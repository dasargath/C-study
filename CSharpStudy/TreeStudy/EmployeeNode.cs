namespace TreeStudy;

public class EmployeeNode
{
    public string Name { get; set; }
    public int Salary { get; set; }
    
    public EmployeeNode Left { get; set; }
    public EmployeeNode Right { get; set; }

    public EmployeeNode(string name, int salary)
    {
        Name = name;
        Salary = salary;
        Left = null;
        Right = null;
    }
}