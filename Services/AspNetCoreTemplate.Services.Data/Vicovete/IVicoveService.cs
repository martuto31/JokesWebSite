namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AspNetCoreTemplate.Web.Infrastructure;

    public interface IVicoveService
    {
        // ako iskame pagirane i controlera da q dovurshi slagame IQuerriable
        IQueryable<TViewModel> GetLatestVicove<TViewModel>(int count = 0);
    }
}
