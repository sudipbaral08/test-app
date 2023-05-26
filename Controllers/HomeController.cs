using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FirstApp.Models;

namespace FirstApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        var list = new List<StudentViewModel>(){
            new StudentViewModel(){ Id = 1, Name = "Shyam", Description = "okay" },
             new StudentViewModel(){ Id = 1, Name = "Prajwal", Description = "ghar bata bhagwa" },
        };
        return View(list);
    }
    [HttpGet]
    public IActionResult New(){
        return View(new TestViewModel());
    }
    [HttpPost]
    public IActionResult New(TestViewModel vm){
        return Ok(vm);
    }


    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Test(){
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
