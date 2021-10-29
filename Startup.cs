using AppCuadre.Datos;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using System.Data;

namespace AppCuadre
{
    public class Campo
    {
        public string nombre { get; set; }
        public int tipoDato { get; set; }
    }
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
            List<Campo> lista = new List<Campo>() {
             new Campo(){nombre="valor", tipoDato=1 },
             new Campo(){nombre="texto", tipoDato=1 },
            };
            CrearTablaDatosEmpresa("conciliacion", lista);
        }


       


        protected SqlConnection ObtenerConexion()
        {
            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "NICOLAS\\SQLEXPRESS";
            builder.InitialCatalog = "conciliaciones";
            builder.UserID = "NicolasMinds";
            builder.Password = "093933580";
            builder.ApplicationName = "MyApp";

            return new SqlConnection(builder.ConnectionString);
        }

        public Boolean CrearTablaDatosEmpresa(string nombre, List<Campo> datos )
        {
            Boolean estado = false;
            string cadenaCreacionTabla = " IF NOT EXISTS (select * from sysobjects where name='"+nombre+"')  create table " + nombre + "( Id" + nombre + " int identity(1,1) primary key,";
            string campos = cadenaCreacionTabla;

            for (int i = 0; i < datos.Count; i++) {

                if (datos[i].tipoDato == 1)
                {
                    campos = campos + datos[i].nombre + " varchar(200) ";
                }
                else if (datos[i].tipoDato == 2)
                {
                    campos = campos + datos[i].nombre + " money";
                }
                else
                {
                    campos = campos + datos[i].nombre + "int";
                }
                if (i==datos.Count-1) {
                    campos = campos + " ) select 0; ELSE select 1";
                } 
                else{
                    campos = campos + " ,"; 
                }
                        

               
            }

            using (var conexion = ObtenerConexion())
            {
                Int32 newProdID = 0;
                conexion.Open();
                using (var comando = new SqlCommand())
                {
                    comando.Connection = conexion;
                    comando.CommandText = campos;
                    comando.CommandType = CommandType.Text;
                    /*newProdID=(Int32) comando.ExecuteScalar();
                    if (newProdID == 1) {
                        estado = false;
                    }else {
                        estado = true;
                    } */
                }
            }
            return estado;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            //cadena de conexion
            services.AddDbContext<ApplicationDbContext>(options => 
            options.UseSqlServer(Configuration.GetConnectionString("ConnectionSQLServer")));
                 
            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
