using ShopappES.Domain;

namespace ShopappES.Application.Repositories
{
	public interface IUserRepository
	{
        User FindById(Guid userId);
	}
}


