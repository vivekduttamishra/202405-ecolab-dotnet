using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConceptArchitect.Utils
{
    public interface IRepository<Entity,Id>
    {
        Task<Entity> Add(Entity entity);
        Task<Entity> Update(Entity entity);
        Task Delete(Id id);
        Task<IList<Entity>> GetAll();

        Task<IList<Entity>> GetAll(Func<Entity,bool> criteria);

        Task<Entity> GetById(Id id);

        void Save();
    }

    ]
}
