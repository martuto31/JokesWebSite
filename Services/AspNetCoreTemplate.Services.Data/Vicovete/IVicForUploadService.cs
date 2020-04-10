namespace AspNetCoreTemplate.Services.Data.Vicovete
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface IVicForUploadService
    {
        public IQueryable<TViewModel> GetAllForUpload<TViewModel>();
    }
}
