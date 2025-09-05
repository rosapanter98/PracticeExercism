public static class EliudsEggs
{
    public static int EggCount(int encodedCount)
{
    int count = 0;
    while (encodedCount > 0)
    {
        count += encodedCount & 1; // add 1 if last bit is set
        encodedCount >>= 1;        // shift right
    }
    return count;
}

}
