namespace Program
{
    using System;
    using System.Net.Http;
    using System.Threading.Tasks;
    using Autofac;
    using Autofac.Features.AttributeFilters;
    using UnitUnderTest;

    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ContainerBuilder();

            // Register individual components
            builder
                .RegisterType<HttpClient>()
                .SingleInstance();
            builder
                .RegisterType<SimpleFunctionality>()
                .AsImplementedInterfaces();
            builder
                .RegisterType<DocumentProvider>()
                .AsImplementedInterfaces();

            // get an instance of document provider and register it as Key1
            builder.Register(ctx => ctx.Resolve<IDocumentProvider>())
                .Keyed<IDocumentProvider>("Key1")
                .SingleInstance();
            builder.Register(ctx => ctx.Resolve<IDocumentProvider>())
                .Keyed<IDocumentProvider>("Key2")
                .SingleInstance();

            builder.RegisterType<SimpleUnitUnderTest>();
            builder.RegisterType<ComplexUnitUnderTest>()
                .WithAttributeFiltering();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var stuff = scope.Resolve<SimpleUnitUnderTest>();
                var x = await stuff.DoStuffAsync(new Uri("https://www.ppedv.de/"));

                var moreStuff = scope.Resolve<ComplexUnitUnderTest>();
            }
        }
    }
}
