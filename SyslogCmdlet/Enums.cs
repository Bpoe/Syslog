//-----------------------------------------------------------------------
// <copyright file="Enums.cs">
//     Copyright
// </copyright>
//-----------------------------------------------------------------------

namespace Poesoft
{
    /// <summary>
    /// Syslog Facility values defined in RFC3164
    /// https://tools.ietf.org/html/rfc3164
    /// </summary>
    public enum Facility
    {
        Kernel = 0,
        User = 1,
        Mail = 2,
        Daemon = 3,
        Auth = 4,
        Syslog = 5,
        Lpr = 6,
        News = 7,
        UUCP = 8,
        Cron = 9,
        Local0 = 10,
        Local1 = 11,
        Local2 = 12,
        Local3 = 13,
        Local4 = 14,
        Local5 = 15,
        Local6 = 16,
        Local7 = 17,
    }

    /// <summary>
    /// Syslog Level values defined in RFC3164
    /// https://tools.ietf.org/html/rfc3164
    /// </summary>
    public enum Level
    {
        Emergency = 0,
        Alert = 1,
        Critical = 2,
        Error = 3,
        Warning = 4,
        Notice = 5,
        Information = 6,
        Debug = 7,
    }
}
