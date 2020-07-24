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
    public class ErrorController : ControllerBase
    {
        private readonly IRepositoryError _repo;

        public ErrorController(IRepositoryError repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Error> Get()
        {
            return _repo.List();
        }

        [HttpGet("{id}")]
        public Error Get(int id)
        {
            return _repo.GetById(id);
        }

        [HttpPost]
        public IEnumerable<Error> Post([FromBody] Error ingrediente)
        {
            _repo.Insert(ingrediente);
            return _repo.List();
        }

        [HttpPut]
        public IEnumerable<Error> Put([FromBody] Error ingrediente)
        {
            _repo.Update(ingrediente);
            return _repo.List();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Error> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.List();
        }
    }
}
