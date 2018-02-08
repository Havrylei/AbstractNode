﻿using System.Collections.Generic;
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
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public NodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<NodeDto>> GetAll()
        {
            IEnumerable<Node> list = await unitOfWork.Nodes.GetAll();
            IEnumerable<NodeDto> result = mapper.Map<IEnumerable<NodeDto>>(list);

            return result;
        }

        public async Task<NodeDto> Get(int id)
        {
            Node entity = await unitOfWork.Nodes.Get(id);
            NodeDto result = mapper.Map<NodeDto>(entity);

            return result;
        }

        public void Dispose()
        {
            unitOfWork.Dispose();
        }
    }
}
