using System;
using System.Collections.Generic;

public class Projects
{

    private List<Challenges> Challenges = new List<Challenges>();
    public string Name { get; }
    public DateTime Time; 
    private int CountProject;
    public Projects(string name, DateTime time)
    {
        Name = name;
        Time = time;
    }
}
