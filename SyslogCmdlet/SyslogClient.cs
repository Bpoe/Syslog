//-----------------------------------------------------------------------
// <copyright file="SyslogClient.cs">
//     Copyright
// </copyright>
//-----------------------------------------------------------------------

namespace Poesoft
{
    using System.Net.Sockets;

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

    /// <summary>
    /// Implements Syslog message sending functionality
    /// </summary>
    public class SyslogClient
    {
        /// <summary>
        /// The default Syslog port number
        /// </summary>
        private const int DefaultSyslogPort = 514;

        /// <summary>
        /// The UDP client to use to send the Syslog message
        /// </summary>
        private readonly UdpClient udpClient = new UdpClient();

        /// <summary>
        /// Initializes a new instance of the SyslogClient class.
        /// </summary>
        /// <param name="address">The name or address of the Syslog server to send the message to.</param>
        public SyslogClient(string address)
            : this(address, DefaultSyslogPort)
        {
        }

        /// <summary>
        /// Initializes a new instance of the SyslogClient class.
        /// </summary>
        /// <param name="address">The name or address of the Syslog server to send the message to.</param>
        /// <param name="port">The port to send the message to.</param>
        public SyslogClient(string address, int port)
        {
            Ensure.ArgumentIsNotNullOrWhiteSpace(address, "address");
            Ensure.ArgumentIsAPositiveInt(port, "port");

            this.Server = address;
            this.Port = port;
            this.udpClient.Connect(address, port);
        }

        /// <summary>
        /// Gets the name or address of the Syslog server to send the message to.
        /// </summary>
        public string Server { get; private set; }

        /// <summary>
        /// Gets the port to send the message to.
        /// </summary>
        public int Port { get; private set; }

        /// <summary>
        /// Sends a Syslog message
        /// </summary>
        /// <param name="address">The name or address of the Syslog server to send the message to.</param>
        /// <param name="facility">The facility code of the message</param>
        /// <param name="level">The level code of the message</param>
        /// <param name="text">The text of the message</param>
        public static void Send(string address, int facility, int level, string text)
        {
            Send(address, DefaultSyslogPort, facility, level, text);
        }

        /// <summary>
        /// Sends a Syslog message
        /// </summary>
        /// <param name="address">The name or address of the Syslog server to send the message to.</param>
        /// <param name="port">The port to send the message to.</param>
        /// <param name="facility">The facility code of the message</param>
        /// <param name="level">The level code of the message</param>
        /// <param name="text">The text of the message</param>
        public static void Send(string address, int port, int facility, int level, string text)
        {
            var syslog = new SyslogClient(address, port);
            syslog.Send(facility, level, text);
        }

        /// <summary>
        /// Sends a Syslog message.
        /// </summary>
        /// <param name="facility">The facility code of the message</param>
        /// <param name="level">The level code of the message</param>
        /// <param name="text">The text of the message</param>
        public void Send(int facility, int level, string text)
        {
            Ensure.ArgumentIsAPositiveInt(facility, "facility");
            Ensure.ArgumentIsAPositiveInt(level, "level");

            var priority = (facility * 8) + level;
            var payload = System.Text.Encoding.ASCII.GetBytes(string.Format("<{0}>{1}", priority, text));

            this.udpClient.Send(payload, payload.Length);
        }

        /// <summary>
        /// Sends a Syslog message.
        /// </summary>
        /// <param name="facility">The facility enumeration of the message</param>
        /// <param name="level">The level enumeration of the message</param>
        /// <param name="text">The text of the message</param>
        public void Send(Facility facility, Level level, string text)
        {
            this.Send((int)facility, (int)level, text);
        }
    }
}
