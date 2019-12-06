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
    public class intentData
    {
        /// <summary>
        /// intentData结构
        /// </summary>
        /// <param name="intentName">意图名称，⻓度范围1~30</param>
        /// <param name="intentType">意图类型： dialog(对话意图)</param>
        /// <param name="intentDesc">意图描述，⻓度范围0~50</param>
        /// <param name="intentClarifyName">意图别名，⻓度范围1~20</param>
        /// <param name="intentClarifyNameArray">
        /// 意图别名列表，可填写1~10个别名。 intentClarifyName和intentClarifyNameArray⾄少填写⼀个，意图别名信息优先使⽤intentClarifyNameArray中的内容
        /// </param>
        /// <param name="sluTags">意图标签列表： 标签由 英⽂、数字、 _ 组成，⻓度1~32 列表中可包含1~10个标签</param>
        /// <param name="slots">词槽信息</param>
        /// <param name="answer">答复信息, 当动作类型含有答复时必填</param>
        /// <param name="guides">对话意图引导信息, 当动作类型含有对话意图引导时必填</param>
        /// <param name="actionPrioritys">答复、对话意图引导的优先级,当技能⾼级设置为【在UNIT平台上配置】时为必填</param>
        public intentData(string intentName, 
                            string intentType, 
                            string intentDesc = null, 
                            string intentClarifyName = null, 
                            List<string> intentClarifyNameArray = null, 
                            List<string> sluTags = null, 
                            List<slot> slots = null, 
                            Answer answer = null, 
                            List<Guide> guides = null, 
                            List<ActionPioritys> actionPrioritys = null)
        {
            this.intentName = intentName;
            this.intentDesc = intentDesc;
            this.intentClarifyName = intentClarifyName;
            this.intentClarifyNameArray = intentClarifyNameArray;
            this.intentType = intentType;
            this.sluTags = sluTags;
            this.slots = slots;
            this.answer = answer;
            this.guides = guides;
            this.actionPrioritys = actionPrioritys;
        }

        /// <summary>
        /// 意图名称，⻓度范围1~30   
        /// </summary>
        public string intentName { get; set; }

        /// <summary>
        /// 意图描述，⻓度范围0~50
        /// </summary>
        public string intentDesc { get; set; }

        /// <summary>
        /// 意图别名，⻓度范围1~20
        /// </summary>
        public string intentClarifyName { get; set; }

        /// <summary>
        /// 意图别名列表，可填写1~10个别名。 intentClarifyName和
        /// intentClarifyNameArray⾄少填写⼀个，意图别名信息优先使
        /// ⽤intentClarifyNameArray中的内容
        /// </summary>
        public List<string> intentClarifyNameArray { get; set; }

        /// <summary>
        /// 意图类型： dialog(对话意图)
        /// </summary>
        public string intentType { get; set; }

        /// <summary>
        /// 意图标签列表： 标签由 英⽂、数字、 _ 组成，⻓度1~32 列表中可包含1~10个标签
        /// </summary>
        public List<string> sluTags { get; set; }

        /// <summary>
        /// 词槽信息
        /// </summary>
        public List<slot> slots { get; set; }

        /// <summary>
        /// 答复信息, 当动作类型含有答复时必填
        /// </summary>
        public Answer answer { get; set; }

        /// <summary>
        /// 对话意图引导信息, 当动作类型含有对话意图引导时必填
        /// </summary>
        public List<Guide> guides { get; set; }

        /// <summary>
        /// 答复、对话意图引导的优先级,当技能⾼级设置为【在UNIT平台上配置】时为必填
        /// </summary>
        public List<ActionPioritys> actionPrioritys { get; set; }
    }

    /// <summary>
    /// actionPrioritys[]结构:
    /// </summary>
    public class ActionPioritys
    {
        /// <summary>
        /// actionPrioritys[]结构:
        /// </summary>
        /// <param name="actionType">取值范围： answer(答复)、 guide(引导⾄对话意图)</param>
        /// <param name="priority">对应actionType的优先级 (1开始如1， 2， 3)</param>
        public ActionPioritys(string actionType, int priority)
        {
            this.actionType = actionType;
            this.priority = priority;
        }

        /// <summary>
        /// 取值范围： answer(答复)、 guide(引导⾄对话意图)
        /// </summary>
        public string actionType { get; set; }

        /// <summary>
        /// 对应actionType的优先级 (1开始如1， 2， 3)
        /// </summary>
        public int priority { get; set; }
    }

    /// <summary>
    /// guides[] (最多10个元素)，每个元素的结构：
    /// </summary>
    public class Guide
    {
        /// <summary>
        /// guides[] (最多10个元素)，每个元素的结构：
        /// </summary>
        /// <param name="intentInfos">引导对话意图列表</param>
        /// <param name="guideScript">引导话术, ⻓度范围1~50</param>
        /// <param name="conditions">规则条件组, 由⼀个condition组成</param>
        public Guide(List<intentInfo> intentInfos, string guideScript, List<Condition> conditions)
        {
            this.intentInfos = intentInfos;
            this.guideScript = guideScript;
            this.conditions = conditions;
        }

        /// <summary>
        /// 引导对话意图列表
        /// </summary>
        public List<intentInfo> intentInfos { get; set; }

        /// <summary>
        /// 引导话术, ⻓度范围1~50
        /// </summary>
        public string guideScript { get; set; }

        /// <summary>
        /// 规则条件组, 由⼀个condition组成
        /// </summary>
        public List<Condition> conditions { get; set; }
    }

    /// <summary>
    /// intentInfos[]结构：
    /// </summary>
    public class intentInfo
    {
        /// <summary>
        /// intentInfo 结构
        /// </summary>
        /// <param name="intentId">意图id</param>
        /// <param name="script">话术，⻓度范围1~50</param>
        public intentInfo(long intentId, string script)
        {
            this.intentId = intentId;
            this.script = script;
        }

        /// <summary>
        /// 意图id
        /// </summary>
        public long intentId { get; set; }

        /// <summary>
        /// 话术，⻓度范围1~50
        /// </summary>
        public string script { get; set; }
    }

    /// <summary>
    /// answer结构：
    /// </summary>
    public class Answer
    {
        /// <summary>
        /// answer结构：
        /// </summary>
        /// <param name="conditions">满⾜答复的条件组列表，最多由25个condition组成</param>
        /// <param name="customReply">开发者⾃定义应答，⻓度范围为1~30，和应答话术say⼆者选其⼀</param>
        /// <param name="say">应答话术，⻓度范围为1~300，和开发者⾃定义应答customReply⼆者选其⼀</param>
        public Answer(List<Condition> conditions,
            string customReply = null, 
            string say = null
            )
        {
            this.customReply = customReply;
            this.say = say;
            this.conditions = conditions;
        }

        /// <summary>
        /// 开发者⾃定义应答，⻓度范围为1~30，和应答话术say⼆者选其⼀
        /// </summary>
        public string customReply { get; set; }

        /// <summary>
        /// 应答话术，⻓度范围为1~300，和开发者⾃定义应答customReply⼆者选其⼀
        /// </summary>
        public string say { get; set; }

        /// <summary>
        /// 满⾜答复的条件组列表，最多由25个condition组成
        /// </summary>
        public List<Condition> conditions { get; set; }

    }

    /// <summary>
    /// condition即⼀个规则组，包含多个规则(⽬前最多50个)，每个规则结构：
    /// </summary>
    public class Condition
    {
        public Condition(string exp, Detail detail)
        {
            this.exp = exp;
            this.detail = detail;
        }

        /// <summary>
        /// 条件类型， sessionSlot(会话过程中) 或quSlot(当前开发者输⼊)、或lastIntent(上轮对话意图)
        /// </summary>
        public string exp { get; set; }

        /// <summary>
        /// 如果exp为quSlot或sessionSlot时，结构如下(其中filled、
        /// contain、 notContain、 equal、 notEqual五个字段只出现⼀
        /// 个)：
        /// {
        //"slotId": 111,
        //"filled": "0(该字段⽆意义)/1(已填充)/2(未填充)",
        //"contain": "word",
        //"notContain": "word"
        //"equal": "word",
        //"notEqual": "word"
        //}
        //    slotId必须在意图的词槽信息范围内
        //    如果exp 为 lastIntent时，结构如下：
        //{ “intentId”: 1, “equal”: 0(不等于)/1(等于)
        //}
        //lastIntent中intentId的意图类型必须为对话意图
        /// </summary>
        public Detail detail { get; set; }
    }

    public class Detail
    {
    }

    /// <summary>
    /// slots[]结构：
    /// </summary>
    public class slot
    {
        /// <summary>
        /// slots[]结构：
        /// </summary>
        /// <param name="slotId">词槽id</param>
        /// <param name="priority">词槽澄清优先级 从1开始，值越⼩优先级越⾼</param>
        /// <param name="clarifyScript">词槽普通澄清话术，⻓度范围1~50</param>
        /// <param name="clarifyScriptObject">词槽澄清⽅式及话术 clarifyScript和clarifyScriptObject⾄少填写⼀个，
        /// 词槽澄清信息优先使⽤clarifyScriptObject中的内容</param>
        public slot(long slotId,
                    int priority,
                    string clarifyScript = null, 
                    ClarifyScriptObject clarifyScriptObject = null
                    )
        {
            this.slotId = slotId;
            this.clarifyScript = clarifyScript;
            this.clarifyScriptObject = clarifyScriptObject;
            this.priority = priority;
        }

        /// <summary>
        /// 词槽id
        /// </summary>
        public long slotId { get; set; }

        /// <summary>
        /// 词槽普通澄清话术，⻓度范围1~50
        /// </summary>
        public string clarifyScript { get; set; }

        /// <summary>
        /// 词槽澄清⽅式及话术 clarifyScript和
        /// clarifyScriptObject⾄少填写⼀个，词槽澄清信息优
        /// 先使⽤clarifyScriptObject中的内容
        /// </summary>
        public ClarifyScriptObject clarifyScriptObject { get; set; }

        /// <summary>
        /// 词槽澄清优先级 从1开始，值越⼩优先级越⾼
        /// </summary>
        public int priority { get; set; }
    }

    /// <summary>
    /// clarifyScriptObject结构：
    /// </summary>
    public class ClarifyScriptObject
    {
        /// <summary>
        /// clarifyScriptObject结构：
        /// </summary>
        /// <param name="slotType">词槽是否必填： mandatory(必填)、 optional(选填)</param>
        /// <param name="clarifyType">词槽澄清⽅式： normal(普通澄清)， enumerate(枚举澄清，词典值数量=0或>5时不可选)</param>
        /// <param name="clarifyCount">取值为1~10。指定clarifyCount轮后放弃要求澄清</param>
        /// <param name="normal">普通澄清话术列表（clarifyType为normal时有效），可填写1~5个澄清话术 普通和枚举澄清话术不可全部为空</param>
        /// <param name="enumerate">枚举澄清话术列表（clarifyType为enumerate时有效），可填写1~5个澄清话术 普通和枚举澄清话术不可全部为空</param>
        public ClarifyScriptObject(string slotType, 
                                    string clarifyType, 
                                    int clarifyCount, 
                                    List<string> normal, 
                                    List<string> enumerate)
        {
            this.slotType = slotType;
            this.clarifyType = clarifyType;
            this.clarifyCount = clarifyCount;
            this.normal = normal;
            this.enumerate = enumerate;
        }

        /// <summary>
        /// 词槽是否必填： mandatory(必填)、 optional(选填)
        /// </summary>
        public string slotType { get; set; }

        /// <summary>
        /// 词槽澄清⽅式： normal(普通澄清)， enumerate(枚举澄清，词典值数量=0或>5时不可选)
        /// </summary>
        public string clarifyType { get; set; }

        /// <summary>
        /// 取值为1~10。指定clarifyCount轮后放弃要求澄清
        /// </summary>
        public int clarifyCount { get; set; }

        /// <summary>
        /// 普通澄清话术列表（clarifyType为normal时有效），可填写1~5个澄清话术 普通和枚举澄清话术不可全部为空
        /// </summary>
        public List<string> normal { get; set; }

        /// <summary>
        /// 枚举澄清话术列表（clarifyType为enumerate时有效），可填写1 ~5个澄清话术 普通和枚举澄清话术不可全部为空
        /// </summary>
        public List<string> enumerate { get; set; }
    }
}