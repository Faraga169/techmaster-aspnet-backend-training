using StudentManagementAPI.Models;

namespace StudentManagementAPI.DTOS
{
    public class PagedResultResponse
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPages { get; set; }
        public List<Student> Students { get; set; }=new List<Student>();
    }
}
