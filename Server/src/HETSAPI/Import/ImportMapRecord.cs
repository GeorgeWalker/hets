﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HETSAPI.Import
{
    public class ImportMapRecord
    {
        public string TableName { get; set; }
        public string MappedColumn { get; set; }
        public string OriginalValue { get; set; }

        public string NewValue { get; set; }
    }
}
