using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Parameters
{
    public class FeedbackParameters
    {
        const int maxPageSize = 20;
        int pageSize = 10;

        public int PageNumber { get; set; } = 1;
        public int PageSize 
        { 
            get => pageSize; 
            set => pageSize = (value > maxPageSize) ? maxPageSize : value;
        }
    }
}
