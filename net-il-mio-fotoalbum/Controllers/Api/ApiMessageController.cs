using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using net_il_mio_fotoalbum.Interface;
using net_il_mio_fotoalbum.Models.Db;

namespace net_il_mio_fotoalbum.Controllers.Api
{
    [Route("api/message/[action]")]
    [ApiController]
    public class ApiMessageController : ControllerBase
    {
        private readonly IRepository<Message> _crudMessage;

        public ApiMessageController(IRepository<Message> crudMessage)
        {
            _crudMessage = crudMessage;
        }


        [HttpPost]
        public IActionResult Post([FromBody] Message message)
        {
            _crudMessage.Add(message);
            return Ok(message);
        }
    }
}
