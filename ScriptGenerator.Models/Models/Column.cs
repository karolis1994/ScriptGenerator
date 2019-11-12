namespace ScriptGenerator.Models
{
    /// <summary>
    /// Column model
    /// </summary>
    public class Column
    {
        /// <summary>
        /// Table schema
        /// </summary>
        public string TableSchema { get; private set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; private set; }

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
        /// Primary key constraint
        /// </summary>
        public Constraint PrimaryKey { get; private set; }

        /// <summary>
        /// Does column have a unique constraint
        /// </summary>
        public bool HasUniqueConstraint { get; private set; }

        /// <summary>
        /// Unique index
        /// </summary>
        public Constraint UniqueConstraint { get; private set; }

        /// <summary>
        /// Does column have a foreign key constraint
        /// </summary>
        public bool HasForeignKeyConstraint { get; private set; }

        /// <summary>
        /// Foreign key
        /// </summary>
        public ConstraintForeignKey ForeignKey { get; private set; }
    }
}
