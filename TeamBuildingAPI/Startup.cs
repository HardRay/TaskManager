using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;

namespace TeamBuilding.Api
{
    public class Startup
	{
		public Startup(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		public IConfiguration Configuration { get; }

		public void ConfigureServices(IServiceCollection services)
		{
			services.AddControllers(options =>
			{
			}).AddNewtonsoftJson(options =>
			{
				options.SerializerSettings.ContractResolver = new DefaultContractResolver
				{
					NamingStrategy = new DefaultNamingStrategy()
				};
				options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
				options.SerializerSettings.Converters.Add(new StringEnumConverter());
			}).ConfigureApiBehaviorOptions(options =>
			{
				options.SuppressModelStateInvalidFilter = true;
			});

			services.AddSwaggerGen();

			services.AddAuthorization();
		}

		public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IConfiguration configuration, ILoggerFactory loggerFactory)
		{
			app.Use(async (context, next) => {
				context.Request.EnableBuffering();
				await next();
			});

			app.UseRouting();

			app.UseAuthentication();

			app.UseAuthorization();

			app.UseSwagger();
			app.UseSwaggerUI();

			app.UseEndpoints(endpoints =>
			{
				endpoints.MapControllers();
			});
		}
	}
}
