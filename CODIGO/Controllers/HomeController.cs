using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ejercicio1.Models;
using ejercicio1.dataAccess;

namespace ejercicio1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult GetAll()
    {
        conexionBD cn = new conexionBD();
        List<modCatalogo> listModelo = new List<modCatalogo>();
        listModelo = cn.GetAll();
        return View(listModelo);
    }

    public IActionResult Actualizar(int Id)
    {
        conexionBD cn = new conexionBD();
        List<modCatalogo> modelo = new List<modCatalogo>();
        modelo = cn.GetByID(Id);

        return View(modelo[0]);
    }

    [HttpPost]
    public IActionResult Actualizar(modCatalogo mod)
    {
        conexionBD cn = new conexionBD();
        bool insertado = cn.Actualizar(mod);
        return RedirectToAction("GetAll");
    }

    public IActionResult Detalles(int Id)
    {
        conexionBD cn = new conexionBD();
        List<modCatalogo> mod = new List<modCatalogo>();
        mod = cn.GetByID(Id);
        return View(mod[0]);
    }
    public IActionResult Eliminar(int Id)

    {
        conexionBD cn = new conexionBD();
        List<modCatalogo> modelo = new List<modCatalogo>();
        modelo = cn.GetByID(Id);

        return View(modelo[0]);
    }
    [HttpPost, ActionName("Eliminar")]
    public IActionResult EliminarById(int Id)

    {
        conexionBD cn = new conexionBD();
         bool Eliminar = cn.EliminarByID(Id);

        return RedirectToAction("GetAll");
    }
    public IActionResult Index()
    {
        return View();
    }
    public IActionResult AgregarNuevo()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AgregarNuevo(modCatalogo mod)
    {
        conexionBD cn = new conexionBD();
        cn.Insertar(mod);
        return RedirectToAction("GetAll");
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
