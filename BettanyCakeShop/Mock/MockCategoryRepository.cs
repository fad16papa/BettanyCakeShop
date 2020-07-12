using BettanyCakeShop.Models;
using BettanyCakeShop.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BettanyCakeShop.Mock
{
    public class MockCategoryRepository : ICategoryRepository
    {
        public IEnumerable<Category> AllCategories => new List<Category>
        { 
            new Category{ CategoryId=1, CategoryName="Fruit Pies", Description="All-fruity pies" },
            new Category{ CategoryId=2, CategoryName="Chesse cakes", Description="Chessy all the way" },
            new Category{ CategoryId=3, CategoryName="Seasonal pies", Description="Get in the mood for a seasonal pies" }
        };
    }
}
