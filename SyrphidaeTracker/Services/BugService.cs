using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyrphidaeTracker.Services;

namespace SyrphidaeTracker.Services;

public class BugService: ISyrphidaeTracker
{
    private List<Bug> Bugs = new List<Bug>();

    public void AddBug(Bug newBug)
    {
        newBug.Id = Bugs.Count + 1;
        Bugs.Add(newBug);
    }

    public List<Bug> GetBugs()
    {
        return Bugs;
    }
}
