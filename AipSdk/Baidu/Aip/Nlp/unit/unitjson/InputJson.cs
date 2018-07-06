using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Baidu.Aip.Nlp.Unit;

namespace Baidu.Aip.Nlp.Unit
{
    /// <summary>
    /// bot 高级设置 botSetting 结构
    /// </summary>
    public class BotSetting
    {
        /// <summary>
        /// 切换意图时是否自动重置 session取值范围： 0(不重置)、 1(重置)
        /// </summary>
        public int intentSession { get; set; }
        /// <summary>
        /// 固定对话次数清空 session 是否重取值范围：0(不重置)、 1(重置)
        /// </summary>
        public int dialogueSession { get; set; }
        /// <summary>
        /// dialogueSession 为 1 时有效，固定对话次数清空 session 的轮数，范围 1~99
        /// </summary>
        public int dialogueCount { get; set; }
        /// <summary>
        /// 问答答案阈值取值范围：
        /// 75(高)、 50(中)、 25(低)、 0(无)说明：
        /// 当用户问题与系统答案的匹配度高于阈值，
        /// 系统返回匹配度最高的唯一答案，
        /// 反之，系统会提供近似问题对用户供选择
        /// </summary>
        public string faqGuideAskFreq { get; set; }
        /// <summary>
        /// 识别异常话术
        /// </summary>
        public string failAction { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        public string createTime { get; set; }
        /// <summary>
        /// 更新时间
        /// </summary>
        public string updateTime { get; set; }
    }

    public class Request
    {
        public Request(string user_id, string query, string client_session = @"{ ""client_results"":"""", ""candidate_options"":[]}", enum_bernard_level bernard_level = enum_bernard_level.中度敏感, Query_Info query_info = null, string updates = "")
        {
            //Request req = new Request();
            //req.user_id = user_id;
            //req.query = query;

            /////QueryInfo
            //Query_Info qi = new Query_Info();
            //qi.source = "KEYBOARD";
            //qi.type = "TEXT";

            /////List Asr_Candidate
            //List<Asr_Candidate> list = new List<Asr_Candidate>();
            //qi.asr_candidates = list;

            //req.query_info = qi;

            ////client session
            //req.client_session = @"{ ""client_results"":"""", ""candidate_options"":[]}";
            ////bernard_level
            //req.bernard_level = 0;

            this.user_id = user_id;
            this.query = query;
            if (query_info == null)
            {
                Query_Info qi = new Query_Info();
                this.query_info = qi;
            }
            this.client_session = client_session;
            this.updates = updates;
            this.bernard_level = (int)enum_bernard_level.中度敏感;


        }

        /// <summary>
        /// 与BOT对话的用户id（如果BOT客户端是用户未登录状态情况下对话的，
        /// 也需要尽量通过其他标识（比如设备id）来唯一区分用户），
        /// 方便今后在平台的日志分析模块定位分析问题、从用户维度统计分析相关对话情况。
        /// </summary>
        public string user_id { get; set; }
        /// <summary>
        /// 本轮请求query（用户说的话），详情见【参数详细说明】
        /// </summary>
        public string query { get; set; }
        /// <summary>
        /// 本轮请求query的附加信息。
        /// </summary>
        public Query_Info query_info { get; set; }
        /// <summary>
        /// client希望传给BOT的本地信息，以一组K-V形式保存，
        /// 如不需要此字段，需填充一个默认值：
        /// {"client_results":"", "candidate_options":[]}。
        ///如果需要此字段，其定义详见【参数详细说明】
        /// </summary>
        public string client_session { get; set; }
        /// <summary>
        /// 干预信息。详情见【参数详细说明】
        /// </summary>
        public string updates { get; set; }
        /// <summary>
        /// 系统自动发现不置信意图/词槽，
        /// 并据此主动发起澄清确认的敏感程度。
        /// 取值范围：0(关闭)、1(中敏感度)、2(高敏感度)。
        /// 取值越高BOT主动发起澄清的频率就越高，建议值为1。
        /// </summary>
        public int bernard_level { get; set; }
    }

    public class Query_Info
    {
        public Query_Info(List<Asr_Candidate> asr_candidates = null , enum_query_info_type type = enum_query_info_type.TEXT,enum_query_info_source source = enum_query_info_source.KEYBOARD)
        {
            this.type = type.ToString();
            this.source = source.ToString();
            if (asr_candidates == null)
            {
                List<Asr_Candidate> list = new List<Asr_Candidate>();
                this.asr_candidates = list;
            }
        }

        /// <summary>
        /// ="TEXT"，请求信息类型，当前为固定值TEXT，
        /// 表示客户端请求的内容类型是一段文本。
        /// 后续会支持"EVENT"类型，让客户端在BOT里直接触发一个意图或填充一些词槽等操作，
        /// 比如客户端发现用户打开对话窗口了，
        /// 可以由BOT主动触发一个请求 给用户问个好、介绍一下自己能解决什么问题。
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 请求信息来源，可选值："ASR","KEYBOARD"。
        /// ASR为语音输入，KEYBOARD为键盘文本输入，
        /// ASR输入的UNIT平台内置了异常信息纠错机制，
        /// 尝试解决语音输入中的一些常见错误。
        /// </summary>
        public string source { get; set; }
        /// <summary>
        /// 请求信息来源若为ASR，该字段为ASR候选信息。
        /// （如果调用百度语音的API会有词信息，
        /// BOT可能会参考该候选信息做综合判断处理。）
        /// </summary>
        public List<Asr_Candidate> asr_candidates { get; set; }
    }

    public class Updates
    {
        /// <summary>
        /// 干预方式，可选值：
        /// DEFINE：抛弃系统解析结果，转而由updates字段来定义)；
        /// MODIFY：修改系统解析结果
        /// </summary>
        public string type { get; set; }
        /// <summary>
        /// 具体操作集
        /// </summary>
        public List<OpItem> ops { get; set; }
    }

    public class Asr_Candidate
    {
        /// <summary>
        /// 语音输入候选文本
        /// </summary>
        public string text { get; set; }
        /// <summary>
        /// 语音输入候选置信度
        /// </summary>
        public float confidence { get; set; }
    }

    public class OpItem
    {
        /// <summary>
        /// 操作方式，可选值：
        /// DEFINE：定义一个对象（当且仅当type为DEFINE时取此值，type为DEFINE时op只可以取此值）
        /// REMOVE： 删除一个对象
        /// ADD：增添一个对象（隐含操作：删除与之冲突的其他对象）
        /// </summary>
        public string op { get; set; }
        /// <summary>
        /// 操作针对的对象，可选值为意图、词槽：INTENT SLOT
        /// </summary>
        public string target { get; set; }
        /// <summary>
        /// target对象的值
        /// </summary>
        public Value value { get; set; }
    }

    public class Value
    {
    }  
}
