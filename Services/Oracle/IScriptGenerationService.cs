using ScriptGenerator.Models;
using System.Threading.Tasks;

namespace ScriptGenerator.Services
{
    /// <summary>
    /// Script generation service
    /// </summary>
    public interface IScriptGenerationService
    {
        /// <summary>
        /// Generates table creation script
        /// </summary>
        /// <param name="table"></param>
        /// <returns></returns>
        Task<string> GenerateCreationScript(Table table);

        /// <summary>
        /// Generates column creation script
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        Task<string> GenerateCreationScript(Column column);

        /// <summary>
        /// Generates sequence creation script
        /// </summary>
        /// <param name="sequence"></param>
        /// <returns></returns>
        Task<string> GenerateCreationScript(Sequence sequence);

        /// <summary>
        /// Generates audit trigger creation script
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        Task<string> GenerateCreationScript(Trigger trigger);
    }
}
