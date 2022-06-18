using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Naves_API.Core.DTOs;
using Naves_API.Core.Entities;
using Naves_API.Core.Interfaces;

namespace Naves_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

  
    public class NavesController : ControllerBase
    {
        readonly INaveService _naveService;// inyeccion de repositorio
        private readonly IMapper _mapper; // inyeccion de dtos

        public NavesController(INaveService naveService, IMapper mapper)
        {
            _naveService = naveService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetNaves()
        {
            var naves = await _naveService.GetNaves();
            var navesdots = _mapper.Map<IEnumerable<NaveDto>>(naves);

            return Ok(navesdots);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNaves(int id)
        {
            var nave = await _naveService.GetNaves(id);
            var navedto = _mapper.Map<NaveDto>(nave);

            return Ok(navedto);

        }

        [HttpPost]
        public async Task<IActionResult> Nave(NaveDto nave)
        {
            var navedto = _mapper.Map<Nave>(nave);
            await _naveService.InsertNave(navedto);

            return Ok(nave);

        }

        [HttpGet("buscar/{buscar}")]
        public async Task<IActionResult> GetNaves(string buscar)
        {
            
            var nave = await _naveService.GetNavesLike(buscar);
            var navedto = _mapper.Map<IEnumerable<NaveDto>>(nave);
            return Ok(navedto);

        }

    }
}
