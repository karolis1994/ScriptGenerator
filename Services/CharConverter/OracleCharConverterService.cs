using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    /// <summary>
    /// Char converter for oracle
    /// </summary>
    public class OracleCharConverterService : ICharConverterService
    {
        /// <summary>
        /// Currently set charset
        /// </summary>
        private Dictionary<int, string> charset = new Dictionary<int, string>();

        public OracleCharConverterService() { }

        public async Task<Dictionary<int, string>> LoadCharset(string charsetFilePath)
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
                else
                {
                    throw new ArgumentException("Incorrect charset file path supplied.");
                }

                charset = newCharset;
            })
            .ConfigureAwait(false);

            return charset;
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
