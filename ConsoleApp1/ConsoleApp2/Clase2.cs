using System;

namespace MyApp 
{
    internal class Clase2
    {
        static void Main(string[] args)
        {
            bool game = true;

            int vida = 0;
            float daño = 0;
            float dañoMagico = 0;
            string name = "nulo";
            string[] raza = new string[] {"Mago","Peleador","Elfo","Enano"};
            
            int indexRaza = 0;


            indexRaza = RegistroClase();
            name = RegistroName();

            Console.WriteLine(name);
            Console.WriteLine(raza[indexRaza]);
            while(false)
            {
                
            }
        }

        static string RegistroName()
        {
            Console.WriteLine("Ingrese tu nombre de usuario");
            string name = Console.ReadLine();
            return name;
        }
        static int RegistroClase()
        {
            Console.WriteLine("Elegi una de las siguientes clases: 1-Mago 2-Peleador 3-Elfo 4-Enano");
            int a = Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1:
                    return 0;
                    break;
                case 2:
                    return 1;
                    break;
                case 3:
                    return 2;
                    break;
                case 4:
                    return 3;
                    break;
            }
            return 0;
        }
        static void Estadisticas(string clase, int vida, float daño, float dañoMagico)
        {
            switch (clase)
            {
                case "Mago":
                    vida = 300;
                    daño = 10;
                    dañoMagico = 100; 
                    break;
            }
        }
    }
}