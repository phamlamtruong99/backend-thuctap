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
    public class ChuaController : ControllerBase
    {
        private readonly IChua _Chua;
        public ChuaController()
        {
            _Chua = new ChuaService();
        }
        // Lấy danh sách chùa 
        [HttpGet("lay danh sach chua")] 
        public IActionResult LayDanhSachChua()
        {
            var ret=_Chua.LayDanhSachChua();
            if (ret != null)
            {
                return Ok(ret);
            }
            else
            {
                return BadRequest("That bai");
            }
        }

        // Lấy danh sách chùa 
        [HttpGet("lay danh sach chua phan trang")]
        public IActionResult LayDanhSachChuaPhanTrang([FromQuery] Pagination pagination = null)
        {
            var results = _Chua.LayDanhSachChuaPhanTrang(pagination);
            var Chua = PageResult<ChuaDTO>.ToPageResult(pagination, results).AsEnumerable();
            pagination.TotalCount = results.Count();
            var ret = new PageResult<ChuaDTO>(pagination, Chua);
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
        [HttpPost("Them chua")]
        public IActionResult ThemChua(chuas Chua)
        {
            var ret = _Chua.ThemChua(Chua);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Them thanh cong");
            }
            else
            {
                return BadRequest("Them that bai");
            };
        }

        // sua thong tin chua 
        [HttpPut("sua thong tin chua")]
        public IActionResult SuaChua(chuas Chua)
        {
            var ret = _Chua.SuaChua(Chua);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("sua thong tin chua thanh cong");
            }
            else
            {
                return BadRequest("Sua thong tin chua that bai");
            };
        }

        // Xoa thong tin chua 
        [HttpDelete("Xoa thong tin chua")]
        public IActionResult XoaChua([FromQuery] int ChuaId)
        {
            var ret = _Chua.XoaChua(ChuaId);
            if (ret == ErrorMessage.ThanhCong)
            {
                return Ok("Xoa thong tin chua thanh cong");
            }
            else
            {
                return BadRequest("Xoa thong tin chua that bai");
            };
        }
    }
}
