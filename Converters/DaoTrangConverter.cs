using WebTT.DTO;
using WebTT.Entities;

namespace WebTT.Converters
{
    public class DaoTrangConverter
    {   
        public DaoTrangDTO DTtoDTO(daotrangs DaoTrang)
        {
            return new DaoTrangDTO
            {   
                daketthuc = DaoTrang.daketthuc,
                noidung = DaoTrang.noidung,
                noitochuc = DaoTrang.noitochuc,
                sothanhvienthamgia = DaoTrang.sothanhvienthamgia,
                thoigiantochuc = DaoTrang.thoigiantochuc,
                nguoitrutri =DaoTrang.nguoitrutri,
            };
                
        }
    }
}
