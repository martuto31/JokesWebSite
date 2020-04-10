namespace AspNetCoreTemplate.Services.Data.SelectVOD
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public interface ISelectVOD
    {
        IQueryable<TViewModel> GetAllFromToday<TViewModel>();
    }
}
