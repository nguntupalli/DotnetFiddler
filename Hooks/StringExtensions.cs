using System;
using System.Linq;
using System.Text;

namespace SpecflowFiddlerTests.Hooks
{
    public static class StringExtensions
    {
        public static bool StartsWithAny(this string stack, params string[] needles)
        {
            return needles.Any(stack.StartsWith);
        }

        public static bool ContainsAny(this string stack, params string[] needles)
        {
            return needles.Any(stack.Contains);
        }

        public static bool IsOneOf<T>(this T value, params T[] items)
        {
            for (int i = 0; i < items.Length; ++i)
            {
                if (items[i].Equals(value))
                    return true;
            }
            return false;
        }
    }
}
