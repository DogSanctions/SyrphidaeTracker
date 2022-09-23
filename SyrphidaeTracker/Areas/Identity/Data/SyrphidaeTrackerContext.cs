using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SyrphidaeTracker.Areas.Identity.Data;

namespace SyrphidaeTracker.Data;

public class SyrphidaeTrackerContext : IdentityDbContext<SyrphidaeTrackerUser>
{
    public SyrphidaeTrackerContext(DbContextOptions<SyrphidaeTrackerContext> options)
        : base(options)
    {
    }
}
