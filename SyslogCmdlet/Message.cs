//-----------------------------------------------------------------------
// <copyright file="Message.cs">
//     Copyright
// </copyright>
//-----------------------------------------------------------------------

namespace Poesoft
{
    using System;

    /// <summary>
    /// Implements a Syslog message
    /// </summary>
    public class Message
    {
        /// <summary>
        /// Initializes a new instance of the Message class.
        /// </summary>
        /// <param name="facility">The facility of the Syslog message.</param>
        /// <param name="level">The level of the Syslog message.</param>
        /// <param name="text">The message text field of the Syslog message.</param>
        public Message(int facility, int level, string text)
            : this(DateTime.UtcNow, Environment.MachineName, facility, level, text)
        {
        }

        /// <summary>
        /// Initializes a new instance of the Message class.
        /// </summary>
        /// <param name="timestamp">The Timestamp field of the Syslog message.</param>
        /// <param name="hostname">The hostname  field of the Syslog message.</param>
        /// <param name="facility">The facility of the Syslog message.</param>
        /// <param name="level">The level of the Syslog message.</param>
        /// <param name="text">The message text field of the Syslog message.</param>
        public Message(DateTime timestamp, string hostname, int facility, int level, string text)
        {
            Ensure.ArgumentIsNotNull(timestamp, "timestamp");
            Ensure.ArgumentIsAPositiveInt(facility, "facility");
            Ensure.ArgumentIsAPositiveInt(level, "level");

            this.TimeStamp = timestamp;
            this.Hostname = hostname;
            this.Facility = facility;
            this.Level = level;
            this.Text = text;
        }

        /// <summary>
        /// Gets or sets the Timestamp field of the Syslog message.
        /// </summary>
        public DateTime TimeStamp { get; set; }

        /// <summary>
        /// Gets or sets the hostname  field of the Syslog message.
        /// </summary>
        public string Hostname { get; set; }

        /// <summary>
        /// Gets or sets the facility of the Syslog message.
        /// </summary>
        public int Facility { get; set; }

        /// <summary>
        /// Gets or sets the level of the Syslog message.
        /// </summary>
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the message text field of the Syslog message.
        /// </summary>
        public string Text { get; set; }

        /// <summary>
        /// Converts the value of the Syslog message to a string value that is suitable to be sent over the network
        /// </summary>
        /// <returns>A string representation of the Syslog message</returns>
        public override string ToString()
        {
            var priority = (this.Facility * 8) + this.Level;
            var timestampString = this.TimeStamp.ToUniversalTime().ToString("MMM dd hh:mm:ss");
            var messageString = string.Format("<{0}>{1} {2} {3}", priority, timestampString, this.Hostname, this.Text);
            return messageString;
        }
    }
}
