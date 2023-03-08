using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LostInTime.Models;

namespace LostInTime.Data
{
    public class CharacterRepository : IRepository<Character>
    {
        private readonly LostInTimeContext lostInTimeContext;

        public CharacterRepository(LostInTimeContext lostInTimeContext)
        {
            this.lostInTimeContext = lostInTimeContext;
        }

        public async Task Add(Character character)
        {
            _ = await lostInTimeContext.Characters.AddAsync(character);
            _ = await lostInTimeContext.SaveChangesAsync();
        }

        public async Task Add(IEnumerable<Character> characters)
        {
            await lostInTimeContext.Characters.AddRangeAsync(characters);
            _ = await lostInTimeContext.SaveChangesAsync();
        }

        public async Task Delete(Character entity)
        {
            _ = lostInTimeContext.Characters.Remove(entity);
            _ = await lostInTimeContext.SaveChangesAsync();
        }

        public async Task<Character?> Get(int id)
        {
            return await lostInTimeContext.Characters.FindAsync(id);
        }

        public IQueryable<Character> Get()
        {
            return lostInTimeContext.Characters;
        }
    }
}
