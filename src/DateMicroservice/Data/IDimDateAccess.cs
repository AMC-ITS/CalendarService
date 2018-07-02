using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DateMicroservice.Data
{
    public interface IDimDateAccess
    {
        DateModel[] GetDateSet(int? year, int? month, int? day);
        DateModel GetSingleDate(int? year, int? month, int? day);
        DateTime? GetLastBusinessDay(int? year, int? month, int? day);
        DateTime? GetNextBusinessDay(int? year, int? month, int? day);
        DateTime? GetNextHoliday(int? year, int? month, int? day);
    }
}
