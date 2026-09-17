using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StudentManagementLINQ
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Thiết lập hiển thị và nhập Tiếng Việt có dấu trên Console
            Console.OutputEncoding = Encoding.UTF8;
            Console.InputEncoding = Encoding.UTF8;

            // 1. Tạo danh sách rỗng để lưu học sinh
            List<Student> studentList = new List<Student>();

            // 2. Tự nhập thông tin 5 học sinh từ bàn phím
            Console.WriteLine("=== NHẬP THÔNG TIN 5 HỌC SINH ===");
            for (int i = 1; i <= 5; i++)
            {
                Console.WriteLine($"\n--- Nhập học sinh thứ {i} ---");

                // Nhập Mã số (Id)
                int id;
                while (true)
                {
                    Console.Write("Nhập Id: ");
                    if (int.TryParse(Console.ReadLine(), out id) && id > 0)
                    {
                        if (studentList.Any(s => s.Id == id))
                        {
                            Console.WriteLine("-> Lỗi: Id này đã tồn tại! Vui lòng nhập lại.");
                            continue;
                        }
                        break;
                    }
                    Console.WriteLine("-> Lỗi: Id phải là số nguyên dương!");
                }

                // Nhập Họ và Tên (Name)
                string name;
                while (true)
                {
                    Console.Write("Nhập Họ và Tên: ");
                    name = Console.ReadLine()?.Trim();
                    if (!string.IsNullOrEmpty(name))
                        break;
                    Console.WriteLine("-> Lỗi: Tên không được để trống!");
                }

                // Nhập Tuổi (Age)
                int age;
                while (true)
                {
                    Console.Write("Nhập Tuổi: ");
                    if (int.TryParse(Console.ReadLine(), out age) && age > 0)
                        break;
                    Console.WriteLine("-> Lỗi: Tuổi phải là số nguyên dương!");
                }

                // Thêm vào danh sách
                studentList.Add(new Student(id, name, age));
            }

            Console.WriteLine("\n-> Đã nhập xong dữ liệu! Bắt đầu thực hiện các yêu cầu LINQ...\n");

            Console.WriteLine("================ QUẢN LÝ HỌC SINH BẰNG LINQ ================\n");

            // a. In danh sách toàn bộ học sinh
            Console.WriteLine("--- a. Danh sách toàn bộ học sinh ---");
            PrintHeader();
            studentList.ForEach(s => s.Display());
            PrintSeparator();

            // b. Tìm và in ra danh sách các học sinh có tuổi từ 15 đến 18
            Console.WriteLine("\n--- b. Danh sách học sinh có tuổi từ 15 đến 18 ---");
            var age15To18 = studentList.Where(s => s.Age >= 15 && s.Age <= 18);
            PrintHeader();
            foreach (var student in age15To18)
            {
                student.Display();
            }
            PrintSeparator();

            // c. Tìm và in ra học sinh có tên bắt đầu bằng chữ "A"
            Console.WriteLine("\n--- c. Danh sách học sinh có tên bắt đầu bằng chữ 'A' ---");
            var startsWithA = studentList.Where(s => s.Name.StartsWith("A", StringComparison.OrdinalIgnoreCase));
            PrintHeader();
            foreach (var student in startsWithA)
            {
                student.Display();
            }
            PrintSeparator();

            // d. Tính tổng tuổi của tất cả học sinh trong danh sách
            Console.WriteLine("\n--- d. Tổng tuổi của tất cả học sinh ---");
            int totalAge = studentList.Sum(s => s.Age);
            Console.WriteLine($"--> Tổng số tuổi: {totalAge} tuổi.");

            // e. Tìm và in ra học sinh có tuổi lớn nhất
            Console.WriteLine("\n--- e. Danh sách học sinh có tuổi lớn nhất ---");
            int maxAge = studentList.Max(s => s.Age);
            var oldestStudents = studentList.Where(s => s.Age == maxAge);
            PrintHeader();
            foreach (var student in oldestStudents)
            {
                student.Display();
            }
            PrintSeparator();

            // f. Sắp xếp danh sách học sinh theo tuổi tăng dần và in ra danh sách sau khi sắp xếp
            Console.WriteLine("\n--- f. Danh sách học sinh sắp xếp theo tuổi tăng dần ---");
            var sortedByAge = studentList.OrderBy(s => s.Age);
            PrintHeader();
            foreach (var student in sortedByAge)
            {
                student.Display();
            }
            PrintSeparator();

            Console.WriteLine("\nNhấn phím bất kỳ để thoát chương trình...");
            Console.ReadKey();
        }

        #region Helper Methods (Hỗ trợ định dạng giao diện)
        private static void PrintHeader()
        {
            Console.WriteLine("--------------------------------------------------");
            Console.WriteLine("{0,-10} | {1,-25} | {2,-10}", "Mã Số", "Họ Và Tên", "Tuổi");
            Console.WriteLine("--------------------------------------------------");
        }

        private static void PrintSeparator()
        {
            Console.WriteLine("--------------------------------------------------");
        }
        #endregion
    }
}