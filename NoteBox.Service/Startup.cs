using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Notebox.Data;
using Notebox.Data.Contract.MajorData;
using Notebox.Data.Contract.UserData;
using Notebox.Data.MajorRepo;
using NoteBox.Application;
using NoteBox.Application.Contract;
using NoteBox.Data.UserRepo;
using NoteBox.Domain.MajorDtos;
using NoteBox.Domain.UserDtos;

namespace NoteBox.Service
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

            services.AddScoped<IMajorApplicationService, MajorApplicationService>();
            services.AddScoped<IMajorDataContextFactory, ContextFactory>();
            services.AddScoped<IMajorRepository, MockMajorRepository>();
            services.AddScoped<IMajorMapper, MajorMapper>();
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
