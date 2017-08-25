using Emgu.Util;
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

namespace FindCamera.NetCamera
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

		private string localMac;
		public string LocalMac
		{
			get { return localMac; }
			set { localMac = value; }
		}

		private string mgateWay;
		public string mGateWay
		{
			get { return mgateWay; }
			set { mgateWay = value; }
		}

		private int m_thCout;
		public int thCout
		{
			get { return m_thCout; }
			set { m_thCout = value; }
		}


		private List<Thread> ScanIP = new List<Thread>();
		public List<Thread> scanIP
		{
			get { return ScanIP; }
		}

		public void GetGateWay()
		{
			NetworkInterface[] nics = NetworkInterface.GetAllNetworkInterfaces();
			foreach (NetworkInterface network in nics)
			{
				string strTestMac = network.GetPhysicalAddress().ToString();
				if (strTestMac == LocalMac)
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
			//mGateWay = "192.168.0.1";
			index = mGateWay.LastIndexOf('.') + 1;
			mGateWay = mGateWay.Remove(index, mGateWay.Length - index);

			int step = 255 / thCout;
			int pick = 255 - (step * thCout);
			for (int i = 0; i < thCout; i++)
			{
				List<int> lTh = new List<int> { i == 0 ? 2 : (i * step) + 1, i == thCout - 1 ? ((i + 1) * step) + pick : ((i + 1) * step) };
				Thread th = new Thread(new ParameterizedThreadStart(ThreadScan));
				th.IsBackground = true;
				th.Start(lTh);
				ScanIP.Add(th);
			}
		}

		private bool IsPingIP(string strIP)
		{
			try
			{
				Ping ping = new Ping();
				PingReply reply = ping.Send(strIP, 1000);
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
			for (int i = par[0]; i < par[1]; i++)
			{
				readyIP = mGateWay + i.ToString();
				if (IsPingIP(readyIP))
				{
					try
					{
						Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
						socket.Connect(new IPEndPoint(IPAddress.Parse(readyIP), 20000));
						CameraIP = ((System.Net.IPEndPoint)socket.RemoteEndPoint).Address.ToString();
						socket.Close();
						CheckPackage();
						GC.Collect();
						return;
					}
					catch (Exception)
					{
						GC.Collect();
					}
				}
			}
		}

		#region CheckPackage

		public DynamicBufferManager recDynBuffer;
		private byte[] startCode;
		private byte[] endCode;
		private Thread threadClient;
		public Thread Client
		{
			get { return threadClient; }
		}
		private int length;
		private int lastEndPosition;
		private int lastStartPosition;
		private Stream recStream;

		private Socket socketClient;
		public Socket socket
		{
			get { return socketClient; }
			set { socketClient = value; }
		}

		public void CheckPackage()
		{
			IPAddress ip = IPAddress.Parse(CameraIP);
			recDynBuffer = new DynamicBufferManager(0xa00000);
			this.startCode = new byte[] { 0xff, 0xd8, 0xff };
			this.endCode = new byte[] { 0xff, 0xd9 };

			socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
			socket.Connect(ip, 20000);
			threadClient = new Thread(new ParameterizedThreadStart(ReceiveData));
			threadClient.IsBackground = true;
			threadClient.Start(socket);

		}

		private void ReceiveData(object cilentsocket)
		{
			byte[] buffMsgRec = new byte[0xa00000];
			Socket socket = cilentsocket as Socket;
			for (int i = 0; i < ScanIP.Count; i++)
			{
				ScanIP[i].Abort();
			}
			ScanIP.Clear();
			GC.Collect();
			while (true)
			{
				length = socket.Receive(buffMsgRec);
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
			if (startIndex != -1)
			{
				this.lastStartPosition = startIndex;
				num2 = this.IndexOf(this.recDynBuffer.Buffer, this.endCode, startIndex, this.recDynBuffer.DataCount);
				if (num2 != -1)
				{
					this.lastEndPosition = num2;
					this.recStream = new MemoryStream(this.recDynBuffer.Buffer, startIndex, num2 - startIndex);
					Image image = Image.FromStream(recStream, true);
					CameraImg = image;
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

		public void dispose()
		{
			socketClient.Dispose();
			ScanIP.Clear();
			recStream.Dispose();
			recDynBuffer.Clear();
			GC.Collect();
			GC.SuppressFinalize(this);
		}
	}
}
