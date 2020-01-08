using ScriptGenerator.Models;
using Services.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Ais
{
    public class CodeComponentsGeneratorService : ICodeComponentsGeneratorService
    {
        private const string identation = "    ";
        private const string summaryOpening = "/// <summary>";
        private const string summaryClosing = "/// </summary>";
        private const string userEntity = "UserEntity";
        private const string entity = "Entity";
        private const string aggregateRoot = "IAggregateRoot";
        private const string validDateTimeRange = "IValidDateTimeRange";
        private const string apiModelUsings = @"using Core.Domain.Models;
using Core.Web.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;";
        private const string domainModelUsings = @"using Ais;
using Core.Domain;
using Core.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;";
        private const string commandUsings = @"using Core.Web.Application.Commands;
using MediatR;";
        private const string commandHandlerUsings = @"using Ais;
using Core.Web.Application.Commands;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;";
        private const string entityConfigurationUsings = @"using Funds.Domain.Models.Funds;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;";
        private const string repositoryInterfaceUsings = @"using Core.Domain.SeedWork;
using System.Collections.Generic;
using System.Threading.Tasks;";
        private const string repositoryUsings = @"using Core.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;";

        public async Task<CodeComponentFile> GenerateAPIModel(CodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            return await Task.Run(() =>
            {
                var sb = new StringBuilder(apiModelUsings);

                sb.AppendLine($"namespace {GetAPIModelNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{GenerateSummary(model.Summary, 1)}");
                sb.AppendLine($"{identation}{GenerateModelClassDefinition(model)}");
                sb.AppendLine($"{identation}{{");

                foreach (var variable in model.Variables.Where(v => !v.IsFieldMultilanguage))
                {
                    sb.AppendLine(GenerateVariableDefinition(variable, false, 2));
                    sb.AppendLine();
                }

                foreach (var variable in model.Variables.Where(v => v.IsFieldMultilanguage))
                {
                    sb.AppendLine(GenerateMultilanguageVariableDefinition(variable, model.Name, false, 2));
                    sb.AppendLine();
                }

                sb.AppendLine(GenerateCreateNew(model, 2));
                sb.AppendLine();
                sb.AppendLine(GenerateUpdateWith(model, 2));
                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), model.Name);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateDomainModel(CodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            return await Task.Run(() =>
            {
                var sb = new StringBuilder(domainModelUsings);

                sb.AppendLine($"namespace {GetDomainModelNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{GenerateSummary(model.Summary, 1)}");
                sb.AppendLine($"{identation}{GenerateModelClassDefinition(model)}");
                sb.AppendLine($"{identation}{{");

                foreach (var variable in model.Variables.Where(v => !v.IsFieldMultilanguage))
                {
                    sb.AppendLine(GenerateVariableDefinition(variable, true, 2));
                    sb.AppendLine();
                }

                foreach (var variable in model.Variables.Where(v => v.IsFieldMultilanguage))
                {
                    sb.AppendLine(GenerateMultilanguageVariableDefinition(variable, model.Name, true, 2));
                    sb.AppendLine();
                }

                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), model.Name);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateCommand(CodeModel model, CommandType type)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            return await Task.Run(() =>
            {
                var identation2 = GenerateIdentation(2);
                var identation3 = GenerateIdentation(3);

                var className = GetCommandName(type, model.Name, false);
                var sb = new StringBuilder(commandUsings);
                sb.AppendLine($"using {GetAPIModelNamespace(model.Namespace, model.SubNamespace)};");

                sb.AppendLine();
                sb.AppendLine($"namespace {GetCommandsNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{GenerateSummary($"Command to {type.ToString().FirstCharToLower()} {model.Name}", 1)}");
                sb.AppendLine($"{identation}public class {className} : IRequest<CommandResponse>");
                sb.AppendLine($"{identation}{{");

                if (type == CommandType.Delete)
                {
                    sb.AppendLine($"{identation2}public {className}(long id)");
                    sb.AppendLine($"{identation2}{{");
                    sb.AppendLine($"{identation3}{model.Name} = {model.Name.FirstCharToLower()};");
                    sb.AppendLine($"{identation2}}}");
                    sb.AppendLine();
                    sb.AppendLine(GenerateSummary($"{model.Name} identificator", 2));
                    sb.AppendLine($"{identation2}public long Id {{ get; }}");
                }
                else
                {
                    sb.AppendLine($"{identation2}public {className}({model.Name} {model.Name.FirstCharToLower()})");
                    sb.AppendLine($"{identation2}{{");
                    sb.AppendLine($"{identation3}{model.Name} = {model.Name.FirstCharToLower()};");
                    sb.AppendLine($"{identation2}}}");
                    sb.AppendLine();
                    sb.AppendLine(GenerateSummary($"{model.Name} model", 2));
                    sb.AppendLine($"{identation2}public {model.Name} {model.Name} {{ get; }}");
                }

                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), className);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateCommandHandler(CodeModel model, CommandType type)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            return await Task.Run(() =>
            {
                var identation2 = GenerateIdentation(2);
                var identation3 = GenerateIdentation(3);
                var commandName = GetCommandName(type, model.Name, false);
                var className = GetCommandName(type, model.Name, true);
                var repositoryInterface = GetRepositoryName(model.Name, true);
                var repository = GetRepositoryName(model.Name, false).FirstCharToLower();
                var sb = new StringBuilder(commandHandlerUsings);
                sb.AppendLine($"usinng {GetDomainModelNamespace(model.Namespace, model.SubNamespace)};");

                sb.AppendLine();
                sb.AppendLine($"namespace {GetCommandsNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{GenerateSummary($"Command to {type.ToString().FirstCharToLower()} {model.Name}", 1)}");
                sb.AppendLine($"{identation}public class {className} : IRequestHandler<{commandName}, CommandResponse>");
                sb.AppendLine($"{identation}{{");
                sb.AppendLine($"{identation2}private readonly {repositoryInterface} {repository};");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public {className}({repositoryInterface} {repository})");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}this.{repository} = {repository};");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public async Task<CommandResponse> Handle({commandName} command, CancellationToken cancellationToken)");
                sb.AppendLine($"{identation2}{{");
                if (type == CommandType.Delete)
                {
                    sb.AppendLine($"{identation3}//TODO: review validations");
                    sb.AppendLine($"{identation3}var entity = await {repository}.FindByIdAsync(command.Id);");
                    sb.AppendLine($"{identation3}if (entity == null)");
                    sb.AppendLine($"{identation3}{identation}return new CommandResponse(AppError.NotFound);");
                    sb.AppendLine();
                    sb.AppendLine($"{identation3}{repository}.Delete(entity);");
                    sb.AppendLine($"{identation3}await {repository}.UnitOfWork.SaveEntitiesAsync();");
                    sb.AppendLine();
                    sb.AppendLine($"{identation3}return new CommandResponse(AppError.SuccessItems);");
                }
                else
                {
                    sb.AppendLine($"{identation3}//TODO:");
                }
                sb.AppendLine($"{identation2}}}");

                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), className);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateEntityTypeConfiguration(CodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            return await Task.Run(() =>
            {
                var className = model.Name + "EntityTypeConfiguration";
                var identation2 = GenerateIdentation(2);
                var identation3 = GenerateIdentation(3);
                var sb = new StringBuilder(entityConfigurationUsings);

                sb.AppendLine();
                sb.AppendLine($"namespace {GetEntityConfigurationNamespace(model.Namespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{identation}internal class {className} : IEntityTypeConfiguration<{model.Name}>");
                sb.AppendLine($"{identation}{{");
                sb.AppendLine($"{identation2}public void Configure(EntityTypeBuilder<{model.Name}> c)");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}c.ToTable(\"{model.Name}\", FundsContext.DEFAULT_SCHEMA);");
                sb.AppendLine($"{identation3}c.Ignore(e => e.DomainEvents);");
                sb.AppendLine($"{identation3}c.HasKey(e => e.Id);");
                sb.AppendLine();

                foreach (var variable in model.Variables.Where(e => !e.IsFieldMultilanguage))
                {
                    sb.AppendLine($"{GenerateVariableConfigurationDefinition(variable, 3)}");
                }

                sb.AppendLine();
                sb.AppendLine($"{identation3}//TODO: manually add relations to child/parent entities.");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), className);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateRepositoryInterface(CodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            if (!model.IsAggregateRoot)
                throw new ArgumentException("Supplied model is not an aggregate root, therefore a repository cannot be created for it.");

            return await Task.Run(() =>
            {
                var className = GetRepositoryName(model.Name, true);
                var identation2 = GenerateIdentation(2);
                var sb = new StringBuilder(repositoryInterfaceUsings);

                sb.AppendLine();
                sb.AppendLine($"namespace {GetDomainModelNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine(GenerateSummary($"{model.Name} repository", 1));
                sb.AppendLine($"{identation}public interface {className} : IRepository<{model.Name}>");
                sb.AppendLine($"{identation}{{");
                sb.AppendLine(GenerateSummary($"Add a new {model.Name}", 2));
                sb.AppendLine($"{identation2}{model.Name} Add({model.Name} {model.Name.FirstCharToLower()});");
                sb.AppendLine();
                sb.AppendLine(GenerateSummary($"Updates an existing {model.Name}", 2));
                sb.AppendLine($"{identation2}{model.Name} Update({model.Name} {model.Name.FirstCharToLower()});");
                sb.AppendLine();
                sb.AppendLine(GenerateSummary($"Deletes an existing {model.Name}", 2));
                sb.AppendLine($"{identation2}void Delete({model.Name} {model.Name.FirstCharToLower()});");
                sb.AppendLine();
                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), className);
            })
            .ConfigureAwait(false);
        }

        public async Task<CodeComponentFile> GenerateRepository(CodeModel model)
        {
            if (model == null)
                throw new ArgumentNullException("Supplied code model was null.");

            if (!model.IsAggregateRoot)
                throw new ArgumentException("Supplied model is not an aggregate root, therefore a repository cannot be created for it.");

            return await Task.Run(() =>
            {
                var className = GetRepositoryName(model.Name, false);
                var identation2 = GenerateIdentation(2);
                var identation3 = GenerateIdentation(3);
                var identation4 = GenerateIdentation(4);
                var modelNameLower = model.Name.FirstCharToLower();
                var sb = new StringBuilder(repositoryUsings);
                sb.AppendLine($"using {GetDomainModelNamespace(model.Namespace, model.SubNamespace)};");

                sb.AppendLine();
                sb.AppendLine($"namespace {GetRepositoriesNamespace(model.Namespace, model.SubNamespace)}");
                sb.AppendLine("{");
                sb.AppendLine($"{identation}public class {className} : {GetRepositoryName(model.Name, true)}");
                sb.AppendLine($"{identation}{{");
                sb.AppendLine($"{identation2}private readonly {model.ContextName} context;");
                sb.AppendLine($"{identation2}public IUnitOfWork UnitOfWork => context;");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public {GetRepositoryName(model.Name, false)}({model.ContextName} context)");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}this.context = context;");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public {model.Name} Add({model.Name} {modelNameLower})");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}if ({modelNameLower}.IsTransient())");
                sb.AppendLine($"{identation3}{{");
                sb.AppendLine($"{identation4}return this.context.add({modelNameLower}).Entity;");
                sb.AppendLine($"{identation3}}}");
                sb.AppendLine($"{identation3}else");
                sb.AppendLine($"{identation3}{{");
                sb.AppendLine($"{identation4}return {modelNameLower};");
                sb.AppendLine($"{identation3}}}");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public {model.Name} Update({model.Name} {modelNameLower})");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}return return this.context.Update({modelNameLower}).Entity;");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine();
                sb.AppendLine($"{identation2}public void Delete({model.Name} {modelNameLower})");
                sb.AppendLine($"{identation2}{{");
                sb.AppendLine($"{identation3}this.context.Remove({modelNameLower});");
                sb.AppendLine($"{identation2}}}");
                sb.AppendLine($"{identation}}}");
                sb.AppendLine("}");

                return new CodeComponentFile(sb.ToString(), className);
            })
            .ConfigureAwait(false);
        }

        private string GenerateVariableConfigurationDefinition(CodeModelVariable variable, int identationCount)
        {
            var localIdentation = GenerateIdentation(identationCount);
            var sb = new StringBuilder();

            sb.Append($"{localIdentation}c.Property(e => e.{variable.Name})");

            if (variable.IsRequired)
                sb.Append(".IsRequired()");

            if (variable.LengthConstraint.HasValue && variable.LengthConstraint > 0 && variable.Type.ToLower() == "string")
                sb.Append($".HasMaxLength({variable.LengthConstraint})");

            sb.Append(";");

            return sb.ToString();
        }

        private string GenerateCreateNew(CodeModel model, int identationCount)
        {
            var localIdentation = GenerateIdentation(identationCount);
            var sb = new StringBuilder();

            sb.AppendLine($"{localIdentation}public static {model.Name} CreateNew({GenerateVariablesAsParameters(model.Variables, v => v.IsPartOfCreateNew)})");
            sb.AppendLine($"{localIdentation}{{");
            sb.AppendLine($"{localIdentation}//TODO:");
            sb.AppendLine($"{localIdentation}}}");

            return sb.ToString();
        }

        private string GenerateUpdateWith(CodeModel model, int identationCount)
        {
            var localIdentation = GenerateIdentation(identationCount);
            var sb = new StringBuilder();

            sb.AppendLine($"{localIdentation}public void UpdateWith({GenerateVariablesAsParameters(model.Variables, v => v.IsPartOfUpdate)})");
            sb.AppendLine($"{localIdentation}{{");
            sb.AppendLine($"{localIdentation}//TODO:");
            sb.AppendLine($"{localIdentation}}}");

            return sb.ToString();
        }

        private string GenerateVariablesAsParameters(IEnumerable<CodeModelVariable> variables, Func<CodeModelVariable, bool> condition)
        {
            if (variables.Where(v => condition(v)).Count() == 0)
                return string.Empty;

            var parameters = new List<string>();

            foreach (var variable in variables)
            {
                parameters.Add($"{variable.Type} {variable.Name.FirstCharToLower()}");
            }

            return string.Join(", ", parameters);
        }

        private string GenerateModelClassDefinition(CodeModel model)
        {
            if (model == null)
                return string.Empty;

            var sb = new StringBuilder("public class ");
            sb.Append(model.Name);

            var inherits = new List<string>();

            if (model.IsUserManaged)
                inherits.Add(userEntity);
            else
                inherits.Add(entity);

            if (model.IsAggregateRoot)
                inherits.Add(aggregateRoot);

            if (model.IsValidDateTimeRange)
                inherits.Add(validDateTimeRange);

            sb.Append($" : {string.Join(", ", inherits)}");

            return sb.ToString();
        }

        private string GenerateVariableDefinition(CodeModelVariable variable, bool isDomain, int identationCount)
        {
            var sb = new StringBuilder();

            var localIdentation = GenerateIdentation(identationCount);

            sb.AppendLine(GenerateSummary(variable.Comment, identationCount));
            if (!isDomain)
            {
                if (variable.LengthConstraint.HasValue)
                    sb.AppendLine($"{localIdentation}[StringLength({variable.LengthConstraint.Value})]");

                if (variable.IsRequired)
                    sb.AppendLine($"{localIdentation}[Required]");
            }
            sb.AppendLine($"{localIdentation}{variable.AccessLevel} {variable.Type} {variable.Name} {{ get; private set; }}");

            return sb.ToString();
        }

        private string GenerateMultilanguageVariableDefinition(CodeModelVariable variable, string modelName, bool isDomain, int identationCount)
        {
            var localIdentation = GenerateIdentation(identationCount);
            var localizedVariableName = $"{modelName}{variable.Name}";
            var sb = new StringBuilder();

            if (!isDomain)
            {
                sb.AppendLine(GenerateSummary($"Localized {variable.Name.FirstCharToLower()}", identationCount));
                sb.AppendLine($"{localIdentation}public IEnumerable<{localizedVariableName}> {variable.Name} {{ get; private set; }} = Enumerable.Empty<{localizedVariableName}>();");
            }
            else
            {
                var summary = GenerateSummary($"Set of {variable.Name.FirstCharToLower()} in all supported languages", identationCount);
                sb.AppendLine(summary);
                sb.AppendLine($"{localIdentation}private HashSet<{localizedVariableName}> _{variable.Name} = new HashSet<{localizedVariableName}>();");
                sb.AppendLine(summary);
                sb.AppendLine($"{localIdentation}public IEnumerable<{localizedVariableName}> {variable.Name} {{ get; private set; }} => _{variable.Name};");
            }

            return sb.ToString();
        }

        private string GenerateSummary(string summary, int identationCount = 0)
        {
            if (string.IsNullOrWhiteSpace(summary))
                return string.Empty;

            var localIdentation = GenerateIdentation(identationCount);

            var sb = new StringBuilder();

            sb.AppendLine($"{localIdentation}{summaryOpening}");
            sb.AppendLine($"{localIdentation}/// {summary}");
            sb.AppendLine($"{localIdentation}{summaryClosing}");

            return sb.ToString();
        }

        private string GenerateIdentation(int identationCount)
        {
            if (identationCount == 0)
                return string.Empty;

            var localIdentation = string.Empty;
            for (var i = 0; i < identationCount; i++)
                localIdentation += identation;

            return localIdentation;
        }

        private string GetRepositoryName(string modelName, bool isInterface) => $"{(isInterface ? "I" : string.Empty)}{modelName}Repository";

        private string GetCommandName(CommandType type, string modelName, bool isHandler) => $"{type.ToString()}{modelName}Command{(isHandler ? "Handler" : string.Empty)}";

        private string GetDomainModelNamespace(string @namespace, string subNamespace) => $"{@namespace}.Domain.Models{(string.IsNullOrWhiteSpace(subNamespace) ? string.Empty : "." + subNamespace)}";

        private string GetAPIModelNamespace(string @namespace, string subNamespace) => $"{@namespace}.API.Application.Models{(string.IsNullOrWhiteSpace(subNamespace) ? string.Empty : "." + subNamespace)}";

        private string GetCommandsNamespace(string @namespace, string subNamespace) => $"{@namespace}.API.Application.Commands{(string.IsNullOrWhiteSpace(subNamespace) ? string.Empty : "." + subNamespace)}";

        private string GetEntityConfigurationNamespace(string @namespace) => $"{@namespace}.Infrastructure.EntityConfigurations";

        private string GetRepositoriesNamespace(string @namespace, string subNamespace) => $"{@namespace}.Infrastructure.Repositories{(string.IsNullOrWhiteSpace(subNamespace) ? string.Empty : "." + subNamespace)}";
    }
}
