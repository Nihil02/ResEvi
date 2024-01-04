using System.Runtime.CompilerServices;
using ResEvi.Data.Entities;

[assembly: InternalsVisibleTo("Tests")]

namespace ResEvi.Data.DAO
{
    internal sealed class AdvisorDAO : AbstractDAO<Advisor>
    {
        public AdvisorDAO(AppDbContext context) : base(context)
        {
        }
    }
}