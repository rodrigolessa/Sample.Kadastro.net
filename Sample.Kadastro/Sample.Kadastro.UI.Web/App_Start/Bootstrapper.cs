using System.Web;
using System.Web.Mvc;
using Microsoft.Practices.Unity;
using Unity.Mvc3;
//-------------------------------

namespace Sample.Kadastro.UI.Web
{
    public static class Bootstrapper
    {
        public static void Initialise()
        {
            var container = BuildUnityContainer();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }

        private static IUnityContainer BuildUnityContainer()
        {
            var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers
            
            // e.g. container.RegisterType<ITestService, TestService>();
            RegisterTypes(container);

            return container;
        }

        public static void RegisterTypes(IUnityContainer container)
        {
            //TODO: container.RegisterType<IQueryableUnitOfWork, MainUnitOfWork>();

            //registra o UnityOfWork
            //TODO: container.RegisterType(typeof(MainUnitOfWork), new PerResolveLifetimeManager());

            //registra a fábrica de Adaptadores
            //TODO: container.RegisterType<ITypeAdapterFactory, AutomapperTypeAdapterFactory>(new ContainerControlledLifetimeManager());

            //registra os repositórios
            RegistraRepositorios(container);

            //registra os Servicos da camada de aplicação
            RegistraServicosDeAplicacao(container);

            //registra as fábricas
            RegistraFabricas(container);

            //registra os servicos de Domínio
            RegistraServicosDeDominio(container);
        }

        private static void RegistraFabricas(IUnityContainer container)
        {
            //TODO: LoggerFactory.SetCurrent(new TraceSourceLogFactory());
            //TODO: EntityValidatorFactory.SetCurrent(new DataAnnotationsEntityValidatorFactory());

            //TODO: var typeAdapterFactory = container.Resolve<ITypeAdapterFactory>();
            //TODO: TypeAdapterFactory.SetCurrent(typeAdapterFactory);
        }

        private static void RegistraServicosDeDominio(IUnityContainer container)
        {

        }

        private static void RegistraServicosDeAplicacao(IUnityContainer container)
        {
            //TODO: container.RegisterType<IUsuarioAppSevice, UsuarioAppService>();
            //TODO: container.RegisterType<IApplicationContext, WebApplicationContext>();
        }

        private static void RegistraRepositorios(IUnityContainer container)
        {
            //TODO: container.RegisterType<ICategoriaRepository, CategoriaRepository>();
            //TODO: container.RegisterType<ICheckListRepository, CheckListRepository>();
            //TODO: container.RegisterType<IClienteRepository, ClienteRepository>();
            //TODO: container.RegisterType<IProjetoRepository, ProjetoRepository>();
            //TODO: container.RegisterType<IUsuarioRepository, UsuarioRepository>();
        }
    }

    public class WebApplicationContext //TODO: IApplicationContext
    {
        public WebApplicationContext()
        {

        }

        public string Login
        {
            get
            {
                if (HttpContext.Current.Session["LOGIN"] != null)
                    return HttpContext.Current.Session["LOGIN"].ToString();

                return null;
            }
            set
            {
                HttpContext.Current.Session["LOGIN"] = value;
            }
        }
    }
}