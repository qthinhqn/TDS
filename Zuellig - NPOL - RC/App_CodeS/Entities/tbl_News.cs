using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NPOL.App_Code.Entities
{
    public class tbl_News
    {
        private int newsid;
        private int typeid;
        private string title;
        private string summary;
        private string content;
        private string picture;
        private string userid;
        private Nullable<DateTime> creationtime;
        private Nullable<DateTime> issuedate;
        private bool isattach;
        private bool allowsubmit;
        private Nullable<DateTime> deadlinesubmit;
        private bool isshow;
        private char statusid;
        private short viewedcount;

        public tbl_News()
        {
            title = "";
            summary = "";
            content = "";
            picture = "";
            userid = "";
            creationtime = DateTime.Now;
            issuedate = DateTime.Now;
            isattach = false;
            allowsubmit = false;
            isshow = false;
        }

        #region properties
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
        public int TypeID
        {
            get
            {
                return typeid;
            }
            set
            {
                typeid = value;
            }
        }
        public string Title
        {
            get
            {
                return title;
            }
            set
            {
                title = value;
            }
        }
        public string Summary
        {
            get
            {
                return summary;
            }
            set
            {
                summary = value;
            }
        }
        public string Content
        {
            get
            {
                return content;
            }
            set
            {
                content = value;
            }
        }
        public string Picture
        {
            get
            {
                return picture;
            }
            set
            {
                picture = value;
            }
        }
        public string UserID
        {
            get
            {
                return userid;
            }
            set
            {
                userid = value;
            }
        }
        public Nullable<DateTime> CreationTime
        {
            get
            {
                return creationtime;
            }
            set
            {
                creationtime = value;
            }
        }
        public Nullable<DateTime> IssueDate
        {
            get
            {
                return issuedate;
            }
            set
            {
                issuedate = value;
            }
        }
        public bool IsAttach
        {
            get
            {
                return isattach;
            }
            set
            {
                isattach = value;
            }
        }
        public bool AllowSubmit
        {
            get
            {
                return allowsubmit;
            }
            set
            {
                allowsubmit = value;
            }
        }
        public Nullable<DateTime> DeadlineSubmit
        {
            get
            {
                return deadlinesubmit;
            }
            set
            {
                deadlinesubmit = value;
            }
        }
        public bool IsShow
        {
            get
            {
                return isshow;
            }
            set
            {
                isshow = value;
            }
        }
        public char StatusID
        {
            get
            {
                return statusid;
            }
            set
            {
                statusid = value;
            }
        }
        public short ViewedCount
        {
            get
            {
                return viewedcount;
            }
            set
            {
                viewedcount = value;
            }
        }
        #endregion
    }
}