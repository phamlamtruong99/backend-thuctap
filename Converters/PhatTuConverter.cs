using WebTT.DTO;
using WebTT.Entities;

namespace WebTT.Converters
{
    public class PhatTuConverter
    {
        public PhatTuDTO EntityToDTO(phattu phatTu)
        {
            return new PhatTuDTO
            {
                phattuid = phatTu.phattuid,
                anhchup = phatTu.anhchup,
                dahoantuc = phatTu.dahoantuc,
                email = phatTu.email,
                gioitinh = phatTu.gioitinh,
                ho = phatTu.ho,
                ngaycapnhap = phatTu.ngaycapnhap,
                ngayhoantuc = phatTu.ngayhoantuc,
                ngaysinh = phatTu.ngaysinh,
                ngayxuatgia = phatTu.ngayxuatgia,
                phapdanh = phatTu.phapdanh
            };
        }
    }
}
