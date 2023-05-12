﻿using Microsoft.EntityFrameworkCore;
using SB_FMB_Domain.Commons.Repositories;
using SB_FMB_Domain.Data;
using SB_FMB_Domain.Entities;
using SB_FMB_Domain.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace SB_FMB_Domain.Repositories
{
	public class MuminRepository : RepositoryBase<Mumin>, IMuminRepository
	{
		protected readonly FMBDbContext _dbContext;

		public MuminRepository(FMBDbContext dbContext) : base(dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
