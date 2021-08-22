using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FF14_Lodestone_Job_Trust_System
{
    class Trust
    {
        //EXPテーブル
        public int[] exp_Table = { 13881000, 15556000, 17498600, 19750000, 22330000, 25340000, 28650000, 32750000, 37650000 };

        //ID獲得経験値
        public int[] id_exp = { 2498970, 3189013, 3970076, 4823272, 5754816 };
        //ID名
        public string[] id_name = { "殺戮郷村 ホルミンスター",
                                          "水妖幻園 ドォーヌ・メグ",
                                          "古跡探索 キタンナ神影洞",
                                          "爽涼離宮 マリカの大井戸",
                                          "偽造天界 グルグ火山" };
    }
}
