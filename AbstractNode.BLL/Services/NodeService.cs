using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AbstractNode.BLL.DTO;
using AbstractNode.BLL.Interfaces;
using AbstractNode.DAL.Entities;
using AbstractNode.DAL.Interfaces;

namespace AbstractNode.BLL.Services
{
    public class NodeService : INodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork
                ?? throw new ArgumentNullException(nameof(unitOfWork));
            _mapper = mapper
                ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<IEnumerable<NodeDto>> GetAll()
        {
            IEnumerable<Node> result = await _unitOfWork.Nodes.GetAll();
            IEnumerable<NodeDto> list = _mapper.Map<IEnumerable<NodeDto>>(result);

            return list;
        }

        public async Task<NodeDto> Get(int id)
        {
            Node result = await _unitOfWork.Nodes.Get(id);
            NodeDto dto = _mapper.Map<NodeDto>(result);

            return dto;
        }

        public async Task Create(NodeDto dto)
        {
            Node entity = _mapper.Map<Node>(dto);

            await _unitOfWork.Nodes.Create(entity);
        }

        public async Task Update(NodeDto dto)
        {
            Node entity = _mapper.Map<Node>(dto);

            await _unitOfWork.Nodes.Update(entity);
        }

        public async Task Delete(NodeDto dto)
        {
            Node entity = _mapper.Map<Node>(dto);

            await _unitOfWork.Nodes.Delete(entity);
        }

        public void Dispose()
        {
            _unitOfWork.Dispose();
        }
    }
}
