# Crc.NET
.NET Standard library for calculating any CRC checksums

## Motivation

I recently wrote a C++ library [crc.h](https://github.com/GediminasMasaitis/crc.h), this is more or less a direct C# port of it, since our codebase consists of both C++ and C# it was useful to have a native C# implementation of it.

## Usage

The main class is `CrcBase`, it implements `System.Security.Cryptography.HashAlgorithm`. There are child classes for popular bit lengths: `Crc8Base`, `Crc16Base`, `Crc32Base`

Configurable parameters are:
* `Size` The bit width of the CRC checksum
* `Polynomial` A polynomial to use for CRC computation
* `InitialValue` Initial value of the checksum
* `FinalXorValue` Value to XOR the rsult with after finishing computation
* `ReflectInput` Whether or not the input is reflected (bit order reversed)
* `ReflectOutput` Whether or not the result is reflected (bit order reversed)
* `ExpectedCheck` A checksum of an ASCII string `"123456789"`. Used as a correctness check. Optional

By providing constructor parameters or deriving child classes, you can construct any CRC implementation. For example:

```csharp
class Crc32 : Crc32Base
{
    public Crc32() : base(0x04C11DB7, 0xFFFFFFFF, 0xFFFFFFFF, true, true)
    {
    }
}
```

The usage is then quite simple:

```csharp
Crc32 crc = new Crc32();
byte[] bytes = Encoding.ASCII.GetBytes("abc123");
byte[] resultBytes = crc.ComputeHash(bytes);
uint resultNum = BitConverter.ToUInt32(resultBytes, 0);
```

The library uses a 256-length lookup table to compute 8 bits of the checksum at the same time for performance reasons. For reflected input, the table is reflected instead. Although more optimizations could be made for specific implementations with concrete parameters, the main goal was generality and customizability. Due to the lookup table however, it should be quite fast. As always - benchmark first, optimize only as needed.