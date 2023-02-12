// Instalar el SDK en Linux
// https://learn.microsoft.com/en-us/dotnet/core/install/linux-ubuntu
namespace ToDo;

internal class Program
{
	public static List<string> TaskList = new List<string>();

	static void Main(string[] args)
	{
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

		string optionSelected = Console.ReadLine();
		Menu _optionSelected = 0;
		try
		{
			_optionSelected = (Menu)Convert.ToInt32(optionSelected);
		}
		catch
		{
			Console.WriteLine("Hubo un error seleccionando el menu");
		}
		return _optionSelected;
	}

	public static void ShowMenuRemove()
	{
		try
		{
			Console.WriteLine("Ingrese el número de la tarea a remover: ");
			ShowMenuTask();
			Console.WriteLine(Linea);

			string taskIndexSelected = Console.ReadLine();
			// Remove the zero position of array because it is first
			int indexToRemove = Convert.ToInt32(taskIndexSelected) - 1;
			if (indexToRemove >= TaskList.Count || indexToRemove < 0)
				Console.WriteLine("El indice se sale del rango de tareas");
			else
			{
				if (TaskList.Count > 0)
				{
					string task = TaskList[indexToRemove];
					TaskList.RemoveAt(indexToRemove);
					Console.WriteLine($"Tarea {task} eliminada");
				}
			}
		}
		catch (Exception ex)
		{
			Console.WriteLine("Ha ocurrido un error eliminando la tarea");
			Console.WriteLine(ex.Message);
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
			Console.WriteLine("Ha ocurrido un error agregando la tarea");
		}
	}

	public static void ShowMenuList()
	{
		if (TaskList?.Count == 0)
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
		int index = 1;
		TaskList?.ForEach( tarea => Console.WriteLine($"{index++} . {tarea}"));
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
