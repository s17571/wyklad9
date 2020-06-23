using LinqCwiczenia.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LinqCwiczenia
{
    public partial class Form1 : Form
    {
        public IEnumerable<Emp> Emps { get; set; }
        public IEnumerable<Dept> Depts { get; set; }

        public Form1()
        {
            InitializeComponent();
            LoadData();

            //1. Extension methods
            string str = "s1234";
            if (str.IsPjatkIndex())
            {

            }

            //2. Anonymous types
            var anon = new
            {
                FirstName="Jan",
                LastName="Kowalski"
            };

            List<int> nums2 = new List<int>() { 3, 4, 2, 3, 1, 2, 3 };
            var res = nums2.Filter(i => i % 2 == 0);
        }

        public static bool sdialjmlmaldakmdlsamdka(int i)
        {
            return i % 2 == 1;
        }

        private void LoadData()
        {
            var empsCol = new List<Emp>();
            var deptsCol = new List<Dept>();

            #region Load depts
            var d1 = new Dept
            {
                Deptno = 1,
                Dname = "Research",
                Loc = "Warsaw"
            };

            var d2 = new Dept
            {
                Deptno = 2,
                Dname = "Human Resources",
                Loc = "New York"
            };

            var d3 = new Dept
            {
                Deptno = 3,
                Dname = "IT",
                Loc = "Los Angeles"
            };

            deptsCol.Add(d1);
            deptsCol.Add(d2);
            deptsCol.Add(d3);
            Depts = deptsCol;
            #endregion

            #region Load emps
            var e1 = new Emp
            {
                Deptno = 1,
                Empno = 1,
                Ename = "Jan Kowalski",
                HireDate = DateTime.Now.AddMonths(-5),
                Job = "Backend programmer",
                Mgr = null,
                Salary = 2000
            };

            var e2 = new Emp
            {
                Deptno = 1,
                Empno = 20,
                Ename = "Anna Malewska",
                HireDate = DateTime.Now.AddMonths(-7),
                Job = "Frontend programmer",
                Mgr = e1,
                Salary = 4000
            };

            var e3 = new Emp
            {
                Deptno = 1,
                Empno = 2,
                Ename = "Marcin Korewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Frontend programmer",
                Mgr = null,
                Salary = 5000
            };

            var e4 = new Emp
            {
                Deptno = 2,
                Empno = 3,
                Ename = "Paweł Latowski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Frontend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e5 = new Emp
            {
                Deptno = 2,
                Empno = 4,
                Ename = "Michał Kowalski",
                HireDate = DateTime.Now.AddMonths(-2),
                Job = "Backend programmer",
                Mgr = e2,
                Salary = 5500
            };

            var e6 = new Emp
            {
                Deptno = 2,
                Empno = 5,
                Ename = "Katarzyna Malewska",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Manager",
                Mgr = null,
                Salary = 8000
            };

            var e7 = new Emp
            {
                Deptno = null,
                Empno = 6,
                Ename = "Andrzej Kwiatkowski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "System administrator",
                Mgr = null,
                Salary = 7500
            };

            var e8 = new Emp
            {
                Deptno = 2,
                Empno = 7,
                Ename = "Marcin Polewski",
                HireDate = DateTime.Now.AddMonths(-3),
                Job = "Mobile developer",
                Mgr = null,
                Salary = 4000
            };

            var e9 = new Emp
            {
                Deptno = 2,
                Empno = 8,
                Ename = "Władysław Torzewski",
                HireDate = DateTime.Now.AddMonths(-9),
                Job = "CTO",
                Mgr = null,
                Salary = 12000
            };

            var e10 = new Emp
            {
                Deptno = 2,
                Empno = 9,
                Ename = "Andrzej Dalewski",
                HireDate = DateTime.Now.AddMonths(-4),
                Job = "Database administrator",
                Mgr = null,
                Salary = 9000
            };

            empsCol.Add(e1);
            empsCol.Add(e2);
            empsCol.Add(e3);
            empsCol.Add(e4);
            empsCol.Add(e5);
            empsCol.Add(e6);
            empsCol.Add(e7);
            empsCol.Add(e8);
            empsCol.Add(e9);
            empsCol.Add(e10);
            Emps = empsCol;
            ResultsDataGridView.DataSource = Emps;

            #endregion
        }

        private void ResetButton_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        /*
            Celem ćwiczenia jest uzupełnienie poniższych metod.
         *  Każda metoda powinna zawierać kod C#, który z pomocą LINQ'a będzie realizować
         *  zapytania opisane za pomocą SQL'a.
         *  Rezultat zapytania powinien zostać wyświetlony za pomocą kontrolki DataGrid.
         *  W tym celu końcowy wynik należy rzutować do Listy (metoda ToList()).
         *  Jeśli dane zapytanie zwraca pojedynczy wynik możemy je wyświetlić w kontrolce
         *  TextBox WynikTextBox.
        */

        /// <summary>
        /// SELECT * FROM Emps WHERE Job = "Backend programmer";
        /// </summary>
        private void Przyklad_1(object sender, EventArgs e)
        {
            //1. Query syntax (SQL)
            var res1 = from emp in Emps
                       where emp.Job == "Backend programmer"
                       select new
                       {
                           Ename = emp.Ename,
                           Job = emp.Job,
                           Salary = emp.Salary,
                           Mgr = emp.Mgr,
                           HireDate=emp.HireDate
                       };
            //2. Lambda and Extension methods
            var res2 = Emps
                .Where(emp1 => emp1.Job == "Backend programmer")
                .Select(emp => new { emp.Ename, emp.Job, emp.Salary, emp.Mgr, emp.HireDate });

            ResultsDataGridView.DataSource = res1.ToList();
        }

        /// <summary>
        /// SELECT * FROM Emps Job = "Frontend programmer" AND Salary>1000 ORDER BY Ename DESC;
        /// </summary>
        private void Przyklad_2(object sender, EventArgs e)
        {
            var res1 = from emp in Emps
                        join dept in Depts on emp.Deptno equals dept.Deptno
                        where emp.Job == "Frontend programmer" && emp.Salary > 1000
                        orderby emp.Ename descending
                        select emp;

            var res2 = Emps
                        .Where((emp, indx) => emp.Job == "Frontend programmer" && emp.Salary > 1000)
                        .OrderByDescending(emp => emp.Ename)
                        .Select(emp => new
                        {
                            emp.Ename,
                            emp.Salary,
                            LiczbaDept=Depts.Count()
                        });

            ResultsDataGridView.DataSource = res1.ToList();
        }

        /// <summary>
        /// SELECT MAX(Salary) FROM Emps;
        /// </summary>
        private void Przyklad_3(object sender, EventArgs e)
        {
            var maxSal1 = (from emp in Emps select emp.Salary).Max();

            var maxSal2 = Emps.Max(emp => emp.Salary);

        }
        /// <summary>
        /// SELECT * FROM Emps WHERE Salary=(SELECT MAX(Salary) FROM Emps);
        /// </summary>
        public void Przyklad_4()
        {
            var res1 = from emp in Emps
                       where emp.Salary == (from emp1 in Emps select emp1.Salary).Max()
                       select new
                       {
                          Ename = emp.Ename,
                          Job = emp.Job,
                          Salary = emp.Salary,
                          Mgr = emp.Mgr,
                          HireDate = emp.HireDate
                       };
            var res2 = Emps
                        .Where(emp => emp.Salary == Emps.Max(innerEmp => innerEmp.Salary))
                        .Select(emp => new { emp.Ename, emp.Job, emp.Salary, emp.HireDate, emp.Mgr });
        }

        /// <summary>
        /// SELECT ename AS Nazwisko, job AS Praca FROM Emps;
        /// </summary>
        public void Przyklad5()
        {
            //1. Query syntax (SQL)
            var res1 = from emp in Emps
                       select new
                       {
                          Nazwisko = emp.Ename,
                          Praca = emp.Job
                       };

            //2. Lambda and Extension methods
            var res2 = Emps.Select(emp => new { Nazwisko = emp.Ename, Praca = emp.Job });
        }

        /// <summary>
        /// SELECT Emps.Ename, Emps.Job, Depts.Dname FROM Emps
        /// INNER JOIN Depts ON Emps.Deptno=Depts.Deptno
        /// Rezultat: Złączenie kolekcji Emps i Depts.
        /// </summary>
        public void Przyklad6()
        {
            var res1 = from emp in Emps
                       join dep in Depts on emp.Deptno equals dep.Deptno
                       select new
                       {
                          Ename = emp.Ename,
                          Job = emp.Job,
                          Dname = dep.Dname
                       };

            var res2 = Emps
                        .Join(Depts, emp => emp.Deptno, dep => dep.Deptno, (emp, dep) => new { Dep = dep, Emp = emp })
                        .Select(empAndDep => new {
                            Dname = empAndDep.Dep.Dname,
                            Ename = empAndDep.Emp.Ename,
                            Job = empAndDep.Emp.Job
                        });
        }

        /// <summary>
        /// SELECT Job AS Praca, COUNT(1) LiczbaPracownikow FROM Emps GROUP BY Job;
        /// </summary>
        public void Przyklad7()
        {
            var res1 = from emp in Emps
                       group emp by emp.Job into grouping
                       select new
                       {
                          praca = grouping.Key,
                          LiczbaPracownikow = grouping.Count()
                       };

            var res2 = Emps.GroupBy(emp => emp.Job).Select(group => new{praca = group.Key, LiczbaPracownikow = group.Count()});
        }

        /// <summary>
        /// Zwróć wartość "true" jeśli choć jeden
        /// z elementów kolekcji pracuje jako "Backend programmer".
        /// </summary>
        public void Przyklad8()
        {
            var isBackend1 = (from emp 
                              in Emps 
                              where emp.Job == "Backend programmer" 
                              select (new{emp})).Any();

            var isBackend2 = Emps.Any(emp => emp.Job == "Backend programmer");
        }

        /// <summary>
        /// SELECT TOP 1 * FROM Emp WHERE Job="Frontend programmer"
        /// ORDER BY HireDate DESC;
        /// </summary>
        public void Przyklad9() {
            var res1 = (from emp 
                        in Emps 
                        where emp.Job == "Frontend programmer" 
                        orderby emp.HireDate 
                        descending select new{
                            Ename = emp.Ename,
                            Job = emp.Job,
                            Salary = emp.Salary,
                            Mgr = emp.Mgr,
                            HireDate = emp.HireDate
                        }).Take(1);

            var res2 = Emps
                        .Where(emp => emp.Job == "Frontend programmer")
                        .OrderByDescending(emp => emp.HireDate)
                        .Take(1)
                        .Select(emp => new { 
                            emp.Ename, 
                            emp.Job, 
                            emp.Salary, 
                            emp.Mgr, 
                            emp.HireDate
                        });
        }

        /// <summary>
        /// SELECT Ename, Job, Hiredate FROM Emps
        /// UNION
        /// SELECT "Brak wartości", null, null;
        /// </summary>
        public void Przyklad10()
        {
            var res1 = from emp 
                       in Emps.Union(new List<Emp>() 
                       { new Emp 
                       { 
                           Ename = "Brak wartości", 
                           Job = null, 
                           HireDate = null 
                       } 
                       }) select new
                       {
                          Ename = emp.Ename,
                          Job = emp.Job,
                          Hiredate = emp.HireDate
                       };

            var res2 = Emps.Union(new List<Emp>{new Emp {
                Ename="Brak wartości", 
                Job = null,
                HireDate = null }})
                .Select(emp => new
                {
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Hiredate = emp.HireDate
                });
        }

        //Znajdź pracownika z najwyższą pensją wykorzystując metodę Aggregate()
        public void Przyklad11()
        {
            var res1 = (from emp 
                        in Emps
                        select new
                        {
                            Ename = emp.Ename,
                            Job = emp.Job,
                            Salary = emp.Salary,
                            Mgr = emp.Mgr,
                            HireDate = emp.HireDate
                        }).Aggregate((emp1, emp2) => emp1.Salary < emp2.Salary ? emp2 : emp1);

            var res2 = Emps
                .Select(emp => new {
                    Ename = emp.Ename,
                    Job = emp.Job,
                    Salary = emp.Salary,
                    Mgr = emp.Mgr,
                    HireDate = emp.HireDate
                })
                .Aggregate((emp1, emp2) => emp1.Salary > emp2.Salary ? emp1 : emp2);
        }

        //Z pomocą języka LINQ i metody SelectMany wykonaj złączenie
        //typu CROSS JOIN
        public void Przyklad12()
        {
           var res = Emps.SelectMany(dep => Depts, (x, y) => new {x.Ename, y.Dname});
        }
    }
}