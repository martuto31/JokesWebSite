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

        public VicoveSevice(IRepository<Vicove> vicoveRepository)
        {
            this.vicoveRepository = vicoveRepository;
        }

        public IRepository<Vicove> VicoveRepository { get; set; }

        public IQueryable<TViewModel> GetLatestVicove<TViewModel>(VicType vicType, int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderBy(x => x.CreatedOn)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetNewestVicove<TViewModel>(VicType vicType, int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderByDescending(x => x.CreatedOn)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetByMostPoints<TViewModel>(VicType vicType, int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderByDescending(x => x.Points)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetByLowestPoints<TViewModel>(VicType vicType, int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == vicType)
                .OrderBy(x => x.Points)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetAllMostPopular<TViewModel>(int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .OrderByDescending(x => x.Points)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }

        public IQueryable<TViewModel> GetAllMostRecent<TViewModel>(int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .OrderBy(x => x.CreatedOn)
                .Take(count)
                .To<TViewModel>();

            return vicove;
        }
    }
}
