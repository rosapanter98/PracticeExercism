using System;
using System.Linq;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        var bytes = reading switch
        {
            < int.MinValue => BitConverter.GetBytes(reading).Prepend((byte)248), // 256 - 8
            < short.MinValue => BitConverter.GetBytes((int)reading).Prepend((byte)252), // 256 - 4
            < ushort.MinValue => BitConverter.GetBytes((short)reading).Prepend((byte)254), // 256 - 2
            <= ushort.MaxValue => BitConverter.GetBytes((ushort)reading).Prepend((byte)2),
            <= int.MaxValue => BitConverter.GetBytes((int)reading).Prepend((byte)252),
            <= uint.MaxValue => BitConverter.GetBytes((uint)reading).Prepend((byte)4),
            _ => BitConverter.GetBytes(reading).Prepend((byte)248),
        };

        return bytes.Concat(new byte[9 - bytes.Count()]).ToArray();
    }

    public static long FromBuffer(byte[] buffer) => buffer[0] switch
    {
        2   => BitConverter.ToUInt16(buffer, 1),
        254 => BitConverter.ToInt16(buffer, 1),
        4   => BitConverter.ToUInt32(buffer, 1),
        252 => BitConverter.ToInt32(buffer, 1),
        248 => BitConverter.ToInt64(buffer, 1),
        _   => 0,
    };
}
