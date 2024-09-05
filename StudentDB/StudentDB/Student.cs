using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentDB
{
    class Student
    {
        string name;
        int age;
        double average;
        string password;

        public string StudentName
        {
            get { return name; }
            set {name=value; }
        }

        public int StudentAge
        {
            get { return age; }
            set { age = value; }
        }

        public double StudentAverage
        {
            get { return average; }
            set { average = value; }
        }

        public string StudentPassword
        {
            get { return password; }
            set { password = value; }
        }

        public string getPassword()
        {
            return name.Substring(0, 3) + age / 10 + age % 10;
        }

        public string showStudent()
        {
            return name + "\t" + age + "\t" + average + "\t" + getPassword();
        }
    }
}
