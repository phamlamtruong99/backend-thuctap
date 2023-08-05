using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebTT.Constant;
using WebTT.DTO;
using WebTT.Entities;
using WebTT.Help;
using WebTT.IService;
using WebTT.Service;

namespace WebTT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DaoTrangControlles : ControllerBase
    {
        private readonly IDaoTrang _DaoTrang;
        public DaoTrangControlles()
        {
            _DaoTrang = new DaoTrangService();
        }
        // Lấy danh sách dao trang
        [HttpGet("lay danh sach dao trang phan trang")]
        public IActionResult LayDanhSachDaoTrang([FromQuery] Pagination pagination = null)
        {
            var result = _DaoTrang.LayDanhSachDaoTrang();
            var DaoTrang = PageResult<DaoTrangDTO>.ToPageResult(pagination, result).AsEnumerable();
            pagination.TotalCount = result.Count();
            var ret = new PageResult<DaoTrangDTO>(pagination, DaoTrang);
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        // Lấy danh sách dao trang phân trang
        [HttpGet("lay danh sach dao trang")]
        public IActionResult LayDanhDaoTrang()
        {
            var ret = _DaoTrang.LayDanhDaoTrang();
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }
        // Them thong tin chua
        [HttpPost("Them Dao Trang")]
        public IActionResult ThemDaoTrang(daotrangs DaoTrang)
        {
            var ret = _DaoTrang.ThemDaoTrang(DaoTrang);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them dao trang thanh cong");
            }
            else
            {
                return BadRequest("Them dao trang that bai");
            };
        }

        // sua thong tin chua 
        [HttpPut("sua thong tin dao trang")]
        public IActionResult SuaDaoTrang(daotrangs DaoTrang)
        {
            var ret = _DaoTrang.SuaDaoTrang(DaoTrang);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("sua thong tin dao trang thanh cong");
            }
            else
            {
                return BadRequest("Sua thong tin đao trang that bai");
            };
        }

        // Xoa thong tin chua 
        [HttpDelete("Xoa thong tin chua")]
        public IActionResult XoaDaoTrang([FromQuery] int DaoTrangId)
        {
            var ret = _DaoTrang.XoaDaoTrang(DaoTrangId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thong tin dao trang thanh cong");
            }
            else
            {
                return BadRequest("Xoa thong tin dao trang that bai");
            };
        }
    }
}
