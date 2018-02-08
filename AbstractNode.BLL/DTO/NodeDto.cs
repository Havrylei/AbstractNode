using System.ComponentModel.DataAnnotations;

namespace AbstractNode.BLL.DTO
{
    public class NodeDto
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
    }
}
