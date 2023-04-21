using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace LocalHostTest.Secure
{
    /// <summary>
    /// 返回封装结果集
    /// </summary>
    public class ResponseResult
    {
        /// <summary>
        /// 返回DataTable成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ApiResult Success(DataTable data, int count)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                data = data,
                count = count,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回DataTable成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResult SuccessAll(DataTable data, int count, string msg)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                data = data,
                count = count,
                msg = msg,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回List成功
        /// </summary>
        /// <param name="data"></param>
        /// <param name="count"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(List<T> data, int? count = null, string msg = null)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                data = data,
                count = count,
                msg = msg,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回自定义成功
        /// </summary>
        /// <param name="dataT"></param>
        /// <param name="count"></param>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(T dataT, int? count = null, string msg = null)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                dataT = dataT,
                count = count,
                msg = msg,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="apiResult"></param>
        /// <returns></returns>
        public ApiResult<T> Success<T>(ApiResult<T> apiResult)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回成功Count
        /// </summary>
        /// <param name="message"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ApiResult SuccessCount(string message, int count)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                msg = message,
                count = count,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public ApiResult FailCount(string message, int count)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                msg = message,
                count = count,
                success = false
            };
            return rs;
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResult Fail(string msg)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                data = null,
                msg = msg,
                success = false
            };
            return rs;
        }
        /// <summary>
        /// 返回失败
        /// </summary>
        /// <param name="msg"></param>
        /// <returns></returns>
        public ApiResult<T> Fail<T>(string msg)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                data = null,
                msg = msg,
                success = false
            };
            return rs;
        }
        /// <summary>
        /// 返回成功
        /// </summary>
        /// <param name="msg"></param>
        public ApiResult SuccessMsg(string msg)
        {
            //返回数据
            ApiResult rs = new ApiResult
            {
                data = null,
                msg = msg,
                success = true
            };
            return rs;
        }
        /// <summary>
        /// 返回失败,加个集合
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ApiResult<T> FailData<T>(string message, List<T> data)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                data = data,
                msg = message,
                success = false
            };
            return rs;
        }
        /// <summary>
        /// 返回成功Msg,加个集合
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public ApiResult<T> SuccessMsgData<T>(string message, List<T> data)
        {
            //返回数据
            ApiResult<T> rs = new ApiResult<T>
            {
                data = data,
                msg = message,
                success = true
            };
            return rs;
        }
    }
}