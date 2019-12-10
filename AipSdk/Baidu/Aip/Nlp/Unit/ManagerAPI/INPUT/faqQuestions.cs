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
    /// <summary>
    /// faqQuestions[]结构(最多包含100个元素)：
    /// </summary>
    public class FaqQuestion
    {
        /// <summary>
        /// FaqQuestion
        /// </summary>
        /// <param name="question">问题, ⻓度范围1~125</param>
        public FaqQuestion(string question)
        {
            this.question = question;
        }

        /// <summary>
        /// 问题, ⻓度范围1~125
        /// </summary>
        public string question { get; set; }
    }

    /// <summary>
    /// faqAnswers[]结构(最多包含5个元素)：
    /// </summary>
    public class faqAnswers
    {
        /// <summary>
        /// faqAnswers
        /// </summary>
        /// <param name="answer">答案，⻓度范围1~1000</param>
        public faqAnswers(string answer)
        {
            this.answer = answer;
        }

        /// <summary>
        /// 答案，⻓度范围1~1000
        /// </summary>
        public string answer { get; set; }
    }

    public class faqPattern
    {
        public PatternString patternString { get; set; }
    }

    public class PatternString
    {
        /// <summary>
        /// 阈值
        /// </summary>
        public float threshold { get; set; }

        public List<Content> content { get; set; }
    }
}
