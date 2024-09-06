using ExampleForAutoMapper.Enums;

namespace ExampleForAutoMapper.Dto
{
    public class EmployeeDto
    {
        public int IdDto { get; set; }
        public string NameDto { get; set; }
        public int AgeDto { get; set; }
        public double AmountDto { get; set; }
        public TypeEmployee TypeEmployeeDto { get; set; }
    }
}
