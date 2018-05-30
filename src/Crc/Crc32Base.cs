namespace Crc
{
    public class Crc32Base : CrcBase
    {
        public Crc32Base(uint polynomial, uint initialValue, uint finalXorValue, bool reflectInput, bool reflectOutput)
            : base(32, polynomial, initialValue, finalXorValue, reflectInput, reflectOutput)
        {
        }
    }
}