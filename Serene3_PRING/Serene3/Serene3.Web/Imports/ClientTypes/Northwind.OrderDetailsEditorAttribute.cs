using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace Serene3.Northwind
{
    public partial class OrderDetailsEditorAttribute : CustomEditorAttribute
    {
        public const string Key = "Serene3.Northwind.OrderDetailsEditor";

        public OrderDetailsEditorAttribute()
            : base(Key)
        {
        }
    }
}

