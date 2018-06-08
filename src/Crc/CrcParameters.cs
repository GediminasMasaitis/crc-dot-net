namespace Crc
{
    public class CrcParameters
    {
        public byte Size { get; }
        public ulong Polynomial { get; }
        public ulong InitialValue { get; }
        public ulong FinalXorValue { get; }
        public bool ReflectInput { get; }
        public bool ReflectOutput { get; }
        public ulong? ExpectedCheck { get; }

        public CrcParameters(byte size, ulong polynomial, ulong initialValue, ulong finalXorValue, bool reflectInput, bool reflectOutput, ulong? expectedCheck = null)
        {
            Size = size;
            Polynomial = polynomial;
            InitialValue = initialValue;
            FinalXorValue = finalXorValue;
            ReflectInput = reflectInput;
            ReflectOutput = reflectOutput;
            ExpectedCheck = expectedCheck;
        }

        protected bool Equals(CrcParameters other)
        {
            return Size == other.Size && Polynomial == other.Polynomial && InitialValue == other.InitialValue && FinalXorValue == other.FinalXorValue && ReflectInput == other.ReflectInput && ReflectOutput == other.ReflectOutput && ExpectedCheck == other.ExpectedCheck;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((CrcParameters) obj);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = Size.GetHashCode();
                hashCode = (hashCode * 397) ^ Polynomial.GetHashCode();
                hashCode = (hashCode * 397) ^ InitialValue.GetHashCode();
                hashCode = (hashCode * 397) ^ FinalXorValue.GetHashCode();
                hashCode = (hashCode * 397) ^ ReflectInput.GetHashCode();
                hashCode = (hashCode * 397) ^ ReflectOutput.GetHashCode();
                hashCode = (hashCode * 397) ^ ExpectedCheck.GetHashCode();
                return hashCode;
            }
        }
    }
}