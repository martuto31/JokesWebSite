namespace AspNetCoreTemplate.Services.Data.MyProfile
{
    using System.Linq;

    using AspNetCoreTemplate.Data.Models;

    public interface IFavVicoveService
    {
        IQueryable<TViewModel> GetFavouriteVicove<TViewModel>(int accountId);

        IQueryable<TViewModel> GetMyVicove<TViewModel>(string user);
    }
}
