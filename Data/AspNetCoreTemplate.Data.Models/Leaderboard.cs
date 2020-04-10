namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Leaderboard : BaseModel<int>
    {
        public string UserName { get; set; }

        public string Email { get; set; }

        public int? Points { get; set; }
    }
}
