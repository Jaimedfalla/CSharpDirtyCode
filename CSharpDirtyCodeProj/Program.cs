﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpDirtyCode
{
    class Program
    {
        static void Main(string[] args)
        {
            const string saludo = "Bienvenido a mi aplicación";
            var año = DateTime.Now.Year;
            double numeroPi = 3.14;
            int[] vectorEnteros = new int[5];
            vectorEnteros = vectorEnteros.Select(index => new Random().Next(100));

            Console.WriteLine(saludo);

            while (true)
            {
                Console.WriteLine("1=Mostrar año actual, 2=Valor del número pi, 3=Contador, 4=Vector, 5=Diccionario");
                var numeroSeleccionado = Console.ReadLine();
                Menu menu = Menu.Ninguna;

                try
                {
                    menu = Enum.Parse<Menu>(numeroSeleccionado);
                }
                catch (FormatException)
                {
                    Console.WriteLine("El dato ingresado no es válido");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Excepción: {ex.Message}");
                }

                if (menu == Menu.Año)
                {
                    Console.WriteLine(año);
                }
                else if (menu == Menu.PI)
                {
                    Console.WriteLine($"Número pi: {numeroPi}");
                }
                else if (menu == Menu.Contador)
                {
                    Console.WriteLine("Ingrese el limite del contador");
                    var limiteContador = Console.ReadLine();
                    int.TryParse(limiteContador, out int intLimiteContador);

                    for (int i = 1; i <= intLimiteContador; i++)
                    {
                        Console.WriteLine(i);
                        i++;
                    }
                }
                else if (menu == Menu.Vector)
                {
                    vectorEnteros.ToList().ForEach(number => Console.WriteLine(number));
                }
                else if (menu == Menu.Diccionario)
                {
                    Console.WriteLine("Por favor ingrese los numeros para el diccionario y finalize con .");
                    string numeroIngresado = "";
                    Dictionary<int, int> diccionario = new Dictionary<int, int>();
                    int keyValue = 1;
                    while (!numeroIngresado.Equals("."))
                    {
                        numeroIngresado = Console.ReadLine();

                        try
                        {
                            int intnumeroIngresado = int.Parse(numeroIngresado);
                            diccionario.Add(keyValue, intnumeroIngresado);
                            keyValue++;
                        }
                        catch
                        {

                        }
                    }

                    foreach (var item in diccionario)
                    {
                        Console.WriteLine($"Clave: {item.Key} - Valor: {item.Value}");
                    }
                }
                else
                {
                    Console.WriteLine("No ha seleccionado un valor válido");
                }
            }
        }
    }

    public enum Menu
    {
        Ninguna,
        Año = 1,
        PI = 2,
        Contador = 3,
        Vector = 4,
        Diccionario = 5
    }
}
