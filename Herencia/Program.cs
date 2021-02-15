using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Herencia
{
    class Program
    {
        static void Main(string[] args)
        {
            bool continuar = true;
            char seleccion, seleccion2;
            List<participante> participantes = new List<participante>();
            do
            {
                Console.Clear();
                Console.WriteLine("---------MENU----------");
                Console.WriteLine("1) Introducir Participante.");
                Console.WriteLine("2) Mostrar Ponentes.");
                Console.WriteLine("3) Mostrar Oyentes.");
                Console.WriteLine("4) Buscar Participante.");
                Console.WriteLine("5)Salir.");
                seleccion = Console.ReadLine().ToString()[0];
                switch (seleccion)
                {
                    case '1':
                        Console.Clear();
                        Console.WriteLine("---------Introducir Participante----------");
                        Console.WriteLine("1) Introducir Oyente.");
                        Console.WriteLine("2) Introducir Ponente.");
                        seleccion2 = Console.ReadLine().ToString()[0];
                        switch (seleccion2)
                        {
                            case '1':
                                participantes.Add(agregarOyente());
                                break;
                            case '2':
                                participantes.Add(agregarPonente());
                                break;
                            default:
                                return;
                        }
                        break;
                    case '2':
                        imprimir(participantes, "ponente");
                        break;
                    case '3':
                        imprimir(participantes, "oyente");
                        break;
                    case '4':
                        buscarParticipante(participantes);
                        break;
                    default:
                        Console.WriteLine("Saliendo...");
                        continuar = false; break;
                }
            } while (continuar);

        }
        static public oyente agregarOyente()
        {
            oyente temp = new oyente();
            temp.pedirInfoGeneral();
            Console.WriteLine("Ingrese el grado academico del oyente");
            temp.Grado_academico = Console.ReadLine();
            Console.WriteLine(temp.GetType().Name);

            return temp;
        }
        static public ponente agregarPonente()
        {

            ponente temp = new ponente();
            temp.pedirInfoGeneral();
            Console.WriteLine("Ingrese el Titulo de la Ponencia");
            temp.Titulo_ponencia = Console.ReadLine();
            Console.WriteLine("Ingrese la Tematica de la ponencia");
            temp.Tematica = Console.ReadLine();
            Console.WriteLine(temp.GetType().Name);
            return temp;
        }
        static public void imprimir(List<participante> participantes, string vari)
        {
            Console.Clear();
            Console.WriteLine("Mostrando la lista de " + vari + "s");
            foreach (participante temp in participantes)
            {
                if (temp.GetType().Name == vari)
                    Console.WriteLine("Nombre: " + temp.nombre + " " + temp.apellido);
            }
            Console.ReadKey();
        }
        static public void buscarParticipante(List<participante> participantes)
        {
            string nombre, apellido;
            Console.Clear();
            Console.WriteLine("--------Busqueda de participante----------");
            Console.WriteLine("Ingrese el nombre del participante a buscar");
            nombre = Console.ReadLine();
            Console.WriteLine("Ingrese el nombre del participante a buscar");
            apellido = Console.ReadLine();
            foreach (participante temp in participantes)
            {
                if (temp.nombre == nombre && temp.apellido == apellido)
                    Console.WriteLine("Nombre: " + temp.nombre + " " + temp.apellido + " " + temp.GetType().Name + " se encontro en la lista");
            }
            Console.ReadKey();
        }
        public class participante
        {
            public string nombre { get; set; }
            public string apellido { get; set; }
            public string sexo { get; set; }
            public string pais { get; set; }
            public string telefono { get; set; }
            public string email { get; set; }
            public void pedirInfoGeneral()
            {
                Console.WriteLine("Ingrese el Nombre del participante");
                nombre = Console.ReadLine();
                Console.WriteLine("ingrese el Apellido del participante");
                apellido = Console.ReadLine();
                Console.WriteLine("ingrese el sexo del participante");
                sexo = Console.ReadLine();
                Console.WriteLine("ingrese el pais del participante");
                pais = Console.ReadLine();
                Console.WriteLine("ingrese el telefono del participante");
                telefono = Console.ReadLine();
                Console.WriteLine("ingrese el email del participante");
                email = Console.ReadLine();
            }
        }
        public class ponente : participante
        {
            private string titulo_ponencia;
            private string tematica;

            public string Tematica
            {
                get { return tematica; }
                set { tematica = value; }
            }

            public string Titulo_ponencia
            {
                get { return titulo_ponencia; }
                set { titulo_ponencia = value; }
            }

        }
        public class oyente : participante
        {
            private string grado_academico;

            public string Grado_academico
            {
                get { return grado_academico; }
                set { grado_academico = value; }
            }
        }

    }
}
