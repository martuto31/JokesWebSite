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
        IQueryable<TViewModel> GetLatestVicove<TViewModel>(VicType vicType); // Take, and int count for paging if that doesnt work

        IQueryable<TViewModel> GetNewestVicove<TViewModel>(VicType vicType);

        IQueryable<TViewModel> GetByMostPoints<TViewModel>(VicType vicType);

        IQueryable<TViewModel> GetByLowestPoints<TViewModel>(VicType vicType);

        IQueryable<TViewModel> GetAllMostPopular<TViewModel>();

        public IQueryable<TViewModel> GetAllMostRecent<TViewModel>();
    }
}
