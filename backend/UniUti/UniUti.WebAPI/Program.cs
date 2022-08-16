using UniUti.Infra.IoC;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//string mySqlConnectionString = builder.Configuration.GetConnectionString("DefaultConnection");

//builder.Services.AddDbContext<ApplicationDbContext>
//(options => options.UseMySql(
//    mySqlConnectionString,
//    ServerVersion.AutoDetect(mySqlConnectionString))
//);

//IMapper mapper = MappingConfig.RegisterMaps().CreateMapper();

//builder.Services.AddSingleton(mapper);
//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
//builder.Services.AddScoped<IAuthRepository, AuthRepository>();
//builder.Services.AddScoped<IInstituicaoRepository, InstituicaoRepository>();
//builder.Services.AddScoped<IMonitoriaRepository, MonitoriaRepository>();
//builder.Services.AddScoped<ICursoRepository, CursoRepository>();

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddInfrastructureJWT(builder.Configuration);
builder.Services.AddInfrastructureSwagger();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
