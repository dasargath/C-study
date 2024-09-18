

namespace TreeStudy;

public class EmployeeTree
{
    public EmployeeNode Root { get; set; }

    public void InsertNode(string name, int salary)
    {
        Root = InsertNodeRecursive(Root, name, salary);
    }

    private EmployeeNode InsertNodeRecursive(EmployeeNode root, string name, int salary)
    {
        if (root == null)
        {
            root = new EmployeeNode(name, salary);
            return root;
        }

        if (salary < root.Salary)
        {
            root.Left = InsertNodeRecursive(root.Left, name, salary);
        }
        else if (salary > root.Salary)
        {
            root.Right = InsertNodeRecursive(root.Right, name, salary);
        }
        return root;
    }

    public void TraverseInOrder()
    {
        TraverseInOrderRecursive(Root);
    }

    private void TraverseInOrderRecursive(EmployeeNode root)
    {
        if (root != null)
        {
            TraverseInOrderRecursive(root.Left);
            Console.WriteLine($"{root.Name} - {root.Salary}");
            TraverseInOrderRecursive(root.Right);
        }
    }

    public string SearchBySalary(int salary)
    {
        EmployeeNode result = SearchBySalaryRecursive(Root, salary);
        if (result == null)
            return "Сотрудник не найден.";
        return $"Сотрудник {result.Name} с зарплатой {salary}";
    }

    private EmployeeNode SearchBySalaryRecursive(EmployeeNode root, int salary)
    {
        if (root == null || root.Salary == salary)
            return root;
        if (salary < root.Salary)
            return SearchBySalaryRecursive(root.Left, salary);
        return SearchBySalaryRecursive(root.Right, salary);
    }
    
}