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
			txtBox_GateWay.Text = GetGateWay();
		}

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
				PingReply reply = ping.Send(strIP, 1000);
				return true;
			}
			catch
			{
				return false;
			}
		}
	}
}
