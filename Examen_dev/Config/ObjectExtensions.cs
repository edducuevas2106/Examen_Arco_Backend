using PagedList;

namespace Examen_dev.Config
{
    public static partial class ObjectExtensions
    {
        public static ClassPagination<T> ConvertClassPaginationByPagedList<T>(this IPagedList<T> pagedList)
        {
            var r = pagedList.GetMetaData();
            return new ClassPagination<T>
            {
                FirstItemOnPage = pagedList.FirstItemOnPage,
                PageSize = pagedList.PageSize,
                PageNumber = pagedList.PageNumber,
                PageCount = pagedList.PageCount,
                LastItemOnPage = pagedList.LastItemOnPage,
                HasPreviousPage = pagedList.HasPreviousPage,
                TotalItemCount = pagedList.TotalItemCount,
                HasNextPage = pagedList.HasNextPage,
                IsFirstPage = pagedList.IsFirstPage,
                IsLastPage = pagedList.IsLastPage,
                Result = pagedList.ToArray()
            };
        }
    }

    public class ClassPagination<T>
    {
        public int FirstItemOnPage { get; set; }
        public bool HasNextPage { get; set; }
        public bool IsFirstPage { get; set; }
        public bool HasPreviousPage { get; set; }
        public bool IsLastPage { get; set; }
        public int LastItemOnPage { get; set; }
        public int PageCount { get; set; }
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int CountItems { get; set; }
        public int TotalItemCount { get; set; }
        public IEnumerable<T> Result { get; set; }
    }
}
