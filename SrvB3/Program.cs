
using B3.DATA.Interface;
using B3.DATA.Service;

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
                .AllowAnyHeader()
                .SetIsOriginAllowedToAllowWildcardSubdomains();
                      });
});
builder.Services.AddSingleton<IB3Service, B3Service>();


// Add services to the container.

//builder.Services.AddHttpClient("ListarB3", client =>
//{
//    //o finao da URI eh um base64 com 10k de pageSize (caso ultrapasse 10k de fiis na bolsa, deve-se alterar o base64)
//    client.BaseAddress = new Uri("https://sistemaswebb3-listados.b3.com.br/");
//    //client.DefaultRequestHeaders.Add("Accept", "application/json");
//}
//);
builder.Services.AddHttpClient();


//.AddTransientHttpErrorPolicy(policyBuilder => policyBuilder.WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 3)));   //jeito mais simples de fazer (faz 30 tentativas, 1 apos cada 5seg)
//.AddPolicyHandler(Policy<HttpResponseMessage>.Handle<HttpRequestException>()
//            .OrResult(x => x.StatusCode >= System.Net.HttpStatusCode.InternalServerError || x.StatusCode == System.Net.HttpStatusCode.RequestTimeout)
//            .WaitAndRetryAsync(Backoff.DecorrelatedJitterBackoffV2(TimeSpan.FromSeconds(1), 5)));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMemoryCache();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{

    app.UseDeveloperExceptionPage();
    app.UseSwaggerUI();
    app.UseSwagger(x => x.SerializeAsV2 = true);
}

app.Use(async (context, next) =>
{
    context.Request.EnableBuffering();
    await next();
});

//app.UseHttpsRedirection();
app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.Run();
