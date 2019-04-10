
namespace Serene3.Administration.Forms
{
    using Serenity.ComponentModel;
    using System;

    [ColumnsScript("Administration.Language")]
    [BasedOnRow(typeof(Entities.LanguageRow), CheckNames = true)]
    public class LanguageColumns
    {
        [EditLink]
        public String LanguageId { get; set; }
        [EditLink]
        [Width(180), QuickFilter, SortOrder(1, true)]
        public String LanguageName { get; set; }
    }
}