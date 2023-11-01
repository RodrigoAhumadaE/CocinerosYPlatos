using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CocinerosYPlatos.Models;
using Microsoft.EntityFrameworkCore;

namespace CocinerosYPlatos.Controllers;

public class PlatoController : Controller{
    private readonly ILogger<PlatoController> _logger;
    private MyContext _context;

    public PlatoController(ILogger<PlatoController> logger, MyContext context){
        _logger = logger;
        _context = context;
    }

    [HttpGet("platos")]
    public IActionResult Platos(){
        List<Plato> ListaPlatos = _context.Platos.Include(p => p.Creador).ToList();
        return View("Platos", ListaPlatos);
    }

    [HttpGet("nuevo/plato")]
    public IActionResult NuevoPlato(){
        List<string> listaChefs = _context.Chefs.Select(c => c.Nombre + " " + c.Apellido).ToList();
        ViewBag.chefs = listaChefs;        
        return View("NuevoPlato");
    }

    // POST
    [HttpPost("agregar/plato")]
    public IActionResult AgregarPlato(Plato plato){
        if(ModelState.IsValid){
            _context.Platos.Add(plato);
            _context.SaveChanges();
            return RedirectToAction("Platos");
        }
        return View("NuevoPlato");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error(){
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}