using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serene3.BasicSamples
{
    public partial class FilteredLookupDetailEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Serene3.BasicSamples.FilteredLookupDetailEditor";

        public FilteredLookupDetailEditorAttribute()
            : base(Key)
        {
        }
    }
}

