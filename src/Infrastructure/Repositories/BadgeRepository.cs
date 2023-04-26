﻿using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BadgeRepository : Repository<Badge>, IBadgeRepository
    {
        public BadgeRepository(AppDbContext context) : base(context) { }
    }
}
