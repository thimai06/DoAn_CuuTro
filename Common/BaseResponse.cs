
using System;
using System.Collections.Generic;

namespace Common
{
    public class BaseResponse<T>
    {
        public T results { get; set; }
        public string message { get; set; }
        public string status { get; set; }
    }

    public class Pagination<T>
    {
        public List<T> Items { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public int TotalCount { get; set; }
        public int TotalPage => (int)Math.Ceiling(TotalCount / (double)PageSize);
    }
}
