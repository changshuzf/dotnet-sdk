using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace Baidu.Aip.Nlp.Unit.ResourceAPI
{
    public class ResourceAPICallBackResultJSON : Result
    {
        /// <summary>
        ///from参数代表展示平台，其中
        //1 为DuerOS技能开放平台；
        //2 为微信公众平台。
        /// </summary>
        public string form { get; set; }
    }
}
