using System;
using System.Threading.Tasks;

namespace AbstractNode.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INodeRepository Nodes { get; }
        Task Save();
    }
}
