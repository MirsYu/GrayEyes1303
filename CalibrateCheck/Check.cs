using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CalibrateCheck
{
    public class Check
    {
		public static void InputParam(double[] X,double[] Y,double baseX,double baseY,
			double MachineDistance,String axis,double DistanceOneMilimeter,double DistanceOnePixel)
		{
			if (X.Length == Y.Length)
			{
				double[] machineX = new double[X.Length];
				double[] machineY = new double[Y.Length];
				double[] alenght = new double[X.Length];
				double[] blenght = new double[X.Length];
				double[] axb = new double[X.Length];
				double[] abcos = new double[X.Length];
				double[] lengthprop = new double[X.Length];
				for (int i = 0; i < X.Length; i++)
				{
					machineX[i] = 0D;
					machineY[i] = 0D;
				}
				// 首先根据轴的运动方向和距离生成对应的数组
				if (axis == "X" || axis == "x")
				{
					for (int i = 0; i < X.Length; i++)
					{
						machineX[i] = i * MachineDistance;
					}
				}
				else if (axis == "Y" || axis == "y")
				{
					for (int i = 0; i < X.Length; i++)
					{
						machineY[i] = i * MachineDistance;
					}
				}
				else if (axis == "XY" || axis == "xy")
				{
					for (int i = 0; i < X.Length; i++)
					{
						machineX[i] = i * MachineDistance;
						machineY[i] = i * MachineDistance;
					}
				}
				else
					return ; // error
				// 以基准点 重组数组
				for (int i = 0; i < X.Length; i++)
				{
					X[i] -= baseX;
					Y[i] -= baseY;
				}

				// 每个向量计算
				for (int i = 0; i < X.Length; i++)
				{
					// a向量 机械
					alenght[i] = Math.Pow(Math.Pow(machineX[i], 2) + Math.Pow(machineY[i], 2), 0.5); //模长
					// b向量 图像
					blenght[i] = Math.Pow(Math.Pow(X[i], 2) + Math.Pow(Y[i], 2), 0.5);
					// 向量积
					axb[i] = X[i] * machineX[i] + Y[i] * machineY[i];
					// 反余弦  角度
					abcos[i] = Math.Acos(axb[i] / (alenght[i] * blenght[i]))/Math.PI*180;
					// 长度比值
					lengthprop[i] = blenght[i] / alenght[i];
				}

				// 以每个角度和长宽比 反推实际坐标
				for (int i = 0; i < X.Length; i++)
				{
					for (int j = 0; j < X.Length; j++)
					{
						// 计算出的B的模长
						double checkb = alenght[j] * lengthprop[i];
						// 根据角度算出两者的向量积
						double checkaxb = alenght[j] * checkb *(axb[i] / (alenght[i] * blenght[i]));
						
					}
				}
			}
		}
    }
}
