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


            RegistroClase(ref indexRaza);
            RegistroName(ref name);

            Console.WriteLine(name);
            Console.WriteLine(raza[indexRaza]);
            while(false)
            {
                
            }
        }

        static void RegistroName(ref string name)
        {
            Console.WriteLine("Ingrese tu nombre de usuario");
            name = Console.ReadLine();
        }
        static void RegistroClase(ref int indexRaza)
        {
            Console.WriteLine("Elegi una de las siguientes clases: 1-Mago 2-Peleador 3-Elfo 4-Enano");
            int a = Convert.ToInt32(Console.ReadLine());
            switch(a)
            {
                case 1:
                    indexRaza = 0;
                    break;
                case 2:
                    indexRaza = 1;
                    break;
                case 3:
                    indexRaza = 2;
                    break;
                case 4:
                    indexRaza = 3;
                    break;
            }
        }
        static void Estadisticas(ref string clase,ref int vida,ref float daño,ref float dañoMagico)
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