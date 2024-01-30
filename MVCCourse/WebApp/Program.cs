//var builder = WebApplication.CreateBuilder(args);

//// Add services to the container.
//builder.Services.AddRazorPages();

//var app = builder.Build();

//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}

//app.UseHttpsRedirection();
//app.UseStaticFiles();

//app.UseRouting();

//app.UseAuthorization();

//app.MapRazorPages();

//app.Run();
using Microsoft.AspNetCore.Components.Forms;
using System.Net.Mime;
using System.Reflection.Emit;
using System.Text;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", (HttpContext context) => {
    WriteHtml(context, $@"
<!doctype html>
<html>
<head><title>miniHTML</title></head>
<body>
<h1>Simple Framework</h1>
</br>
<form action=""/login" method=""post"">
<label for="username">username:</label>
<input type=""text"" id=""username"" name=""username"" required>
<label for=""password"">Password:</label>
<input type=""password"" id=""password"" name=""password"" required>
<button type=""submit"">Login</button>
</form>
</body>
</html>");
});

app.MapPost("/login", (HttpContext context) =>
{
    var username = context.Request.Form["username"];
    var password = context.Request.Form["password"];

    if (username == "frank" && password == "password")
    {
        var html = @$"
<!doctype html>
<html>
<head><title>miniHTML</title></head>
<body>
<h1>Simple Framework</h1>
</br>
Welcome to our simple framework!
</body>
</html>";
        WriteHtml(context, html);
    }
    else
    {
        var html = @$"
<!doctype html>
<html>
<head><title>miniHTML</title></head>
<body>
<h1>Simple Framework</h1>
<br/>
<form action=""/login"" method=""post"">
<label for=""username"">Username:</label>
<input type=""text"" id=""username"" name=""username"" required>
<label for=""password"">Password:</label>
<input type=""password"" id=""password"" name=""password"" required>
<button type=""submit"">Login</button>
<br/>
<label style=""color:red"">Login failed!</label>
</form>
</body>
</html>";
        WriteHtml(context, html);
    }
}
);


app.Run();

void WriteHtml(HttpContext context, string html)
{
    context.Response.ContentType = MediaTypeNames.Text.Html;
    context.Response.ContentLength = Encoding.UTF8.GetByteCount(html);
    context.Response.WriteAsync(html);
}