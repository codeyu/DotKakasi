using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Reflection;

namespace DotKakasi.Scripts
{
    public class Jisyo
    {
        private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();

        public Jisyo(string dictName)
        {
            var fileName = $"DotKakasi._gz.{dictName}";
            var assembly = typeof(Jisyo).GetTypeInfo().Assembly;
            using (var resource = assembly.GetManifestResourceStream(fileName))
            using (GZipStream decompressionStream = new GZipStream(resource, CompressionMode.Decompress))
            {
                using (StreamReader textReader = new StreamReader(decompressionStream))
                {
                    var json = textReader.ReadToEnd();
                    _dict = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                }
            }
        }
        public bool haskey(string key)
        {
            return _dict.ContainsKey(key);
        }
        public string lookup(string key)
        {
            return _dict[key];
        }

        public int maxkeylen()
        {
            return _dict.Count;
        }
    }
}