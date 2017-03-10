using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Starts2000.TaoBao.Views.Utils
{
    static class ConstData
    {
        internal static IList<TaoBaoLevel> TaoBaoLevels = new List<TaoBaoLevel>
        {
            new TaoBaoLevel { Id = 1, Name = "一星" },
            new TaoBaoLevel { Id = 2, Name = "二星" },
            new TaoBaoLevel { Id = 3, Name = "三星" },
            new TaoBaoLevel { Id = 4, Name = "三星" },
            new TaoBaoLevel { Id = 5, Name = "一月亮" },
            new TaoBaoLevel { Id = 6, Name = "二月亮" },
            new TaoBaoLevel { Id = 7, Name = "三月亮" },
            new TaoBaoLevel { Id = 8, Name = "一太阳" },
            new TaoBaoLevel { Id = 9, Name = "二太阳" },
            new TaoBaoLevel { Id = 10, Name = "三太阳" },
        };

        internal static IList<ConsumptionLevel> ConsumptionLevels = new List<ConsumptionLevel>
        {
            new ConsumptionLevel { Id = 1, Name = "一心" },
            new ConsumptionLevel { Id = 2, Name = "二心" },
            new ConsumptionLevel { Id = 3, Name = "三心" },
            new ConsumptionLevel { Id = 4, Name = "四心" },
            new ConsumptionLevel { Id = 5, Name = "五心" },
            new ConsumptionLevel { Id = 6, Name = "一金砖" },
            new ConsumptionLevel { Id = 7, Name = "二金砖" },
            new ConsumptionLevel { Id = 8, Name = "三金砖" },
            new ConsumptionLevel { Id = 9, Name = "四金砖" },
            new ConsumptionLevel { Id = 10, Name = "五金砖" },
            new ConsumptionLevel { Id = 11, Name = "一金冠" },
            new ConsumptionLevel { Id = 12, Name = "二金冠" },
            new ConsumptionLevel { Id = 13, Name = "三金冠" },
            new ConsumptionLevel { Id = 14, Name = "四金冠" },
            new ConsumptionLevel { Id = 15, Name = "五紫冠" },
            new ConsumptionLevel { Id = 16, Name = "一紫冠" },
            new ConsumptionLevel { Id = 17, Name = "二紫冠" },
            new ConsumptionLevel { Id = 18, Name = "三紫冠" },
            new ConsumptionLevel { Id = 19, Name = "四紫冠" },
            new ConsumptionLevel { Id = 20, Name = "五紫冠" }
        };
    }

    class TaoBaoLevel
    {
        public byte Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }

    class ConsumptionLevel
    {
        public byte Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }
    }
}
