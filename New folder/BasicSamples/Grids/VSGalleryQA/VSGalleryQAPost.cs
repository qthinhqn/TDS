using System;

namespace COCOSIN_ERP.BasicSamples
{
    public class VSGalleryQAPost
    {
        public int PostId { get; set; }
        public DateTime PostedOn { get; set; }
        public string PostedByName { get; set; }
        public string PostedByUserId { get; set; }
        public string Message { get; set; }
    }
}