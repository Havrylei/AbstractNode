using System.Collections.Generic;
using System.Threading.Tasks;
using AbstractNode.BLL.DTO;

namespace AbstractNode.BLL.Interfaces
{
    public interface INodeService
    {
        Task<IEnumerable<NodeDto>> GetAll();
        Task<NodeDto> Get(int id);
        void Dispose();
    }
}
