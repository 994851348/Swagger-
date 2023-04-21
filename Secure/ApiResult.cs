using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LocalHostTest.Secure
{
    /// <summary>
    /// 返回DataTable结果集Model
    /// </summary>
    public class ApiResult
    {
        /// <summary>
        /// 返回成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 失败提醒
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回的数据格式
        /// </summary>
        public DataTable data { get; set; }
        /// <summary>
        /// 返回的总数
        /// </summary>
        public int count { get; set; }
    }
    /// <summary>
    /// 返回List\泛型结果集Model
    /// </summary>
    public class ApiResult<T>
    {
        /// <summary>
        /// 返回成功
        /// </summary>
        public bool success { get; set; }
        /// <summary>
        /// 失败提醒
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 返回的数据格式
        /// </summary>
        public List<T> data { get; set; }
        /// <summary>
        /// 返回的数据格式
        /// </summary>
        public T dataT { get; set; }
        /// <summary>
        /// 返回的总数
        /// </summary>
        public int? count { get; set; }
    }
}