using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace DotKakasi.Kanji
{
    public class Itaiji
    {
        private static readonly Lazy<Itaiji> lazy = new Lazy<Itaiji>(() => new Itaiji());
        public static Itaiji Instance { get { return lazy.Value; } }

        private readonly Dictionary<char, char> _itaijidict;
        private Itaiji()
        {
            var fileName = $"DotKakasi._gz.itaijidict.json.gz";
            var assembly = typeof(Itaiji).GetTypeInfo().Assembly;
            using (var resource = assembly.GetManifestResourceStream(fileName))
            using (GZipStream decompressionStream = new GZipStream(resource, CompressionMode.Decompress))
            {
                using (StreamReader textReader = new StreamReader(decompressionStream))
                {
                    var json = textReader.ReadToEnd();
                    _itaijidict = JsonConvert.DeserializeObject<Dictionary<char, char>>(json);
                }
            }
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