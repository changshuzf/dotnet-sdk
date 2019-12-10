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
        #region 2.1 机器⼈
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
        #endregion

        #region 2.2. 技能管理
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
        #endregion

        #region 2.3. 对话技能
        #region 2.3.1 意图
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
        #endregion

        #region 2.3.2 词槽
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
        /// 2.3.2.3. 新建词槽
        /// </summary>
        private const string SLOTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/add";

        /// <summary>
        /// 2.3.2.4. 查询词槽详情
        /// </summary>
        private const string SLOTINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/info";

        /// <summary>
        /// 2.3.2.5. 修改词槽详情
        /// </summary>
        private const string SLOTUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/update";

        /// <summary>
        /// 2.3.2.6. 删除词槽
        /// </summary>
        private const string SLOTDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/delete";

        /// <summary>
        /// 2.3.2.7. 查询⾃定义词槽词典值列表
        /// </summary>

        private const string SLOTVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/value";

        /// <summary>
        /// 2.3.2.8. 新建⾃定义词典值
        /// </summary>
        private const string SLOTADDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/addValue";

        /// <summary>
        /// 2.3.2.9. 修改⾃定义词典值
        /// </summary>
        private const string SLOTUPDATEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/updateValue";

        /// <summary>
        /// 2.3.2.10. 删除⾃定义词典值
        /// </summary>
        private const string SLOTDELETEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/slot/deleteValue";
        #endregion

        #region 2.3.3. 对话模板
        /// <summary>
        /// 2.3.3.1. 查询对话模板列表
        /// </summary>
        private const string PATTERNLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/list";

        /// <summary>
        /// 2.3.3.2. 新建对话模板
        /// </summary>
        private const string PATTERNADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/add";

        /// <summary>
        /// 2.3.3.3. 查询对话模板详情
        /// </summary>
        private const string PATTERNINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/info";

        /// <summary>
        /// 2.3.3.4. 修改对话模板详情
        /// </summary>
        private const string PATTERNUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/update";

        /// <summary>
        /// 2.3.3.5. 修改对话模板优先级
        /// </summary>
        private const string PATTERNPRIORITY =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/priority";

        /// <summary>
        /// 2.3.3.6. 删除对话模板(批量)
        /// </summary>
        private const string PATTERNBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/pattern/batchDelete";

        /// <summary>
        /// 2.3.3.7. 获取模板包列表
        /// </summary>
        private const string PATTERNSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/patternSet/list";
        #endregion

        #region 2.3.4. 特征词
        /// <summary>
        /// 2.3.4.1. 查询特征词列表
        /// </summary>
        private const string KEYWORDLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/list";

        /// <summary>
        /// 2.3.4.2. 新建特征词
        /// </summary>
        private const string KEYWORDADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/add";

        /// <summary>
        /// 2.3.4.3. 删除特征词
        /// </summary>
        private const string KEYWORDBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/batchDelete";

        /// <summary>
        /// 2.3.4.4. 查询特征词词典值列表
        /// </summary>
        private const string KEYWORDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/value";

        /// <summary>
        /// 2.3.4.5. 新建特征词词典值
        /// </summary>
        private const string KEYWORDADDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/addValue";

        /// <summary>
        /// 2.3.4.6. 修改特征词词典值
        /// </summary>
        private const string KEYWORDUPDATEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/updateValue";

        /// <summary>
        /// 2.3.4.7. 删除特征词词典值
        /// </summary>
        private const string KEYWORDDELETEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/deleteValue";

        /// <summary>
        /// 2.3.4.8. 清空特征词词典值
        /// 1）功能描述：清空特征词词典值
        /// 2）接⼝地址： keyword/clearValue
        /// </summary>
        private const string KEYWORDCLEARVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/keyword/clearValue";
        #endregion

        #region 2.3.5. ⼝语化词
        /// <summary>
        /// 2.3.5.1. 查询⼝语化词列表
        /// </summary>
        private const string OMITLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/list";

        /// <summary>
        /// 2.3.5.2. 新建⼝语化词
        /// </summary>
        private const string OMITADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/add";

        /// <summary>
        /// 2.3.5.3. 修改⼝语化词
        /// </summary>
        private const string OMITUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/update";

        /// <summary>
        /// 2.3.5.4. 删除⼝语化词
        /// </summary>
        private const string OMITBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/batchDelete";

        /// <summary>
        /// 2.3.5.5. 清空⼝语化词
        /// </summary>
        private const string OMITCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/clear";

        /// <summary>
        /// 2.3.5.6. 重置⼝语化词
        /// </summary>
        private const string OMITRESET =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/omit/reset";
        #endregion

        #region 2.3.6. 对话样本
        /// <summary>
        /// 2.3.6.1. 查询对话样本集列表
        /// </summary>
        private const string QUERYSETLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/list";

        /// <summary>
        /// 2.3.6.2. 新建对话样本集
        /// </summary>
        private const string QUERYSETADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/add";

        /// <summary>
        /// 2.3.6.3. 修改对话样本集
        /// </summary>
        private const string QUERYSETUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/update";

        /// <summary>
        /// 2.3.6.4. 合并对话样本集
        /// </summary>
        private const string QUERYSETMERGE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/merge";

        /// <summary>
        /// 2.3.6.5. 删除对话样本集
        /// </summary>
        private const string QUERYSETDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/querySet/delete";

        /// <summary>
        /// 2.3.6.6. 查询对话样本列表
        /// </summary>
        private const string QUERYLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/list";

        /// <summary>
        /// 2.3.6.8. 查询对话样本详情
        /// </summary>
        private const string QUERYINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/info";

        /// <summary>
        /// 2.3.6.7. 新建对话样本
        /// </summary>
        private const string QUERYADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/add";

        /// <summary>
        /// 2.3.6.9. 修改对话样本详情
        /// </summary>
        private const string QUERYUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/update";

        private const string QUERYDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/delete";

        /// <summary>
        /// 2.3.6.10 确认对话样本(批量）
        /// </summary>
        private const string QUERYQUICKANNOTATE =
             "https://aip.baidubce.com/rpc/2.0/unit/v3/query/quickAnnotate";

        /// <summary>
        /// 2.3.6.11 删除对话样本(批量）
        /// </summary>
        private const string QUERYBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/query/batchDelete";
        #endregion

        #region 2.3.7. 模型
        /// <summary>
        /// 2.3.7.1. 查询模型列表
        /// </summary>
        private const string MODELLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/list";

        /// <summary>
        /// 2.3.7.2. 训练模型
        /// </summary>
        private const string MODELTRAIN =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/train";

        /// <summary>
        /// 2.3.7.3. ⽣效到沙盒
        /// </summary>
        private const string MODELEFFECT =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/effect";

        /// <summary>
        /// 2.3.7.4. 删除有效模型
        /// </summary>
        private const string MODELDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/model/delete";
        #endregion

        #region 2.3.8. 设置
        /// <summary>
        /// 2.3.8.1 查询⾼级设置
        /// </summary>
        private const string SETTINGINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/setting/info";

        /// <summary>
        /// 2.3.8.2. 修改⾼级设置
        /// </summary>
        private const string SETTINGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/setting/update";
        #endregion

        #region 2.3.9. 分享码
        /// <summary>
        /// 2.3.9.1. 查询分享码状态
        /// </summary>
        private const string SHARECODESTATUS =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/shareCode/status";

        /// <summary>
        /// 2.3.9.2. 启⽤分享码
        /// </summary>
        private const string SHARECODESTART =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/shareCode/start";

        /// <summary>
        /// 2.3.9.3. 终⽌分享码
        /// </summary>
        private const string SHARECODESTOP =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/shareCode/stop";

        /// <summary>
        /// 2.3.9.4. 使⽤分享码复制技能
        /// </summary>
        private const string SKILLCOPY =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/skill/copy";
        #endregion
        #endregion

        #region 2.4 问答技能
        #region 2.4.1. 问答对
        /// <summary>
        /// 2.4.1.1. 查询问答对列表
        /// </summary>
        private const string FAQSKILLFAQPAIRLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/list";

        /// <summary>
        /// 2.4.1.2. 新建问答对
        /// </summary>
        private const string FAQSKILLFAQPAIRADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/add";

        /// <summary>
        /// 2.4.1.3. 查询问答对详情
        /// </summary>
        private const string FAQSKILLFAQPAIRINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/info";

        /// <summary>
        /// 2.4.1.4. 修改问答对详情
        /// </summary>
        private const string FAQSKILLFAQPAIRUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/update";

        /// <summary>
        /// 2.4.1.5. 修改问答对标签(批量)
        /// </summary>
        private const string FAQSKILLFAQPAIRUPDATETAGS =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/updateTags";

        /// <summary>
        /// 2.4.1.6. 删除问答对(批量)
        /// </summary>
        private const string FAQSKILLFAQPAIRBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/batchDelete";

        /// <summary>
        /// 2.4.1.7. 查找问答对
        /// </summary>
        private const string FAQSKILLFAQPAIRSEARCH =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/faqPair/search";
        #endregion
        #region 2.4.2. 特征词
        /// <summary>
        /// 2.4.2.1. 查询特征词列表
        /// </summary>
        private const string FAQSKILLKEYWORDLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/list";

        /// <summary>
        /// 2.4.2.2. 新建特征词
        /// 1）功能描述：新建特征词
        /// 2）接⼝地址： faqskill/keyword/add
        /// </summary>
        private const string FAQSKILLKEYWORDADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/add";

        /// <summary>
        /// 2.4.2.3. 删除特征词
        /// </summary>
        private const string FAQSKILLKEYWORDBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/batchDelete";

        /// <summary>
        /// 2.4.2.4. 查询特征词词典值列表
        /// 1）功能描述：查看特征词词典值列表
        /// 2）接⼝地址： faqskill/keyword/value
        /// </summary>
        private const string FAQSKILLKEYWORDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/value";

        /// <summary>
        /// 2.4.2.5. 新建特征词词典值
        /// </summary>
        private const string FAQSKILLKEYWORDADDVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/addValue";

        /// <summary>
        /// 2.4.2.6. 修改特征词词典值
        /// </summary>
        private const string FAQSKILLKEYWORDUPDATEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/updateValue";

        /// <summary>
        /// 2.4.2.7. 删除特征词词典值
        /// </summary>
        private const string FAQSKILLKEYWORDDELETEVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/deleteValue";

        /// <summary>
        /// 2.4.2.8. 清空特征词词典值
        /// </summary>
        private const string FAQSKILLKEYWORDCLEARVALUE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/keyword/clearValue";
        #endregion
        #region 2.4.3. 问答技能-标签
        /// <summary>
        /// 2.4.3.1. 查询标签列表
        /// </summary>
        private const string TAGLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/list";

        /// <summary>
        /// 2.4.3.2. 新建标签
        /// </summary>
        private const string TAGADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/add";

        /// <summary>
        /// 2.4.3.3. 修改标签
        /// </summary>
        private const string TAGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/update";

        /// <summary>
        /// 2.4.3.4. 更新标签顺序
        /// </summary>
        private const string TAGSORT =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/sort";

        /// <summary>
        /// 2.4.3.5. 删除标签(批量)
        /// </summary>
        private const string TAGBATCHDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/batchDelete";

        /// <summary>
        /// 2.4.3.6. 标签查找
        /// </summary>
        private const string TAGSEARCH =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/tag/search";


        #endregion 2.4.3. 问答技能-标签
        #region 2.4.4. 模型
        /// <summary>
        /// 2.4.4.1. 查询模型列表
        /// </summary>
        private const string FAQSKILLMODELLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/model/list";

        /// <summary>
        /// 2.4.4.2. 训练模型
        /// </summary>
        private const string FAQSKILLMODELTRAIN =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/model/train";

        /// <summary>
        /// 2.4.4.3. ⽣效到沙盒
        /// </summary>
        private const string FAQSKILLMODELEFFECT =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/model/effect";

        /// <summary>
        /// 2.4.4.4. 删除有效模型
        /// </summary>
        private const string FAQSKILLMODELDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/model/delete";

        #endregion 2.4.4. 模型
        #region 2.4.5. 设置
        /// <summary>
        /// 2.4.5.1 查询⾼级设置
        /// </summary>
        private const string FAQSKILLSETTINGINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/setting/info";

        /// <summary>
        /// 2.4.5.2. 修改⾼级设置
        /// </summary>
        private const string FAQSKILLSETTINGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/setting/update";
        #endregion
        #region 2.4.6. 分享码
        /// <summary>
        /// 2.4.6.1. 查询分享码状态
        /// </summary>
        private const string FAQSKILLSHARECODESTATUS =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/shareCode/status";

        /// <summary>
        /// 2.4.6.2. 启⽤分享码
        /// </summary>
        private const string FAQSKILLSHARECODESTART =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/shareCode/start";

        /// <summary>
        /// 2.4.6.3. 终⽌分享码
        /// </summary>
        private const string FAQSKILLSHARECODESTOP =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/shareCode/stop";

        /// <summary>
        /// 2.4.6.4. 使⽤分享码复制技能
        /// </summary>
        private const string FAQSKILLSKILLCOPY =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/faqskill/skill/copy";
        #endregion
        #endregion

        #region 2.5 对话式⽂档问答技能

        #region 2.5.1. 技能
        /// <summary>
        /// 2.5.1.1. 查询技能列表
        /// </summary>
        private const string DDAQSKILLLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/skill/list";

        /// <summary>
        /// 2.5.1.2. 新建技能
        /// </summary>
        private const string DDAQSKILLADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/skill/add";

        /// <summary>
        /// 2.5.1.3. 修改技能属性
        /// </summary>
        private const string DDAQSKILLUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/skill/update";

        /// <summary>
        /// 2.5.1.4. 删除技能
        /// </summary>
        private const string DDAQSKILLDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/skill/delete";
        #endregion 2.5.1. 技能 

        #region 2.5.2. ⽂档
        /// <summary>
        /// 2.5.2.1. 查询⽂档列表
        /// </summary>
        private const string DDQAFILELIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/file/list";

        /// <summary>
        /// 2.5.2.2. 上传⽂档
        /// </summary>
        private const string DDQAFILEUPLOAD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/file/upload";

        /// <summary>
        /// 2.5.2.3. 删除⽂档
        /// </summary>
        private const string DDQAFILEDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/file/delete";
        #endregion 2.5.2. ⽂档

        #region 2.5.3. 模型
        /// <summary>
        /// 2.5.3.1. 训练模型
        /// </summary>
        private const string DDQAMODELTRAIN =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/model/train";
        #endregion 2.5.3. 模型

        #region 2.5.4. 设置
        /// <summary>
        /// 2.5.4.1. 对话式⽂档问答阈值设置
        /// </summary>
        private const string DDQASETTINGUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/ddaq/setting/update";
        #endregion 2.5.4. 设置

        #endregion 2.5 对话式⽂档问答技能

        #region 2.6. 结构化知识问答技能
        #region 2.6.1. 技能
        /// <summary>
        /// 2.6.1.1. 查询技能列表
        /// </summary>
        private const string KBQASKILLLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/skill/list";

        /// <summary>
        /// 2.6.1.2. 新建技能
        /// </summary>
        private const string KBQASKILLADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/skill/add";

        /// <summary>
        /// 2.6.1.3. 修改技能属性
        /// </summary>
        private const string KBQASKILLUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/skill/update";

        /// <summary>
        /// 2.6.1.4. 删除技能
        /// </summary>
        private const string KBQASKILLDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/skill/delete";
        #endregion 2.6.1. 技能
        #region 2.6.2. Schema
        /// <summary>
        /// 2.6.2.1. 查询 schema 列表
        /// </summary>
        private const string KBQASCHEMALIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/schema/list";

        /// <summary>
        /// 2.6.2.2. 查询 schema 信息
        /// </summary>
        private const string KBQASCHEMAINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/schema/info";

        /// <summary>
        /// 2.6.2.3. 新建 schema
        /// </summary>
        private const string KBQASCHEMAADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/schema/add";

        /// <summary>
        /// 2.6.2.4. 更新 schema
        /// </summary>
        private const string KBQASCHEMAUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/schema/update";

        /// <summary>
        /// 2.6.2.5. 删除 schema
        /// </summary>
        private const string KBQASCHEMADELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/schema/delete";
        #endregion 2.6.2. Schema
        #region 2.6.3. Record数据
        /// <summary>
        /// 2.6.3.1. 查询 record 列表
        /// </summary>
        private const string KBQARECORDLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/list";

        /// <summary>
        /// 2.6.3.2. 查询 record 信息
        /// </summary>
        private const string KBQARECORDINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/info";

        /// <summary>
        /// 2.6.3.3. 添加 record 数据
        /// </summary>
        private const string KBQARECORDADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/add";

        /// <summary>
        /// 2.6.3.4. 修改 record 数据
        /// </summary>
        private const string KBQARECORDUPDATE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/update";

        /// <summary>
        /// 2.6.3.5. 删除 record 数据
        /// </summary>
        private const string KBQARECORDDELETE =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/delete";

        /// <summary>
        /// 2.6.3.6. 清除 record 数据
        /// </summary>
        private const string KBQARECORDCLEAR =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/record/clear";
        #endregion 2.6.3. Record数据
        #region 2.6.4. Synoym同义词对
        /// <summary>
        /// 2.6.4.1. 查询同义词对列表
        /// </summary>
        private const string KBQAOPTIMIZATIONSYNONYMLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/synonymList";

        /// <summary>
        /// 2.6.4.2. 查询同义词对信息
        /// </summary>
        private const string KBQAOPTIMIZATIONSYNONYMINFO =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/synonymInfo";

        /// <summary>
        /// 2.6.4.3. 添加同义词对
        /// </summary>
        private const string KBQAOPTIMIZATIONADDSYNONYM =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/addSynonym";

        /// <summary>
        /// 2.6.4.4. 修改同义词对
        /// </summary>
        private const string KBQAOPTIMIZATIONUPDATESYNONYM =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/updateSynonym";

        /// <summary>
        /// 2.6.4.5. 删除同义词对
        /// </summary>
        private const string KBQAOPTIMIZATIONDELETESYNONYM =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/deleteSynonym";

        /// <summary>
        /// 2.6.4.6. 清除同义词对
        /// </summary>
        private const string KBQAOPTIMIZATIONCLEARSYNONYM =
           "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/clearSynonym";
        #endregion
        #region 2.6.5. Reply回复话术
        /// <summary>
        /// 2.6.5.1. 查询回复话术列表
        /// </summary>
        private const string KBQAOPTIMIZATIONREPLYLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/replyList";

        /// <summary>
        /// 2.6.5.2. 查询回复话术信息
        /// </summary>
        private const string KBQAOPTIMIZATIONREPLYINFO =
           "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/replyInfo";

        /// <summary>
        /// 2.6.5.3. 添加回复话术配置
        /// </summary>
        private const string KBQAOPTIMIZATIONADDREPLY =
          "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/addReply";

        /// <summary>
        /// 2.6.5.4. 修改回复话术配置
        /// </summary>
        private const string KBQAOPTIMIZATIONUPDATEREPLY =
          "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/updateReply";

        /// <summary>
        /// 2.6.5.5. 删除回复话术配置
        /// </summary>
        private const string KBQAOPTIMIZATIONDELETEREPLY =
          "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/deleteReply";

        /// <summary>
        /// 2.6.5.6. 清除回复话术配置
        /// </summary>
        private const string KBQAOPTIMIZATIONDCLEARREPLY =
          "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/optimization/clearReply";

        #endregion
        #region 2.6.6. 模型
        /// <summary>
        /// 2.6.6.1. 查询模型列表
        /// </summary>
        private const string KBQAMODELLIST =
           "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/model/list";

        /// <summary>
        /// 2.6.6.2. 训练模型
        /// </summary>
        private const string KBQAMODELTRAIN =
           "https://aip.baidubce.com/rpc/2.0/unit/v3/kbqa/model/train";
        #endregion
        #endregion 2.6. 结构化知识问答技能

        #region 2.7. ⽣产环境部署（含模型发布）
        /// <summary>
        /// 2.7.1. 新增⽣产环境部署
        /// </summary>
        private const string DEPLOYMENTADD =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/add";

        /// <summary>
        /// 2.7.2. 更新⽣产环境模型版本
        /// </summary>
        private const string DEPLOYMENTUPDATEMODELVERSION =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/updateModelVersion";

        /// <summary>
        /// 2.7.3. 查询部署任务执⾏状态
        /// </summary>
        private const string DEPLOYMENTGETSTATUS =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/getStatus";

        /// <summary>
        /// 2.7.4. 查询部署任务记录
        /// </summary>
        private const string DEPLOYMENTLIST =
            "https://aip.baidubce.com/rpc/2.0/unit/v3/deployment/list";

        /// <summary>
        /// 2.7.5. 删除⽣产环境
        /// </summary>
        private const string DEPLOYMENTDELETEREGION =
           "https://aip.baidubce.com/rpc/2.0/unit/deployment/deleteRegion";
        #endregion

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

        #region 2.1 机器⼈
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
        public JObject ServiceListSkill(string serviceId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICELISTSKILL);

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
        /// <param name="serviceId">机器⼈ID</param>
        /// <param name="skillId">技能ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ServiceDeleteSkill(string serviceId, int skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SERVICEDELETESKILL);

            aipReq.Bodys["serviceId"] = serviceId;
            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.2. 技能管理
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
        public JObject SkillList(int pageNo, int pageSize, Dictionary<string, object> options = null, string skillCategory = "", string skillType = "")
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
        public JObject SkillUpdate(long skillId, string skillName, string skillDesc = "", Dictionary<string, object> options = null)
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
        #endregion
        #region 2.3. 对话技能
        #region 2.3.1 意图
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
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
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
            aipReq.Bodys["intentData"] = JsonConvert.SerializeObject(intentData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
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
        #endregion
        #region 2.3.2 词槽
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
        /// 2.3.2.3. 新建词槽
        /// 1）功能描述：新建词槽
        /// 2）接⼝地址： slot/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotName">词槽名称，⻓度范围1~20 必须以user_ 开头</param>
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
                                string slotDesc = null,
                                List<string> slotClarifyNameList = null,
                                List<SlotSysDict> slotSysDict = null,
                                int slotDictEfficient = 1,
                                int slotSysDictEfficient = 1,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotName"] = slotName;
            if (slotDesc != null)
            {
                aipReq.Bodys["slotDesc"] = slotDesc;
            }
            if (slotClarifyNameList != null)
            {
                aipReq.Bodys["slotClarifyNameList"] = slotClarifyNameList;
            }
            if (slotSysDict != null)
            {
                aipReq.Bodys["slotSysDict"] = slotSysDict;

            }
            aipReq.Bodys["slotDictEfficient"] = slotDictEfficient;
            aipReq.Bodys["slotSysDictEfficient"] = slotSysDictEfficient;
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
        public JObject SlotInfo(long skillId, long slotId, Dictionary<string, object> options = null)
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
                                    List<SlotSysDict> slotSysDict,
                                    string slotDesc = null,
                                    List<string> slotClarifyNameList = null,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotDictEfficient"] = slotDictEfficient;
            aipReq.Bodys["slotSysDictEfficient"] = slotSysDictEfficient;
            aipReq.Bodys["slotSysDict"] = slotSysDict;
            if (slotDesc != null)
            {
                aipReq.Bodys["slotDesc"] = slotDesc;
            }
            if (slotClarifyNameList != null)
            {
                aipReq.Bodys["slotClarifyNameList"] = slotClarifyNameList;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        /// <summary>
        /// 2.3.2.6. 删除词槽
        /// 1）功能描述：删除词槽
        /// 2）接⼝地址： slot/delete
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotId">词槽id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SLotDelete(long skillId, long slotId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.2.7. 查询⾃定义词槽词典值列表
        /// 1）功能描述：查询⾃定义词槽词典值列表
        /// 2）接⼝地址： slot/value
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotId">词槽id</param>
        /// <param name="slotType">词槽词典类别，开发者⾃定义(user)/⿊名单(black)，传递空字符串时返回所有类型</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~5000</param>
        /// <param name="isNormalizedValue">词槽词典值是否为归⼀格式， 1(是)、 0(否)，不传不进⾏此项筛选</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotValue(long skillId,
                                    long slotId,
                                    string slotType,
                                    int pageNo,
                                    int pageSize,
                                    int isNormalizedValue = 0,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["isNormalizedValue"] = isNormalizedValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.2.8. 新建⾃定义词典值
        /// 1）功能描述：新建⾃定义词典值
        /// 2）接⼝地址： slot/addValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotId">词槽id</param>
        /// <param name="slotValue">词槽词典值</param>
        /// <param name="slotType">词槽词典类别，开发者⾃定义(user)/⿊名单(black),默认为user</param>
        /// <param name="slotNormalizedValue">词槽词典值归⼀化值，默认为空（词典值⽆归⼀化词）。当词典类别为⿊名单时，归⼀化值⽆效。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotAddValue(long skillId,
                                    long slotId,
                                    string slotValue,
                                    string slotType = "user",
                                    string slotNormalizedValue = "",
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTADDVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotValue"] = slotValue;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["slotNormalizedValue"] = slotNormalizedValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        /// <summary>
        /// 2.3.2.9. 修改⾃定义词典值
        /// 1）功能描述：修改⾃定义词典值
        /// 2）接⼝地址： slot/updateValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="slotId">词槽id</param>
        /// <param name="slotType">词槽词典类别，开发者⾃定义(user)/⿊名单(black)</param>
        /// <param name="valueId">词槽词典值id</param>
        /// <param name="slotValue">词槽词典值</param>
        /// <param name="slotNormalizedValue">词槽词典值归⼀化值，默认为空（词典值⽆归⼀化词）。当词典类别为⿊名单时，归⼀化值⽆效</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotUpdateValue(long skillId,
                                        long slotId,
                                        string slotType,
                                        long valueId,
                                        string slotValue,
                                        string slotNormalizedValue = "",
                                        Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTUPDATEVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["slotId"] = slotId;
            aipReq.Bodys["slotType"] = slotType;
            aipReq.Bodys["valueId"] = valueId;
            aipReq.Bodys["slotValue"] = slotValue;
            aipReq.Bodys["slotNormalizedValue"] = slotNormalizedValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.2.10. 删除⾃定义词典值
        /// 1）功能描述：删除⾃定义词典值
        /// 2）接⼝地址： slot/deleteValue
        /// </summary>
        /// <param name="skillId">技能id/param>
        /// <param name="slotId">词槽id</param>
        /// <param name="slotType">词槽词典类别，开发者⾃定义(user)/⿊名单(black)</param>
        /// <param name="valueId">词槽词典值id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SlotDeleteValue(long skillId, long slotId, string slotType, long valueId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SLOTDELETEVALUE);

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
        #endregion
        #region 2.3.3. 对话模板
        /// <summary>
        /// 2.3.3.1. 查询对话模板列表
        /// 1）功能描述：查询对话模板列表
        /// 2）接⼝地址： pattern/list
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="patternSetId"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternList(long skillId, long patternSetId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNLIST);

            aipReq.Bodys["skillId"] = skillId;
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
        /// 2.3.3.2. 新建对话模板
        /// 1）功能描述：新建对话模板
        /// 2）接⼝地址： pattern/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="patternSetId">模板包id</param>
        /// <param name="intentId">意图id</param>
        /// <param name="threshold">阈值</param>
        /// <param name="content">模板内容</param>
        /// <param name="filledOtherSlotsLabel">解析返回所有词槽： 1-是； 0-否；默认为1</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternAdd(long skillId,
                                    long patternSetId,
                                    long intentId,
                                    float threshold,
                                    JArray content,
                                    int filledOtherSlotsLabel = 1,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNADD);

            aipReq.Bodys["botId"] = skillId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["threshold"] = threshold;
            aipReq.Bodys["content"] = JsonConvert.SerializeObject(content, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["filledOtherSlotsLabel"] = filledOtherSlotsLabel;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.3.3. 查询对话模板详情
        /// 1）功能描述：查询对话模板详情
        /// 2）接⼝地址： pattern/info
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="patternSetId">模板包id</param>
        /// <param name="patternId">模板id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternInfo(long skillId, long patternSetId, long patternId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["patternId"] = patternId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.3.4. 修改对话模板详情
        /// 1）功能描述：修改对话模板
        /// 2）接⼝地址： pattern/update
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="patternId">模板id</param>
        /// <param name="intentId">意图id</param>
        /// <param name="threshold">阈值</param>
        /// <param name="content">模板内容</param>
        /// <param name="filledOtherSlotsLabel">解析返回所有词槽： 1-是； 0-否；默认为1</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternUpdate(long skillId,
                                    long patternId,
                                    long intentId,
                                    float threshold,
                                    JArray content,
                                    int filledOtherSlotsLabel = 1,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["patternId"] = patternId;
            aipReq.Bodys["intentId"] = intentId;
            aipReq.Bodys["threshold"] = threshold;
            aipReq.Bodys["content"] = JsonConvert.SerializeObject(content, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["filledOtherSlotsLabel"] = filledOtherSlotsLabel;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.3.5. 修改对话模板优先级
        /// 1）功能描述：置顶、置底对话模板顺序
        /// 2）接⼝地址： pattern/priority
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="patternId"></param>
        /// <param name="adjustType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternPriority(long skillId,
                                    long patternId,
                                    string adjustType,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNPRIORITY);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["patternId"] = patternId;
            aipReq.Bodys["adjustType"] = adjustType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.3.6. 删除对话模板(批量)
        /// 1）功能描述：删除已有对话模板(批量)
        /// 2）接⼝地址： pattern/batchDelete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="patternSetId"></param>
        /// <param name="patternIds"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternBatchDelete(long skillId,
                            long patternSetId,
                            JArray patternIds,
                            int pageSize = 10,
                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["patternSetId"] = patternSetId;
            aipReq.Bodys["patternIds"] = JsonConvert.SerializeObject(patternIds, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.3.7. 获取模板包列表
        /// 1）功能描述：获取模板包列表
        /// 2）接⼝地址： patternSet/list
        /// </summary>
        /// <param name="botId">技能 id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject PatternSetList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(PATTERNSETLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.3.4. 特征词
        /// <summary>
        /// 2.3.4.1. 查询特征词列表
        /// 1）功能描述：查询特征词列表
        /// 2）接⼝地址： keyword/list
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDLIST);

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
        /// 2.3.4.2. 新建特征词
        /// 1）功能描述：新建特征词
        /// 2）接⼝地址： keyword/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordName">特征词名称，⻓度范围1~20, 以kw_开头</param>
        /// <param name="keywordValues">特征词词典值</param>
        /// <param name="keywordDesc">特征词描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordAdd(long skillId,
                                string keywordName,
                                List<string> keywordValues,
                                string keywordDesc = null,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordName"] = keywordName;
            aipReq.Bodys["keywordValues"] = keywordValues;
            if (keywordDesc != null)
            {
                aipReq.Bodys["keywordDesc"] = keywordDesc;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.4.3. 删除特征词
        /// 1）功能描述：删除特征词(批量)
        /// 2）接⼝地址： keyword/batchDelete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="keywordIds"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordBatchDelete(long skillId, List<long> keywordIds, int pageSize = 0, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordIds"] = keywordIds;
            if (pageSize != 0)
            {
                aipReq.Bodys["pageSize"] = pageSize;
            }

            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.4.4. 查询特征词词典值列表
        /// 1）功能描述：查看特征词词典值列表
        /// 2）接⼝地址： keyword/value
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="keywordId"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="keywordType"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordValue(long skillId, long keywordId, int pageNo, int pageSize, string keywordType = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["keywordType"] = keywordType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.4.5. 新建特征词词典值
        /// 1）功能描述：新建特征词词典值
        /// 2）接⼝地址： keyword/addValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">keyword id</param>
        /// <param name="keywordType">特征词类型:user(⽤户词典值); black(⿊名单)</param>
        /// <param name="keywordValue">特征词词典值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordAddValue(long skillId,
                                        long keywordId,
                                        string keywordType,
                                        string keywordValue,
                                        Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDADDVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordType"] = keywordType;
            aipReq.Bodys["keywordValue"] = keywordValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        

        /// <summary>
        /// 2.3.4.6. 修改特征词词典值
        /// 1）功能描述：修改特征词词典值
        /// 2）接⼝地址： keyword/updateValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordValueId">特征词词典值 id</param>
        /// <param name="keywordValue">特征词词典值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordUpdateValue(long skillId,
            long keywordId,
            long keywordValueId,
            string keywordValue,
            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDUPDATEVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordValueId"] = keywordValueId;
            aipReq.Bodys["keywordValue"] = keywordValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.4.7. 删除特征词词典值
        /// 1）功能描述：删除特征词词典值
        /// 2）接⼝地址： keyword/deleteValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordValueIds">特征词词典值id列表</param>
        /// <param name="keywordType">特征词词典值类型，⽤于前端返回删除后当前⻚码</param>
        /// <param name="pageSize">每⻚⼤⼩，⽤于前端返回删除后当前⻚码</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordDeleteValue(long skillId,
                                        long keywordId,
                                        List<long> keywordValueIds,
                                        string keywordType = null,
                                        int pageSize = 0,
                                        Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDDELETEVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordValueIds"] = keywordValueIds;
            if (keywordType!= null)
            {
                aipReq.Bodys["keywordType"] = keywordType;
            }
            if (pageSize != 0)
            {
                aipReq.Bodys["pageSize"] = pageSize;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.4.8. 清空特征词词典值
        /// 1）功能描述：清空特征词词典值
        /// 2）接⼝地址： keyword/clearValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordType">特征词类型:user(⽤户词典值); black(⿊名单),不传则全部清空</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KeywordClearValue(long skillId,
                                long keywordId,
                                string keywordType = null,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KEYWORDCLEARVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            if (keywordType != null)
            {
                aipReq.Bodys["keywordType"] = keywordType;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        #endregion
        #region 2.3.5. ⼝语化词
        /// <summary>
        /// 2.3.5.1. 查询⼝语化词列表
        /// 1）功能描述：查询⼝语化词列表
        /// 2）接⼝地址： omit/list
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITLIST);

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
        /// 2.3.5.2. 新建⼝语化词
        /// 1）功能描述：新建⼝语化词列表
        /// 2）接⼝地址： omit/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="omitValue">⼝语化词词典值,单个词典值不能超过6个字符</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitAdd(long skillId, string omitValue, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["omitValue"] = omitValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.5.3. 修改⼝语化词
        /// 1）功能描述：修改⼝语化词
        /// 2）接⼝地址： omit/update
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="omitId">⼝语化词id</param>
        /// <param name="omitValue">⼝语化词词典值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitUpdate(long skillId, int omitId, string omitValue, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["omitId"] = omitId;
            aipReq.Bodys["omitValue"] = omitValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.5.4. 删除⼝语化词
        /// 1）功能描述：删除⼝语化词
        /// 2）接⼝地址： omit/batchDelete
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="omitIds">⼝语化词id列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitBatchDelete(long skillId, List<int> omitIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["omitIds"] = omitIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.5.5. 清空⼝语化词
        /// 1）功能描述：清空⼝语化词
        /// 2）接⼝地址： omit/clear
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitClear(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITCLEAR);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.5.6. 重置⼝语化词
        /// 1）功能描述：重置⼝语化词，恢复⾄初始状态
        /// 2）接⼝地址： omit/reset
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject OmitReset(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(OMITRESET);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.3.6. 对话样本
        /// <summary>
        /// 2.3.6.1. 查询对话样本集列表
        /// 1）功能描述：查询对话样本集列表
        /// 2）接⼝地址： querySet/list
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETLIST);

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
        /// 2.3.6.2. 新建对话样本集
        /// 1）功能描述：新增对话样本集
        /// 2）接⼝地址： querySet/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetName">样本包名称，⻓度范围1~30</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetAdd(long skillId, string querySetName, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetName"] = querySetName;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.3. 修改对话样本集
        /// 1）功能描述：修改对话样本集命名
        /// 2）接⼝地址： querySet/update
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="querySetId"></param>
        /// <param name="querySetName"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetUpdate(long skillId, long querySetId, string querySetName, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["querySetName"] = querySetName;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.4. 合并对话样本集
        /// 1）功能描述：合并对话样本集
        /// 2）接⼝地址： querySet/merge
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetIds">待合并样本集id</param>
        /// <param name="querySetName">样本集名称，⻓度范围1~30</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetMerge(long skillId, List<long> querySetIds, string querySetName, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETMERGE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetIds"] = querySetIds;
            aipReq.Bodys["querySetName"] = querySetName;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.5. 删除对话样本集
        /// 1）功能描述：删除对话样本集
        /// 2）接⼝地址： querySet/delete
        /// </summary>
        /// <param name="botId">技能 id</param>
        /// <param name="querySetId">样本包id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QuerySetDelete(long skillId, long querySetId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYSETDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        /// <summary>
        /// 2.3.6.6. 查询对话样本列表
        /// 1）功能描述：获取样本列表
        /// 2）接⼝地址： query/list
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetId">样本包id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="status">查询的列表类型： -1/待确认 0/未标注的 1/已标注的 2/全部的</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryList(long skillId, long querySetId, int pageNo, int pageSize, int status, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYLIST);

            aipReq.Bodys["skillId"] = skillId;
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
        /// 2.3.6.7. 新建对话样本
        /// 1）功能描述：新建对话样本
        /// 2）接⼝地址： query/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetId">样本包id</param>
        /// <param name="query">样本信息</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryAdd(long skillId, long querySetId, JObject query, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["query"] = JsonConvert.SerializeObject(query, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.8. 查询对话样本详情
        /// 1）功能描述：样本详情查看
        /// 2）接⼝地址： query/info
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetId">样本包id</param>
        /// <param name="queryId">样本id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryInfo(long skillId, long querySetId, long queryId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["queryId"] = queryId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.9. 修改对话样本详情
        /// 1）功能描述：修改对话样本详情
        /// 2）接⼝地址： query/update
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetId">样本包id</param>
        /// <param name="query">样本信息</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryUpdate(long skillId, long querySetId, JObject query, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["query"] = JsonConvert.SerializeObject(query, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.10 确认对话样本(批量）
        /// 1）功能描述：确认对话样本(批量）
        /// 2）接⼝地址： query/quickAnnotate
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="querySetId"></param>
        /// <param name="queryIds"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryQuickAnnotate(long skillId, long querySetId, List<long> queryIds = null, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYQUICKANNOTATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            if (queryIds!=null)
            {
                aipReq.Bodys["queryIds"] = queryIds;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.6.11 删除对话样本(批量）
        /// 1）功能描述：删除对话样本(批量）
        /// 2）接⼝地址： query/batchDelete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="querySetId">样本集id</param>
        /// <param name="queryIds">样本id列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject QueryBatchDelete(long skillId, long querySetId, List<long> queryIds, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(QUERYBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["querySetId"] = querySetId;
            aipReq.Bodys["queryIds"] = queryIds;    
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.3.7. 模型
        /// <summary>
        /// 2.3.7.1. 查询模型列表
        /// 1）功能描述：查询有效模型列表
        /// 2）接⼝地址： model/list
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELLIST);

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
        /// 2.3.7.2. 训练模型
        /// 1）功能描述：训练新模型
        /// 2）接⼝地址： model/train
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelDesc">模型描述, ⻓度范围0~50</param>
        /// <param name="trainOption">
        /// 开发者训练参数， json结构，包含两部分信息
        //  1. 训练数据的选择，包含模板包和样本包
        //  2. 训练⽅式的选择，开发者可选⽅式有三种：快速训练
        //  (smartqu); 深度训练(mlqu); 快速⽣效taskflow配置
        //    (taskflow)
        //  选择，填写true；否则，填写false
        //  具体样例如下
        /// </param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelTrain(long skillId, string trainOption, string modelDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELTRAIN);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelDesc"] = modelDesc;
            aipReq.Bodys["trainOption"] = trainOption;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.7.3. ⽣效到沙盒
        /// 1）功能描述：将模型⽣效到沙盒
        /// 2）接⼝地址： model/effect
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelId">模型id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelEffect(long skillId, long modelId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELEFFECT);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelId"] = modelId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.7.4. 删除有效模型
        /// 1）功能描述：删除有效模型
        /// 2）接⼝地址： model/delete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelId">模型id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ModelDelete(long skillId, long modelId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(MODELDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelId"] = modelId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.3.8. 设置
        /// <summary>
        /// 2.3.8.1 查询⾼级设置
        /// 1）功能描述：查询技能⾼级设置
        /// 2）接⼝地址： setting/info
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SettingInfo(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SETTINGINFO);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.8.2. 修改⾼级设置
        /// 1）功能描述：修改技能⾼级设置
        /// 2）接⼝地址： setting/update
        /// 3）请求⽅式： Method: post; Content-Type: multipart/form-data;
        /// 4）⽂件上传URL前缀为https://aip.baidubce.com/file/2.0/unit/v3
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="skillSetting">⾼级设置具体内容</param>
        /// <param name="taskflowFile">当skillSetting中dialogueManagerType为taskflow时有效;问答技能设置不⽣效;</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SettingUpdate(long skillId, JObject skillSetting, string taskflowFile = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SETTINGUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["botSetting"] = JsonConvert.SerializeObject(skillSetting, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["taskflowFile"] = taskflowFile;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion
        #region 2.3.9. 分享码
        /// <summary>
        /// 2.3.9.1. 查询分享码状态
        /// 1) 功能描述：查看技能分享状态，⾸次调⽤时会⽣成分享码
        /// 2) 接⼝地址： shareCode/status
        /// </summary>
        /// <param name="originalSkillId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ShareCodeStatus(long originalSkillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SHARECODESTATUS);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.9.2. 启⽤分享码
        /// 1) 功能描述：开始分享，设置分享码有效时⻓
        /// 2) 接⼝地址： shareCode/start
        /// </summary>
        /// <param name="originalSkillId">原始技能ID</param>
        /// <param name="shareCode">分享码</param>
        /// <param name="days">分享码有效期时⻓, ⽬前可传⼊3、 7、 15、 30</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ShareCodeStart(long originalSkillId, string shareCode, string days, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SHARECODESTART);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            aipReq.Bodys["shareCode"] = shareCode;
            aipReq.Bodys["days"] = days;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.9.3. 终⽌分享码
        /// 1) 功能描述：停⽌分享，分享码失效
        /// 2) 接⼝地址： shareCode/stop
        /// </summary>
        /// <param name="originalSkillId">原始技能ID</param>
        /// <param name="shareCode">分享码</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject ShareCodeStop(long originalSkillId, string shareCode, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SHARECODESTOP);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            aipReq.Bodys["shareCode"] = shareCode;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.3.9.4. 使⽤分享码复制技能
        /// 1) 功能描述：进⾏技能复制
        /// 2) 接⼝地址： skill/copy
        /// </summary>
        /// <param name="shareCode">分享码</param>
        /// <param name="skillName">技能名称，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject SkillCopy(string shareCode, string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(SKILLCOPY);

            aipReq.Bodys["shareCode"] = shareCode;
            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #endregion
        #region 2.4 问答技能
        #region 2.4.1. 问答对
        /// <summary>
        /// 2.4.1.1. 查询问答对列表
        /// 1）功能描述：查询问答对列表
        /// 2）接⼝地址： faqskill/faqPair/list
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="sluTagIds">标签ID列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairList(long skillId,
                                            int pageNo,
                                            int pageSize,
                                            List<long> sluTagIds = null,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            if (sluTagIds != null)
            {
                aipReq.Bodys["sluTagIds"] = sluTagIds;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.2. 新建问答对
        /// 1）功能描述：新建问答对
        /// 2）接⼝地址： faqskill/faqPair/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="faqQuestions">问题列表</param>
        /// <param name="faqAnswers">回答列表</param>
        /// <param name="faqStdQuestion">标准问题</param>
        /// <param name="faqPatterns">问题模板</param>
        /// <param name="sluTagIds">标签ID列表， 1~10个。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairAdd(long skillId,
                                            List<JObject> faqQuestions,
                                            List<JObject> faqAnswers,
                                            string faqStdQuestion = "",
                                            List<string> faqPatterns = null,
                                            List<long> sluTagIds = null,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["faqQuestions"] = JsonConvert.SerializeObject(faqQuestions, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["faqAnswers"] = JsonConvert.SerializeObject(faqAnswers, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["faqStdQuestion"] = faqStdQuestion;
            aipReq.Bodys["faqPatterns"] = JsonConvert.SerializeObject(faqPatterns, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["sluTagIds"] = JsonConvert.SerializeObject(sluTagIds, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.3. 查询问答对详情
        /// 1）功能描述：查询问答对详情
        /// 2）接⼝地址： faqskill/faqPair/info
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="faqId">问答对id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairInfo(long skillId,
                                            long faqId,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRINFO);
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["faqId"] = faqId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.4. 修改问答对详情
        /// 1）功能描述：修改问答对详情
        /// 2）接⼝地址： faqskill/faqPair/update
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="faqId"></param>
        /// <param name="faqQuestions"></param>
        /// <param name="faqAnswers"></param>
        /// <param name="faqStdQuestion"></param>
        /// <param name="faqPatterns"></param>
        /// <param name="sluTagIds"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairUpdate(long skillId,
                                            long faqId,
                                            List<JObject> faqQuestions,
                                            List<JObject> faqAnswers,
                                            string faqStdQuestion = "",
                                            List<string> faqPatterns = null,
                                            List<long> sluTagIds = null,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["faqId"] = faqId;
            aipReq.Bodys["faqQuestions"] = JsonConvert.SerializeObject(faqQuestions, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["faqAnswers"] = JsonConvert.SerializeObject(faqAnswers, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["faqStdQuestion"] = faqStdQuestion;
            aipReq.Bodys["faqPatterns"] = JsonConvert.SerializeObject(faqPatterns, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["sluTagIds"] = JsonConvert.SerializeObject(sluTagIds, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.5. 修改问答对标签(批量)
        /// 1）功能描述：批量修改问答对标签
        /// 2）接⼝地址： faqskill/faqPair/updateTags
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="faqIds">问答对id列表</param>
        /// <param name="sluTags">标签列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairUpdateTags(long skillId,
                                            List<long> faqIds,
                                            List<JObject> sluTags,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRUPDATETAGS);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["faqIds"] = JsonConvert.SerializeObject(faqIds, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["sluTags"] = JsonConvert.SerializeObject(sluTags, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.6. 删除问答对(批量)
        /// 1）功能描述：删除问答对(批量)
        /// 2）接⼝地址： faqskill/faqPair/batchDelete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="faqIds">问答对id列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairBatchDelete(long skillId,
                                            List<long> faqIds,
                                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["faqIds"] = faqIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.1.7. 查找问答对
        /// 1）功能描述：查找问答对
        /// 2）接⼝地址： faqskill/faqPair/search
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="searchKey">搜素问题关键词</param>
        /// <param name="sluTagIds">筛选标签ID列表， ["notag"]代表筛选⽆标签问题</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillFAQPairSearch(long skillId,
                                    int pageNo,
                                    int pageSize,
                                    string searchKey = null,
                                    List<long> sluTagIds = null,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLFAQPAIRSEARCH);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            if (searchKey != null)
            {
                aipReq.Bodys["searchKey"] = searchKey;
            }
            if (sluTagIds != null)
            {
                aipReq.Bodys["sluTagIds"] = sluTagIds;
            }
            PreAction();
            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.4.2. 特征词
        /// <summary>
        /// 2.4.2.1. 查询特征词列表
        /// 1）功能描述：查询特征词列表
        /// 2）接⼝地址： faqskill/keyword/list
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKEYWORDLIST(long skillId,
                                    int pageNo,
                                    int pageSize,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDLIST);

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
        /// 2.4.2.2. 新建特征词
        /// 1）功能描述：新建特征词
        /// 2）接⼝地址： faqskill/keyword/add
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordName">特征词名称，⻓度范围1~20, 以kw_开头</param>
        /// <param name="keywordValues">特征词词典值</param>
        /// <param name="keywordDesc">特征词描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKEYWORDAdd(long skillId,
                                    string keywordName,
                                    List<string> keywordValues,
                                    string keywordDesc = null,
                                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordName"] = keywordName;
            aipReq.Bodys["keywordValues"] = keywordValues;
            if (keywordDesc != null)
            {
                aipReq.Bodys["keywordDesc"] = keywordDesc;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.3. 删除特征词
        /// 1）功能描述：删除特征词(批量)
        /// 2）接⼝地址： faqskill/keyword/batchDelete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="keywordIds">特征词id列表</param>
        /// <param name="pageSize">每⻚⼤⼩，⽤于前端返回删除后当前⻚码</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKEYWORDBatchDelete(long skillId,
                            List<long> keywordIds,
                            int pageSize = 0,
                            Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordIds"] = keywordIds;
            if (pageSize != 0)
            {
                aipReq.Bodys["pageSize"] = pageSize;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.4. 查询特征词词典值列表
        /// 1）功能描述：查看特征词词典值列表
        /// 2）接⼝地址： faqskill/keyword/value
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">keyword id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~5000</param>
        /// <param name="keywordType">特征词词典值类型:user(⽤户词典值); black(⿊名单);默认为空，两者均返回</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKeywordValue(long skillId,
                    long keywordId,
                    int pageNo,
                    int pageSize,
                    string keywordType = null,
                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            if (keywordType != null)
            {
                aipReq.Bodys["keywordType"] = keywordType;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.5. 新建特征词词典值
        /// 1）功能描述：新建特征词词典值
        /// 2）接⼝地址： faqskill/keyword/addValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">keyword id</param>
        /// <param name="keywordType">特征词类型:user(⽤户词典值); black(⿊名单)</param>
        /// <param name="keywordValue">特征词词典值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKeywordAddValue(long skillId,
                    long keywordId,
                    string keywordType,
                    string keywordValue,
                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDADDVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordType"] = keywordType;
            aipReq.Bodys["keywordValue"] = keywordValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.6. 修改特征词词典值
        /// 1）功能描述：修改特征词词典值
        /// 2）接⼝地址： faqskill/keyword/updateValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">keyword id</param>
        /// <param name="keywordValueId">特征词词典值 id</param>
        /// <param name="keywordValue">特征词词典值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKeywordUpdateValue(long skillId,
                    long keywordId,
                    long keywordValueId,
                    string keywordValue,
                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDUPDATEVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordValueId"] = keywordValueId;
            aipReq.Bodys["keywordValue"] = keywordValue;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.7. 删除特征词词典值
        /// 1）功能描述：删除特征词词典值
        /// 2）接⼝地址： faqskill/keyword/deleteValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordValueIds">特征词词典值id列表</param>
        /// <param name="keywordType">特征词词典值类型，⽤于前端返回删除后当前⻚码</param>
        /// <param name="pageSize">每⻚⼤⼩，⽤于前端返回删除后当前⻚码</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKeywordDeleteValue(long skillId,
                    long keywordId,
                    List<long> keywordValueIds,
                    string keywordType = null,
                    int pageSize = 0,
                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDDELETEVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordValueIds"] = keywordValueIds;
            if (keywordType != null)
            {
                aipReq.Bodys["keywordType"] = keywordType;
            }
            if (pageSize != 0)
            {
                aipReq.Bodys["pageSize"] = pageSize;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.2.8. 清空特征词词典值
        /// 1）功能描述：清空特征词词典值
        /// 2）接⼝地址： faqskill/keyword/clearValue
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="keywordId">特征词 id</param>
        /// <param name="keywordType">特征词类型:user(⽤户词典值); black(⿊名单),不传则全部清空</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillKeywordClearValue(long skillId,
                    long keywordId,
                    string keywordType = "",
                    Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLKEYWORDCLEARVALUE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["keywordId"] = keywordId;
            aipReq.Bodys["keywordType"] = keywordType;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.4.3. 问答技能-标签
        /// <summary>
        /// 2.4.3.1. 查询标签列表
        /// 1）功能描述：查询标签列表
        /// 2）接⼝地址： tag/list
        /// </summary>
        /// <param name="skillId">技能ID</param>
        /// <param name="pageNo">⻚码⼤于等于1</param>
        /// <param name="pageSize">每⻚记录数</param>
        /// <param name="faqIds">问答对ID列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagList(long skillId,
                                int pageNo,
                                int pageSize,
                                List<long> faqIds = null,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            if (faqIds != null)
            {
                aipReq.Bodys["faqIds"] = faqIds;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.3.2. 新建标签
        /// 1）功能描述：新建标签
        /// 2）接⼝地址： tag/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="tagName">标签名称。⻓度1~8。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagAdd(long skillId,
                                string tagName,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["tagName"] = tagName;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.3.3. 修改标签
        /// 1）功能描述：修改标签
        /// 2）接⼝地址： tag/update
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="tagId">标签 id</param>
        /// <param name="tagName">标签名称。⻓度1~8。</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagUpdate(long skillId,
                                long tagId,
                                string tagName,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["tagId"] = tagId;
            aipReq.Bodys["tagName"] = tagName;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.3.4. 更新标签顺序
        /// 1）功能描述：更新标签顺序
        /// 2）接⼝地址： tag/sort
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="tagIds">标签ID顺序列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagSort(long skillId,
                                List<long> tagIds,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGSORT);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["tagIds"] = tagIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.3.5. 删除标签(批量)
        /// 1）功能描述：删除标签(批量)
        /// 2）接⼝地址： tag/batchDelete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="tagIds">标签ID列表</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagBatchDelete(long skillId,
                        List<long> tagIds,
                        Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGBATCHDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["tagIds"] = tagIds;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.3.6. 标签查找
        /// 1）功能描述：标签查找
        /// 2）接⼝地址： tag/search
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="pageNo"></param>
        /// <param name="pageSize"></param>
        /// <param name="searchKey"></param>
        /// <param name="faqIds"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject TagSearch(long skillId,
                                int pageNo,
                                int pageSize,
                                string searchKey = null,
                                List<long> faqIds = null,
                                Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(TAGSEARCH);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            if (searchKey != null)
            {
                aipReq.Bodys["searchKey"] = searchKey;
            }
            if (faqIds != null)
            {
                aipReq.Bodys["faqIds"] = faqIds;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion
        #region 2.4.4. 模型
        /// <summary>
        /// 2.4.4.1. 查询模型列表
        /// 1）功能描述：查询模型列表
        /// 2）接⼝地址： 接⼝地址： faqskill/model/list
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillModelList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLMODELLIST);

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
        /// 2.4.4.2. 训练模型
        /// 1）功能描述：训练新模型
        /// 2）接⼝地址： faqskill/model/train
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelDesc">模型描述, ⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillModelTrain(long skillId, string modelDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLMODELTRAIN);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelDesc"] = modelDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.4.3. ⽣效到沙盒
        /// 1）功能描述：将模型⽣效到沙盒
        /// 2）接⼝地址： faqskill/model/effect
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelId">模型id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillModelEffect(long skillId, long modelId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLMODELEFFECT);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelId"] = modelId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.4.4. 删除有效模型
        /// 1）功能描述：删除有效模型
        /// 2）接⼝地址： faqskill/model/delete
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="modelId">模型id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillModelDelete(long skillId, long modelId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLMODELDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["modelId"] = modelId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.4.5. 设置
        /// <summary>
        /// 2.4.5.1 查询⾼级设置
        /// 1）功能描述：查询技能⾼级设置
        /// 2）接⼝地址： faqskill/setting/info
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillSettingInfo(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSETTINGINFO);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.5.2. 修改⾼级设置
        /// 1）功能描述：修改技能⾼级设置
        /// 2）接⼝地址： faqskill/setting/update
        /// 3）请求⽅式： Method: post; Content-Type: multipart/form-data;
        /// 4）⽂件上传URL前缀为https://aip.baidubce.com/file/2.0/unit/v3
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="skillSetting">⾼级设置具体内容</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillSettingUpdate(long skillId, JObject skillSetting, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSETTINGUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["botSetting"] = JsonConvert.SerializeObject(skillSetting, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.4.6. 分享码
        /// <summary>
        /// 2.4.6.1. 查询分享码状态
        /// 1) 功能描述：查看技能分享状态，⽆可⽤分享码调⽤时会⽣成新的分享码
        /// 2) 接⼝地址： faqskill/shareCode/status
        /// </summary>
        /// <param name="originalSkillId">原始技能ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillShareCodeStatus(long originalSkillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSHARECODESTATUS);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.6.2. 启⽤分享码
        /// 1) 功能描述：开始分享，设置分享码有效时⻓
        /// 2) 接⼝地址： faqskill/shareCode/start
        /// </summary>
        /// <param name="originalSkillId">原始技能ID</param>
        /// <param name="shareCode">分享码</param>
        /// <param name="days">分享码有效期时⻓, ⽬前可传⼊3、 7、 15、 30</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillShareCodeStart(long originalSkillId, string shareCode, string days, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSHARECODESTART);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            aipReq.Bodys["shareCode"] = shareCode;
            aipReq.Bodys["days"] = days;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.6.3. 终⽌分享码
        /// 1) 功能描述：停⽌分享，分享码失效，该分享码不可再进⾏技能复制
        /// 2) 接⼝地址： faqskill/shareCode/stop
        /// </summary>
        /// <param name="originalSkillId">原始技能ID</param>
        /// <param name="shareCode">分享码</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillShareCodeStop(long originalSkillId, string shareCode, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSHARECODESTOP);

            aipReq.Bodys["originalSkillId"] = originalSkillId;
            aipReq.Bodys["shareCode"] = shareCode;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.4.6.4. 使⽤分享码复制技能
        /// 1) 功能描述：进⾏技能复制
        /// 2) 接⼝地址： faqskill/skill/copy
        /// </summary>
        /// <param name="shareCode">分享码</param>
        /// <param name="skillName">技能名称，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject FAQSkillSkillCopy(string shareCode, string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(FAQSKILLSKILLCOPY);

            aipReq.Bodys["shareCode"] = shareCode;
            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #endregion
        #region 2.5 对话式⽂档问答技能
        #region 2.5.1. 技能
        /// <summary>
        /// 2.5.1.1. 查询技能列表
        /// 1）功能描述：对话式⽂档问答技能列表
        /// 2）接⼝地址： ddqa/skill/list
        /// </summary>
        /// <param name="skillCategory">技能类别，⽬前仅⽀持 innovation</param>
        /// <param name="pageNo">⻚码⼤于等于1,默认为1</param>
        /// <param name="pageSize">每⻚记录数，默认为50</param>
        /// <param name="options"></param>
        /// <param name=""></param>
        /// <returns></returns>
        public JObject DDQASkillList(string skillCategory = "innovation", int pageNo = 1, int pageSize = 50, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDAQSKILLLIST);

            aipReq.Bodys["skillCategory"] = skillCategory;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.5.1.2. 新建技能
        /// 1）功能描述：创建对话式⽂档问答技能
        /// 2）接⼝地址： ddqa/skill/add
        /// </summary>
        /// <param name="skillName">技能名称，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDAQSkillAdd(string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDAQSKILLADD);

            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.5.1.3. 修改技能属性
        /// 1）功能描述：修改对话式⽂档问答技能
        /// 2）接⼝地址： ddqa/skill/update
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="skillName">技能名称，⽀持中⽂、英⽂、数字、下划线， 1~30个字符</param>
        /// <param name="skillDesc">技能描述， 0~50个字符</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDAQSkillUpdate(long skillId, string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDAQSKILLUPDATE);

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
        /// 2.5.1.4. 删除技能
        /// 1）功能描述：删除技能
        /// 2）接⼝地址： ddqa/skill/delete
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDAQSkillDelete(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDAQSKILLDELETE);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.5.2. ⽂档
        /// <summary>
        /// 2.5.2.1. 查询⽂档列表
        /// 1）接⼝描述 ：查询⽂档列表
        /// 2）接⼝地址： ddqa/file/list
        /// </summary>
        /// <param name="skillId">技能ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDQAFileList(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDQAFILELIST);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.5.2.2. 上传⽂档
        /// 1）接⼝描述 ：上传⽂件到技能下⾯
        /// 2）接⼝地址： ddqa/file/upload
        /// 3）请求⽅式： Method: post; Content-Type: multipart/form-data;
        /// 4）⽂件上传URL前缀为https://aip.baidubce.com/file/2.0/unit/v3
        /// </summary>
        /// <param name="file">⽂件信息，单次上传⽂件⼤⼩限制为10M, 仅⽀持纯⽂本格式的⽂档上传</param>
        /// <param name="skillId">技能ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDQAFileUpload(string file, int skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDQAFILEUPLOAD);

            aipReq.Bodys["file"] = file;
            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.5.2.3. 删除⽂档
        /// 1）功能描述：删除⽂档
        /// 2）接⼝地址： ddqa/file/delete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="fileId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDQAFileDelete(long skillId, long fileId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDQAFILEDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["fileId"] = fileId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #region 2.5.3. 模型
        /// <summary>
        /// 2.5.3.1. 训练模型
        /// 1）接⼝描述：触发模型训练
        /// 2）接⼝地址： ddqa/model/train
        /// </summary>
        /// <param name="skillId">skillId</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDQAModelTrain(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDQAMODELTRAIN);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }


        #endregion
        #region 2.5.4. 设置
        /// <summary>
        /// 2.5.4.1. 对话式⽂档问答阈值设置
        /// 1）接⼝描述：对话式⽂档问答阈值设置
        /// 2）接⼝地址： ddqa/setting/update
        /// </summary>
        /// <param name="skillId">技能id</param>
        /// <param name="recallThreshold">召回阈值, 取值范围0~100</param>
        /// <param name="top1Threshold">top1阈值，取值范围0~100且recallThreshold <=top1Threshold</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DDQASettingUpdate(long skillId, int recallThreshold, int top1Threshold, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DDQASETTINGUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["recallThreshold"] = recallThreshold;
            aipReq.Bodys["top1Threshold"] = top1Threshold;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
        #endregion
        #region 2.6. 结构化知识问答技能
        #region 2.6.1. 技能
        /// <summary>
        /// 2.6.1.1. 查询技能列表
        /// 1）功能描述：查询结构化知识问答技能列表
        /// 2）接⼝地址： kbqa/skill/list
        /// </summary>
        /// <param name="pageNo">⻚码，从 1 开始</param>
        /// <param name="pageSize">每⻚数量，取值范围 1~200</param>
        /// <param name="skillCategory">技能类别： user(开发者⾃定义) 、 system(系统)；当前仅⽀持开发者⾃定义</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASkillList(int pageNo, int pageSize, string skillCategory = "user", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASKILLLIST);

            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            aipReq.Bodys["skillCategory"] = skillCategory;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.1.2. 新建技能
        /// 1）功能描述： 新建结构化知识问答技能
        /// 2）接⼝地址： kbqa/skill/add
        /// </summary>
        /// <param name="skillName">技能名称，⽀持中⽂、英⽂、数字、下划线，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围 0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASkillAdd(string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASKILLADD);

            aipReq.Bodys["skillName"] = skillName;
            aipReq.Bodys["skillDesc"] = skillDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.1.3. 修改技能属性
        /// 1）功能描述：修改结构化知识问答技能
        /// 2）接⼝地址： kbqa/skill/update
        /// </summary>
        /// <param name="skillId">技能ID</param>
        /// <param name="skillName">技能名称，⽀持中⽂、英⽂、数字、下划线，⻓度范围1~30</param>
        /// <param name="skillDesc">技能描述，⻓度范围 0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASkillUpdate(long skillId, string skillName, string skillDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASKILLUPDATE);

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
        /// 2.6.1.4. 删除技能
        /// 1）功能描述：删除结构化知识问答技能
        /// 2）接⼝地址： kbqa/skill/delete
        /// </summary>
        /// <param name="skillId">技能ID</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASkillDelete(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASKILLDELETE);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion 2.6.1. 技能

        #region 2.6.2. Schema
        /// <summary>
        /// 2.6.2.1. 查询 schema 列表
        /// 1）功能描述：查询技能的 schema 列表
        /// 2）接⼝地址： kbqa/schema/list
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1～200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASchemaList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASCHEMALIST);

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
        /// 2.6.2.2. 查询 schema 信息
        /// 1）功能描述：查询某个schema 信息
        /// 2）接⼝地址： kbqa/schema/info
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASchemaInfo(long skillId, long schemaId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASCHEMAINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.2.3. 新建 schema
        /// 1）功能描述：新建 schema
        /// 2）接⼝地址： kbqa/schema/add
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaData">schema数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASchemaAdd(long skillId, JObject schemaData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASCHEMAADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaData"] = JsonConvert.SerializeObject(schemaData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.2.4. 更新 schema
        /// 1）功能描述：更新 schema
        /// 2）接⼝地址： kbqa/schema/update
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="schemaData">schema数据</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASchemaUpdate(long skillId, long schemaId, JObject schemaData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASCHEMAUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["schemaData"] = JsonConvert.SerializeObject(schemaData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.2.5. 删除 schema
        /// 1）功能描述：删除 schema
        /// 2）接⼝地址： kbqa/schema/delete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQASchemaDelete(long skillId, long schemaId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQASCHEMADELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion 2.6.2. Schema

        #region 2.6.3. Record数据
        /// <summary>
        /// 2.6.3.1. 查询 record 列表
        /// 1）功能描述：查询 schema 下record数据列表
        /// 2）接⼝地址： kbqa/record/list
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1～200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordList(long skillId, long schemaId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.3.2. 查询 record 信息
        /// 1）功能描述：查询单条 record信息
        /// 2）接⼝地址： kbqa/record/info
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="recordId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordInfo(long skillId, long schemaId, long recordId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["recordId"] = recordId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.3.3. 添加 record 数据
        /// 1）功能描述：添加 record 数据，⽀持批量
        /// 2）接⼝地址： kbqa/record/add
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="recordData">record 数据列表，每条数据包含schema中定义的所有属性及属性值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordAdd(long skillId, long schemaId, JArray recordData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDADD);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["recordData"] = JsonConvert.SerializeObject(recordData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); ;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.3.4. 修改 record 数据
        /// 1）功能描述：修改 record 数据
        /// 2）接⼝地址： kbqa/record/update
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="recordId">record id</param>
        /// <param name="recordData">单条record数据，包含schema中定义的所有属性及属性值</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordUpdate(long skillId, long schemaId, long recordId, JArray recordData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDUPDATE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["recordId"] = recordId;
            aipReq.Bodys["recordData"] = JsonConvert.SerializeObject(recordData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }); ;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.3.5. 删除 record 数据
        /// 1）功能描述：删除 record 数据
        /// 2）接⼝地址： kbqa/record/delete
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="recordId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordDelete(long skillId, long schemaId, long recordId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDDELETE);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["recordId"] = recordId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.3.6. 清除 record 数据
        /// 1）功能描述：删除所有 record 数据
        /// 2）接⼝地址： kbqa/record/clear
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQARecordClear(long skillId, long schemaId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQARECORDCLEAR);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion 2.6.3. Record数据

        #region 2.6.4. Synoym同义词对
        /// <summary>
        /// 2.6.4.1. 查询同义词对列表
        /// 1）功能描述：查询 schema 下同义词对列表
        /// 2）接⼝地址： kbqa/optimization/synonymList
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1～200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationSynonymList(long skillId, long schemaId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONSYNONYMLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.4.2. 查询同义词对信息
        /// 1）功能描述：查询同义词对信息
        /// 2）接⼝地址： kbqa/optimization/synonymInfo
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="synonymId">同义词对id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationSynonymInfo(long skillId, long schemaId, long synonymId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONSYNONYMINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["synonymId"] = synonymId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.4.3. 添加同义词对
        /// 1）功能描述：添加同义词对
        /// 2）接⼝地址： kbqa/optimization/addSynonym
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="synonymData">schema id</param>
        /// <param name="synonymCategory">同义词对类型： user， system</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationAddSynonym(long skillId, long schemaId, JArray synonymData, string synonymCategory = "user", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONADDSYNONYM);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["synonymData"] = JsonConvert.SerializeObject(synonymData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["synonymCategory"] = synonymCategory;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.4.4. 修改同义词对
        /// 1）功能描述：修改同义词对信息
        /// 2）接⼝地址： kbqa/optimization/updateSynonym
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="synonymId"></param>
        /// <param name="synonymData"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationUpdateSynonym(long skillId, long schemaId, long synonymId, JArray synonymData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONUPDATESYNONYM);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["synonymId"] = synonymId;
            aipReq.Bodys["synonymData"] = JsonConvert.SerializeObject(synonymData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.4.5. 删除同义词对
        /// 1）功能描述：删除同义词对信息
        /// 2）接⼝地址： kbqa/optimization/deleteSynonym
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="synonymId">同义词对id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationDeleteSynonym(long skillId, long schemaId, long synonymId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONDELETESYNONYM);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["synonymId"] = synonymId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.4.6. 清除同义词对
        /// 1）功能描述：清除schema下所有同义词对信息
        /// 2）接⼝地址： kbqa/optimization/clearSynonym
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationClearSynonym(long skillId, long schemaId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONCLEARSYNONYM);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion

        #region 2.6.5. Reply回复话术
        /// <summary>
        /// 2.6.5.1. 查询回复话术列表
        /// 1）功能描述：查询 schema 下属性回复话术列表
        /// 2）接⼝地址： kbqa/optimization/replyList
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="pageNo">⻚码，从1开始</param>
        /// <param name="pageSize">每⻚数量，取值范围1～200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationReplyList(long skillId, long schemaId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONREPLYLIST);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["pageNo"] = pageNo;
            aipReq.Bodys["pageSize"] = pageSize;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.5.2. 查询回复话术信息
        /// 1）功能描述：查询回复话术信息
        /// 2）接⼝地址： kbqa/optimization/replyInfo
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="replyId">reply id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationReplyInfo(long skillId, long schemaId, long replyId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONREPLYINFO);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["replyId"] = replyId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.5.3. 添加回复话术配置
        /// 1）功能描述：添加回复话术配置
        /// 2）接⼝地址： kbqa/optimization/addReply
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="replyData">回复话术配置</param>
        /// <param name="replyCategory">回复话术配置类型： user， system，默认为user</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationAddReply(long skillId, long schemaId, JArray replyData, string replyCategory = "user", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONADDREPLY);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["replyData"] = JsonConvert.SerializeObject(replyData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["replyCategory"] = replyCategory;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.5.4. 修改回复话术配置
        /// 1）功能描述：修改回复话术配置
        /// 2）接⼝地址： kbqa/optimization/updateReply
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="replyId">reply id</param>
        /// <param name="replyData">回复话术配置</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationUpdateReply(long skillId, long schemaId, long replyId, JArray replyData, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONUPDATEREPLY);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["replyId"] = replyId;
            aipReq.Bodys["replyData"] = JsonConvert.SerializeObject(replyData, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.5.5. 删除回复话术配置
        /// 1）功能描述：删除回复话术配置
        /// 2）接⼝地址： kbqa/optimization/deleteReply
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="schemaId">schema id</param>
        /// <param name="replyId">reply id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationDeleteReply(long skillId, long schemaId, long replyId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONDELETEREPLY);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            aipReq.Bodys["replyId"] = replyId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.6.5.6. 清除回复话术配置
        /// 1）功能描述：清除schema下所有回复话术配置
        /// 2）接⼝地址： kbqa/optimization/clearReply
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="schemaId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAOptimizationClearReply(long skillId, long schemaId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAOPTIMIZATIONDCLEARREPLY);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["schemaId"] = schemaId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        #endregion

        #region 2.6.6. 模型

        /// <summary>
        /// 2.6.6.1. 查询模型列表
        /// 1）功能描述：查询模型列表
        /// 2）接⼝地址： kbqa/model/list
        /// </summary>
        /// <param name="skillId"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAModelList(long skillId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAMODELLIST);

            aipReq.Bodys["skillId"] = skillId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        /// <summary>
        /// 2.6.6.2. 训练模型
        /// 1）功能描述：训练新模型
        /// 2）接⼝地址： kbqa/model/train
        /// </summary>
        /// <param name="skillId">skill id</param>
        /// <param name="trainOption">
        /// 开发者训练参数， json 结构，包含两部分信息：训练数据的选择，包含schema列表训练⽅式的选择，开发者可选⽅式⽬前只有⼀种： 快速训练(kbqa)。具体样例为：
        /// {
        /// "configure" ： {
        /// "kbqa" ： "true"
        /// },
        /// "data" ： {
        /// "schemaIds" ： [ 7 ]
        ///     }
        /// }
        /// </param>
        /// <param name="modelDesc">模型描述, ⻓度范围 0~50</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject KBQAModelTrain(long skillId, JObject trainOption, string modelDesc = "", Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(KBQAMODELTRAIN);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["trainOption"] = JsonConvert.SerializeObject(trainOption, Formatting.Indented,new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
            aipReq.Bodys["modelDesc"] = modelDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion

        #endregion 2.6. 结构化知识问答技能
        #region 2.7. ⽣产环境部署（含模型发布）

        /// <summary>
        /// 2.7.1. 新增⽣产环境部署
        /// 1）功能描述：新增⽣产环境部署
        /// 2）接⼝地址： deployment/add
        /// </summary>
        /// <param name="skillId">技能 id</param>
        /// <param name="region">部署地域： bj（华北）、 su（华东）、 gz（华南） 只可填写⼀个部署地域</param>
        /// <param name="modelVersion">模型版本，如果不填写，默认部署当前沙盒⽣效的模型版本</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentAdd(long skillId, string region, string modelVersion = null, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTADD);
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["region"] = region;
            if (modelVersion != null)
            {
                aipReq.Bodys["modelVersion"] = modelVersion;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.7.2. 更新⽣产环境模型版本
        /// 1）功能描述：更新⽣产环境模型版本
        /// 2）接⼝地址： deployment/updateModelVersion
        /// </summary>
        /// <param name="skillId">技能 Id</param>
        /// <param name="region">部署地域： bj（华北）、 su（华东）、 gz（华南） 只可填写⼀个部署地域</param>
        /// <param name="modelVersion">模型版本，如果不填写，默认部署当前沙盒⽣效的模型版本</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentUpdateModelVersion(long skillId, string region, string modelVersion = null, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTUPDATEMODELVERSION);

            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["region"] = region;
            if (modelVersion != null)
            {
                aipReq.Bodys["modelVersion"] = modelVersion;
            }
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.7.3. 查询部署任务执⾏状态
        /// 1）功能描述：查询部署任务的状态
        /// 2）接⼝地址： deployment/getStatus
        /// </summary>
        /// <param name="skillId">技能 Id</param>
        /// <param name="deploymentId">部署任务 id</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentGetStatus(long skillId, int deploymentId, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTGETSTATUS);
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["deploymentId"] = deploymentId;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }

        /// <summary>
        /// 2.7.4. 查询部署任务记录
        /// 1）功能描述：查询部署任务记录
        /// 2）接⼝地址： deployment/list
        /// </summary>
        /// <param name="skillId">技能 Id</param>
        /// <param name="pageNo">页码，从 1 开始</param>
        /// <param name="pageSize">每页数量，取值范围 1~200</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentList(long skillId, int pageNo, int pageSize, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTLIST);
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
        /// 2.7.5. 删除⽣产环境
        /// 1）功能描述：删除⽣产环境
        /// 2）接⼝地址： deployment/deleteRegion
        /// </summary>
        /// <param name="skillId">技能 Id</param>
        /// <param name="region">部署地域：bj（华北）、 su（华东）、 gz（华南）只可填写一个部署地域</param>
        /// <param name="options"></param>
        /// <returns></returns>
        public JObject DeploymentDeleteRegion(long skillId, string region, Dictionary<string, object> options = null)
        {
            var aipReq = DefaultRequest(DEPLOYMENTDELETEREGION);
            aipReq.Bodys["skillId"] = skillId;
            aipReq.Bodys["region"] = region;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
        #endregion
    }
}