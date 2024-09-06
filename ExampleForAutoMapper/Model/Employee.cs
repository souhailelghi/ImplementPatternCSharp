using ExampleForAutoMapper.Enums;

namespace ExampleForAutoMapper.Model
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public  int Age { get; set; }
        public double Amount { get; set; }
        public TypeEmployee TypeEmployee { get; set; }
    }

   
}
