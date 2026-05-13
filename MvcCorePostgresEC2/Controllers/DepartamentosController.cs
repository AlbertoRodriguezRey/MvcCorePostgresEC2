using Microsoft.AspNetCore.Mvc;
using MvcCorePostgresEC2.Repositories;

namespace MvcCorePostgresEC2.Controllers
{
    public class DepartamentosController : Controller
    {
        private RepositoryDepartamentos repo;

        public DepartamentosController(RepositoryDepartamentos repo)
        {
            this.repo = repo;
        }
        public async Task<IActionResult> Index()
        {
            var departamentos = await this.repo.GetDepartamentosAsync();
            return View(departamentos);
        }
        //DETAILS
        public async Task<IActionResult> Details(int id)
        {
            var dept = await this.repo.FindDepartamentoAsync(id);
            return View(dept);
        }
        //CREATE
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(int idDepartamento, string nombre, string localidad)
        {
            await this.repo.CreateDepartamento(idDepartamento, nombre, localidad);
            return RedirectToAction("Index");
        }
    }
}
