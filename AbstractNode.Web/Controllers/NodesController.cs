using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AbstractNode.BLL.DTO;
using AbstractNode.BLL.Interfaces;
using AbstractNode.Web.Filters;

namespace AbstractNode.Web.Controllers
{
    [Route("api/[controller]")]
    [HandleExceptionFilter]
    [ValidateModel]
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
        public async Task<NodeDto> Get([FromRoute] int id)
        {
            NodeDto entity = await service.Get(id);

            return entity;
        }

        [HttpPost]
        public async Task Create([FromBody] NodeDto dto)
        {
            await service.Create(dto);
        }

        [HttpPut]
        public async Task Update([FromBody] NodeDto dto)
        {
            await service.Update(dto);
        }

        [HttpDelete("{id}")]
        public async Task Delete([FromRoute] int id)
        {
            await service.Delete(id);
        }

        protected override void Dispose(bool disposing)
        {
            service.Dispose();
            base.Dispose(disposing);
        }
    }
}
