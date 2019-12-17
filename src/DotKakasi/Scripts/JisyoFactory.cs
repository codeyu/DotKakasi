
using Newtonsoft.Json;

using System;

using System.Collections.Generic;

using System.IO;

using System.IO.Compression;

using System.Reflection;

using System.Collections.Concurrent;


namespace DotKakasi.Scripts

{

    public class JisyoFactory

    {
        private static readonly ConcurrentDictionary<string, Dictionary<string, string>> cd = new ConcurrentDictionary<string, Dictionary<string, string>>();
        public static Dictionary<string, string> Load(string dictName)
        {

            Dictionary<string, string> result;

            if(cd.TryGetValue(dictName, out result))

            {

                return result;

            }

            result = Create(dictName);

            cd.Add(dictName, result);

            return result;

        }
        private Dictionary<string, string> Create(string dictName)

        {

            var fileName = $"DotKakasi._gz.{dictName}";

            var assembly = typeof(JisyoFactory).GetTypeInfo().Assembly;

            using (var resource = assembly.GetManifestResourceStream(fileName))

            using (GZipStream decompressionStream = new GZipStream(resource, CompressionMode.Decompress))

            {

                using (StreamReader textReader = new StreamReader(decompressionStream))

                {

                    var json = textReader.ReadToEnd();

                    return JsonConvert.DeserializeObject<Dictionary<string, string>>(json);

                }

            }

        }

    }

}
