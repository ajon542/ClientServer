
namespace Client
{
    /// <summary>
    /// Base class for all messages.
    /// </summary>
    public class BaseMsg
    {
        /// <summary>
        /// Gets or sets a string description for the type of message.
        /// </summary>
        /// <remarks>
        /// This will be used in determining the type for (de)serialization.
        /// </remarks>
        public string Type { get; set; }

        /// <summary>
        /// Gets or sets the contents of the message.
        /// </summary>
        public string Contents { get; set; }
    }
}
