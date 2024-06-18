using API_DCI_DIAGRAM_SVG.Contexts;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DBDCI>();
builder.Services.AddDbContext<HRMContext>();
builder.Services.AddDbContext<ManpowerContext>();
builder.Services.AddDbContext<DBPDB>();
builder.Services.AddDbContext<DBSCM>();
builder.Services.AddCors(options => options.AddPolicy("Cors", builder =>
{
    builder
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader();
}));
// Configure the HTTP request pipeline.
var app = builder.Build();
app.UseCors("Cors");
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthentication();
//app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
