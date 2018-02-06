using System.Collections.Generic;
using AbstractNode.DAL.Entities;

namespace AbstractNode.DAL.Interfaces
{
    public interface INodeRepository
    {
        IEnumerable<Node> GetAll();
        Node Get(int id);
    }
}
