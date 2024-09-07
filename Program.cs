var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", (minimal_api.Dominio.DTO.LoginDTO loginDTO) =>  {
    if(loginDTO.Email == "adm@teste.com" && loginDTO.Senha == "123456")
    {
        return Results.Ok("Login bem sucedido!");
    }
    else{
        return Results.Unauthorized();
    }
});

app.Run();


