﻿// See https://aka.ms/new-console-template for more information
using CursoBasico.BigO;
using CursoBasico.POO_01.Clase_Estructura;
using CursoBasico.POO_01.ClaseAbstracta_Interfaz;
using CursoBasico.POO_02.Encapsulacion;
using CursoBasico.POO_02.Polimorfismo;
using CursoBasico.POO_03.BasicShit;
using CursoBasico.POO_04.ClasesOrientadoAObjetos;

internal class Program
{
    private static void Main(string[] args)
    {
        CuentaBancaria cuenta = new CuentaBancaria();

        cuenta.saldo = 150;

        Console.WriteLine("Cuenta.Saldo \n");
        Console.WriteLine(cuenta.saldo);
        Console.WriteLine("Cuenta.MostrarSaldo \n");

    }

}