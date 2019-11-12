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

        /// <summary>
        /// Creates a new column
        /// </summary>
        /// <param name="tableSchema"></param>
        /// <param name="tableName"></param>
        /// <param name="name"></param>
        /// <param name="dataType"></param>
        /// <param name="dataLength"></param>
        /// <param name="defaultValue"></param>
        /// <param name="isNullable"></param>
        /// <param name="comment"></param>
        /// <param name="hasPrimaryKeyConstraint"></param>
        /// <param name="primaryKey"></param>
        /// <param name="hasUniqueConstraint"></param>
        /// <param name="uniqueConstraint"></param>
        /// <param name="hasForeignKeyConstraint"></param>
        /// <param name="foreignKey"></param>
        /// <returns></returns>
        public static Column CreateNew(string tableSchema, string tableName, string name, DataType dataType, int? dataLength, string defaultValue,
            bool isNullable, string comment, bool hasPrimaryKeyConstraint, Constraint primaryKey, bool hasUniqueConstraint, Constraint uniqueConstraint,
            bool hasForeignKeyConstraint, ConstraintForeignKey foreignKey)
        {
            return new Column()
            {
                TableSchema = tableSchema,
                TableName = tableName,
                Name = name,
                DataType = dataType,
                DataLength = dataLength,
                DefaultValue = defaultValue,
                IsNullable = isNullable,
                Comment = comment,
                HasPrimaryKeyConstraint = hasPrimaryKeyConstraint,
                PrimaryKey = primaryKey,
                HasUniqueConstraint = hasUniqueConstraint,
                UniqueConstraint = uniqueConstraint,
                HasForeignKeyConstraint = hasForeignKeyConstraint,
                ForeignKey = foreignKey
            };
        }
    }
}
