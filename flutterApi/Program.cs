
using flutterApi.Helpers;
using flutterApi.Interfaces;
using flutterApi.Models;
using flutterApi.Services;
using login.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Server.Kestrel.Core;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Microsoft.Extensions.FileProviders;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json.Converters;
using ProductMiniApi.Repository.Abastract;
using ProductMiniApi.Repository.Implementation;
using System.Configuration;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddDbContext<ApplicationDBContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefultconnectionString")),ServiceLifetime.Transient);
builder.Services.AddSwaggerGen();
builder.Services.Configure<JWT>(builder.Configuration.GetSection("JWT"));
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
                .AddJwtBearer(o =>
                {
                    o.RequireHttpsMetadata = false;
                    o.SaveToken = false;
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidIssuer = builder.Configuration["JWT:Issuer"],
                        ValidAudience =builder.Configuration["JWT:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"])),
                          ClockSkew = TimeSpan.Zero
                    };
                });
builder.Services.Configure<IISServerOptions>(options =>
{
    options.MaxRequestBodySize = int.MaxValue;
});

builder.Services.Configure<KestrelServerOptions>(options =>
{
    options.Limits.MaxRequestBodySize = int.MaxValue; // if don't set default value is: 30 MB
});
builder.Services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<ApplicationDBContext>()
   
  .AddDefaultTokenProviders();

builder.Services.Configure<TwilioSettings>(builder.Configuration.GetSection("Twilio"));
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        policy.AllowAnyHeader()
              .AllowAnyMethod()
              .AllowAnyOrigin();
    });
});

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ICarService,CarService>();
//builder.Services.AddScoped<IAccidentService, AccidentService>();   

builder.Services.AddScoped<ICompanyService, CompanyService>();
builder.Services.AddScoped<ICompanyBenfitsService, CompanyBenfitsService>();
builder.Services.AddScoped<ICompanyInfoService, CompanyInfoService>();
builder.Services.AddScoped<IPolicyService, PolicyService>();

builder.Services.AddScoped<IAccidentService, AccidentService>();



builder.Services.AddScoped< ICarModelService,CarModelService>();
builder.Services.AddScoped<ICarInfoService, CarInfoService>();
builder.Services.AddScoped<ITestFileService, TestFileService>();
builder.Services.AddScoped<IImageAccidentDBService, ImageAccidentDBService>();
builder.Services.AddScoped<IPersonalImagesUrlService, PersonalImagesUrlService>();
builder.Services.AddScoped<IPersonalImagedbService,PersonalImageDbService>();
builder.Services.AddScoped<IPreviewerReportService,PreviewerReportService>();
builder .Services.AddScoped<IReportImageDBService, ReportImageDBService>();
builder.Services.AddScoped<IInsuranceRequestService,InsuranceRequestService>();
builder.Services.AddScoped<IInsuranceService, InsuranceService>();
builder.Services.AddScoped<IMedicalCompanyService, MedicalCompanyService>();
builder.Services.AddScoped<ICompanyHealthInsuranceTypesService, CompanyHealthInsuranceTypesService>();
builder.Services.AddScoped<IPlaceOfTreatmentService, PlaceOfTreatmentService>();
builder.Services.AddScoped<IPlaceOfTreatmentDetailsService, PlaceOfTreatmentDetailsService>();
builder.Services.AddScoped<IAgeLimitesService, AgeLimitesService>();
builder.Services.AddScoped<ImedicalInsurancePricesService, medicalInsurancePricesService>();

//builder.Services.AddScoped<IBaseRepository<T>,BaseRepository>();
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.Converters.Add(new StringEnumConverter());
    }


    );
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();
/*app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(Directory.GetCurrentDirectory(),"Uploads")),
    RequestPath = "/Uploads"
});*/
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(Path.Combine(Directory.GetCurrentDirectory(), "Assets")),
    RequestPath = "/Assets"

}) ;
app.UseAuthentication();
app.UseCors("CorsPolicy");

app.UseAuthorization();


app.MapControllers();

app.Run();
