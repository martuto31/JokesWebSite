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

        public IQueryable<TViewModel> GetLatestVicove<TViewModel>(int count = 10)
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.VicType == VicType.Blondinki)
                .OrderByDescending(x => x.CreatedOn)
                .Take(count)
                .To<TViewModel>();
            return vicove;
        }
    }
}
