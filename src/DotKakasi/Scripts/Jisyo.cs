using System;
using System.Collections.Generic;


namespace DotKakasi.Scripts
{
    public class Jisyo
    {
        private readonly Dictionary<string, string> _dict = new Dictionary<string, string>();

        public Jisyo(string dictName)
        {
            _dict = JisyoFactory.Load(dictName);
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
