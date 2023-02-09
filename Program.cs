namespace ToDo
{
  internal class Program
  {
    public static List<string> TaskList { get; set; } = new List<string>();

    public enum Menu
    {
      Add = 1,
      Remove = 2,
      List = 3,
      Exit = 4
    }

    static void Main(string[] args)
    {
      int menuSelected = 0;
      do
      {
        menuSelected = ShowMainMenu();
        if (menuSelected == (int)Menu.Add)
        {
          ShowMenuAdd();
        }
        else if (menuSelected == (int)Menu.Remove)
        {
          ShowMenuRemove();
        }
        else if (menuSelected == (int)Menu.List)
        {
          ShowMenuTaskList();
        }
      } while (menuSelected != (int)Menu.Exit);
    }
 

    public static int ShowMainMenu()
    {
      Console.WriteLine("----------------------------------------");
      Console.WriteLine("Ingrese la opción a realizar: ");
      Console.WriteLine("1. Nueva tarea");
      Console.WriteLine("2. Remover tarea");
      Console.WriteLine("3. Tareas pendientes");
      Console.WriteLine("4. Salir");

      try
      {
        string optionSelected = Console.ReadLine();
        return Convert.ToInt32(optionSelected);
      }
      catch (Exception)
      {
        Console.WriteLine("Opcion no valida");
        return 4;
      }
      
    }

    public static void ShowMenuRemove()
    {
      try
      {
        Console.WriteLine("Ingrese el número de la tarea a remover: ");
        ShowTaskList();
        Console.WriteLine("----------------------------------------");

        string numTaskSelected = Console.ReadLine();
        int indexToRemove = Convert.ToInt32(numTaskSelected) - 1;

        if (indexToRemove > (TaskList.Count - 1) || indexToRemove < 0)
        {
          Console.WriteLine("Tarea seleccionada no valida");
        }
        else if (indexToRemove > -1 && TaskList.Count > 0)
        {

          string taskDeleted = TaskList[indexToRemove];
          TaskList.RemoveAt(indexToRemove);
          Console.WriteLine($"Tarea {taskDeleted} eliminada");

        }
      }
      catch (Exception)
      {
        Console.WriteLine("No se ha podido borrar la tarea");

      }
    }

    public static void ShowMenuAdd()
    {
      try
      {
        Console.WriteLine("Ingrese el nombre de la tarea: ");
        string newTask = Console.ReadLine();

        if (newTask == string.Empty)
        {
          Console.WriteLine("Formato de tarea no valido");

        }
        else
        {
          TaskList.Add(newTask);
          Console.WriteLine("Tarea registrada");
        }
      }
      catch (Exception)
      {
        Console.WriteLine("No se ha podido registrar la tarea");
      }
    }

    public static void ShowMenuTaskList()
    {
      if (TaskList?.Count > 0)
      {
        ShowTaskList();

      }
      else
      {
        Console.WriteLine("No hay tareas por realizar");

      }
    }

    public static void ShowTaskList()
    {
      Console.WriteLine("----------------------------------------");

      int indexTas = 1;
      TaskList.ForEach(taskItem => Console.WriteLine($"{indexTas++}. {taskItem}"));

    }
  }
}
