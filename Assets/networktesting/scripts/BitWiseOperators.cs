public class bitwiseoperators
{
    public static class bitwiseOperations
    {
        static byte setTrue(byte data, int pos)
        {
            return (byte)(data | (1 << pos));
        }
        static byte setFalse(byte data, int pos)
        {
            return (byte)(data & ~(1 << pos));
        }
        static public byte setBit(byte data, int pos, bool input)
        {
            byte x1 = data;
            if (input)
            {
                x1 = setTrue(x1, pos);
            }
            if (!input)
            {
                x1 = setFalse(x1, pos);
            }
            return x1;
        }
    }
}
