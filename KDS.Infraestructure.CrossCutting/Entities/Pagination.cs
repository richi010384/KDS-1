namespace KDS.Infraestructure.CrossCutting.Entities
{
    public class Pagination
    {
        public short StartIndex { get; set; }
        public short EndIndex { get; set; }
        public string SortColumn { get; set; }
        public string SortOrder { get; set; }
        public int TotalDisplayRecords { get; set; }
        public int TotalRecords { get; set; }
    }
}
