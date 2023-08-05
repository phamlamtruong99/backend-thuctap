using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;

namespace WebTT.IService
{
    public interface IDaoTrang
    {
        ErrorMessage ThemDaoTrang(daotrangs DaoTrang); // 
        ErrorMessage SuaDaoTrang(daotrangs DaoTrang); //
        ErrorMessage XoaDaoTrang(int DaoTrangId); // 
        IEnumerable<DaoTrangDTO> LayDanhSachDaoTrang(Pagination pagination = null);
        IEnumerable<daotrangs> LayDanhDaoTrang();
    }
}
