using System;
using System.Data.SqlClient;

namespace DateMicroservice.Data
{
    public class DateModel : BaseSqlQueryResult
    {
        private SqlDataReader _reader;
        public int DimDateId { get; set; }
        public DateTime DateKey { get; set; }
        public string DateDescription { get; set; }
        public int YearNumber { get; set; }
        public string YearMonth { get; set; }
        public string QuarterName { get; set; }
        public int MonthNumber { get; set; }
        public string MonthName { get; set; }
        public string MonthName3 { get; set; }
        public string DayName { get; set; }
        public string DayName3 { get; set; }
        public int DayOfYear { get; set; }
        public int DayOfQuarter { get; set; }
        public int DayOfMonth { get; set; }
        public int DayOfWeek { get; set; }
        public int WeekNumber { get; set; }
        public int WeekNumber2 { get; set; }
        public DateTime? YearStart { get; set; }
        public DateTime? YearEnd { get; set; }
        public DateTime? QuarterStart { get; set; }
        public DateTime? QuarterEnd { get; set; }
        public DateTime? MonthStart { get; set; }
        public DateTime? MonthEnd { get; set; }
        public DateTime? WeekStart { get; set; }
        public DateTime? WeekEnd { get; set; }
        public DateTime? Week2Start { get; set; }
        public DateTime? Week2End { get; set; }
        public DateTime? PayPeriodStart { get; set; }
        public DateTime? PayPeriodEnd { get; set; }
        public DateTime? LastBusinessDay { get; set; }
        public DateTime? NextBusinessDay { get; set; }
        public DateTime? Ytd { get; set; }
        public DateTime? YtdEndByDayOfYear { get; set; }
        public DateTime? Qtd { get; set; }
        public DateTime? QtdEndByDayOfQuarter { get; set; }
        public DateTime? Mtd { get; set; }
        public DateTime? MtdEndByDayOfMonth { get; set; }
        public DateTime? Wtd { get; set; }
        public DateTime? Wtd2 { get; set; }
        public int BusinessDaysYtd { get; set; }
        public int BusinessDaysRemainingYtd { get; set; }
        public int BusinessDaysQtd { get; set; }
        public int BusinessDaysRemainingQtd { get; set; }
        public int BusinessDaysMtd { get; set; }
        public int BusinessDaysRemainingMtd { get; set; }
        public int RelativeYear { get; set; }
        public int RelativeQuarter { get; set; }
        public int RelativeMonth { get; set; }
        public int RelativePayPeriod { get; set; }
        public int RelativeWeek { get; set; }
        public int RelativeWeekDay { get; set; }
        public int RelativeCalendarDay { get; set; }
        public int RelativeBusinessDay { get; set; }
        public int RelativeBusinessDaySat { get; set; }
        public int WeekDayFlag { get; set; }
        public string IsWeekDay { get; set; }
        public int HolidayFlag { get; set; }
        public string IsHoliday { get; set; }
        public int BusinessDayFlag { get; set; }
        public string IsBusinessDay { get; set; }
        public int BusinessDaySatFlag { get; set; }
        public string IsBusinessDaySat { get; set; }
        public int MonthEndFlag { get; set; }
        public string IsMonthEnd { get; set; }
        public int DstInEffectFlag { get; set; }
        public int YtdFlag { get; set; }
        public string IsYtd { get; set; }
        public int YtdEndByDayOfYearFlag { get; set; }
        public string IsYtdEndByDayOfYear { get; set; }
        public int QtdFlag { get; set; }
        public string IsQtd { get; set; }
        public int QtdEndByDayOfQuarterFlag { get; set; }
        public string IsQtdEndByDayOfQuarter { get; set; }
        public int MtdFlag { get; set; }
        public string IsMtd { get; set; }
        public int MtdEndByDayOfMonthFlag { get; set; }
        public string IsMtdEndByDayOfMonth { get; set; }
        public int WtdFlag { get; set; }
        public string IsWtd { get; set; }
        public int Wtd2Flag { get; set; }
        public string IsWtd2 { get; set; }
        public int UtcOffset { get; set; }

