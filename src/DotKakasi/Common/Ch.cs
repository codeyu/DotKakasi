namespace DotKakasi.Common
{
    public static class Ch
    {
        public static int space => 0x20;
        public static int at_mark => 0x40;
        public static int alphabet_A => 0x41;
        public static int alphabet_Z => 0x5a;
        public static int square_bra => 0x5b;
        public static int back_quote => 0x60;
        public static int alphabet_a => 0x61;
        public static int alphabet_z => 0x7a;
        public static int bracket_bra => 0x7b;
        public static int tilda => 0x7e;
        public static int delete => 0x7f;
        public static int ideographic_space => 0x3000;
        public static int postal_mark_face => 0x3020;
        public static int wavy_dash => 0x3030;
        public static int ideographic_half_fill_space => 0x303f;
        public static int greece_Alpha => 0x0391;
        public static int greece_Rho => 0x30a1;
        public static int greece_Sigma => 0x30a3;
        public static int greece_Omega => 0x03a9;
        public static int greece_alpha => 0x03b1;
        public static int greece_omega => 0x03c9;
        public static int cyrillic_A => 0x0410;
        public static int cyrillic_E => 0x0401;
        public static int cyrillic_e => 0x0451;
        public static int cyrillic_ya => 0x044f;
        public static int zenkaku_exc_mark => 0xff01;
        public static int zenkaku_slash_mark => 0xff0f;
        public static int zenkaku_number_zero => 0xff10;
        public static int zenkaku_number_nine => 0xff1a;
        public static int zenkaku_A => 0xff21;
        public static int zenkaku_a => 0xff41;
        public static string[] endmark => new string[] { ")", "]", "!", ",", ".", "\u3001", "\u3002" };
    }
}