using DotKakasi.Common;

namespace DotKakasi.Scripts
{
    public class A2
    {
        private readonly string _mode;
        public A2(string mode)
        {
            _mode = mode;
        }
        public bool IsRegion(char ch)
        {
            return Ch.space <= (int)ch &&  (int)ch < Ch.delete;
        }
        public (char, int) Convert(string text)
        {
            return _mode == "E" ? convert_E(text) : convert_noop(text);
        }

        private char _convert(string text)
        {
            var c = (int)text[0];
            if (Ch.space <= c && c <= Ch.at_mark)
            {
                return ConvertTables.alpha_table_1[(c - Ch.space)];
            }
            else if (Ch.alphabet_A <= c && c <= Ch.alphabet_Z)
            {
                // u\0041A => u\ff21£Á
                return (char)(Ch.zenkaku_A + c - Ch.alphabet_A);
            }
            else if (Ch.square_bra <= c && c <= Ch.back_quote)
                return ConvertTables.alpha_table_2[(c - Ch.square_bra)];
            else if (Ch.alphabet_a <= c && c <= Ch.alphabet_z)
                return (char)(Ch.zenkaku_a + c - Ch.alphabet_a);  // u\0061a => u\ff41£á
            else if (Ch.bracket_bra <= c && c <= Ch.tilda)
                return ConvertTables.alpha_table_3[(c - Ch.bracket_bra)];
            else
                return ' ';
        }
        private (char, int) convert_E(string text)
        {
            var t = _convert(text);
            if (t != ' ')
                return (t, 1);
            return (' ', 0);
        }
        private (char, int) convert_noop(string text)
        {
            return (text[0], 1);
        }
    }
}