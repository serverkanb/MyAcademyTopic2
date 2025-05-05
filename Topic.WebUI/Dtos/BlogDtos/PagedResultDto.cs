namespace Topic.WebUI.Dtos.BlogDtos
{
    public class PagedResultDto<T>
    {
        public List<T> Items { get; set; }
        public int TotalPages { get; set; }
    }
}
