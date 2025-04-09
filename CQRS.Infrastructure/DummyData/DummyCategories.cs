using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.InfrastructureEF.DummyData
{
    public static class DummyCategories
    {
        public static List<Category> Get() 
        {
            return new List<Category>
            {
                new Category
                {
                    CategoryId=1,
                    Name = "Kategoria 1",
                    DisplayName = "Kategoria 1"
                },
                new Category
                {
                    CategoryId=1,
                    Name = "Kategoria 2",
                    DisplayName = "Kategoria 2"
                },
                new Category
                {
                    CategoryId=1,
                    Name = "Kategoria 3",
                    DisplayName = "Kategoria 3"
                },
                new Category
                {
                    CategoryId=1,
                    Name = "Kategoria 4",
                    DisplayName = "Kategoria 4"
                }

            };
        }
    }
}
