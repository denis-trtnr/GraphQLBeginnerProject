using GraphiQl;
using GraphQL.Server;
using GraphQL.Server.Transports.AspNetCore;
using GraphQL.Server.Transports.AspNetCore.SystemTextJson;
using GraphQL.Types;
using GraphQLAPITest.Data;
using GraphQLAPITest.Interfaces;
using GraphQLAPITest.Mutations;
using GraphQLAPITest.Queries;
using GraphQLAPITest.Schemas;
using GraphQLAPITest.Services;
using GraphQLAPITest.Types;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace GraphQLAPITest
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //This method gets called by the runtime. Use this method to add services to the container

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddTransient<IProduct, ProductService>();
            services.AddTransient<ProductType>();
            services.AddTransient<ProductQuery>();
            services.AddTransient<ProductMutation>();
            services.AddTransient<ISchema, ProductSchema>();

            services.AddGraphQL(options =>
            {
                options.EnableMetrics = false;
            }).AddSystemTextJson();

            services.AddDbContext<GraphQLDbContext>(option => option.UseSqlServer(@"Data Source= (localdb)\ProjectModels;Initial Catalog=GraphQLDb,Integrated Security = True"));
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, GraphQLDbContext dbContext)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            dbContext.Database.EnsureCreated();
            app.UseGraphiQl("/graphql");
            app.UseGraphQL<ISchema>();
        }
    }
}
