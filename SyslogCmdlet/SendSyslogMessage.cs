//-----------------------------------------------------------------------
// <copyright file="SendSyslogMessage.cs">
//     Copyright
// </copyright>
//-----------------------------------------------------------------------

using System.Management.Automation;

namespace Poesoft
{
    /// <summary>
    /// Implements the Send-SyslogMessage PowerShell Cmdlet
    /// </summary>
    [Cmdlet(VerbsCommunications.Send, "SyslogMessage")]
    public class SendSyslogMessage : PSCmdlet
    {
        /// <summary>
        /// Gets or sets the computer name of the Syslog server
        /// </summary>
        [Parameter(ParameterSetName = "Default", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string ComputerName { get; set; }

        /// <summary>
        /// Gets or sets the port of the Syslog server
        /// </summary>
        [Parameter(ParameterSetName = "Default", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int Port { get; set; }

        /// <summary>
        /// Gets or sets the facility level of the message
        /// </summary>
        [Parameter(ParameterSetName = "Default", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int Facility { get; set; }

        /// <summary>
        /// Gets or sets the level of the message
        /// </summary>
        [Parameter(ParameterSetName = "Default", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public int Level { get; set; }

        /// <summary>
        /// Gets or sets the text of the message
        /// </summary>
        [Parameter(ParameterSetName = "Default", Mandatory = true)]
        [ValidateNotNullOrEmpty]
        public string Message { get; set; }

        /// <summary>
        /// The main method for a cmdlet
        /// </summary>
        protected override void ProcessRecord()
        {
            SyslogClient.Send(this.ComputerName, this.Facility, this.Level, this.Message);
        }
    }
}
