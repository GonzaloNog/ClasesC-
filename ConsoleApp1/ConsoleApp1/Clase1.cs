using System; //Librerias de sistema 

namespace MyApp // Nombre de la calse de using para no llamar en cada linea
{
    internal class Clase1
    {
        static void Main(string[] args)//Main funcion reservada es el codigo que se ejecuta 
        {
            Console.WriteLine("Hello World!"); //Imprime una linea en consola
                                               //Console.WriteLine(23); //Diferencia numero de texto con ""

            int a = 1;
            int b = 2;

            int resultado = a + b;
            Console.WriteLine(resultado);
            float flo = 1.0f; //Numero con decimales hasta 9 decimales
            double c = 1.0f; // Igual que el float pero con 16 decimales
            bool d = false; //solo dos resultados Verdadero y Falso 
            string e = "HOLA"; //String es una cadena de texto
            char f = 'a';

            //If 

            if (a > b)
            {
                Console.WriteLine("Entro en el if");
                if (2> 1)
                {
                    Console.WriteLine("Entro en el if");
                    if (3 > 2)
                    {

                    }
                    else
                    {

                    }
                }
            }
            else
            {
                Console.WriteLine("No entro en el if");
            }



            if (1 > 2 && 2 > 3 && 4>6) // && es igual que "y"
            {

            }

            if(1 > 2 || 1 > 4){ // || es igual a or
                Console.WriteLine("No entro en el if");
            }
            else if (3 > 2)
            {

            }
            else
            {

            }

            // Comentarios

            /*
             Comentario Largo
                1
                2
                3
            */
        }

    }
}