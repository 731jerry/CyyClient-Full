using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyyClient
{
    /*
     胆码
    定位胆码
    分序组选
    偶数个数
    小数个数
    质数个数
    号码形态
    平衡指数
    龙头凤尾
    A/B分解

    合值
    两码合差
    跨度
    前后轨迹
    反边球距离
    最大临码跨距
    边临和
    012路
    和值
    两码差和

    两码合
    两码差
     */

    #region 基础号码 与 非基础号码
    public struct BaseNumsStruct
    {
        public int[] line1 { get; set; }
        public int[] line2 { get; set; }
        public int[] line3 { get; set; }
    }
    public struct NotBaseNumsStruct
    {
        public int[] line1 { get; set; }
        public int[] line2 { get; set; }
        public int[] line3 { get; set; }
    }
    #endregion

    #region 胆码 结构
    public struct DanmaStruct
    {
        public bool IsSelect;
        public int[] _danma { get; set; }
        public int[] AppearCounts { get; set; }
        public int[] NotAppearCounts { get; set; }
    }
    #endregion

    #region 定位胆码
    public struct LocateIndexNum11_3
    {
        public int[] index1;
        public int[] index2;
        public int[] index3;

        public int[] AppearCounts;
    }
    #endregion

    #region 分序组选
    public struct LocateIndexNumFenxu11_3
    {
        public int[] index1;
        public int[] index2;
        public int[] index3;

        public int[] AppearCounts;
    }
    #endregion

    #region 号码形态

    public struct HaomaxingtaiStruct
    {
        public bool isAo;
        public bool isTu;
        public bool isSheng;
        public bool isJiang;
    }
    #endregion

    #region 平衡指数

    public struct PinghengzhishuStruct
    {
        public bool isJia;
        public bool isDeng;
        public bool isJian;
    }
    #endregion

    #region 偶小质 综合属性
    public struct ZongheshuxingStruct
    {
        public bool IsSelect;

        public int[] OddCounts { get; set; }
        public int[] SmallCounts { get; set; }
        public int[] ZhiCounts { get; set; }
        public int[] AppearCounts { get; set; }
    }
    #endregion

    #region 龙头凤尾
    public struct LongtouFengwei11_3
    {
        public bool LongtouDan { get; set; }
        public bool LongtouShuang { get; set; }
        public bool LongtouZhi { get; set; }
        public bool LongtouHe { get; set; }
        public bool LongtouDa { get; set; }
        public bool LongtouXiao { get; set; }

        public bool FengweiDan { get; set; }
        public bool FengweiShuang { get; set; }
        public bool FengweiZhi { get; set; }
        public bool FengweiHe { get; set; }
        public bool FengweiDa { get; set; }
        public bool FengweiXiao { get; set; }

        public int[] AppearCounts { get; set; }
    }
    #endregion

    #region 012路
    public struct FZBQ012Lu
    {
        public int[] fanbianqiujuli { get; set; }
        public int[] zuidalinmakuaju { get; set; }
        public int[] bianlinhe { get; set; }
        public int[] qianhouguiji { get; set; }

        public int[] AppearCounts { get; set; }
    }
    #endregion

    #region A/B分解
    public struct ABfenjie
    {
        public int[] Afengjie { get; set; }
        public int[] Bfenjie { get; set; }

        public bool isEnabled { get; set; }
    }
    #endregion

    #region 大小形态
    public struct Daxiaoxingtai
    {
        public bool isQuanda;
        public bool isQuanxiao;
        public bool isDadaxiao;
        public bool isXiaoxiaoda;
        public bool isXiaodada;
        public bool isDaxiaoxiao;
        public bool isDaxiaoda;
        public bool isXiaodaxiao;
        public int[] AppearCounts;
    }
    #endregion

    #region 单双形态
    public struct Danshuangxingtai
    {
        public bool isQuandan;
        public bool isQuanshuang;
        public bool isDandanshuang;
        public bool isShuangshuangdan;
        public bool isShuangdandan;
        public bool isDanshuangshuang;
        public bool isDanshuangdan;
        public bool isShuangdanshuang;
        public int[] AppearCounts;
    }
    #endregion

    #region 质和形态
    public struct Zhihexingtai
    {
        public bool isQuanzhi;
        public bool isQuanhe;
        public bool isZhizhihe;
        public bool isHehezhi;
        public bool isHezhizhi;
        public bool isZhihehe;
        public bool isZhihezhi;
        public bool isHezhihe;
        public int[] AppearCounts;
    }
    #endregion

    #region 两码合差
    public struct LiangmahechaStruct
    {
        public int[] _Liangmahecha1;
        public int[] _Liangmahecha2;
        public int[] _Liangmahecha3;
        public int[] _Liangmahecha4;
        public int[] _Liangmahecha5;

        public int[] AppearCounts;
    }
    #endregion

    #region 任意两码合 一
    public struct RenyiliangmaheYiStruct
    {
        public int[] renyiliangmaheYi;
        public int[] AppearNums;
    }
    #endregion

    #region 任意两码合 二
    public struct RenyiliangmaheErStruct
    {
        public int[] renyiliangmaheEr1;
        public int[] renyiliangmaheEr2;
        public int[] AppearNums;
    }
    #endregion

    #region 两码合分序组选
    public struct Liangmahefenxuzuxuan
    {
        public int[] liangmahefenxuzuxuan1;
        public int[] liangmahefenxuzuxuan2;
        public int[] liangmahefenxuzuxuan3;
        public int[] AppearNums;
    }
    #endregion

    #region 定位两码合
    public struct Dingweiliangmahe
    {
        public int[] dingweiliangmahe1;
        public int[] dingweiliangmahe2;
        public int[] dingweiliangmahe3;
        public int[] AppearNums;
    }
    #endregion

    #region 任意两码差一
    public struct RenyiliangmachaYiStruct
    {
        public int[] renyiliangmachaYi;
        public int[] AppearNums;
    }
    #endregion

    #region 任意两码合 二
    public struct RenyiliangmachaErStruct
    {
        public int[] renyiliangmachaEr1;
        public int[] renyiliangmachaEr2;
        public int[] AppearNums;
    }
    #endregion

    #region 两码差分序组选
    public struct Liangmachafenxuzuxuan
    {
        public int[] liangmachafenxuzuxuan1;
        public int[] liangmachafenxuzuxuan2;
        public int[] liangmachafenxuzuxuan3;
        public int[] AppearNums;
    }
    #endregion

    #region 定位两码差
    public struct Dingweiliangmacha
    {
        public int[] dingweiliangmacha1;
        public int[] dingweiliangmacha2;
        public int[] dingweiliangmacha3;
        public int[] AppearNums;
    }
    #endregion

    #region 彩票类
    public class Lottery11_3
    {
        #region 偶 小 质 综合属性
        public int EvenCount { get; private set; } // 偶
        public int OddCount { get; private set; } // 奇
        public int SmallCount { get; private set; } // 小
        public int SumCount { get; private set; } // 和
        public int ZhiCount { get; private set; } // 质
        public int LinkedCount { get; private set; } // 连号
        #endregion

        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 5)
                {
                    return lottery11_3[index];
                }
                return -1;
            }
        }

        private int[] lottery11_3;
        private int[] NotLottery11_3;

        public int[] GetArray()
        {
            return lottery11_3;
        }


        public int[] PreSort;

        public Lottery11_3(string strlen10)
        {
            int i = int.Parse(strlen10.Substring(0, 2));
            int ii = int.Parse(strlen10.Substring(2, 2));
            int iii = int.Parse(strlen10.Substring(4, 2));


            int[] arr = new int[3] { i, ii, iii };

            PreSort = (int[])arr.Clone();

            Array.Sort<int>(arr);


            lottery11_3 = new int[] { arr[0], arr[1], arr[2] };
            SetNotLottery11_3(arr[0], arr[1], arr[2]);

            Set_11_3_Zongheshuxing(); //综合属性
        }

        public Lottery11_3(int i, int ii, int iii)
        {
            lottery11_3 = new int[] { i, ii, iii };
            //SetNotLottery11_3(i, ii, iii);
            Set_11_3_Zongheshuxing(); //综合属性
        }

        private void SetNotLottery11_3(int i, int ii, int iii)
        {
            int[] tmp = new int[8];
            int length = 0;

            for (int x = 1; x <= 11; x++)
            {
                if (x != i && x != ii && x != iii)
                {
                    tmp[length] = x;
                    length++;
                }
            }
            NotLottery11_3 = tmp;
        }

        public int GetSumOfLottery11_3()
        {
            return lottery11_3[0] + lottery11_3[1] + lottery11_3[2];
        }

        private int SameNumberCount(List<int> l1, List<int> l2)
        {
            int sameCount = 0;
            for (int i = 0; i < l1.Count; i++)
            {
                for (int ii = 0; ii < l2.Count; ii++)
                {
                    if (l1[i] == l2[ii])
                    {
                        sameCount++;
                    }
                }
            }
            return sameCount;
        }

        private int SameNumberCountOriginal(List<int> l1, List<int> l2)
        {
            int sameCount = 0;
            for (int i = 0; i < l1.Count; i++)
            {
                for (int ii = 0; ii < l2.Count; ii++)
                {
                    if (l1[i] == l2[ii])
                    {
                        sameCount++;
                    }
                }
            }
            return sameCount;
        }

        public int GetSmallBitOfSum11_3()
        {
            int sum = GetSumOfLottery11_3();

            string sumStr = sum.ToString();
            sumStr = sumStr.Substring(sumStr.Length - 1, 1);

            return int.Parse(sumStr);
        }
        public int SameNumberCount(int[] other)
        {
            int sameCount = 0;
            for (int i = 0; i < lottery11_3.Length; i++)
            {
                for (int ii = 0; ii < other.Length; ii++)
                {
                    if (lottery11_3[i] == other[ii])
                    {
                        sameCount++;
                    }
                }
            }
            return sameCount;
        }

        public int GetMaxNearestNumDis()
        {
            int l1 = lottery11_3[1] - lottery11_3[0];
            int l2 = lottery11_3[2] - lottery11_3[1];

            int[] ll = new int[] { l1, l2 };

            Array.Sort<int>(ll);
            return ll[1];
        }

        public int GetZuidalinmajianju()
        {
            int l1 = (11 - lottery11_3[0]) + (lottery11_3[1] - 1);
            int l2 = (11 - lottery11_3[1]) + (lottery11_3[2] - 1);

            int[] ll = new int[] { l1, l2 };

            Array.Sort<int>(ll);
            return ll[1];
        }
        private void Set_11_3_Zongheshuxing()
        {
            for (int i = 0; i < lottery11_3.Length; i++)
            {
                #region 设置综合属性
                if (lottery11_3[i] % 2 == 0)
                {
                    EvenCount++;
                }
                else
                {
                    OddCount++;
                }

                if (lottery11_3[i] <= 5)
                {
                    SmallCount++;
                }

                if (lottery11_3[i] == 4 || lottery11_3[i] == 6 || lottery11_3[i] == 8 || lottery11_3[i] == 9 || lottery11_3[i] == 10)
                {
                    SumCount++;
                }

                if (lottery11_3[i] == 1 || lottery11_3[i] == 2 || lottery11_3[i] == 3 || lottery11_3[i] == 5 || lottery11_3[i] == 7 || lottery11_3[i] == 11)
                {
                    ZhiCount++;
                }
                /*
                if (i < 4)
                {
                    if ((lottery11_3[i + 1] - lottery11_3[i]) == 1)
                    {
                        LinkedCount++;
                    }
                }
                 */
                #endregion
            }
        }

        #region 胆码
        public bool MeetBileCode(List<DanmaStruct> bileCodes)
        {
            foreach (DanmaStruct bc in bileCodes)
            {
                if (bc._danma.Length == 0 || bc.AppearCounts.Length == 0)
                    continue;

                int counts = SameNumberCount(bc._danma);

                int notIndex = Array.IndexOf<int>(bc.NotAppearCounts, counts);

                if (notIndex != -1)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 定位胆码
        public bool MeetLocateIndexNum(LocateIndexNum11_3 lin)
        {
            if (lin.AppearCounts.Length == 0) return true;

            int l1 = ((Array.IndexOf<int>(lin.index1, lottery11_3[0]) != -1) && lin.index1.Length != 0) ? 1 : 0;
            int l2 = ((Array.IndexOf<int>(lin.index2, lottery11_3[1]) != -1) && lin.index2.Length != 0) ? 1 : 0;
            int l3 = ((Array.IndexOf<int>(lin.index3, lottery11_3[2]) != -1) && lin.index3.Length != 0) ? 1 : 0;

            if (Array.IndexOf<int>(lin.AppearCounts, l1 + l2 + l3) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 分序组选
        public bool MeetLocateIndexNumFenxu(LocateIndexNumFenxu11_3 lin)
        {
            if (lin.AppearCounts.Length == 0) return true;
            int l1 = 0, l2 = 0, l3 = 0;

            if ((lottery11_3[0] < lottery11_3[1]) && (lottery11_3[1] < lottery11_3[2]))
            {
                l1 = ((Array.IndexOf<int>(lin.index1, lottery11_3[0]) != -1) && lin.index1.Length != 0) ? 1 : 0;
                l2 = ((Array.IndexOf<int>(lin.index2, lottery11_3[1]) != -1) && lin.index2.Length != 0) ? 1 : 0;
                l3 = ((Array.IndexOf<int>(lin.index3, lottery11_3[2]) != -1) && lin.index3.Length != 0) ? 1 : 0;
            }

            if (Array.IndexOf<int>(lin.AppearCounts, l1 + l2 + l3) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 号码形态
        public bool MeetHaomaxingtaiStruct(HaomaxingtaiStruct lin)
        {
            if (lin.isAo == false && lin.isTu == false && lin.isSheng == false && lin.isJiang == false) return true;

            if (lin.isAo)
            {
                if (!((lottery11_3[1] > lottery11_3[0]) || (lottery11_3[1] > lottery11_3[2])))
                {
                    return true;
                }
            }
            if (lin.isTu)
            {
                if (!((lottery11_3[1] < lottery11_3[0]) || (lottery11_3[1] < lottery11_3[2])))
                {
                    return true;
                }
            }
            if (lin.isSheng)
            {
                if (!((lottery11_3[1] < lottery11_3[0]) || (lottery11_3[2] < lottery11_3[1])))
                {
                    return true;
                }
            }
            if (lin.isJiang)
            {
                if (!((lottery11_3[0] < lottery11_3[1]) || (lottery11_3[1] < lottery11_3[2])))
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region 平衡指数
        public bool MeetPinghengzhishuStruct(PinghengzhishuStruct lin)
        {
            if (lin.isJia == false && lin.isDeng == false && lin.isJian == false) return true;

            if (lin.isJia)
            {
                if ((Math.Abs(lottery11_3[0] - lottery11_3[1]) - 1) > (Math.Abs(lottery11_3[1] - lottery11_3[2]) - 1))
                {
                    return true;
                }
            }
            if (lin.isDeng)
            {
                if ((Math.Abs(lottery11_3[0] - lottery11_3[1]) - 1) == (Math.Abs(lottery11_3[1] - lottery11_3[2]) - 1))
                {
                    return true;
                }
            }
            if (lin.isJian)
            {
                if ((Math.Abs(lottery11_3[0] - lottery11_3[1]) - 1) < (Math.Abs(lottery11_3[1] - lottery11_3[2]) - 1))
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 偶 小 质 综合属性
        public bool MeetZongheshuxingStruct(ZongheshuxingStruct syAttr)
        {
            const int Nexist = -1;

            // 偶数
            int evenIndex;
            if (syAttr.OddCounts.Length == 0)
            {
                evenIndex = Nexist;
            }
            else
            {
                evenIndex = Array.IndexOf<int>(syAttr.OddCounts, EvenCount);
            }

            // 小数
            int smallIndex;
            if (syAttr.SmallCounts.Length == 0)
            { smallIndex = Nexist; }
            else
            {
                smallIndex = Array.IndexOf<int>(syAttr.SmallCounts, SmallCount);
            }

            // 质数
            int zhiIndex;

            if (syAttr.ZhiCounts.Length == 0) { zhiIndex = Nexist; }
            else
            {
                zhiIndex = Array.IndexOf<int>(syAttr.ZhiCounts, ZhiCount);
            }

            int indexSum = (evenIndex == Nexist ? 0 : 1)
                + (smallIndex == Nexist ? 0 : 1)
                + (zhiIndex == Nexist ? 0 : 1);

            int[] acs = syAttr.AppearCounts;

            if (acs.Length == 0) { return true; }

            foreach (int i in acs)
            {
                if (i == indexSum)
                {
                    return true;
                }
            }
            return false;
        }
        #endregion

        #region 龙头凤尾
        public bool MeetLongtouFengweiStruct(LongtouFengwei11_3 syAttr)
        {
            if (syAttr.AppearCounts.Length == 0) return true;

            int ltDaxiao = 0;
            int ltDanshuang = 0;
            int ltZhihe = 0;

            int fwDaxiao = 0;
            int fwDanshuang = 0;
            int fwZhihe = 0;

            // 龙头
            if (syAttr.LongtouDan && (lottery11_3[0] == 1 || lottery11_3[0] == 3 || lottery11_3[0] == 5 || lottery11_3[0] == 7 || lottery11_3[0] == 9 || lottery11_3[0] == 11))
            {
                ltDanshuang++;
            }
            if (syAttr.LongtouShuang && (lottery11_3[0] == 2 || lottery11_3[0] == 4 || lottery11_3[0] == 6 || lottery11_3[0] == 8 || lottery11_3[0] == 10))
            {
                ltDanshuang++;
            }
            if (syAttr.LongtouZhi && (lottery11_3[0] == 1 || lottery11_3[0] == 2 || lottery11_3[0] == 3 || lottery11_3[0] == 5 || lottery11_3[0] == 7 || lottery11_3[0] == 11))
            {
                ltZhihe++;
            }
            if (syAttr.LongtouHe && (lottery11_3[0] == 4 || lottery11_3[0] == 6 || lottery11_3[0] == 8 || lottery11_3[0] == 9 || lottery11_3[0] == 10))
            {
                ltZhihe++;
            }
            if (syAttr.LongtouDa && (lottery11_3[0] >= 6))
            {
                ltDaxiao++;
            }
            if (syAttr.LongtouXiao && (lottery11_3[0] < 6))
            {
                ltDaxiao++;
            }

            // 凤尾
            if (syAttr.FengweiDan && (lottery11_3[2] == 1 || lottery11_3[2] == 3 || lottery11_3[2] == 5 || lottery11_3[2] == 7 || lottery11_3[2] == 9 || lottery11_3[2] == 11))
            {
                fwDanshuang++;
            }
            if (syAttr.FengweiShuang && (lottery11_3[2] == 2 || lottery11_3[2] == 4 || lottery11_3[2] == 6 || lottery11_3[2] == 8 || lottery11_3[2] == 10))
            {
                fwDanshuang++;
            }
            if (syAttr.FengweiZhi && (lottery11_3[2] == 1 || lottery11_3[2] == 2 || lottery11_3[2] == 3 || lottery11_3[2] == 5 || lottery11_3[2] == 7 || lottery11_3[2] == 11))
            {
                fwZhihe++;
            }
            if (syAttr.FengweiHe && (lottery11_3[2] == 4 || lottery11_3[2] == 6 || lottery11_3[2] == 8 || lottery11_3[2] == 9 || lottery11_3[2] == 10))
            {
                fwZhihe++;
            }
            if (syAttr.FengweiDa && (lottery11_3[2] >= 6))
            {
                fwDaxiao++;
            }
            if (syAttr.FengweiXiao && (lottery11_3[2] < 6))
            {
                fwDaxiao++;
            }

            int counts = ltDaxiao + ltDanshuang + ltZhihe + fwDaxiao + fwDanshuang + fwZhihe;
            /*
            if(!(Array.IndexOf<int>(syAttr.AppearCounts, (counts == 0) ? 0 : -1) != -1)) {
                return true;
            }
             */

            if ((Array.IndexOf<int>(syAttr.AppearCounts, counts) != -1)
             || (Array.IndexOf<int>(syAttr.AppearCounts, (counts == 5) ? 5 : -1) != -1)
             || (Array.IndexOf<int>(syAttr.AppearCounts, (counts == 4) ? 4 : -1) != -1)
             || (Array.IndexOf<int>(syAttr.AppearCounts, (counts == 3) ? 3 : -1) != -1)
             || (Array.IndexOf<int>(syAttr.AppearCounts, (counts == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(syAttr.AppearCounts, (counts == 1) ? 1 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 012路
        public bool MeetFZBQ012LuStruct(FZBQ012Lu _bzbq)
        {
            if (_bzbq.AppearCounts.Length == 0) return true;

            int fbqCount = 0;
            int zdlmkjCount = 0;
            int blhCount = 0;
            int qhgjCount = 0;

            if ((_bzbq.fanbianqiujuli.Length > 0) && (Array.IndexOf<int>(_bzbq.fanbianqiujuli, GetSmallerBiggerLength() % 3) != -1))
            {
                fbqCount++;
            }
            if ((_bzbq.zuidalinmakuaju.Length > 0) && (Array.IndexOf<int>(_bzbq.zuidalinmakuaju, GetZuidalinmajianju() % 3) != -1))
            {
                zdlmkjCount++;
            }
            if ((_bzbq.bianlinhe.Length > 0) && (Array.IndexOf<int>(_bzbq.bianlinhe, (GetSmallerBiggerLength() + GetZuidalinmajianju()) % 3) != -1))
            {
                blhCount++;
            }
            if ((_bzbq.qianhouguiji.Length > 0) && (Array.IndexOf<int>(_bzbq.qianhouguiji, (Math.Abs(lottery11_3[0] - 1) + Math.Abs(lottery11_3[2] - 11)) % 3) != -1))
            {
                blhCount++;
            }

            int counts = fbqCount + zdlmkjCount + blhCount + qhgjCount;

            if ((Array.IndexOf<int>(_bzbq.AppearCounts, counts) != -1)
             || (Array.IndexOf<int>(_bzbq.AppearCounts, (counts == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(_bzbq.AppearCounts, (counts == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(_bzbq.AppearCounts, (counts == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region AB分解
        public bool MeetABFenjie(ABfenjie syAttr)
        {
            if (syAttr.isEnabled == false) return true;

            List<int> AfenjieList = syAttr.Afengjie.ToList();
            List<int> BfenjieList = syAttr.Bfenjie.ToList();

            if (!((AfenjieList.Contains(lottery11_3[0]) && AfenjieList.Contains(lottery11_3[1]) && AfenjieList.Contains(lottery11_3[2])) || (BfenjieList.Contains(lottery11_3[0]) && BfenjieList.Contains(lottery11_3[1]) && BfenjieList.Contains(lottery11_3[2]))))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 合值
        public bool MeetHeZhi11_3(int[] smallBitValues)
        {
            if (smallBitValues.Length == 0) return true;

            if (Array.IndexOf<int>(smallBitValues, GetSmallBitOfSum11_3()) != -1) { return true; }

            return false;
        }
        #endregion

        #region 跨度
        public int GetSpan(int[] temp)
        {
            List<int> tempList = temp.ToList();
            tempList.Sort();
            return tempList[2] - tempList[0];
        }


        public bool MeetSpan(int[] spans)
        {
            if (spans.Length == 0)
            {
                return true;
            }

            int span = GetSpan(lottery11_3);

            if (Array.IndexOf<int>(spans, span) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 和值
        public bool MeetSumOfLottery11_3(int[] sumoflotterys)
        {
            if (sumoflotterys.Length == 0)
            {
                return true;
            }

            if (Array.IndexOf<int>(sumoflotterys, GetSumOfLottery11_3()) != -1)
            {
                return true;
            }


            return false;
        }
        #endregion

        #region 反边球距离

        public int GetSmallerBiggerLength()
        {
            return lottery11_3[0] - 1 + 11 - lottery11_3[2];
        }

        public bool MeetSmallerBiggerLength(int[] sbl)
        {
            if (sbl.Length == 0) return true;

            int n = lottery11_3[0] - 1 + 11 - lottery11_3[2];

            if (Array.IndexOf<int>(sbl, n) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 最大临码距离
        public bool MeetMaxNearestNumDis(int[] mns)
        {
            if (mns.Length == 0) return true;

            if (Array.IndexOf<int>(mns, GetZuidalinmajianju()) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 边临和
        public int GetBianLinHe()
        {
            int num = GetZuidalinmajianju() + lottery11_3[0] - 1 + 11 - lottery11_3[2];
            return num;
        }
        public bool MeetSmallBiggerLenAddMaxNearestDis(int[] sband)
        {
            if (sband.Length == 0) return true;

            int num = GetZuidalinmajianju() + lottery11_3[0] - 1 + 11 - lottery11_3[2];

            if (Array.IndexOf<int>(sband, num) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        // 任意两码的差的数组
        public int[] GetRenyiLiangmacha(int[] temp)
        {
            int[] renyiDis = new int[] {
                Math.Abs(temp[0] - temp[1]),
                Math.Abs(temp[1] - temp[2]),
                Math.Abs(temp[0] - temp[2])
            };
            return renyiDis;
        }

        // 任意两码的合的数组
        public int[] GetRenyiLiangmahehe(int[] temp)
        {
            int[] renyiHehe = new int[] {
                (temp[0] + temp[1])%10,
                (temp[2] + temp[1])%10,
                (temp[0] + temp[2])%10
            };
            return renyiHehe;
        }

        #region 两码差和
        public bool Meet11_3Liangmachahe(int[] sband)
        {
            if (sband.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(lottery11_3);

            int num = temp[0] + temp[1] + temp[2];

            if (Array.IndexOf<int>(sband, num) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 前后轨迹
        public bool Meet11_3Qianhouguiji(int[] sband)
        {
            if (sband.Length == 0) return true;

            int num = Math.Abs(lottery11_3[0] - 1) + Math.Abs(lottery11_3[2] - 11);

            if (Array.IndexOf<int>(sband, num) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 大小形态
        public bool Meet11_3Daxiaoxingtai(Daxiaoxingtai _dxxt)
        {
            /*
            if (_dxxt.isQuanda == false
                && _dxxt.isQuanxiao == false
                && _dxxt.isDadaxiao == false
                && _dxxt.isXiaoxiaoda == false
                && _dxxt.isXiaodada == false
                && _dxxt.isDaxiaoxiao == false
                && _dxxt.isDaxiaoda == false
                && _dxxt.isXiaodaxiao == false
                ) return true;
             */
            if (_dxxt.AppearCounts.Length == 0)
            {
                return true;
            }

            int count = 0;
            if (_dxxt.isQuanda)
            {
                if ((lottery11_3[0] >= 6 && lottery11_3[1] >= 6 && lottery11_3[2] >= 6))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isQuanxiao)
            {
                if ((lottery11_3[0] <= 5 && lottery11_3[1] <= 5 && lottery11_3[2] <= 5))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isDadaxiao)
            {
                if ((lottery11_3[0] >= 6 && lottery11_3[1] >= 6 && lottery11_3[2] <= 5))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isXiaoxiaoda)
            {
                if ((lottery11_3[0] <= 5 && lottery11_3[1] <= 5 && lottery11_3[2] >= 6))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isXiaodada)
            {
                if ((lottery11_3[0] <= 5 && lottery11_3[1] >= 6 && lottery11_3[2] >= 6))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isDaxiaoxiao)
            {
                if ((lottery11_3[0] >= 6 && lottery11_3[1] <= 5 && lottery11_3[2] <= 5))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isDaxiaoda)
            {
                if ((lottery11_3[0] >= 6 && lottery11_3[1] <= 5 && lottery11_3[2] >= 6))
                {
                    count++;
                    //return true;
                }
            }
            if (_dxxt.isXiaodaxiao)
            {
                if ((lottery11_3[0] <= 5 && lottery11_3[1] >= 6 && lottery11_3[2] <= 5))
                {
                    count++;
                    //return true;
                }
            }

            if (Array.IndexOf<int>(_dxxt.AppearCounts, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 单双形态
        public bool Meet11_3Danshuangxingtai(Danshuangxingtai _dsxt)
        {
            if (_dsxt.AppearCounts.Length == 0)
            {
                return true;
            }

            int count = 0;
            if (_dsxt.isQuandan)
            {
                if ((lottery11_3[0] % 2 == 1) && (lottery11_3[1] % 2 == 1) && (lottery11_3[2] % 2 == 1))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isQuanshuang)
            {
                if ((lottery11_3[0] % 2 == 0) && (lottery11_3[1] % 2 == 0) && (lottery11_3[2] % 2 == 0))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isDandanshuang)
            {
                if ((lottery11_3[0] % 2 == 1) && (lottery11_3[1] % 2 == 1) && (lottery11_3[2] % 2 == 0))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isDanshuangdan)
            {
                if ((lottery11_3[0] % 2 == 1) && (lottery11_3[1] % 2 == 0) && (lottery11_3[2] % 2 == 1))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isDanshuangshuang)
            {
                if ((lottery11_3[0] % 2 == 1) && (lottery11_3[1] % 2 == 0) && (lottery11_3[2] % 2 == 0))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isShuangdandan)
            {
                if ((lottery11_3[0] % 2 == 0) && (lottery11_3[1] % 2 == 1) && (lottery11_3[2] % 2 == 1))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isShuangdanshuang)
            {
                if ((lottery11_3[0] % 2 == 0) && (lottery11_3[1] % 2 == 1) && (lottery11_3[2] % 2 == 0))
                {
                    count++;
                    //return true;
                }
            }
            if (_dsxt.isShuangshuangdan)
            {
                if ((lottery11_3[0] % 2 == 0) && (lottery11_3[1] % 2 == 0) && (lottery11_3[2] % 2 == 1))
                {
                    count++;
                    //return true;
                }
            }

            if (Array.IndexOf<int>(_dsxt.AppearCounts, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 质和形态
        public bool Meet11_3Zhihexingtai(Zhihexingtai _zhxt)
        {
            if (_zhxt.AppearCounts.Length == 0)
            {
                return true;
            }

            int[] zhiT = new int[] { 1, 2, 3, 5, 7, 11 };
            int[] heT = new int[] { 4, 6, 8, 9, 10 };


            int count = 0;
            if (_zhxt.isQuanzhi)
            {
                if ((Array.IndexOf<int>(zhiT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isQuanhe)
            {
                if ((Array.IndexOf<int>(heT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isZhizhihe)
            {
                if ((Array.IndexOf<int>(zhiT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isZhihezhi)
            {
                if ((Array.IndexOf<int>(zhiT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isZhihehe)
            {
                if ((Array.IndexOf<int>(zhiT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isHezhizhi)
            {
                if ((Array.IndexOf<int>(heT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isHezhihe)
            {
                if ((Array.IndexOf<int>(heT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }
            if (_zhxt.isHehezhi)
            {
                if ((Array.IndexOf<int>(heT, lottery11_3[0]) != -1) && (Array.IndexOf<int>(heT, lottery11_3[1]) != -1) && (Array.IndexOf<int>(zhiT, lottery11_3[2]) != -1))
                {
                    count++;
                    //return true;
                }
            }

            if (Array.IndexOf<int>(_zhxt.AppearCounts, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 两码合差
        public bool Meet11_3Liangmahecha(LiangmahechaStruct lmhcs)
        {
            if (lmhcs.AppearCounts.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(GetRenyiLiangmahehe(lottery11_3));

            int l1 = (((Array.IndexOf<int>(lmhcs._Liangmahecha1, temp[0]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha1, temp[1]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha1, temp[2]) != -1))
                                       && lmhcs._Liangmahecha1.Length != 0) ? 1 : 0;

            int l2 = (((Array.IndexOf<int>(lmhcs._Liangmahecha2, temp[0]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha2, temp[1]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha2, temp[2]) != -1))
                                       && lmhcs._Liangmahecha2.Length != 0) ? 1 : 0;

            int l3 = (((Array.IndexOf<int>(lmhcs._Liangmahecha3, temp[0]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha3, temp[1]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha3, temp[2]) != -1))
                                       && lmhcs._Liangmahecha3.Length != 0) ? 1 : 0;

            int l4 = ((Array.IndexOf<int>(lmhcs._Liangmahecha4, temp[0]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha4, temp[1]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha4, temp[2]) != -1)
                                       && lmhcs._Liangmahecha4.Length != 0) ? 1 : 0;

            int l5 = (((Array.IndexOf<int>(lmhcs._Liangmahecha5, temp[0]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha5, temp[1]) != -1)
                   || (Array.IndexOf<int>(lmhcs._Liangmahecha5, temp[2]) != -1))
                                       && lmhcs._Liangmahecha5.Length != 0) ? 1 : 0;

            if (Array.IndexOf<int>(lmhcs.AppearCounts, l1 + l2 + l3 + l4 + l5) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 任意两码合 一
        public bool Meet11_3RenyiliangmaheYi(RenyiliangmaheYiStruct rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmahehe(lottery11_3);

            int count = SameNumberCount(rylmhy.renyiliangmaheYi.ToList(), temp.ToList());

            int[] ttt = rylmhy.AppearNums;

            Array.Sort(ttt);

            int[] result = new int[] { 0, 0, 0, 0 };

            if (ttt[0] == 0)
            {
                result = new int[] { 0, 1, 2, 3 };
            }
            if (ttt[0] == 1)
            {
                result = new int[] { 1, 2, 3 };
            } if (ttt[0] == 2)
            {
                result = new int[] { 2, 3 };
            }
            if (ttt[0] == 3)
            {
                result = new int[] { 3 };
            }

            if (Array.IndexOf<int>(result, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 任意两码合 二
        public bool Meet11_3RenyiliangmaheEr(RenyiliangmaheErStruct rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmahehe(lottery11_3);

            int count1 = SameNumberCount(rylmhy.renyiliangmaheEr1.ToList(), temp.ToList());
            int count2 = SameNumberCount(rylmhy.renyiliangmaheEr2.ToList(), temp.ToList());

            int[] ttt = rylmhy.AppearNums;

            Array.Sort(ttt);

            int[] result1 = new int[] { 0, 0, 0, 0 };
            int[] result2 = new int[] { 0, 0, 0, 0 };

            if (ttt[0] == 0)
            {
                result1 = new int[] { 0, 1, 2, 3 };
                result2 = new int[] { 0, 1, 2, 3 };
            }
            if (ttt[0] == 1)
            {
                result1 = new int[] { 1, 2, 3 };
                result2= new int[] { 1, 2, 3 };
            } if (ttt[0] == 2)
            {
                result1 = new int[] { 2, 3 };
                result2 = new int[] { 2, 3 };
            }
            if (ttt[0] == 3)
            {
                result1 = new int[] { 3 };
                result2 = new int[] { 3 };
            }

            int l1 = (((Array.IndexOf<int>(result1, count1) != -1)) && rylmhy.renyiliangmaheEr1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(result2, count2) != -1)) && rylmhy.renyiliangmaheEr2.Length != 0) ? 1 : 0;

            if (Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2) != -1) 
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 两码合最大间距
        public bool Meet11_3Liangmahezuidajianju(int[] lmhzdjj)
        {
            if (lmhzdjj.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(GetRenyiLiangmahehe(lottery11_3));
            Array.Sort(temp);

            if (Array.IndexOf<int>(lmhzdjj, temp[2] - 1) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 两码合分序组选
        public bool Meet11_3Liangmahefenxuzuxuan(Liangmahefenxuzuxuan rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmahehe(lottery11_3);

            Array.Sort(temp);

            int l1 = (((Array.IndexOf<int>(rylmhy.liangmahefenxuzuxuan1, temp[0]) != -1)) && rylmhy.liangmahefenxuzuxuan1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(rylmhy.liangmahefenxuzuxuan2, temp[1]) != -1)) && rylmhy.liangmahefenxuzuxuan2.Length != 0) ? 1 : 0;
            int l3 = (((Array.IndexOf<int>(rylmhy.liangmahefenxuzuxuan3, temp[2]) != -1)) && rylmhy.liangmahefenxuzuxuan3.Length != 0) ? 1 : 0;

            if ((Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2 + l3) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 定位两码合
        public bool Meet11_3Dingweiliangmahe(Dingweiliangmahe rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int l1 = (((Array.IndexOf<int>(rylmhy.dingweiliangmahe1, (lottery11_3[0] + lottery11_3[1]) % 10) != -1)) && rylmhy.dingweiliangmahe1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(rylmhy.dingweiliangmahe2, (lottery11_3[0] + lottery11_3[2]) % 10) != -1)) && rylmhy.dingweiliangmahe2.Length != 0) ? 1 : 0;
            int l3 = (((Array.IndexOf<int>(rylmhy.dingweiliangmahe3, (lottery11_3[1] + lottery11_3[2]) % 10) != -1)) && rylmhy.dingweiliangmahe3.Length != 0) ? 1 : 0;

            if ((Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2 + l3) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 任意两码差一
        public bool Meet11_3RenyiliangmachaYi(RenyiliangmachaYiStruct rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(lottery11_3);

            int count = SameNumberCount(rylmhy.renyiliangmachaYi.ToList(), temp.ToList());

            int[] ttt = rylmhy.AppearNums;

            Array.Sort(ttt);

            int[] result = new int[] { 0, 0, 0, 0 };

            if (ttt[0] == 0)
            {
                result = new int[] { 0, 1, 2, 3 };
            }
            if (ttt[0] == 1)
            {
                result = new int[] { 1, 2, 3 };
            } if (ttt[0] == 2)
            {
                result = new int[] { 2, 3 };
            }
            if (ttt[0] == 3)
            {
                result = new int[] { 3 };
            }

            if (Array.IndexOf<int>(result, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 任意两码差 二
        public bool Meet11_3RenyiliangmachaEr(RenyiliangmachaErStruct rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(lottery11_3);

            int count1 = SameNumberCount(rylmhy.renyiliangmachaEr1.ToList(), temp.ToList());
            int count2 = SameNumberCount(rylmhy.renyiliangmachaEr2.ToList(), temp.ToList());

            int[] ttt = rylmhy.AppearNums;

            Array.Sort(ttt);

            int[] result1 = new int[] { 0, 0, 0, 0 };
            int[] result2 = new int[] { 0, 0, 0, 0 };

            if (ttt[0] == 0)
            {
                result1 = new int[] { 0, 1, 2, 3 };
                result2 = new int[] { 0, 1, 2, 3 };
            }
            if (ttt[0] == 1)
            {
                result1 = new int[] { 1, 2, 3 };
                result2 = new int[] { 1, 2, 3 };
            } if (ttt[0] == 2)
            {
                result1 = new int[] { 2, 3 };
                result2 = new int[] { 2, 3 };
            }
            if (ttt[0] == 3)
            {
                result1 = new int[] { 3 };
                result2 = new int[] { 3 };
            }

            int l1 = (((Array.IndexOf<int>(result1, count1) != -1)) && rylmhy.renyiliangmachaEr1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(result2, count2) != -1)) && rylmhy.renyiliangmachaEr2.Length != 0) ? 1 : 0;

            if (Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 两码差最大间距
        public bool Meet11_3Liangmachazuidajianju(int[] lmczdjj)
        {
            if (lmczdjj.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(GetRenyiLiangmacha(lottery11_3));
            Array.Sort(temp);

            if (Array.IndexOf<int>(lmczdjj, temp[2] - 1) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 两码差分序组选
        public bool Meet11_3Liangmachafenxuzuxuan(Liangmachafenxuzuxuan rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int[] temp = GetRenyiLiangmacha(lottery11_3);

            Array.Sort(temp);

            int l1 = (((Array.IndexOf<int>(rylmhy.liangmachafenxuzuxuan1, temp[0]) != -1)) && rylmhy.liangmachafenxuzuxuan1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(rylmhy.liangmachafenxuzuxuan2, temp[1]) != -1)) && rylmhy.liangmachafenxuzuxuan2.Length != 0) ? 1 : 0;
            int l3 = (((Array.IndexOf<int>(rylmhy.liangmachafenxuzuxuan3, temp[2]) != -1)) && rylmhy.liangmachafenxuzuxuan3.Length != 0) ? 1 : 0;

            if ((Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2 + l3) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 定位两码差
        public bool Meet11_3Dingweiliangmacha(Dingweiliangmacha rylmhy)
        {
            if (rylmhy.AppearNums.Length == 0) return true;

            int l1 = (((Array.IndexOf<int>(rylmhy.dingweiliangmacha1, Math.Abs(lottery11_3[0] - lottery11_3[1])) != -1)) && rylmhy.dingweiliangmacha1.Length != 0) ? 1 : 0;
            int l2 = (((Array.IndexOf<int>(rylmhy.dingweiliangmacha2, Math.Abs(lottery11_3[0] - lottery11_3[2])) != -1)) && rylmhy.dingweiliangmacha2.Length != 0) ? 1 : 0;
            int l3 = (((Array.IndexOf<int>(rylmhy.dingweiliangmacha3, Math.Abs(lottery11_3[1] - lottery11_3[2])) != -1)) && rylmhy.dingweiliangmacha3.Length != 0) ? 1 : 0;

            if ((Array.IndexOf<int>(rylmhy.AppearNums, l1 + l2 + l3) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(rylmhy.AppearNums, ((l1 + l2 + l3) == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion


    }
    #endregion

    class Algorithm11_3
    {
        #region 基础号码 与 非基础号码
        public int[,] BaseNums { get; set; }
        public int[,] NotBaseNums { get; set; }

        public List<BaseNumsStruct> baseNumsStruct { get; private set; }
        public List<NotBaseNumsStruct> notBaseNumsStruct { get; private set; }
        #endregion

        #region 胆码列表
        public List<DanmaStruct> danmaStruct { get; set; }
        #endregion

        #region 定位胆码
        public LocateIndexNum11_3 _LocateIndexNum { get; set; }
        #endregion

        #region 分序组选
        public LocateIndexNumFenxu11_3 _LocateIndexNumFenxu { get; set; }
        #endregion

        #region 号码形态
        public HaomaxingtaiStruct _HaomaxingtaiStruct { get; set; }
        #endregion

        #region 平衡指数
        public PinghengzhishuStruct _PinghengzhishuStruct { get; set; }
        #endregion

        #region 偶 小 质 综合属性
        public ZongheshuxingStruct _ZongheshuxingStruct11_3 { get; set; }
        #endregion

        #region 龙头凤尾
        public LongtouFengwei11_3 _LongtouFengwei11_3 { get; set; }
        #endregion

        #region 012路
        public FZBQ012Lu _FZBQ012Lu { get; set; }
        #endregion

        #region A/B分解
        public ABfenjie _ABfenjie { get; set; }
        #endregion

        #region 合值
        public int[] HeZhi11_3 { get; set; }
        #endregion

        #region 反边球距离
        public int[] SmallerBigerLengths { get; set; }
        #endregion

        #region 最大临码距离
        public int[] MaxNearestNumDiss { get; set; }
        #endregion

        #region 边临和
        public int[] SmallBiggerLenAddMaxNearestDiss { get; set; }
        #endregion

        #region 跨度
        public int[] Spans { get; set; }
        #endregion

        #region 和值
        public int[] SumOfLotterys { get; set; }
        #endregion

        #region 两码差和
        public int[] Liangmachahe { get; set; }
        #endregion

        #region 前后轨迹
        public int[] Qianhouguiji { get; set; }
        #endregion

        #region 大小形态
        public Daxiaoxingtai _Daxiaoxingtai { get; set; }
        #endregion

        #region 单双形态
        public Danshuangxingtai _Danshuangxingtai { get; set; }
        #endregion

        #region 质和形态
        public Zhihexingtai _Zhihexingtai { get; set; }
        #endregion

        #region 两码合差
        public LiangmahechaStruct _LiangmahechaStruct { get; set; }
        #endregion

        #region 任意两码合 一
        public RenyiliangmaheYiStruct _RenyiliangmaheYi { get; set; }
        #endregion

        #region 任意两码合 二
        public RenyiliangmaheErStruct _RenyiliangmaheEr { get; set; }
        #endregion

        #region 两码合最大间距
        public int[] Liangmahezuidajianju { get; set; }
        #endregion

        #region 两码合分序组选
        public Liangmahefenxuzuxuan _Liangmahefenxuzuxuan { get; set; }
        #endregion

        #region 定位两码合
        public Dingweiliangmahe _Dingweiliangmahe { get; set; }
        #endregion

        #region 任意两码差一
        public RenyiliangmachaYiStruct _RenyiliangmachaYi { get; set; }
        #endregion

        #region 任意两码合 二
        public RenyiliangmachaErStruct _RenyiliangmachaEr { get; set; }
        #endregion

        #region 两码差最大间距
        public int[] Liangmachazuidajianju { get; set; }
        #endregion

        #region 两码合分序组选
        public Liangmachafenxuzuxuan _Liangmachafenxuzuxuan { get; set; }
        #endregion

        #region 定位两码合
        public Dingweiliangmacha _Dingweiliangmacha { get; set; }
        #endregion

        // 11_3彩票
        public List<Lottery11_3> Lotterys { get; private set; }

        // 获得所有的所有11选3
        public void ReGetBaseLotterys11_3()
        {
            Lotterys = GetBaseLotterys11_3();
        }

        // 获得有条件的所有11选3
        public void GetBaseLotterysConditional11_3Public()
        {
            Lotterys = GetBaseLotterysConditional11_3();
        }

        #region 生成基础号码
        public List<Lottery11_3> GetBaseLotterysConditional11_3()
        {
            List<Lottery11_3> lotterys = new List<Lottery11_3>();

            // 排序 从小到大
            BaseNums = Array2DSort(BaseNums);
            NotBaseNums = Array2DSort(NotBaseNums);

            int[] baseNumsArray1;
            List<int> baseNumsList1 = new List<int>();

            int[] baseNumsArray2;
            List<int> baseNumsList2 = new List<int>();

            int[] baseNumsArray3;
            List<int> baseNumsList3 = new List<int>();

            for (int j = 0; j < 11; j++)
            {
                if (BaseNums[0, j] != 0)
                {
                    baseNumsList1.Add(BaseNums[0, j]);
                }
                if (BaseNums[1, j] != 0)
                {
                    baseNumsList2.Add(BaseNums[1, j]);
                }
                if (BaseNums[2, j] != 0)
                {
                    baseNumsList3.Add(BaseNums[2, j]);
                }
            }

            baseNumsArray1 = baseNumsList1.ToArray();
            baseNumsArray2 = baseNumsList2.ToArray();
            baseNumsArray3 = baseNumsList3.ToArray();

            for (int i = 0; i < baseNumsArray1.Length; i++)
            {
                for (int ii = 0; ii < baseNumsArray2.Length; ii++)
                {
                    if (baseNumsArray2[ii] != baseNumsArray1[i])
                    {
                        for (int iii = 0; iii < baseNumsArray3.Length; iii++)
                        {
                            if ((baseNumsArray3[iii] != baseNumsArray2[ii]) && (baseNumsArray3[iii] != baseNumsArray1[i]))
                            {
                                lotterys.Add(new Lottery11_3(baseNumsArray1[i], baseNumsArray2[ii], baseNumsArray3[iii]));
                            }
                        }
                    }
                }
            }

            return lotterys;
        }

        // 数组排序
        public int[,] Array2DSort(int[,] Tarray)
        {
            int[,] sortTarray = Tarray;
            int[] arr = new int[33];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    arr[i * 11 + j] = Tarray[i, j];//把二维数组变成一维数组
                }
            }
            for (int i = 0; i < 3; i++)
                Array.Sort(arr, i * 11, 11);//从0到100，100到200，200到300这样分别排序

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 11; j++)
                {
                    sortTarray[i, j] = arr[i * 11 + j];//将一位数组再变成二维数组
                }
            }
            return sortTarray;
        }
        #endregion

        #region 生成所有基础号码
        public static List<Lottery11_3> GetBaseLotterys11_3()
        {
            List<Lottery11_3> lotterys = new List<Lottery11_3>();
            for (int i = 1; i <= 9; i++)
            {
                for (int ii = 2; ii <= 10; ii++)
                {
                    if (ii > i)
                    {
                        for (int iii = 3; iii <= 11; iii++)
                        {
                            if (iii > ii)
                            {
                                lotterys.Add(new Lottery11_3(i, ii, iii));

                            }
                        }
                    }
                }
            }
            return lotterys;
        }
        #endregion
        public void Calc()
        {
            #region 胆码规则
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetBileCode(danmaStruct))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 定位胆码
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery) //
                {
                    if (!lottery.MeetLocateIndexNum(_LocateIndexNum))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 分序组选
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery) //
                {
                    if (!lottery.MeetLocateIndexNumFenxu(_LocateIndexNumFenxu))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 号码形态
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery) //
                {
                    if (!lottery.MeetHaomaxingtaiStruct(_HaomaxingtaiStruct))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 平衡指数
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery) //
                {
                    if (!lottery.MeetPinghengzhishuStruct(_PinghengzhishuStruct))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 偶小质 综合属性
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetZongheshuxingStruct(_ZongheshuxingStruct11_3))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 龙头凤尾
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetLongtouFengweiStruct(_LongtouFengwei11_3))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion


            #region 012路
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetFZBQ012LuStruct(_FZBQ012Lu))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region A/B分解
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetABFenjie(_ABfenjie))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 和值
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetSumOfLottery11_3(SumOfLotterys))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 合值
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetHeZhi11_3(HeZhi11_3))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 跨度
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetSpan(Spans))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region  反边球距离
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetSmallerBiggerLength(SmallerBigerLengths))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region  最大临码距离
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetMaxNearestNumDis(MaxNearestNumDiss))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 边临和
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.MeetSmallBiggerLenAddMaxNearestDis(SmallBiggerLenAddMaxNearestDiss))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码差和
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmachahe(Liangmachahe))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 前后轨迹
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Qianhouguiji(Qianhouguiji))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 大小形态
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Daxiaoxingtai(_Daxiaoxingtai))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 单双形态
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Danshuangxingtai(_Danshuangxingtai))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 质和形态
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Zhihexingtai(_Zhihexingtai))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码合差
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmahecha(_LiangmahechaStruct))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 任意两码合 一
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3RenyiliangmaheYi(_RenyiliangmaheYi))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 任意两码合 二
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3RenyiliangmaheEr(_RenyiliangmaheEr))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码合最大间距
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmahezuidajianju(Liangmahezuidajianju))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码合分序组选
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmahefenxuzuxuan(_Liangmahefenxuzuxuan))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 定位两码合
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Dingweiliangmahe(_Dingweiliangmahe))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 任意两码差一
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3RenyiliangmachaYi(_RenyiliangmachaYi))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 任意两码差 二
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3RenyiliangmachaEr(_RenyiliangmachaEr))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码差最大间距
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmachazuidajianju(Liangmachazuidajianju))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码合分序组选
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Liangmachafenxuzuxuan(_Liangmachafenxuzuxuan))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 定位两码差
            Lotterys.RemoveAll(
                delegate(Lottery11_3 lottery)
                {
                    if (!lottery.Meet11_3Dingweiliangmacha(_Dingweiliangmacha))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

        }
    }
}
