namespace ScriptGenerator.Models
{
    /// <summary>
    /// Ais component file model
    /// </summary>
    public class CodeComponentFile
    {
        public CodeComponentFile(string codeText, string fileName)
        {
            this.ComponentCodeText = codeText;
            this.FileName = fileName.EndsWith(".cs") ? fileName : fileName + ".cs";
        }

        /// <summary>
        /// Component code text
        /// </summary>
        public string ComponentCodeText { get; private set; }

        /// <summary>
        /// Name of file for this component
        /// </summary>
        public string FileName { get; private set; }
    }
}
