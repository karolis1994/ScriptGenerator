using System.Collections.Generic;

namespace ScriptGenerator.Models
{
    /// <summary>
    /// Ais project model
    /// </summary>
    public class CodeModel
    {
        /// <summary>
        /// Model (class) name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Model (class) namespace
        /// </summary>
        public string Namespace { get; private set; }

        /// <summary>
        /// Model summary
        /// </summary>
        public string Summary { get; private set; }

        /// <summary>
        /// Is model an aggregate root
        /// </summary>
        public bool IsAggregateRoot { get; private set; }

        /// <summary>
        /// Is model managed by user
        /// </summary>
        public bool IsUserManaged { get; private set; }

        /// <summary>
        /// Does model have validity range
        /// </summary>
        public bool IsValidDateTimeRange { get; private set; }

        /// <summary>
        /// Variables collection
        /// </summary>
        public HashSet<CodeModelVariable> Variables { get; set; } = new HashSet<CodeModelVariable>();

        /// <summary>
        /// Name of context under which the domain model falls
        /// </summary>
        public string ContextName { get; private set; }

        /// <summary>
        /// Name of sub namespace
        /// </summary>
        public string SubNamespace { get; private set; }

        /// <summary>
        /// Creates ais model
        /// </summary>
        /// <param name="name"></param>
        /// <param name="isAggregateRoot"></param>
        /// <param name="variables"></param>
        /// <returns></returns>
        public static CodeModel CreateNew(string name, string nameSpace, string summary, bool isAggregateRoot, bool isUserManaged, 
            bool isValidDateTimeRange, IEnumerable<CodeModelVariable> variables, string contextName, string subNamespace)
        {
            var model = new CodeModel()
            {
                Name = name,
                Namespace = nameSpace,
                Summary = summary,
                IsAggregateRoot = isAggregateRoot,
                IsUserManaged = isUserManaged,
                IsValidDateTimeRange = isValidDateTimeRange,
                ContextName = contextName,
                SubNamespace = subNamespace
            };

            foreach(var variable in variables)
            {
                model.Variables.Add(variable);
            }

            return model;
        }
    }
}
