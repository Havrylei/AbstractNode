using AutoMapper; 
using AbstractNode.BLL.Infrastructure.Profiles;

namespace AbstractNode.BLL.Infrastructure
{
    public static class MapperProfile
    {
        public static IMapper Instance;

        static MapperProfile()
        {
            var mapperConfiguration = new MapperConfiguration(config =>
            {
                config.AddProfile<NodeProfile>();
            });

            Instance = mapperConfiguration.CreateMapper();
        }
    }
}
