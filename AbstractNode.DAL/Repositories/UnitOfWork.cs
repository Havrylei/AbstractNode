using System;
using AbstractNode.DAL.Infrastructure;
using AbstractNode.DAL.Interfaces;

namespace AbstractNode.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbstractNodeContext _context;
        private bool disposed;
        private INodeRepository nodeRepository;

        public UnitOfWork(AbstractNodeContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public INodeRepository Nodes
        {
            get
            {
                if (nodeRepository == null)
                {
                    nodeRepository = new NodeRepository(_context);
                }

                return nodeRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }

                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
