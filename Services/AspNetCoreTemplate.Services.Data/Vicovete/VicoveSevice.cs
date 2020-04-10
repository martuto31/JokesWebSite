namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;
    using AspNetCoreTemplate.Web.Infrastructure;

    public class VicoveSevice : IVicoveService
    {
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IRepository<VicNaDenq> dailyVicRepository;

        public VicoveSevice(IRepository<Vicove> vicoveRepository, IRepository<VicNaDenq> dailyVicRepository)
        {
            this.vicoveRepository = vicoveRepository;
            this.dailyVicRepository = dailyVicRepository;
        }

        public IRepository<Vicove> VicoveRepository { get; set; }

        public IQueryable<TViewModel> GetLatestVicove<TViewModel>(VicType vicType)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderBy(x => x.CreatedOn)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetNewestVicove<TViewModel>(VicType vicType)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderByDescending(x => x.CreatedOn)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetByMostPoints<TViewModel>(VicType vicType)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderByDescending(x => x.Points)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetByLowestPoints<TViewModel>(VicType vicType)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderBy(x => x.Points)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetAllMostPopular<TViewModel>()
        {
            var vicove = this.vicoveRepository.All()
                .OrderByDescending(x => x.Points)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetAllMostRecent<TViewModel>()
        {
            var vicove = this.vicoveRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<TViewModel>();

            return vicove;
        }

        public VicNaDenq VicNaDenq()
        {
            var vic = this.dailyVicRepository.All()
                .FirstOrDefault(x => x.Day == DateTime.Today);

            return vic;
        }
    }
}
