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

namespace AipSdk.Baidu.Aip.Nlp.Unit.TalkAPI
{
    class TalkAPI : AipServiceBase
    {
        private const string BOTCHAT =
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
    }
}
