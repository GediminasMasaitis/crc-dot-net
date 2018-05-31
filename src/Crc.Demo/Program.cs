using System;
using System.Text;

namespace Crc.Demo
{
    class Program
    {
        class Crc32 : Crc32Base
        {
            public Crc32() : base(0x04C11DB7, 0xFFFFFFFF, 0xFFFFFFFF, true, true)
            {
            }
        }

        static void Main(string[] args)
        {
            var runner = new KnownCrcCheckRunner();
            runner.RunChecks();

            var crc = new Crc32();
            var bytes = Encoding.ASCII.GetBytes("abc123");
            var crcResult = crc.ComputeHash(bytes);
            var crcResultNum = BitConverter.ToUInt32(crcResult, 0);
            Console.ReadLine();
        }
    }
}
