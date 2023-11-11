using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_Metodos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Variables            
            int opcion;
            decimal r; //Almacena el valor devuelto de Restar();
            decimal num1Ar, num2Ar; //Argumentos para enviar una copia de su valor a los métodos

            do
            {
                Console.WriteLine("1. Suma");
                Console.WriteLine("2. Resta");
                Console.WriteLine("3. Multiplicación");
                Console.WriteLine("4. División");

                //Pedimos una opción
                Console.Write("Escoge una opción: ");
                opcion = Convert.ToInt32(Console.ReadLine());
            }
            while ((opcion < 1) || (opcion > 4));

            //Hacer la operación según la opción escogida
            switch (opcion)
            {
                case 1:
                    Sumar();
                    break;
                case 2:
                    r = Restar(); //Asignamos a "r" el valor devuelto por "return"

                    //Mostramos el resultado, con la información que contiene "r"
                    Console.WriteLine("El resultado de la resta es: {0}", r);
                    break;
                case 3:
                    //Pedimos el valor de ambos números
                    Console.Write("Ingresa el primer número:");
                    num1Ar = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Ingresa el segundo número:");
                    num2Ar = Convert.ToDecimal(Console.ReadLine());

                    //Invocamos al método
                    Multiplicar(num1Ar, num2Ar);
                    break;
                case 4:
                    //Pedimos el valor de ambos números
                    Console.Write("Ingresa el primer número:");
                    num1Ar = Convert.ToDecimal(Console.ReadLine());

                    Console.Write("Ingresa el segundo número:");
                    num2Ar = Convert.ToDecimal(Console.ReadLine());

                    r = Dividir(num1Ar, num2Ar);

                    //Mostramos el resultado, con la información que contiene "r"
                    Console.WriteLine("El resultado de la división es: {0}", r);
                    break;
            }
        }// Cierre el Main

        // [modificador] [tipo] [identificador] [parámetros]
        static void Sumar()
        {
            //Variables del método Sumar()
            decimal num1, num2, resultado;

            //Pedimos el valor de ambos números
            Console.Write("Ingresa el primer número:");
            num1 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Ingresa el segundo número:");
            num2 = Convert.ToDecimal(Console.ReadLine());

            //Operación
            resultado = num1 + num2;

            //Mostramos el resultado
            Console.WriteLine("{0} + {1} = {2}", num1, num2, resultado);
        }

        // [modificador] [tipo] [identificador] [parámetros]
        static decimal Restar()
        {
            //Variables del método Sumar()
            decimal num1, num2, resultado;

            //Pedimos el valor de ambos números
            Console.Write("Ingresa el primer número:");
            num1 = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Ingresa el segundo número:");
            num2 = Convert.ToDecimal(Console.ReadLine());

            //Operación
            resultado = num1 - num2;

            //Devolvemos un tipo al autor de llamado
            return resultado;
        }

        // [modificador] [tipo] [identificador] [parámetros]
        static void Multiplicar(decimal num1Pa, decimal num2Pa)
        {
            //Variables
            decimal resultado;

            //Multiplicación con los valores que mandaron los argumentos
            resultado = num1Pa * num2Pa;

            //Mostramos el resultado
            Console.WriteLine("{0} * {1} = {2}", num1Pa, num2Pa, resultado);
        }

        // [modificador] [tipo] [identificador] [parámetros]
        static decimal Dividir(decimal num1Pa, decimal num2Pa)
        {
            //Variable
            decimal resultado;

            if (num2Pa != 0)
            {
                //División con los valores que mandaron los argumentos
                resultado = num1Pa / num2Pa;
            }
            else
            {
                Console.WriteLine("No es posible dividir entre cero");
                resultado = 0;
            }

            return resultado;
        }
 
    }
}
