using CQRS.Application.Contracts.Persistance;
using CQRS.Application.Functions.Categories.Queries.GetCategoriesWithPost;
using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.InfrastructureEF.Repositories
{
    public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(CQRSAppContext dbContext) : base(dbContext)
        {
        }

        //public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchOptions)
        //{
        //    IQueryable<Category> allCategories = _dbContext.Categories.Include(p => p.Posts);

        //    if (searchOptions == SearchCategoryOptions.FirstBestAllTheTime)
        //    {
        //        return await allCategories.ToListAsync();
        //    }
        //    else if (searchOptions == SearchCategoryOptions.FirstBestThisMonth) 
        //    { 
        //        DateTime d = DateTime.Now;
        //        allCategories = allCategories.Where(c =>c.Posts.Any(p=>p.Date.Month == d.Month && p.Date.Year == d.Year));
        //        return await GetOneMaxPost(allCategories);
        //    }

        //    return await allCategories.ToListAsync();

        //}

        //private async Task<List<Category>> GetOneMaxPost(IQueryable<Category> allCategories)
        //{
        //    // Pobieramy najlepszy post dla każdej kategorii w jednym zapytaniu
        //    var result = await allCategories
        //        .Select(c => new Category
        //        {
        //            CategoryId = c.CategoryId,
        //            DisplayName = c.DisplayName,
        //            Name = c.Name,
        //            Posts = c.Posts
        //                .OrderByDescending(p => p.Rate)  // Sortujemy posty w kategorii po ocenie
        //                .Take(1)  // Wybieramy tylko najlepszy post
        //                .ToList()
        //        })
        //        .ToListAsync();

        //    return result;
        //}




        public async Task<List<Category>> GetCategoriesWithPost(SearchCategoryOptions searchOptions)
        {
            // Pobieranie wszystkich kategorii z postami
            var allCategories = await _dbContext.Categories.Include(p => p.Posts).ToListAsync();

            if (searchOptions == SearchCategoryOptions.FirstBestAllTheTime)
            {
                return allCategories;
            }
            else if (searchOptions == SearchCategoryOptions.FirstBestThisMonth)
            {
                DateTime currentDate = DateTime.Now;

                // Filtrowanie kategorii w pamięci, które mają posty z bieżącego miesiąca
                allCategories = allCategories
                    .Where(c => c.Posts.Any(p => p.Date.Month == currentDate.Month && p.Date.Year == currentDate.Year))
                    .ToList();

                // Wybieramy kategorię z najlepszym postem
                return await GetOneMaxPost(allCategories);
            }

            return allCategories;
        }

        private Task<List<Category>> GetOneMaxPost(List<Category> allCategories)
        {
            foreach (var category in allCategories)
            {
                // Wybieramy najlepszy post dla każdej kategorii
                var maxPost = category.Posts.OrderByDescending(p => p.Rate).FirstOrDefault();

                // Nadpisujemy listę postów tylko najlepszym postem
                category.Posts = new List<Post> { maxPost };
            }

            return Task.FromResult(allCategories);
        }
















        //private Task<List<Category>> GetOneMaxPost(IQueryable<Category> allCategories)
        //{
        //    foreach (var category in allCategories) 
        //    {
        //        Post max = null;

        //        foreach (var post in category.Posts) 
        //        {
        //            if (max == null) 
        //            {
        //                max = post;
        //                break;
        //            }
        //            if (max.Rate < post.Rate) 
        //            {
        //                max = post;
        //            }
        //            category.Posts = new List<Post>();
        //            if (max != null) 
        //            { 
        //                category.Posts.Add(max);
        //            }

        //        }
        //    }

        //    return Task.FromResult<List<Category>>([.. allCategories]);
        //}

        //private async Task<List<Category>> GetOneMaxPost(IQueryable<Category> allCategories)
        //{
        //    // Pobieramy najlepszy post dla każdej kategorii w jednym zapytaniu
        //    var result = await allCategories
        //        .Select(c => new Category
        //        {
        //            CategoryId = c.CategoryId,
        //            DisplayName = c.DisplayName,
        //            Name = c.Name,
        //            Posts = c.Posts
        //                .OrderByDescending(p => p.Rate)  // Sortujemy posty w kategorii po ocenie
        //                .Take(1)  // Wybieramy tylko najlepszy post
        //                .ToList()
        //        })
        //        .ToListAsync();

        //    return result;
        //}

    }
}
