namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Mapping;

    public class VicLikeService : IVicLikeService
    {
        private readonly IRepository<VicLike> vicLikeRepository;

        public VicLikeService(IRepository<VicLike> vicLikeRepository)
        {
            this.vicLikeRepository = vicLikeRepository;
        }

        public int CountByVicId(int id)
        {
            return this.vicLikeRepository.All()
                .Where(v => v.VicId == id && v.UserLike == true)
                .Count();
        }

        public bool Exists(int vicId, string ipAddress)
        {
            var result = this.vicLikeRepository.All().FirstOrDefault(e => e.VicId == vicId && e.IPAdress == ipAddress);
            return result != null;
        }

        public IEnumerable<T> GetByVicId<T>(int id)
        {
            return this.vicLikeRepository.All()
                .Where(v => v.VicId == id && v.UserLike == true)
                .To<T>()
                .ToList();
        }
    }
}
