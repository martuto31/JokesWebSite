namespace AspNetCoreTemplate.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AspNetCoreTemplate.Data.Common.Models;

    public class Badges : BaseModel<int>
    {
        public BadgeType BadgeType { get; set; }

        public int AccountId { get; set; }

        public Account Account { get; set; }
    }
}
