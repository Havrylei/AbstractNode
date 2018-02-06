using System.Collections.Generic;
using AbstractNode.DAL.Entities;
using AbstractNode.DAL.Infrastructure;
using AbstractNode.DAL.Interfaces;

namespace AbstractNode.DAL.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly AbstractNodeContext db;

        public NodeRepository(AbstractNodeContext context)
        {
            db = context;
        }

        public IEnumerable<Node> GetAll()
        {
            return db.Nodes;
        }

        public Node Get(int id)
        {
            return db.Nodes.Find(id);
        }        
    }
}
