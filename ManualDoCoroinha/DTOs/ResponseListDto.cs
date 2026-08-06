namespace ManualDoCoroinha.DTOs
{
    public class ResponseListDto<T>
    {
        public IEnumerable<T> Items { get; set; } = Enumerable.Empty<T>();
        public int CurrentPage { get; set; }
        public int PageSize { get; set; }
        public int TotalItems { get; set; }
        public int TotalPages { get; set; }
        public bool HasMore { get; set; }
        public bool HasPrevious => CurrentPage > 1;
    }
}
