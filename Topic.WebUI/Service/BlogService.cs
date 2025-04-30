using Topic.WebUI.Dtos.BlogDtos;

namespace Topic.WebUI.Service
{
    public class BlogService : IBlogService
    {
        private readonly HttpClient _client;

        public BlogService(HttpClient client)
        {
            _client = client;
        }

        public async Task CreateBlogAsync(CreateBlogDto dto)
        {
            await _client.PostAsJsonAsync("blogs", dto);
        }

        public async Task DeleteBlogAsync(int id)
        {
            await _client.DeleteAsync("blogs/" +  id);
        }

        public async Task<List<ResultBlogDto>> GetAllAsync()
        {
            return await _client.GetFromJsonAsync<List<ResultBlogDto>>("blogs");
        }

        public async Task<UpdateBlogDto> GetByIdAsync(int id)
        {
            return await _client.GetFromJsonAsync<UpdateBlogDto>("blogs/" + id);
        }

        public async Task UpdateBlogAsync(UpdateBlogDto dto)
        {
            await _client.PutAsJsonAsync("blogs", dto);
        }
    }
}
