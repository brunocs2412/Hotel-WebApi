
using LogicaAccesoDatos.BaseDatos;
using LogicaAccesoDatos.Repositorios;
using LogicaAplicacion.CasosDeUso;
using LogicaAplicacion.InterfacesCasosDeUso;
using LogicaNegocio.EntidadesNegocio;
using LogicaNegocio.InterfacesRepositorios;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;
using System.Text.Json;

namespace WebApiHotel;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        //Agregnado styles para swagger 
        builder.Services.AddSwaggerGen(options =>
        {

            options.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Hotel Mantenimientos",
                Description = "apiUrl: https://localhost:7084/",
                Contact = new OpenApiContact
                {
                    Name = "Juan Ximenez",
                    Url = new Uri("https://www.linkedin.com/in/juan-ximenez-0a9a13230/")

                },
                License = new OpenApiLicense
                {
                    Name = "Bruno Collazo",
                    Url = new Uri("https://www.linkedin.com/in/bruno-collazo/")
                }
            });

            // using System.Reflection; para que deje mostrar los summary de los metodos 
            var xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
            options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));

            //Para que pueda ingresar el token en swagger y hacer las pruebas
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                In = ParameterLocation.Header,
                Description = "Por favor ingrese el token JWT con Bearer al inicio.",
                Name = "Authorization",
                Type = SecuritySchemeType.ApiKey
            });

            options.AddSecurityRequirement(new OpenApiSecurityRequirement()
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });



        });

        //Agregando la configuracion de parametros
        var configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("Parametros.json")
            .Build();

        Parametros.TopeMaximoCabania = configuration.GetValue<int>("TopeMaxDscCabania");
        Parametros.TopeMinimoCabania = configuration.GetValue<int>("TopeMinDscCabania");
        Parametros.TopeMinimoMantenimiento = configuration.GetValue<int>("TopeMinDscMantenimiento");
        Parametros.TopeMaximoMantenimiento = configuration.GetValue<int>("TopeMaxDscMantenimiento");
        Parametros.TopeMaximoTipo = configuration.GetValue<int>("TopeMaxTipo");
        Parametros.TopeMinimoTipo = configuration.GetValue<int>("TopeMinTipo");


        //Agregando JWT
        var claveSecreta = "ZWRpw6fDo28gZW0gY29tcHV0YWRvcmE=";

        builder.Services.AddAuthentication(aut =>
        {
            aut.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            aut.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })

       .AddJwtBearer(aut =>
       {
           aut.RequireHttpsMetadata = false;
           aut.SaveToken = true;
           aut.TokenValidationParameters = new TokenValidationParameters
           {
               ValidateIssuerSigningKey = true,
               IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(claveSecreta)),
               ValidateIssuer = false,
               ValidateAudience = false
           };
           aut.Events = new JwtBearerEvents
           {
               OnChallenge = context =>
               {
                   // Evita el desafío por defecto de JwtBearer.
                   context.HandleResponse();

                   context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                   context.Response.ContentType = "application/json";

                   // Personaliza la respuesta.
                   var problem = new
                   {
                       code = context.Response.StatusCode,
                       message = "No está autorizado para acceder a este recurso, por favor proporcione un token válido."
                   };
                   var problemJson = JsonSerializer.Serialize(problem);
                   return context.Response.WriteAsync(problemJson);
               }
           };
       });


        //Agregando Scoped:

        //CU Cabania
        builder.Services.AddScoped<ICUCabaniaAlta, CUCabaniaAlta>();
        builder.Services.AddScoped<ICUCabaniaBuscarPorNombre, CUCabaniaBuscarPorNombre>();
        builder.Services.AddScoped<ICUCabaniaBuscarPorTipo, CUCabaniaBuscarPorTipo>();
        builder.Services.AddScoped<ICUCabaniaBuscarHabilitadas, CUCabaniaBuscarHabilitadas>();
        builder.Services.AddScoped<ICUCabaniaBuscarPorCapacidad, CUCabaniaBuscarPorCapacidad>();
        builder.Services.AddScoped<ICUCabaniaListar, CUCabaniaListar>();
        builder.Services.AddScoped<ICUCabaniaActualizar, CUCabaniaActualizar>();
        builder.Services.AddScoped<ICUMantenimientoListarEntreDosFechas, CUMantenimientoListarEntreDosFechas>();
        builder.Services.AddScoped<ICUCabaniaDelete, CUCabaniaDelete>();
        builder.Services.AddScoped<ICUCabaniaBuscarPorId, CUCabaniaBuscarPorId>();


        //CU Mantenimiento
        builder.Services.AddScoped<ICUMantenimientoAlta, CUMantenimientoAlta>();
        builder.Services.AddScoped<ICUMantenimientosListar, CUMantenimientosListar>();

        //CU TipoCabania
        builder.Services.AddScoped<ICUTipoCabaniaBuscarPorNombre, CUTipoCabaniaBuscarPorNombre>();
        builder.Services.AddScoped<ICUTipoCabaniaListar, CUTipoCabaniaListar>();
        builder.Services.AddScoped<ICUTipoCabaniaAlta, CUTipoCabaniaAlta>();
        builder.Services.AddScoped<ICUTipoCabaniaActualizar, CUTipoCabaniaActualizar>();
        builder.Services.AddScoped<ICUTipoCabaniaEliminar, CUTipoCabaniaEliminar>();
        builder.Services.AddScoped<ICUCabaniasFiltroTipoYMonto, CUCabaniasFiltroTipoYMonto>();
        builder.Services.AddScoped<ICUTipoBuscarPorId, CUTipoBuscarPorId>();
        builder.Services.AddScoped<ICUMantenimientoBusquedaPorCapacidad, CUMantenimientoBusquedaPorCapacidad>();

        //Cu Usuario
        builder.Services.AddScoped<ICULogin, CULogin>();

        //Repositorios
        builder.Services.AddScoped<IRepositorioCabania, RepositorioCabania>();
        builder.Services.AddScoped<IRepositorioUsuario, RepositorioUsuario>();
        builder.Services.AddScoped<IRepositorioTipo, RepositorioTipo>();


        //conexion a base de datos
        builder.Services.AddSqlServer<HotelContext>(builder.Configuration.GetConnectionString("cnBase"));

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        // app.UseHttpsRedirection();
        app.UseRouting();
        //para darle css al swagger
        app.UseStaticFiles();

        app.UseAuthentication();
        app.UseAuthorization();


        app.MapControllers();

        app.Run();
    }
}