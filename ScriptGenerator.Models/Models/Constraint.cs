namespace ScriptGenerator.Models
{
    /// <summary>
    /// Generic constraint model
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// Schema name
        /// </summary>
        public string Schema { get; protected set; }

        /// <summary>
        /// Constraint name
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; protected set; }

        /// <summary>
        /// Table column name
        /// </summary>
        public string TableColumnName { get; protected set; }

        /// <summary>
        /// Tablespace used for this index
        /// </summary>
        public string TableSpace { get; protected set; }

        /// <summary>
        /// Creates new constraint
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumnName"></param>
        /// <returns></returns>
        public static Constraint CreateNew(string schema, string name, string tableName, string tableColumnName, string tableSpace)
        {
            return new Constraint()
            {
                Schema = schema,
                Name = name,
                TableName = tableName,
                TableColumnName = tableColumnName,
                TableSpace = tableSpace
            };
        }
    }
}
