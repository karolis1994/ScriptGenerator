using ScriptGenerator.Models;
using System.Threading.Tasks;

namespace Services.Ais
{
    /// <summary>
    /// Ais component generator service
    /// </summary>
    public interface ICodeComponentsGeneratorService
    {
        /// <summary>
        /// Generates a domain model class
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateDomainModel(CodeClass model);

        /// <summary>
        /// Generates entity type configuration class
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateEntityTypeConfiguration(CodeClass model);

        /// <summary>
        /// Generates an API model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateAPIModel(CodeClass model);

        /// <summary>
        /// Generates a multilanguage domain model class
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateDomainModelMultilanguage(CodeModelVariable variable, CodeClass model);

        /// <summary>
        /// Generates multilanguage entity type configuration class
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateEntityTypeConfigurationMultilanguage(CodeModelVariable variable, CodeClass model);

        /// <summary>
        /// Generates a multilanguage API model
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateAPIModelMultilanguage(CodeModelVariable variable, CodeClass model);

        /// <summary>
        /// Generates an interface for repository
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateRepositoryInterface(CodeClass model);

        /// <summary>
        /// Generates a repository class
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateRepository(CodeClass model);

        /// <summary>
        /// Generates a command class
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateCommand(CodeClass model, CommandType type);

        /// <summary>
        /// Generates a command handler class
        /// </summary>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        Task<CodeComponentFile> GenerateCommandHandler(CodeClass model, CommandType type);
    }
}
