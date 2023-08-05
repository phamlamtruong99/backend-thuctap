using WebTT.DTO;
using WebTT.Entities;

namespace WebTT.Converters
{
    public class ChuaConverter
    {  
        public ChuaDTO ChuaToDTO(chuas Chua)
        {
            return new ChuaDTO
            {   
                capnhat = Chua.capnhat,
                diachi= Chua.diachi,
                ngaythanhlap = Chua.ngaythanhlap,
                tenchua = Chua.tenchua,
                trutri = Chua.trutri,  
            };
        }
    }
}
