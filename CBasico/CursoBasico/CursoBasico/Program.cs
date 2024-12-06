using CursoBasico.Asincrona;
using CursoBasico.POO_04.Enumerados;

public class Program
{  
    private static void Main(string[] args)
    {     
        PrintMessageAsync print = new PrintMessageAsync();
        print.asyncCall();
    }
}