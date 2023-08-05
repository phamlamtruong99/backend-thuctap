using System.ComponentModel.DataAnnotations;

namespace WebTT.Entities
{
    public class phattudaotrangs
    {
        [Key] 
        public int phattudaotrangid { get; set; }
        public bool? dathamgia { get; set; }
        public string? lydokhongthamgia { get; set; }    
        public int? daotrangid { get; set; }
        public daotrangs? daotrang { get; set; }
        public int? phattuid { get; set; }
        public phattu? phattu { get; set; }
        
    }
}
