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
        public string ReferencedTableSchemaName { get; set; }

        /// <summary>
        /// Referenced table name
        /// </summary>
        public string ReferencedTableName { get; set; }

        /// <summary>
        /// Referenced table column name
        /// </summary>
        public string ReferencedTableColumnName { get; set; }

        /// <summary>
        /// Index for the foreign key
        /// </summary>
        public Constraint Index { get; set; }
    }
}
