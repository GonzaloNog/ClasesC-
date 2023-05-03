using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
/*      
        hay que matar dos veces a los enemigos. Cuando su vida baja a 0 hay que usar un comando extra para salir de el loop de combate.
        lista solo se puede usar una vez por combate
        ganar un combate sube demasiados niveles
*/
namespace MyApp
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
            int expChange = 0;
            int lvl = 0;
            int dañoOut = 0;
            int dañoIn = 0;
            //nivel
            int cuarto = 1;
            int mirarCuarto = -1;
            int deficultad = 0;
            //int objActual

            int indexRaza = 0;
            string[] clase = new string[] { "Mago", "Luchador", "Elfo", "Enano" };
            string[] enemigos = new string[] { "duende", "elfoOscuro", "minotauro", "gargola" };
            string[] eventos = new string[] { "Te encuentras una caja queres ver el contenido Y/N", "una serpiente sale de la caja y te lastima -10 de vida", "encontraste un libro de experiencia + 15exp", "Te encontrás con un cuadro enorme, al acercarte ves que detrás hay una palanca. ¿Tirás de ella? [Y/N]", "Al bajar la palanca se abre una puerta secreta detrás tuyo. ¡Hay un enemigo!", "Al bajar la palanca se abre una puerta secreta detrás tuyo. ¡Hay un pollo rostizado! Al comerlo recuperas toda tu vida." };
            //                                 X           X  estos ceros no se que hacen
            int[] resultados = new int[] {/*1*/0, -10, 15, 0, /*2*/0, vidaMax, 0, 0, /*3*/0, 0, 0, 0 };

            //System.Threading.Thread.Sleep(5000);
            Bienvenida(ref nombre);
            RegistroClase(ref indexRaza, ref clase, ref vidaAct, ref vidaMax);
            Estadisticas(ref clase[indexRaza], ref fuerza, ref inteligencia, ref vidaMax, ref vidaAct);
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
                        Mirar(ref vidaAct, ref vidaMax, ref expAct, ref expNecesaria, ref lvl, ref eventos, ref resultados, ref game);
                        break;
                    case "avanzar":
                        Avanzar(ref cuarto);
                        Random eve = new Random();
                        int eveInt = eve.Next(0, deficultad);
                        if (eveInt == 0)
                        {
                            Encuentro(ref enemigos, ref vidaAct, ref fuerza, ref inteligencia, ref dañoOut, ref dañoIn, ref vidaMax, ref expChange, ref game, ref expAct, ref lvl, ref expNecesaria);
                        }
                        break;
                    case "estado":
                        VerEstadisticas(ref nombre, ref fuerza, ref inteligencia, ref vidaMax, ref vidaAct, ref expNecesaria, ref expAct, ref lvl, ref clase, ref indexRaza, ref cuarto);
                        break;
                    case "ataque":
                        //Ataque();
                        break;
                    case "ataqueMag":
                        //AtaqueMag();
                        break;
                    default:
                        Console.WriteLine("Comando no encontrado");
                        break;
                }
                if (cuarto == 10)
                {
                    Victoria();
                    game = false;
                }
            }
            /*if (vidaAct == 0)
            {
                Console.WriteLine("GameOver");
            }*/
            //GanarExp(ref expAct, ref lvl, ref expNecesaria);
        }
        //
        static void Victoria()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Lleguaste al décimo cuarto y ganaste");
            Console.ForegroundColor = ConsoleColor.White;
        }
        static void Muerte(ref bool game)
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Has muerto");
            Console.ForegroundColor = ConsoleColor.White;
            game = false;

        }
        static void ComandosList()
        {
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Lista de comandos:");
            Console.WriteLine("         - quit: Salir del juego");
            Console.WriteLine("         - estadisticas: muestra todas las estadisticas");
            Console.WriteLine("         - mirar: mira la habitacion");
            Console.WriteLine("         - avanzar: cambia de sala");
            Console.WriteLine("         - estado: muestra las estadisticas");
            Console.WriteLine("         - ataque: ataque físico");
            Console.WriteLine("         - ataqueMag: ataque mágico");
            Console.WriteLine("");


        }
        static void ComandosComb(ref bool listaUsado)
        {
            Console.WriteLine("");
            Console.WriteLine("         - estado: muestra las estadisticas");
            Console.WriteLine("         - ataque: ataque físico");
            Console.WriteLine("         - ataqueMag: ataque mágico");
            Console.WriteLine("");
            listaUsado = true;
        }
        static void VerEstadisticas(ref string nombre, ref float fuerza, ref float inteligencia, ref int vidaMax, ref int vidaAct, ref int expNecesaria, ref int expAct, ref int lvl, ref string[] clase, ref int indexRaza, ref int cuarto)
        {
            Console.Clear();
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
            Console.Clear();
            Console.WriteLine("");
            Console.WriteLine("Avanzas al siguiente cuarto");
            cuarto++;

            Console.WriteLine("");
        }

        static void Mirar(ref int vidaAct, ref int vidaMax, ref int expAct, ref int expNecesaria, ref int lvl, ref string[] eventos, ref int[] resultados, ref bool game)
        {
            //no entiendo como funciona este código
            Random eve = new Random();
            int eveInt = eve.Next(0, eventos.Length / 3);
            int actualEvent = eveInt * 3;
            int indexRe = 0;
            if (eveInt > 0)
                indexRe = 4 * eveInt;
            //

            bool subMenu = true;

            while (subMenu == true)
            {
                string com;
                Console.WriteLine(eventos[actualEvent] + "\n");
                com = Console.ReadLine();
                if (com == "Y" || com == "y" || com == "N" || com == "n")
                {
                    Random ev = new Random();
                    int resIndex = ev.Next(0, 1);
                    if (resIndex == 0)
                    {
                        Console.WriteLine(eventos[actualEvent + 1]);
                        Eventos(ref vidaAct, ref vidaMax, ref expAct, ref expNecesaria, ref lvl, resultados[indexRe], resultados[indexRe + 1], actualEvent, eventos, ref game);
                        subMenu = false;
                    }
                    else
                    {
                        Console.WriteLine(eventos[actualEvent + 2]);
                        Eventos(ref vidaAct, ref vidaMax, ref expAct, ref expNecesaria, ref lvl, resultados[indexRe + 2], resultados[indexRe + 3], actualEvent, eventos, ref game);
                        subMenu = false;
                    }
                }
                else
                    Console.WriteLine("Error: ingrese Y/N");
            }

        }
        static void Eventos(ref int vidaAct, ref int vidaMax, ref int expAct, ref int expNecesaria, ref int lvl, int expChange, int vidaChange, int actualEvent, string[] eventos, ref bool game)
        {
            if (expChange > 0)
            {
                GanarExp(ref expAct, ref lvl, ref expNecesaria, expChange);
            }
            if (vidaChange > 0)
            {
                GanarVida(ref vidaMax, ref vidaAct, vidaChange, ref game);
            }
        }
        static void GanarVida(ref int vidaMax, ref int vidaAct, int vidaChange, ref bool game)
        {
            if (vidaChange > 0)
            {
                vidaAct += vidaChange;
                if (vidaAct > vidaMax)
                    vidaAct = vidaMax;
            }
            else if (vidaChange < 0)
            {
                vidaChange = vidaChange * -1;
                vidaAct -= vidaChange;
                if (vidaAct < 0)
                    vidaAct = 0;
            }
            if (vidaAct < 0)
            {
                Muerte(ref game);
            }
            Console.WriteLine("vidaChange" + vidaChange);

        }
        static void GanarExp(ref int expAct, ref int lvl, ref int expNecesaria, int expChange)
        {
            expAct += expChange;

            if (expAct >= expNecesaria)
            {
                Console.WriteLine("");
                Console.WriteLine("Nuevo Nivel");
                Console.WriteLine("");
                expAct = expAct - expNecesaria;
                lvl++;
                expNecesaria = expNecesaria + 200;
            }
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
        static void RegistroClase(ref int indexRaza, ref string[] clase, ref int vidaAct, ref int vidaMax)

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
        static void Encuentro(ref string[] enemigos, ref int vidaAct, ref float fuerza, ref float inteligencia, ref int dañoOut, ref int dañoIn, ref int vidaMax, ref int expChange, ref bool game, ref int expAct, ref int lvl, ref int expNecesaria)
        {
            int vidaEnemigo = 0;
            float fuerzaEnem = 0;
            float inteligenciaEnem = 0;
            int exp = 0;
            bool enemigoVivo = true;
            Random ev = new Random();
            int resIndex = ev.Next(0, enemigos.Length);
            switch (enemigos[resIndex])
            {
                case "duende":
                    vidaEnemigo = 100;
                    fuerzaEnem = 25;
                    inteligenciaEnem = 20;
                    exp = 50;
                    break;
                case "elfoOscuro":
                    vidaEnemigo = 200;
                    fuerzaEnem = 50;
                    inteligenciaEnem = 100;
                    exp = 100;
                    break;
                case "minotauro":
                    vidaEnemigo = 300;
                    fuerzaEnem = 75;
                    inteligenciaEnem = 50;
                    exp = 150;
                    break;
                case "gargola":
                    vidaEnemigo = 400;
                    fuerzaEnem = 100;
                    inteligenciaEnem = 0;
                    exp = 200;
                    break;
            }
            Console.WriteLine("¡Te encontrás con " + enemigos[resIndex] + "!");
            int turnoJug = 0;
            int turnoEne = 0;
            //borré                    || vidaAct >= 0) porque no se cerraba el loop al matar un enemigo
            while (enemigoVivo == true)
            {
                bool listaUsado = false;
                if (vidaEnemigo <= 0)
                {
                    Console.WriteLine("Has derrotado al enemigo");
                    enemigoVivo = false;
                }

                Console.WriteLine("¿Qué haces?");
                string comandEnc = Console.ReadLine();
                switch (comandEnc)
                {
                    case "ataque":
                        Ataque(ref fuerza, ref vidaEnemigo, ref dañoOut, ref expAct, ref exp, ref lvl, ref expNecesaria);
                        Console.WriteLine(enemigos[resIndex] + " recibe " + dañoOut + " de daño");
                        Console.WriteLine("turnoEne: " + turnoEne);
                        Console.WriteLine("turnoJug: " + turnoJug);
                        Console.WriteLine("vidaAct: " + vidaAct);
                        Console.WriteLine("vidaEnemigo: " + vidaEnemigo);
                        turnoJug++;
                        break;
                    case "ataqueMag":
                        vidaEnemigo = vidaEnemigo - AtaqueMag(inteligencia);
                        Console.WriteLine(enemigos[resIndex] + " recibe " + dañoOut + " de daño mágico");
                        turnoJug++;
                        break;
                    case "lista":

                        if (listaUsado = false)
                        {
                            ComandosComb(ref listaUsado);
                        }
                        break;
                    default:
                        Console.WriteLine("Por favor usa un comando válido");
                        break;
                }

                if (turnoEne < turnoJug)
                {
                    AtaqueEnem(ref fuerzaEnem, ref inteligenciaEnem, ref vidaAct, ref dañoIn, ref vidaMax, ref exp, ref game);
                    Console.WriteLine(enemigos[resIndex] + " hace " + dañoIn + " de daño");
                    turnoEne++;
                }
            }
        }
        static void Ataque(ref float fuerza, ref int vidaEnemigo, ref int dañoOut, ref int expAct, ref int exp, ref int lvl, ref int expNecesaria)
        {
            Random abc = new Random();
            int dados = abc.Next(0, 6);
            if (dados > 0)
            {
                float dañof = fuerza / dados;
                dañoOut = Convert.ToInt32(dañof);
            }
            else if (dados == 0)
            {
                dañoOut = 0;
            }
            vidaEnemigo -= dañoOut;
            if (vidaEnemigo < 0) ;
            {
                GanarExp(ref expAct, ref lvl, ref expNecesaria, exp);
            }
        }
        static int AtaqueMag(float inteligencia)
        {
            int dañoOut = 0;
            Random abc = new Random();
            int dados = abc.Next(0, 6);
            if (dados > 0)
            {
                float dañof = inteligencia / dados;
                dañoOut = Convert.ToInt32(dañof);
            }
            else if (dados == 0)
            {
                dañoOut = 0;
            }
            //vidaEnemigo -= dañoOut;
            return dañoOut;
        }
        static void AtaqueEnem(ref float fuerzaEnem, ref float inteligenciaEnem, ref int vidaAct, ref int dañoIn, ref int vidaMax, ref int exp, ref bool game)
        {
            Random abc = new Random();
            int dados = abc.Next(0, 6);
            Random ataqR = new Random();
            int ataque = ataqR.Next(0, 1);
            switch (ataque)
            {
                case 0://magico
                    if (dados > 0)
                    {
                        float dañof = inteligenciaEnem / dados;
                        dañoIn = Convert.ToInt32(dañof);
                    }
                    else if (dados == 0)
                    {
                        dañoIn = 0;
                    }
                    break;
                case 1://fisico
                    if (dados > 0)
                    {
                        float dañof = fuerzaEnem / dados;
                        dañoIn = Convert.ToInt32(dañof);
                    }
                    else if (dados == 0)
                    {
                        dañoIn = 0;
                    }
                    break;
            }
            dañoIn = dañoIn * -1;
            GanarVida(ref vidaMax, ref vidaAct, dañoIn, ref game);
        }
        static void Estadisticas(ref string clase, ref float fuerza, ref float inteligencia, ref int vidaMax, ref int vidaActual)
        {
            switch (clase)
            {
                case "Mago":
                    vidaMax = 300;
                    fuerza = 20;
                    inteligencia = 100;
                    break;
                case "Luchador":
                    vidaMax = 500;
                    fuerza = 100;
                    inteligencia = 20;
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
            vidaActual = vidaMax;
            Console.WriteLine("");
            Console.WriteLine("Vida: " + vidaMax);
            Console.WriteLine("Fuerza: " + fuerza);
            Console.WriteLine("Inteligencia: " + inteligencia);
            Console.WriteLine("");
        }
    }
}