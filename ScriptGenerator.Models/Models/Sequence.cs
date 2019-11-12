namespace ScriptGenerator.Models
{
    /// <summary>
    /// Sequence model
    /// </summary>
    public class Sequence
    {
        /// <summary>
        /// Sequence name
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// Schema name to which it belongs
        /// </summary>
        public string Schema { get; private set; }

        /// <summary>
        /// The number from which to start the sequence
        /// </summary>
        public long StartWith { get; private set; }

        /// <summary>
        /// The number by which to increment the sequence
        /// </summary>
        public long IncrementBy { get; private set; }

        /// <summary>
        /// Create a new sequence
        /// </summary>
        /// <param name="name"></param>
        /// <param name="schema"></param>
        /// <param name="startWith"></param>
        /// <param name="incrememntBy"></param>
        /// <returns></returns>
        public static Sequence CreateNew(string name, string schema, int startWith, int incrememntBy)
        {
            return new Sequence()
            {
                Name = name,
                Schema = schema,
                StartWith = startWith,
                IncrementBy = incrememntBy
            };
        }
    }
}
