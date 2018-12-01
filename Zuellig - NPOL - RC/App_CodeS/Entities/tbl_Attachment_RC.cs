using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_Attachment_RC
    {
        private int id;
        private string requestid;
        private string attachmentname;
        private string attachmentpath;
        private string filetype;
        private string filesize;
        private string attachType;

        public tbl_Attachment_RC()
        {
            attachmentname = "";
            attachmentpath = "";
            filetype = "";
            filesize = "";
            attachType = "";
        }
        #region
        public int ID
        {
            get
            {
                return id;
            }
            set
            {
                id = value;
            }
        }
        public string RequestID
        {
            get
            {
                return requestid;
            }
            set
            {
                requestid = value;
            }
        }
        public string AttachmentName
        {
            get
            {
                return attachmentname;
            }
            set
            {
                attachmentname = value;
            }
        }
        public string AttachmentPath
        {
            get
            {
                return attachmentpath;
            }
            set
            {
                attachmentpath = value;
            }
        }
        public string FileType
        {
            get
            {
                return filetype;
            }
            set
            {
                filetype = value;
            }
        }
        public string FileSize
        {
            get
            {
                return filesize;
            }
            set
            {
                filesize = value;
            }
        }
        public string AttachType
        {
            get
            {
                return attachType;
            }
            set
            {
                attachType = value;
            }
        }
        #endregion
    }
}