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

using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using System.IO;
using Baidu.Aip.Nlp.Unit;
using Baidu.Aip;

namespace Baidu.Aip.Nlp.Unit
{
    public class TalkAPI : AipServiceBase
    {
        private const string BOTCHAT =
    "https://aip.baidubce.com/rpc/2.0/unit/service/chat";

        private const string SKILLCHAT =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/chat";

        public TalkAPI(string apiKey, string secretKey) : base(apiKey, secretKey)
        {

        }

        protected AipHttpRequest DefaultRequest(string uri)
        {
            return new AipHttpRequest(uri)
            {
                Method = "POST",
                BodyType = AipHttpRequest.BodyFormat.Json,
                ContentEncoding = Encoding.GetEncoding("UTF-8")
            };
        }

        /// <summary>
        /// UNIT机器人对话API，机器人对话API
        /// </summary>
        /// <param name="service_id">机器人ID，service_id 与skill_ids不能同时缺失，至少一个有值。</param>
        /// <param name="request"></param>
        /// <param name="log_id"></param>
        /// <param name="version"></param>
        /// <param name="skill_ids">技能ID列表。我们允许开发者指定调起哪些技能。这个列表是有序的——排在越前面的技能，优先级越高。技能优先级体现在response的排序上。具体排序规则参见【应答参数说明】service_id和skill_ids可以组合使用，详见【请求参数详细说明】</param>
        /// <param name="session_id"></param>
        /// <param name="dialog_state"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ReturnJsonBotChat BotChat(string service_id, Request request, string log_id = "",
            string version = "2.0", List<string> skill_ids = null, string session_id = "", object dialog_state = null, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTCHAT);

            aipReq.Bodys["version"] = version;
            aipReq.Bodys["service_id"] = service_id;
            if (log_id == "")
            {
                System.Random r = new System.Random(10000000);
                aipReq.Bodys["log_id"] = r.Next().ToString();
            }
            aipReq.Bodys["request"] = request;
            aipReq.Bodys["session_id"] = session_id;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return JsonConvert.DeserializeObject<ReturnJsonBotChat>(PostAction(aipReq).ToString());
        }

        /// <summary>
        /// UNIT对话服务,技能对话API
        ///沙盒环境
        ///【不区分机房】https://aip.baidubce.com/rpc/2.0/unit/bot/chat
        ///生产环境
        ///【华北机房】https://unit.bj.baidubce.com/rpc/2.0/unit/bot/chat
        ///【华东机房】https://unit.su.baidubce.com/rpc/2.0/unit/bot/chat
        ///【华南机房】https://unit.gz.baidubce.com/rpc/2.0/unit/bot/chat
        /// </summary>
        /// <param name="bot_id">BOT唯一标识，在『我的BOT』的BOT列表中第一列数字即为bot_id</param>
        /// <param name="log_id">开发者需要在客户端生成的唯一id，用来定位请求，响应中会返回该字段。对话中每轮请求都需要一个log_id。</param>
        /// <param name="request">本轮请求体</param>
        /// <param name="version">=2.0，当前api版本对应协议版本号为2.0，固定值。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ReturnJsonBotChat SkillChat(string bot_id, Request request, string log_id = "",
            string version = "2.0", string bot_session = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLCHAT);

            aipReq.Bodys["version"] = version;
            aipReq.Bodys["bot_id"] = bot_id;
            if (log_id == "")
            {
                System.Random r = new System.Random(10000000);
                aipReq.Bodys["log_id"] = r.Next().ToString();
            }
            aipReq.Bodys["request"] = request;
            aipReq.Bodys["bot_session"] = bot_session;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return JsonConvert.DeserializeObject<ReturnJsonBotChat>(PostAction(aipReq).ToString());
        }
    }
}
