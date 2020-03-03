namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Web.Infrastructure;

    public interface IVicoveService
    {
        // ako iskame pagirane i controlera da q dovurshi slagame IQuerriable
        IQueryable<TViewModel> GetLatestVicove<TViewModel>(VicType vicType, int count = 0);

        IQueryable<TViewModel> GetNewestVicove<TViewModel>(VicType vicType, int count);

        IQueryable<TViewModel> GetByMostPoints<TViewModel>(VicType vicType, int count);

        IQueryable<TViewModel> GetByLowestPoints<TViewModel>(VicType vicType, int count);

        IQueryable<TViewModel> GetAllMostPopular<TViewModel>(int count);

        public IQueryable<TViewModel> GetAllMostRecent<TViewModel>(int count);
    }
}
