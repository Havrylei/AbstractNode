using System.ComponentModel.DataAnnotations;

namespace AbstractNode.BLL.DTO
{
    public class NodeDto
    {
        public int ID { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
