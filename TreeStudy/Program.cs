namespace TreeStudy
{



    public class Program
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                EmployeeTree tree = new EmployeeTree();
                Console.WriteLine("Введите данные о сотруднике(имя и зарплату). Закончить ввод данных - пустая строка");

                while (true)
                {
                    Console.WriteLine("Введите имя сотрудника: ");
                    string name = Console.ReadLine();
                    
                    if (CheckForExit(name)) return;

                    if (string.IsNullOrEmpty(name))
                    {
                        Console.WriteLine("Поле ввода должно быть словом или буквой.");
                        break;
                    }

                    Console.WriteLine("Введите зарплату сотрудника: ");


                    string salaryInput = Console.ReadLine();

                    if (CheckForExit(salaryInput)) return;

                    int salary;

                    if (!int.TryParse(salaryInput, out salary) || salary <= 0)
                    {
                        Console.WriteLine("Поле ввода должно быть числом больше 0.");
                        continue;
                    }

                    tree.InsertNode(name, salary);

                }

                Console.WriteLine("Сотрудники в порядке возрастания зарплат: ");
                tree.TraverseInOrder();

                while (true)
                {
                    Console.WriteLine("Введите зарплату для поиска: ");

                    string salaryInput = Console.ReadLine();
                    if (CheckForExit(salaryInput)) return;

                    int salary;
                    if (!int.TryParse(salaryInput, out salary))
                    {
                        Console.WriteLine("Некорректный ввод цифр зарплаты.");
                        continue;
                    }

                    string result = tree.SearchBySalary(salary);
                    Console.WriteLine(result);

                    Console.WriteLine("Введите 0 для повторного ввода сотрудников или 1 для повторного поиска: ");

                    string userInput = Console.ReadLine();
                    if (CheckForExit(userInput)) return;

                    int input;

                    if (!int.TryParse(userInput, out input))
                    {
                        Console.WriteLine("Введите 0 или 1.");
                        continue;
                    }


                    if (input == 0)
                    {
                        break;
                    }
                    else if (input == 1)
                    {
                        continue;
                    }
                    else if (input == -1)
                    {

                    }
                }
            }
        }

        private static bool CheckForExit(string userInput)
        {
            if (userInput?.ToLower() == "exit")
            {
                Console.WriteLine("Выполняю выход из программы...");
                return true;
            }

            return false;
        }
    }
}    