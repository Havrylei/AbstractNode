using System;
using AbstractNode.DAL.Infrastructure;
using AbstractNode.DAL.Interfaces;

namespace AbstractNode.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbstractNodeContext db;
        private bool disposed;
        private INodeRepository nodeRepository;

        public UnitOfWork(AbstractNodeContext dbContext)
        {
            db = dbContext;
        }

        public INodeRepository Nodes
        {
            get
            {
                if (nodeRepository == null)
                {
                    nodeRepository = new NodeRepository(db);
                }

                return nodeRepository;
            }
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }

                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
