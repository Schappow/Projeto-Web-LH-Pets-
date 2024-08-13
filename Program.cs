namespace SENAI;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        var app = builder.Build();

        app.MapGet("/", () => "SENAI");
        
        app.UseStaticFiles(); 
        app.MapGet ("/index", (HttpContext contexto)=> {
                contexto.Response.Redirect("index.html", false);
       
        });

        Banco dba=new Banco();
        app.MapGet("/ListaClientes" , (HttpContext contexto) => {
        
            contexto.Response.WriteAsync( dba.GetListaString());    
         });

        app.Run();
    }
}
