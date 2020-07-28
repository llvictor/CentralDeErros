using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using CentralDeErros.Api.DTO;
using CentralDeErros.Domain.Entities;
using CentralDeErros.Domain.Enum;
using CentralDeErros.Domain.Interfaces.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Environment = CentralDeErros.Domain.Enum.Environment;

namespace CentralDeErros.Api.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class LogController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryLog _repo;

        public LogController(IMapper mapper, IRepositoryLog repo)
        {
            _mapper = mapper;
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
        public ActionResult<IEnumerable<Log>> Post([FromBody] LogDTO log)
        {
            _repo.Insert(_mapper.Map<LogDTO, Log>(log));
            return _repo.List();
        }

        [HttpPut]
        public IEnumerable<Log> Put([FromBody] Log log)
        {
            _repo.Update(log);
            return _repo.List();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Log> Delete(int id)
        {
            _repo.Delete(id);
            return _repo.List();
        }

        [HttpPost("GetLogsFiltered")]
        public ActionResult<IEnumerable<Log>> Post([FromBody] LogFilterDTO LogFilter)
        {
            return Ok(_repo.getLogsFiltered(LogFilter.environment, LogFilter.orderBy, LogFilter.searchBy, LogFilter.search));
        }

        [HttpPost("Archive")]
        public ActionResult Post(int id)
        {
            return Ok(_repo.ArchiveLog(id));
        }

    }
}
