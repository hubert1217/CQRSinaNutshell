
namespace CQRS.Application.Functions.Webinars.Queries.GetWebinarListByDate
{
    public class PageWebinarByDateViewModel
    {
        public int AllCount { get; set; }
        public List<WebinarsByDateViewModel> Webinars { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

    }
}