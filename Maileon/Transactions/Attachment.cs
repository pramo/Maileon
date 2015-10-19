using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

using Maileon.Utils.JSON;

namespace Maileon.Transactions
{
    public class Attachment
    {
        // technically this is the maximum transaction size
        private const long MAX_ATTACHMENT_SIZE = 1000000;

        /// <summary>
        /// The file name to use for the attachment in the generated transaction e-mail
        /// </summary>
        [MaileonJson("filename")]
        public string Filename { get; set; }

        /// <summary>
        /// The mime type to specify for the attachment as part of the generated transaction e-mail
        /// </summary>
        [MaileonJson("mimetype")]
        public string MimeType { get; set; }

        /// <summary>
        /// The binary contents of the attachment, encoded in Base64.
        /// </summary>
        [MaileonJson("data")]
        public string Data { get; set; }

        /// <summary>
        /// Initializes a new attachment from the given data
        /// </summary>
        /// <param name="data"></param>
        /// <param name="mimeType"></param>
        /// <param name="filename"></param>
        public Attachment(byte[] data, string mimeType, string filename)
        {
            if (data.Length > MAX_ATTACHMENT_SIZE) throw new MaileonException("file length must be < " + MAX_ATTACHMENT_SIZE);

            Data = Convert.ToBase64String(data);
            MimeType = mimeType;
            Filename = filename;
        }

        public static Attachment FromFile(string path)
        {
            if (new FileInfo(path).Length > MAX_ATTACHMENT_SIZE) throw new MaileonException("file length must be < " + MAX_ATTACHMENT_SIZE);

            return new Attachment(
                File.ReadAllBytes(path),
                MimeMapping.GetMimeMapping(path),
                Path.GetFileName(path));
        }
    }
}
