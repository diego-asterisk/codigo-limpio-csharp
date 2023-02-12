using System;
using System.Collections.Generic;

namespace ToDo
{
    internal class Program
    {
        public static List<string> TaskList { get; set; }

        static void Main(string[] args)
        {
            TaskList = new List<string>();
            Menu userOptionSelected = 0;
            do
            {
                userOptionSelected = ShowMainMenu();
                switch(userOptionSelected)
                {
					case Menu.Add:
						ShowMenuAdd();
						break;
					case Menu.Remove:
						ShowMenuRemove();
						break;
					case Menu.List:
						ShowMenuList();
						break;					
				}
            } while (userOptionSelected != Menu.Exit);
        }
        /// <summary>
        /// Show the main menu 
        /// </summary>
        /// <returns>Returns option indicated by user</returns>
        public static Menu ShowMainMenu()
        {
            Console.WriteLine(Linea);
            Console.WriteLine("Ingrese la opción a realizar: ");
            Console.WriteLine("1. Nueva tarea");
            Console.WriteLine("2. Remover tarea");
            Console.WriteLine("3. Tareas pendientes");
            Console.WriteLine("4. Salir");

            // Read line
            string optionSelected = Console.ReadLine();
            return (Menu)Convert.ToInt32(optionSelected);
        }

        public static void ShowMenuRemove()
        {
            try
            {
                Console.WriteLine("Ingrese el número de la tarea a remover: ");
                // Show current taks
				ShowMenuTask();
                Console.WriteLine(Linea);

                string taskIndexSelected = Console.ReadLine();
                // Remove one position
                int indexToRemove = Convert.ToInt32(taskIndexSelected) - 1;
                if ((indexToRemove > -1) && (TaskList.Count > 0))
                {
					string task = TaskList[indexToRemove];
					TaskList.RemoveAt(indexToRemove);
					Console.WriteLine("Tarea " + task + " eliminada");
                }
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuAdd()
        {
            try
            {
                Console.WriteLine("Ingrese el nombre de la tarea: ");
                string task = Console.ReadLine();
                TaskList.Add(task);
                Console.WriteLine("Tarea registrada");
            }
            catch (Exception)
            {
            }
        }

        public static void ShowMenuList()
        {
            if (TaskList == null || TaskList.Count == 0)
            {
                Console.WriteLine("No hay tareas por realizar");
            } 
            else
            {
                Console.WriteLine(Linea);
                ShowMenuTask();
                Console.WriteLine(Linea);
            }
        }
        public static void ShowMenuTask()
        {
			int index = 0;
			TaskList.ForEach( tarea => Console.WriteLine((index++ + 1) + ". " + tarea));
		}
        public enum Menu{
			// agregamos los valores para coincidir con el menu impreso
			Add = 1,
			List = 3,
			Remove =2,
			Exit = 4
		}
		const string Linea = "----------------------------------------";
    }
}
