using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit.ManagerAPI.INPUT
{
    /// <summary>
    /// sluTags[]结构：
    /// </summary>
    public class SluTag
    {
        /// <summary>
        /// sluTags[]结构：
        /// </summary>
        /// <param name="tagId">标签 id</param>
        /// <param name="tagSelect">批量更新标签状态： 0 - 所有传⼊问答对剔除该标签； 1 - 所有问答对添加该标签</param>
        public SluTag(long tagId, int tagSelect)
        {
            this.tagId = tagId;
            this.tagSelect = tagSelect;
        }

        /// <summary>
        /// 标签 id
        /// </summary>
        public long tagId { get; set; }

        /// <summary>
        /// 批量更新标签状态： 0 - 所有传⼊问答对剔除该标签； 1 - 所有问答对添加该标签
        /// </summary>
        public int tagSelect { get; set; }
    }
}
