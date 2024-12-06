using CursoBasico.Asincrona;
using CursoBasico.POO_04.Enumerados;

public class Program
{  
    private static async Task Main(string[] args)
    {

        Console.Out.WriteLineAsync("Inicializamos el programa");

        SecondExcerAsync excerc = new SecondExcerAsync();

        var task01 = excerc.PrintFirstText();

        var task02 = excerc.PrintSecondText();

        var results = await Task.WhenAll(task01, task02);

        Console.Out.WriteLineAsync($"Resultado 1: {results[0]}");
        Console.Out.WriteLineAsync($"Resultado 2: {results[1]}");

        await Console.Out.WriteLineAsync("Todas las tareas completadas");

    }
}