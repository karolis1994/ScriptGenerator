namespace ScriptGenerator.Models.Oracle
{
    /// <summary>
    /// Column model
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Column name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Column data type
        /// </summary>
        public DataType DataType { get; private set; }

        /// <summary>
        /// Column data length
        /// </summary>
        public int? DataLength { get; private set; }

        /// <summary>
        /// Default value
        /// </summary>
        public string DefaultValue { get; private set; }

        /// <summary>
        /// Is column nullable
        /// </summary>
        public bool IsNullable { get; private set; }

        /// <summary>
        /// Comment on the column
        /// </summary>
        public string Comment { get; private set; }

        /// <summary>
        /// Does column have a primary key constraint
        /// </summary>
        public bool HasPrimaryKeyConstraint { get; private set; }

        /// <summary>
        /// Primary key constraint name
        /// </summary>
        public string PrimaryKeyConstraintName { get; private set; }

        /// <summary>
        /// Does column have a unique constraint
        /// </summary>
        public bool HasUniqueConstraint { get; private set; }

        /// <summary>
        /// Unique constraint name
        /// </summary>
        public string UniqueConstraintName { get; private set; }

        /// <summary>
        /// Does column have a foreign key constraint
        /// </summary>
        public bool HasForeignKeyConstraint { get; private set; }

        /// <summary>
        /// Foreign key constraint name
        /// </summary>
        public string ForeignKeyConstraintName { get; private set; }

        /// <summary>
        /// Foreign key constraint schema name
        /// </summary>
        public string ForeignKeyConstraintSchema { get; private set; }

        /// <summary>
        /// Foreign key constraint referenced table
        /// </summary>
        public string ForeignKeyConstraintTable { get; private set; }

        /// <summary>
        /// Foreign key constraint referenced column
        /// </summary>
        public string ForeignKeyConstraintColumn { get; private set; }

        /// <summary>
        /// Index for fk constraint name
        /// </summary>
        public string IndexForFKConstraintName { get; private set; }
    }
}
