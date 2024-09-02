using Gertec.Application.Product.Queries;
using Gertec.Application.Product.Repositories;
using Gertec.Infrastructure.Data.Context;
using Gertec.Infrastructure.Data.Repositories.Product;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace Gertec.Infrastructure.BootStrap.DependencyInjection
{
    public static class InjectionRepository
    {
        public static void Register(IServiceCollection serviceCollection, IConfiguration configuration)
        {
            //Pega a Conexao do arquivo lauch.json
            serviceCollection.AddDbContext<GertecDbContext>(options => options.UseMySql(
                                                                                        configuration.GetSection("MySqlConfiguration").GetSection("ConnectionString").Value,
                                                                                        new MySqlServerVersion(new Version(8, 0, 36))));



            #region // queries //

            serviceCollection.AddScoped<IProductQuery, ProductQuery>();

            #endregion // queries //

            #region // repositories //

            serviceCollection.AddScoped<IProductRepository, ProductRepository>();

            #endregion // repositories //
        }
    }
}