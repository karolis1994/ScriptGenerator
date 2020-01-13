namespace ScriptGenerator.Models.Models.AIS
{
    public class APIModel : IClassHeader
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public CodeAccessLevel AccessLevel { get; set; }
    }
}
