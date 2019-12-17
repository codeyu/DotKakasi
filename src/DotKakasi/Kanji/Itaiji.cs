using System;
using System.Collections.Generic;
using DotKakasi.Common;
using DotKakasi.Scripts;
namespace DotKakasi.Kanji
{
    public class Itaiji
    {
        private static readonly Lazy<Itaiji> lazy = new Lazy<Itaiji>(() => new Itaiji());
        public static Itaiji Instance { get { return lazy.Value; } }

        private readonly Dictionary<char, char> _itaijidict;
        private Itaiji()
        {
            _itaijidict = JisyoFactory.Load(Configurations.jisyo_itaiji);
        }

        public bool HasKey(char key)
        {
            return _itaijidict.ContainsKey(key);
        }
        public char Lookup(char key)
        {
            return _itaijidict[key];
        }
        public string Convert(string txt)
        {
            var lst = new List<char>();
            foreach(var c in txt)
            {
                if(HasKey(c))
                {
                    lst.Add(c);
                }
            }
            foreach(var c in lst)
            {
                txt = txt.Replace(c, Lookup(c));
            }
            return txt;
        }
    }
}
