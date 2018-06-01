namespace Crc
{
    public class Crc32Base : CrcBase
    {
        public Crc32Base(uint polynomial, uint initialValue, uint finalXorValue, bool reflectInput, bool reflectOutput, uint? check = null)
            : base(32, polynomial, initialValue, finalXorValue, reflectInput, reflectOutput, check)
        {
        }
    }
}