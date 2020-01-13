namespace ScriptGenerator.Models
{
    /// <summary>
    /// Class header interface
    /// </summary>
    interface IClassHeader
    {
        /// <summary>
        /// Class acess level
        /// </summary>
        CodeAccessLevel AccessLevel { get; set; }

        /// <summary>
        /// Namespace under which falls the class
        /// </summary>
        string Namespace { get; set; }

        /// <summary>
        /// Class name
        /// </summary>
        string Name { get; set; }
    }
}
