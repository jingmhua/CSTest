using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using WebApplication_Null.Models;

namespace WebApplication_Null
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        //通过有参构造函数， 将_configuration 依赖注入
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);//添加mvc框架。
            services.AddTransient<IStudent, MockStudentImpl>();//用于依赖注入进行注册的


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            //app.UseHttpsRedirection();
            app.UseStaticFiles();
            //app.UseRouting();
            app.UseMvcWithDefaultRoute();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        //进程名
            //        //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        //await context.Response.WriteAsync(processName);

            //        //获取appsetting的对应的key的value
            //        //var configVal = _configuration["MyKey"];
            //        //await context.Response.WriteAsync(configVal);
            //        await context.Response.WriteAsync("Startup");


            //    });
            //});
        }
    }
}
