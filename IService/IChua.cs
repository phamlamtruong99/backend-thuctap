using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;

namespace WebTT.IService
{
    public interface IChua
    {
        ErrorMessage ThemChua(chuas Chua); // 
        ErrorMessage SuaChua(chuas Chua); //
        ErrorMessage XoaChua(int ChuaId); // 
        IEnumerable<ChuaDTO> LayDanhSachChuaPhanTrang(Pagination pagination = null);
        IEnumerable<chuas> LayDanhSachChua();
    }
}
