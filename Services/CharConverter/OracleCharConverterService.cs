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
            await Task.Run(() =>
            {
                Dictionary<int, string> newCharset = new Dictionary<int, string>();
                int key = 0;

                if (File.Exists(charsetFilePath))
                {
                    IEnumerable<string> lines = File.ReadLines(charsetFilePath);
                    foreach (string line in lines)
                    {
                        string[] splitResult = line.Split(' ');

                        if (splitResult.Length == 2)
                            if (int.TryParse(splitResult[0], out key))
                                newCharset.Add(key, splitResult[1]);
                    }
                }

                charset = newCharset;
            })
            .ConfigureAwait(false);
        }

        public async Task<string> ReplaceWithCharset(string original, bool convertApostrophe = false)
        {
            return await Task.Run(() =>
            {
                StringBuilder stringBuilder = new StringBuilder(original);

                foreach (KeyValuePair<int, string> pair in charset)
                    stringBuilder.Replace(pair.Value, $"' || chr({pair.Key}) || '");

                if (convertApostrophe)
                    stringBuilder.Replace("'", "' || chr(39) || '");

                return stringBuilder.ToString();
            })
            .ConfigureAwait(false);
        }
    }
}
