namespace ScriptGenerator.Models.Models.AIS
{
    public class DomainModel : IClassHeader
    {
        public string Namespace { get; set; }
        public string Name { get; set; }
        public CodeAccessLevel AccessLevel { get; set; }
    }
}
