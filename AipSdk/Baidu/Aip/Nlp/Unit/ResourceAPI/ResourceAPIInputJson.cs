using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit.ResourceAPI
{
    public class ResourceAPIInputJson
    {
        /// <summary>
        /// 0为正常，其他为错误
        /// </summary>
        public string error_code { get; set; }
        /// <summary>
        /// 	错误描述
        /// </summary>
        public string error_msg { get; set; }

        /// <summary>
        /// 对象
        /// </summary>
        public ResourceAPIResult result { get; set; }
    }

    public class ResourceAPIResult
    {
        /// <summary>
        /// 现在仅支持纯文本返回text，其他预留
        /// </summary>
        public string type = "text";
        /// <summary>
        /// 当返回是text类型时，content为返回话术
        /// </summary>
        public string content { get; set; }
    }
}
