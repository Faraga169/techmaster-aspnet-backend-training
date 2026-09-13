namespace Drill_01_DbContext___First_Migration.DTOS
{
    public class PaginationResultDTO
    {
        


        public int TotalCount { get; set; }
        public int pageNumber { get; set; }

        public int pageSize { get; set; }

        public int TotalPages { get; set; }

        public IEnumerable<GetEnrollmentsDTO> items { get; set; } = new List<GetEnrollmentsDTO>();

    }
}
