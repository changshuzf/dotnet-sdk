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
            var aipReq = DefaultRequest(BOTLIST);

            aipReq.Bodys["botName"] = botName;
            aipReq.Bodys["botDesc"] = botDesc;
            PreAction();

            if (options != null)
                foreach (var pair in options)
                    aipReq.Bodys[pair.Key] = pair.Value;
            return PostAction(aipReq);
        }
    }
}