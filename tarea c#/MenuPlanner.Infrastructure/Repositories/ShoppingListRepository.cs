using MenuPlanner.Domain.Entities;
using MenuPlanner.Domain.Repository;
using MenuPlanner.Infrastructure.Core;

namespace MenuPlanner.Infrastructure.Repositories
{
    public class ShoppingListRepository : BaseRepository<ShoppingList>, IShoppingListRepository
    {
        public Task<ShoppingList?> GetByMenuIdAsync(int menuId)
        {
            return Task.FromResult(_items.FirstOrDefault(x => x.MenuId == menuId));
        }
    }
}
