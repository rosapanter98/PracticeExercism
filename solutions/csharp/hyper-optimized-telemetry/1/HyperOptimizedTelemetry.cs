using System;

public static class TelemetryBuffer
{
    // Encode: smallest fitting type, prefix = bytes (unsigned) or 256 - bytes (signed).
    // Buffer is always 9 bytes: [prefix][payload][zeros...]
    public static byte[] ToBuffer(long reading)
    {
        var buf = new byte[9];

        if (reading >= 0 && reading <= ushort.MaxValue)
        {
            buf[0] = 2; // ushort
            Write(BitConverter.GetBytes((ushort)reading), buf, 1);
        }
        else if (reading >= -32768 && reading <= -1)
        {
            buf[0] = 256 - 2; // short
            Write(BitConverter.GetBytes((short)reading), buf, 1);
        }
        else if ((reading >= 65536 && reading <= int.MaxValue) ||
                 (reading >= int.MinValue && reading <= -32769))
        {
            buf[0] = 256 - 4; // int
            Write(BitConverter.GetBytes((int)reading), buf, 1);
        }
        else if (reading >= (long)uint.MinValue && reading <= uint.MaxValue)
        {
            buf[0] = 4; // uint
            Write(BitConverter.GetBytes((uint)reading), buf, 1);
        }
        else
        {
            buf[0] = 256 - 8; // long
            Write(BitConverter.GetBytes(reading), buf, 1);
        }

        return buf;
    }

    // Decode: use prefix to determine signedness/size. Invalid prefix -> 0.
    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 1) return 0;

        switch (buffer[0])
        {
            case 2:      return ReadU16(buffer, 1);
            case 254:    return ReadI16(buffer, 1); // 256 - 2
            case 4:      return ReadU32(buffer, 1);
            case 252:    return ReadI32(buffer, 1); // 256 - 4
            case 248:    return ReadI64(buffer, 1); // 256 - 8
            default:     return 0;
        }
    }

    // --- helpers ---
    private static void Write(byte[] src, byte[] dst, int offset)
    {
        if (!BitConverter.IsLittleEndian) Array.Reverse(src);
        Array.Copy(src, 0, dst, offset, src.Length);
    }

    private static long ReadI64(byte[] b, int o)
    {
        if (b.Length < o + 8) return 0;
        var tmp = new byte[8]; Array.Copy(b, o, tmp, 0, 8);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);
        return BitConverter.ToInt64(tmp, 0);
    }

    private static long ReadI32(byte[] b, int o)
    {
        if (b.Length < o + 4) return 0;
        var tmp = new byte[4]; Array.Copy(b, o, tmp, 0, 4);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);
        return BitConverter.ToInt32(tmp, 0);
    }

    private static long ReadU32(byte[] b, int o)
    {
        if (b.Length < o + 4) return 0;
        var tmp = new byte[4]; Array.Copy(b, o, tmp, 0, 4);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);
        return BitConverter.ToUInt32(tmp, 0);
    }

    private static long ReadI16(byte[] b, int o)
    {
        if (b.Length < o + 2) return 0;
        var tmp = new byte[2]; Array.Copy(b, o, tmp, 0, 2);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);
        return BitConverter.ToInt16(tmp, 0);
    }

    private static long ReadU16(byte[] b, int o)
    {
        if (b.Length < o + 2) return 0;
        var tmp = new byte[2]; Array.Copy(b, o, tmp, 0, 2);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);
        return BitConverter.ToUInt16(tmp, 0);
    }
}
