using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Polimorfismo
{
    public abstract class Animal
    {
        //Polimorfismo es llamar a la misma funcion en diferentes clases
        public abstract void HacerRuido();


        //Gato cat = new Gato();
        //cat.HacerRuido();

        //Perro dog = new Perro();
        //dog.HacerRuido();

        ////Gracias al polimorfismo podemos asignar diferentes clases a una lista en comun
        //List<Animal> animals = new List<Animal>();
        //animals.Add(dog);
        //animals.Add(cat);

        //foreach (Animal animal in animals)
        //{
        //    //TGracias al polimorfismo podemos utilizar este metodo en todos ellos 
        //    //Sin embargo no pueden hacer o disponer de la altura del gato porque no comparte esa inf en la clase base
        //    animal.HacerRuido();
            
        //}

}
}
