using AutoMapper;
using AbstractNode.BLL.DTO;
using AbstractNode.DAL.Entities;

namespace AbstractNode.BLL.Infrastructure.Profiles
{
    public class NodeProfile : Profile
    {
        public NodeProfile()
        {
            CreateMap<Node, NodeDto>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.Name))
                .ForAllOtherMembers(m => m.Ignore());

            CreateMap<NodeDto, Node>()
                .ForMember(m => m.ID, c => c.MapFrom(d => d.ID))
                .ForMember(m => m.Name, c => c.MapFrom(d => d.Name))
                .ForAllOtherMembers(m => m.Ignore());
        }
    }
}
