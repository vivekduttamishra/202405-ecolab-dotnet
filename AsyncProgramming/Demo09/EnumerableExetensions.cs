﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo07
{
    public static class EnumerableExetensions
    {
        public static void ForEach<T>(this IEnumerable<T> items, Action<T>action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}
