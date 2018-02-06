using System;
using AbstractNode.DAL.Infrastructure;
using AbstractNode.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbstractNode.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AbstractNodeContext db;
        private bool disposed;
        private INodeRepository nodeRepository;

        public UnitOfWork(string connectionString)
        {
            var builder = new DbContextOptionsBuilder<AbstractNodeContext>();

            builder.UseSqlServer(connectionString);

            db = new AbstractNodeContext(builder.Options);
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

        public void Save()
        {
            db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if(!disposed)
            {
                if(disposing)
                {
                    db.Dispose();
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
