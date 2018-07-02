using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace DateMicroservice.Data
{
    public class DimDateAccess: IDimDateAccess
    {
        #region Properties
        private IConfiguration Configuration { get; set; }

        private string ConnectionString { get; set; }
        #endregion

        #region Constructors
        public DimDateAccess(IConfiguration configuration)
        {
            Configuration = configuration;
            ConnectionString = Configuration["Database:ConnectionString"];
        }

        public DimDateAccess(string connectionString)
        {
            ConnectionString = connectionString;
        }
        #endregion

        #region Public Methods
        public DateModel[] GetDateSet(int? year, int? month, int? day)
        {
            var dateModelList = new List<DateModel>();
            if (!IsValidDate(year, month, day))
            {
                //do nothing
            }
            else if (year == null && month == null && day == null)
            {
                dateModelList.Add(GetSingleDate(DateTime.Now));
            }
            else if (year != null && month == null && day == null)
            {
                var startDate = new DateTime((int)year, 1, 1);
                var endDate = new DateTime((int)year, 12, 31);
                dateModelList = GetDateRange(startDate, endDate);
            }
            else if (month != null && day == null)
            {
                year = year ?? DateTime.Now.Year;
                var startDate = new DateTime((int)year, (int)month, 1);
                var endDate = new DateTime((int)year, (int)month, DateTime.DaysInMonth((int)year, (int)month));
                dateModelList = GetDateRange(startDate, endDate);
            }
            else
            {
                var date = GetSingleDate(year, month, day);
                if (date != null)
                {
                    dateModelList.Add(date);
                }
            }
            return dateModelList.ToArray();
        }
        public DateModel GetSingleDate(int? year, int? month, int? day)
        {
            if (!IsValidDate(year, month, day))
            {
                return null;
            }
            (int y, int m, int d) = CheckDay(year, month, day);
            var commandText = "SELECT * FROM [ODS].[dbo].[DimDate] WHERE CONVERT(date, [DateKey]) = CONVERT(date, @MyDate)";
            var commandParameters = new List<SqlParameter>();
            DateTime date;
            try
            {
                date = new DateTime(y, m, d);
            }
            catch
            {
                date = DateTime.Now;
            }
            var dateParameter = new SqlParameter("@MyDate", SqlDbType.DateTime) { Value = date };
            commandParameters.Add(dateParameter);
            BaseDataAccess bda = new BaseDataAccess(ConnectionString);
            var result = bda.RunSingleRowQuery<DateModel>(commandText, commandParameters);
            return result;
        }
        public DateTime? GetNextBusinessDay(int? year, int? month, int? day)
        {
            if (!IsValidDate(year, month, day))
            {
                return null;
            }
            (int y, int m, int d) = CheckDay(year, month, day);
            var dateModel = GetSingleDate(y, m, d);
            return dateModel?.NextBusinessDay;
        }
        public DateTime? GetLastBusinessDay(int? year, int? month, int? day)
        {
            if (!IsValidDate(year, month, day))
            {
                return null;
            }
            (int y, int m, int d) = CheckDay(year, month, day);
            var dateModel = GetSingleDate(y, m, d);
            return dateModel?.LastBusinessDay;
        }
        public DateTime? GetNextHoliday(int? year, int? month, int? day)
        {
            if (!IsValidDate(year, month, day))
            {
                return null;
            }
            (int y, int m, int d) = CheckDay(year, month, day);
            var dates = GetDateRange(new DateTime(y, m, d), new DateTime(y, m, d).AddDays(365));
            return dates.FirstOrDefault(x => x.IsHoliday == "Holiday")?.DateKey;
        }
        #endregion

        #region Private Methods
        private DateModel GetSingleDate(DateTime dt)
        {
            return GetSingleDate(dt.Year, dt.Month, dt.Day);
        }
        private List<DateModel> GetDateRange(DateTime startDate, DateTime endDate)
        {
            var commandText = "SELECT * FROM [ODS].[dbo].[DimDate] WHERE CONVERT(date, [DateKey]) BETWEEN CONVERT(date, @StartDate) AND CONVERT(date, @EndDate)";
            var commandParameters = new List<SqlParameter>();
            var startDateParameter = new SqlParameter("@StartDate", SqlDbType.DateTime) { Value = startDate };
            commandParameters.Add(startDateParameter);
            var endDateParameter = new SqlParameter("@EndDate", SqlDbType.DateTime) { Value = endDate };
            commandParameters.Add(endDateParameter);
            BaseDataAccess bda = new BaseDataAccess(ConnectionString);
            return bda.RunQuery<DateModel>(commandText, commandParameters);
        }
        private static (int year, int month, int day) CheckDay(int? year, int? month, int? day)
        {
            // ReSharper disable once InvertIf
            if (year != null && month == null && day == null)
            {
                month = 1;
                day = 1;
            }
            else if (month != null && day == null)
            {
                day = 1;
            }
            return (
                year ?? DateTime.Now.Year,
                month ?? DateTime.Now.Month,
                day ?? DateTime.Now.Day);
        }
        private static bool IsValidDate(int? year, int? month, int? day)
        {
            try
            {
                (int y, int m, int d) = CheckDay(year, month, day);
                var dummy = new DateTime(y, m, d);
            }
            catch
            {
                return false;
            }
            return true;
        }
        #endregion

    }
}
