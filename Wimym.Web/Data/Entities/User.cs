﻿namespace Wimym.Web.Data.Entities
{
    using System;
    public class User
    {

        public virtual DateTimeOffset? LockoutEnd { get; set; }

        public virtual bool TwoFactorEnabled { get; set; }

        public virtual bool PhoneNumberConfirmed { get; set; }

        public virtual string PhoneNumber { get; set; }

        public virtual string ConcurrencyStamp { get; set; }

        public virtual string SecurityStamp { get; set; }

        public virtual string PasswordHash { get; set; }

        public virtual bool EmailConfirmed { get; set; }

        public virtual string NormalizedEmail { get; set; }

        public virtual string Email { get; set; }

        public virtual string NormalizedUserName { get; set; }

        public virtual string UserName { get; set; }

        public virtual string Id { get; set; }

        public virtual bool LockoutEnabled { get; set; }

        public virtual int AccessFailedCount { get; set; }

        public string Rol { get; set; }

        public string RolId { get; set; }

        //[JsonIgnore]
        //public virtual ICollection<Wallet> Wallets { get; set; }

    }
}
