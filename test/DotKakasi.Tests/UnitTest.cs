using DotKakasi.Kanji;
using System;
using System.Collections.Generic;
using Xunit;

namespace DotKakasi.Tests
{
    public class UnitTest
    {
        [Fact]
        public void test_itaiji()
        {
            var dic = new Dictionary<string,string>{
                {"菟", "兎"},
                {"菟集", "兎集"},
                {"熙", "煕" },
                { "壱弍", "一二"},
                { "森鷗外", "森鴎外"}
            };
            var j = new J2("H");
            foreach(var kv in dic)
            {
                var re = j.itaiji_conv(kv.Key);
                Assert.Equal(kv.Value, re);
            }

        }
    }
}
