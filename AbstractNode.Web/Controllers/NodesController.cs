using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AbstractNode.BLL.DTO;
using AbstractNode.BLL.Interfaces;

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
        public IEnumerable<NodeDto> Get()
        {
            IEnumerable<NodeDto> list = service.GetAll();

            return list;
        }
        
        [HttpGet("{id}")]
        public NodeDto Get(int id)
        {
            NodeDto entity = service.Get(id);

            return entity;
        }
    }
}
