using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CentralDeErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LevelController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryLevel _repo;

        public LevelController(IMapper mapper, IRepositoryLevel repo)
        {
            _mapper = mapper;
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Level> Get()
        {
            return _repo.List();
        }

        [HttpGet("{id}")]
        public Level Get(int id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public ActionResult<IEnumerable<Level>> Post([FromBody] Level level)
        {
            _repo.Insert(level);
            return _repo.List();
        }

        [HttpPut]
        public IEnumerable<Level> Put([FromBody] Level level)
        {
            _repo.Update(level);
            return _repo.List();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Level> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.List();
        }
    }
}