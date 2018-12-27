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
    /// <summary>
    /// 理解与交互技术Unit
    /// </summary>
    public class Unit : AipServiceBase
    {

        private const string BOTCHAT =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/chat";

        private const string BOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/bot/list";

        private const string BOTADD =
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

        private const string INTENTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/intent/delete";

        private const string SLOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/list";

        private const string SYSSLOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/sysSlot/list";

        private const string SLOTVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/value";

        private const string SLOTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/add";

        private const string SLOTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/update";

        private const string SLOTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/delete";

        private const string MODELLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/model/list";

        private const string MODELTRAIN =
            "https://aip.baidubce.com/rpc/2.0/unit/model/train";

        private const string MODELDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/model/delete";

        private const string QUERYSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/querySet/list";

        private const string QUERYSETADD =
            "https://aip.baidubce.com/rpc/2.0/unit/querySet/add";

        private const string QUERYSETDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/querySet/delete";

        private const string QUERYLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/query/list";

        private const string QUERYINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/query/info";

        private const string QUERYADD =
            "https://aip.baidubce.com/rpc/2.0/unit/query/add";

        private const string QUERYUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/query/update";

        private const string QUERYDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/query/delete";

        private const string PATTERNSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/patternSet/list";

        private const string PATTERNLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/pattern/list";

        private const string PATTERNINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/pattern/info";

        private const string PATTERNIMPORT =
            "https://aip.baidubce.com/rpc/2.0/unit/pattern/import";

        private const string PATTERNCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/pattern/clear";

        private const string KEYWORDLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/keyword/list";

        private const string KEYWORDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/keyword/value";

        private const string KEYWORDADD =
            "https://aip.baidubce.com/rpc/2.0/unit/keyword/add";

        private const string KEYWORDUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/keyword/update";

        private const string KEYWORDDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/keyword/delete";

        private const string FAQLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/list";

        private const string FAQINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/info";

        private const string FAQADD =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/add";

        private const string FAQUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/update";

        private const string FAQDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/delete";

        private const string FAQCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/clear";

        private const string FAQIMPORT =
            "https://aip.baidubce.com/rpc/2.0/unit/faq/import";

        private const string FILEUPLOAD =
            "https://aip.baidubce.com/rpc/2.0/unit/file/upload";

        private const string JOBINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/job/info";

        private const string DEPLOYMENTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/deployment/add";

        private const string DEPLOYMENTUPDATEMODELVERSION =
            "https://aip.baidubce.com/rpc/2.0/unit/deployment/updateModelVersion";

        private const string DEPLOYMENTGETSTATUS =
            "https://aip.baidubce.com/rpc/2.0/unit/deployment/getStatus";

        private const string DEPLOYMENTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/deployment/list";


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
        /// UNIT对话服务
        /// </summary>
        /// <param name="bot_id">BOT唯一标识，在『我的BOT』的BOT列表中第一列数字即为bot_id</param>
        /// <param name="log_id">开发者需要在客户端生成的唯一id，用来定位请求，响应中会返回该字段。对话中每轮请求都需要一个log_id。</param>
        /// <param name="request">本轮请求体</param>
        /// <param name="version">=2.0，当前api版本对应协议版本号为2.0，固定值。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public ReturnJsonBotChat BotChat(string bot_id, Request request, string log_id = "",
            string version = "2.0", string bot_session = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(BOTCHAT);

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
        public JObject BotList(int pageNo, int pageSize, Dictionary<string, object> options = null, string botCategory = "")
        {
            var aipReq = DefaultRequest(BOTLIST);

            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["botCategory"] = botCategory;
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
        public JObject BotAdd(string botName, string botDesc = "", Dictionary<string, object> options = null)
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
        public JObject BotUpdate(long botId, string botName, string botDesc = "", Dictionary<string, object> options = null)
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
        public JObject SettingUpdate(long botId, BotSettingInputJSON botSetting, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SETTINGUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["botSetting"] = JsonConvert.SerializeObject(botSetting, Formatting.Indented);
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
        public JObject SkillList(long botId, int pageNo, int pageSize, Dictionary<string, object> options = null)
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
        public JObject IntentList(long botId, long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null, string intentType = "")
        {
            var aipReq = DefaultRequest(INTENTLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentType"] = intentType;
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
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented);
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
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除意图
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">意图 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentDelete(long botId, long skillId, long intentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTDELETE);

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
        /// 查询自定义词槽列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotList(long botId, long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTLIST);

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
        /// 查询系统词槽列表
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SysSlotList(Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SYSSLOTLIST);

            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  查询自定义词槽词典详细信息
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="slotId">词槽 id</param>
        /// <param name="slotType">词槽词典类别用户自定义(user)黑名单(black)，传递空字符串时返回所有类型</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~5000</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotValue(long botId, long skillId, long slotId, string slotType, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTVALUE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  新建词槽
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="slotName">词槽名称，长度范围 1~20</param>
        /// <param name="slotDesc">词槽描述，长度范围 0~50</param>
        /// <param name="slotDictPath">自定义词槽词典标识，通过上传接口产生</param>
        /// <param name="slotBlacklistDictPath">词槽黑名单词典标识，通过上传接口产生</param>
        /// <param name="slotSysDict">系统词槽名称</param>
        /// <param name="slotDictPathEfficient">自定义词槽词典和黑名单词典是否使用:1(使用)、 0(未使用)</param>
        /// <param name="slotSysDictEfficient">系统词槽词典是否使用: 1(使用)、 0(未使用)</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotAdd(long botId, long skillId, string slotName, string slotDesc,
            string slotDictPath, string slotBlacklistDictPath, JArray slotSysDict,
            int slotDictPathEfficient, int slotSysDictEfficient,
            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotName"] = slotName;
            aipReq.Bodys["slotDesc"] = slotDesc;
            aipReq.Bodys["slotDictPath"] = slotDictPath;
            aipReq.Bodys["slotBlacklistDictPath"] = slotBlacklistDictPath;
            aipReq.Bodys["slotSysDict"] = JsonConvert.SerializeObject(slotSysDict, Formatting.Indented);
            aipReq.Bodys["slotDictPathEfficient"] = slotDictPathEfficient;
            aipReq.Bodys["slotSysDictEfficient"] = slotSysDictEfficient;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  修改词槽
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="slotId">词槽 id</param>
        /// <param name="slotDesc">词槽描述，长度范围 0~50</param>
        /// <param name="slotDictPath">自定义词槽词典标识，通过上传接口产生</param>
        /// <param name="slotBlacklistDictPath">词槽黑名单词典标识，通过上传接口产生</param>
        /// <param name="slotSysDict">系统词槽名称</param>
        /// <param name="slotDictPathEfficient">自定义词槽词典和黑名单词典是否使用:1(使用)、 0(未使用)</param>
        /// <param name="slotSysDictEfficient">系统词槽词典是否使用: 1(使用)、 0(未使用)</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotUpdate(long botId, long skillId, long slotId, string slotDesc,
            string slotDictPath, string slotBlacklistDictPath, JArray slotSysDict,
            int slotDictPathEfficient, int slotSysDictEfficient,
            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotDesc"] = slotDesc;
            aipReq.Bodys["slotDictPath"] = slotDictPath;
            aipReq.Bodys["slotBlacklistDictPath"] = slotBlacklistDictPath;
            aipReq.Bodys["slotSysDict"] = JsonConvert.SerializeObject(slotSysDict, Formatting.Indented);
            aipReq.Bodys["slotDictPathEfficient"] = slotDictPathEfficient;
            aipReq.Bodys["slotSysDictEfficient"] = slotSysDictEfficient;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  删除词槽
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="slotId">词槽 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotDelete(long botId, long skillId, long slotId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查询模型列表
        /// </summary>
        /// <param name="botId">botId</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelList(long botId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELLIST);

            aipReq.Bodys["botId"] = botId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 训练模型
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="modelDesc">模型描述, 长度范围 0~50</param>
        /// <param name="trainOption">
        ///     用户训练参数，json 结构，包含两部分信息
        //      1. 训练数据的选择，包含模板包和样本包
        //      2. 训练方式的选择，用户可选方式有两种：
        //      a.快速训练(smartqu)
        //      b.快速训练(smartqu)+深度训练(mlqu)
        //      选择，填写 true；否则，填写 false
        //      3. 具体样例为：
        //      {
        //      "configure":{
        //      "smartqu": "true",
        //      "mlqu": "true"
        //      },
        //      "data":{
        //      "querySetIds":[
        //      1,
        //      2
        //      ],
        //      "patternSetIds":[
        //      100
        //      ]
        //          }
        //      }
        /// </param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelTrain(long botId, string modelDesc, string trainOption, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELTRAIN);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["modelDesc"] = modelDesc;
            aipReq.Bodys["trainOption"] = trainOption;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除有效模型
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="modelId">模型 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelDelete(long botId, long modelId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["modelId"] = modelId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  获取样本包列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetList(long botId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETLIST);

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
        /// 新增样本包
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetName">样本包名称，长度范围 1~30</param>
        /// <param name="dictPath">文件下载链接，通过上传接口产生</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetAdd(long botId, string querySetName, string dictPath, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetName"] = querySetName;
            aipReq.Bodys["dictPath"] = dictPath;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除样本包
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetDelete(long botId, long querySetId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查看样本列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="status">查询的列表类型： 0/未标注的 1/已标注的 2/全部的</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryList(long botId, long querySetId, int pageNo, int pageSize, int status, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["status"] = status;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查看样本详细内容
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="queryId">样本 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryInfo(long botId, long querySetId, long queryId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYINFO);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["queryId"] = queryId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 新增样本
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="query">样本信息</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryAdd(long botId, long querySetId, JObject query, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["query"] = JsonConvert.SerializeObject(query, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 修改样本
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="query">样本信息</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryUpdate(long botId, long querySetId, JObject query, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["query"] = JsonConvert.SerializeObject(query, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除样本
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="querySetId">样本包 id</param>
        /// <param name="queryId">样本 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryDelete(long botId, long querySetId, long queryId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["queryId"] = queryId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 获取模板包列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternSetList(long botId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNSETLIST);

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
        /// 查询模板列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="patternSetId">模板包 id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternList(long botId, long patternSetId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查看模板详细信息
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="patternSetId">模板包 id</param>
        /// <param name="patternId">模板 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternInfo(long botId, long patternSetId, long patternId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNINFO);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["patternId"] = patternId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 导入模板
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="patternSetId">模板包 id</param>
        /// <param name="filePath">文件下载链接，通过上传接口产生</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternImport(long botId, long patternSetId, string filePath, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNIMPORT);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["filePath"] = filePath;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 清空模板
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="patternSetId">模板包 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternClear(long botId, long patternSetId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNCLEAR);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查询特征词词典列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordList(long botId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDLIST);

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
        /// 查看特征词词典详情
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="keywordId">keyword id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~5000</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordValue(long botId, long keywordId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDVALUE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 新建特征词
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="keywordName">特征词名称，长度范围 1~20</param>
        /// <param name="keywordDesc">特征词描述，长度范围 0~50</param>
        /// <param name="dictPath">自定义词典下载链接文件，通过上传接口产生</param>
        /// <param name="blacklistDictPath">黑名单词典下载链接，通过上传接口产生</param>
        /// <param name="keywordSysDict">系统词典</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordAdd(long botId, string keywordName, string keywordDesc,
            string dictPath, string blacklistDictPath, JArray keywordSysDict,
            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["keywordName"] = keywordName;
            aipReq.Bodys["keywordDesc"] = keywordDesc;
            aipReq.Bodys["dictPath"] = dictPath;
            aipReq.Bodys["blacklistDictPath"] = blacklistDictPath;
            aipReq.Bodys["keywordSysDict"] = JsonConvert.SerializeObject(keywordSysDict, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 更新特征词
        /// </summary>
        /// <param name="botId">Bot id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordName">特征词名称，长度范围 1~20</param>
        /// <param name="keywordDesc">特征词描述，长度范围 0~50</param>
        /// <param name="dictPath">自定义词典下载链接，通过上传接口产生，
        ///                        若传递空字符串代表清空该特征词，传递保
        ///                        留字符串 KEEP 代表不改内容
        /// </param>
        /// <param name="blacklistDictPath">黑名单词典下载链接，通过上传接口产生，
        ///                                 若传递空字符串代表清空该特征词，传递保留字符串 KEEP 代表不改内容
        /// </param>
        /// <param name="keywordSysDict">系统词典</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordUpdate(long botId, long keywordId, string keywordName,
            string keywordDesc, string dictPath, string blacklistDictPath,
            JArray keywordSysDict, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordName"] = keywordName;
            aipReq.Bodys["keywordDesc"] = keywordDesc;
            aipReq.Bodys["dictPath"] = dictPath;
            aipReq.Bodys["blacklistDictPath"] = blacklistDictPath;
            aipReq.Bodys["keywordSysDict"] = JsonConvert.SerializeObject(keywordSysDict, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除特征词
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordDelete(long botId, long keywordId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["keywordId"] = keywordId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 获取问答对列表
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQList(long botId, long skillId, long intentId,
            int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQLIST);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 查询问答对明细
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="faqId">问答对 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQInfo(long botId, long skillId, long intentId,
            long faqId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQINFO);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["faqId"] = faqId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 新增一个问答对
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="faqQuestions">问题列表</param>
        /// <param name="faqAnswers">回答列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQAdd(long botId, long skillId, long intentId,
            JArray faqQuestions, JArray faqAnswers, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQADD);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["faqQuestions"] = JsonConvert.SerializeObject(faqQuestions, Formatting.Indented);
            aipReq.Bodys["faqAnswers"] = JsonConvert.SerializeObject(faqAnswers, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 更新单个问答对
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="faqId">问答对 id</param>
        /// <param name="faqQuestions">问答对 id</param>
        /// <param name="faqAnswers">回答列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQUpdate(long botId, long skillId, long intentId,
            long faqId, JArray faqQuestions, JArray faqAnswers, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQUPDATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["faqId"] = faqId;
            aipReq.Bodys["faqQuestions"] = JsonConvert.SerializeObject(faqQuestions, Formatting.Indented);
            aipReq.Bodys["faqAnswers"] = JsonConvert.SerializeObject(faqAnswers, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 删除单个问答对
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="faqId">问答对 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQDelete(long botId, long skillId, long intentId,
            long faqId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQDELETE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["faqId"] = faqId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 清空问答对数据
        /// </summary>
        /// <param name="botId">bot Id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQClear(long botId, long skillId, long intentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQCLEAR);

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
        /// 导入问答对
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentId">问答意图 id</param>
        /// <param name="filePath">文件下载链接，通过上传接口产生</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQImport(long botId, long skillId, long intentId, string filePath, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQIMPORT);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["filePath"] = filePath;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        /// <summary>
        /// 上传文件
        /// </summary>
        /// <param name="file">单次上传文件大小限制为 10M，每个用户每个APP 每天上传限制为 100M</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FileUpload(string file, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FILEUPLOAD);
            var fileraw = File.ReadAllBytes(file);
            aipReq.Bodys["file"] = System.Convert.ToBase64String(fileraw);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        ///  查询任务信息
        /// </summary>
        /// <param name="botId">bot Id</param>
        /// <param name="jobId">job id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject JobInfo(long botId, long jobId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(JOBINFO);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["jobId"] = jobId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.8.1 新增生产环境部署
        /// </summary>
        /// <param name="botId">bot Idparam>
        /// <param name="region">部署地域：bj（华北）、su（华东）、gz（华南）只可填写一个部署地域</param>
        /// <param name="modelVersion">模型版本，如果不填写，默认部署当前沙盒生效的模型版本</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentAdd(long botId, string region, string modelVersion = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTADD);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["region"] = region;
            aipReq.Bodys["modelVersion"] = modelVersion;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.8.2 更新生产环境模型版本
        /// </summary>
        /// <param name="botId">bot Idparam>
        /// <param name="region">部署地域：bj（华北）、su（华东）、gz（华南）只可填写一个部署地域</param>
        /// <param name="modelVersion">模型版本，如果不填写，默认部署当前沙盒生效的模型版本</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentUpdateModelVersion(long botId, string region, string modelVersion = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTUPDATEMODELVERSION);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["region"] = region;
            aipReq.Bodys["modelVersion"] = modelVersion;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.8.3 查询部署任务执行状态
        /// </summary>
        /// <param name="botId">bot Id</param>
        /// <param name="deploymentId">部署任务 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentGetStatus(long botId,int deploymentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTGETSTATUS);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["deploymentId"] = deploymentId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.8.4 查询部署任务记录
        /// </summary>
        /// <param name="botId">bot Id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentGetStatus(long botId, int pageNo,int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTLIST);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
    }
}