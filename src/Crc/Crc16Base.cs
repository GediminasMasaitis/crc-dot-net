namespace Crc
{
    public class Crc16Base : CrcBase
    {
        public Crc16Base(ushort polynomial, ushort initialValue, ushort finalXorValue, bool reflectInput, bool reflectOutput)
            : base(16, polynomial, initialValue, finalXorValue, reflectInput, reflectOutput)
        {
        }
    }
}