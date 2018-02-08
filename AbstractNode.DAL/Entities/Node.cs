using System.ComponentModel.DataAnnotations;

namespace AbstractNode.DAL.Entities
{
    public class Node
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
