using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{

    public static class IRepositoryExtensions
    {
        
        public static async Task<Entity> Update<Entity, Id>(this IRepository<Entity, Id> repository, Id id, Entity entity, params string[] excluded)
        {
            return await repository.Update(entity,
                async () => await repository.GetById(id),
                (oldE, newE) =>
                {
                    if (excluded.Length==0)
                        oldE.Copy(newE, "Id");
                    else
                        oldE.Copy(newE, excluded);
                });
        }          

        public static async Task<Entity> UpdateOnly<Entity,Id>(this IRepository<Entity,Id> repository, Id id, Entity newData, params string[] includedProperties)
        {
            return await repository.Update(newData,
                async () => await repository.GetById(id),
                mergeOldNew: (oldE, newE) =>
                {
                   oldE.CopyOnly(newE, includedProperties);
                });
        }

        public static async Task<Entity> Update<Entity,Id>(this IRepository<Entity,Id> repository, Entity newData, Func<Task<Entity>>oldDataFinder,Action<Entity,Entity> mergeOldNew)
        {
            var oldEntity = await oldDataFinder();
            if (oldEntity!=null)
            {
                mergeOldNew(oldEntity, newData);
            }
            await repository.Save();
            return oldEntity;
        }
    
    
    }
    public interface IRepository<Entity,Id>
    {
        Task<Entity> Add(Entity entity);

        Task Delete(Id id);
        Task<IList<Entity>> GetAll();

        Task<IList<Entity>> GetAll(Func<Entity,bool> criteria);

        Task<Entity> GetById(Id id);

        Task Save();
    }

    
}
