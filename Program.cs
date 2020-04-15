using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL;
using Entity;

namespace ParcialMarvinUI
{
    class Program
    {
        static void Main(string[] args)
        {
            TasaDeInteresCompuesto compuesto;
            TasaDeInteresSimple simple;
            List<Credito> creditos = new List<Credito>();
            CreditoService service = new CreditoService();
            int opcion;
            do
            {
                Console.Clear();
                Console.WriteLine("Main");
                Console.WriteLine("");
                Console.WriteLine("1 .Registrar");
                Console.WriteLine("2. Consultar");
                Console.WriteLine("3. Mostrar");
                Console.WriteLine("4. Modificar");
                Console.WriteLine("5. Eliminar");
                Console.WriteLine("0. SALIR");
                Console.WriteLine("Digite La opcion deseada");
                opcion = int.Parse( Console.ReadLine());
                switch (opcion)
                {
                    case 1: Registrar(); break;
                    case 2: Consultar(); break;
                    case 3: MostrarTodo(); break;
                    case 4: Modificar(); break;
                    case 5: Eliminar(); break;
                    case 0: break;
                }

            } while (opcion != 0);

            Console.ReadKey();
            void Registrar() 
            {
                simple = new TasaDeInteresSimple("111", "sim", 300000, 30, 3, 0);
                simple.CalcularInteres();
                Console.WriteLine(service.Guardar(simple));
                simple = new TasaDeInteresSimple("1", "sim", 300000, 30, 3, 0);
                simple.CalcularInteres();
                Console.WriteLine(service.Guardar(simple));
                compuesto = new TasaDeInteresCompuesto("222", "comm", 300000, 30, 3, 0);
                compuesto.CalcularInteres();
                Console.WriteLine(service.Guardar(compuesto));
                compuesto = new TasaDeInteresCompuesto("2", "comm", 300000, 30, 3, 0);
                compuesto.CalcularInteres();
                Console.WriteLine(service.Guardar(compuesto));
            }
            void Consultar() 
            {

                Console.Clear();
                Console.WriteLine("Buscar");
                foreach (var item in creditos)
                {

                    Console.WriteLine(item.ToString());
                }
            }
            void Eliminar()
            {
                Console.Clear();
                Console.WriteLine("Eliminar");
                service.Eliminar("2"); service.Eliminar("0"); 
            }
            void MostrarTodo()
            {
                Console.Clear();
                Console.WriteLine("Todo");
                service.Consultar(); 
            }
            void Modificar()
            {

                Console.Clear();
                Console.WriteLine("Buscar");
                Console.WriteLine("no actualizado");
            }

        }
    }
}