using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Problems.Strings;

namespace Problems.Tests.Strings
{
    [TestClass]
    public class ZigZagConversionTests
    {
        [TestMethod]
        public void TestZigZag()
        {
            var s = "PAYPALISHIRING";
            var r = ZigZagConversion.Convert_1(s, 1);
            Assert.AreEqual(s, r);

            /*
             P Y A I H R N
             A P L S I I G
             */
            r = ZigZagConversion.Convert_1(s, 2);
            Assert.AreEqual("PYAIHRNAPLSIIG", r);

            /*
             P   A   H   N
             A P L S I I G
             Y   I   R
             */
            r = ZigZagConversion.Convert_1(s, 3);
            Assert.AreEqual("PAHNA P L S I I GY   I   R".Replace(" ", string.Empty), r);

            /*
             P     I    N     O
             A   L S  I G   E N
             Y A   H R  S M   E
             P     I    O
             */
            var s1 = "PAYPALISHIRINGSOMEONE";
            r = ZigZagConversion.Convert_1(s1, 4);
            Assert.AreEqual("P     I    N     OA   L S  I G   E NY A   H R  S M   EP     I    O".Replace(" ", string.Empty), r);

            /*
            P     H     M 
            A   S I   O E
            Y  I  R  S  O
            P L   I G   N
            A     N     E 
             */
            r = ZigZagConversion.Convert_1(s1, 5);
            Assert.AreEqual("P     H     M A   S I   O EY  I  R  S  OP L   I G   NA     N     E ".Replace(" ", string.Empty), r);
        }
    }
}
