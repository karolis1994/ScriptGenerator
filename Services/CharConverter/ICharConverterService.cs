using System.Collections.Generic;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    /// <summary>
    /// Char converter service
    /// </summary>
    public interface ICharConverterService
    {
        /// <summary>
        /// Loads charset file values
        /// </summary>
        /// <param name="charsetFilePath"></param>
        /// <returns></returns>
        Task<Dictionary<int, string>> LoadCharset(string charsetFilePath);

        /// <summary>
        /// Replaces characters inside the supplied string with encoded values of supplied charset
        /// </summary>
        /// <param name="original"></param>
        /// <param name="charset"></param>
        /// <param name="convertApostrophe"></param>
        /// <returns></returns>
        Task<string> ReplaceWithCharset(string original, bool convertApostrophe = false);
    }
}
