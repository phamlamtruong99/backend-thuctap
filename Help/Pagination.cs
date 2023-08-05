namespace WebTT.Help
{
    public class Pagination
    {
        public int PageSie { get; set; }
        public int PageNumber { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage
        {
            get
            {
                if (PageSie == 0) { return 0; }
                var total = TotalCount / PageSie;
                if (TotalCount % PageSie > 0) { return total++; }
                return total;
            }
        }
    }
}
