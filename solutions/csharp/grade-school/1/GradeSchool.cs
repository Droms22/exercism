using System;
using System.Linq;
using System.Collections.Generic;

public class GradeSchool
{
    public Dictionary<string,int> students;

    public GradeSchool()
    {
        students = new();
    }

    public bool Add(string student, int grade) => students.TryAdd(student, grade);

    public IEnumerable<string> Roster() => students.OrderBy(s => s.Value).ThenBy(s => s.Key).Select(s => s.Key);

    public IEnumerable<string> Grade(int grade) => students.Where(s => s.Value == grade).OrderBy(s => s.Key).Select(s => s.Key);
}