        public override BaseSqlQueryResult HandleReader(SqlDataReader reader)
        {
            _reader = reader;
            var dm = new DateModel()
            {
                DimDateId = int.Parse(_reader["DimDateId"].ToString()),
                DateKey = (DateTime) _reader["DateKey"],
                DateDescription = (string) _reader["DateDescription"],
                YearNumber = int.Parse(_reader["YearNumber"].ToString()),
                YearMonth = (string) _reader["YearMonth"],
                QuarterName = (string) _reader["QuarterName"],
                MonthNumber = int.Parse(_reader["MonthNumber"].ToString()),
                MonthName = (string) _reader["MonthName"],
                MonthName3 = (string) _reader["MonthName3"],
                DayName = (string) _reader["DayName"],
                DayName3 = (string) _reader["DayName3"],
                DayOfYear = int.Parse(_reader["DayOfYear"].ToString()),
                DayOfQuarter = int.Parse(_reader["DayOfQuarter"].ToString()),
                DayOfMonth = int.Parse(_reader["DayOfMonth"].ToString()),
                DayOfWeek = int.Parse(_reader["DayOfWeek"].ToString()),
                WeekNumber = int.Parse(_reader["WeekNumber"].ToString()),
                WeekNumber2 = int.Parse(_reader["WeekNumber2"].ToString()),
                YearStart = _reader["YearStart"] is DBNull ? null : (DateTime?) _reader["YearStart"],
                YearEnd = _reader["YearEnd"] is DBNull ? null : (DateTime?) _reader["YearEnd"],
                QuarterStart = _reader["QuarterStart"] is DBNull ? null : (DateTime?) _reader["QuarterStart"],
                QuarterEnd = _reader["QuarterEnd"] is DBNull ? null : (DateTime?) _reader["QuarterEnd"],
                MonthStart = _reader["MonthStart"] is DBNull ? null : (DateTime?) _reader["MonthStart"],
                MonthEnd = _reader["MonthEnd"] is DBNull ? null : (DateTime?) _reader["MonthEnd"],
                WeekStart = _reader["WeekStart"] is DBNull ? null : (DateTime?) _reader["WeekStart"],
                WeekEnd = _reader["WeekEnd"] is DBNull ? null : (DateTime?) _reader["WeekEnd"],
                Week2Start = _reader["Week2Start"] is DBNull ? null : (DateTime?) _reader["Week2Start"],
                Week2End = _reader["Week2End"] is DBNull ? null : (DateTime?) _reader["Week2End"],
                PayPeriodStart = _reader["PayPeriodStart"] is DBNull ? null : (DateTime?) _reader["PayPeriodStart"],
                PayPeriodEnd = _reader["PayPeriodEnd"] is DBNull ? null : (DateTime?) _reader["PayPeriodEnd"],
                LastBusinessDay = _reader["LastBusinessDay"] is DBNull ? null : (DateTime?) _reader["LastBusinessDay"],
                NextBusinessDay = _reader["NextBusinessDay"] is DBNull ? null : (DateTime?) _reader["NextBusinessDay"],
                Ytd = _reader["Ytd"] is DBNull ? null : (DateTime?) _reader["Ytd"],
                YtdEndByDayOfYear =
                    _reader["YtdEndByDayOfYear"] is DBNull ? null : (DateTime?) _reader["YtdEndByDayOfYear"],
                Qtd = _reader["Qtd"] is DBNull ? null : (DateTime?) _reader["Qtd"],
                QtdEndByDayOfQuarter = _reader["QtdEndByDayOfQuarter"] is DBNull
                    ? null
                    : (DateTime?) _reader["QtdEndByDayOfQuarter"],
                Mtd = _reader["Mtd"] is DBNull ? null : (DateTime?) _reader["Mtd"],
                MtdEndByDayOfMonth = _reader["MtdEndByDayOfMonth"] is DBNull
                    ? null
                    : (DateTime?) _reader["MtdEndByDayOfMonth"],
                Wtd = _reader["Wtd"] is DBNull ? null : (DateTime?) _reader["Wtd"],
                Wtd2 = _reader["Wtd2"] is DBNull ? null : (DateTime?) _reader["Wtd2"],
                BusinessDaysYtd = int.Parse(_reader["BusinessDaysYtd"].ToString()),
                BusinessDaysRemainingYtd = int.Parse(_reader["BusinessDaysRemainingYtd"].ToString()),
                BusinessDaysQtd = int.Parse(_reader["BusinessDaysQtd"].ToString()),
                BusinessDaysRemainingQtd = int.Parse(_reader["BusinessDaysRemainingQtd"].ToString()),
                BusinessDaysMtd = int.Parse(_reader["BusinessDaysMtd"].ToString()),
                BusinessDaysRemainingMtd = int.Parse(_reader["BusinessDaysRemainingMtd"].ToString()),
                RelativeYear = int.Parse(_reader["RelativeYear"].ToString()),
                RelativeQuarter = int.Parse(_reader["RelativeQuarter"].ToString()),
                RelativeMonth = int.Parse(_reader["RelativeMonth"].ToString()),
                RelativePayPeriod = int.Parse(_reader["RelativePayPeriod"].ToString()),
                RelativeWeek = int.Parse(_reader["RelativeWeek"].ToString()),
                RelativeWeekDay = int.Parse(_reader["RelativeWeekDay"].ToString()),
                RelativeCalendarDay = int.Parse(_reader["RelativeCalendarDay"].ToString()),
                RelativeBusinessDay = int.Parse(_reader["RelativeBusinessDay"].ToString()),
                RelativeBusinessDaySat = int.Parse(_reader["RelativeBusinessDaySat"].ToString()),
                WeekDayFlag = int.Parse(_reader["WeekDayFlag"].ToString()),
                IsWeekDay = (string) _reader["IsWeekDay"],
                HolidayFlag = int.Parse(_reader["HolidayFlag"].ToString()),
                IsHoliday = (string) _reader["IsHoliday"],
                BusinessDayFlag = int.Parse(_reader["BusinessDayFlag"].ToString()),
                IsBusinessDay = (string) _reader["IsBusinessDay"],
                BusinessDaySatFlag = int.Parse(_reader["BusinessDaySatFlag"].ToString()),
                IsBusinessDaySat = (string) _reader["IsBusinessDaySat"],
                MonthEndFlag = int.Parse(_reader["MonthEndFlag"].ToString()),
                IsMonthEnd = (string) _reader["IsMonthEnd"],
                DstInEffectFlag = int.Parse(_reader["DstInEffectFlag"].ToString()),
                YtdFlag = int.Parse(_reader["YtdFlag"].ToString()),
                IsYtd = (string) _reader["IsYtd"],
                YtdEndByDayOfYearFlag = int.Parse(_reader["YtdEndByDayOfYearFlag"].ToString()),
                IsYtdEndByDayOfYear = (string) _reader["IsYtdEndByDayOfYear"],
                QtdFlag = int.Parse(_reader["QtdFlag"].ToString()),
                IsQtd = (string) _reader["IsQtd"],
                QtdEndByDayOfQuarterFlag = int.Parse(_reader["QtdEndByDayOfQuarterFlag"].ToString()),
                IsQtdEndByDayOfQuarter = (string) _reader["IsQtdEndByDayOfQuarter"],
                MtdFlag = int.Parse(_reader["MtdFlag"].ToString()),
                IsMtd = (string) _reader["IsMtd"],
                MtdEndByDayOfMonthFlag = int.Parse(_reader["MtdEndByDayOfMonthFlag"].ToString()),
                IsMtdEndByDayOfMonth = (string) _reader["IsMtdEndByDayOfMonth"],
                WtdFlag = int.Parse(_reader["WtdFlag"].ToString()),
                IsWtd = (string) _reader["IsWtd"],
                Wtd2Flag = int.Parse(_reader["Wtd2Flag"].ToString()),
                IsWtd2 = (string) _reader["IsWtd2"],
                UtcOffset = int.Parse(_reader["UtcOffset"].ToString())
            };
            return dm;
        }
    }
}