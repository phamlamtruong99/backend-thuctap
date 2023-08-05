using System.ComponentModel.DataAnnotations;

namespace WebTT.Entities
{
    public class daotrangs
    {
        [Key]
        public int daotrangid { get; set; }
        public bool? daketthuc { get; set; }
        public string? noidung { get; set; }
        public string? noitochuc { get; set; }
        public int? sothanhvienthamgia { get; set; }
        public DateTime? thoigiantochuc { get; set; }
        public int? nguoitrutri { get; set; }
        public IEnumerable<dondangkys>? dondangkys { get; set; }
        public IEnumerable<phattudaotrangs>? phattudaotrangs { get; set; }

    }
}
