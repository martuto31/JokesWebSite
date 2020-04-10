namespace AspNetCoreTemplate.Web.Hubs
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using AspNetCoreTemplate.Data.Common.Repositories;
    using AspNetCoreTemplate.Data.Models;
    using AspNetCoreTemplate.Services.Data.Vicovete;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.SignalR;

    public class MainHub : Hub
    {
        private readonly IRepository<Vicove> vicoveRepository;
        private readonly IVicLikeService vicLikeService;
        private readonly IRepository<VicForReview> vicReviewRepository;
        private readonly IVicForUploadService vicForUploadService;
        private readonly IRepository<Leaderboard> leaderboardRepository;
        private readonly IRepository<Account> accountRepository;

        // private readonly IUserIdProvider userIdProvider;

        // private readonly UserManager<IdentityUser> userManager;
        public MainHub(IRepository<Vicove> vicoveRepository, IVicLikeService vicLikeService, IRepository<VicForReview> vicReviewRepository, IVicForUploadService vicForUploadService, IRepository<Leaderboard> leaderboardRepository, IRepository<Account> accountRepository/*IUserIdProvider userIdProvider,*/ /*UserManager<IdentityUser> userManager*/)
        {
            this.vicoveRepository = vicoveRepository;
            this.vicLikeService = vicLikeService;
            this.vicReviewRepository = vicReviewRepository;
            this.vicForUploadService = vicForUploadService;
            this.leaderboardRepository = leaderboardRepository;
            this.accountRepository = accountRepository;

            // this.userIdProvider = userIdProvider;
            // this.userManager = userManager;
        }

        public async Task Like(int vicId)
        {
            var currentVic = this.vicoveRepository.All()
                 .FirstOrDefault(x => x.Id == vicId);

            string userName = currentVic.Creator;

            var currentUser = this.leaderboardRepository.All()
                .FirstOrDefault(x => x.UserName == userName);

            var currentAcc = this.accountRepository.All()
                .FirstOrDefault(x => x.User == userName);

            var user = new Leaderboard()
            {
                UserName = userName,
                Email = userName,
                Points = 0,
            };

            if (currentUser == null)
            {
                await this.leaderboardRepository.AddAsync(user);
                await this.leaderboardRepository.SaveChangesAsync();
            }

            currentUser = this.leaderboardRepository.All()
                .FirstOrDefault(x => x.UserName == userName);

            // var ip = this.Context.GetHttpContext().Connection.RemoteIpAddress.ToString();
            var ip = this.Context.GetHttpContext().Connection.LocalIpAddress.ToString();

            // var currentUser = await this.userManager.GetUserAsync(this.Context.User);

            // this.userIdProvider.GetUserId(this.Context.GetHttpContext().Connection)
            var liked = new VicLike
            {
                IPAdress = ip, // currentUser.Id.ToString(),
                VicId = vicId,

                // UserAgent = this.Context.UserIdentifier.ToString(),
                UserLike = true,
                Vic = currentVic,
            };

            // var dupe = this.vicLikeService.GetByVicId<VicLike>(currentVic.Id);
            // currentVic.VicLikes.FirstOrDefault(x => x.VicId == liked.VicId && x.IPAdress == liked.IPAdress);
            bool checkIfExist = this.vicLikeService.Exists(liked.VicId, liked.IPAdress); // VicId.Value
            var check = currentVic?.VicLikes.Where(x => x.VicId == vicId).FirstOrDefault(x => x.IPAdress == liked.IPAdress); // .First
            var asd = 0;
            if (checkIfExist == false)
            {
                currentVic.VicLikes.Add(liked);
                currentUser.Points += 1;
                currentAcc.AllPoints += 1;
                this.accountRepository.Update(currentAcc);
                this.leaderboardRepository.Update(currentUser);
                await this.accountRepository.SaveChangesAsync();
                await this.leaderboardRepository.SaveChangesAsync();
            }
            else if (check.UserLike == false)
            {
                check.UserLike = true;
                currentUser.Points += 1;
                currentAcc.AllPoints += 1;
                this.accountRepository.Update(currentAcc);
                this.leaderboardRepository.Update(currentUser);
                await this.accountRepository.SaveChangesAsync();
                await this.leaderboardRepository.SaveChangesAsync();

                // currentVic.VicLikes.FirstOrDefault(v => v.VicId == liked.Id && v.IPAdress == liked.IPAdress).UserLike = true;
            }
            else
            {
                check.UserLike = false;
                currentUser.Points -= 1;
                currentAcc.AllPoints -= 1;
                this.accountRepository.Update(currentAcc);
                this.leaderboardRepository.Update(currentUser);
                await this.accountRepository.SaveChangesAsync();
                await this.leaderboardRepository.SaveChangesAsync();
            }

            await this.vicoveRepository.SaveChangesAsync();

            var vic = this.vicoveRepository.All()
                .FirstOrDefault(v => v.Id == vicId);

            // var vicLikes = vic.VicLikes.Count(v => v.UserLike);
            var likes = this.vicLikeService.CountByVicId(vicId);

            currentVic.Points = likes;
            await this.vicoveRepository.SaveChangesAsync();
            await this.leaderboardRepository.SaveChangesAsync();

            var check2 = currentVic?.VicLikes.Where(x => x.VicId == vicId).FirstOrDefault(x => x.IPAdress == liked.IPAdress);

            await this.Clients.All.SendAsync("Liked", likes, vicId, check2.UserLike);
        }

        public async Task UploadVic(int vicId)
        {
            var vic = this.vicReviewRepository.All()
                .FirstOrDefault(x => x.Id == vicId);

            var account = this.accountRepository?.All()
                    .FirstOrDefault(u => u.User == vic.User);

            var vicForRealDb = new Vicove()
            {
                Content = vic.Content,
                CreatedOn = vic.CreatedOn,
                Creator = vic.Creator,
                DateTime = vic.DateTime,
                VicType = vic.VicType,
                Points = 0,
                AccountID = account.Id,
            };

            account.Vicove.Add(vicForRealDb);
            account.UploadedVicove += 1;
            this.accountRepository.Update(account);
            await this.accountRepository.SaveChangesAsync();
            await this.vicoveRepository.SaveChangesAsync();

            // vicForRealDb.Account.Vicove.Add(vicForRealDb);
            // await this.vicoveRepository.AddAsync(vicForRealDb);
            // await this.vicoveRepository.SaveChangesAsync();
            // await this.accountRepository.SaveChangesAsync();
            this.vicReviewRepository.Delete(vic);
            await this.vicReviewRepository.SaveChangesAsync();

            await this.Clients.All.SendAsync("Upload", vicId);
        }

        public async Task DeleteVic(int vicId)
        {
            var vic = this.vicReviewRepository.All()
                .FirstOrDefault(x => x.Id == vicId);

            this.vicReviewRepository.Delete(vic);
            await this.vicReviewRepository.SaveChangesAsync();

            await this.Clients.All.SendAsync("Delete", vicId);
        }
    }
}
