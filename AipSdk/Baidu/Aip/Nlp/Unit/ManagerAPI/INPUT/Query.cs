using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit.ManagerAPI.INPUT
{
    /// <summary>
    /// query结构：
    /// </summary>
    public class QueryAdd_Query
    {
        /// <summary>
        /// query结构：
        /// </summary>
        /// <param name="queryString">样本，⻓度范围1~125</param>
        /// <param name="intentId">意图id</param>
        /// <param name="slots">词槽标注信息</param>
        public QueryAdd_Query(string queryString, long intentId = 0, List<QueryAdd_Slot> slots = null)
        {
            this.queryString = queryString;
            if (intentId != 0)
            {
                this.intentId = intentId;
            }
            else
            {
                this.intentId = null;
            }
            if (slots != null)
            {
                this.slots = slots;
            }
            else
            {
                this.slots = new List<QueryAdd_Slot>();
            }
        }

        /// <summary>
        /// 样本，⻓度范围1~125
        /// </summary>
        public string queryString { get; set; }

        /// <summary>
        /// 意图id
        /// </summary>
        public long? intentId { get; set; }

        /// <summary>
        /// 词槽标注信息
        /// </summary>
        public List<QueryAdd_Slot> slots { get; set; }
    }

    /// <summary>
    /// QueryUpdate_Query
    /// </summary>
    public class QueryUpdate_Query : QueryAdd_Query
    {
        /// <summary>
        /// QueryUpdate_Query 构造函数
        /// </summary>
        /// <param name="queryString">样本</param>
        /// <param name="queryId">样本id</param>
        /// <param name="intentId">意图id</param>
        /// <param name="slots">词槽标注信息</param>
        public QueryUpdate_Query(long queryId, string queryString, long intentId = 0, List<QueryAdd_Slot> slots = null) : base(queryString, intentId, slots)
        {
            this.queryId = queryId;
            this.queryString = queryString;
            if (intentId != 0)
            {
                this.intentId = intentId;
            }
            else
            {
                this.intentId = null;
            }
            if (slots != null)
            {
                this.slots = slots;
            }
            else
            {
                this.slots = new List<QueryAdd_Slot>();
            }
        }

        /// <summary>
        /// 样本id
        /// </summary>
        public long queryId { get; set; }
    }

    public class QueryAdd_Slot
    {
        /// <summary>
        /// slots[]结构：
        /// </summary>
        /// <param name="slotId">词槽id</param>
        /// <param name="word">标注⽂本</param>
        /// <param name="length">标注⽂本⻓度</param>
        /// <param name="offset">⽂本在queryString中的位移，从0开始</param>
        public QueryAdd_Slot(long slotId, string word, int length, int offset)
        {
            this.slotId = slotId;
            this.word = word;
            this.length = length;
            this.offset = offset;
        }

        /// <summary>
        /// 词槽id
        /// </summary>
        public long slotId { get; set; }
        /// <summary>
        /// 标注⽂本
        /// </summary>
        public string word { get; set; }

        /// <summary>
        /// 标注⽂本⻓度
        /// </summary>
        public int length { get; set; }

        /// <summary>
        /// ⽂本在queryString中的位移，从0开始
        /// </summary>
        public int offset { get; set; }
    }
}
