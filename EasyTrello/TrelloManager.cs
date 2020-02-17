namespace EaseTrello
{
    using System.IO;
    using Unity;
    using Unity.Injection;
    using Client;
    using Helpers;
    using Import;
    using Interfaces;
    using Models;
    using Services;
    using System.Threading.Tasks;

    public class TrelloManager
    {
        private static UnityContainer _container;

        public TrelloManager(
            string apiKey,
            string token)
        {
            this.InitUnityContainer(apiKey, token);
        }

        public async Task ImportToTrello(string filePath)
        {
            var boardLoader = _container.Resolve<IBoardLoader>();
            var importer = _container.Resolve<IImporter>();

            var boardName = Path.GetFileNameWithoutExtension(filePath);
            var source = boardLoader.Load(filePath);
            var destination = new Board(boardName);

            await importer.Import(source, destination);
        }

        private void InitUnityContainer(
            string apiKey,
            string token)
        {
            _container = new UnityContainer();
            
            _container.RegisterType<IAccessProvided, AccessProvided>(new InjectionConstructor(new object[] { apiKey, token }));

            // Trello services injection
            _container.RegisterType<IHttpClient, DefaultHttpClient>();
            _container.RegisterType<IBoardService, BoardService>();
            _container.RegisterType<ICardService, CardService>();
            _container.RegisterType<ITokensService, TokensService>();
            _container.RegisterType<IChecklistsService, ChecklistsService>();
            _container.RegisterType<IMemberService, MemberService>();

            // File loader injection
            _container.RegisterType<IBoardLoader, BoardLoader>(); // TODO: try "Adapter" or "Mediator"

            // "Chain of responsibility" injection
            _container.RegisterType<IImporter, BoardImport>();
            _container.RegisterType<CardImport, CardImport>();
            _container.RegisterType<ListImport, ListImport>();
            _container.RegisterType<LabelImport, LabelImport>();
            _container.RegisterType<ChecklistsImport, ChecklistsImport>();
        }
    }
}
