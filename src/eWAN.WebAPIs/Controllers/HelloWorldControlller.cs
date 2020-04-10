using Microsoft.AspNetCore.Mvc;
using System.Text.Encodings.Web;

namespace eWAN.WebAPIs.Controllers
{
    public class HelloWorldController : Controller
    {
        public string Index()
        {
            return "This is a test";
        }
    }
}
