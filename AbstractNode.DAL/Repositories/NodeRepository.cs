using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using AbstractNode.DAL.Entities;
using AbstractNode.DAL.Infrastructure;
using AbstractNode.DAL.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AbstractNode.DAL.Repositories
{
    public class NodeRepository : INodeRepository
    {
        private readonly AbstractNodeContext db;

        public NodeRepository(AbstractNodeContext context)
        {
            db = context;
        }

        public async Task<IEnumerable<Node>> GetAll()
        {
            return await (from n in db.Nodes
                            orderby n.ID descending                  
                            select n).ToListAsync();
        }

        public async Task<Node> Get(int id)
        {
            return await db.Nodes.FindAsync(id);
        }

        public async Task Create(Node entity)
        {
            await db.Nodes.AddAsync(entity);
            await db.SaveChangesAsync();
        }

        public async Task Update(Node entity)
        {
            db.Entry(entity).State = EntityState.Modified;

            db.SaveChanges();
        }

        public async Task Delete(Node entity)
        {
            db.Nodes.Remove(entity);
            await db.SaveChangesAsync();
        }
    }
}
