using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SyrphidaeTracker;
using SyrphidaeTracker.Services;

namespace SyrphidaeTracker.Services
{
    public interface ISyrphidaeTracker
    {
        List<Bug> GetBugs();

        void AddBug(Bug newBug);
    }
}
