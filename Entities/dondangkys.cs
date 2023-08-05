using System.ComponentModel.DataAnnotations;

namespace WebTT.Entities
{
    public class dondangkys
    {
        [Key]  
        
        public int dondangkyid { get; set; }
        public DateTime? ngayguidon { get; set; }
        public DateTime? ngayxuly { get; set; }
        public int? nguoixuly { get; set; }
        public int? trangthaidon { get; set; }
        public int? daotrangid { get; set; }
        public daotrangs? daotrang { get; set; }
        public int? phattuid { get; set; }
        public phattu? phattu { get; set; }
    }
}
