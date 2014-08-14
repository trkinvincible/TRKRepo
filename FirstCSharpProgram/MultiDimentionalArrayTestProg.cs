using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FirstCSharpProgram
{
    public class Student
    {
        public String m_name;
        public Int32 m_matrixNo;
    }
    public class Marks
    {
        public Int32 m_CAmark;
        public Int32 m_WrittenTestMark;
    }
    class MultiDimentionalArrayTestProg
    {
        static void Main()
        {
            List<Student> studentObj = new List<Student>
            {
                new Student() {m_name = "Radhakrishnan" , m_matrixNo = 0122992},
                new Student() {m_name = "Parthi" , m_matrixNo = 0122993}
            };
            List<Marks> marksObj = new List<Marks>
            {
                new Marks() {m_CAmark = 20 , m_WrittenTestMark = 80},
                new Marks() {m_CAmark = 20 , m_WrittenTestMark = 80}
            };
            System.Collections.Hashtable tableDisplay = new System.Collections.Hashtable();
            tableDisplay.Add(" "," ");
            String[] subjects = { "Programing","OOAD","Software Engg"};

            Int32 i = 0;
            Console.Write("\t\t");
            while (subjects.GetLength(0) > i)
            {
                Console.Write("{0}\t",subjects[i]);
                i++;
            }
            Console.Write("\n-------------------------------------------------------\n");
            i = 0;
            Int32 count = studentObj.Count;
            while (count > i)
            {
                tableDisplay.Add((studentObj.ElementAt(i)).m_matrixNo,(studentObj.ElementAt(i)).m_name);
                Console.WriteLine("{0}\t", tableDisplay[(studentObj.ElementAt(i)).m_matrixNo]);
                i++;
            }
            Console.Write("-------------------------------------------------------");
            Console.ReadKey(true);
        }
    }
}
