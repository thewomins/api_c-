using prueba2.Controllers;
using prueba2.Models;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options => options.AddPolicy("MyPolicy", builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        }));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("MyPolicy");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

TokenController tkc= new TokenController ();
UsuarioController uc= new UsuarioController ();
JuegoController jc = new JuegoController ();
NoticiasController nc = new NoticiasController ();

app.MapPost("/login",(Usuario usuario)=>{
    string respuesta= uc.login(usuario);
    if(respuesta.Equals(string.Empty)){
        System.Console.WriteLine(usuario.user);
        return Results.NotFound();//404
    }
    return Results.Ok(respuesta);//200
});

app.MapGet("/juegos",(HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.getAllGames());
    }
    return Results.NotFound();
});

app.MapPost("/juegos/post",(Juegos juego,HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.crearJuego(juego));
    }
    return Results.NotFound();
});

app.MapDelete("/juegos/delete",(int id,HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.eliminarGameId(id));//200
    }
    return Results.NotFound();
});

app.MapPut("/juegos/put",(Juegos juego,HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.editarGame(juego));//200
    }
    return Results.NotFound();
});

app.MapGet("/juegos-",(Char caracter, HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.mostrarPorLetra(caracter));
    }
    return Results.NotFound();
});

app.MapGet("/juegos/date",(HttpRequest request)=>{
    Boolean respuesta= tkc.verificaHeaders(request);
    if(respuesta){
       return Results.Ok(jc.anio1999to2020());
    }
    return Results.NotFound();
});


//noticias

app.MapPost("/noticias/post",(Noticias noticia)=>{
    return Results.Ok(nc.crearNoticia(noticia));//200
});

app.MapPost("/noticias/post-",(int id,string comentario)=>{
    return Results.Ok(nc.anadirComentario(id,comentario));//200
});

app.MapGet("/noticias-",(int id)=>{
    return Results.Ok(nc.getNoticiasId(id));//200
});

app.MapGet("/noticias",()=>{
    return Results.Ok(nc.mostrarNoticias());//200
});


app.Run();
