namespace Topic.WebUI.Dtos.CategoryDtos
{
    public class CreateCategoryDto
    {
        public string CategoryName { get; set; }
        public bool Status { get; set; } = true;

        public string Description { get; set; }
        public string ImageUrl { get; set; }
    }
}
