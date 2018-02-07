using Ninject.Modules;
using AbstractNode.BLL.Interfaces;
using AbstractNode.BLL.Services;
using AbstractNode.DAL.Interfaces;
using AbstractNode.DAL.Repositories;

namespace AbstractNode.BLL.Infrastructure
{
    public class ServiceModule : NinjectModule
    {
        private readonly string connectionString;

        public ServiceModule(string connection)
        {
            connectionString = connection;
        }

        public override void Load()
        {
            Bind<IUnitOfWork>().To<UnitOfWork>().WithConstructorArgument(connectionString);
            Bind<INodeService>().To<NodeService>().WithConstructorArgument(MapperProfile.Instance);
        }
    }
}
