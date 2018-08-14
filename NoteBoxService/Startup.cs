using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notebox.Data;
using Notebox.Data.Contract;
using Notebox.Data.Contract.UserData;
using Notebox.Data.UserRepo;
using NoteBoxApplication;
using NoteBoxDomain.UserDto;

namespace NoteBoxService
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().AddControllersAsServices();
            services.AddScoped<IUserAplicatinService, UserApplicationService>();
            services.AddScoped<IUserDataContextFactory, ContextFactory>();
            services.AddSingleton<IUserRepository, MockUserRepository>();
            services.AddScoped<IUserMapper, UserMapper>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
