using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serene3.BasicSamples
{
    public partial class ChangingLookupTextEditorAttribute : LookupEditorBaseAttribute
    {
        public const string Key = "Serene3.BasicSamples.ChangingLookupTextEditor";

        public ChangingLookupTextEditorAttribute()
            : base(Key)
        {
        }
    }
}

