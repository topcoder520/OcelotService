using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ServiceApi.ApiControllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        [Route("/")]
        [HttpGet]
        public ActionResult Hello()
        {
            return Ok(new { 
                Message = "ok"
            });
        }

        [HttpGet]
        public ActionResult GetBookById(int Id)
        {
            return Ok(new
            {
                Id = Id,
                BookName = "钢铁是怎样练成的",
                Author = "保尔柯察金",
                Time = DateTime.UtcNow.Ticks.ToString()
            });
        }

        [HttpPost]
        public ActionResult SaveBook()
        {
            return Ok(new { 
                Status = 200,
                Message = "保存成功！"
            });
        }
    }
}
