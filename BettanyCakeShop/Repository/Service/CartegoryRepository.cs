using BettanyCakeShop.DBContext;
using BettanyCakeShop.Models;
using BettanyCakeShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettanyCakeShop.Repository.Service
{
    public class CartegoryRepository : ICategoryRepository
    {
        private readonly AppDbContext _appDbContext;

        public CartegoryRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public IEnumerable<Category> AllCategories => _appDbContext.Categories;
    }
}
