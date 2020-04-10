namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Linq;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class VicForUploadService : IVicForUploadService
    {
        private readonly IRepository<VicForReview> vicReviewRepository;

        public VicForUploadService(IRepository<VicForReview> vicReviewRepository)
        {
            this.vicReviewRepository = vicReviewRepository;
        }

        public IQueryable<TViewModel> GetAllForUpload<TViewModel>()
        {
            var vicove = this.vicReviewRepository.All()
                .OrderByDescending(x => x.CreatedOn)
                .To<TViewModel>();

            return vicove;
        }
    }
}
