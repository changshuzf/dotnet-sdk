using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit.ManagerAPI.INPUT
{
    public class SkillSetting
    {
        /// <summary>
        /// skillSetting结构：
        /// </summary>
        /// <param name="faqGuideTopFreq">
        /// top1阈值 取值范围： 0~40，技能初始化时为30 说明：开发者query与问答库中最相似问题的相似度>=top1阈值时，只
        /// 返回相似度最⾼的问题和对应答案。否则将按相似度从⾼到底返回多个相似问题让开发者进⼀步选择
        /// </param>
        /// <param name="faqGuideLowFreq">
        /// 召回阈值 取值范围： 0~40，且⼩于等于top1阈值，技能初始化时为20 说明：问答库中的问题与开发者query的相似度
        /// ⼤于等于召回阈值时，对应的问题和答案会被返回
        /// </param>
        /// <param name="topFaqGuideNo">
        /// 最多返回相似问题数 取值范围： 1~20，技能初始化时为3 说明： query与问答集中问题的相似度在【top1阈值】和【召
        /// 回阈值】之间时最多可返回的相似问题数
        /// </param>
        public SkillSetting(int faqGuideTopFreq = 0, int faqGuideLowFreq = 0, int topFaqGuideNo = 0)
        {
            this.faqGuideTopFreq = faqGuideTopFreq;
            this.faqGuideLowFreq = faqGuideLowFreq;
            this.topFaqGuideNo = topFaqGuideNo;
        }
        /// <summary>
        /// top1阈值 取值范围： 0~40，技能初始化时为30 说明：开发者query与问答库中最相似问题的相似度>=top1阈值时，只
        /// 返回相似度最⾼的问题和对应答案。否则将按相似度从⾼到底返回多个相似问题让开发者进⼀步选择
        /// </summary>
        public int faqGuideTopFreq { get; set; }

        /// <summary>
        /// 召回阈值 取值范围： 0~40，且⼩于等于top1阈值，技能初始化时为20 说明：问答库中的问题与开发者query的相似度
        /// ⼤于等于召回阈值时，对应的问题和答案会被返回
        /// </summary>
        public int faqGuideLowFreq { get; set; }

        /// <summary>
        /// 最多返回相似问题数 取值范围： 1~20，技能初始化时为3 说明： query与问答集中问题的相似度在【top1阈值】和【召
        /// 回阈值】之间时最多可返回的相似问题数
        /// </summary>
        public int topFaqGuideNo { get; set; }
    }
}
