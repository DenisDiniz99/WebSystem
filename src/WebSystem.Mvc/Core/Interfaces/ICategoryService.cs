namespace WebSystem.Mvc.Core.Interfaces
{
    public interface ICategoryService
    {
        Task ServiceSaveAsync(string categoryName);
        Task ServiceUpdateAsync(Guid categoryId, string categoryName);
        Task ServiceDeleteAsync(Guid categoryId);
    }
}
