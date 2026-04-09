using ShopappES.Domain;

namespace ShopappES.Application.Repositories
{
    public interface ICategoryRepository
    {
       Category FindById(int categoryId);
    }
}
