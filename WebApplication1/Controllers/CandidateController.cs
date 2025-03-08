﻿using Microsoft.AspNetCore.Mvc;
using Repository.Entities;
using Service.Interfaces;
using Service.Service;
using Service.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CandidateController : ControllerBase
    {
        private readonly IService<CandidateDto> _candidateService;
        public CandidateController(IService<CandidateDto> candidateService)
        {
            _candidateService = candidateService;
        }
        // GET: api/<CandidateController>
        [HttpGet]
        
        public List<CandidateDto> Get()
        {
            return _candidateService.GetAll();
        }

        // GET api/<CandidateController>/5
        [HttpGet("{id}")]
       
        public CandidateDto Get(int id)
        {
            return _candidateService.GetById(id);
        }

        // POST api/<CandidateController>
        [HttpPost]
        public void Post([FromForm] CandidateDto value)
        {
            _candidateService.AddItem(value);
        }

        // PUT api/<CandidateController>/5
        [HttpPut("{id}")]
        //[Authorize(Roles = "candidate")]
        public void Put(int id, [FromForm] CandidateDto value)
        {
            _candidateService.Update(id, value);
        }

        // DELETE api/<CandidateController>/5
        [HttpDelete("{id}")]
        [Authorize(Roles = "admin")]
        public void Delete(int id)
        {
            _candidateService.Delete(id);
        }
    }
}
