namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public interface IVicLikeService
    {
        public IEnumerable<T> GetByVicId<T>(int id);

        public bool Exists(int vicId, string ipAdress);

        public int CountByVicId(int id);
    }
}
