using System;
using System.Collections.Generic;
namespace DotKakasi.Common
{
    public static class ConvertTables
    {
        /*
        convert symbols to alphabet
        based on Original KAKASI"s EUC_JP - alphabet converter table
        --------------------------------------------------------------------------
        a1 a0 | 　 、 。 ， ． ・ ： ； ？ ！ ゛ ゜ ´ ｀ ¨
                " ",",",".",",",".",".",",",";","?",
                "!","\"","(maru)",""","`","..",
        a1 b0 | ＾ ￣ ＿ ヽ ヾ ゝ ゞ 〃 仝 々 〆 〇 ー ― ‐ ／
            "~","~","_","(kurikaesi)","(kurikaesi)","(kurikaesi)",
            "(kurikaesi)","(kurikaesi)","(kurikaesi)","(kurikaesi)",
            "sime","(maru)","^","-","-","/",
        a1 c0 | ＼ ～ ∥ ｜ … ‥ ‘ ’ “ ” （ ） 〔 〕 ［ ］
            "\\","~","||","|","...","..","`",""","\"","\"","(",")","[","]","[","]",
            "{","}","<",">","<<",">>","(",")","(",")","(",")","+","-","+-","X",
        a1 d0 | ｛ ｝ 〈 〉 《 》 「 」 『 』 【 】 ＋ － ± ×
        a1 e0 | ÷ ＝ ≠ ＜ ＞ ≦ ≧ ∞ ∴ ♂ ♀ ° ′ ″ ℃ ￥
            "/","=","!=","<",">","<=",">=","(kigou)","...",
            "(osu)","(mesu)","(do)",""","\"","(Sessi)","\\",
        a1 f0 | ＄ ￠ ￡ ％ ＃ ＆ ＊ ＠ § ☆ ★ ○ ● ◎ ◇
            "$","(cent)","(pound)","%","#","&","*","@",
            "(setu)","(hosi)","(hosi)","(maru)","(maru)","(maru)","(diamond)"
        ---------------------------------------------------------------------------
        ----------------------------------------------------------
        a2 a0 | ◆ □ ■ △ ▲ ▽ ▼ ※ 〒 → ← ↑ ↓ 〓
        a2 b0 | ∈ ∋ ⊆ ⊇ ⊂ ⊃ a2 c0 | ∪ ∩ ∧ ∨ ￢ ⇒ ⇔ ∀
        a2 d0 | ∃ ∠ ⊥ ⌒ ∂
        a2 e0 | ∇ ≡ ≒ ≪ ≫ √ ∽ ∝ ∵ ∫ ∬
        a2 f0 | Å ‰ ♯ ♭ ♪ † ‡ ¶ ◯
        ----------------------------------------------------------
        Greek convertion table
        ----------------------------------------------------------
        "Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta",
        "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho",
        "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega",
        "", "", "", "", "", "", "", "",
        "alpha", "beta", "gamma", "delta", "epsilon", "zeta", "eta", "theta",
        "iota", "kappa", "lambda", "mu", "nu", "xi", "omicron", "pi", "rho",
        "sigma", "tau", "upsilon", "phi", "chi", "psi", "omega"
        ----------------------------------------------------------
        
        */
        // U3000 - 301F
    // \u3000、。〃〄〇〆々〈〉《》「」『』【】〒〓〔〕〖〗〘〙
    // 〚〛〜〝〞〟〠
    public static string[] symbol_table_1 => new string[]{" ", ",", ".", "\"", "(kigou)", "(kurikaesi)", "(sime)", "(maru)", "<", ">",
                      "<<", ">>", "(", ")", "(", ")", "(", ")", "(kigou)", "(geta)",
                      "(", ")", "(", ")", "(", ")", "(", ")", "~", "(kigou)", "\\\"",
                      "(kigou)", "(kigou)"};
    // U3030 - 3040
    // 〰〱〲〳〴〵〶〷〼〽〾〿
    public static string[] symbol_table_2 => new string[]{"-", "(kurikaesi)",
                      "(kurikaesi)", "(kurikaesi)", "(kurikaesi)", "(kurikaesi)",
                      "(kigou)", "XX", null, null, null, null, "(masu)", "(kurikaesi)", " ", " "};
    // U0391-03A9
    public static string[] symbol_table_3 => new string[]{"Alpha", "Beta", "Gamma", "Delta", "Epsilon", "Zeta", "Eta", "Theta",
                      "Iota", "Kappa", "Lambda", "Mu", "Nu", "Xi", "Omicron", "Pi", "Rho", null,
                      "Sigma", "Tau", "Upsilon", "Phi", "Chi", "Psi", "Omega"};
    // U03B1-03C9
    public static string[] symbol_table_4 => new string[]{"alpha", "beta", "gamma", "delta", "epsilon", "zeta", "eta", "theta",
                      "iota", "kappa", "lambda", "mu", "nu", "xi", "omicron", "pi", "rho", "final sigma",
                      "sigma", "tau", "upsilon", "phi", "chi", "psi", "omega"};
    // UFF01-FF0F
    public static string[] symbol_table_5 => new string[]{"!", "\"", "//", "$", "%", "&", "'", "(", ")", "*", "+",
                      ",", "-", ".", "/"};
    // cyriilic
    public static Dictionary<string,string> cyrillic_table => new Dictionary<string, string>{  // basic cyrillic characters
        {"\u0410", "A"}, {"\u0411", "B"}, {"\u0412", "V"},  // АБВ
        {"\u0413", "G"}, {"\u0414", "D"}, {"\u0415", "E"},  // ГДЕ
        {"\u0401", "E"}, {"\u0416", "Zh"}, {"\u0417", "Z"},  // ЁЖЗ
        {"\u0418", "I"}, {"\u0419", "Y"}, {"\u041a", "K"},  // ИЙК
        {"\u041b", "L"}, {"\u041c", "M"}, {"\u041d", "N"},  // ЛМН
        {"\u041e", "O"}, {"\u041f", "P"}, {"\u0420", "R"},  // ОПР
        {"\u0421", "S"}, {"\u0422", "T"}, {"\u0423", "U"},  // СТУ
        {"\u0424", "F"}, {"\u0425", "H"}, {"\u0426", "Ts"},  // ФХЦ
        {"\u0427", "Ch"}, {"\u0428", "Sh"}, {"\u0429", "Sch"},  // ЧШЩ
        {"\u042a", ""}, {"\u042b", "Y"}, {"\u042c", ""},  // ЪЫЬ
        {"\u042d", "E"}, {"\u042e", "Yu"}, {"\u042f", "Ya"},  // ЭЮЯ
        {"\u0430", "a"}, {"\u0431", "b"}, {"\u0432", "v"},  // абв
        {"\u0433", "g"}, {"\u0434", "d"}, {"\u0435", "e"},  // где
        {"\u0451", "e"}, {"\u0436", "zh"}, {"\u0437", "z"},  // ёжз
        {"\u0438", "i"}, {"\u0439", "y"}, {"\u043a", "k"},  // ийк
        {"\u043b", "l"}, {"\u043c", "m"}, {"\u043d", "n"},  // лмн
        {"\u043e", "o"}, {"\u043f", "p"}, {"\u0440", "r"},  // опр
        {"\u0441", "s"}, {"\u0442", "t"}, {"\u0443", "u"},  // сту
        {"\u0444", "f"}, {"\u0445", "h"}, {"\u0446", "ts"},  // фхц
        {"\u0447", "ch"}, {"\u0448", "sh"}, {"\u0449", "sch"},  // чшщ
        {"\u044a", ""}, {"\u044b", "y"}, {"\u044c", ""},  // ъыь
        {"\u044d", "e"}, {"\u044e", "yu"}, {"\u044f", "ya"}  // эюя
    };

    public static char[] alpha_table_1 => new char[]{'\u3000', '\uff01', '\uff02', '\uff03', '\uff04', '\uff05', '\uff06',
                     '\uff07', '\uff08', '\uff09', '\uff0a', '\uff0b', '\uff0c', '\uff0d',
                     '\uff0e', '\uff0f',  // ！＂＃＄％＆＇（）＊＋，－．／
                     '\uff10', '\uff11', '\uff12', '\uff13', '\uff14', '\uff15', '\uff16',
                     '\uff17', '\uff18', '\uff19',  // ０...９
                     '\uff1a', '\uff1b', '\uff1c', '\uff1d',
                     '\uff1e', '\uff1f', '\uff20'};  // ：；＜＝＞？＠
    public static char[] alpha_table_2 => new char[]{'\uff3b', '\uff3c', '\uff3d', '\uff3e', '\uff3f', '\uff40' };  // ［＼］＾＿｀
    public static char[] alpha_table_3 => new char[]{ '\uff5b', '\uff5c', '\uff5d', '\uff5e' }; // ｛｜｝～
    }
}