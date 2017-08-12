using System;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading;

public class DynamicBufferManager
{
	private static System.Threading.Semaphore writeProtect = new System.Threading.Semaphore(1, 1);

	public DynamicBufferManager(int bufferSize)
	{
		this.DataCount = 0;
		this.Buffer = new byte[bufferSize];
	}

	public void Clear()
	{
		writeProtect.WaitOne();
		this.DataCount = 0;
		writeProtect.Release();
	}

	public void Clear(int count)
	{
		writeProtect.WaitOne();
		if (count >= this.DataCount)
		{
			this.DataCount = 0;
		}
		else
		{
			for (int i = 0; i < (this.DataCount - count); i++)
			{
				this.Buffer[i] = this.Buffer[count + i];
			}
			this.DataCount -= count;
		}
		writeProtect.Release();
	}

	public int GetDataCount()
	{
		return this.DataCount;
	}

	public int GetReserveCount()
	{
		return (this.Buffer.Length - this.DataCount);
	}

	public void SetBufferSize(int size)
	{
		writeProtect.WaitOne();
		if (this.Buffer.Length < size)
		{
			byte[] destinationArray = new byte[size];
			Array.Copy(this.Buffer, 0, destinationArray, 0, this.DataCount);
			this.Buffer = destinationArray;
		}
		writeProtect.Release();
	}

	public void WriteBuffer(byte[] buffer)
	{
		this.WriteBuffer(buffer, 0, buffer.Length);
	}

	public void WriteBuffer(byte[] buffer, int offset, int count)
	{
		writeProtect.WaitOne();
		if (this.GetReserveCount() >= count)
		{
			Array.Copy(buffer, offset, this.Buffer, this.DataCount, count);
			this.DataCount += count;
		}
		else
		{
			int num = (this.Buffer.Length + count) - this.GetReserveCount();
			byte[] destinationArray = new byte[num];
			Array.Copy(this.Buffer, 0, destinationArray, 0, this.DataCount);
			Array.Copy(buffer, offset, destinationArray, this.DataCount, count);
			this.DataCount += count;
			this.Buffer = destinationArray;
		}
		writeProtect.Release();
	}

	public void WriteInt(int value, bool convert)
	{
		if (convert)
		{
			value = IPAddress.HostToNetworkOrder(value);
		}
		byte[] bytes = BitConverter.GetBytes(value);
		this.WriteBuffer(bytes);
	}

	public void WriteLong(long value, bool convert)
	{
		if (convert)
		{
			value = IPAddress.HostToNetworkOrder(value);
		}
		byte[] bytes = BitConverter.GetBytes(value);
		this.WriteBuffer(bytes);
	}

	public void WriteShort(short value, bool convert)
	{
		if (convert)
		{
			value = IPAddress.HostToNetworkOrder(value);
		}
		byte[] bytes = BitConverter.GetBytes(value);
		this.WriteBuffer(bytes);
	}

	public void WriteString(string value)
	{
		byte[] bytes = Encoding.UTF8.GetBytes(value);
		this.WriteBuffer(bytes);
	}

	public byte[] Buffer { get; set; }

	public int DataCount { get; set; }
}

