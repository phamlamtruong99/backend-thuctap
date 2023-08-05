using System.ComponentModel.DataAnnotations;

namespace WebTT.Entities
{
    public class chuas
    {
        [Key]
        public int chuaid { get; set; }
        public DateTime? capnhat { get; set; }
        public string? diachi { get; set; }
        public DateTime? ngaythanhlap { get; set; }
        public string? tenchua { get; set; }
        public string? trutri { get; set; }
        public IEnumerable<phattu>? phattu { get; set; }
    }
}
