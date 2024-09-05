using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
namespace StudentDB
{
    class Program
    {

        //Retrieving data
        public static void GetStudent(out Student[] studarr)
        {
            Connection conn = new Connection();
            DataTable DT = conn.QueryDdata();
            int rowCount = DT.Rows.Count;
            studarr = new Student[rowCount];

            for (int i = 0; i < rowCount;i++)
            {
                studarr[i] = new Student();
                studarr[i].StudentName = (string)DT.Rows[i]["Stu_name"];
                studarr[i].StudentAge = (int)DT.Rows[i]["Stu_age"];
                studarr[i].StudentAverage = Convert.ToDouble(DT.Rows[i]["Stu_average"]);
                studarr[i].StudentPassword = (string)DT.Rows[i]["Stu_password"];
            }
        } 

        //Printing all students
        public static string PrintAllStudent(Student[] stuArr)
        {
            string output = "";
            for (int i = 0; i < stuArr.Length;i++)
            {
                output += stuArr[i].showStudent() + "\n";
            }
            return output;
        }

        static void Main(string[] args)
        {
            Student st = new Student();
            Connection conn = new Connection();

            Console.WriteLine("How many students you want to add? ");
            int n = Convert.ToInt32(Console.ReadLine());
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine("Enter a student name: ");
                st.StudentName = Console.ReadLine();


                Console.WriteLine("Enter a student age");
                st.StudentAge = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("Enter a student Average Mark: ");
                st.StudentAverage = Convert.ToDouble(Console.ReadLine());



                conn.InsertStudent(st.StudentName, st.StudentAge, st.StudentAverage, st.getPassword());
                Console.WriteLine("The data has been added!!");

            }

            Console.WriteLine("=================================================================");
            Student[] studArr;
            GetStudent(out studArr);
            Console.WriteLine(String.Format("{0,-5}{1,8}{2,19}{3,21}", "Name", "Age", "Average", "Password"));
            Console.WriteLine(PrintAllStudent(studArr));
            Console.ReadLine();
        }
    }
}
