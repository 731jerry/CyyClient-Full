using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace CyyClient
{
    #region 算法工具类
    public static class AlgorithmTools
    {
        public struct BeiLvCalc
        {
            public int BeiLv;
            public int ZhuShu;
            public int TouRu;
            public int LeiJi;
            public int ZhongJiang;
            public int LiRun;
            public double LiRunLv;
        }

        public static int[] GetSubArray(int[] srcArray, int length)
        {
            int[] newArr = new int[length];
            for (int i = 0; i < length; i++)
            {
                newArr[i] = srcArray[i];
            }
            return newArr;
        }
        public static int[,] GetSubArray11_3(int[,] srcArray, int[] length)
        {
            int[,] newArr = new int[3, 11];
            for (int j = 0; j < 3; j++)
            {
                for (int i = 0; i < length[j]; i++)
                {
                    newArr[j, i] = srcArray[j, i];
                }
            }


            return newArr;
        }

        public static List<BeiLvCalc> CalcBeiLv(
            int DanZhuJinE, int ZhongjiangJinE, int JiHuaTouZhu, int QiShiBeiLv, int ZhuiHaoQiShu, int Conditions,
            int txtLiRun = 0, int txtLiRunLv = 10, int txtQiCheng = 1, int txtBeiCheng = 2, int txtQiJia = 1, int txtBeiJia = 1)
        {
            List<BeiLvCalc> bcs = new List<BeiLvCalc>();

            int count = 0;

            int bl = QiShiBeiLv;
            int sums = 0;

            do
            {

                int beiLv = bl;
                int zhuShu = bl * JiHuaTouZhu;
                int touRu = zhuShu * DanZhuJinE;
                int leiJi = sums + touRu;
                int zhongJiang = bl * ZhongjiangJinE;
                int liRun = zhongJiang - leiJi;
                double liRunLv = liRun / (double)leiJi;

                BeiLvCalc bc =
                new BeiLvCalc
                {
                    BeiLv = beiLv,
                    ZhuShu = zhuShu,
                    TouRu = touRu,
                    LeiJi = leiJi,
                    ZhongJiang = zhongJiang,
                    LiRun = liRun,
                    LiRunLv = liRunLv
                };

                bool boK = false;

                switch (Conditions)
                {
                    default:
                    case 0: // 利润率
                        boK = (Math.Round(bc.LiRunLv * 100) >= txtLiRunLv) ? true : false;
                        break;
                    case 1: // 利润
                        boK = (bc.LiRun >= txtLiRun) ? true : false;
                        break;
                    case 2: // 隔 X 
                        if ((count + 1) % txtQiCheng == 0)
                        {
                            bl = bl * txtBeiCheng;
                        }
                        break;
                    case 3: // 隔 +
                        // Jerry
                        if ((count + 1) % txtQiJia == 0)
                        {
                            bl = bl + txtBeiJia;
                        }
                        break;
                    case -1:
                        boK = true;
                        break;
                }

                if (Conditions <= 1)
                {
                    if (boK)
                    {
                        bcs.Add(bc);
                        sums = sums + bc.TouRu;
                        count++;
                    }
                    else
                    {
                        bl++;
                    }
                }
                else
                {
                    bcs.Add(bc);
                    sums = sums + bc.TouRu;
                    count++;
                }
                if (bc.TouRu > 10000000)
                {
                    MessageBox.Show("数值超出范围");
                    break;

                }

            } while (count < ZhuiHaoQiShu);


            return bcs;
        }

    }
    #endregion

    #region 综合属性 结构
    public struct SynthesizedAttribute
    {
        public bool IsSelect;
        public int[] EvenCounts { get; set; }
        public int[] SmallCounts { get; set; }
        public int[] SumCounts { get; set; }
        public int[] LinkedCounts { get; set; }
        public int[] AppearCounts { get; set; }
    }
    #endregion

    #region 胆码 结构
    public struct BileCode
    {
        public bool IsSelect;
        public int[] _BileCode { get; set; }
        public int[] AppearCounts { get; set; }
        public int[] NotAppearCounts { get; set; }
    }

    #endregion

    #region 跨码
    public struct SkipNum
    {
        public int[] skipNums;
        public int[] AppearNums;
    }
    #endregion

    #region 两码差
    public struct TwoNumDis
    {
        public int[] _TwoNumDis { get; set; }
        public int[] AppearCounts { get; set; }
        public int[] NotAppearCounts { get; set; }
    }
    #endregion

    #region 平衡指数
    public enum BalanceState
    {
        LeftMore, RightMore, Equal, None
    }

    public enum AppearState
    {
        Appear, NotAppear
    }
    public struct BalanceIndex
    {
        public bool IsSelect;
        public List<BalanceState> BalanceStates { get; set; }
        public List<AppearState> ApplearStates { get; set; }
    }

    #endregion

    #region 连号轨迹
    public struct LianHaoGuiJi
    {
        // 0 为 +， 1 为 =， 2 为 -
        public int[] guiji;
        public int[] AppearCounts;
    }
    #endregion

    #region 龙头凤尾

    public enum FPState
    {
        IsPrimes, IsSums, IsSingular, IsEven
    }
    public struct FaucetAndPteris
    {
        public List<FPState> Faucent;
        public List<FPState> Peris;

        public int[] AppearCounts;
    }
    #endregion

    #region 重号与传码 结构
    public struct ReNoAndPassNo
    {
        public bool IsSelect;

        public int[] baseNums; //  基础号
        public int[] BaseNums
        {
            get { return baseNums; }
            set
            {
                baseNums = value;
                PassBigNums = (int[])baseNums.Clone();
                PassSmallNums = (int[])baseNums.Clone();
                setPassSmallAndBigNums();
            }
        }

        public int[] PassBigNums { get; private set; }


        public int[] PassSmallNums { get; private set; }
        public int[] NotReNoCounts;     //  非重号个数
        public int[] ReNoCounts;        //  重号个数
        public int[] NotPassSmallCounts;
        public int[] PassSmallCounts;   //  传小个数
        public int[] NotPassBigCounts;
        public int[] PassBigCounts;     //  传大个数

        private void setPassSmallAndBigNums()
        {
            for (int i = 0; i < baseNums.Length; i++)
            {
                PassSmallNums[i] = baseNums[i] - 1;
                PassBigNums[i] = baseNums[i] + 1;
            }
        }
    }
    #endregion

    #region 邻码间距
    public struct NearSkipCount
    {
        public int[] ns0;
        public int[] ns1;
        public int[] ns2;
        public int[] ns3;
        public int[] ns4;
        public int[] ns5;
        public int[] ns6;
        public int[] AppearCounts;
    }
    #endregion

    #region 两码和
    public struct TwoNumPlus
    {
        public int[] _TwoNumPlus { get; set; }
        public int[] AppearCounts { get; set; }
        public int[] NotAppearCounts { get; set; }
    }
    #endregion

    #region 定位组选
    public struct LocateIndexNum
    {
        public int[] index1;
        public int[] index2;
        public int[] index3;
        public int[] index4;
        public int[] index5;

        public int[] AppearCounts;
    }
    #endregion

    #region 两码组合
    public struct TwoNum
    {
        public bool State;
        public int Num1;
        public int Num2;
    }
    #endregion

    #region 智能数据
    public struct AIData
    {
        public int[] AI_A;
        public int[] AI_B;
        public int[] AI_C;
        public int[] AI_D;
        public int[] AppearCount;
    }
    #endregion

    #region 012比例
    public struct Rate012
    {
        public int count0;
        public int count1;
        public int count2;
    }
    #endregion

    #region 012路个数
    public struct CountsOf012
    {
        public int[] countOf0;
        public int[] countOf1;
        public int[] countOf2;

        public int[] AppearCount;
    }
    #endregion

    #region 智能值
    public struct AIValues
    {
        public int[] AI_A;
        public int[] AI_B;
        public int[] AI_C;
        public int[] AI_D;
        public int[] AI_E;
        public int[] AI_F;

        public int[] AppearCount;
    }
    #endregion

    #region 智能平衡
    public struct AIBalance
    {
        // 0 为 +， 1 为 =， 2 为 -
        public int[] bsA;
        public int[] bsB;
        public int[] bsC;
        public int[] AppearCounts;
    }
    #endregion

    #region 彩票类
    public class Lottery : IEquatable<Lottery>
    {
        public int this[int index]
        {
            get
            {
                if (index >= 0 && index <= 5)
                {
                    return lottery[index];
                }
                return -1;
            }
        }

        public int count0;
        public int count1;
        public int count2;


        private int[] lottery;
        private int[] NotLottery;



        #region 集临个数  溃临个数
        public int ExistMaxLinkedNum;
        public int NotExistMaxLinkedNum;






        private int SetMaxLinkedNum(int[] arr)
        {
            if (arr.Length == 0) return 0;

            int tempLinkMaxNum = 1;
            int linkMaxNum = 1;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] == 1)
                {
                    tempLinkMaxNum++;

                    if (tempLinkMaxNum > linkMaxNum)
                    {
                        linkMaxNum = tempLinkMaxNum;
                    }
                }
                else
                {

                    if (tempLinkMaxNum > linkMaxNum)
                    {
                        linkMaxNum = tempLinkMaxNum;

                    }
                    tempLinkMaxNum = 1;
                }

            }

            return linkMaxNum;
        }

        #endregion

        #region 前后比例

        public int[] sixLeft;
        public int[] sixRight;
        #endregion

        #region 综合属性
        public int EvenCount { get; private set; }
        public int SmallCount { get; private set; }
        public int SumCount { get; private set; }
        public int LinkedCount { get; private set; }
        #endregion

        #region 平衡指数
        public BalanceState _BalanceState { get; private set; }
        #endregion

        #region 临群码

        public int GetLinkCount(int[] arr)
        {
            int linkNum = 1;
            int linkCount = 0;

            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] - arr[i - 1] == 1)
                {
                    linkNum++;

                    if (i == 4)
                    {
                        linkCount++;
                    }
                }
                else
                {
                    if (linkNum > 1)
                    {
                        linkCount++;
                    }
                    linkNum = 1;
                }
            }

            return linkCount;
        }

        public int GetLinkCount()
        {
            //bool link = false;
            int linkNum = 1;
            int linkCount = 0;

            for (int i = 1; i < 5; i++)
            {
                if (lottery[i] - lottery[i - 1] == 1)
                {
                    linkNum++;

                    if (i == 4)
                    {
                        linkCount++;
                    }
                }
                else
                {
                    if (linkNum > 1)
                    {
                        linkCount++;
                    }
                    linkNum = 1;
                }
            }

            return linkCount;
        }

        #endregion

        #region 两码差
        public List<int> twoNumDiss;

        private void SetTwoNumDiss()
        {
            twoNumDiss = new List<int>();
            for (int i = 0; i < lottery.Length - 1; i++)
            {
                for (int ii = i + 1; ii < lottery.Length; ii++)
                {
                    int dis = lottery[ii] - lottery[i];
                    if (!twoNumDiss.Contains(dis))
                    {
                        twoNumDiss.Add(dis);
                    }
                }
            }
            twoNumDiss.Sort();
        }
        #endregion

        #region 两码和
        public List<int> twoNumPluss;
        private void SetTwoNumPluss()
        {
            twoNumPluss = new List<int>();

            for (int i = 0; i < lottery.Length - 1; i++)
            {
                for (int ii = i + 1; ii < lottery.Length; ii++)
                {
                    int he = lottery[ii] + lottery[i];

                    if (!twoNumPluss.Contains(he))
                    {
                        twoNumPluss.Add(he);
                    }

                }
            }

            twoNumPluss.Sort();
        }

        #endregion

        public int[] GetArray()
        {
            return lottery;
        }


        public int[] PreSort;

        public Lottery(string strlen10)
        {
            int i = int.Parse(strlen10.Substring(0, 2));
            int ii = int.Parse(strlen10.Substring(2, 2));
            int iii = int.Parse(strlen10.Substring(4, 2));
            int iv = int.Parse(strlen10.Substring(6, 2));
            int v = int.Parse(strlen10.Substring(8, 2));


            int[] arr = new int[5] { i, ii, iii, iv, v };

            PreSort = (int[])arr.Clone();

            Array.Sort<int>(arr);


            lottery = new int[] { arr[0], arr[1], arr[2], arr[3], arr[4] };
            SetNotLottery(arr[0], arr[1], arr[2], arr[3], arr[4]);
            SetTwoNumDiss();
            SetTwoNumPluss();
            SetCountOf012();

            NotExistMaxLinkedNum = SetMaxLinkedNum(NotLottery);

            ExistMaxLinkedNum = SetMaxLinkedNum(lottery);

            Set_11_5_Attr(); //综合属性 、前后比例

        }

        public Lottery(int i, int ii, int iii, int iv, int v)
        {
            lottery = new int[] { i, ii, iii, iv, v };
            SetNotLottery(i, ii, iii, iv, v);
            SetTwoNumDiss();
            SetTwoNumPluss();
            SetCountOf012();

            NotExistMaxLinkedNum = SetMaxLinkedNum(NotLottery);

            ExistMaxLinkedNum = SetMaxLinkedNum(lottery);

            Set_11_5_Attr(); //综合属性 、前后比例
        }

        private void SetNotLottery(int i, int ii, int iii, int iv, int v)
        {
            int[] tmp = new int[6];
            int length = 0;

            for (int x = 1; x <= 11; x++)
            {
                if (x != i && x != ii && x != iii && x != iv && x != v)
                {
                    tmp[length] = x;
                    length++;
                }
            }
            NotLottery = tmp;
        }

        public int GetSumOfLottery()
        {
            return lottery[0] + lottery[1] + lottery[2] + lottery[3] + lottery[4];
        }

        private void Set_11_5_Attr()
        {
            int[] sixLeft = new int[5];
            int[] sixRight = new int[5];
            int length1 = 0;
            int length2 = 0;

            for (int i = 0; i < lottery.Length; i++)
            {
                #region 设置前后比例
                if (lottery[i] < 6)
                {
                    sixLeft[length1] = lottery[i];
                    length1++;
                }

                if (lottery[i] > 6)
                {
                    sixRight[length2] = lottery[i];
                    length2++;
                }
                #endregion

                #region 设置综合属性
                if (lottery[i] % 2 == 0)
                {
                    EvenCount++;
                }

                if (lottery[i] <= 5)
                {
                    SmallCount++;
                }
                if (lottery[i] == 4 || lottery[i] == 6 || lottery[i] == 8 || lottery[i] == 9 || lottery[i] == 10)
                {
                    SumCount++;
                }

                if (i < 4)
                {
                    if ((lottery[i + 1] - lottery[i]) == 1)
                    {
                        LinkedCount++;
                    }
                }
                #endregion
            }

            this.sixLeft = AlgorithmTools.GetSubArray(sixLeft, length1);
            this.sixRight = AlgorithmTools.GetSubArray(sixRight, length2);

            int baseN = this.sixLeft.Length - this.sixRight.Length;

            if (baseN > 0)
            {
                _BalanceState = BalanceState.LeftMore;
            }
            else if (baseN < 0)
            {
                _BalanceState = BalanceState.RightMore;
            }
            else
            {
                _BalanceState = BalanceState.Equal;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is Lottery)
            {
                Lottery other = (Lottery)obj;
                if (lottery[0] == other.lottery[0] && lottery[1] == other.lottery[1] && lottery[2] == other.lottery[2]
                    && lottery[3] == other.lottery[3] && lottery[4] == other.lottery[4])
                {
                    return true;
                }
            }
            return false;
        }

        #region 智能平衡



        public BalanceState GetAIBalanceA()
        {
            int baseN = 0;
            int big12 = 0;
            int small12 = 0;
            foreach (int i in twoNumPluss)
            {
                if (i > 12)
                {
                    big12++;
                }
                if (i < 12)
                {
                    small12++;
                }
            }

            baseN = small12 - big12;
            BalanceState bs = BalanceState.None;

            if (baseN > 0)
                bs = BalanceState.LeftMore;
            else if (baseN == 0)
                bs = BalanceState.Equal;
            else
                bs = BalanceState.RightMore;

            return bs;
        }

        public BalanceState GetAIBalanceB()
        {
            int baseN = 0;
            int big6 = 0;
            int small6 = 0;


            List<int> tempints = new List<int>();

            foreach (int i in twoNumDiss)
            {
                if (i >= 4 && i <= 10)
                {
                    tempints.Add(i);
                }

            }

            foreach (int i in tempints)
            {
                if (i > 6)
                {
                    big6++;
                }
                if (i < 6)
                {
                    small6++;
                }
            }

            baseN = small6 - big6;
            BalanceState bs = BalanceState.None;

            if (baseN > 0)
                bs = BalanceState.LeftMore;
            else if (baseN == 0)
                bs = BalanceState.Equal;
            else
                bs = BalanceState.RightMore;

            return bs;
        }

        public BalanceState GetAIBalanceC()
        {

            int baseN = 0;
            int big6 = 0;
            int small6 = 0;

            int[] KLsmall6 = new int[6];
            int[] KLbig6 = new int[6];
            int length1 = 0;
            int length2 = 0;
            foreach (int i in NotLottery)
            {
                if (i < 6)
                {
                    KLsmall6[length1] = i;
                    length1++;
                }

                if (i > 6)
                {
                    KLbig6[length2] = i;
                    length2++;
                }
            }

            KLsmall6 = AlgorithmTools.GetSubArray(KLsmall6, length1);
            KLbig6 = AlgorithmTools.GetSubArray(KLbig6, length2);


            small6 = SetMaxLinkedNum(KLsmall6);
            big6 = SetMaxLinkedNum(KLbig6);

            baseN = small6 - big6;

            BalanceState bs = BalanceState.None;

            if (baseN > 0)
                bs = BalanceState.LeftMore;
            else if (baseN == 0)
                bs = BalanceState.Equal;
            else
                bs = BalanceState.RightMore;

            return bs;
        }


        public bool MeetAIBalance(AIBalance aib)
        {
            if ((aib.bsA.Length == 0 && aib.bsB.Length == 0 && aib.bsC.Length == 0) || aib.AppearCounts.Length == 0)
                return true;

            int count = 0;
            int N = 0;
            int baseN = 0;


            #region 智能A
            int big12 = 0;
            int small12 = 0;
            foreach (int i in twoNumPluss)
            {
                if (i > 12)
                {
                    big12++;
                }
                if (i < 12)
                {
                    small12++;
                }
            }

            baseN = small12 - big12;

            if (baseN > 0)
                N = 0;
            else if (baseN == 0)
                N = 1;
            else
                N = 2;

            if (Array.IndexOf<int>(aib.bsA, N) != -1)
                count++;
            #endregion

            #region 智能B
            int big6 = 0;
            int small6 = 0;


            List<int> tempints = new List<int>();

            foreach (int i in twoNumDiss)
            {
                if (i >= 4 && i <= 10)
                {
                    tempints.Add(i);
                }

            }

            foreach (int i in tempints)
            {
                if (i > 6)
                {
                    big6++;
                }
                if (i < 6)
                {
                    small6++;
                }
            }

            baseN = small6 - big6;

            if (baseN > 0)
                N = 0;
            else if (baseN == 0)
                N = 1;
            else
                N = 2;

            if (Array.IndexOf<int>(aib.bsB, N) != -1)
                count++;
            #endregion

            #region 智能C
            int[] KLsmall6 = new int[6];
            int[] KLbig6 = new int[6];
            int length1 = 0;
            int length2 = 0;
            foreach (int i in NotLottery)
            {
                if (i < 6)
                {
                    KLsmall6[length1] = i;
                    length1++;
                }

                if (i > 6)
                {
                    KLbig6[length2] = i;
                    length2++;
                }
            }

            KLsmall6 = AlgorithmTools.GetSubArray(KLsmall6, length1);
            KLbig6 = AlgorithmTools.GetSubArray(KLbig6, length2);


            small6 = SetMaxLinkedNum(KLsmall6);
            big6 = SetMaxLinkedNum(KLbig6);

            baseN = small6 - big6;

            if (baseN > 0)
                N = 0;
            else if (baseN == 0)
                N = 1;
            else
                N = 2;

            if (Array.IndexOf<int>(aib.bsC, N) != -1)
                count++;
            #endregion

            if (Array.IndexOf<int>(aib.AppearCounts, count) != -1)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 智能值

        public int GetAI_A()
        {
            int AI_A;

            AI_A = (twoNumPluss.Count + SetMaxLinkedNum(twoNumPluss.ToArray())) % 10;
            return AI_A;
        }

        public int GetAI_B()
        {
            int AI_B;
            AI_B = (twoNumDiss.Count + SetMaxLinkedNum(twoNumDiss.ToArray())) % 10;
            return AI_B;
        }

        public int GetAI_C()
        {
            int AI_C;

            AI_C = twoNumPluss.Count - SetMaxLinkedNum(twoNumPluss.ToArray());
            return AI_C;
        }

        public int GetAI_D()
        {
            int AI_D;

            AI_D = twoNumDiss.Count - SetMaxLinkedNum(twoNumDiss.ToArray());
            return AI_D;
        }

        public int GetAI_E()
        {
            List<int> lstE = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            for (int i = 0; i < twoNumDiss.Count; i++)
            {
                int n = twoNumDiss[i];

                if (lstE.Contains(n))
                {
                    lstE.Remove(n);
                }


            }

            int maxDis = twoNumDiss[twoNumDiss.Count - 1];
            int minDis = twoNumDiss[0];


            lstE.RemoveAll(delegate(int n)
            {
                if (n < minDis || n > maxDis) { return true; }
                return false;
            });

            for (int i = 0; i < lstE.Count; i++)
            {
                int n = lstE[i];
                if (n < minDis || n > maxDis)
                {
                    lstE.Remove(n);
                }
            }


            int AI_E = SetMaxLinkedNum(lstE.ToArray());

            return AI_E;
        }

        public int GetAI_F()
        {
            int FN = 0;
            for (int i = 1; i < twoNumDiss.Count; i++)
            {
                if (twoNumDiss[i] - twoNumDiss[i - 1] != 1)
                {
                    FN++;
                }
            }


            int AI_F = FN;

            return AI_F;
        }


        public bool MeetAIValues(AIValues aivs)
        {

            if ((aivs.AI_A.Length == 0 &&
                aivs.AI_B.Length == 0 &&
                aivs.AI_C.Length == 0 &&
                aivs.AI_D.Length == 0 &&
                aivs.AI_E.Length == 0 &&
                aivs.AI_F.Length == 0)
                || aivs.AppearCount.Length == 0)
            {
                return true;
            }

            int count = 0;
            #region 智能A

            int AI_A = (twoNumPluss.Count + SetMaxLinkedNum(twoNumPluss.ToArray())) % 10;

            if (Array.IndexOf<int>(aivs.AI_A, AI_A) != -1)
            {
                count++;
            }

            #endregion

            #region 智能B
            int AI_B = (twoNumDiss.Count + SetMaxLinkedNum(twoNumDiss.ToArray())) % 10;

            if (Array.IndexOf<int>(aivs.AI_B, AI_B) != -1)
            {
                count++;
            }
            #endregion

            #region 智能C
            int AI_C = twoNumPluss.Count - SetMaxLinkedNum(twoNumPluss.ToArray());

            if (Array.IndexOf<int>(aivs.AI_C, AI_C) != -1)
            {
                count++;
            }
            #endregion

            #region 智能D
            int AI_D = twoNumDiss.Count - SetMaxLinkedNum(twoNumDiss.ToArray());

            if (Array.IndexOf<int>(aivs.AI_D, AI_D) != -1)
            {
                count++;
            }
            #endregion


            #region 智能E

            List<int> lstE = new List<int>(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 });

            for (int i = 0; i < twoNumDiss.Count; i++)
            {
                int n = twoNumDiss[i];

                if (lstE.Contains(n))
                {
                    lstE.Remove(n);
                }


            }

            int maxDis = twoNumDiss[twoNumDiss.Count - 1];
            int minDis = twoNumDiss[0];


            lstE.RemoveAll(delegate(int n)
            {
                if (n < minDis || n > maxDis) { return true; }
                return false;
            });

            for (int i = 0; i < lstE.Count; i++)
            {
                int n = lstE[i];
                if (n < minDis || n > maxDis)
                {
                    lstE.Remove(n);
                }
            }


            int AI_E = SetMaxLinkedNum(lstE.ToArray());

            if (Array.IndexOf<int>(aivs.AI_E, AI_E) != -1)
            {
                count++;
            }
            #endregion

            #region 智能F

            int FN = 0;
            for (int i = 1; i < twoNumDiss.Count; i++)
            {
                if (twoNumDiss[i] - twoNumDiss[i - 1] != 1)
                {
                    FN++;
                }
            }


            int AI_F = FN;

            if (Array.IndexOf<int>(aivs.AI_F, AI_F) != -1)
            {
                count++;
            }
            #endregion


            if (Array.IndexOf<int>(aivs.AppearCount, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        public bool HasAnyNums(int[] others)
        {
            foreach (int i in others)
            {
                int index = Array.BinarySearch<int>(lottery, i);
                if (index >= 0 && index < lottery.Length)
                {
                    return true;
                }
            }
            return false;
        }

        private void SetCountOf012()
        {
            foreach (int i in lottery)
            {
                if (i % 3 == 0)
                {
                    count0++;
                }
                else if (i % 3 == 1)
                {
                    count1++;
                }
                else if (i % 3 == 2)
                {
                    count2++;
                }
            }
        }

        public int GetSmallBitOfSum()
        {
            int sum = GetSumOfLottery();

            string sumStr = sum.ToString();
            sumStr = sumStr.Substring(sumStr.Length - 1, 1);

            return int.Parse(sumStr);
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

        public int SameNumberCount(int[] other)
        {
            int sameCount = 0;
            for (int i = 0; i < lottery.Length; i++)
            {
                for (int ii = 0; ii < other.Length; ii++)
                {
                    if (lottery[i] == other[ii])
                    {
                        sameCount++;
                    }
                }
            }
            return sameCount;
        }

        private int SameNumberCount(int[] arr1, int[] arr2)
        {
            int sameCount = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int ii = 0; ii < arr2.Length; ii++)
                {
                    if (arr1[i] == arr2[ii])
                    {
                        sameCount++;
                    }
                }
            }
            return sameCount;
        }

        public int GetMaxNearestNumDis()
        {
            int l1 = lottery[1] - lottery[0];
            int l2 = lottery[2] - lottery[1];
            int l3 = lottery[3] - lottery[2];
            int l4 = lottery[4] - lottery[3];

            int[] ll = new int[] { l1, l2, l3, l4 };

            Array.Sort<int>(ll);
            return ll[3];
        }

        #region 龙头凤尾
        public FPState GetFaucetStatePrimer()
        {
            int l1 = lottery[0];
            FPState f1 = (l1 == 1 || l1 == 2 || l1 == 3 || l1 == 5 || l1 == 7 || l1 == 11) ? FPState.IsPrimes : FPState.IsSums;
            return f1;
        }

        public FPState GetPterisStatePrimer()
        {
            int l5 = lottery[4];
            FPState p1 = (l5 == 1 || l5 == 2 || l5 == 3 || l5 == 5 || l5 == 7 || l5 == 11) ? FPState.IsPrimes : FPState.IsSums;
            return p1;
        }

        public bool MeetFaucetAndPterisPrimer(FaucetAndPteris fp)
        {
            if (fp.AppearCounts.Length == 0) return true;

            int l1 = lottery[0];
            int l5 = lottery[4];

            FPState f1 = (l1 == 1 || l1 == 2 || l1 == 3 || l1 == 5 || l1 == 7 || l1 == 11) ? FPState.IsPrimes : FPState.IsSums;
            FPState p1 = (l5 == 1 || l5 == 2 || l5 == 3 || l5 == 5 || l5 == 7 || l5 == 11) ? FPState.IsPrimes : FPState.IsSums;

            int appearcount = (fp.Faucent.Contains(f1) ? 1 : 0) + (fp.Peris.Contains(p1) ? 1 : 0);

            if (Array.IndexOf<int>(fp.AppearCounts, appearcount) != -1)
            {
                return true;
            }

            return false;
        }

        public FPState GetFaucetStateEven()
        {
            int l1 = lottery[0];
            FPState f1 = (l1 % 2 == 0) ? FPState.IsEven : FPState.IsSingular;
            return f1;
        }

        public FPState GetPterisStateEven()
        {
            int l5 = lottery[4];
            FPState p1 = (l5 % 2 == 0) ? FPState.IsEven : FPState.IsSingular;
            return p1;
        }

        public bool MeetFaucetAndPterisEven(FaucetAndPteris fp)
        {
            if (fp.AppearCounts.Length == 0) return true;

            int l1 = lottery[0];
            int l5 = lottery[4];

            FPState f1 = (l1 % 2 == 0) ? FPState.IsEven : FPState.IsSingular;
            FPState p1 = (l5 % 2 == 0) ? FPState.IsEven : FPState.IsSingular;

            int appearcount = (fp.Faucent.Contains(f1) ? 1 : 0) + (fp.Peris.Contains(p1) ? 1 : 0);

            if (Array.IndexOf<int>(fp.AppearCounts, appearcount) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 集临个数
        public bool MeetLinkNum(int[] linknum, bool maxlinkNum)
        {
            if (linknum.Length == 0)
            {
                return true;
            }

            int N = maxlinkNum ? ExistMaxLinkedNum : NotExistMaxLinkedNum;

            int index = Array.IndexOf<int>(linknum, N);

            if (index != -1)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region 平衡指数
        public bool MeetBalanceIndex(BalanceIndex bi)
        {
            if (/*bi.ApplearStates.Count == 0 || */bi.BalanceStates.Count == 0)
            {
                return true;
            }

            bool exist = bi.BalanceStates.Contains(_BalanceState);

            return exist;

            /*
            if (exist)
            {
                if (bi.ApplearStates.Contains(AppearState.Appear))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (bi.ApplearStates.Contains(AppearState.Appear))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
             */
        }
        #endregion

        private int[] GetSimall6()
        {
            int[] tmps = new int[5];
            int length = 0;
            foreach (int i in lottery)
            {
                if (i <= 6)
                {
                    tmps[length] = i;
                    length++;
                }
            }

            return AlgorithmTools.GetSubArray(tmps, length);
        }

        private int[] GetBigger6()
        {
            int[] tmps = new int[5];
            int length = 0;
            foreach (int i in lottery)
            {
                if (i >= 6)
                {
                    tmps[length] = i;
                    length++;
                }
            }

            return AlgorithmTools.GetSubArray(tmps, length);
        }

        public int GetLinkTrail()
        {
            int small6 = 0;
            int[] small6s = GetSimall6();

            for (int i = 0; i < small6s.Length - 1; i++)
            {
                if ((small6s.Length > 1) && (small6s[i + 1] - small6s[i] == 1))
                {
                    small6++;
                }
            }

            int big6 = 0;
            int[] big6s = GetBigger6();
            for (int i = 0; i < big6s.Length - 1; i++)
            {
                if ((big6s.Length > 1) && (big6s[i + 1] - big6s[i] == 1))
                {
                    big6++;
                }
            }

            int baseN = small6 - big6;

            return baseN;
        }

        #region 连号轨迹
        public bool MeetLianHaoGuiJi(LianHaoGuiJi lhgj)
        {
            if (lhgj.guiji.Length == 0 /*|| lhgj.AppearCounts.Length == 0*/)
                return true;

            int small6 = 0;
            int[] small6s = GetSimall6();

            for (int i = 0; i < small6s.Length - 1; i++)
            {
                if ((small6s.Length > 1) && (small6s[i + 1] - small6s[i] == 1))
                {
                    small6++;
                }
            }

            int big6 = 0;
            int[] big6s = GetBigger6();
            for (int i = 0; i < big6s.Length - 1; i++)
            {
                if ((big6s.Length > 1) && (big6s[i + 1] - big6s[i] == 1))
                {
                    big6++;
                }
            }

            int baseN = small6 - big6;
            int index;

            if (baseN > 0)
            {
                index = Array.IndexOf<int>(lhgj.guiji, 0);
            }
            else if (baseN < 0)
            {
                index = Array.IndexOf<int>(lhgj.guiji, 1);
            }
            else
            {
                index = Array.IndexOf<int>(lhgj.guiji, 2);
            }


            if (index >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }

            /*
            if (index >= 0)
            {
                if (Array.IndexOf<int>(lhgj.AppearCounts, 0) != -1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
            else
            {
                if (Array.IndexOf<int>(lhgj.AppearCounts, 0) != -1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
             */

        }
        #endregion

        #region 重号与传码
        public bool MeetReNoAndPassNo(ReNoAndPassNo rap)
        {

            if (rap.BaseNums.Length == 0)
            {
                return true;
            }

            if (rap.ReNoCounts.Length != 0)
            {
                int sameBaseNumCount = SameNumberCount(rap.BaseNums);
                int notIndex1 = Array.IndexOf<int>(rap.NotReNoCounts, sameBaseNumCount);
                if (notIndex1 != -1)
                {
                    return false;
                }
            }


            if (rap.PassSmallCounts.Length != 0)
            {
                int samePassSmallNumCount = SameNumberCount(rap.PassSmallNums);
                int notIndex2 = Array.IndexOf<int>(rap.NotPassSmallCounts, samePassSmallNumCount);
                if (notIndex2 != -1)
                {
                    return false;
                }
            }

            if (rap.PassBigCounts.Length != 0)
            {

                int samePassBigNumCount = SameNumberCount(rap.PassBigNums);
                int notIndex3 = Array.IndexOf<int>(rap.NotPassBigCounts, samePassBigNumCount);

                if (notIndex3 != -1)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 前后比例
        public bool MeetSixLeftNum(int[] sixLeftNums, int[] sixRightNums)
        {
            if (sixLeftNums.Length == 0 || sixRightNums.Length == 0)
            {
                return true;
            }

            foreach (int i in sixLeftNums)
            {
                if (i == this.sixLeft.Length)
                {
                    foreach (int ii in sixRightNums)
                    {
                        if (ii == this.sixRight.Length)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }
        #endregion

        #region 综合属性
        public bool MeetSynthesizedAttribute(SynthesizedAttribute syAttr)
        {
            const int Nexist = -1;
            int evenIndex;
            if (syAttr.EvenCounts.Length == 0)
            {
                evenIndex = Nexist;
            }
            else { evenIndex = Array.IndexOf<int>(syAttr.EvenCounts, EvenCount); }

            int smallIndex;

            if (syAttr.SmallCounts.Length == 0)
            { smallIndex = Nexist; }
            else
            {
                smallIndex = Array.IndexOf<int>(syAttr.SmallCounts, SmallCount);
            }


            int sumIndex;

            if (syAttr.SumCounts.Length == 0) { sumIndex = Nexist; }
            else
            {
                sumIndex = Array.IndexOf<int>(syAttr.SumCounts, SumCount);
            }


            int linkedIndex;

            if (syAttr.LinkedCounts.Length == 0) { linkedIndex = Nexist; }
            else
            {
                linkedIndex = Array.IndexOf<int>(syAttr.LinkedCounts, LinkedCount);
            }


            int indexSum = (evenIndex == Nexist ? 0 : 1)
                + (smallIndex == Nexist ? 0 : 1)
                + (sumIndex == Nexist ? 0 : 1)
                + (linkedIndex == Nexist ? 0 : 1);

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

        #region 胆码
        public bool MeetBileCode(List<BileCode> bileCodes)
        {
            foreach (BileCode bc in bileCodes)
            {
                if (bc._BileCode.Length == 0 || bc.AppearCounts.Length == 0)
                    continue;

                int counts = SameNumberCount(bc._BileCode);

                int notIndex = Array.IndexOf<int>(bc.NotAppearCounts, counts);

                if (notIndex != -1)
                {
                    return false;
                }
            }

            return true;
        }
        #endregion

        #region 临群码
        public bool MeetLinkCounts(int[] linkcounts)
        {
            if (linkcounts.Length == 0)
            {
                return true;
            }

            int linkcount = GetLinkCount();

            if (Array.IndexOf<int>(linkcounts, linkcount) != -1)
            {
                return true;
            }
            return false;

        }
        #endregion

        #region 龙头凤尾 012路

        public int GetFacucet012()
        {
            return lottery[0] % 3;
        }

        public int GetPteris012()
        {
            return lottery[4] % 3;
        }

        public bool Meet012(int[] lt012, int[] fw012, int[] appears)
        {
            if ((lt012.Length == 0 && fw012.Length == 0) || appears.Length == 0)
            {
                return true;
            }

            int count = 0;
            if (Array.IndexOf<int>(lt012, lottery[0] % 3) != -1)
            {
                count++;
            }

            if (Array.IndexOf<int>(fw012, lottery[4] % 3) != -1)
            {
                count++;
            }

            if (Array.IndexOf<int>(appears, count) != -1)
            {
                return true;
            }

            return false;
        }


        /*
        public bool Meet012(int[] fct012, bool head)
        {
            int index = head ? 0 : 4;

            if (fct012.Length == 0) return true;

            if (Array.IndexOf<int>(fct012, lottery[index] % 3) != -1)
                return true;

            return false;
        }
         */

        #endregion

        #region 和值
        public bool MeetSumOfLottery(int[] sumoflotterys)
        {
            if (sumoflotterys.Length == 0)
            {
                return true;
            }

            if (Array.IndexOf<int>(sumoflotterys, GetSumOfLottery()) != -1)
            {
                return true;
            }


            return false;
        }
        #endregion

        #region 合值
        public bool MeetSmallBitValue(int[] smallBitValues)
        {
            if (smallBitValues.Length == 0) return true;

            if (Array.IndexOf<int>(smallBitValues, GetSmallBitOfSum()) != -1) { return true; }

            return false;
        }
        #endregion

        #region 跨度

        public int GetSpan()
        {
            return lottery[4] - lottery[0];
        }
        public bool MeetSpan(int[] spans)
        {
            if (spans.Length == 0)
            {
                return true;
            }

            int span = lottery[4] - lottery[0];

            if (Array.IndexOf<int>(spans, span) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 临码和

        public int GetLinMaHe()
        {
            return lottery[4] - lottery[0] - 4;
        }
        public bool MeetMaxMinusSmallMinus(int[] mmsm4)
        {
            if (mmsm4.Length == 0) return true;

            int num = lottery[4] - lottery[0] - 4;

            if (Array.IndexOf<int>(mmsm4, num) != -1)
            {
                return true;
            }
            return false;
        }
        #endregion

        #region 两码差

        public bool MeetTwoNumDis(List<TwoNumDis> tnds)
        {
            if (tnds.Count == 0 || (tnds[0]._TwoNumDis.Length == 0 && tnds[1]._TwoNumDis.Length == 0 && tnds[2]._TwoNumDis.Length == 0 && tnds[3]._TwoNumDis.Length == 0 && tnds[4]._TwoNumDis.Length == 0))
            {
                return true;
            }

            foreach (TwoNumDis tnd in tnds)
            {
                if (tnd._TwoNumDis.Length == 0 || tnd.AppearCounts.Length == 0)
                {
                    continue;
                }

                int sameCount = SameNumberCount(new List<int>(tnd._TwoNumDis), twoNumDiss);

                if (Array.IndexOf<int>(tnd.NotAppearCounts, sameCount) != -1)
                {
                    return false;
                }
            }



            return true;
        }
        #endregion

        #region 差临值
        public bool MeetTwoNumDisCounts(int[] tndc)
        {
            if (tndc.Length == 0) return true;

            if (Array.IndexOf<int>(tndc, twoNumDiss.Count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 反边球距离

        public int GetSmallerBiggerLength()
        {
            return lottery[0] - 1 + 11 - lottery[4];
        }

        public bool MeetSmallerBiggerLength(int[] sbl)
        {
            if (sbl.Length == 0) return true;

            int n = lottery[0] - 1 + 11 - lottery[4];

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


            if (Array.IndexOf<int>(mns, GetMaxNearestNumDis()) != -1)
            {
                return true;
            }



            return false;
        }
        #endregion

        #region 边临和

        public int GetBianLinHe()
        {
            int num = GetMaxNearestNumDis() + lottery[0] - 1 + 11 - lottery[4];
            return num;
        }
        public bool MeetSmallBiggerLenAddMaxNearestDis(int[] sband)
        {
            if (sband.Length == 0) return true;
            int num = GetMaxNearestNumDis() + lottery[0] - 1 + 11 - lottery[4];

            if (Array.IndexOf<int>(sband, num) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 跨码

        public List<int> GetKuaMas()
        {
            List<int> skips = new List<int>();

            for (int i = 0; i < lottery.Length - 1; i++)
            {
                for (int ii = i + 1; (ii < i + 3) && (ii < lottery.Length); ii++)
                {
                    if (lottery[ii] - lottery[i] == 2)
                    {
                        skips.Add(lottery[i]);
                    }
                }
            }

            return skips;
        }

        public bool MeetSkipNums(SkipNum skipnum)
        {
            if (skipnum.AppearNums.Length == 0) return true;

            List<int> skips = new List<int>();

            for (int i = 0; i < lottery.Length - 1; i++)
            {
                for (int ii = i + 1; (ii < i + 3) && (ii < lottery.Length); ii++)
                {
                    if (lottery[ii] - lottery[i] == 2)
                    {
                        skips.Add(lottery[i]);
                    }
                }
            }

            int count = SameNumberCount(skips, new List<int>(skipnum.skipNums));

            if (Array.IndexOf<int>(skipnum.AppearNums, count) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 邻码间距

        public int[] GetJianGeCount()
        {
            int[] skips = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 1; i < lottery.Length; i++)
            {
                int nearskip = lottery[i] - lottery[i - 1] - 1;

                skips[nearskip]++;
            }

            return skips;
        }

        public bool MeetNearSkipCount(NearSkipCount nsc)
        {
            if (nsc.AppearCounts.Length == 0) return true;

            int s0 = 0;
            int s1 = 0;
            int s2 = 0;
            int s3 = 0;
            int s4 = 0;
            int s5 = 0;
            int s6 = 0;

            for (int i = 1; i < lottery.Length; i++)
            {
                int nearskip = Math.Abs(lottery[i] - lottery[i - 1]) - 1;

                switch (nearskip)
                {
                    default:
                    case 0:
                        s0++;
                        break;
                    case 1:
                        s1++;
                        break;
                    case 2:
                        s2++;
                        break;
                    case 3:
                        s3++;
                        break;
                    case 4:
                        s4++;
                        break;
                    case 5:
                        s5++;
                        break;
                    case 6:
                        s6++;
                        break;
                }
            }

            int openCount = ((nsc.ns0.Length != 0) ? 1 : 0)
                         + ((nsc.ns1.Length != 0) ? 1 : 0)
                         + ((nsc.ns2.Length != 0) ? 1 : 0)
                         + ((nsc.ns3.Length != 0) ? 1 : 0)
                         + ((nsc.ns4.Length != 0) ? 1 : 0)
                         + ((nsc.ns5.Length != 0) ? 1 : 0)
                         + ((nsc.ns6.Length != 0) ? 1 : 0);

            int count = ((Array.IndexOf<int>(nsc.ns0, s0) != -1 && nsc.ns0.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns1, s1) != -1 && nsc.ns1.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns2, s2) != -1 && nsc.ns2.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns3, s3) != -1 && nsc.ns3.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns4, s4) != -1 && nsc.ns4.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns5, s5) != -1 && nsc.ns5.Length != 0) ? 1 : 0)
                         + ((Array.IndexOf<int>(nsc.ns6, s6) != -1 && nsc.ns6.Length != 0) ? 1 : 0);

            if (count == openCount)
            {
                return true;
            }
            else if (Array.IndexOf<int>(nsc.AppearCounts, count) != -1)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 首尾临码最大间距

        public int GetShouWeiZuiDaJJ()
        {
            int skip1 = lottery[1] - lottery[0] - 1;
            int skip2 = lottery[4] - lottery[3] - 1;

            int max = skip1 > skip2 ? skip1 : skip2;
            return max;
        }
        public bool MeetHeadTailMaxSkip(int[] htms)
        {
            if (htms.Length == 0) return true;

            int skip1 = lottery[1] - lottery[0] - 1;
            int skip2 = lottery[4] - lottery[3] - 1;

            int max = skip1 > skip2 ? skip1 : skip2;

            if (Array.IndexOf<int>(htms, max) != -1)
            {
                return true;
            }


            return false;
        }

        #endregion

        #region 定位组选
        public bool MeetLocateIndexNum(LocateIndexNum lin)
        {
            if (lin.AppearCounts.Length == 0) return true;

            int l1 =
             ((Array.IndexOf<int>(lin.index1, lottery[0]) != -1) && lin.index1.Length != 0) ? 1 : 0;

            int l2 =
            ((Array.IndexOf<int>(lin.index2, lottery[1]) != -1) && lin.index2.Length != 0) ? 1 : 0;

            int l3 =
            ((Array.IndexOf<int>(lin.index3, lottery[2]) != -1) && lin.index3.Length != 0) ? 1 : 0;

            int l4 =
            ((Array.IndexOf<int>(lin.index4, lottery[3]) != -1) && lin.index4.Length != 0) ? 1 : 0;

            int l5 =
            ((Array.IndexOf<int>(lin.index5, lottery[4]) != -1) && lin.index5.Length != 0) ? 1 : 0;

            if (Array.IndexOf<int>(lin.AppearCounts, l1 + l2 + l3 + l4 + l5) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        /*
        #region 两码差

        public bool MeetTwoNumDis(List<TwoNumDis> tnds)
        {
            if (tnds.Count == 0 || (tnds[0]._TwoNumDis.Length == 0 && tnds[1]._TwoNumDis.Length == 0 && tnds[2]._TwoNumDis.Length == 0 && tnds[3]._TwoNumDis.Length == 0 && tnds[4]._TwoNumDis.Length == 0))
            {
                return true;
            }

            foreach (TwoNumDis tnd in tnds)
            {
                if (tnd._TwoNumDis.Length == 0 || tnd.AppearCounts.Length == 0)
                {
                    continue;
                }

                int sameCount = SameNumberCount(new List<int>(tnd._TwoNumDis), twoNumDiss);

                if (Array.IndexOf<int>(tnd.NotAppearCounts, sameCount) != -1)
                {
                    return false;
                }
            }



            return true;
        }
        #endregion
        */

        #region 两码和
        public bool MeetTwoNumPlus(List<TwoNumPlus> tnps)
        {
            if (tnps.Count == 0 || (tnps[0]._TwoNumPlus.Length == 0 && tnps[1]._TwoNumPlus.Length == 0 && tnps[2]._TwoNumPlus.Length == 0 && tnps[3]._TwoNumPlus.Length == 0 && tnps[4]._TwoNumPlus.Length == 0))
            {
                return true;
            }

            foreach (TwoNumPlus tnp in tnps)
            {
                if (tnp._TwoNumPlus.Length == 0 || tnp.AppearCounts.Length == 0)
                {
                    continue;
                }

                int sameCount = SameNumberCount(new List<int>(tnp._TwoNumPlus), twoNumPluss);

                if (Array.IndexOf<int>(tnp.NotAppearCounts, sameCount) != -1)
                {
                    return false;
                }
            }

            return true;
        }

        #endregion

        #region 两码组合
        public bool MeetTwoNumsChu(List<TwoNum> twonums, bool state)
        {

            List<int> tmpList = new List<int>(lottery);

            if (twonums.Count == 0) return true;

            foreach (TwoNum tn in twonums)
            {
                if (state)
                {

                    if (tn.State)
                    {
                        if (tmpList.Contains(tn.Num1) && tmpList.Contains(tn.Num2))
                            return true;
                        else
                            return false;
                    }
                    else
                        return false;
                }
                else
                {

                    if (!tn.State)
                    {
                        if (tmpList.Contains(tn.Num1) && tmpList.Contains(tn.Num2))
                            return false;
                        else
                            return true;
                    }
                    else
                        return true;
                }

            }

            if (state)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        // 两码组合 - new
        public bool MeetTwoNums(TwoNum tn, bool state)
        {
            bool twoNumsState = false;
            List<int> tmpList = new List<int>(lottery);
            if (state)
            {
                if (tn.State) // 出
                {
                    if (tmpList.Contains(tn.Num1) && tmpList.Contains(tn.Num2))
                        return true;
                    else
                        return false;
                }
            }
            else
            {
                if (!tn.State) // 杀
                {
                    if (tmpList.Contains(tn.Num1) && tmpList.Contains(tn.Num2))
                        return false;
                    else
                        return true;
                }
                else
                    return true;
            }
            return twoNumsState;
        }
        #endregion

        #region 智能数据


        public List<int> Get_AI_A()
        {
            int[] A1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] A2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            int[] A3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 10 };
            int[] A4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 11 };

            List<int[]> listA = new List<int[]>();
            listA.Add(A1);
            listA.Add(A2);
            listA.Add(A3);
            listA.Add(A4);

            List<int> ais = new List<int>();

            for (int i = 0; i < listA.Count; i++)
            {

                if (SameNumberCount(listA[i]) == 5)
                {
                    ais.Add(i);
                }
            }

            return ais;
        }

        public List<int> Get_AI_B()
        {
            int[] B1 = new int[] { 1, 2, 3, 4, 5, 6, 8, 9 };
            int[] B2 = new int[] { 1, 2, 3, 4, 5, 6, 8, 10 };
            int[] B3 = new int[] { 1, 2, 3, 4, 5, 6, 8, 11 };
            int[] B4 = new int[] { 1, 2, 3, 4, 5, 6, 9, 10 };

            List<int[]> listB = new List<int[]>();
            listB.Add(B1);
            listB.Add(B2);
            listB.Add(B3);
            listB.Add(B4);

            List<int> ais = new List<int>();

            for (int i = 0; i < listB.Count; i++)
            {

                if (SameNumberCount(listB[i]) == 5)
                {
                    ais.Add(i);
                }
            }
            return ais;
        }

        public List<int> Get_AI_C()
        {
            int[] C1 = new int[] { 1, 2, 3, 4, 5, 6, 9, 11 };
            int[] C2 = new int[] { 1, 2, 3, 4, 5, 6, 10, 11 };
            int[] C3 = new int[] { 2, 3, 5, 7, 8, 9, 10, 11 };
            int[] C4 = new int[] { 3, 4, 6, 7, 8, 9, 10, 11 };


            List<int[]> listC = new List<int[]>();
            listC.Add(C1);
            listC.Add(C2);
            listC.Add(C3);
            listC.Add(C4);
            List<int> ais = new List<int>();

            for (int i = 0; i < listC.Count; i++)
            {

                if (SameNumberCount(listC[i]) == 5)
                {
                    ais.Add(i);
                }
            }
            return ais;
        }

        public List<int> Get_AI_D()
        {
            int[] D1 = new int[] { 1, 4, 5, 7, 8, 9, 10, 11 };
            int[] D2 = new int[] { 2, 5, 6, 7, 8, 9, 10, 11 };
            int[] D3 = new int[] { 1, 3, 6, 7, 8, 9, 10, 11 };
            int[] D4 = new int[] { 1, 2, 4, 7, 8, 9, 10, 11 };

            List<int[]> listD = new List<int[]>();
            listD.Add(D1);
            listD.Add(D2);
            listD.Add(D3);
            listD.Add(D4);

            List<int> ais = new List<int>();

            for (int i = 0; i < listD.Count; i++)
            {

                if (SameNumberCount(listD[i]) == 5)
                {
                    ais.Add(i);
                }
            }
            return ais;
        }

        public bool MeetAIData(AIData aiData)
        {
            if ((aiData.AI_A.Length == 0) && (aiData.AI_B.Length == 0) && (aiData.AI_C.Length == 0) && (aiData.AI_D.Length == 0) || (aiData.AppearCount.Length == 0))
            {
                return true;
            }
            int[] A1 = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
            int[] A2 = new int[] { 1, 2, 3, 4, 5, 6, 7, 9 };
            int[] A3 = new int[] { 1, 2, 3, 4, 5, 6, 7, 10 };
            int[] A4 = new int[] { 1, 2, 3, 4, 5, 6, 7, 11 };

            List<int[]> listA = new List<int[]>();
            listA.Add(A1);
            listA.Add(A2);
            listA.Add(A3);
            listA.Add(A4);


            int[] B1 = new int[] { 1, 2, 3, 4, 5, 6, 8, 9 };
            int[] B2 = new int[] { 1, 2, 3, 4, 5, 6, 8, 10 };
            int[] B3 = new int[] { 1, 2, 3, 4, 5, 6, 8, 11 };
            int[] B4 = new int[] { 1, 2, 3, 4, 5, 6, 9, 10 };

            List<int[]> listB = new List<int[]>();
            listB.Add(B1);
            listB.Add(B2);
            listB.Add(B3);
            listB.Add(B4);


            int[] C1 = new int[] { 1, 2, 3, 4, 5, 6, 9, 11 };
            int[] C2 = new int[] { 1, 2, 3, 4, 5, 6, 10, 11 };
            int[] C3 = new int[] { 2, 3, 5, 7, 8, 9, 10, 11 };
            int[] C4 = new int[] { 3, 4, 6, 7, 8, 9, 10, 11 };


            List<int[]> listC = new List<int[]>();
            listC.Add(C1);
            listC.Add(C2);
            listC.Add(C3);
            listC.Add(C4);

            int[] D1 = new int[] { 1, 4, 5, 7, 8, 9, 10, 11 };
            int[] D2 = new int[] { 2, 5, 6, 7, 8, 9, 10, 11 };
            int[] D3 = new int[] { 1, 3, 6, 7, 8, 9, 10, 11 };
            int[] D4 = new int[] { 1, 2, 4, 7, 8, 9, 10, 11 };

            List<int[]> listD = new List<int[]>();
            listD.Add(D1);
            listD.Add(D2);
            listD.Add(D3);
            listD.Add(D4);

            int counts = 0;

            #region AI A
            if (aiData.AI_A.Length != 0)
            {
                for (int i = 0; i < aiData.AI_A.Length; i++)
                {

                    if (SameNumberCount(listA[aiData.AI_A[i] - 1]) == 5)
                    {
                        counts++;
                        break;
                    }
                }
            }
            #endregion

            #region AI B

            if (aiData.AI_B.Length != 0)
            {
                for (int i = 0; i < aiData.AI_B.Length; i++)
                {

                    if (SameNumberCount(listB[aiData.AI_B[i] - 1]) == 5)
                    {
                        counts++;
                        break;
                    }
                }
            }
            #endregion

            #region AI C
            if (aiData.AI_C.Length != 0)
            {
                for (int i = 0; i < aiData.AI_C.Length; i++)
                {

                    if (SameNumberCount(listC[aiData.AI_C[i] - 1]) == 5)
                    {
                        counts++;
                        break;
                    }
                }
            }
            #endregion

            #region AI D
            if (aiData.AI_D.Length != 0)
            {
                for (int i = 0; i < aiData.AI_D.Length; i++)
                {

                    if (SameNumberCount(listD[aiData.AI_D[i] - 1]) == 5)
                    {
                        counts++;
                        break;
                    }
                }
            }
            #endregion


            if (Array.IndexOf<int>(aiData.AppearCount, counts) != -1)
            {
                return true;
            }


            return false;
        }
        #endregion

        #region 012路
        public bool Meet012(CountsOf012 cf012)
        {
            int lotCount0 = 0;
            int lotCount1 = 0;
            int lotCount2 = 0;
            for (int j = 0; j < lottery.Length; j++)
            {
                if (lottery[j] % 3 == 0)
                {
                    lotCount0++;
                }
                if (lottery[j] % 3 == 1)
                {
                    lotCount1++;
                }
                if (lottery[j] % 3 == 2)
                {
                    lotCount2++;
                }
            }

            if (cf012.AppearCount.Length == 0) return true;

            int counts = 0;

            if (cf012.countOf0.Length != 0 && Array.IndexOf<int>(cf012.countOf0, lotCount0) != -1)
            {
                counts++;
            }

            if (cf012.countOf1.Length != 0 && Array.IndexOf<int>(cf012.countOf1, lotCount1) != -1)
            {
                counts++;
            }

            if (cf012.countOf2.Length != 0 && Array.IndexOf<int>(cf012.countOf2, lotCount2) != -1)
            {
                counts++;
            }

            if ((Array.IndexOf<int>(cf012.AppearCount, counts) != -1)
                //|| (Array.IndexOf<int>(cf012.AppearCount, (counts == 2) ? 2 : -1) != -1)
             || (Array.IndexOf<int>(cf012.AppearCount, (counts == 1) ? 1 : -1) != -1)
             || (Array.IndexOf<int>(cf012.AppearCount, (counts == 0) ? 0 : -1) != -1))
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 012路比例
        public bool MeetRate012(List<Rate012> rate012s, int[] appearcounts)
        {
            if (rate012s.Count == 0 || appearcounts.Length == 0) return true;

            int count = 0;
            foreach (Rate012 r012 in rate012s)
            {
                if ((r012.count0 == count0) && (r012.count1 == count1) && (r012.count2 == count2))
                {
                    count++;
                }
            }

            if (Array.IndexOf<int>(appearcounts, count) != -1)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
        #endregion

        #region 断临

        public int[] GetDuanLins()
        {
            int[] dls = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            Array.Sort<int>(NotLottery);

            int len = 0;

            if (NotLottery[NotLottery.Length - 1] == 11 && NotLottery[0] == 1)
            {
                dls[len] = 11;
                len++;
            }

            for (int i = 0; i < NotLottery.Length - 1; i++)
            {

                if (NotLottery[i + 1] - NotLottery[i] == 1)
                {
                    dls[len] = NotLottery[i];
                    len++;
                }
            }



            return AlgorithmTools.GetSubArray(dls, len); ;
        }
        public bool MeetKillNears(int[] killNears)
        {
            if (killNears.Length == 0) return true;

            foreach (int i in killNears)
            {
                if (i < 11)
                {
                    if ((Array.IndexOf<int>(lottery, i) != -1) || (Array.IndexOf<int>(lottery, i + 1) != -1))
                    {
                        return false;
                    }
                }
                else
                {
                    if ((Array.IndexOf<int>(lottery, 11) != -1) || (Array.IndexOf<int>(lottery, 1) != -1))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
        #endregion

        #region 隔位合

        public int[] GetGeWeiHe()
        {
            string sum1 = (lottery[0] + lottery[2]).ToString();
            string sum2 = (lottery[1] + lottery[3]).ToString();
            string sum3 = (lottery[2] + lottery[4]).ToString();

            int tailSum1 = int.Parse(sum1.ToString().Substring(sum1.Length - 1, 1));
            int tailSum2 = int.Parse(sum2.ToString().Substring(sum2.Length - 1, 1));
            int tailSum3 = int.Parse(sum3.ToString().Substring(sum3.Length - 1, 1));

            int[] gwh = new int[] { tailSum1, tailSum2, tailSum3 };

            return gwh;
        }

        public bool MeetSkipBitSum(List<int[]> SkipBitSums, int[] AppearCounts)
        {
            if (SkipBitSums.Count == 0 || AppearCounts.Length == 0)
            {
                return true;
            }

            string sum1 = (lottery[0] + lottery[2]).ToString();
            string sum2 = (lottery[1] + lottery[3]).ToString();
            string sum3 = (lottery[2] + lottery[4]).ToString();

            int tailSum1 = int.Parse(sum1.ToString().Substring(sum1.Length - 1, 1));
            int tailSum2 = int.Parse(sum2.ToString().Substring(sum2.Length - 1, 1));
            int tailSum3 = int.Parse(sum3.ToString().Substring(sum3.Length - 1, 1));

            int counts = 0;

            foreach (int[] ints in SkipBitSums)
            {
                if ((Array.IndexOf<int>(ints, tailSum1) != -1) || ((Array.IndexOf<int>(ints, tailSum2) != -1))
                    || (Array.IndexOf<int>(ints, tailSum3) != -1))
                {
                    counts++;
                }
            }

            if (Array.IndexOf<int>(AppearCounts, counts) != -1)
            {
                return true;
            }

            return false;
        }

        #endregion

        #region 隔位差

        public int[] GetGeWeiCha()
        {
            int dis1 = lottery[2] - lottery[0];
            int dis2 = lottery[3] - lottery[1];
            int dis3 = lottery[4] - lottery[2];

            int[] gwc = new int[] { dis1, dis2, dis3 };

            return gwc;
        }
        public bool MeetSkipBitDiss(List<int[]> SkipBitDiss, int[] AppearCounts)
        {
            if (SkipBitDiss.Count == 0 || AppearCounts.Length == 0)
            {
                return true;
            }

            int dis1 = lottery[2] - lottery[0];
            int dis2 = lottery[3] - lottery[1];
            int dis3 = lottery[4] - lottery[2];

            int counts = 0;

            foreach (int[] ints in SkipBitDiss)
            {
                if ((Array.IndexOf<int>(ints, dis1) != -1) || ((Array.IndexOf<int>(ints, dis2) != -1))
                    || (Array.IndexOf<int>(ints, dis3) != -1))
                {
                    counts++;
                }
            }

            if (Array.IndexOf<int>(AppearCounts, counts) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 隔位合 分序
        public bool MeetSkipBitSumFenxu(List<int[]> SkipBitSumFenxu, int[] AppearCounts)
        {
            if (SkipBitSumFenxu.Count == 0 || AppearCounts.Length == 0)
            {
                return true;
            }

            int[] sum = new int[]{
            (lottery[0] +lottery[2])%10,
            (lottery[1] +lottery[3])%10,
            (lottery[2] +lottery[4])%10,
            };

            Array.Sort(sum, 0, 3);

            Array.Sort(AppearCounts,0,AppearCounts.Length);

            int i = 0;
            int counts = 0;
            foreach (int[] ints in SkipBitSumFenxu)
            {
                if (Array.IndexOf<int>(ints, sum[i]) != -1)
                {
                    counts++;
                    if (counts == AppearCounts[0])
                    {
                        return true;
                    }
                }
                i++;
            }

            if (Array.IndexOf<int>(AppearCounts, counts) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        #region 隔位差 分序
        public bool MeetSkipBitDisFenxu(List<int[]> SkipBitDisFenxu, int[] AppearCounts)
        {
            if (SkipBitDisFenxu.Count == 0 || AppearCounts.Length == 0)
            {
                return true;
            }

            int[] dis = new int[]{
            Math.Abs(lottery[0] - lottery[2]),
            Math.Abs(lottery[1] - lottery[3]),
            Math.Abs(lottery[2] - lottery[4]),
            };

            Array.Sort(dis, 0, 3);

            Array.Sort(AppearCounts, 0, AppearCounts.Length);

            int i = 0;
            int counts = 0;
            foreach (int[] ints in SkipBitDisFenxu)
            {
                if (Array.IndexOf<int>(ints, dis[i]) != -1)
                {
                    counts++;
                    if (counts == AppearCounts[0])
                    {
                        return true;
                    }
                }
                i++;
            }

            if (Array.IndexOf<int>(AppearCounts, counts) != -1)
            {
                return true;
            }

            return false;
        }
        #endregion

        bool IEquatable<Lottery>.Equals(Lottery other)
        {
            return this.Equals((Lottery)other);
        }

        public override string ToString()
        {
            return new StringBuilder(lottery[0].ToString("D2")).Append(lottery[1].ToString("D2")).Append(lottery[2].ToString("D2")).Append(lottery[3].ToString("D2")).Append(lottery[4].ToString("D2")).ToString();
        }

        public override int GetHashCode()
        {
            int num = lottery[0] * 10000 + lottery[1] * 1000 + lottery[2] * 100 + lottery[3] * 10 + lottery[0];
            return (num ^ num << 16) * 0x15051505;
        }
    }
    #endregion

    class Algorithm11_5
    {
        public ReNoAndPassNo _ReNoAndPassNo { get; set; }

        #region 基础号码 与 非基础号码
        public int[] BaseNums { get; set; }
        public int[] NotBaseNums { get; set; }
        #endregion

        #region 集临个数 与 溃临个数

        public int[] MaxLinkNum { get; set; }
        public int[] NotMaxLinkNum { get; set; }
        #endregion

        public List<Lottery> Lotterys { get; private set; }
        public Algorithm11_5()
        {
            Lotterys = GetBaseLotterys();
        }
        #region 平衡指数
        public BalanceIndex _BalanceIndex { get; set; }
        #endregion

        #region 连号轨迹
        public LianHaoGuiJi _LianHaoGuiJi { get; set; }
        #endregion

        #region 前后比例
        public int[] SixLeft { get; set; }
        public int[] SixRight { get; set; }
        #endregion


        #region 胆码列表
        public List<BileCode> BileCodes { get; set; }
        #endregion

        // -
        #region 两码差列表
        public List<TwoNumDis> TwoNumDiss { get; set; }
        #endregion

        // -
        #region 差临值
        public int[] TwoNumDissCounts { get; set; }
        #endregion

        #region 综合属性
        public SynthesizedAttribute _SynthesizedAttribute { get; set; }
        #endregion

        #region 龙头凤尾
        public FaucetAndPteris _FaucetAndPterisPrimer { get; set; }// 是否质数

        public FaucetAndPteris _FaucetAndPterisEven { get; set; } //是否双数
        #endregion

        #region 龙头凤尾 0，1，2路
        public int[] Faucet012 { get; set; }
        public int[] Pteris012 { get; set; }

        public int[] FPAppears { get; set; }
        #endregion

        #region 临群码
        public int[] LinkCounts { get; set; }
        #endregion

        #region 和值
        public int[] SumOfLotterys { get; set; }
        #endregion

        #region 合值
        public int[] SmallBitValue { get; set; }
        #endregion

        #region 跨度
        public int[] Spans { get; set; }
        #endregion

        #region 临码和
        public int[] MaxMinusSmallMinus4s { get; set; }
        #endregion

        #region 最大临码距离
        public int[] MaxNearestNumDiss { get; set; }
        #endregion

        #region 反边球距离
        public int[] SmallerBigerLengths { get; set; }
        #endregion

        #region 边临和
        public int[] SmallBiggerLenAddMaxNearestDiss { get; set; }
        #endregion

        // -
        #region 跨码
        public SkipNum _SkipNum { get; set; }
        #endregion

        // -
        #region 邻码间距
        public NearSkipCount _NearSkipCount { get; set; }
        #endregion

        #region 首尾邻码最大间距
        public int[] HeadTailMaxSkip { get; set; }
        #endregion

        // -
        #region 定位组选
        public LocateIndexNum _LocateIndexNum { get; set; }
        #endregion

        // -
        #region 两码和
        public List<TwoNumPlus> _TwoNumPluss { get; set; }
        public int[] TwoNumAppears { get; set; }
        #endregion

        // -
        #region 两码组合
        public List<TwoNum> twoNums { get; set; }
        //public bool twoNumsState { get; set; }
        #endregion

        // -
        #region 智能数据
        public AIData aiData { get; set; }
        #endregion

        // -
        #region 012路
        public CountsOf012 countsOf012 { get; set; }
        #endregion

        // -
        #region 012路比例
        public List<Rate012> rate012s { get; set; }
        public int[] Rate012AppearCount { get; set; }
        #endregion

        // -
        #region 断临
        public int[] killNears { get; set; }
        #endregion

        // -
        #region 隔位合
        public List<int[]> SkipBitSum { get; set; }
        public int[] SkipBitCounts { get; set; }
        #endregion

        // -
        #region 隔位差
        public List<int[]> SkipBitDis { get; set; }
        public int[] SkipBitDisCounts { get; set; }
        #endregion

        #region 隔位合分序
        public List<int[]> SkipBitSumFenxu { get; set; }
        public int[] SkipBitSumFenxuCounts { get; set; }
        #endregion

        #region 隔位差分序
        public List<int[]> SkipBitDisFenxu { get; set; }
        public int[] SkipBitDisFenxuCounts { get; set; }
        #endregion
        //
        #region 智能值
        public AIValues _AIValues { get; set; }
        #endregion

        //
        #region 智能平衡
        public AIBalance _AIBalance { get; set; }
        #endregion
        public void ReGetBaseLotterys()
        {
            Lotterys = GetBaseLotterys();
        }

        #region 生成所有基础号码
        public static List<Lottery> GetBaseLotterys()
        {
            List<Lottery> lotterys = new List<Lottery>();
            for (int i = 1; i <= 7; i++)
            {
                for (int ii = 2; ii <= 8; ii++)
                {
                    if (ii > i)
                    {
                        for (int iii = 3; iii <= 9; iii++)
                        {
                            if (iii > ii)
                            {
                                for (int iv = 4; iv <= 10; iv++)
                                {
                                    if (iv > iii)
                                    {
                                        for (int v = 5; v <= 11; v++)
                                        {
                                            if (v > iv)
                                            {
                                                lotterys.Add(new Lottery(i, ii, iii, iv, v));
                                            }
                                        }
                                    }
                                }
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
            #region 删除 非基础号码
            Lotterys.RemoveAll(
                 delegate(Lottery lottery)
                 {
                     if (lottery.HasAnyNums(NotBaseNums))
                     {
                         return true;
                     }
                     return false;
                 });

            #endregion

            #region  重号与传码规则
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetReNoAndPassNo(_ReNoAndPassNo))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 胆码规则
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetBileCode(BileCodes))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 综合属性规则
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSynthesizedAttribute(_SynthesizedAttribute))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 前后比例规则
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSixLeftNum(SixLeft, SixRight))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 平衡指数
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetBalanceIndex(_BalanceIndex))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion


            #region  连号轨迹
            Lotterys.RemoveAll(
                           delegate(Lottery lottery)
                           {
                               if (!lottery.MeetLianHaoGuiJi(_LianHaoGuiJi))
                               {
                                   return true;
                               }
                               return false;
                           });
            #endregion


            #region 集临个数
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetLinkNum(MaxLinkNum, true))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 溃临个数
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetLinkNum(NotMaxLinkNum, false))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 龙头凤尾 是否质数
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetFaucetAndPterisPrimer(_FaucetAndPterisPrimer))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 龙头凤尾 是否双数
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetFaucetAndPterisEven(_FaucetAndPterisEven))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion


            /*
            #region 龙头 012 路
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.Meet012(Faucet012, true))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 凤尾 012 路
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.Meet012(Pteris012, false))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion
             */

            #region 龙头凤尾  012 路

            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.Meet012(Faucet012, Pteris012, FPAppears))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 临群码
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetLinkCounts(LinkCounts))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 和值
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSumOfLottery(SumOfLotterys))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 合值
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSmallBitValue(SmallBitValue))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 跨度
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSpan(Spans))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 临码和
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetMaxMinusSmallMinus(MaxMinusSmallMinus4s))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 两码差
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetTwoNumDis(TwoNumDiss))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 差临值
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetTwoNumDisCounts(TwoNumDissCounts))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region  反边球距离
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
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
                delegate(Lottery lottery)
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
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSmallBiggerLenAddMaxNearestDis(SmallBiggerLenAddMaxNearestDiss))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 跨码
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetSkipNums(_SkipNum))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 邻码间距
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetNearSkipCount(_NearSkipCount))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 首尾邻码最大间距
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetHeadTailMaxSkip(HeadTailMaxSkip))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 定位组选
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetLocateIndexNum(_LocateIndexNum))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码和
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetTwoNumPlus(_TwoNumPluss))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 两码组合 (出 杀)
            List<TwoNum> tnTemp = new List<TwoNum>();

            List<Lottery> temp = new List<Lottery>();

            // 杀
            if (this.twoNums.Count > 0)
            {
                foreach (TwoNum tn in this.twoNums)
                {
                    if (tn.State == true)
                    {
                        tnTemp.Add(tn);
                    }
                    else if (tn.State == false)
                    {
                        Lotterys.RemoveAll(delegate(Lottery lottery)
                        {
                            if (!lottery.MeetTwoNums(tn, false))
                            {
                                return true;
                            }
                            return false;
                        });
                    }
                }
            }

            foreach (Lottery lt in Lotterys)
            {
                temp.Add(lt);
            }


            // 出
            if (tnTemp.Count > 0)
            {
                foreach (TwoNum tn in tnTemp)
                {
                    Lotterys.RemoveAll(delegate(Lottery lottery)
                    {
                        if (lottery.MeetTwoNums(tn, true))
                        {
                            return true;
                        }
                        return false;
                    });
                }
                temp.RemoveAll(
                                    delegate(Lottery lt)
                                    {
                                        if (Lotterys.Contains(lt))
                                        {
                                            return true;
                                        }
                                        return false;
                                    });
                Lotterys.Clear();
                foreach (Lottery lt in temp)
                {
                    Lotterys.Add(lt);
                }
            }
           
            #endregion

            #region 智能数据
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetAIData(aiData))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 012路
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.Meet012(countsOf012))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            #region 012路比例
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetRate012(rate012s, Rate012AppearCount))
                    {
                        return true;
                    }
                    return false;
                });

            #endregion

            /*
            #region 临断
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetKillNears(killNears))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion
             */

            #region 隔位合
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetSkipBitSum(SkipBitSum, SkipBitCounts))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 隔位差
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetSkipBitDiss(SkipBitDis, SkipBitDisCounts))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 隔位合 分序
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetSkipBitSumFenxu(SkipBitSumFenxu, SkipBitSumFenxuCounts))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 隔位差 分序
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetSkipBitDisFenxu(SkipBitDisFenxu, SkipBitDisFenxuCounts))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 智能值
            Lotterys.RemoveAll(
                delegate(Lottery lottery) //
                {
                    if (!lottery.MeetAIValues(_AIValues))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion

            #region 智能平衡
            Lotterys.RemoveAll(
                delegate(Lottery lottery)
                {
                    if (!lottery.MeetAIBalance(_AIBalance))
                    {
                        return true;
                    }
                    return false;
                });
            #endregion
        }
    }
}
