namespace Lumia.Helpers
{
    public class PaginatedList<T>:List<T>
    {
        public PaginatedList(List<T> values,int count,int pagesize,int page)
        {
            AddRange(values);
            ActivePage = page;
            TotalPageCount=(int)Math.Ceiling((double)count/pagesize);
        }
        public int ActivePage { get; set; }
        public int TotalPageCount { get; set; }
        public bool Next { get=> ActivePage< TotalPageCount;  }
        public bool Previous { get => ActivePage>1; }

        public static PaginatedList<T> Create(IQueryable<T> values, int pagesize, int activepage)
        {
            return new PaginatedList<T>(values.Skip((activepage - 1) * pagesize).Take(pagesize).ToList(), values.Count(), pagesize, activepage);
        }
    }
}
