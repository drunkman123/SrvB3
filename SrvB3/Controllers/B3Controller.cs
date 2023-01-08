using B3.DATA.Service;
using Microsoft.AspNetCore.Mvc;
using static B3.DATA.Model.ListarTodasAcoesModel;
using static B3.DATA.Model.ListarTodosFiisModel;

namespace SrvB3.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class B3Controller : Controller
    {
        private IHostEnvironment _hostingEnvironment;
        private readonly B3Service _B3Svc;
        public B3Controller(IHostEnvironment hostingEnvironment, IConfiguration Configuration, IHttpClientFactory httpClientFactory)
        {
            _hostingEnvironment = hostingEnvironment;
            _B3Svc = new B3Service(Configuration, hostingEnvironment, httpClientFactory);

        }

        [HttpGet]
        [Produces("application/json")]

        public async Task<ActionResult<Acoes>> ListarTodasAcoes()
        {
            try
            {
                return await _B3Svc.ListarTodasAcoes();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }

        [HttpGet]
        [Produces("application/json")]
        public async Task<ActionResult<Fiis>> ListarTodosFiis()
        {
            try
            {
                return await _B3Svc.ListarTodosFiis();

            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }

        }

    }
}
