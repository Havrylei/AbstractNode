using AbstractNode.DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AbstractNode.DAL.Infrastructure
{
    public class AbstractNodeContext : DbContext
    {
        public DbSet<Node> Nodes { get; set; }

        public AbstractNodeContext(DbContextOptions context) 
            : base(context)
        {

        }
    }
}
