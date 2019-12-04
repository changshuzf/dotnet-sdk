/*
 * Copyright 2017 Baidu, Inc.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file except in compliance with
 * the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the License is distributed on
 * an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied. See the License for the
 * specific language governing permissions and limitations under the License.
 */

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
        ResourceAPIResult result { get; set; }
    }

    class ResourceAPIResult
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
