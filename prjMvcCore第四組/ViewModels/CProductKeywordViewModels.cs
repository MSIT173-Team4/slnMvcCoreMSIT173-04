namespace prjMvcCore第四組.ViewModels
{
    public class CProductKeywordViewModels
{
        public string txtKeyword { get; set; }
        public string SearchType { get; set; }
        public int? MinStock { get; set; }
        public int? MaxStock { get; set; }
        public byte? StatusFilter { get; set; }
    }
}
