using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;
using System.Threading;

namespace VisionPlatform.NetCamera
{
	public class Camera
	{
		private string camIP = "";
		public string CameraIP
		{
			get { return camIP; }
			set { camIP = value; }
		}

		private Image camImg;
		public Image CameraImg
		{
			get { return camImg; }
			set { camImg = value; }
		}

		private string mgateWay;
		public string mGateWay
		{
			get { return mgateWay; }
			set { mgateWay = value; }
		}

		public void GetGateWay()
		{
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface network in nics)
			{
				string strTestMac = network.GetPhysicalAddress().ToString();
				if (strTestMac == "40490F231791" || strTestMac == "b644205b733a")
				{
					IPInterfaceProperties ip = network.GetIPProperties();
					GatewayIPAddressInformationCollection getways = ip.GatewayAddresses;
					foreach (var gateway in getways)
					{
						if (IsPingIP(gateway.Address.ToString()))
						{
							mGateWay = gateway.Address.ToString();
							break;
						}
					}
					break;
				}
				else
					mGateWay = "GateWay is Error";
			}
		}

		public void GetCameraIP()
		{
			int index = -1;
			index = mGateWay.LastIndexOf('.') + 1;
			mGateWay = mGateWay.Remove(index, mGateWay.Length - index);

			List<int> lTh1 = new List<int>() {2,127 };
			List<int> lTh2 = new List<int>() { 128, 254 };
			Thread th1 = new Thread(new ParameterizedThreadStart(ThreadScan));
			Thread th2 = new Thread(new ParameterizedThreadStart(ThreadScan));
			th1.IsBackground = true;
			th2.IsBackground = true;
			th1.Start(lTh1);
			th2.Start(lTh2);
		}

		private bool IsPingIP(string strIP)
		{
			try
			{
				Ping ping = new Ping();
				PingReply reply = ping.Send(strIP, 500);
				if (reply.Status == IPStatus.Success)
				{
					ping = null;
					reply = null;
					GC.Collect();
					return true;
				}
				else
				{
					return false;
				}
			}
			catch
			{
				return false;
			}
		}

		private void ThreadScan(object mParameter)
		{
			List<int> par = mParameter as List<int>;
			string readyIP = "";
			for (int i = par[0]	; i < par[1]; i++)
			{
				readyIP = mGateWay + i.ToString();
				if (IsPingIP(readyIP))
					CheckPackage(readyIP);
			}
		}

		#region CheckPackage

		public DynamicBufferManager recDynBuffer;
		private byte[] startCode;
		private byte[] endCode;
		private Thread threadClient;
		private int length;
		private int lastEndPosition;
		private int lastStartPosition;
		private Stream recStream;

		private bool bResult = false;

		public bool CheckPackage(string strIpAddress)
		{
			recDynBuffer = new DynamicBufferManager(0xa00000);
			this.startCode = new byte[] { 0xff, 0xd8, 0xff };
			this.endCode = new byte[] { 0xff, 0xd9 };
			byte[] buffMsgRec = new byte[0xa00000];

			IPAddress ip = IPAddress.Parse(strIpAddress);
			try
			{
				Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
				socket.Connect(new IPEndPoint(ip, 20000));
				threadClient = new Thread(new ParameterizedThreadStart(this.ReceiveData));
				threadClient.IsBackground = true;
				threadClient.Start(socket);
				if (socket.Poll(-1,SelectMode.SelectRead))
				{
					int nRead = socket.Receive(buffMsgRec);
					if (nRead == 0)
					{
						return false;
					}
				}
				return true;
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
				if (!showData())
				{
					clien.Close();
					break;
				}
				else
					CameraIP = ((System.Net.IPEndPoint)clien.RemoteEndPoint).AddressFamily.ToString();
			}
		}

		private bool showData()
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
					this.lastEndPosition = num2;
					this.recStream = new MemoryStream(this.recDynBuffer.Buffer, startIndex, num2 - startIndex);
					Image image = Image.FromStream(recStream, true);
					CameraImg = image;
					return true;
				}
			}
			return false;
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

	}
}
