using Serenity;
using Serenity.ComponentModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;

namespace ewm.BasicSamples {
    public partial class ChangingLookupTextEditorAttribute : LookupEditorBaseAttribute {
        public const string Key = "ewm.BasicSamples.ChangingLookupTextEditor";

        public ChangingLookupTextEditorAttribute()
            : base(Key) {
        }
    }
}

