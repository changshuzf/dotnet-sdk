using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AipSdk.Baidu.Aip.Nlp.unit
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
}
