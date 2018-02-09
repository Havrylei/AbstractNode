using System;
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
        private readonly AbstractNodeContext _context;

        public NodeRepository(AbstractNodeContext context)
        {
            _context = context
                ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<IEnumerable<Node>> GetAll()
        {
            return await (from n in _context.Nodes
                            orderby n.ID descending                  
                            select n).ToListAsync();
        }

        public async Task<Node> Get(int id)
        {
            Node result = await _context.Nodes.FindAsync(id);

            _context.Entry(result).State = EntityState.Detached;

            return result;
        }

        public async Task Create(Node entity)
        {
            await _context.Nodes.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Update(Node entity)
        {
            _context.Entry(entity).State = EntityState.Modified;

            _context.SaveChanges();
        }

        public async Task Delete(Node entity)
        {
            _context.Nodes.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
