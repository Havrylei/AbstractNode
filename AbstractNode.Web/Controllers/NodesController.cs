﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AbstractNode.BLL.DTO;
using AbstractNode.BLL.Interfaces;
using System.Threading.Tasks;

namespace AbstractNode.Web.Controllers
{
    [Route("api/[controller]")]
    public class NodesController : Controller
    {
        private readonly INodeService service;

        public NodesController(INodeService service)
        {
            this.service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<NodeDto>> Get()
        {
            IEnumerable<NodeDto> list = await service.GetAll();

            return list;
        }
        
        [HttpGet("{id}")]
        public async Task<NodeDto> Get(int id)
        {
            NodeDto entity = await service.Get(id);

            return entity;
        }
    }
}
