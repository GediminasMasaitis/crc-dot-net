namespace Crc
{
    public class Crc16CCITT : CrcBase
    {
        public Crc16CCITT() : base(16, 0x1021, 0xAA55, 0x0, false, false)
        {
        }
    }
}