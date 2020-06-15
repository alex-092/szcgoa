using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Libs
{
    public class TimeHelper
    {
        private static DateTime _dtStart = new DateTime(1970, 1, 1, 8, 0, 0);
        public static int GetTimeStamp(DateTime dateTime)
        {
            return Convert.ToInt32(dateTime.Subtract(_dtStart).TotalSeconds);
        }
        public static int GetTimeStamp()
        {
            return Convert.ToInt32(DateTime.Now.Subtract(_dtStart).TotalSeconds);
        }

        /// <summary> 
        /// 根据时间戳获取时间 
        /// </summary>  
        public static DateTime TimeStampToDateTime(string timeStamp)
        {
            return _dtStart.AddMilliseconds(Convert.ToInt64(timeStamp));
        }

        /// <summary> 
        /// 根据时间戳获取时间 
        /// </summary>  
        public static DateTime TimeStampToDateTime(int timeStamp)
        {
            if (timeStamp > 0)
            {
                return _dtStart.AddMilliseconds(timeStamp);
            }
            return DateTime.MinValue;
        }
    }
}
