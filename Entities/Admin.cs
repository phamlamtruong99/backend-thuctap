namespace WebTT.Entities
{
    public class Admin
    {    
        public int AdminId { get; set; }
        public string? NameTk { get; set; }
        public IEnumerable<phattu>? phattus { get; set; }
    }
}
