using DotKakasi.Kanji;
using System;
using Xunit;
namespace DotKakasi.Tests
{
    public class DataCorrectnessTest
    {
        [Fact]
        public void test_Itaiji_class()
        {
            var itaiji = Itaiji.Instance;
            Assert.NotNull(itaiji);
        }

        [Fact]
        public void test_Kanwa_class()
        {
            var kanwa = Kanwa.Instance;
            Assert.NotNull(kanwa);
        }
    }
}