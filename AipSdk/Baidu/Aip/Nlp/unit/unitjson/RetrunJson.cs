using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit
{
    #region 百度Unit管理API Return对象
    public class BotSettingReturnJson : BotSettingInputJSON
    {
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updateTime { get; set; }
    }
    #endregion

    /// <summary>
    /// BotChat返回JSON
    /// </summary>
    #region BotChat返回JSON
    public class ReturnJsonBotChat
    {
        /// <summary>
        /// 错误码，为0时表示成功
        /// </summary>
        public int error_code { get; set; }
        /// <summary>
        /// 错误信息，errno!= 0 时存在
        /// </summary>
        public string error_msg { get; set; }
        public Result result { get; set; }
        
        /// <summary>
        /// 包括html标签的消息
        /// </summary>
        public string retMsg
        {
            get
            {
                string s = "";
                s = this.result.response.action_list.FirstOrDefault().say + "\n";
                foreach (var item in this.result.response.action_list.FirstOrDefault().refine_detail.option_list)
                {
                    s = s + item.option + "\n";
                }
                return s;
            }
        }
        /// <summary>
        /// retWeiXingMsg删除<br><div></div>标签，和微信里面消息兼容
        /// </summary>
        public  string retWeiXinMsg
        {
            get
            {
                string s = "";
                s = this.result.response.action_list.FirstOrDefault().say + "\n";
                foreach (var item in this.result.response.action_list.FirstOrDefault().refine_detail.option_list)
                {
                    s = s + item.option + "\n";
                }
                s = s.Replace("<br>", "\n");
                s = s.Replace("<div>", "");
                s = s.Replace("</div>", "\n");
                return s;
            }
        }
    }

    public class Result
    {
        /// <summary>
        /// 同输入参数
        /// </summary>
        public string version = "2.0";
        /// <summary>
        /// BOT唯一ID
        /// </summary>
        public string bot_id { get; set; }
        /// <summary>
        /// 日志唯一ID（用户与BOT的一问一答为一次interaction，
        /// 其中用户每说一次对应有一个log_id）
        /// </summary>
        public string log_id { get; set; }
        /// <summary>
        /// session信息
        /// </summary>
        public string bot_session { get; set; }
        /// <summary>
        /// 为本轮请求+应答之组合，生成的id
        /// </summary>
        public string interaction_id { get; set; }
        /// <summary>
        /// 本轮应答体
        /// </summary>
        public Response response { get; set; }
    }

    public class Response
    {
        /// <summary>
        /// 动作列表
        /// </summary>
        public List<Action_List> action_list { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// BOT解析的结果
        /// </summary>
        public Qu_Res qu_res { get; set; }
        /// <summary>
        /// 解析的schema，解析意图、词槽结果都从这里面获取
        /// </summary>
        public Schema schema { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string status { get; set; }
    }

    public class Qu_Res
    {
        /// <summary>
        /// query结果时间戳
        /// </summary>
        public int timestamp { get; set; }
        /// <summary>
        /// query结果状态
        /// </summary>
        public int status { get; set; }
        /// <summary>
        /// 原始query
        /// </summary>
        public string raw_query { get; set; }
        /// <summary>
        /// 意图候选项
        /// </summary>
        public List<Candidate> candidates { get; set; }
        /// <summary>
        /// query的情感分析结果
        /// </summary>
        public Sentiment_Analysis sentiment_analysis { get; set; }
    }

    public class Sentiment_Analysis
    {
        /// <summary>
        /// 情感标签
        /// </summary>
        public string label { get; set; }
        /// <summary>
        /// 置信度
        /// </summary>
        public float pval { get; set; }
    }

    public class Candidate
    {
        /// <summary>
        /// 候选项意图名称
        /// </summary>
        public string intent { get; set; }
        /// <summary>
        /// 候选项意图置信度
        /// </summary>
        public float intent_confidence { get; set; }
        /// <summary>
        /// 候选项domain分类置信度
        /// </summary>
        public float domain_confidence { get; set; }
        /// <summary>
        /// 意图是否需要澄清
        /// </summary>
        public Boolean intent_need_clarify { get; set; }
        /// <summary>
        /// 候选项词槽列表
        /// </summary>
        public List<CandidatesSlot> slots { get; set; }
        /// <summary>
        /// 来自哪个qu策略（smart-qu对应对话模板，ml-qu对应对话样本学习）
        /// </summary>
        public string from_who { get; set; }
        /// <summary>
        /// query匹配信息
        /// </summary>
        public string match_info { get; set; }
        /// <summary>
        /// 候选项附加信息
        /// </summary>
        //public Dictionary<string, string> extra_info { get; set; }
        /// <summary>
        /// 最终qu结果，内部格式同result.response.qu_res.candidates[]
        /// </summary>
        public List<Candidate> qu_res_chosen { get; set; }
        /// <summary>
        /// query的词法分析结果
        /// </summary>
        public List<Lexical_Analysis> lexical_analysis { get; set; }
    }

    public class Lexical_Analysis
    {
        /// <summary>
        /// 词汇(含命名实体)))
        /// </summary>
        public string term { get; set; }
        /// <summary>
        /// 重要性权重
        /// </summary>
        public float weight { get; set; }
        /// <summary>
        /// 词性或专名类别
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 构成词汇的基本词
        /// </summary>
        public List<Basic_Word> basic_word { get; set; }
    }

    public class Basic_Word
    {

    }

    public class CandidatesSlot
    {
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public float confidence { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public int begin { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public string original_word { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public string normalized_word { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public string word_type { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 同shema.slots
        /// </summary>
        public bool need_clarify { get; set; }
        /// <summary>
        /// 父词槽index，非子词槽，取值-1
        /// </summary>
        public int father_idx { get; set; }
    }

    public class Schema
    {
        /// <summary>
        /// 意图信息
        /// </summary>
        public string intent { get; set; }
        /// <summary>
        /// 词置信度
        /// </summary>
        public float intent_confidence { get; set; }
        /// <summary>
        /// domain分类置信度
        /// </summary>
        public float domain_confidence { get; set; }
        /// <summary>
        /// 词槽列表
        /// </summary>
        public List<SchemaSlot> slots { get; set; }
    }

    public class SchemaSlot
    {
        /// <summary>
        /// 词槽置信度
        /// </summary>
        public float confidence { get; set; }
        /// <summary>
        /// 词槽起始
        /// </summary>
        public int begin { get; set; }
        /// <summary>
        /// 词槽长度
        /// </summary>
        public int length { get; set; }
        /// <summary>
        /// 词槽值
        /// </summary>
        public string original_word { get; set; }
        /// <summary>
        /// 归一化词槽值
        /// </summary>
        public string normalized_word { get; set; }
        /// <summary>
        /// 词槽值细化类型
        /// </summary>
        public string word_type { get; set; }
        /// <summary>
        /// 词槽名称
        /// </summary>
        public string name { get; set; }
        /// <summary>
        /// 词槽是在第几轮对话中引入的
        /// </summary>
        public int session_offset { get; set; }
        /// <summary>
        /// 引入的方式
        /// </summary>
        public string merge_method { get; set; }
        /// <summary>
        /// 子词槽list，内部结构同正常词槽。
        /// </summary>
        public List<string> sub_slots { get; set; }
    }

    public class Action_List
    {
        /// <summary>
        /// 动作置信度
        /// </summary>
        public float confidence { get; set; }
        /// <summary>
        /// 动作ID
        /// </summary>
        public string action_id { get; set; }
        /// <summary>
        /// 应答话术
        /// </summary>
        public string say { get; set; }
        /// <summary>
        /// 用户自定义应答，如果action_type为event，对应事件定义在此处
        /// </summary>
        public string custom_reply { get; set; }
        /// <summary>
        /// 类型，具体有以下几种:clarify/satisfy/guide/faqguide/understood(理解达成)/failure(理解失败)/chat(聊天话术)/event(触发事件，
        /// 在"对话意图--场景bot回应--答复"选择了"执行函数"将返回event类型)
        /// </summary>
        public action_list_type type { get; set; }
        /// <summary>
        /// 『泛澄清』时，即clarify/guide/faqguide时有效
        /// </summary>
        public Refine_Detail refine_detail { get; set; }
    }

    public class Refine_Detail
    {
        /// <summary>
        /// 具体有以下几种：select/ask/selectandask
        /// </summary>
        public string interact { get; set; }
        /// <summary>
        /// 『泛澄清』选项列表。这里的『选项』是广义的选项，
        /// 在意图、词槽不置信or缺失澄清，以及faqguide时，
        /// 也会有一个长度为1的option_list，存放相应细节信息。
        /// </summary>
        public List<Option_List> option_list { get; set; }
        /// <summary>
        /// clarify时有值，表明起因
        /// </summary>
        public string clarify_reason { get; set; }
    }

    public class Option_List
    {
        /// <summary>
        /// 选项文字       
        /// </summary>
        public string option { get; set; }
        /// <summary>
        /// 选项细节信息
        /// </summary>
        public Info info { get; set; }
    }

    public class Info
    {
    }
    #endregion
}
