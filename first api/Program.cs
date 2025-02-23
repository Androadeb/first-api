using first_api.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// السماح لجميع المصادر باستخدام CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

// إعداد قاعدة البيانات باستخدام SQL Server
builder.Services.AddDbContext<AppDpContext>(op =>
      op.UseSqlServer(builder.Configuration.GetConnectionString("MyConnection")));

builder.Services.AddControllers().AddJsonOptions(configure => configure.Equals(true));

// إعداد Swagger لتوثيق API
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// تشغيل Swagger في بيئة التطوير فقط
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ❌ **إزالة إعادة التوجيه لـ HTTPS**
// (Render يوفر HTTPS تلقائيًا، لذا لا حاجة لإجبار التطبيق عليه)

// ✅ تفعيل CORS والسماح بالوصول إلى الـ API
app.UseCors("AllowAll");
app.UseAuthorization();
app.MapControllers();

// ✅ **تحديد المنفذ من متغير البيئة (خاص بـ Render)**
var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
app.Urls.Add($"http://0.0.0.0:{port}");

app.Run();
