using DotKakasi.Common;

namespace DotKakasi.Scripts
{
    public class Sym2
    {
        private readonly string _mode;
        public Sym2(string mode)
        {
            _mode = mode;
        }
        public bool isRegion(char ch)
        {
            var c = (int)ch;
            return (Ch.ideographic_space <= c && c <= Ch.postal_mark_face) ||
               (Ch.wavy_dash <= c && c <= Ch.ideographic_half_fill_space) ||
               (Ch.greece_Alpha <= c && c <= Ch.greece_Rho) ||
               (Ch.greece_Sigma <= c && c <= Ch.greece_Omega) ||
               (Ch.greece_alpha <= c && c <= Ch.greece_omega) ||
               (Ch.cyrillic_A <= c && c <= Ch.cyrillic_ya) ||
               (Ch.zenkaku_exc_mark <= c && c <= Ch.zenkaku_number_nine) ||
               (0xff20 <= c && c <= 0xff5e) || 
               c == 0x0451 || 
               c == 0x0401;
        }
    }
}