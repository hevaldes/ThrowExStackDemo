using System;
namespace DemoThrowStack
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Metodo1();
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.ToString());
                //Console.ReadLine();              
                //Demo 1
                //throw ex;
                //Demo 2
                throw;
            }
        }

        static void Metodo1() 
        {
            Metodo2();
        }

        private static void Metodo2()
        {
            Metodo3();
        }

        private static void Metodo3()
        {
            System.IO.File.Open("ArchivoNoExistente.txt", System.IO.FileMode.Open);
        }
    }
}