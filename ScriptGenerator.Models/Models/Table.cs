using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptGenerator.Models
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
        public HashSet<Column> Columns { get; private set; }

        /// <summary>
        /// Validates a collection of columns
        /// </summary>
        /// <param name="columns"></param>
        public static void ValidateColumns(HashSet<Column> columns)
        {
            if (columns.Count != columns.Select(e => e.Name).Distinct().Count())
                throw new Exception("");
        }

        /// <summary>
        /// Creates a new table
        /// </summary>
        /// <param name="name"></param>
        /// <param name="scehmaName"></param>
        /// <param name="tableComment"></param>
        /// <param name="tableSpace"></param>
        /// <param name="columns"></param>
        /// <returns></returns>
        public static Table CreateNew(string name, string scehmaName, string tableComment, string tableSpace, HashSet<Column> columns)
        {
            ValidateColumns(columns);

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
