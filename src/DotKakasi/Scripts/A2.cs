using DotKakasi.Common;

namespace DotKakasi.Scripts
{
    public class A2
    {
        public A2(string mode)
        {

        }
        public bool IsRegion(char ch)
        {
            return new Ch().space <= (int)ch &&  (int)ch < new Ch().delete;
        }
    }
}