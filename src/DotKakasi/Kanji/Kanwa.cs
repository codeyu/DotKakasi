using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace DotKakasi.Kanji
{
    public class Kanwa
    {
        private static readonly Lazy<Kanwa> lazy = new Lazy<Kanwa>(() => new Kanwa());
        public static Kanwa Instance { get { return lazy.Value; } }

        private readonly Dictionary<string, Dictionary<string, List<List<string>>>> _jisyo_table;
        private Kanwa()
        {
            var fileName = $"DotKakasi._gz.kanwadict.json.gz";
            var assembly = typeof(Kanwa).GetTypeInfo().Assembly;
            using (var resource = assembly.GetManifestResourceStream(fileName))
            using (GZipStream decompressionStream = new GZipStream(resource, CompressionMode.Decompress))
            {
                using (StreamReader textReader = new StreamReader(decompressionStream))
                {
                    var json = textReader.ReadToEnd();
                    _jisyo_table = JsonConvert.DeserializeObject<Dictionary<string, Dictionary<string, List<List<string>>>>>(json);
                }
            }
        }

        public Dictionary<string, List<List<string>>> Load(char c)
        {
            var key = ((int)c).ToString("X").PadLeft(4, '0');
            return _jisyo_table[key];
        }
    }
}