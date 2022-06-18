using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Naves_API.Core.Entities;
using Naves_API.Core.Interfaces;

namespace Naves_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class NavesController : ControllerBase
    {
        readonly INaveRepository _naveRepository;// inyeccion de repositorio

        public NavesController(INaveRepository naveRepository)
        {
            _naveRepository = naveRepository;
        }

        [HttpGet]
        public async Task <IActionResult> GetNaves()
        {
            var naves = await _naveRepository.GetNaves();

            return Ok(naves);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNaves(int id)
        {
            var nave = await _naveRepository.GetNaves(id);

            return Ok(nave);

        }

        [HttpPost]
        public async Task<IActionResult> Nave(Nave nave)
        {
            await _naveRepository.InsertNave(nave);

            return Ok(nave);

        }

    }
}
