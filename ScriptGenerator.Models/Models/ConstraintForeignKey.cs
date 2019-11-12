namespace ScriptGenerator.Models
{
    /// <summary>
    /// Foreign key constraint
    /// </summary>
    public class ConstraintForeignKey : Constraint
    {
        /// <summary>
        /// Referenced table schema name
        /// </summary>
        public string ReferencedTableSchemaName { get; private set; }

        /// <summary>
        /// Referenced table name
        /// </summary>
        public string ReferencedTableName { get; private set; }

        /// <summary>
        /// Referenced table column name
        /// </summary>
        public string ReferencedTableColumnName { get; private set; }

        /// <summary>
        /// Index for the foreign key
        /// </summary>
        public Constraint Index { get; private set; }

        /// <summary>
        /// Creates new foreign key constraint
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <param name="tableColumnName"></param>
        /// <param name="referencedTableSchemaName"></param>
        /// <param name="referencedTableName"></param>
        /// <param name="referencedTableColumnName"></param>
        /// <param name="index"></param>
        /// <returns></returns>
        public static ConstraintForeignKey CreateNew(string schema, string name, string tableName, string tableColumnName, string referencedTableSchemaName, 
            string referencedTableName, string referencedTableColumnName, Constraint index)
        {
            return new ConstraintForeignKey()
            {
                Schema = schema,
                Name = name,
                TableName = tableName,
                TableColumnName = tableColumnName,
                ReferencedTableSchemaName = referencedTableSchemaName,
                ReferencedTableName = referencedTableName,
                ReferencedTableColumnName = referencedTableColumnName,
                Index = index
            };
        }
    }
}
