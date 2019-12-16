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
        public (char, int) Convert(string text)
        {
            return _mode == "a" ? convert_a(text) : convert_noop(text);
        }
        private char _convert(string text)
        {
            var c = (int)text[0];

        if (Ch.ideographic_space <= c && c <= Ch.postal_mark_face)

            return ConvertTables.symbol_table_1[c - Ch.ideographic_space];

        else if (Ch.wavy_dash <= c && c<= Ch.ideographic_half_fill_space)

            return ConvertTables.symbol_table_2[c - Ch.wavy_dash];

        else if (Ch.greece_Alpha <= c && c <= Ch.greece_Omega)

            return ConvertTables.symbol_table_3[c - Ch.greece_Alpha];

        else if (Ch.greece_alpha <= c && c <= Ch.greece_omega)

            return ConvertTables.symbol_table_4[c - Ch.greece_alpha];

        else if (Ch.cyrillic_A <= c && c <= Ch.cyrillic_ya)

            return ConvertTables.cyrillic_table[text[0]];

        else if (c == Ch.cyrillic_E || c == Ch.cyrillic_e)

            return ConvertTables.cyrillic_table[text[0]];

        else if (Ch.zenkaku_exc_mark <= c&& c <= Ch.zenkaku_slash_mark)

            return ConvertTables.symbol_table_5[c - Ch.zenkaku_exc_mark];

        else if (Ch.zenkaku_number_zero <= c && c <= Ch.zenkaku_number_nine)

            return (char)(c - Ch.zenkaku_number_zero + (int)'0');

        else if (0xff20 <= c && c <= 0xff40)

            return (char)(0x0041 + c - 0xff21);  // u\ff21Ａ => u\0041:@A..Z[\]^_`

        else if (0xff41 <= c && c < 0xff5f)

            return (char)(0x0061 + c - 0xff41);  // u\ff41ａ => u\0061:a..z{|}

        else

            return ' ';  // pragma: no cover

    }

     private (char, int) convert_a(string text)
     {
        var t = _convert(text);
        if (t != ' ')
            return (t, 1);
        else
            return (' ', 0);
      }

      private (char, int) convert_noop(string text)
      {
        return (text[0], 1);
      }
    }
}
