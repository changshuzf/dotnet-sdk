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
    public class UnitManagerAPI : AipServiceBase
    {
        /// <summary>
        /// 2.1.1. 查询机器⼈列表
        /// </summary>
        private const string SERVICELIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/list";

        /// <summary>
        /// 2.1.2. 新建机器⼈
        /// </summary>
        private const string SERVICEADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/add";

        /// <summary>
        /// 2.1.3. 修改机器⼈属性
        /// </summary>
        private const string SERVICEUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/update";

        /// <summary>
        /// 2.1.4. 删除机器⼈
        /// </summary>
        private const string SERVICEDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/delete";

        /// <summary>
        /// 2.1.5. 查询机器⼈详情
        /// </summary>
        private const string SERVICELISTSKILL =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/listSkill";

        /// <summary>
        /// 2.1.6. 添加技能
        /// </summary>
        private const string SERVICEADDSKILL =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/addSkill";

        /// <summary>
        /// 2.1.7. 修改技能优先级
        /// </summary>
        private const string SERVICESORTSKILL =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/sortSkill";

        /// <summary>
        /// 2.1.8. 移除技能
        /// </summary>
        private const string SERVICEDELETESKILL =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/service/deleteSkill";

        /// <summary>
        /// 2.2.1. 查询技能列表
        /// </summary>
        private const string SKILLLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/skill/list";

        /// <summary>
        /// 2.2.2. 新建技能
        /// </summary>
        private const string SKILLADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/skill/add";

        /// <summary>
        /// 2.2.3. 修改技能属性
        /// </summary>
        private const string SKILLUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/skill/update";

        /// <summary>
        /// 2.2.4. 删除技能
        /// </summary>
        private const string SKILLDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/skill/delete";

        private const string SETTINGINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/setting/info";

        private const string SETTINGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/setting/update";

        /// <summary>
        /// 2.3.1.1 查询意图列表
        /// </summary>
        private const string INTENTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/intent/list";

        /// <summary>
        /// 2.3.1.2 新建意图
        /// </summary>
        private const string INTENTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/intent/add";

        /// <summary>
        /// 2.3.1.3 查询意图详情
        /// </summary>
        private const string INTENTINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/intent/info";

        /// <summary>
        /// 2.3.1.4 修改意图详情
        /// </summary>
        private const string INTENTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/intent/update";

        /// <summary>
        /// 2.3.1.5. 删除意图
        /// </summary>
        private const string INTENTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/intent/delete";

        /// <summary>
        /// 2.3.2.1 查询词槽列表
        /// </summary>
        private const string SLOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/list";

        /// <summary>
        /// 2.3.2.2. 查询完整的系统词槽列表
        /// </summary>
        private const string SYSSLOTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/sysSlot/list";

        /// <summary>
        /// 2.3.2.4. 查询词槽详情
        /// </summary>
        private const string SLOTINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/info";

        private const string SLOTVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/value";

        /// <summary>
        /// 2.3.2.3. 新建词槽
        /// </summary>
        private const string SLOTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/add";

        /// <summary>
        /// 2.3.2.5. 修改词槽详情
        /// </summary>
        private const string SLOTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/update";

        private const string SLOTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/delete";

        private const string SLOTADDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/addValue";

        private const string SLOTUPDATEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/updateValue";

        private const string SLOTDELETEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/slot/deleteValue";

        private const string MODELLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/list";

        private const string MODELTRAIN =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/train";

        private const string MODELDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/delete";

        private const string QUERYSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/list";

        private const string QUERYSETADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/add";

        private const string QUERYSETDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/delete";

        private const string QUERYLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/list";

        private const string QUERYINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/info";

        private const string QUERYADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/add";

        private const string QUERYUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/update";

        private const string QUERYDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/delete";

        private const string QUERYQUICKANNOTATE =
             "https://aip.baidubce.com/rpc/2.0/unit/query/quickAnnotate";

        private const string PATTERNSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/patternSet/list";

        private const string PATTERNLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/list";

        private const string PATTERNINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/info";

        private const string PATTERNIMPORT =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/import";

        private const string PATTERNCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/clear";

        private const string KEYWORDLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/list";

        private const string KEYWORDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/value";

        private const string KEYWORDADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/add";

        private const string KEYWORDUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/update";

        private const string KEYWORDDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/delete";

        private const string FAQLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/list";

        private const string FAQINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/info";

        private const string FAQADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/add";

        private const string FAQUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/update";

        private const string FAQDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/delete";

        private const string FAQCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/clear";

        private const string FAQIMPORT =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faq/import";

        private const string FILEUPLOAD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/file/upload";

        private const string JOBINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/job/info";

        private const string DEPLOYMENTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/add";

        private const string DEPLOYMENTUPDATEMODELVERSION =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/updateModelVersion";

        private const string DEPLOYMENTGETSTATUS =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/getStatus";

        private const string DEPLOYMENTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/list";

        private const string DEPLOYMENTDELETEREGION =
           "https://aip.baidubce.com/rpc/2.0/unit/deployment/deleteRegion";


        public UnitManagerAPI(string apiKey, string secretKey) : base(apiKey, secretKey)
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
        /// 2.1.1. 查询机器⼈列表
        /// 1）功能描述：查询机器⼈列表
        /// 2）接⼝地址： service/list
        /// </summary>
        /// <param name="pageNo">⻚码⼤于等于1</param>
        /// <param name="pageSize"> 每⻚记录数
        /// <return>JObject</return>
        ///
        public JObject ServiceList(int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICELIST);

            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.2. 新建机器⼈
        /// 1）功能描述：新建机器⼈
        /// 2）接⼝地址： service/add
        /// </summary>
        /// <param name="serviceName">机器⼈名称</param>
        /// <param name="serviceDesc">机器⼈描述</param>
        /// <param name="options"></param>
        /// <returns>JObject</returns>
        public JObject ServiceAdd(string serviceName, string serviceDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEADD);

            aipReq.Bodys["serviceName"] = serviceName;
            aipReq.Bodys["serviceDesc"] = serviceDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.3. 修改机器⼈属性
        /// 1）功能描述：修改机器⼈属性
        /// 2）接⼝地址： service/update
        /// </summary>
        /// <param name="serviceId">机器⼈ID</param>
        /// <param name="serviceName">机器⼈名称</param>
        /// <param name="serviceDesc">机器⼈描述</param>
        /// <param name="options"></param>
        /// <returns>JObject</returns>
        public JObject ServiceUpdate(string serviceId, string serviceName, string serviceDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEUPDATE);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["serviceName"] = serviceName;
            aipReq.Bodys["serviceDesc"] = serviceDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        /// <summary>
        /// 2.1.4. 删除机器⼈
        /// 1）功能描述：修改机器⼈属性
        /// 2）接⼝地址： service/delete
        /// </summary>
        /// <param name="botId">机器⼈ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceDelete(string serviceId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEDELETE);

            aipReq.Bodys["serviceId"] = serviceId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.5. 查询机器⼈详情 
        /// 1) 接⼝描述：查询机器⼈技能列表
        /// 2）接⼝地址： service/listSkill
        /// </summary>
        /// <param name="serviceId">机器⼈ID</param>
        /// <param name="pageNo">⻚码⼤于等于1</param>
        /// <param name="pageSize">每⻚记录数</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceListSkill(string serviceId,string pageNo,string pageSize,Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEDELETE);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.6. 添加技能
        /// 1）接⼝描述：给机器⼈添加技能
        /// 2）接⼝地址： service/addSkill
        /// </summary>
        /// <param name="serviceId">机器⼈ID</param>
        /// <param name="list">技能ID列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceAddSkill(string serviceId, List<string> skillIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEADDSKILL);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["skillIds"] = skillIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.7. 修改技能优先级
        /// 1）接⼝描述：修改技能优先级
        /// 2）接⼝地址： service/sortSkill
        /// </summary>
        /// <param name="serviceId">机器⼈ID</param>
        /// <param name="skillIds">技能ID列表，列表id顺序即为排序顺序</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceSortSkill(string serviceId, List<string> skillIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICESORTSKILL);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["skillIds"] = skillIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.1.8. 移除技能
        /// 1）接⼝描述：移除技能
        /// 2）接⼝地址： service/deleteSkill
        /// </summary>
        /// <param name="serviceId"></param>
        /// <param name="skillIds"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceDeleteSkill(string serviceId, List<string> skillIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEDELETESKILL);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["skillIds"] = skillIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.2.1. 查询技能列表
        /// 1）功能描述：查询开发者的技能列表
        /// 2）接⼝地址： skill/list
        /// </summary>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <param name="skillCategory"></param>
        /// <param name="skillType"></param>
        /// <returns></returns>
        public JObject SkillList(int pageNo, int pageSize, Dictionary<string, object> options = null,string skillCategory = "", string skillType = "")
        {
            var aipReq = DefaultRequest(SKILLLIST);

            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["skillCategory"] = skillCategory;
            aipReq.Bodys["skillType"] = skillType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.2.2. 新建技能
        /// 1）功能描述：新建技能
        /// 2）接⼝地址： skill/add
        /// </summary>
        /// <param name="skillName">技能名称，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围0~50</param>
        /// <param name="skillType">技能类型： dialogue(对话)、 faq(问答); 不填默认为dialogue(对话)</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SkillAdd(string skillName, string skillDesc = "", string skillType = "dialogue", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLADD);

            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            aipReq.Bodys["skillType"] = skillType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.2.3. 修改技能属性
        /// 1）功能描述：修改技能的名称和属性
        /// 2）接⼝地址： skill/update
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="skillName">技能名称，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SkillUpdate(long skillId,string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.2.4. 删除技能
        /// 1）功能描述：删除技能
        /// 2）接⼝地址： skill/delete
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SkillDelete(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLDELETE);

            aipReq.Bodys["skillId"] = skillId;
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
        /// 2.3.1.1 查询意图列表
        /// 1）功能描述：查询账户指定技能的意图列表
        /// 2）接⼝地址： intent/list
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="intentType">意图类型： dialog(对话意图)</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentList(long skillId, int pageNo, int pageSize, string intentType = "dialog", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["intentType"] = intentType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.1.3 查询意图详情
        /// 1）功能描述：查询意图的具体信息
        /// 2）接⼝地址： intent/info
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="intentId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentInfo(long skillId, long intentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.1.2 新建意图
        /// 1）功能描述：新建意图
        /// 2）接⼝地址： intent/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="intentData">意图数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentAdd(long skillId, JObject intentData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.1.4 修改意图详情
        /// 1）功能描述：修改意图
        /// 2）接⼝地址： intent/update
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="intentData">意图数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentUpdate(long skillId, JObject intentData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented);
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.1.5. 删除意图
        /// 1）功能描述：删除意图
        /// 2）接⼝地址： intent/delete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="intentId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject IntentDelete(long skillId, long intentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(INTENTDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["intentId"] = intentId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.2.1 查询词槽列表
        /// 1）功能描述：查询⾃定义词槽列表
        /// 2）接⼝地址： slot/list
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTLIST);

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
        /// 2.3.2.2. 查询完整的系统词槽列表
        /// 1）功能描述：查询系统词槽列表
        /// 2）接⼝地址： sysSlot/list
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
        /// 2.3.2.4. 查询词槽详情
        /// 1）功能描述：查询⾃定义词槽详细信息
        /// 2）接⼝地址： slot/info
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="slotId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotInfo(long skillId, long slotId,Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTINFO);
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;

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
        /// 2.3.2.3. 新建词槽
        /// 1）功能描述：新建词槽
        /// 2）接⼝地址： slot/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotName">词槽名称，⻓度范围1~20</param>
        /// <param name="slotDesc">词槽描述，⻓度范围0~50</param>
        /// <param name="slotClarifyNameList">词槽别名列表，可包含1~10个别名； 别名，⻓度范围1 ~20</param>
        /// <param name="slotSysDict">系统词槽名称</param>
        /// <param name="slotDictEfficient">⾃定义词槽词典和⿊名单词典是否使⽤: 1(使⽤)、 0(未使⽤), 默认为使⽤</param>
        /// <param name="slotSysDictEfficient">系统词槽词典是否使⽤: 1(使⽤)、 0(未使⽤), 默认为使⽤</param>
        /// <param name=""></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotAdd(long skillId,
                                string slotName,
                                string slotDesc = "",
                                JArray slotClarifyNameList = null,
                                JArray slotSysDict = null,
                                int slotDictEfficient = 1,
                                int slotSysDictEfficient = 1,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotName"] = slotName;
            aipReq.Bodys["slotDesc"] = slotDesc;
            aipReq.Bodys["slotClarifyNameList"] = JsonConvert.SerializeObject(slotClarifyNameList, Formatting.Indented);
            aipReq.Bodys["slotSysDict"] = JsonConvert.SerializeObject(slotSysDict, Formatting.Indented);
            aipReq.Bodys["slotDictEfficient"] = slotDictEfficient;
            aipReq.Bodys["slotSysDictEfficient"] = slotSysDictEfficient;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        /// <summary>
        /// 2.3.2.5. 修改词槽详情
        /// 1）功能描述：修改词槽
        /// 2）接⼝地址： slot/update
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotId">词槽id</param>
        /// <param name="slotDictEfficient">⾃定义词槽词典和⿊名单词典是否使⽤: 1(使⽤)、 0(未使⽤)</param>
        /// <param name="slotSysDictEfficient">系统词槽词典是否使⽤: 1(使⽤)、 0(未使⽤)</param>
        /// <param name="slotDesc">词槽描述，⻓度范围0~50</param>
        /// <param name="slotClarifyNameList">词槽别名列表，可包含1~10个别名； 别名，⻓度范围1~20</param>
        /// <param name="slotSysDict">系统词槽名称</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotUpdate(long skillId,
                                    long slotId,
                                    int slotDictEfficient,
                                    int slotSysDictEfficient,
                                    string slotDesc = "",
                                    JArray slotClarifyNameList = null,
                                    JArray slotSysDict = null,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotDesc"] = slotDesc;
            aipReq.Bodys["slotClarifyNameList"] = JsonConvert.SerializeObject(slotClarifyNameList, Formatting.Indented);
            aipReq.Bodys["slotSysDict"] = JsonConvert.SerializeObject(slotSysDict, Formatting.Indented);
            aipReq.Bodys["slotDictEfficient"] = slotDictEfficient;
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
        /// V1.7.6 2.4.8 新增词槽词典值
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="skillId"></param>
        /// <param name="slotId"></param>
        /// <param name="slotType"></param>
        /// <param name="slotValue"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotAddValue(long botId, long skillId, long slotId,string slotType,string slotValue, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTADDVALUE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["slotValue"] = slotValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// V1.7.6 2.4.9 更新词槽词典值 
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="skillId"></param>
        /// <param name="slotId"></param>
        /// <param name="slotType"></param>
        /// <param name="valueId"></param>
        /// <param name="slotValue"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotUpdateValue(long botId, long skillId, long slotId, string slotType,long valueId, string slotValue, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATEVALUE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["valueId"] = valueId;
            aipReq.Bodys["slotValue"] = slotValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// V1.7.6 2.4.10 删除词槽词典值
        /// </summary>
        /// <param name="botId">bot id</param>
        /// <param name="skillId">技能 id</param>
        /// <param name="slotId">词槽 id</param>
        /// <param name="slotType">词槽词典类别，开发者自定义(user)/黑名单(black)</param>
        /// <param name="valueId">词槽词典值 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotDeleteValue(long botId, long skillId, long slotId, string slotType, long valueId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATEVALUE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["valueId"] = valueId;
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
        /// V1.7.6 2.6.1.9 批量确认样本
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="querySetId"></param>
        /// <param name="queryIds"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryQuickAnnotate(long botId, long querySetId, List<long> queryIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYQUICKANNOTATE);

            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["queryIds"] = queryIds;
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
        public JObject DeploymentList(long botId, int pageNo,int pageSize, Dictionary<string, object> options = null)
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

        /// <summary>
        /// V1.7.6 2.8.5 删除生产环境
        /// </summary>
        /// <param name="botId"></param>
        /// <param name="region">部署地域：bj（华北）、 su（华东）、 gz（华南）只可填写一个部署地域</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentDeleteRegion(long botId, string region, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTDELETEREGION);
            aipReq.Bodys["botId"] = botId;
            aipReq.Bodys["region"] = region;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
    }
}