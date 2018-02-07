using Ninject.Modules;
using AbstractNode.BLL.Interfaces;
using AbstractNode.BLL.Services;

namespace AbstractNode.Web.Infrastructure
{
    public class BusinessLogicModule : NinjectModule
    {
        public override void Load()
        {
            Bind<INodeService>().To<NodeService>();
        }
    }
}
