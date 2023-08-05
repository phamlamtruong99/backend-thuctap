using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;
using System.Reflection.Metadata;

namespace WebTT.Entities
{
    public class phattu
    {
        [Key]
        public int phattuid { get; set; }
        public string? anhchup { get; set; }
        public bool? dahoantuc { get; set; }
        public string? email { get; set; }
        public int? gioitinh { get; set; }
        public string? ho { get; set; }
        public DateTime? ngaycapnhap { get; set; }
        public DateTime? ngayhoantuc { get; set; }
        public DateTime? ngaysinh { get; set; }
        public DateTime? ngayxuatgia{ get; set; }
        public string? password { get; set; }
        public string? phapdanh { get; set; }
        public string? sodienthoai { get; set; }
        public string? ten { get; set; }
        public string? tendem { get; set; }  
        public bool? trangthai { get; set; }
        public int? chuaid { get; set; }
        public chuas? chua { get;set; }
        public int? kieuthanhvienid { get; set; }
        public kieuthanhviens? kieuthanhvien { get; set; }
        public int? AdminId { get; set; }
        public Admin? Admin { get; set; }
        public IEnumerable<phattudaotrangs>? phattudaotrangs { get; set; }
        public IEnumerable<token>? tokens { get; set; }

    }
}
 

