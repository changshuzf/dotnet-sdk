using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace AipSdk.Baidu.Aip.Nlp.unit.unitemnu
{
    /// <summary>
    /// 系统自动发现不置信意图/词槽，并据此主动发起澄清确认的敏感程度。取值范围：0(关闭)、1(中敏感度)、2(高敏感度)。取值越高BOT主动发起澄清的频率就越高，建议值为1。
    /// </summary>
    public enum enum_bernard_level
    {
        关闭 = 0,
        中度敏感 = 1,
        高度敏感 = 2
    }

    /// <summary>
    /// ="TEXT"，请求信息类型，当前为固定值TEXT，表示客户端请求的内容类型是一段文本。后续会支持"EVENT"类型，让客户端在BOT里直接触发一个意图或填充一些词槽等操作，比如客户端发现用户打开对话窗口了，可以由BOT主动触发一个请求 给用户问个好、介绍一下自己能解决什么问题。
    /// </summary>
    public enum enum_query_info_type
    {
        TEXT = 1,
        EVENT = 2
    }

    /// <summary>
    /// 请求信息来源，可选值："ASR","KEYBOARD"。ASR为语音输入，KEYBOARD为键盘文本输入，ASR输入的UNIT平台内置了异常信息纠错机制，尝试解决语音输入中的一些常见错误。
    /// </summary>
    public enum enum_query_info_source
    {
        ASR = 1 ,
        KEYBOARD = 2
    }
}
