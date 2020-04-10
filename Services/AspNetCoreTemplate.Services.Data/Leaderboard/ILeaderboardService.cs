namespace AspNetCoreTemplate.Services.Data.Leaderboard
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ILeaderboardService
    {
        public IQueryable<TViewModel> ShowAll<TViewModel>();
    }
}
