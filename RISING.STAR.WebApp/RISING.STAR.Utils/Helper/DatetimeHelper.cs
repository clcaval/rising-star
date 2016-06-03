﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RISING.STAR.Utils.Helper
{
    public static class DatetimeHelper
    {


        public static string DatetimeToDDMMMYY(DateTime date)
        {
            return date.ToString("dd-MMM-yyyy");
        }

        public static string TimespanToHHmmTT(TimeSpan ts)
        {
            DateTime time = DateTime.Today.Add(ts);
            return time.ToString("hh:mm");
        }

    }
}