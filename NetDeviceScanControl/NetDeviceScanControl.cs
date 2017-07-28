using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Management;
using System.Management.Instrumentation;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace NetDeviceScanControl
{
	public partial class NetDeviceScanControl : UserControl
	{
		public NetDeviceScanControl()
		{
			InitializeComponent();
		}

		private void btn_GetDeviceIP_Click(object sender, EventArgs e)
		{
			string strGateWay = "";
			strGateWay = GetGateWay();
			txtBox_GateWay.Text = strGateWay;
			txtBox_TargetIP.Text = ScanActiveIP(strGateWay);
		}

		public string ScanActiveIP(string strGateWay)
		{
			string strPingIp = "";
			int index = -1;
			Ping ping;
			index = strGateWay.LastIndexOf('.')+1;
			strPingIp = strGateWay.Remove(index, strGateWay.Length - index);
			for (int ipIndex =1; ipIndex < 255; ipIndex++)
			{
				strPingIp = strGateWay.Remove(index, strGateWay.Length - index);
				ping = new Ping();
				strPingIp += ipIndex.ToString();
				if(IsPingIP(strPingIp))
				{
					if (CheckPackage(strPingIp))
					{
						return strPingIp;
					}
				}
			}
			return "Error";
		}

		#region CheckPackage

		public DynamicBufferManager recDynBuffer;
		private byte[] startCode;
		private byte[] endCode;
		private Thread threadClient;
		private int length;
		private int lastEndPosition;
		private int lastStartPosition;

		private bool bResult = false;

		public bool CheckPackage(string strIpAddress)
		{
			recDynBuffer = new DynamicBufferManager(0xa00000);
			this.startCode = new byte[] { 0xff, 0xd8, 0xff };
			this.endCode = new byte[] { 0xff, 0xd9 };

			//socket.Blocking = false;
			IPAddress ip = IPAddress.Parse(strIpAddress);
			try
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(new IPEndPoint(ip, 20000));
				threadClient = new Thread(new ParameterizedThreadStart(this.ReceiveData));
				threadClient.IsBackground = true;
				threadClient.Start(socket);
				Thread.Sleep(2000);
				if (strIpAddress == "192.168.0.106")
				{

				}
				if (bResult)
					return true;
				else
					return false;
			}
			catch (Exception)
			{
				return false;
			}

		}

		private void ReceiveData(object clienSocket)
		{
			byte[] buffMsgRec = new byte[0xa00000];
			Socket clien = clienSocket as Socket;
			while (true)
			{
				length = clien.Receive(buffMsgRec);
				this.recDynBuffer.WriteBuffer(buffMsgRec, 0, length);
				showData();
			}
		}

		private void showData()
		{
			int startIndex = -1;
			int num2 = -1;
			if ((this.lastStartPosition != -1) && (this.lastEndPosition != -1))
			{
				this.recDynBuffer.Clear(this.lastEndPosition);
				this.lastStartPosition = this.lastEndPosition = -1;
			}
			startIndex = this.IndexOf(this.recDynBuffer.Buffer, this.startCode, 0, this.recDynBuffer.DataCount);
			if (startIndex != -1 && bResult == false)
			{
				this.lastStartPosition = startIndex;
				num2 = this.IndexOf(this.recDynBuffer.Buffer, this.endCode, startIndex, this.recDynBuffer.DataCount);
				if (num2 != -1)
				{
					bResult = true;
				}
			}
		}

		internal int IndexOf(byte[] srcBytes, byte[] searchBytes, int startIndex, int srcLength)
		{
			if (srcBytes != null)
			{
				if (searchBytes == null)
				{
					return -1;
				}
				if ((srcLength == 0) || (srcLength > srcBytes.Length))
				{
					return -1;
				}
				if ((startIndex >= srcBytes.Length) || (startIndex < 0))
				{
					return -1;
				}
				if (searchBytes.Length != 0)
				{
					if (srcLength < searchBytes.Length)
					{
						return -1;
					}
					for (int i = startIndex; i < (srcLength - searchBytes.Length); i++)
					{
						if (srcBytes[i] != searchBytes[0])
						{
							continue;
						}
						if (searchBytes.Length == 1)
						{
							return i;
						}
						bool flag = true;
						for (int j = 1; j < searchBytes.Length; j++)
						{
							if (srcBytes[i + j] != searchBytes[j])
							{
								flag = false;
								break;
							}
						}
						if (flag)
						{
							return i;
						}
					}
				}
			}
			return -1;
		}
		#endregion

		public string GetGateWay()
		{
			string strGateWay = "";
			// Get All NetCard
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface network in nics)
			{
				if (network.GetPhysicalAddress().ToString() == txtBox_MacAddress.Text)
				{
					// single NetCard
					IPInterfaceProperties ip = network.GetIPProperties();
					GatewayIPAddressInformationCollection gateways = ip.GatewayAddresses;
					foreach (var gateWay in gateways)
					{
						if (IsPingIP(gateWay.Address.ToString()))
						{
							strGateWay = gateWay.Address.ToString();
							break;
						}
					}
					break;
				}
				else
				{
					strGateWay = "Error";
				}
			}
			return strGateWay;
		}

		public string GetMacAddress()
		{
			string mac = "";
			string ip = "";
			try
			{
				ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
				ManagementObjectCollection moc = mc.GetInstances();
				foreach (ManagementObject mobj in moc)
				{
					if ((bool)mobj["IPEnabled"] == true)
					{
						mac = mobj.Properties["MacAddress"].Value.ToString();
						if (mac == txtBox_MacAddress.Text)
						{
							Array arr;
							arr = (Array)mobj.Properties["IPAddress"].Value;
							foreach (var ipaddres in arr)
							{
								if (IsRightIP(ipaddres.ToString()))
								{
									ip = ipaddres.ToString();
									break;
								}
							}
							break;
						}
					}
				}
				moc = null;
				mc = null;
				return ip;
			}
			catch (Exception)
			{
				return "UNKNOW";
			}
		}

		public string GetIPAddress()
		{
			string strLocalIP = "";
			string strPcName = Dns.GetHostName();
			IPHostEntry ipEntry = Dns.GetHostEntry(strPcName);
			foreach (var IPadd in ipEntry.AddressList)
			{
				// Check this string is IP address
				if (IsRightIP(IPadd.ToString()))
				{
					strLocalIP = IPadd.ToString();
					break;
				}
			}
			return strLocalIP;
		}

		public static bool IsRightIP(string strIPadd)
		{
			if (Regex.IsMatch(strIPadd, "[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}\\.[0-9]{1,3}"))
			{
				// ip analysis
				string[] ips = strIPadd.Split('.');
				if (ips.Length == 4 || ips.Length == 6)
				{
					try
					{
						// IPV4
						if (Int32.Parse(ips[0]) < 256 && Int32.Parse(ips[1]) < 256
							&& Int32.Parse(ips[2]) < 256 && Int32.Parse(ips[3]) < 256)
						{
							return true;
						}
						else
						{
							return false;
						}
					}
					catch (Exception)
					{
						return false;
					}

				}
				else
				{
					return false;
				}
			}
			else
			{
				return false;
			}
		}

		public static bool IsPingIP(string strIP)
		{
			try
			{
				Ping ping = new Ping();
				PingReply reply = ping.Send(strIP, 500);
				if (reply.Status == IPStatus.Success)
				{
					return true;
				}else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}
	}
}
