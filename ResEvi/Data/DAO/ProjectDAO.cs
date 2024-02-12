using ResEvi.Data.Entities;

namespace ResEvi.Data.DAO
{
    internal sealed class ProjectDAO : AbstractDAO<Project>
    {
        public ProjectDAO(AppDbContext context) : base(context)
        {
        }
    }
}
