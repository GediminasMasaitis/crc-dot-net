namespace Crc
{
    public class Crc32 : CrcBase
    {
        public Crc32() : base(32, 0x04C11DB7, 0xFFFFFFFF, 0xFFFFFFFF, true, true)
        {
        }
    }
}