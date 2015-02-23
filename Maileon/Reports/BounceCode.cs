using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;

namespace Maileon.Reports
{
    /// <summary>
    /// A class representing information of a Bounce
    /// </summary>
    public class BounceCode
    {
        /// <summary>
        /// The bounce code
        /// </summary>
        [XmlText]
        public string Value
        {
            set
            {
                _value = value;
                string[] code = value.Split('.');

                if (code.Length > 2) 
                {
                    string msgPart = code[1] + code[2];

                    this.Message = messages[msgPart][0];
                    this.Description = messages[msgPart][1];
                    this.Type = code[0] == "5" ? BounceType.Permanent : BounceType.Transient;
                }
                else
                {
                    this.Message = string.Empty;
                    this.Description = string.Empty;
                }
            }

            get
            {
                return _value;
            }
        }

        private string _value;

        /// <summary>
        /// The type of the bounce code
        /// </summary>
        [XmlIgnore]
        public BounceType Type { get; private set; }

        /// <summary>
        /// The message for the bounce code
        /// </summary>
        [XmlIgnore]
        public string Message { get; private set; }

        /// <summary>
        /// The description of the bounce code
        /// </summary>
        [XmlIgnore]
        public string Description { get; private set; }

        private static Dictionary<string, string[]> messages = null;

        public override string ToString()
        {
            return string.Format("{0} - {1}", _value, Message);
        }

