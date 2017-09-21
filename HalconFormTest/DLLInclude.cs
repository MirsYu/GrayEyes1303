using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace HalconFormTest
{
    public class DLLInclude
    {

        [DllImport("HalconTestDLL")]
        public static extern void Init(HTuple wind);
        [DllImport("HalconTestDLL")]
        public static extern void thisStart();
        [DllImport("HalconTestDLL")]
        public static extern void Close();
    }
}
