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

        //ͨ���вι��캯���� ��_configuration ����ע��
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(option => option.EnableEndpointRouting = false);//���mvc��ܡ�
            services.AddTransient<IStudent, MockStudentImpl>();//��������ע�����ע���


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
            //        //������
            //        //var processName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            //        //await context.Response.WriteAsync(processName);

            //        //��ȡappsetting�Ķ�Ӧ��key��value
            //        //var configVal = _configuration["MyKey"];
            //        //await context.Response.WriteAsync(configVal);
            //        await context.Response.WriteAsync("Startup");


            //    });
            //});
        }
    }
}
