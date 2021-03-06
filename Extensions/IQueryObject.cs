namespace NXS.Extensions
{
    public interface IQueryObject
    {
        string SortBy { get; set; }
        bool IsSortAscending { get; set; }
        bool? IsPaging { get; set; }
        int Page { get; set; }
        byte PageSize { get; set; }
    }
}