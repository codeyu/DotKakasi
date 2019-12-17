namespace DotKakasi.Scripts
{
    public class K2
    {
           _kanadict = None



    _diff = 0x30a1 - 0x3041  // KATAKANA LETTER A - HIRAGANA A
       
    public  K2(string mode, string method="Hepburn")
           {
               if mode == "a":

            if method == "Hepburn":

                self._kanadict = Jisyo(Configurations.jisyo_hepburn)

            elif method == "Passport":

                self._kanadict = Jisyo(Configurations.jisyo_passport)

            elif method == "Kunrei":

                self._kanadict = Jisyo(Configurations.jisyo_kunrei)

            else:

                raise UnsupportedRomanRulesException("Unsupported roman rule")  # pragma: no cover



            self.convert = self.convert_a

        else if (mode == "H")
        {
            
        }

            self.convert = self.convert_h

        else:

            self.convert = self.convert_noop
           }

    public (char, int) Convert(string text)
    {


        if mode == "a":

            if method == "Hepburn":

                self._kanadict = Jisyo(Configurations.jisyo_hepburn)

            elif method == "Passport":

                self._kanadict = Jisyo(Configurations.jisyo_passport)

            elif method == "Kunrei":

                self._kanadict = Jisyo(Configurations.jisyo_kunrei)

            else:

                raise UnsupportedRomanRulesException("Unsupported roman rule")  # pragma: no cover



            self.convert = self.convert_a

        elif mode == "H":

            self.convert = self.convert_h

        else:

            self.convert = self.convert_noop

    }

    private bool isRegion(char ch)
            {

        return 0x30a0 < (int)ch && ch < 0x30fd;
            }



    private (char, int) convert_a(string text)
        {

        var Hstr = ' ';

        var max_len = -1;

        var r = Math.Min(_kanadict.Count, text.Length);

        for x in xrange(1, r + 1):

            if self._kanadict.haskey(text[:x]):

                if max_len < x:

                    max_len = x

                    Hstr = self._kanadict.lookup(text[:x])

        return (Hstr, max_len);

        }

    private (char ,int ) convert_h(string text)
                    {

        var Hstr = ' ';

        var max_len = 0

        var r = text.Length;

        for(var x = 0; x<r;x++)
        {

            if (isRegion(text[x]) && (int)(text[x]) < 0x30f7)
            {

                Hstr = Hstr + (char)((int)(text[x] - _diff));

                max_len += 1;
            }

            else if (isRegion(text[x]))
            {
                Hstr = Hstr + text[x];

                max_len += 1;
            }

            else  // pragma: no cover
            {
                break;
            }
        }
        return (Hstr, max_len);
                    }



    private (char int) convert_noop(string text)
            {

        return (text[0], 1);
            }
    }
}
