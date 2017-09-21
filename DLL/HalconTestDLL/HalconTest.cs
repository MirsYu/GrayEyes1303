using HalconDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace HalconTestDLL
{
    public class HalconTest
    {
        public static void Init(HTuple wind)
        {
            HDevelopExport.mWindow = wind;
            HDevelopExport.acquireimage();
        }

        public static void thisStart( )
        {
            HDevelopExport.acquireimage();
        }

        public static HTuple Change(HWindow wind)
        {
            return wind;
        }
    }
}
