using System;

namespace AbstractNode.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        INodeRepository Nodes { get; }
        void Save();
    }
}
