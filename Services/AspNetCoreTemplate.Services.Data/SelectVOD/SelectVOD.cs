namespace AspNetCoreTemplate.Services.Data.SelectVOD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class SelectVOD : ISelectVOD
    {
        private readonly IRepository<Vicove> vicoveRepository;

        public SelectVOD(IRepository<Vicove> vicoveRepository)
        {
            this.vicoveRepository = vicoveRepository;
        }

        public IQueryable<TViewModel> GetAllFromToday<TViewModel>()
        {
            var vicove = this.vicoveRepository.All()
                .Where(x => x.CreatedOn.Date == DateTime.UtcNow.Date)
                .To<TViewModel>();

            return vicove;
        }
    }
}
