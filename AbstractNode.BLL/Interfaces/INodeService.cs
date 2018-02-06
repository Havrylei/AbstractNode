using System.Collections.Generic;
using AbstractNode.BLL.DTO;

namespace AbstractNode.BLL.Interfaces
{
    public interface INodeService
    {
        IEnumerable<NodeDto> GetAll();
        NodeDto Get(int id);
        void Dispose();
    }
}
