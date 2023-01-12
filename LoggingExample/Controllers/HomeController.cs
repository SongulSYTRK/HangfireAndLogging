using LoggingExample.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace LoggingExample.Controllers
{
    public class HomeController : Controller
   {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        //private readonly ILoggerFactory? _loggerFactory;
        // public HomeController(ILoggerFactory? loggerFactory)
        //{
        //      _loggerFactory = loggerFactory;
        //   }
        public IActionResult Index()
    {
            int value1 = 5;
            int value2 = 0;
            int result;
            try
            {
                result = value1 / value2;
            }
            catch (Exception ex)
            {

                _logger.LogError(ex,ex.Message);

            }
     //  var _logger= _loggerFactory.CreateLogger("home sınıfı ");

           /* _logger.LogTrace("index sayfasına girildi");
            _logger.LogDebug("index sayfasına girildi");*/

            _logger.LogInformation("index sayfasına girildi");
           /* _logger.LogWarning("index sayfasına girildi");
            _logger.LogError("index sayfasına girildi");
            _logger.LogCritical("index sayfasına girildi");*/
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