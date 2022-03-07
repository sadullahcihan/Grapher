using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Grapher_new_edition_17._12._2019
{
    class Program
    {
        static char[,] screen = new char[25, 40];
        static char[,] fake_screen = new char[25, 40];
        static string menu_option;
        static void MENU()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("**********THE GRAPHER**********" + "\n" + "\n" + "         -MENU-  " + "\n");
            Console.WriteLine("1 - LOAD GRAPH " + "\n" + "2 - DRAW  GRAPH MANUALLY" + "\n" + "\n" + "NOTE: YOU SHOULD USE UPPERCASE LETTER WHILE DRAWING OR REDRAWING THE GRAPH" + "\n" + "\n" + "PLEASE CHOOSE MODE: ");
            menu_option = Console.ReadLine();
            while (menu_option != "1" && menu_option != "2")
            {
                Console.Clear();
                Console.WriteLine("**********THE GRAPHER**********" + "\n" + "\n" + "         -MENU-  " + "\n");
                Console.WriteLine("1 - LOAD GRAPH " + "\n" + "2 - DRAW  GRAPH MANUALLY" + "\n" + "\n" + "NOTE: YOU SHOULD USE UPPERCASE LETTER WHILE DRAWING OR REDRAWING THE GRAPH" + "\n" + "\n" + "PLEASE CHOOSE MODE: ");
                menu_option = Console.ReadLine();
            }
        }
        static void GRAPH_LOADER()
        {
            string name_of_graph;
            string graph_option;
            Console.WriteLine("Enter the option of which graph you want to see" + "\n1-Existed graph" + "\n2-New existed graph");
            graph_option = Console.ReadLine();
            while (graph_option != "1" && graph_option != "2")
            {
                Console.Clear();
                Console.WriteLine("Enter the option of which graph you want to see" + "\n1-Existed graph" + "\n2-New existed graph");
                graph_option = Console.ReadLine();
            }
            if (graph_option == "1")
            {
                name_of_graph = "graph";
            }
            else
            {
                name_of_graph = "graph_new";
            }
            string path = @"C:\Users\Sadullah Cihan\Source\Repos\File_Reading\File_Reading\bin\Debug\" + name_of_graph + ".txt";
            StreamReader graph_txt = File.OpenText(path);
            char char_reader;
            while (!graph_txt.EndOfStream)
            {
                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        char_reader = Convert.ToChar(graph_txt.Read());
                        while (char_reader == 13 || char_reader == 10) //txt dosyası içinde görünmeyen \r (ASCII'de 13) veya \n (ASCII'de10) karakterleri gelirse diğer karakteri okur.
                        { char_reader = Convert.ToChar(graph_txt.Read()); }
                        screen[i, j] = Convert.ToChar(char_reader);
                    }
                }
            }
            graph_txt.Close();
            Console.Clear();
        }
        static void GRAPH_DRAWER()
        {
            //DRAVING MODE
            Console.ForegroundColor = ConsoleColor.Blue;
            //creating  # frame 
            for (int i = 1; i < 43; i++)
            {
                Console.Write('#');
            }
            Console.WriteLine();
            for (int i = 1; i < 26; i++)
            {
                Console.WriteLine('#');
            }
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    screen[i, j] = '.';
                    Console.SetCursorPosition(j + 1, i + 1);
                    Console.Write(screen[i, j]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            for (int i = 1; i < 43; i++)
            {
                Console.Write('#');
            }
            Console.ResetColor();
            ConsoleKeyInfo keyboard;
            int cursorx = 20, cursory = 20;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("press enter to save new graph");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyboard = Console.ReadKey(true);
                    if (keyboard.Key == ConsoleKey.LeftArrow && cursorx > 1)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx--;
                    }
                    if (keyboard.Key == ConsoleKey.RightArrow && cursorx < 40)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx++;
                    }
                    if (keyboard.Key == ConsoleKey.UpArrow && cursory > 1)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursory--;
                    }
                    if (keyboard.Key == ConsoleKey.DownArrow && cursory < 25)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursory++;
                    }
                    if (keyboard.Key == ConsoleKey.Escape) break;

                    if (keyboard.KeyChar >= 65 && keyboard.KeyChar <= 80)
                    {
                        screen[cursory - 1, cursorx - 1] = keyboard.KeyChar;
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.Write(screen[cursory - 1, cursorx - 1]); //cursory -1 and cursorx -1 bacause of #'s
                    }

                    if (keyboard.Key == ConsoleKey.Spacebar)
                    {
                        screen[cursory - 1, cursorx - 1] = '+';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                    }
                    if (keyboard.Key == ConsoleKey.X)
                    {
                        screen[cursory - 1, cursorx - 1] = 'X';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                    }
                    if (keyboard.KeyChar == 46) //DOT IN ASCII 46
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        screen[cursory - 1, cursorx - 1] = '.';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                        Console.ResetColor();
                    }
                    if (keyboard.Key == ConsoleKey.Enter)
                        SAVING();
                }
                Console.SetCursorPosition(cursorx, cursory);
            }
        }
        static void GRAPH_REDRAWER()
        {
            //REDRAVING MODE
            Console.ForegroundColor = ConsoleColor.Blue;
            //creating  # frame 
            for (int i = 1; i < 43; i++)
            {
                Console.Write('#');
            }
            Console.WriteLine();
            for (int i = 1; i < 26; i++)
            {
                Console.WriteLine('#');
            }
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.SetCursorPosition(j + 1, i + 1);
                    Console.Write(screen[i, j]);
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.Write('#');
                }
                Console.WriteLine();
            }
            for (int i = 1; i < 43; i++)
            {
                Console.Write('#');
            }
            Console.ResetColor();
            ConsoleKeyInfo keyboard;
            int cursorx = 20, cursory = 20;
            Console.SetCursorPosition(0, 28);
            Console.WriteLine("press enter to save new graph");
            while (true)
            {
                if (Console.KeyAvailable)
                {
                    keyboard = Console.ReadKey(true);
                    if (keyboard.Key == ConsoleKey.LeftArrow && cursorx > 1)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx--;
                    }
                    if (keyboard.Key == ConsoleKey.RightArrow && cursorx < 40)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursorx++;
                    }
                    if (keyboard.Key == ConsoleKey.UpArrow && cursory > 1)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursory--;
                    }
                    if (keyboard.Key == ConsoleKey.DownArrow && cursory < 25)
                    {
                        Console.SetCursorPosition(cursorx, cursory);
                        cursory++;
                    }
                    if (keyboard.KeyChar >= 65 && keyboard.KeyChar <= 80)
                    {
                        screen[cursory - 1, cursorx - 1] = keyboard.KeyChar;
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.Write(screen[cursory - 1, cursorx - 1]); //cursory -1 and cursorx -1 bacause of #'s
                    }
                    if (keyboard.Key == ConsoleKey.Spacebar)
                    {
                        screen[cursory - 1, cursorx - 1] = '+';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                    }
                    if (keyboard.Key == ConsoleKey.X)
                    {
                        screen[cursory - 1, cursorx - 1] = 'X';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                    }
                    if (keyboard.KeyChar == 46) //DOT IN ASCII 46
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        screen[cursory - 1, cursorx - 1] = '.';
                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine(screen[cursory - 1, cursorx - 1]);
                        Console.ResetColor();
                    }
                    if (keyboard.Key == ConsoleKey.Enter)
                        SAVING();
                }
                Console.SetCursorPosition(cursorx, cursory);
            }
        }
        static void SAVING()
        {
            StreamWriter graph_new = File.CreateText("C:\\Users\\Sadullah Cihan\\Source\\Repos\\File_Reading\\File_Reading\\bin\\Debug\\graph_new.txt");
            for (int i = 0; i < screen.GetLength(0); i++)
            {
                for (int j = 0; j < screen.GetLength(1); j++)
                {
                    char saved_graph = Convert.ToChar(screen[i, j]);
                    graph_new.Write(saved_graph);
                }
                if (i != 24)
                {
                    graph_new.WriteLine();
                }
            }
            graph_new.Close();
            Console.SetCursorPosition(0, 27); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saving operation has finished successfully !");
        }
        static void MATRIX_SAVING(int h)
        {
            StreamWriter matrix_new = File.AppendText("C:\\Users\\Sadullah Cihan\\Source\\Repos\\File_Reading\\File_Reading\\bin\\Debug\\matrix.txt");
            matrix_new.WriteLine("R_"+h);
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    int saved_matrix = R_N_MATRIX[i,j];
                    matrix_new.Write(saved_matrix);
                }
                matrix_new.WriteLine();
            }
            matrix_new.WriteLine();
            matrix_new.Close();
            Console.SetCursorPosition(0, 27); Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Saving operation has finished successfully !");
        }
        static char[] graph_nodes = new char[30];//NODE KEEPER [A,P]
        static int q = 0; // connection assign variable
        //global variables
        static char[] end_nodes = new char[30];
        static bool[] connection = new bool[30];
        static int trace_i = 0;
        static int trace_j = 0;
        static bool flag = true;
        static int nodes_keeper_i;
        static int nodes_keeper_j;
        static int letter_around_counter = 0;
        static string[] letter = { "A", "B", "C", "D", "E", "F", "G", "H", "I", "J", "K", "L", "M", "N", "O", "P" };
        static void right()
        {
            //right(); function this while + direction function (add while end **)
            while (fake_screen[trace_i, trace_j + 1] != '.')
            {
                if (fake_screen[trace_i, trace_j + 1] == '+')
                { fake_screen[trace_i, trace_j + 1] = '.'; }

                trace_j++;
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i, trace_j + 1];
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar 
        }
        static void right_down()
        {
            while (fake_screen[trace_i + 1, trace_j + 1] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                { fake_screen[trace_i + 1, trace_j + 1] = '.'; }
                trace_i++; // **************** her fonksiyonda değişen kısımlar
                trace_j++; // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i + 1, trace_j + 1]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar. 
        }

        static void right_up()
        {
            while (fake_screen[trace_i - 1, trace_j + 1] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                { fake_screen[trace_i - 1, trace_j + 1] = '.'; }
                trace_i--; // **************** her fonksiyonda değişen kısımlar
                trace_j++; // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i - 1, trace_j + 1]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }
                // eski yer tutma fonksiyonu old_position_holder();
            }// **add here direction function DIRECTION();
        }
        static void up()
        {
            while (fake_screen[trace_i - 1, trace_j] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i - 1, trace_j] == '+')
                { fake_screen[trace_i - 1, trace_j] = '.'; }
                trace_i--; // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i - 1, trace_j]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
        }
        static void down()
        {
            while (fake_screen[trace_i + 1, trace_j] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i + 1, trace_j] == '+')
                { fake_screen[trace_i + 1, trace_j] = '.'; }
                trace_i++; // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i + 1, trace_j]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar.
        }
        static void left()
        {
            while (fake_screen[trace_i, trace_j - 1] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i, trace_j - 1] == '+')
                { fake_screen[trace_i, trace_j - 1] = '.'; }
                trace_j--; // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i, trace_j - 1]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar.
        }
        static void left_up()
        {
            while (fake_screen[trace_i - 1, trace_j - 1] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                { fake_screen[trace_i - 1, trace_j - 1] = '.'; }
                trace_i--; // **************** her fonksiyonda değişen kısımlar
                trace_j--;           // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i - 1, trace_j - 1]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        graph_nodes[q] = fake_screen[trace_i, trace_j];
                        break;
                    }
                }

            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar.
        }
        static void left_down()
        {
            while (fake_screen[trace_i + 1, trace_j - 1] != '.') // **************** her fonksiyonda değişen kısımlar
            {
                if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                { fake_screen[trace_i + 1, trace_j - 1] = '.'; }
                trace_i++; // **************** her fonksiyonda değişen kısımlar
                trace_j--;           // **************** her fonksiyonda değişen kısımlar
                if (letter_around_counter > 0)
                {
                    // HARFIN ETRAFINDAKI + LARI SAYAR
                    int plus_counter = 0;
                    if (fake_screen[trace_i + 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i, trace_j - 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                        plus_counter++;
                    if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                        plus_counter++;
                    if (plus_counter >= 3)
                    {
                        fake_screen[trace_i, trace_j] = '+';
                    }
                }
                letter_around_counter++;
                Console.SetCursorPosition(trace_j, trace_i);
                if (fake_screen[trace_i, trace_j] == 'X')
                {
                    end_nodes[q] = fake_screen[trace_i + 1, trace_j - 1]; // **************** her fonksiyonda değişen kısımlar
                    connection[q] = true;
                    q++;
                    flag = false;
                    letter_around_counter = 0;
                    if (flag == false)
                    {
                        trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        break;
                    }
                }
            }// **add here direction function DIRECTION();
             // yön değiştirdiği anda loop tan çıkar. 
        }
        static int[,] R_MATRIX = new int[16, 16];
        static int[] connection_one_zero = new int[connection.Length];
        static int[,] R_N_MATRIX = new int[16, 16];
        static int[,] R_N_MATRIX_NEW = new int[16, 16];
        static int[,] R_ORIGINAL = new int[16, 16];
        static int[,] R_MIN_MATRIX = new int[16, 16];

        static int[,] R_N(int N)
        {
            //R**2_MATRIX mul.
            if (N == 1) return R_N_MATRIX;
            else
            {
                int sum = 0; // MATRIX MULTIPLICATION
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        sum = 0;
                        for (int k = 0; k < 16; k++)
                        {
                            sum += R_N_MATRIX[i, k] * R_ORIGINAL[k, j];
                        }

                        if (sum > 1)
                        { sum = 1; }
                        R_N_MATRIX_NEW[i, j] = sum;//N veya N-1 olabilir?
                    }
                }
                //R_N_MATRIX has been updated here
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_N_MATRIX_NEW[i, j];
                    }
                }
                N--;
                return R_N(N);
            }
        }
        static int node_amount = 0;
        static int matrix_saving_controller = 1;
        static void TRACING_AND_R_MATRIX()
        {
            //TRACING 
            for (int i = 0; i < fake_screen.GetLength(0); i++)
            {
                for (int j = 0; j < fake_screen.GetLength(1); j++)
                {
                    Console.SetCursorPosition(j, i);
                    //it keeps nodes that placed in the graph 
                    if (fake_screen[i, j] >= 65 && fake_screen[i, j] <= 80)
                    {
                        Console.SetCursorPosition(j, i);
                        trace_i = i; trace_j = j;
                        node_amount++;
                        nodes_keeper_i = trace_i;
                        nodes_keeper_j = trace_j;
                        // HARFIN ETRAFINDAKI + LARI SAYAR
                        int plus_counter = 0;
                        if (fake_screen[trace_i + 1, trace_j] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i + 1, trace_j + 1] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i + 1, trace_j - 1] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i, trace_j + 1] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i, trace_j - 1] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i - 1, trace_j] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i - 1, trace_j + 1] == '+')
                            plus_counter++;
                        if (fake_screen[trace_i - 1, trace_j - 1] == '+')
                            plus_counter++;
                        for (int z = 0; z < plus_counter; z++)
                        {   // If a node change its manevra it must get in the big while loop (8direction loop)
                            while (fake_screen[trace_i + 1, trace_j] == '+'
                            || fake_screen[trace_i + 1, trace_j + 1] == '+'
                            || fake_screen[trace_i + 1, trace_j - 1] == '+'
                            || fake_screen[trace_i, trace_j + 1] == '+'
                            || fake_screen[trace_i, trace_j - 1] == '+'
                            || fake_screen[trace_i - 1, trace_j] == '+'
                            || fake_screen[trace_i - 1, trace_j + 1] == '+'
                            || fake_screen[trace_i - 1, trace_j - 1] == '+')
                            {
                                //DIRECTION(); function**** starting here
                                //if graph node has found, check around of the node.(8 Directions)
                                graph_nodes[q] = fake_screen[trace_i, trace_j];
                                while (fake_screen[trace_i + 1, trace_j] == '+'
                                || fake_screen[trace_i + 1, trace_j + 1] == '+'
                                || fake_screen[trace_i + 1, trace_j - 1] == '+'
                                || fake_screen[trace_i, trace_j + 1] == '+'
                                || fake_screen[trace_i, trace_j - 1] == '+'
                                || fake_screen[trace_i - 1, trace_j] == '+'
                                || fake_screen[trace_i - 1, trace_j + 1] == '+'
                                || fake_screen[trace_i - 1, trace_j - 1] == '+')
                                {
                                    //if (fake_screen[temp_i, temp_j] != '+') // yön değiştirdiğinde geri dönmemesi için yazıldı (her fonksiyonun başına)
                                    {   //right(); function this while + direction function (add while end **)
                                        if (fake_screen[trace_i, trace_j + 1] == '+')
                                        {
                                            Console.SetCursorPosition(trace_j + 1, trace_i);
                                            right();
                                        }// **add here direction function DIRECTION();
                                    }

                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //right_down(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                        if (fake_screen[trace_i + 1, trace_j + 1] == '+') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j + 1, trace_i + 1);
                                            right_down();
                                        }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                            //right_up(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                            if (fake_screen[trace_i - 1, trace_j + 1] == '+') // **************** her fonksiyonda değişen kısımlar
                                            {
                                                Console.SetCursorPosition(trace_j + 1, trace_i - 1);
                                                right_up();
                                            }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //up(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                        if (fake_screen[trace_i - 1, trace_j] == '+') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j, trace_i - 1);
                                            up();
                                        }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //down(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                        if (fake_screen[trace_i + 1, trace_j] == '+') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j, trace_i + 1);
                                            down();
                                        }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //left(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                        if (fake_screen[trace_i, trace_j - 1] != '.') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j - 1, trace_i);
                                            left();
                                        }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //left_up(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar
                                        if (fake_screen[trace_i - 1, trace_j - 1] == '+') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j - 1, trace_i - 1);
                                            left_up();
                                        }
                                    }
                                    //if (fake_screen[temp_i, temp_j] != '+')
                                    {
                                        //left_down(); function this while + direction function (add while end **) // **************** her fonksiyonda değişen kısımlar

                                        if (fake_screen[trace_i + 1, trace_j - 1] == '+') // **************** her fonksiyonda değişen kısımlar
                                        {
                                            Console.SetCursorPosition(trace_j - 1, trace_i + 1);
                                            left_down();
                                        }
                                    }
                                    if (flag == false)
                                    { break; }
                                }//DIRECTION(); function ends
                                flag = true;
                                trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                            }
                            trace_i = nodes_keeper_i; trace_j = nodes_keeper_j;
                        }
                    }//ctrl point
                }
            }
            // R MATRIX FILLING
            for (int t = 0; t < connection_one_zero.Length; t++)
            {
                if (connection[t] == true)
                { connection_one_zero[t] = 1; }
            }
            for (int t = 0; t < R_MATRIX.GetLength(0); t++)//all matrix 0
            {
                for (int u = 0; u < R_MATRIX.GetLength(1); u++)
                { R_MATRIX[t, u] = 0; }
            }
            for (int t = 0; t < R_MATRIX.GetLength(0); t++) // assigning connected nodes 1
            {
                for (int u = 0; u < R_MATRIX.GetLength(1); u++)
                {
                    if ((graph_nodes[u] >= 65 && graph_nodes[u] <= 80) && (end_nodes[u] >= 65 && end_nodes[u] <= 80))
                    { R_MATRIX[graph_nodes[u] - 65, end_nodes[u] - 65] = connection_one_zero[u]; }
                }
            }
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    R_ORIGINAL[i, j] = R_MATRIX[i, j];
                    R_N_MATRIX[i, j] = R_MATRIX[i, j];
                }
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(46, 0);
            Console.WriteLine("R MATRIX");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(46, 1);
            Console.Write("ABCDEFGHIJKLMNOP");          
            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(44, 2 + i);
                Console.WriteLine(letter[i]);
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int t = 0; t < R_MATRIX.GetLength(0); t++)
            {
                for (int u = 0; u < R_MATRIX.GetLength(1); u++)
                {
                    Console.SetCursorPosition(46 + u, 2 + t);
                    Console.Write(R_MATRIX[t, u]);
                }
                Console.WriteLine();
            }
            //R* calculate
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(66, 0);
            Console.WriteLine("R*" + "            ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.SetCursorPosition(66, 1);
            Console.Write("ABCDEFGHIJKLMNOP");
            for (int i = 0; i < 16; i++)
            {
                Console.SetCursorPosition(64, 2 + i);
                Console.WriteLine(letter[i]);
            }
            int[,] R_STAR_MATRIX = new int[16, 16];
            for (int w = 1; w <= node_amount; w++)
            {
                R_N(w);
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if(R_N_MATRIX[i,j]==1)
                        {
                            R_STAR_MATRIX[i, j] = R_N_MATRIX[i, j];
                        }
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_ORIGINAL[i, j];
                    }
                }
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            for (int i = 0; i < 16; i++)
            {
                for (int j = 0; j < 16; j++)
                {
                    Console.SetCursorPosition(66 + j, 2 + i);
                    Console.Write(R_STAR_MATRIX[i, j]);
                }
                Console.WriteLine();
            }
            //R MİN calculate
            for (int w = 1; w <= node_amount; w++)
            {
                R_N(w);
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        if (R_N_MATRIX[i, j] == 1&& (R_MIN_MATRIX[i, j]!=1 && R_MIN_MATRIX[i, j] != 2 && R_MIN_MATRIX[i, j] != 3 && R_MIN_MATRIX[i, j] != 4 && R_MIN_MATRIX[i, j] != 5 && R_MIN_MATRIX[i, j] != 6 && R_MIN_MATRIX[i, j] != 7 && R_MIN_MATRIX[i, j] != 8 && R_MIN_MATRIX[i, j] != 9))
                        {
                            R_MIN_MATRIX[i, j] = w;
                        }
                    }
                }
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_ORIGINAL[i, j];
                    }
                }
            }
            if (matrix_saving_controller==1)
            {
                //Firstly delete matrix.txt file
                StreamWriter matrix_new = File.CreateText("C:\\Users\\Sadullah Cihan\\Source\\Repos\\File_Reading\\File_Reading\\bin\\Debug\\matrix.txt");
                matrix_new.Close();
                //Saving R ,R2 ,R3 ... RN into matrix.txt 
                for (int h = 1; h <= node_amount; h++)
                {
                    R_N(h);
                    MATRIX_SAVING(h);
                    for (int i = 0; i < 16; i++)
                    {
                        for (int j = 0; j < 16; j++)
                        {
                            R_N_MATRIX[i, j] = R_ORIGINAL[i, j];
                        }
                    }
                }
                // Saving R* matrix to matrix.txt
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_STAR_MATRIX[i, j];
                    }
                }
                MATRIX_SAVING(42);
                // Saving R MIN matrix to matrix.txt
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_MIN_MATRIX[i, j];
                    }
                }
                MATRIX_SAVING(774978); // 77 = M , 49=I , 78=N in ASCII :) :)
                for (int i = 0; i < 16; i++)
                {
                    for (int j = 0; j < 16; j++)
                    {
                        R_N_MATRIX[i, j] = R_ORIGINAL[i, j];
                    }
                }
                matrix_saving_controller++;
            } 
        }
        static void Main(string[] args)
        {
            MENU();
            //LOADING GRAPH
            if (menu_option == "1")
            {
                Console.Clear();
                GRAPH_LOADER();
                //graph.txt file writer
                for (int i = 0; i < screen.GetLength(0); i++)
                {
                    for (int j = 0; j < screen.GetLength(1); j++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(screen[i, j]); ;
                        fake_screen[i, j] = screen[i, j];
                    }
                    Console.WriteLine();
                }
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine();
                bool flag = true;
                while (flag)
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.SetCursorPosition(45, 19);
                    Console.WriteLine("MENU");
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.SetCursorPosition(45, 20);
                    Console.WriteLine("'0' => Show R Min Matrix ");
                    Console.SetCursorPosition(45, 21);
                    Console.WriteLine("'1' => Show R and R * Matrix");
                    Console.SetCursorPosition(45, 22);
                    Console.WriteLine("'2-9' => Show Rn Matrix");
                    Console.SetCursorPosition(45, 23);
                    Console.WriteLine("'Q' => Query For Min Steps");
                    Console.SetCursorPosition(45, 24);
                    Console.WriteLine("'C' => Change The Graph");
                    Console.SetCursorPosition(45, 25);
                    string display_keys = Console.ReadLine();
                    if (display_keys == "1")
                    {
                        TRACING_AND_R_MATRIX();
                    }
                    else if (display_keys == "0") // SHOWING  R_MIN MATRIX
                    {
                        TRACING_AND_R_MATRIX();
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(66, 0);
                        Console.WriteLine("R MIN"+"            ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        for (int i = 0; i < 16; i++)
                        {
                            for (int j = 0; j < 16; j++)
                            {
                                Console.SetCursorPosition(66 + j, 2 + i);
                                Console.Write(R_MIN_MATRIX[i, j]);
                            }
                            Console.WriteLine();
                        }
                    }
                    //R(N) MATRIX WRTING
                    else if (display_keys == "2" || display_keys == "3" || display_keys == "4" || display_keys == "5"
                          || display_keys == "6" || display_keys == "7" || display_keys == "8" || display_keys == "9")
                    {
                        TRACING_AND_R_MATRIX();
                        int which_N = Convert.ToInt32(display_keys);//R(N) input
                        R_N(which_N);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(66, 0);
                        Console.WriteLine("R" + which_N+"            ");
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.SetCursorPosition(66, 1);
                        Console.Write("ABCDEFGHIJKLMNOP");
                        for (int i = 0; i < 16; i++)
                        {
                            Console.SetCursorPosition(64, 2 + i);
                            Console.WriteLine(letter[i]);
                        }
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        for (int t = 0; t < R_N_MATRIX.GetLength(0); t++)
                        {
                            for (int u = 0; u < R_N_MATRIX.GetLength(1); u++)
                            {
                                Console.SetCursorPosition(66 + u, 2 + t);
                                Console.Write(R_N_MATRIX[t, u]);
                            }
                            Console.WriteLine();
                        }
                    }
                    else if (display_keys.ToUpper() == "Q")
                    {
                        TRACING_AND_R_MATRIX();
                        Console.SetCursorPosition(77, 19);
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine("QUERY FOR MIN STEPS");
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.SetCursorPosition(77, 20);
                        Console.Write("From: ");
                        string from = Console.ReadLine().ToUpper();
                        Console.SetCursorPosition(85, 20);
                        Console.Write(" To: ");
                        string to = Console.ReadLine().ToUpper();
                        if (R_MIN_MATRIX[Convert.ToChar(from) - 65, Convert.ToChar(to) - 65] == 0)
                        {
                            Console.SetCursorPosition(77, 21);
                            Console.WriteLine("NOT POSSIBLE");
                        }
                        else
                        {
                            Console.SetCursorPosition(77, 21);
                            Console.WriteLine(R_MIN_MATRIX[Convert.ToChar(from) - 65, Convert.ToChar(to) - 65]);
                        }     
                    }
                    else if (display_keys.ToLower()=="c")
                    { flag = false; }
                    Console.SetCursorPosition(45, 25); 
                    Console.Write("                                                    ");
                }
                Console.Clear();
                GRAPH_REDRAWER();
            }
            //DRAWING NEW GRAPH
            else if (menu_option == "2")
            {
                Console.Clear();
                GRAPH_DRAWER();
            }
            Console.ReadLine();
        }

    }
}