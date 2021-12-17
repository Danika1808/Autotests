using System;

namespace Autotests.Helpers
{
    public static class DateTimeHelper
    {
        public static string CurrentDateTime => DateTime.Now.ToString("yyyy-MM-dd_hh-mm-ss");
    }
}