using System;

namespace MyApp // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            bool game = true;
            string nombre = "Aventurero";
            string comando = "null";
            float fuerza = 0;
            float inteligencia = 0;
            int vidaMax = 0;
            int vidaAct = 0;
            int expNecesaria = 200;
            int expAct = 0;
            int lvl = 0;
            int expSobrante = 0;


            int indexRaza = 0;
            string[] clase = new string[] { "Mago", "Luchador", "Elfo", "Enano" };
            string[] eventos = new string[] {"Poder distinguir","se encuentra"};
            string[] objetos = new string[] {"caja", "un cuadro", "mesa" };

            Bienvenida(ref nombre);
            RegistroClase(ref indexRaza, ref clase);
            Estadisticas(ref clase[indexRaza], ref fuerza, ref inteligencia, ref vidaMax);

            /*
            Random r = new Random();
            int rInt = r.Next(0, objetos.Length - 1);
            Console.WriteLine(rInt);*/


            Console.WriteLine("exp actual: " + expAct);
            Console.WriteLine("nivel: " + lvl);
            Console.WriteLine("exp necesaria: " + expNecesaria);
            Console.WriteLine("");

            while (game)
            {
                Console.WriteLine("Ingrese un comando(lista: para ver los comandos): ");
                comando = Console.ReadLine();
                switch (comando)
                {
                    case "quit" or "Quit":
                        game = false;
                        break;
                    case "lista":
                        ComandosList();
                        break;
                    case "mirar":
                        break;
                    case "avanzar":
                        break;
                    default:
                        Console.WriteLine("Comando no encontrado");
                        break;
                }
            }

            //GanarExp(ref expAct, ref lvl, ref expNecesaria, 250);
        }
        //

        static void ComandosList()
        {
            Console.WriteLine("Lista de comandos:");
            Console.WriteLine("         - quit: Salir del juego");
            Console.WriteLine("         - estadisticas: muestra todas las estadisticas");
            Console.WriteLine("         - mirar: mira la habitacion");
            Console.WriteLine("         - avanzar: cambia de sala");
        }
        static void GanarExp(ref int expAct, ref int lvl, ref int expNecesaria, int exp)
        {
            expAct += exp;

            if(expAct >= expNecesaria)
            {
                Console.WriteLine("Nuevo Nivel");
                expAct = expAct - expNecesaria;
                lvl++;
                expNecesaria = expNecesaria + 200;
            }
            
            Console.WriteLine("exp actual: " + expAct);
            Console.WriteLine("nivel: " + lvl);
            Console.WriteLine("exp necesaria: " + expNecesaria);
            Console.WriteLine("");
        }
       

        static void Bienvenida(ref string nombre)
        {
            Console.WriteLine("Hola, " + nombre);
            Console.WriteLine("¿Como te llamas?");
            nombre = Console.ReadLine();
            Console.WriteLine("Encantado de conocerte, " + nombre);
            Console.WriteLine("");
        }
        static void RegistroClase(ref int indexRaza, ref string[] clase)

        {
            Console.WriteLine("¿Cual es tu clase?");

            for (int c = 0; c < clase.Length; c++)
                Console.WriteLine((c + 1) + "-" + clase[c]);

            int a = Convert.ToInt32(Console.ReadLine());

            if (a > 0 && a <= clase.Length)
                indexRaza = a - 1;
            else
                Console.WriteLine("El numero ingresado no esta en el area contemplada");

            //esto escribe una letra de "Mago" dependiendo de la clase que se elige
            Console.WriteLine("Elegiste: " + clase[indexRaza]);
            Console.WriteLine("");
        }

        static void Estadisticas(ref string clase, ref float fuerza, ref float inteligencia, ref int vidaMax)
        {
            switch (clase)
            {
                case "Mago":
                    vidaMax = 300;
                    fuerza = 10;
                    inteligencia = 100;
                    break;
                case "Luchador":
                    vidaMax = 500;
                    fuerza = 100;
                    inteligencia = 10;
                    break;
                case "Elfo":
                    vidaMax = 200;
                    fuerza = 80;
                    inteligencia = 80;
                    break;
                case "Enano":
                    vidaMax = 550;
                    fuerza = 150;
                    inteligencia = 0;
                    break;

            }
            Console.WriteLine("");
            Console.WriteLine("Vida: " + vidaMax);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Inteligencia: " + inteligencia);
            Console.WriteLine("");
        }
    }
}
