using System;
using System.Collections.Generic;
using System.Text;
using Songrics.Data.Common;

namespace Songrics.Data.Models
{
    public class Category : BaseModel<int>
    {
        public string SongCategory { get; set; }
    }
}
