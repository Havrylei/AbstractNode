using System;
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
        private readonly INodeService _service;

        public NodesController(INodeService service)
        {
            _service = service 
                ?? throw new ArgumentNullException(nameof(service));
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            IEnumerable<NodeDto> result = await _service.GetAll();

            return Ok(result);
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromRoute] int id)
        {
            NodeDto result = await _service.Get(id);

            if(result == null)
            {
                return BadRequest("Node not found.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] NodeDto dto)
        {
            await _service.Create(dto);

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] NodeDto dto)
        {
            NodeDto result = await _service.Get(dto.ID);

            if (result == null)
            {
                return BadRequest("Node not found.");
            }
            
            result = null;

            await _service.Update(dto);

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            NodeDto result = await _service.Get(id);

            if (result == null)
            {
                return BadRequest("Node not found.");
            }

            await _service.Delete(result);

            return Ok();
        }

        protected override void Dispose(bool disposing)
        {
            _service.Dispose();
            base.Dispose(disposing);
        }
    }
}
