namespace WebTT.Help
{
    public class PageResult<T>
    {
        public Pagination Pagination { get; set; }
        public IEnumerable<T> Data { get; set; }
        public PageResult() { }
        public PageResult(Pagination pagination, IEnumerable<T> data)
        {
            Pagination = pagination;
            Data = data;
        }
        public static IEnumerable<T> ToPageResult(Pagination pagination, IEnumerable<T> query)
        {
            pagination.PageNumber = pagination.PageNumber < 1 ? 1 : pagination.PageNumber;
            query = query.Skip(pagination.PageSie * (pagination.PageNumber - 1))
                   .Take(pagination.PageSie)
                   .AsQueryable();
            return query;
        }
    }
}
