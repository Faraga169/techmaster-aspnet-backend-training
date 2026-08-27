namespace Book_Store_API.DTOS
{
    public class booksperCategoryResponse
    {
        public string CategoryName { get; set; } = null!;

        public int Count { get; set; }
    }
}
