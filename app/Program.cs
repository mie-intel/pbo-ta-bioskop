﻿using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;
using App.Utils;
using PBO_GUI;

namespace App
{
    internal class Program
    {
        // Program Utama
        static void Main(string[] args)
        {

            // while (true)
            // {
            //     if (!TerminalDisplay.Display())
            //         break;
            // }
            string tes = UserProvider.Register("polikarpu123", "mie-mie");
            Console.WriteLine(tes);
            Console.WriteLine("\nSampai Jumpa!");
        }
    }
}