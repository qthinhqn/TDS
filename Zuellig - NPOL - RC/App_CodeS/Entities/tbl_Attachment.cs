using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_Attachment
    {
        private int id;
        private int newsid;
        private string attachmentname;
        private string attachmentpath;
        private string filetype;
        private string filesize;

        public tbl_Attachment()
        {
            attachmentname = "";
            attachmentpath = "";
            filetype = "";
            filesize = "";
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
        public int NewsID
        {
            get
            {
                return newsid;
            }
            set
            {
                newsid = value;
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
        #endregion
    }
}