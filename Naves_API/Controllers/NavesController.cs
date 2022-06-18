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
        readonly INaveRepository _naveRepository;// inyeccion de repositorio
        private readonly IMapper _mapper; // inyeccion de dtos

        public NavesController(INaveRepository naveRepository, IMapper mapper)
        {
            _naveRepository = naveRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task <IActionResult> GetNaves()
        {
            var naves = await _naveRepository.GetNaves();
            var navesdots = _mapper.Map<IEnumerable<NaveDto>>(naves);

            return Ok(navesdots);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetNaves(int id)
        {
            var nave = await _naveRepository.GetNaves(id);
            var navedto = _mapper.Map<NaveDto>(nave);

            return Ok(navedto);

        }

        [HttpPost]
        public async Task<IActionResult> Nave(NaveDto nave)
        {
            var navedto = _mapper.Map<Nave>(nave);
            await _naveRepository.InsertNave(navedto);

            return Ok(nave);

        }

        [HttpGet("buscar/{buscar}")]
        public async Task<IActionResult> GetNaves(string buscar)
        {
            
            var nave = await _naveRepository.GetNavesLike(buscar);
            var navedto = _mapper.Map<IEnumerable<NaveDto>>(nave);
            return Ok(navedto);

        }

    }
}
