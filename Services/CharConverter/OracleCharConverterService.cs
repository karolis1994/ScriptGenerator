using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    public class OracleCharConverterService : ICharConverterService
    {
        private Dictionary<int, string> charset = new Dictionary<int, string>();

        public async Task LoadCharset(string charsetFilePath)
        {
            await new Task(() =>
            {
                Dictionary<Int32, String> newCharset = new Dictionary<Int32, String>();
                Int32 key = 0;

                if (File.Exists(charsetFilePath))
                {
                    IEnumerable<String> lines = File.ReadLines(charsetFilePath);
                    foreach (String line in lines)
                    {
                        String[] splitResult = line.Split(' ');

                        if (splitResult.Length == 2)
                            if (Int32.TryParse(splitResult[0], out key))
                                newCharset.Add(key, splitResult[1]);
                    }
                }

                charset = newCharset;
            });
        }

        public async Task<string> ReplaceWithCharset(string original, bool convertApostrophe = false)
        {
            return await new Task<string>(() =>
            {
                StringBuilder stringBuilder = new StringBuilder(original);

                foreach (KeyValuePair<Int32, String> pair in charset)
                    stringBuilder.Replace(pair.Value, $"' || chr({pair.Key}) || '");

                if (convertApostrophe)
                    stringBuilder.Replace("'", "' || chr(39) || '");

                return stringBuilder.ToString();
            });
        }
    }
}
