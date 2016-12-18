﻿using System;
using System.Collections.Generic;
using System.Linq;
using Trady.Core.Period;

namespace Trady.Core.Helper
{
    public static class TimeSeriesExtension
    {
        public static IPeriod CreateInstance(this PeriodOption period)
        {
            string periodName = Enum.GetName(typeof(PeriodOption), period);
            var periodType = Type.GetType($"{typeof(TimeSeries<>).Namespace}.Period.{periodName}");
            return (IPeriod)Activator.CreateInstance(periodType);
        }

        public static int? FindIndexOrDefault<T>(this List<T> items, Predicate<T> predicate)
        {
            int index = items.FindIndex(predicate);
            return index == -1 ? (int?)null : index;
        }

        public static int? FindLastIndexOrDefault<T>(this List<T> items, Predicate<T> predicate)
        {
            int index = items.FindLastIndex(predicate);
            return index == -1 ? (int?)null : index;
        }
    }
}
