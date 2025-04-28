namespace Topic.WebUI.Dtos.CategoryDtos
{
    public class UpdateCategoryDto
    {
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public bool Status { get; set; } = true;

        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
