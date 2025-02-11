﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Common.Utils
{
    public static class CustomEnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            FieldInfo fi = value.GetType().GetField(value.ToString());
            if (fi is null)
            {
                return "NULL";
            }

            var descrAttributes = fi.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];

            if (descrAttributes != null && 
                descrAttributes.Any())
            {
                return descrAttributes.First().Description;
            }

            return value.ToString();
        }
    }
}
