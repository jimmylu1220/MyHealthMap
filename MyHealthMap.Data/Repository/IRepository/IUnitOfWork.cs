namespace MyHealthMap.Data.Repository.IRepository
{
    public interface IUnitOfWork
    {
        IRestaurantRepository RestaurantRepository { get; }
        IMenuRepository MenuRepository { get; }
        Task Save();
    }
}
