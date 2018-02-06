using System.Collections.Generic;
using AbstractNode.BLL.DTO;
using AbstractNode.BLL.Interfaces;
using AbstractNode.DAL.Interfaces;

namespace AbstractNode.BLL.Services
{
    public class NodeService : INodeService
    {
        private readonly IUnitOfWork db;

        public NodeService(IUnitOfWork unitOfWork)
        {
            db = unitOfWork;
        }

        public IEnumerable<NodeDto> GetAll()
        {
            return null;
        }

        public NodeDto Get(int id)
        {
            return null;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}