        public BounceCode()
        {
            if(messages == null) 
            {
                messages = new Dictionary<string,string[]>();
                
                messages.Add("00", new string[]{"Other undefined Status", "Other undefined status is the only undefined error code.  It should be used for all errors for which only the class of the error is known. "});
                messages.Add("10", new string[]{"Other address status", "Something about the address specified in the message caused this DSN. "});
                messages.Add("11", new string[]{"Bad destination mailbox address", "The mailbox specified in the address does not exist.  For Internet mail names, this means the address portion to the left of the \"@\" sign is invalid.  This code is only useful for permanent failures. "});
                messages.Add("12", new string[]{"Bad destination system address", "The destination system specified in the address does not exist or is incapable of accepting mail.  For Internet mail names, this means the address portion to the right of the \"@\" is invalid for mail.  This code is only useful for permanent failures. "});
                messages.Add("13", new string[]{"Bad destination mailbox address syntax", "The destination address was syntactically invalid.  This can apply to any field in the address.  This code is only useful for permanent failures. "});
                messages.Add("14", new string[]{"Destination mailbox address ambiguous", "The mailbox address as specified matches one or more recipients on the destination system.  This may result if a heuristic address mapping algorithm is used to map the specified address to a local mailbox name. "});
                messages.Add("15", new string[]{"Destination address valid", "This mailbox address as specified was valid.  This status code should be used for positive delivery reports. "});
                messages.Add("16", new string[]{"Destination mailbox has moved, No forwarding address", "The mailbox address provided was at one time valid, but mail is no longer being accepted for that address.  This code is only useful for permanent failures. "});
                messages.Add("17", new string[]{"Bad sender's mailbox address syntax", "The sender's address was syntactically invalid.  This can apply to any field in the address. "});
                messages.Add("18", new string[]{"Bad sender's system address", "The sender's system specified in the address does not exist or is incapable of accepting return mail.  For domain names, this means the address portion to the right of the \"@\" is invalid for mail. "});
                messages.Add("20", new string[]{"Other or undefined mailbox status", "The mailbox exists, but something about the destination mailbox has caused the sending of this DSN. "});
                messages.Add("21", new string[]{"Mailbox disabled, not accepting messages", "The mailbox exists, but is not accepting messages.  This may be a permanent error if the mailbox will never be re-enabled or a transient error if the mailbox is only temporarily disabled. "});
                messages.Add("22", new string[]{"Mailbox full", "The mailbox is full because the user has exceeded a per-mailbox administrative quota or physical capacity.  The general semantics implies that the recipient can delete messages to make more space available.  This code should be used as a persistent transient failure. "});
                messages.Add("23", new string[]{"Message length exceeds administrative limit", "A per-mailbox administrative message length limit has been exceeded.  This status code should be used when the per-mailbox message length limit is less than the general system limit. This code should be used as a permanent failure. "});
                messages.Add("24", new string[]{"Mailing list expansion problem", "The mailbox is a mailing list address and the mailing list was unable to be expanded.  This code may represent a permanent failure or a persistent transient failure. "});
                messages.Add("30", new string[]{"Other or undefined mail system status", "The destination system exists and normally accepts mail, but something about the system has caused the generation of this DSN. "});
                messages.Add("31", new string[]{"Mail system full", "Mail system storage has been exceeded.  The general semantics imply that the individual recipient may not be able to delete material to make room for additional messages.  This is useful only as a persistent transient error. "});
                messages.Add("32", new string[]{"System not accepting network messages", "The host on which the mailbox is resident is not accepting messages.  Examples of such conditions include an immanent shutdown, excessive load, or system maintenance.  This is useful for both permanent and persistent transient errors. "});
                messages.Add("33", new string[]{"System not capable of selected features", "Selected features specified for the message are not supported by the destination system.  This can occur in gateways when features from one domain cannot be mapped onto the supported feature in another. "});
                messages.Add("34", new string[]{"Message too big for system", "The message is larger than per-message size limit.  This limit may either be for physical or administrative reasons.  This is useful only as a permanent error. "});
                messages.Add("35", new string[]{"System incorrectly configured", "The system is not configured in a manner that will permit it to accept this message. "});
                messages.Add("40", new string[]{"Other or undefined network or routing status", "Something went wrong with the networking, but it is not clear what the problem is, or the problem cannot be well expressed with any of the other provided detail codes. "});
                messages.Add("41", new string[]{"No answer from host", "The outbound connection attempt was not answered, because either the remote system was busy, or was unable to take a call.  This is useful only as a persistent transient error. "});
                messages.Add("42", new string[]{"Bad connection", "The outbound connection was established, but was unable to complete the message transaction, either because of time-out, or inadequate connection quality.  This is useful only as a persistent transient error. "});
                messages.Add("43", new string[]{"Directory server failure", "The network system was unable to forward the message, because a directory server was unavailable.  This is useful only as a persistent transient error. The inability to connect to an Internet DNS server is one example of the directory server failure error. "});
                messages.Add("44", new string[]{"Unable to route", "The mail system was unable to determine the next hop for the message because the necessary routing information was unavailable from the directory server.  This is useful for both permanent and persistent transient errors. A DNS lookup returning only an SOA (Start of Administration) record for a domain name is one example of the unable to route error. "});
                messages.Add("45", new string[]{"Mail system congestion", "The mail system was unable to deliver the message because the mail system was congested.  This is useful only as a persistent transient error. "});
                messages.Add("46", new string[]{"Routing loop detected", "A routing loop caused the message to be forwarded too many times, either because of incorrect routing tables or a user- forwarding loop.  This is useful only as a persistent transient error. "});
                messages.Add("47", new string[]{"Delivery time expired", "The message was considered too old by the rejecting system, either because it remained on that host too long or because the time-to-live value specified by the sender of the message was exceeded.  If possible, the code for the actual problem found when delivery was attempted should be returned rather than this code. "});
                messages.Add("50", new string[]{"Other or undefined protocol status", "Something was wrong with the protocol necessary to deliver the message to the next hop and the problem cannot be well expressed with any of the other provided detail codes. "});
                messages.Add("51", new string[]{"Invalid command", "A mail transaction protocol command was issued which was either out of sequence or unsupported.  This is useful only as a permanent error. "});
                messages.Add("52", new string[]{"Syntax error", "A mail transaction protocol command was issued which could not be interpreted, either because the syntax was wrong or the command is unrecognized.  This is useful only as a permanent error. "});
                messages.Add("53", new string[]{"Too many recipients", "More recipients were specified for the message than could have been delivered by the protocol.  This error should normally result in the segmentation of the message into two, the remainder of the recipients to be delivered on a subsequent delivery attempt.  It is included in this list in the event that such segmentation is not possible. "});
                messages.Add("54", new string[]{"Invalid command arguments", "A valid mail transaction protocol command was issued with invalid arguments, either because the arguments were out of range or represented unrecognized features.  This is useful only as a permanent error. "});
                messages.Add("55", new string[]{"Wrong protocol version", "A protocol version mis-match existed which could not be automatically resolved by the communicating parties. "});
                messages.Add("60", new string[]{"Other or undefined media error", "Something about the content of a message caused it to be considered undeliverable and the problem cannot be well expressed with any of the other provided detail codes. "});
                messages.Add("61", new string[]{"Media not supported", "The media of the message is not supported by either the delivery protocol or the next system in the forwarding path. This is useful only as a permanent error. "});
                messages.Add("62", new string[]{"Conversion required and prohibited", "The content of the message must be converted before it can be delivered and such conversion is not permitted.  Such prohibitions may be the expression of the sender in the message itself or the policy of the sending host. "});
                messages.Add("63", new string[]{"Conversion required but not supported", "The message content must be converted in order to be forwarded but such conversion is not possible or is not practical by a host in the forwarding path.  This condition may result when an ESMTP gateway supports 8bit transport but is not able to downgrade the message to 7 bit as required for the next hop. "});
                messages.Add("64", new string[]{"Conversion with loss performed", "This is a warning sent to the sender when message delivery was successfully but when the delivery required a conversion in which some data was lost.  This may also be a permanent error if the sender has indicated that conversion with loss is prohibited for the message. "});
                messages.Add("65", new string[]{"Conversion Failed", "A conversion was required but was unsuccessful.  This may be useful as a permanent or persistent temporary notification. "});
                messages.Add("70", new string[]{"Other or undefined security status", "Something related to security caused the message to be returned, and the problem cannot be well expressed with any of the other provided detail codes.  This status code may also be used when the condition cannot be further described because of security policies in force. "});
                messages.Add("71", new string[]{"Delivery not authorized, message refused", "The sender is not authorized to send to the destination.  This can be the result of per-host or per-recipient filtering.  This memo does not discuss the merits of any such filtering, but provides a mechanism to report such.  This is useful only as a permanent error. "});
                messages.Add("72", new string[]{"Mailing list expansion prohibited", "The sender is not authorized to send a message to the intended mailing list.  This is useful only as a permanent error. "});
                messages.Add("73", new string[]{"Security conversion required but not possible", "A conversion from one secure messaging protocol to another was required for delivery and such conversion was not possible. This is useful only as a permanent error. "});
                messages.Add("74", new string[]{"Security features not supported", "A message contained security features such as secure authentication that could not be supported on the delivery protocol.  This is useful only as a permanent error. "});
                messages.Add("75", new string[]{"Cryptographic failure", "A transport system otherwise authorized to validate or decrypt a message in transport was unable to do so because necessary information such as key was not available or such information was invalid. "});
                messages.Add("76", new string[]{"Cryptographic algorithm not supported", "A transport system otherwise authorized to validate or decrypt a message was unable to do so because the necessary algorithm was not supported. "});
                messages.Add("77", new string[]{"Message integrity failure", "A transport system otherwise authorized to validate a message was unable to do so because the message was corrupted or altered.  This may be useful as a permanent, transient persistent, or successful delivery code."});
           }
        }
    }
}
