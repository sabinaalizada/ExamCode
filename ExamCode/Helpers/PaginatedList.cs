namespace ExamCode.Helpers
{
    public class PaginatedList<T>:List<T>
    {
        public PaginatedList(List<T> values,int count,int pagesize,int activepage)
        {
            AddRange(values);
            ActivePage=activepage;
            TotalPageCount = (int)Math.Ceiling(count / (double)pagesize);
        }
        public int ActivePage { get; set; }
        public bool Next { get=> ActivePage>1; }
        public bool Previous { get=> ActivePage<TotalPageCount; }
        public int TotalPageCount { get; set; }

        public static PaginatedList<T> Create(IQueryable<T> query,int pagesize,int activepage)
        {
            return new PaginatedList<T>(query.Skip((activepage - 1) * pagesize).Take(pagesize).ToList(),query.Count(),pagesize,activepage);
        }
    }
}
