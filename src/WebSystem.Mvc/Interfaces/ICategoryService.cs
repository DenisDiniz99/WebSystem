namespace WebSystem.Mvc.Interfaces
{
    public interface ICategoryService
    {
        Task ServiceSaveAsync(string categoryName);
        Task ServiceUpdateAsync(Guid categoryId, string categoryName);
        Task ServiceDeleteAsync(Guid categoryId);
    }
}
