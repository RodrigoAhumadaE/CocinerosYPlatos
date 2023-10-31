using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CocinerosYPlatos.Models;

namespace CocinerosYPlatos.Controllers;

public class ChefController : Controller{
    private readonly ILogger<ChefController> _logger;
    private MyContext _context;

    public ChefController(ILogger<ChefController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet("")]
    public IActionResult Index(){
        List<Chef> ListaChef = _context.Chefs.ToList();
        return View("Index", ListaChef);
    }

    [HttpGet("nuevo/chef")]
    public IActionResult NuevoChef(){
        return View("NuevoChef");
    }

    // Post
    [HttpPost("agregar/Chef")]
    public IActionResult AgregarChef(Chef chef){
        if(ModelState.IsValid){
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        return View("NuevoChef");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
