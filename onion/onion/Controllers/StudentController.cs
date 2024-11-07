using DomainLayer.Models;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer.DTO;
using ServiceLayer.Service;

namespace onion.Controllers
{
    public class StudentController : Controller
    {
        private readonly ICustomService<StudentDTO> service;
        public StudentController(ICustomService<StudentDTO> service)
        {
            this.service = service;
        }
        public IActionResult Index()
        {
            return View(service.GetAll());
        }
    }
}
