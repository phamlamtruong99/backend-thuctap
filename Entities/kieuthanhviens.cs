using System.ComponentModel.DataAnnotations;

namespace WebTT.Entities
{
    public class kieuthanhviens
    {
        [Key]
        public int kieuthanhvienid { get; set; }
        public string? code { get; set; }
        public string? tenkieu { get; set; }
        public IEnumerable<phattu>? phattu { get; set; }
        
    }
}
