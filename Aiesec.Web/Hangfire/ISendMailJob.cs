using System.Threading.Tasks;

namespace Aiesec.Web.Hangfire
{
    public interface ISendMailJob
    {
        Task SendEmail();
    }
}