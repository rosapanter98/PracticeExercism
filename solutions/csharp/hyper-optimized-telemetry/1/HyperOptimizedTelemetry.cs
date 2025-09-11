using System;

public static class TelemetryBuffer
{
    public static byte[] ToBuffer(long reading)
    {
        (byte prefix, byte[] payload, int count) Encode()
        {
            if (reading >= 0 && reading <= ushort.MaxValue)
                return (2, BitConverter.GetBytes((ushort)reading), 2);
    
            if (reading >= 65_536 && reading <= int.MaxValue)
                return ((byte)(256 - 4), BitConverter.GetBytes((int)reading), 4);
    
            if (reading >= 2_147_483_648 && reading <= uint.MaxValue)
                return (4, BitConverter.GetBytes((uint)reading), 4);
    
            if (reading >= 4_294_967_296 && reading <= long.MaxValue)
                return ((byte)(256 - 8), BitConverter.GetBytes(reading), 8);
    
            if (reading >= short.MinValue && reading <= -1)
                return ((byte)(256 - 2), BitConverter.GetBytes((short)reading), 2);
    
            if (reading >= int.MinValue && reading <= -32_769)
                return ((byte)(256 - 4), BitConverter.GetBytes((int)reading), 4);
    
            // [long.MinValue .. -2_147_483_649]
            return ((byte)(256 - 8), BitConverter.GetBytes(reading), 8);
        }
    
        var (prefix, payload, count) = Encode();
    
        if (!BitConverter.IsLittleEndian) Array.Reverse(payload, 0, count);
    
        var buffer = new byte[9];
        buffer[0] = prefix;
        Buffer.BlockCopy(payload, 0, buffer, 1, count);
        return buffer;
    }


    // Decode: return 0 on unexpected prefix.
    public static long FromBuffer(byte[] buffer)
    {
        if (buffer == null || buffer.Length < 2) return 0;

        byte prefix = buffer[0];
        int count = prefix switch
        {
            2   => 2,   // ushort
            4   => 4,   // uint
            254 => 2,   // short
            252 => 4,   // int
            248 => 8,   // long
            _   => 0
        };
        if (count == 0 || buffer.Length < 1 + count) return 0;

        // Extract payload (little-endian for protocol)
        var tmp = new byte[count];
        Buffer.BlockCopy(buffer, 1, tmp, 0, count);
        if (!BitConverter.IsLittleEndian) Array.Reverse(tmp);

        return prefix switch
        {
            2   => (long)BitConverter.ToUInt16(tmp, 0),
            4   => (long)BitConverter.ToUInt32(tmp, 0),
            254 => BitConverter.ToInt16(tmp, 0),
            252 => BitConverter.ToInt32(tmp, 0),
            248 => BitConverter.ToInt64(tmp, 0),
            _   => 0
        };
    }
}
