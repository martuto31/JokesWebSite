using AspNetCoreTemplate.Data.Common.Repositories;
using AspNetCoreTemplate.Data.Models;
using AspNetCoreTemplate.Services.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AspNetCoreTemplate.Services.Data.MyProfile
{
    public class FavVicoveService : IFavVicoveService
    {
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IRepository<FavouriteVicove> favVicoveRepository;

        public FavVicoveService(
            IRepository<Vicove> vicoveRepository,
            IRepository<FavouriteVicove> favVicoveRepository)
        {
            this.vicoveRepository = vicoveRepository;
            this.favVicoveRepository = favVicoveRepository;
        }

        public IQueryable<TViewModel> GetFavouriteVicove<TViewModel>(int accountId)
        {
            var vicove = this.favVicoveRepository.All()
                .Where(x => x.AccountID == accountId)
                .OrderByDescending(x => x.ModifiedOn)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetMyVicove<TViewModel>(string user)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.Creator == user)
                .OrderByDescending(x => x.CreatedOn)
                .To<TViewModel>();

            return vicove;
        }
    }
}
