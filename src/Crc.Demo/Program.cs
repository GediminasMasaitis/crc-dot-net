using System;
using System.Text;

namespace Crc.Demo
{
    class Program
    {
        static void Main(string[] args)
        {
            //var crc = new CrcBase(16, 0x1021, 0xAA55, 0x0, false, false);
            //var crc = new CrcBase(32, 0x1021, 0xAA55, 0x0, false, false);
            var crc = new Crc32();
            var bytes = Encoding.ASCII.GetBytes("abc123");
            var crcResult = crc.ComputeHash(bytes);
            var crcResultNum = BitConverter.ToUInt32(crcResult, 0);
            //var crcResultShort = BitConverter.ToUInt16(crcResult, 0);
            Console.ReadLine();
        }
    }
}
