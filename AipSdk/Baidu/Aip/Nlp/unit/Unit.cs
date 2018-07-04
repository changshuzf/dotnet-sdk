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
using AipSdk.Baidu.Aip.Nlp.unit;
using Newtonsoft.Json;

namespace Baidu.Aip.Nlp.Unit
{
    /// <summary>
    /// 理解与交互技术Unit
    /// </summary>
    public class Unit : AipServiceBase   {
        
        private const string BOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/list";

        private const string BOTADD  =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/add";

        private const string BOTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/update";

        private const string BOTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/delete";

        private const string SETTINGINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/setting/info";

        private const string SETTINGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/setting/update";

        private const string SKILLLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/skill/list";

        private const string INTENTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/intent/list";

        private const string INTENTINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/intent/info";

        private const string INTENTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/intent/add";

        private const string INTENTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/intent/update";

        public Unit(string apiKey, string secretKey) : base(apiKey, secretKey)
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
        /// 功能描述：查询用户的 bot 列表
        /// </summary>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize"> 每页数量，取值范围 1~200
        ///     <list type="bullet">
        ///     </list>
        /// </param>
        /// <return>JObject</return>
        ///
        public JObject BotList(int pageNo,int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTLIST);
            
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 功能描述： 新增 bot
        /// </summary>
        /// <param name="botName">bot 名称，长度范围 1~30</param>
        /// <param name="botDesc">bot 描述，长度范围 0~50</param>
        /// <param name="options"></param>
        /// <returns>JObject</returns>
        public JObject BotAdd(string botName, string botDesc, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTADD);

            aipReq.Bodys["botName"] = botName;
            aipReq.Bodys["botDesc"] = botDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 修改 bot 属性
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="botName">bot 名称，长度范围 1~30</param>
        /// <param name="botDesc">bot 描述，长度范围 0~50</param>
        /// <param name="options"></param>
        /// <returns>JObject</returns>
        public JObject BotUpdate(long botId, string botName,string botDesc, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["botName"] = botName;
            aipReq.Bodys["botDesc"] = botDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        /// <summary>
        /// 删除BOT
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject BotDelete(long botId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTDELETE);

            aipReq.Bodys["botId"] = botId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查询 bot 高级设置
        /// </summary>
        /// <param name="botId">botId</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SettingInfo(long botId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SETTINGINFO);

            aipReq.Bodys["botId"] = botId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 修改 bot 高级设置
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="botSetting">高级设置具体内容</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SettingUpdate(long botId, BotSetting botSetting, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SETTINGUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["botSetting"] = JsonConvert.SerializeObject(botSetting,Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        /// <summary>
        /// 查询技能列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SkillList(long botId, int pageNo,int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 获取意图列表
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="skillId"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentList(long botId,long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查询意图详情
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">意图 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentInfo(long botId, long skillId, long intentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTINFO);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 新建意图
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentData">意图数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentAdd(long botId, long skillId, JObject intentData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = JsonConvert.SerializeObject(intentData,Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 修改意图
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentData">意图数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentUpdate(long botId, long skillId, JObject intentData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = JsonConvert.SerializeObject(intentData, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

    }
}