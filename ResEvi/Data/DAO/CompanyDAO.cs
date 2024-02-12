using ResEvi.Data.Entities;

namespace ResEvi.Data.DAO 
{
    internal sealed class CompanyDAO : AbstractDAO<Company>
    {
        public CompanyDAO(AppDbContext context) : base(context)
        {
        }
    }
}
