using System.Collections.Generic;
using System.Threading.Tasks;
using AbstractNode.DAL.Entities;

namespace AbstractNode.DAL.Interfaces
{
    public interface INodeRepository
    {
        Task<IEnumerable<Node>> GetAll();
        Task<Node> Get(int id);
        Task Create(Node entity);
        Task Update(Node entity);
        Task Delete(Node entity);
    }
}
