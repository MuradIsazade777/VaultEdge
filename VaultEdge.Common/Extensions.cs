using System;

namespace VaultEdge.Common
{
    public static class Extensions
    {
        public static string ToSafeString(this object obj)
        {
            return obj?.ToString() ?? string.Empty;
        }

        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrWhiteSpace(str);
        }

        public static DateTime ToUtc(this DateTime dt)
        {
            return DateTime.SpecifyKind(dt, DateTimeKind.Utc);
        }

        public static string ShortId(this Guid guid)
        {
            return guid.ToString().Substring(0, 8);
        }
    }
}
