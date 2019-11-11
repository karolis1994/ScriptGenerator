using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    /// <summary>
    /// Service to increase version of all .NET projects inside a root directory
    /// </summary>
    public interface IVersioningService
    {
        /// <summary>
        /// Changes version of all AssemblyInfo files inside the specified root path
        /// </summary>
        /// <param name="rootPath">Root directory path from which the start for AssemblyInfo files begins</param>
        /// <param name="increaseMinor">Should minor version be increased</param>
        /// <param name="increaseMajor">Should major version be increased</param>
        /// <returns></returns>
        Task<string> ChangeVersions(string rootPath, bool increaseMinor, bool increaseMajor);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="rootPath">Root directory path from which the start for AssemblyInfo files begins</param>
        /// <param name="customVersion">Custom version for AssemblyInfo files, format: (#.#.#.#)</param>
        /// <returns></returns>
        Task<string> ChangeVersions(string rootPath, string customVersion);
    }
}
