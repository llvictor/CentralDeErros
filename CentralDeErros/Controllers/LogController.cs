using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
    public class LogController : ControllerBase
    {
        private readonly IRepositoryLog _repo;

        public LogController(IRepositoryLog repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Log> Get()
        {
            return _repo.List();
        }

        [HttpGet("{id}")]
        public Log Get(int id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public IEnumerable<Log> Post([FromBody] Log ingrediente)
        {
            _repo.Insert(ingrediente);
            return _repo.List();
        }

        [HttpPut]
        public IEnumerable<Log> Put([FromBody] Log ingrediente)
        {
            _repo.Update(ingrediente);
            return _repo.List();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Log> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.List();
        }
    }
}
