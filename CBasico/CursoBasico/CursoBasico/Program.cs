using CursoBasico.Asincrona;
using CursoBasico.POO_04.Enumerados;

public class Program
{  
    private static async Task Main(string[] args)
    {
        try
        {
            Console.Out.WriteLineAsync("Inicializamos el programa");

            AsyncWithErrorClass1 asy = new AsyncWithErrorClass1();

            await asy.callMethodTry();

        }
        catch (Exception ex) 
        {
            await Console.Out.WriteLineAsync($"El error es este hdp: {ex.Message}");
        }
        finally 
        {
            Console.Out.WriteLineAsync("Finaliza el programa:");
        }


    }
}