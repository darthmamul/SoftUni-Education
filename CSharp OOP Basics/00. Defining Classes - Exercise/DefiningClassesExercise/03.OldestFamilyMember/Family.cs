using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


public class Family
{
    List<Person> members;

    public Family()
    {
        members = new List<Person>();
    }

    public void AddMember(Person member)
    {
        members.Add(member);
    }

    public Person GetOldestMember()
    {
        return members.OrderByDescending(m => m.Age).FirstOrDefault();
    }
}

