using System.Threading.Tasks;

namespace Werter.Capgemini.WebApi.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}