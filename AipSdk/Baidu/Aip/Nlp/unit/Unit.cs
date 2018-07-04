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
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData,Formatting.Indented);
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
        public JObject SlotList(long botId, long skillId, int pageNo,int pageSize, Dictionary<string, object> options = null)
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
        public JObject SLotValue(long botId,long skillId,long slotId,string slotType,int pageNo,int pageSize,Dictionary<string, object> options = null)
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
        public JObject SLotAdd(long botId, long skillId, string slotName,string slotDesc,
            string slotDictPath,string slotBlacklistDictPath, JArray slotSysDict, 
            int slotDictPathEfficient,int slotSysDictEfficient,
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
        public JObject SLotDelete(long botId, long skillId, long slotId,Dictionary<string, object> options = null)
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
        public JObject ModelTrain(long botId,string modelDesc,string trainOption, Dictionary<string, object> options = null)
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
        public JObject ModelDelete(long botId,long modelId, Dictionary<string, object> options = null)
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
        public JObject QuerySetList(long botId, int pageNo,int pageSize, Dictionary<string, object> options = null)
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
    }
}