using System;

namespace StudentManagementLINQ
{
    public class Student
    {
        // Thuộc tính theo đề bài yêu cầu
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        // Constructor không tham số
        public Student() { }

        // Constructor đầy đủ tham số
        public Student(int id, string name, int age)
        {
            this.Id = id;
            this.Name = name;
            this.Age = age;
        }

        // Phương thức hiển thị thông tin học sinh dạng bảng
        public void Display()
        {
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10}", Id, Name, Age);
        }
    }
}