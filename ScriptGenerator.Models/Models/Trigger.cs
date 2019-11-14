namespace ScriptGenerator.Models
{
    /// <summary>
    /// Trigger
    /// </summary>
    public class Trigger
    {
        /// <summary>
        /// Schema name
        /// </summary>
        public string Schema { get; private set; }

        /// <summary>
        /// Trigger name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string TableName { get; private set; }

        /// <summary>
        /// Creates a new trigger
        /// </summary>
        /// <param name="schema"></param>
        /// <param name="name"></param>
        /// <param name="tableName"></param>
        /// <returns></returns>
        public static Trigger CreateNew(string schema, string name, string tableName)
        {
            return new Trigger()
            {
                Schema = schema,
                Name = name,
                TableName = tableName
            };
        }
    }
}
