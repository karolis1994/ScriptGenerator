using System.Collections.Generic;

namespace ScriptGenerator.Models.Oracle
{
    /// <summary>
    /// Table model
    /// </summary>
    public class Table
    {
        /// <summary>
        /// Table name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Schema name
        /// </summary>
        public string SchemaName { get; private set; }

        /// <summary>
        /// Table comment
        /// </summary>
        public string TableComment { get; private set; }

        /// <summary>
        /// Table space
        /// </summary>
        public string TableSpace { get; private set; }

        /// <summary>
        /// Columns
        /// </summary>
        public IEnumerable<Column> Columns { get; private set; }

        /// <summary>
        /// Creates a new table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scehmaName"></param>
        /// <param name="tableComment"></param>
        /// <param name="tableSpace"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static Table CreateNew(string name, string scehmaName, string tableComment, string tableSpace, IEnumerable<Column> columns)
        {
            return new Table()
            {
                Name = name,
                SchemaName = scehmaName,
                TableSpace = tableSpace,
                TableComment = tableComment,
                Columns = columns
            };
        }
    }
}
