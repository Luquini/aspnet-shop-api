using Microsoft.AspNetCore.Mvc;

namespace Shop.Api.Controllers
{
  public class HomeController : Controller
  {
    [HttpGet]
    [Route("")]
    public string Get()
    {
      return "";
    }
  }
}
