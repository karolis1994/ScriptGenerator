namespace ScriptGenerator.Models
{
    /// <summary>
    /// Ais model variable
    /// </summary>
    public class CodeModelVariable
    {
        /// <summary>
        /// Variable access level
        /// public by default
        /// </summary>
        public string AccessLevel { get; set; }

        /// <summary>
        /// Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Variable type in c#
        /// </summary>
        public string Type { get; set; }

        /// <summary>
        /// Summary comment
        /// </summary>
        public string Summary { get; set; }

        /// <summary>
        /// Size for length constraint
        /// </summary>
        public int? LengthConstraint { get; set; }

        /// <summary>
        /// Is field required in database and API level
        /// </summary>
        public bool IsRequired { get; set; }

        /// <summary>
        /// Custom column type
        /// </summary>
        public string ColumnType { get; set; }

        /// <summary>
        /// Is variable part of UpdateWith method
        /// </summary>
        public bool IsPartOfUpdate { get; set; }

        /// <summary>
        /// Is part of create new method
        /// </summary>
        public bool IsPartOfCreateNew { get; set; }

        /// <summary>
        /// Is variable multilanguage
        /// </summary>
        public bool IsFieldMultilanguage { get; set; }

        public static CodeModelVariable CreateNew(string accessLevel,string name, string type, string comment, 
            int? stringLength, bool isRequired, bool isPartOfUpdate, bool isPartOfCreateNew, bool isFieldMultilanguage)
        {
            return new CodeModelVariable()
            {
                AccessLevel = string.IsNullOrWhiteSpace(accessLevel) ? "public" : accessLevel,
                Name = name,
                Type = type,
                Summary = comment,
                LengthConstraint = stringLength,
                IsRequired = isRequired,
                IsPartOfUpdate = isPartOfUpdate,
                IsPartOfCreateNew = isPartOfCreateNew,
                IsFieldMultilanguage = isFieldMultilanguage
            };
        }
    }
}
