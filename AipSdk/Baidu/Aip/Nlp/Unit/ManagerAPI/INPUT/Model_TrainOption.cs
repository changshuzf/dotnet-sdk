using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Baidu.Aip.Nlp.Unit.ManagerAPI.INPUT
{
    public class Model_TrainOption
    {
        /// <summary>
        /// 默认快速训练，无模板包信息、样本包信息
        /// </summary>
        public Model_TrainOption()
        {
            this.configure = new Model_TrainOption_Configure();
            this.data = new Model_TrainOption_Data();
        }

        /// <summary>
        /// 
        /// </summary>
        public Model_TrainOption_Configure configure { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public Model_TrainOption_Data data { get; set; }
    }

    /// <summary>
    /// 训练⽅式的选择开发者可选⽅式有三种：快速训练(smartqu);深度训练(mlqu); 快速⽣效taskflow配置
    /// </summary>
    public class Model_TrainOption_Configure
    {
        /// <summary>
        /// 默认配置，快速训练smartqu
        /// </summary>
        public Model_TrainOption_Configure()
        {
            this.smartqu = "true";
            this.mlqu = "false";
            this.taskflow = "false";
        }

        /// <summary>
        /// 深度训练mlqu
        /// </summary>
        /// <param name="mlqu"></param>
        public Model_TrainOption_Configure(string mlqu)
        {
            this.smartqu = "false";
            this.mlqu = "true";
            this.taskflow = "false";
        }

        /// <summary>
        /// 快速训练(smartqu)
        /// </summary>
        public string smartqu { get; set; }
        /// <summary>
        /// 深度训练(mlqu)
        /// </summary>
        public string mlqu { get; set; }
        /// <summary>
        /// 快速⽣效taskflow配置(taskflow)
        /// </summary>
        public string taskflow { get; set; }
    }

    /// <summary>
    /// 训练数据的选择，包含模板包和样本包
    /// </summary>
    public class Model_TrainOption_Data
    {
        /// <summary>
        /// 无参数、默认空值
        /// </summary>
        public Model_TrainOption_Data()
        {
            this.querySetIds = new List<int>();
            this.patternSetIds = new List<int>();
        }

        /// <summary>
        /// 训练数据的选择
        /// </summary>
        /// <param name="querySetIds">样本包ID</param>
        /// <param name="patternSetIds">模板包ID</param>
        public Model_TrainOption_Data(List<int> querySetIds, List<int> patternSetIds)
        {
            this.querySetIds = querySetIds;
            this.patternSetIds = patternSetIds;
        }

        /// <summary>
        /// 样本包
        /// </summary>
        public List<int> querySetIds { get; set; }
        /// <summary>
        /// 模板包
        /// </summary>
        public List<int> patternSetIds { get; set; }
    }
}
