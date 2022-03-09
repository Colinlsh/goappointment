using System.Collections.Generic;
using System.Threading.Tasks;

namespace Appointment.Application.Core.Helpers
{
    public static class LinqExtensions
    {
        public static async Task<IEnumerable<T>> WhenAll<T>(this IEnumerable<Task<T>> tasks)
        {
            return await Task.WhenAll(tasks);
        }
    }
}
