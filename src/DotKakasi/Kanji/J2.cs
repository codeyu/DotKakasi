using System;

namespace DotKakasi.Kanji
{
    public class J2
    {
        private readonly Kanwa _kanwa = Kanwa.Instance;
        private readonly Itaiji _itaiji = Itaiji.Instance;
        private readonly string[] _cl_table = new string[]
        {
            "", "aiueow", "aiueow", "aiueow", "aiueow", "aiueow", "aiueow", "aiueow",
                 "aiueow", "aiueow", "aiueow", "k", "g", "k", "g", "k", "g", "k", "g", "k",
                 "g", "s", "zj", "s", "zj", "s", "zj", "s", "zj", "s", "zj", "t", "d", "tc",
                 "d", "aiueokstchgzjfdbpw", "t", "d", "t", "d", "t", "d", "n", "n", "n", "n",
                 "n", "h", "b", "p", "h", "b", "p", "hf", "b", "p", "h", "b", "p", "h", "b",
                 "p", "m", "m", "m", "m", "m", "y", "y", "y", "y", "y", "y", "rl", "rl",
                 "rl", "rl", "rl", "wiueo", "wiueo", "wiueo", "wiueo", "w", "n", "v", "k",
                 "k", "", "", "", "", "", "", "", "", ""
        };

        public J2(string mode = "H", string method= "Hepburn")
        {
            
        }

        public object itaiji_conv(string key)
        {
            throw new NotImplementedException();
        }
    }
}