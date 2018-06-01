namespace Crc
{
    public class Crc8Base : CrcBase
    {
        public Crc8Base(byte polynomial, byte initialValue, byte finalXorValue, bool reflectInput, bool reflectOutput, byte? check = null)
            : base(8, polynomial, initialValue, finalXorValue, reflectInput, reflectOutput, check)
        {
        }
    }
}