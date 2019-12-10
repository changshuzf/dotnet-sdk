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

namespace Baidu.Aip.Nlp.Unit.ManagerAPI.INPUT
{
    public class Content
    {
        /// <summary>
        /// content[]结构：
        /// </summary>
        /// <param name="patternString">模板⽚段</param>
        /// <param name="required">是否必须匹配： 1-是； 0-否</param>
        /// <param name="order">顺序</param>
        public Content(string patternString, int required, int order)
        {
            this.patternString = patternString;
            this.required = required;
            this.order = order;
        }

        /// <summary>
        /// 模板⽚段
        /// </summary>
        public string patternString { get; set; }

        /// <summary>
        /// 是否必须匹配： 1-是； 0-否
        /// </summary>
        public int required { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public int order { get; set; }
    }
}
