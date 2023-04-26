using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;

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

            //nivel
            int cuarto = 0;
            int mirarCuarto = -1;
            //int objActual

            int indexRaza = 0;
            //entiendo que la mayoría de arrays se pueden poner en su respectiva funcion
            string[] clase = new string[] { "Mago", "Luchador", "Elfo", "Enano" }; ;
            string[] eventos = new string[] { "Te encuentras una caja queres ver el contenido Y/N", "una serpiente sale de la caja y te lastima -10 de vida", "encontraste un libro de experiencia + 15exp" };
            int[] resultados = new int[] { 0, -10, 15, 0 };


            Bienvenida(ref nombre);
            RegistroClase(ref indexRaza, ref clase);
            Estadisticas(ref clase[indexRaza], ref fuerza, ref inteligencia, ref vidaMax);
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
                        //Mirar(ref objetos, ref vidaAct, ref expAct, ref vidaMax,);
                        break;
                    case "avanzar":
                        Avanzar(ref cuarto);
                        break;
                    case "estado":
                        VerEstadisticas(ref nombre, ref fuerza, ref inteligencia, ref vidaMax, ref vidaAct, ref expNecesaria, ref expAct, ref lvl, ref clase, ref indexRaza, ref cuarto);
                        break;
                    default:
                        Console.WriteLine("Comando no encontrado");
                        break;
                }
            }
            if (vidaAct == 0)
            {
                Console.WriteLine("GameOver");
            }
            //GanarExp(ref expAct, ref lvl, ref expNecesaria);
        }
        //
        static void VerEstadisticas(ref string nombre, ref float fuerza, ref float inteligencia, ref int vidaMax, ref int vidaAct, ref int expNecesaria, ref int expAct, ref int lvl, ref string[] clase, ref int indexRaza, ref int cuarto)
        {
            Console.WriteLine("");
            Console.WriteLine("Nombre: " + nombre);
            Console.WriteLine("Clase: " + clase[indexRaza]);
            Console.WriteLine("Vida: " + vidaAct + "/" + vidaMax);
            Console.WriteLine("Experiencia: " + expAct + "/" + expNecesaria);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Inteligencia: " + inteligencia);
            Console.WriteLine("Nivel " + lvl);
            Console.WriteLine("");
        }
        static void Avanzar(ref int cuarto)
        {
            Console.WriteLine("");
            Console.WriteLine("Avanzas al siguiente cuarto");
            cuarto++;

            Console.WriteLine("");
        }
        static void Mirar(ref int vidaAct, ref int vidaMax, ref int expAct, ref int expNecesaria, ref int lvl, ref string[] eventos, ref int[] resultados)
        {
            Random eve = new Random();
            //el -1 al final hacía que no funcione el codigo
            int objInt = eve.Next(0, eventos.Length / 3);
            int actualEvent = objInt * 3;
            int indexRe = 0;
            if (objInt > 0)
                indexRe = 4 * objInt;

            bool subMenu = true;

            while (subMenu == true)
            {
                string com;
                Console.WriteLine(eventos[actualEvent] + "\n");
                com = Console.ReadLine();
                if (com == "Y")
                {
                    Console.WriteLine(eventos[actualEvent + 1]);
                    Eventos(ref vidaAct, ref vidaMax, ref expAct, ref expNecesaria, ref lvl, resultados[indexRe], resultados[indexRe + 1]);
                    subMenu = false;
                }
                else if (com == "N")
                {
                    Console.WriteLine(eventos[actualEvent + 2]);
                    Eventos(ref vidaAct, ref vidaMax, ref expAct, ref expNecesaria, ref lvl, resultados[indexRe + 2], resultados[indexRe + 3]);
                    subMenu = false;
                }
                else
                    Console.WriteLine("Error: ingrese Y/N");

            }

        }
        static void Eventos(ref int vidaAct, ref int vidaMax, ref int expAct, ref int expNecesaria, ref int lvl, int expChange, int vidaChange)
        {
            if (expChange > 0)
            {
                GanarExp(ref expAct, ref lvl, ref expNecesaria, expChange);
            }
            if (vidaChange > 0)
            {

            }
        }
        static void ComandosList()
        {
            Console.WriteLine("");
            Console.WriteLine("Lista de comandos:");
            Console.WriteLine("         - quit: Salir del juego");
            Console.WriteLine("         - estadisticas: muestra todas las estadisticas");
            Console.WriteLine("         - mirar: mira la habitacion");
            Console.WriteLine("         - avanzar: cambia de sala");
            Console.WriteLine("         - estado: muestra las estadisticas");
            Console.WriteLine("");

        }
        static void GanarExp(ref int expAct, ref int lvl, ref int expNecesaria, int exp)
        {
            expAct += exp;

            if (expAct >= expNecesaria)
            {
                Console.WriteLine("");
                Console.WriteLine("Nuevo Nivel");
                Console.WriteLine("");
                expAct = expAct - expNecesaria;
                lvl++;
                expNecesaria = expNecesaria + 200;
            }
            /*
            Console.WriteLine("exp actual: " + expAct);
            Console.WriteLine("nivel: " + lvl);
            Console.WriteLine("exp necesaria: " + expNecesaria);
            Console.WriteLine("");
            */
        }


        static void Bienvenida(ref string nombre)
        {
            Console.WriteLine("");
            Console.WriteLine("Hola, " + nombre);
            Console.WriteLine("");
            Console.WriteLine("¿Como te llamas?");
            Console.WriteLine("");
            nombre = Console.ReadLine();
            Console.WriteLine("");
            Console.WriteLine("Encantado de conocerte, " + nombre);
            Console.WriteLine("");
        }
        static void RegistroClase(ref int indexRaza, ref string[] clase)

        {
            Console.WriteLine("");
            Console.WriteLine("¿Cual es tu clase?");


            for (int c = 0; c < clase.Length; c++)
                Console.WriteLine((c + 1) + "-" + clase[c]);

            int a = Convert.ToInt32(Console.ReadLine());

            if (a > 0 && a <= clase.Length)
                indexRaza = a - 1;
            else
                Console.WriteLine("El numero ingresado no esta en el area contemplada");

            Console.WriteLine("");
            Console.WriteLine("Elegiste: " + clase[indexRaza]);
            Console.WriteLine("");
        }
        static void Encuentro(ref string enemigos)
        {
            switch (enemigos)
            {
                case "esqueleto":
                    break;
                case "no muerto":
                    break;
                case "rata":
                    break;
            }
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