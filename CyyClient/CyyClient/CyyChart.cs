using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyyClient
{
    class CyyChart
    {

        #region 综合走势图
        public static string GetHtmlZongHeZouShi(List<Lottery> lotterys, List<string> days)
        {
            string fdss = "";
            string pdss = "";
            string f012s = "";
            string p012s = "";
            string fbqjls = "";
            string zdlmkjs = "";
            string blhs = "";

            for (int i = 0; i < lotterys.Count; i++)
            {
                fdss += "fds" + i.ToString() + ",";
                pdss += "pds" + i.ToString() + ",";
                f012s += "f012" + i.ToString() + ",";
                p012s += "p012" + i.ToString() + ",";
                fbqjls += "fbqjl" + i.ToString() + ",";
                zdlmkjs += "zdlmkj" + i.ToString() + ",";
                blhs += "blh" + i.ToString() + ",";
            }

            fdss = fdss.Substring(0, fdss.Length - 1);
            pdss = pdss.Substring(0, pdss.Length - 1);
            f012s = f012s.Substring(0, f012s.Length - 1);
            p012s = p012s.Substring(0, p012s.Length - 1);
            fbqjls = fbqjls.Substring(0, fbqjls.Length - 1);
            zdlmkjs = zdlmkjs.Substring(0, zdlmkjs.Length - 1);
            blhs = blhs.Substring(0, blhs.Length - 1);

            string TOP = string.Format(
                @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>CYY2</title>
                    
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}
		
		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}
		
		                td{{
			                height: 32px;
		                }}
		
		                table{{
			                width: 1200px; 
			                text-align:center;
                            margin:auto;
		                }}
		
                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}                        

                        td.grayfont{{
					                        color:gray;
				                        }}
	                    .redballfont{{
		                    color:red;
	                    }}
	
                        td.equalwidth{{
				            width: 32px;
			            }}

                        .redball{{
		                    background-image: url(image/ball_red.png);
		                    background-repeat: no-repeat;
		                    color: white;
		                    font-weight: bold;
                            background-position:center center;
	                    }}
                        
                        .blueball{{
                            background-image: url(image/ball_bule.png);
		                    background-repeat: no-repeat;
		                    color: white;
		                    font-weight: bold;
                            background-position:center center;
                        }}   


                        .eredball{{
		                    background-image: url(image/qred.png);
		                    background-repeat: no-repeat;
		                    color: red;
		                    font-weight: bold;
                            background-position:center center;
	                    }}

                        .eblueball{{
                            background-image: url(image/qbule.png);
		                    background-repeat: no-repeat;
		                    color: blue;
		                    font-weight: bold;
                            background-position:center center;
                        }}                

		                .middledata{{
		                    background-color:rgb(249,242,223);
	                    }}
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">

                           function drawlines(){{
                            DrawLine_blue(""{0}"",""19"", ""4"");
				            DrawLine(""{1}"",""19"", ""4"");
				            DrawLine(""{2}"",""19"", ""4"");
				            DrawLine_blue(""{3}"",""19"", ""4"");
				            DrawLine(""{4}"",""19"", ""4"");
				            DrawLine_blue(""{5}"",""19"", ""4"");
				            DrawLine(""{6}"",""19"", ""4"");
                            }}
                        $(document).ready(function(){{
                            drawlines();
                        }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});


                    </script>

                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";

					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:8.5%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:12.5%"">开奖号码</td>
			                <td colspan=""2"">龙头</td>
			                <td colspan=""2"">凤尾</td>
			                <td colspan=""3"">龙头012</td>
			                <td colspan=""3"">凤尾012</td>
			                <td colspan=""7"">反边球距离</td>
			                <td colspan=""7"">最大临码跨距</td>
			                <td colspan=""5"">边临和</td>
			                <td colspan=""3"">智能平衡</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">单</td>
			                <td class=""equalwidth"">双</td>
			                <td class=""equalwidth"">单</td>
			                <td class=""equalwidth"">双</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">A</td>
			                <td class=""equalwidth"">B</td>
			                <td class=""equalwidth"">C</td>
		                </tr> 
                ", fdss, pdss, f012s, p012s, fbqjls, zdlmkjs, blhs);

            string html = TOP;

            int[] FacucetEven = new int[] { 0, 0 };  // index = 0 , 单； index = 1， 双
            int[] PterisEven = new int[] { 0, 0 };
            int[] Facucet012 = new int[] { 0, 0, 0 };
            int[] Pteris012 = new int[] { 0, 0, 0 };
            int[] FanBianQiuJuLi = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] ZuiDaLinMaKuaJu = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] BianLinHe = new int[] { 0, 0, 0, 0, 0 };
            //for (int i = lotterys.Count - 1; i >= 0; i--)
            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                #region 龙头凤尾单双
                FPState fp1 = lottery.GetFaucetStateEven();

                if (fp1.Equals(FPState.IsEven))
                {
                    FacucetEven[0]++;
                    FacucetEven[1] = 0;
                }
                else
                {
                    FacucetEven[1]++;
                    FacucetEven[0] = 0;
                }

                FPState fp5 = lottery.GetPterisStateEven();
                if (fp5.Equals(FPState.IsEven))
                {
                    PterisEven[0]++;
                    PterisEven[1] = 0;
                }
                else
                {
                    PterisEven[1]++;
                    PterisEven[0] = 0;
                }
                #endregion

                #region 龙头凤尾012路
                int f012 = lottery.GetFacucet012();
                int p012 = lottery.GetPteris012();

                for (int ii = 0; ii < Facucet012.Length; ii++)
                {
                    if (ii == f012)
                    {
                        Facucet012[ii] = 0;
                    }
                    else
                    {
                        Facucet012[ii]++;
                    }
                }

                for (int ii = 0; ii < Pteris012.Length; ii++)
                {
                    if (ii == p012)
                    {
                        Pteris012[ii] = 0;
                    }
                    else
                    {
                        Pteris012[ii]++;
                    }
                }
                #endregion

                #region 反边球距离
                int fbqjl = lottery.GetSmallerBiggerLength();

                for (int ii = 0; ii < FanBianQiuJuLi.Length; ii++)
                {
                    if (ii == fbqjl)
                    {
                        FanBianQiuJuLi[ii] = 0;
                    }
                    else
                    {
                        FanBianQiuJuLi[ii]++;
                    }
                }
                #endregion

                #region 最大临码跨距
                int zdlmkj = lottery.GetMaxNearestNumDis();

                int zdlmkjIndex = zdlmkj - 1;

                for (int ii = 0; ii < ZuiDaLinMaKuaJu.Length; ii++)
                {
                    if (ii == zdlmkjIndex)
                    {
                        ZuiDaLinMaKuaJu[ii] = 0;
                    }
                    else
                    {
                        ZuiDaLinMaKuaJu[ii]++;
                    }
                }


                #endregion

                #region 边临和
                int blh = lottery.GetBianLinHe();
                int blhIndex = blh - 3;
                for (int ii = 0; ii < BianLinHe.Length; ii++)
                {
                    if (ii == blhIndex)
                    {
                        BianLinHe[ii] = 0;
                    }
                    else
                    {
                        BianLinHe[ii]++;
                    }
                }
                #endregion

                #region 智能平衡A
                BalanceState bsA = lottery.GetAIBalanceA();
                BalanceState bsB = lottery.GetAIBalanceB();
                BalanceState bsC = lottery.GetAIBalanceC();

                #endregion

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
			            <td class=""middledata redballfont equalwidth"">{4}</td>
			            <td class=""middledata redballfont equalwidth"">{5}</td>
			            <td {38}>{6}</td>
			            <td {39}>{7}</td>
			            <td {40}>{8}</td>
			            <td {41}>{9}</td>
			            <td {42}>{10}</td>
			            <td {43}>{11}</td>
			            <td {44}>{12}</td>
			            <td {45}>{13}</td>
			            <td {46}>{14}</td>
			            <td {47}>{15}</td>
			            <td {48}>{16}</td>
			            <td {49}>{17}</td>
			            <td {50}>{18}</td>
			            <td {51}>{19}</td>
			            <td {52}>{20}</td>
			            <td {53}>{21}</td>
			            <td {54}>{22}</td>
			            <td {55}>{23}</td>
			            <td {56}>{24}</td>
			            <td {57}>{25}</td>
			            <td {58}>{26}</td>
			            <td {59}>{27}</td>
			            <td {60}>{28}</td>
			            <td {61}>{29}</td>
			            <td {62}>{30}</td>
			            <td {63}>{31}</td>
			            <td {64}>{32}</td>
			            <td {65}>{33}</td>
			            <td {66}>{34}</td>
			            <td class=""middledata"">{35}</td>
			            <td class=""middledata"">{36}</td>
			            <td class=""middledata"">{37}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"), // 0 - 6
                     fp1.Equals(FPState.IsSingular) ? "单" : FacucetEven[0].ToString(),  //6
                     fp1.Equals(FPState.IsEven) ? "双" : FacucetEven[1].ToString(),  //7
                     fp5.Equals(FPState.IsSingular) ? "单" : PterisEven[0].ToString(), //8
                     fp5.Equals(FPState.IsEven) ? "双" : PterisEven[1].ToString(), //9
                     f012 == 0 ? "0" : Facucet012[0].ToString(), //10
                     f012 == 1 ? "1" : Facucet012[1].ToString(), //11
                     f012 == 2 ? "2" : Facucet012[2].ToString(),// 12
                     p012 == 0 ? "0" : Pteris012[0].ToString(), //13
                     p012 == 1 ? "1" : Pteris012[1].ToString(), //14
                     p012 == 2 ? "2" : Pteris012[2].ToString(),// 15
                     fbqjl == 0 ? "0" : FanBianQiuJuLi[0].ToString(), //16
                     fbqjl == 1 ? "1" : FanBianQiuJuLi[1].ToString(), //17
                     fbqjl == 2 ? "2" : FanBianQiuJuLi[2].ToString(), //18
                     fbqjl == 3 ? "3" : FanBianQiuJuLi[3].ToString(), //19
                     fbqjl == 4 ? "4" : FanBianQiuJuLi[4].ToString(), //20
                     fbqjl == 5 ? "5" : FanBianQiuJuLi[5].ToString(), //21
                     fbqjl == 6 ? "6" : FanBianQiuJuLi[6].ToString(),//22
                    zdlmkjIndex == 0 ? "1" : ZuiDaLinMaKuaJu[0].ToString(),//23
                    zdlmkjIndex == 1 ? "2" : ZuiDaLinMaKuaJu[1].ToString(),//24
                    zdlmkjIndex == 2 ? "3" : ZuiDaLinMaKuaJu[2].ToString(),//25
                    zdlmkjIndex == 3 ? "4" : ZuiDaLinMaKuaJu[3].ToString(),//26
                    zdlmkjIndex == 4 ? "5" : ZuiDaLinMaKuaJu[4].ToString(),//27
                    zdlmkjIndex == 5 ? "6" : ZuiDaLinMaKuaJu[5].ToString(),//28
                    zdlmkjIndex == 6 ? "7" : ZuiDaLinMaKuaJu[6].ToString(),//29
                blhIndex == 0 ? "3" : BianLinHe[0].ToString(),//30
                blhIndex == 1 ? "4" : BianLinHe[1].ToString(),//31
                blhIndex == 2 ? "5" : BianLinHe[2].ToString(),//32
                blhIndex == 3 ? "6" : BianLinHe[3].ToString(),//33
                blhIndex == 4 ? "7" : BianLinHe[4].ToString(),//34
                bsA.Equals(BalanceState.LeftMore) ? "+" : (bsA.Equals(BalanceState.RightMore) ? "-" : "="), //35
                bsB.Equals(BalanceState.LeftMore) ? "+" : (bsB.Equals(BalanceState.RightMore) ? "-" : "="), //36
                bsC.Equals(BalanceState.LeftMore) ? "+" : (bsC.Equals(BalanceState.RightMore) ? "-" : "="), //37
                fp1.Equals(FPState.IsSingular) ? @"class=""blueball"" id=""fds" + i.ToString() + @"""" : @"class=""grayfont""", //38
                fp1.Equals(FPState.IsEven) ? @"class=""blueball"" id=""fds" + i.ToString() + @"""" : @"class=""grayfont""",  //39
                fp5.Equals(FPState.IsSingular) ? @"class=""middledata eredball"" id=""pds" + i.ToString() + @"""" : @"class=""middledata grayfont""", //40
                fp5.Equals(FPState.IsEven) ? @"class=""middledata eredball"" id=""pds" + i.ToString() + @"""" : @"class=""middledata grayfont""", //41
                f012 == 0 ? @"class=""redball"" id=""f012" + i.ToString() + @"""" : @"class=""grayfont""", //42
                f012 == 1 ? @"class=""redball"" id=""f012" + i.ToString() + @"""" : @"class=""grayfont""",  //43
                f012 == 2 ? @"class=""redball"" id=""f012" + i.ToString() + @"""" : @"class=""grayfont""",// 44
                p012 == 0 ? @"class=""middledata blueball"" id=""p012" + i.ToString() + @"""" : @"class=""middledata grayfont""", //45
                p012 == 1 ? @"class=""middledata blueball"" id=""p012" + i.ToString() + @"""" : @"class=""middledata grayfont""",  //46
                p012 == 2 ? @"class=""middledata blueball"" id=""p012" + i.ToString() + @"""" : @"class=""middledata grayfont""",// 47
                fbqjl == 0 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""", //48
                fbqjl == 1 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""",//49
                fbqjl == 2 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""",//50
                fbqjl == 3 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""", //51
                fbqjl == 4 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""", //52
                fbqjl == 5 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""",//53
                fbqjl == 6 ? @"class=""redball"" id=""fbqjl" + i.ToString() + @"""" : @"class=""grayfont""",//54
                zdlmkjIndex == 0 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""", //55
                zdlmkjIndex == 1 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""", //56
                zdlmkjIndex == 2 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""", //57
                zdlmkjIndex == 3 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""",  //58
                zdlmkjIndex == 4 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata  grayfont""", //59
                zdlmkjIndex == 5 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""", //60
                zdlmkjIndex == 6 ? @"class=""middledata blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""middledata grayfont""", //61
                 blhIndex == 0 ? @"class=""redball"" id=""blh" + i.ToString() + @"""" : @"class=""grayfont""",
                 blhIndex == 1 ? @"class=""redball"" id=""blh" + i.ToString() + @"""" : @"class=""grayfont""",
                 blhIndex == 2 ? @"class=""redball"" id=""blh" + i.ToString() + @"""" : @"class=""grayfont""",
                 blhIndex == 3 ? @"class=""redball"" id=""blh" + i.ToString() + @"""" : @"class=""grayfont""",
                 blhIndex == 4 ? @"class=""redball"" id=""blh" + i.ToString() + @"""" : @"class=""grayfont""");
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""6""><input type=""button"" value=""提交选择"" /></td>
			                <td class=""unclk"">单</td>
			                <td class=""unclk"">双</td>
			                <td class=""unclk"">单</td>
			                <td class=""unclk"">双</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">7</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">7</td>
			                <td class=""unclk"">A</td>
			                <td class=""unclk"">B</td>
			                <td class=""unclk"">C</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""2"">龙头</td>
			                <td colspan=""2"">凤尾</td>
			                <td colspan=""3"">龙头012路</td>
			                <td colspan=""3"">凤尾012路</td>
			                <td colspan=""7"">反边球距离</td>
			                <td colspan=""7"">最大临码跨距</td>
			                <td colspan=""5"">边临和</td>
			                <td colspan=""3"">智能平衡</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 基本走势图
        public static string GetHtmlJiBenZouShi(List<Lottery> lotterys, List<string> days)
        {
            #region top
            const string TOP =
            @"<!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
            <html lang=""en"">
            <head>
	            <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	            <style type=""text/css"">
	            .headfoot{
		            background-color:rgb(245,234,190);
		            font:normal 20px arial,sans-serif;
	            }
	
	            table, tr, td{ 
		            border-collapse: collapse;
		            border:1px solid black;
	            }
	
	            td{
		            height: 32px;
	            }
	
	            .middledata{
		            background-color:rgb(249,242,223);
	            }
	            .redballfont{
		            color:red;
	            }
                        .clk{
					        background-color:red;
				        }
				
				        .unclk{
					
				        }

 td.grayfont{
					                        color:gray;
				                        }
	
                .noneball{
                    background-image: url(image/ball_black.png);
		            background-repeat: no-repeat;
		            color: white;
		            font-weight: bold;
                    background-position:center center;
                }                

                td.equalwidth{
				    width: 32px;
			    }  

                        
	            .redball{
		            background-image: url(image/ball_red.png);
		            background-repeat: no-repeat;
		            color: white;
		            font-weight: bold;
                    background-position:center center;
	            }
	            </style>
	            <script type=""text/javascript"" src=""jq142.js""></script>
	            <script type=""text/javascript"" src=""drawline.js""></script>
                <script type=""text/javascript"">
					$(document).ready(function()
					{
            document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{
							if ($(this).hasClass(""clk""))
							{
								$(this).removeClass(""clk"");
                                    document.title =""clk"";
							}
							else if ($(""td.clk"").length < 5)
							{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}				
						});
					});
				</script>

	            <title>CyyChart</title>
            </head>
            <body>
	            <table style=""width: 1020px; text-align:center; margin:auto;"">
		            <tr class=""headfoot"">
			            <td rowspan=""2"" style = ""width:10%"">期号</td>
			            <td rowspan=""2"" colspan=""5"" style=""width:15%"">开奖号码</td>
			            <td colspan=""11"" style=""width:30%"">开奖号码走势图</td>
			            <td rowspan=""2"">落码(个)</td>
			            <td rowspan=""2"">连号(个)</td>
			            <td rowspan=""2"">前后比例</td>
			            <td rowspan=""2"">大小比例</td>
			            <td rowspan=""2"">奇偶比例</td>
			            <td rowspan=""2"">平衡指数</td>
			            <td rowspan=""2"">连号轨迹</td>
		            </tr>
		
		            <tr class=""headfoot"">
			            <td class=""equalwidth"">01</td>
			            <td class=""equalwidth"">02</td>
			            <td class=""equalwidth"">03</td>
			            <td class=""equalwidth"">04</td>
			            <td class=""equalwidth"">05</td>
			            <td class=""equalwidth"">06</td>
			            <td class=""equalwidth"">07</td>
			            <td class=""equalwidth"">08</td>
			            <td class=""equalwidth"">09</td>
			            <td class=""equalwidth"">10</td>
			            <td class=""equalwidth"">11</td>
		    </tr>";
            #endregion

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            //for (int i = lotterys.Count-1; i  >= 0; i--)
            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                for (int ii = 1; ii <= 11; ii++)
                {

                    if (Array.IndexOf<int>(lottery.GetArray(), ii) == -1)
                    {
                        preExistCount[ii - 1]++;
                        lotteryNumExit[ii - 1] = false;
                    }
                    else
                    {
                        preExistCount[ii - 1] = 0;
                        lotteryNumExit[ii - 1] = true;
                    }
                }

                int LinkTrail = lottery.GetLinkTrail();


                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
			            <td class=""middledata redballfont equalwidth"">{4}</td>
			            <td class=""middledata redballfont equalwidth"">{5}</td>
			            <td {24}>{6}</td>
			            <td {25}>{7}</td>
			            <td {26}>{8}</td>
			            <td {27}>{9}</td>
			            <td {28}>{10}</td>
			            <td {29}>{11}</td>
			            <td {30}>{12}</td>
			            <td {31}>{13}</td>
			            <td {32}>{14}</td>
			            <td {33}>{15}</td>
			            <td {34}>{16}</td>
			            <td class=""middledata"">{17}</td>
			            <td>{18}</td>
			            <td class=""middledata"">{19}</td>
			            <td>{20}</td>
			            <td class=""middledata"">{21}</td>
			            <td>{22}</td>
			            <td class=""middledata"">{23}</td>
		                </tr>
                           ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"), // 0 - 5
                          lotteryNumExit[0] ? "01" : preExistCount[0].ToString(),  //6
                          lotteryNumExit[1] ? "02" : preExistCount[1].ToString(),  //7
                          lotteryNumExit[2] ? "03" : preExistCount[2].ToString(),  //8
                          lotteryNumExit[3] ? "04" : preExistCount[3].ToString(),  //9
                          lotteryNumExit[4] ? "05" : preExistCount[4].ToString(),  //10
                          lotteryNumExit[5] ? "06" : preExistCount[5].ToString(),  //11
                          lotteryNumExit[6] ? "07" : preExistCount[6].ToString(),   //12
                          lotteryNumExit[7] ? "08" : preExistCount[7].ToString(),   //13
                          lotteryNumExit[8] ? "09" : preExistCount[8].ToString(),  //14
                          lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), // 15
                          lotteryNumExit[10] ? "11" : preExistCount[10].ToString(), //16
                          i == 0 ? "0" : lottery.SameNumberCount(lotterys[i - 1].GetArray()).ToString(), //17
                          lottery.LinkedCount.ToString(),   //18
                          lottery.sixLeft.Length.ToString() + ":" + lottery.sixRight.Length.ToString(),//19
                          (5 - lottery.SmallCount).ToString() + ":" + lottery.SmallCount.ToString(), //20
                          (5 - lottery.EvenCount).ToString() + ":" + lottery.EvenCount.ToString(),//21
                          lottery._BalanceState == BalanceState.LeftMore ? "+" : (lottery._BalanceState == BalanceState.RightMore ? "-" : "="),  //22
                          LinkTrail > 0 ? "+" : (LinkTrail == 0 ? "=" : "-"), //23
                          lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", //24
                          lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""", //25
                          lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""", //26
                          lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""", //27
                          lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""", //28
                          lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""", //29
                          lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""", //30
                          lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""", //31
                          lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""", //32
                          lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //33
                          lotteryNumExit[10] ? @"class=""redball""" : @"class=""grayfont"""  //34
                          );
            }
            html +=
                   string.Format(
                    @"
		            <tr class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">
				            <input type=""button"" value=""提交选择"" />
			            </td>
			            <td class=""unclk"">01</td>
			            <td class=""unclk"">02</td>
			            <td class=""unclk"">03</td>
			            <td class=""unclk"">04</td>
			            <td class=""unclk"">05</td>
			            <td class=""unclk"">06</td>
			            <td class=""unclk"">07</td>
			            <td class=""unclk"">08</td>
			            <td class=""unclk"">09</td>
			            <td class=""unclk"">10</td>
			            <td class=""unclk"">11</td>
			            <td rowspan=""2"">落码(个)</td>
			            <td rowspan=""2"">连号(个)</td>
			            <td rowspan=""2"">前后比例</td>
			            <td rowspan=""2"">大小比例</td>
			            <td rowspan=""2"">奇偶比例</td>
			            <td rowspan=""2"">平衡指数</td>
			            <td rowspan=""2"">连号轨迹</td>
		            </tr>
		            <tr class=""headfoot"">
			            <td colspan=""11"">开奖号码走势图</td>
		            </tr>
	            </table>
            </body>
            </html>
            ");

            return html;
        }
        #endregion

        #region 定位走势图
        public static string GetHtmlDingWeiZouShi(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";
            string d2 = "";
            string d3 = "";
            string d4 = "";
            string d5 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
                d4 += "d4" + i.ToString() + ",";
                d5 += "d5" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);
            d4 = d4.Substring(0, d4.Length - 1);
            d5 = d5.Substring(0, d5.Length - 1);

            #region top
            string Top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>定位走势图</title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

		                table{{
			                width: 1600px; 
			                text-align:center;
                            margin:auto;
		                }}
 td.grayfont{{
	color:gray;
}}
	
		                .redballfont{{
			                color:red;
		                }}

                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      

		                td.equalwidth{{
			                width: 32px;
		                }}

		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   


		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">
                           function drawlines(){{
                            DrawLine_blue(""{0}"",""19"", ""4"");
				            DrawLine(""{1}"",""19"", ""4"");
				            DrawLine_blue(""{2}"",""19"", ""4"");
				            DrawLine(""{3}"",""19"", ""4"");
				            DrawLine_blue(""{4}"",""19"", ""4"");
                            }}
                        $(document).ready(function(){{
                            drawlines();
                        }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                    </script>

<script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                 document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                    document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:7%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:10%"">开奖号码</td>
			                <td colspan=""11"">开奖号码分布图</td>
			                <td colspan=""7"">第一位</td>
			                <td colspan=""7"">第二位</td>
			                <td colspan=""7"">第三位</td>
			                <td colspan=""7"">第四位</td>
			                <td colspan=""7"">第五位</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">01</td>
			                <td class=""equalwidth"">02</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
			                <td class=""equalwidth"">01</td>
			                <td class=""equalwidth"">02</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">02</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
		                </tr>
            ", d1, d2, d3, d4, d5);
            #endregion

            string html = Top;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };


            int[] num1 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] num2 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] num3 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] num4 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] num5 = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            //for (int i = lotterys.Count - 1; i >= 0; i--)
            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                for (int ii = 1; ii <= 11; ii++)
                {

                    if (Array.IndexOf<int>(lottery.GetArray(), ii) == -1)
                    {
                        preExistCount[ii - 1]++;
                        lotteryNumExit[ii - 1] = false;
                    }
                    else
                    {
                        preExistCount[ii - 1] = 0;
                        lotteryNumExit[ii - 1] = true;
                    }
                }


                int[] lotteryArr = lottery.GetArray();

                #region num1
                for (int ii = 1; ii <= 7; ii++)
                {
                    if (ii != lotteryArr[0])
                    {
                        num1[ii - 1]++;
                    }
                    else
                    {
                        num1[ii - 1] = 0;
                    }
                }
                #endregion

                #region num2
                for (int ii = 2; ii <= 8; ii++)
                {
                    if (ii != lotteryArr[1])
                    {
                        num2[ii - 2]++;
                    }
                    else
                    {
                        num2[ii - 2] = 0;
                    }
                }
                #endregion

                #region num3
                for (int ii = 3; ii <= 9; ii++)
                {
                    if (ii != lotteryArr[2])
                    {
                        num3[ii - 3]++;
                    }
                    else
                    {
                        num3[ii - 3] = 0;
                    }
                }
                #endregion

                #region num4
                for (int ii = 4; ii <= 10; ii++)
                {
                    if (ii != lotteryArr[3])
                    {
                        num4[ii - 4]++;
                    }
                    else
                    {
                        num4[ii - 4] = 0;
                    }
                }
                #endregion

                #region num5
                for (int ii = 5; ii <= 11; ii++)
                {
                    if (ii != lotteryArr[4])
                    {
                        num5[ii - 5]++;
                    }
                    else
                    {
                        num5[ii - 5] = 0;
                    }
                }
                #endregion

                html += string.Format(@"
                    <tr>
			        <td>{0}</td>
			        <td class=""middledata redballfont equalwidth"">{1}</td>
			        <td class=""middledata redballfont equalwidth"">{2}</td>
			        <td class=""middledata redballfont equalwidth"">{3}</td>
			        <td class=""middledata redballfont equalwidth"">{4}</td>
			        <td class=""middledata redballfont equalwidth"">{5}</td>
			        <td {52}>{6}</td>
			        <td {53}>{7}</td>
			        <td {54}>{8}</td>
			        <td {55}>{9}</td>
			        <td {56}>{10}</td>
			        <td {57}>{11}</td>
			        <td {58}>{12}</td>
			        <td {59}>{13}</td>
			        <td {60}>{14}</td>
			        <td {61}>{15}</td>
			        <td {62}>{16}</td>
			        <td {63}>{17}</td>
			        <td {64}>{18}</td>
			        <td {65}>{19}</td>
			        <td {66}>{20}</td>
			        <td {67}>{21}</td>
			        <td {68}>{22}</td>
			        <td {69}>{23}</td>
			        <td {70}>{24}</td>
			        <td {71}>{25}</td>
			        <td {72}>{26}</td>
			        <td {73}>{27}</td>
			        <td {74}>{28}</td>
			        <td {75}>{29}</td>
			        <td {76}>{30}</td>
			        <td {77}>{31}</td>
			        <td {78}>{32}</td>
			        <td {79}>{33}</td>
			        <td {80}>{34}</td>
			        <td {81}>{35}</td>
			        <td {82}>{36}</td>
			        <td {83}>{37}</td>
			        <td {84}>{38}</td>
			        <td {85}>{39}</td>
			        <td {86}>{40}</td>
			        <td {87}>{41}</td>
			        <td {88}>{42}</td>
			        <td {89}>{43}</td>
			        <td {90}>{44}</td>
			        <td {91}>{45}</td>
			        <td {92}>{46}</td>
			        <td {93}>{47}</td>
			        <td {94}>{48}</td>
			        <td {95}>{49}</td>
			        <td {96}>{50}</td>
			        <td {97}>{51}</td>
                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                    lotteryNumExit[0] ? "01" : preExistCount[0].ToString(),  //6
                    lotteryNumExit[1] ? "02" : preExistCount[1].ToString(),  //7
                    lotteryNumExit[2] ? "03" : preExistCount[2].ToString(),  //8
                    lotteryNumExit[3] ? "04" : preExistCount[3].ToString(),  //9
                    lotteryNumExit[4] ? "05" : preExistCount[4].ToString(),  //10
                    lotteryNumExit[5] ? "06" : preExistCount[5].ToString(),  //11
                    lotteryNumExit[6] ? "07" : preExistCount[6].ToString(),   //12
                    lotteryNumExit[7] ? "08" : preExistCount[7].ToString(),   //13
                    lotteryNumExit[8] ? "09" : preExistCount[8].ToString(),  //14
                    lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), // 15
                    lotteryNumExit[10] ? "11" : preExistCount[10].ToString(), //16

                    lottery[0] == 1 ? "1" : num1[0].ToString(),//17
                    lottery[0] == 2 ? "2" : num1[1].ToString(),//18
                    lottery[0] == 3 ? "3" : num1[2].ToString(),//19
                    lottery[0] == 4 ? "4" : num1[3].ToString(),//20
                    lottery[0] == 5 ? "5" : num1[4].ToString(),//21
                    lottery[0] == 6 ? "6" : num1[5].ToString(),//22
                    lottery[0] == 7 ? "7" : num1[6].ToString(),//23

                    lottery[1] == 2 ? "2" : num2[0].ToString(),//24
                    lottery[1] == 3 ? "3" : num2[1].ToString(),//25
                    lottery[1] == 4 ? "4" : num2[2].ToString(),//26
                    lottery[1] == 5 ? "5" : num2[3].ToString(),//27
                    lottery[1] == 6 ? "6" : num2[4].ToString(),//28
                    lottery[1] == 7 ? "7" : num2[5].ToString(),//29
                    lottery[1] == 8 ? "8" : num2[6].ToString(),//30

                    lottery[2] == 3 ? "3" : num3[0].ToString(),//31
                    lottery[2] == 4 ? "4" : num3[1].ToString(),//32
                    lottery[2] == 5 ? "5" : num3[2].ToString(),//33
                    lottery[2] == 6 ? "6" : num3[3].ToString(),//34
                    lottery[2] == 7 ? "7" : num3[4].ToString(),//35
                    lottery[2] == 8 ? "8" : num3[5].ToString(),//36
                    lottery[2] == 9 ? "9" : num3[6].ToString(),//37

                    lottery[3] == 4 ? "4" : num4[0].ToString(),//38
                    lottery[3] == 5 ? "5" : num4[1].ToString(),//39
                    lottery[3] == 6 ? "6" : num4[2].ToString(),//40
                    lottery[3] == 7 ? "7" : num4[3].ToString(),//41
                    lottery[3] == 8 ? "8" : num4[4].ToString(),//42
                    lottery[3] == 9 ? "9" : num4[5].ToString(),//43
                    lottery[3] == 10 ? "10" : num4[6].ToString(),//44

                    lottery[4] == 5 ? "5" : num5[0].ToString(),//45
                    lottery[4] == 6 ? "6" : num5[1].ToString(),//46
                    lottery[4] == 7 ? "7" : num5[2].ToString(),//47
                    lottery[4] == 8 ? "8" : num5[3].ToString(),//48
                    lottery[4] == 9 ? "9" : num5[4].ToString(),//49
                    lottery[4] == 10 ? "10" : num5[5].ToString(),//50
                    lottery[4] == 11 ? "11" : num5[6].ToString(),//51

                    lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[10] ? @"class=""redball""" : @"class=""grayfont""", // 52- 62

                    lottery[0] == 1 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 5 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 6 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 7 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",//63-69

                    lottery[1] == 2 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 3 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 4 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 5 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 6 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 7 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 8 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""", // 70-76

                    lottery[2] == 3 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 4 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 5 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 6 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 7 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 8 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 9 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", //77-83

                    lottery[3] == 4 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 5 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 6 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 7 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 8 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 9 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[3] == 10 ? @"class=""redball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",//84-90

                    lottery[4] == 5 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 6 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 7 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 8 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 9 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 10 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    lottery[4] == 11 ? @"class=""blueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata"""//91-97
                 );
            }

            html += @"
                    <tr  class=""headfoot"">
			        <td rowspan=""2"" colspan=""6"">提交选择</td>
			        <td class=""unclk"">01</td>
			        <td class=""unclk"">02</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">11</td>
			        <td class=""unclk"">01</td>
			        <td class=""unclk"">02</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">02</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">11</td>
		        </tr>
		        <tr  class=""headfoot"">
			        <td colspan=""11"">开奖号码分布图</td>
			        <td colspan=""7"">第一位</td>
			        <td colspan=""7"">第二位</td>
			        <td colspan=""7"">第三位</td>
			        <td colspan=""7"">第四位</td>
			        <td colspan=""7"">第五位</td>
		        </tr>
	        </table>
        </body>
        </html>
        ";

            return html;
        }

        #endregion

        #region 两码和差
        public static string GetHtmlLiangMaHeCha(List<Lottery> lotterys, List<string> days)
        {
            #region TOP
            const string TOP = @"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title></title>
	                <style type=""text/css"">
		                .headfoot{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }

		                table, tr, td{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }

		                td{
			                height: 32px;
		                }

		                table{
			                width: 1200px; 
			                text-align:center;
                            margin:auto;
		                }

		                .redballfont{
			                color:red;
		                }

		                td.equalwidth{
			                width: 32px;
		                }

		                .redball{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }
		
		                .blueball{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }   

                        .clk{
					        background-color:red;
				        }
				
				        .unclk{
					
				        }   
                     td.grayfont{
	                    color:gray;
                    }

		                .eredball{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }

		                .eblueball{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }                

		                .middledata{
			                background-color:rgb(249,242,223);
		                }
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{
							if ($(this).hasClass(""clk""))
							{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}
							else 
							{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}				
						});
					});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:8.5%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:12.5%"">开奖号码</td>
			                <td colspan=""19"">两码和走势图</td>
			                <td colspan=""10"">两码差走势图</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">8</td>
			                <td class=""equalwidth"">9</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
			                <td class=""equalwidth"">12</td>
			                <td class=""equalwidth"">13</td>
			                <td class=""equalwidth"">14</td>
			                <td class=""equalwidth"">15</td>
			                <td class=""equalwidth"">16</td>
			                <td class=""equalwidth"">17</td>
			                <td class=""equalwidth"">18</td>
			                <td class=""equalwidth"">19</td>
			                <td class=""equalwidth"">20</td>
			                <td class=""equalwidth"">21</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">8</td>
			                <td class=""equalwidth"">9</td>
			                <td class=""equalwidth"">10</td>
		                </tr>
            ";

            #endregion

            string html = TOP;


            int[] twoAdds = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            int[] twoDiss = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                List<int> twoNumAdds = lottery.twoNumPluss;
                List<int> twoNumdiss = lottery.twoNumDiss;


                for (int ii = 0; ii < twoAdds.Length; ii++)
                {
                    // if (twoAdds[ii] != 0)
                    // {
                    twoAdds[ii]++;
                    //}
                }


                for (int ii = 0; ii < twoDiss.Length; ii++)
                {
                    // if (twoDiss[ii] != 0)
                    //{
                    twoDiss[ii]++;
                    //}
                }


                foreach (int tn in twoNumAdds)
                {
                    twoAdds[tn - 3] = 0;
                }

                foreach (int tn in twoNumdiss)
                {
                    twoDiss[tn - 1] = 0;
                }




                html += string.Format(@"
                    		<tr>
			                    <td>{0}</td>
			                    <td class=""middledata redballfont equalwidth"">{1}</td>
			                    <td class=""middledata redballfont equalwidth"">{2}</td>
			                    <td class=""middledata redballfont equalwidth"">{3}</td>
			                    <td class=""middledata redballfont equalwidth"">{4}</td>
			                    <td class=""middledata redballfont equalwidth"">{5}</td>
			                    <td {35}>{6}</td>
			                    <td {36}>{7}</td>
			                    <td {37}>{8}</td>
			                    <td {38}>{9}</td>
			                    <td {39}>{10}</td>
			                    <td {40}>{11}</td>
			                    <td {41}>{12}</td>
			                    <td {42}>{13}</td>
			                    <td {43}>{14}</td>
			                    <td {44}>{15}</td>
			                    <td {45}>{16}</td>
			                    <td {46}>{17}</td>
			                    <td {47}>{18}</td>
			                    <td {48}>{19}</td>
			                    <td {49}>{20}</td>
			                    <td {50}>{21}</td>
			                    <td {51}>{22}</td>
			                    <td {52}>{23}</td>
			                    <td {53}>{24}</td>
			                    <td {54}>{25}</td>
			                    <td {55}>{26}</td>
			                    <td {56}>{27}</td>
			                    <td {57}>{28}</td>
			                    <td {58}>{29}</td>
			                    <td {59}>{30}</td>
			                    <td {60}>{31}</td>
			                    <td {61}>{32}</td>
			                    <td {62}>{33}</td>
			                    <td {63}>{34}</td>
		                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                 twoNumAdds.Contains(3) ? "3" : twoAdds[0].ToString(), //6
                 twoNumAdds.Contains(4) ? "4" : twoAdds[1].ToString(),//7
                 twoNumAdds.Contains(5) ? "5" : twoAdds[2].ToString(),//8
                 twoNumAdds.Contains(6) ? "6" : twoAdds[3].ToString(),//9
                 twoNumAdds.Contains(7) ? "7" : twoAdds[4].ToString(),//10
                 twoNumAdds.Contains(8) ? "8" : twoAdds[5].ToString(),//11
                 twoNumAdds.Contains(9) ? "9" : twoAdds[6].ToString(),//12
                 twoNumAdds.Contains(10) ? "10" : twoAdds[7].ToString(),//13
                 twoNumAdds.Contains(11) ? "11" : twoAdds[8].ToString(),//14
                 twoNumAdds.Contains(12) ? "12" : twoAdds[9].ToString(),//15
                 twoNumAdds.Contains(13) ? "13" : twoAdds[10].ToString(),//16
                 twoNumAdds.Contains(14) ? "14" : twoAdds[11].ToString(),//17
                 twoNumAdds.Contains(15) ? "15" : twoAdds[12].ToString(),//18
                 twoNumAdds.Contains(16) ? "16" : twoAdds[13].ToString(),//19
                 twoNumAdds.Contains(17) ? "17" : twoAdds[14].ToString(),//20
                 twoNumAdds.Contains(18) ? "18" : twoAdds[15].ToString(),//21
                 twoNumAdds.Contains(19) ? "19" : twoAdds[16].ToString(),//22
                 twoNumAdds.Contains(20) ? "20" : twoAdds[17].ToString(),//23
                 twoNumAdds.Contains(21) ? "21" : twoAdds[18].ToString(), //24
                 twoNumdiss.Contains(1) ? "1" : twoDiss[0].ToString(), //25
                 twoNumdiss.Contains(2) ? "2" : twoDiss[1].ToString(), //26
                 twoNumdiss.Contains(3) ? "3" : twoDiss[2].ToString(), //27
                 twoNumdiss.Contains(4) ? "4" : twoDiss[3].ToString(), //28
                 twoNumdiss.Contains(5) ? "5" : twoDiss[4].ToString(), //29
                 twoNumdiss.Contains(6) ? "6" : twoDiss[5].ToString(), //30
                 twoNumdiss.Contains(7) ? "7" : twoDiss[6].ToString(), //31
                 twoNumdiss.Contains(8) ? "8" : twoDiss[7].ToString(), //32
                 twoNumdiss.Contains(9) ? "9" : twoDiss[8].ToString(), //33
                 twoNumdiss.Contains(10) ? "10" : twoDiss[9].ToString(),//34

                 twoNumAdds.Contains(3) ? @"class=""redball""" : @"class=""grayfont""", //35
                 twoNumAdds.Contains(4) ? @"class=""redball""" : @"class=""grayfont""",//36
                 twoNumAdds.Contains(5) ? @"class=""redball""" : @"class=""grayfont""",//37
                 twoNumAdds.Contains(6) ? @"class=""redball""" : @"class=""grayfont""",//38
                 twoNumAdds.Contains(7) ? @"class=""redball""" : @"class=""grayfont""",//39
                 twoNumAdds.Contains(8) ? @"class=""redball""" : @"class=""grayfont""",//40
                 twoNumAdds.Contains(9) ? @"class=""redball""" : @"class=""grayfont""",//41
                 twoNumAdds.Contains(10) ? @"class=""redball""" : @"class=""grayfont""",//42
                 twoNumAdds.Contains(11) ? @"class=""redball""" : @"class=""grayfont""",//43
                 twoNumAdds.Contains(12) ? @"class=""redball""" : @"class=""grayfont""",//44
                 twoNumAdds.Contains(13) ? @"class=""redball""" : @"class=""grayfont""",//45
                 twoNumAdds.Contains(14) ? @"class=""redball""" : @"class=""grayfont""",//46
                 twoNumAdds.Contains(15) ? @"class=""redball""" : @"class=""grayfont""",//47
                 twoNumAdds.Contains(16) ? @"class=""redball""" : @"class=""grayfont""",//48
                 twoNumAdds.Contains(17) ? @"class=""redball""" : @"class=""grayfont""",//49
                 twoNumAdds.Contains(18) ? @"class=""redball""" : @"class=""grayfont""",//50
                 twoNumAdds.Contains(19) ? @"class=""redball""" : @"class=""grayfont""",//51
                 twoNumAdds.Contains(20) ? @"class=""redball""" : @"class=""grayfont""",//52
                 twoNumAdds.Contains(21) ? @"class=""redball""" : @"class=""grayfont""", //53

                 twoNumdiss.Contains(1) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //54
                 twoNumdiss.Contains(2) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //55
                 twoNumdiss.Contains(3) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //56
                 twoNumdiss.Contains(4) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //57
                 twoNumdiss.Contains(5) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //58
                 twoNumdiss.Contains(6) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //59
                 twoNumdiss.Contains(7) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //60
                 twoNumdiss.Contains(8) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //61
                 twoNumdiss.Contains(9) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""", //62
                 twoNumdiss.Contains(10) ? @"class=""middledata blueball""" : @"class=""middledata grayfont""" //63
                 );

            }

            html += @"
                <tr  class=""headfoot"">
			                <td rowspan=""2"" colspan=""6"">提交选择</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">7</td>
			                <td class=""unclk"">8</td>
			                <td class=""unclk"">9</td>
			                <td class=""unclk"">10</td>
			                <td class=""unclk"">11</td>
			                <td class=""unclk"">12</td>
			                <td class=""unclk"">13</td>
			                <td class=""unclk"">14</td>
			                <td class=""unclk"">15</td>
			                <td class=""unclk"">16</td>
			                <td class=""unclk"">17</td>
			                <td class=""unclk"">18</td>
			                <td class=""unclk"">19</td>
			                <td class=""unclk"">20</td>
			                <td class=""unclk"">21</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">7</td>
			                <td class=""unclk"">8</td>
			                <td class=""unclk"">9</td>
			                <td class=""unclk"">10</td>

		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""19"">两码和走势图</td>
			                <td colspan=""10"">两码差走势图</td>
		                </tr>
	                </table>
                </body>
                </html>
            ";


            return html;
        }
        #endregion

        #region 代码走势 临差值
        public static string GetHtmlDMZS_LCZZouShi(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";
            string d2 = "";
            string d3 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                if (i != 0)
                {
                    d1 += "d1" + i.ToString() + ",";
                    d2 += "d2" + i.ToString() + ",";
                }
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>cmzs</title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

		                table{{
			                width: 1250px; 
			                text-align:center;
                            margin:auto;
		                }}

                        .noneball{{
                            background-image: url(image/ball_black.png);
		                    background-repeat: no-repeat;
		                    color: white;
		                    font-weight: bold;
                            background-position:center center;
                        }}          
		                .redballfont{{
			                color:red;
		                }}

		                td.equalwidth{{
			                width: 32px;
		                }}

 td.grayfont{{
	color:gray;
}}
		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   


		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">
                           function drawlines(){{
                            DrawLine_blue(""{0}"",""19"", ""4"");
				            DrawLine(""{1}"",""19"", ""4"");
				            DrawLine_blue(""{2}"",""19"", ""4"");
                            }}
                        $(document).ready(function(){{
                            drawlines();
                        }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                    </script>
<script type=""text/javascript"">
					$(document).ready(function()
					{{
                         document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
                                document.title =""clk"";
								$(this).removeClass(""clk"");
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                    document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:8%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:12%"">开奖号码</td>
			                <td colspan=""11"">开奖号码分布图</td>
			                <td colspan=""6"">传小个数</td>
			                <td colspan=""6"">传大个数</td>
			                <td colspan=""6"">差临值</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">01</td>
			                <td class=""equalwidth"">02</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">8</td>
			                <td class=""equalwidth"">9</td>
		                </tr>
                    ", d1, d2, d3);
            #endregion

            string html = top;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] passbigs = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] passsmalls = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] clzs = new int[] { 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                for (int ii = 1; ii <= 11; ii++)
                {

                    if (Array.IndexOf<int>(lottery.GetArray(), ii) == -1)
                    {
                        preExistCount[ii - 1]++;
                        lotteryNumExit[ii - 1] = false;
                    }
                    else
                    {
                        preExistCount[ii - 1] = 0;
                        lotteryNumExit[ii - 1] = true;
                    }
                }

                int psb = 0;
                int pss = 0;
                int clz = lottery.twoNumDiss.Count;
                if (i > 0)
                {
                    psb = skip1(lotterys[i - 1].GetArray(), lotterys[i].GetArray());
                    pss = skip1(lotterys[i].GetArray(), lotterys[i - 1].GetArray());




                    for (int ii = 0; ii < 6; ii++)
                    {
                        if (ii == psb)
                        {
                            passbigs[ii] = 0;
                        }
                        else
                        {
                            passbigs[ii]++;
                        }

                        if (ii == pss)
                        {
                            passsmalls[ii] = 0;
                        }
                        else
                        {
                            passsmalls[ii]++;
                        }
                    }
                }

                for (int ii = 0; ii < 6; ii++)
                {
                    if (ii + 4 == clz)
                    {
                        clzs[ii] = 0;
                    }
                    else
                    {
                        clzs[ii]++;
                    }
                }

                html += string.Format(@"
                    		<tr>
			                    <td>{0}</td>
			                    <td  class=""middledata redballfont equalwidth"">{1}</td>
			                    <td  class=""middledata redballfont equalwidth"">{2}</td>
			                    <td  class=""middledata redballfont equalwidth"">{3}</td>
			                    <td  class=""middledata redballfont equalwidth"">{4}</td>
			                    <td  class=""middledata redballfont equalwidth"">{5}</td>
			                    <td {35}>{6}</td>
			                    <td {36}>{7}</td>
			                    <td {37}>{8}</td>
			                    <td {38}>{9}</td>
			                    <td {39}>{10}</td>
			                    <td {40}>{11}</td>
			                    <td {41}>{12}</td>
			                    <td {42}>{13}</td>
			                    <td {43}>{14}</td>
			                    <td {44}>{15}</td>
			                    <td {45}>{16}</td>
			                    <td {46}>{17}</td>
			                    <td {47}>{18}</td>
			                    <td {48}>{19}</td>
			                    <td {49}>{20}</td>
			                    <td {50}>{21}</td>
			                    <td {51}>{22}</td>
			                    <td {52}>{23}</td>
			                    <td {53}>{24}</td>
			                    <td {54}>{25}</td>
			                    <td {55}>{26}</td>
			                    <td {56}>{27}</td>
			                    <td {57}>{28}</td>
			                    <td {58}>{29}</td>
			                    <td {59}>{30}</td>
			                    <td {60}>{31}</td>
			                    <td {61}>{32}</td>
			                    <td {62}>{33}</td>
			                    <td {63}>{34}</td>
		                    </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                      lotteryNumExit[0] ? "01" : preExistCount[0].ToString(),  //6
                    lotteryNumExit[1] ? "02" : preExistCount[1].ToString(),  //7
                    lotteryNumExit[2] ? "03" : preExistCount[2].ToString(),  //8
                    lotteryNumExit[3] ? "04" : preExistCount[3].ToString(),  //9
                    lotteryNumExit[4] ? "05" : preExistCount[4].ToString(),  //10
                    lotteryNumExit[5] ? "06" : preExistCount[5].ToString(),  //11
                    lotteryNumExit[6] ? "07" : preExistCount[6].ToString(),   //12
                    lotteryNumExit[7] ? "08" : preExistCount[7].ToString(),   //13
                    lotteryNumExit[8] ? "09" : preExistCount[8].ToString(),  //14
                    lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), // 15
                    lotteryNumExit[10] ? "11" : preExistCount[10].ToString(), //16
                    i == 0 ? "0" : (pss == 0 ? "0" : passsmalls[0].ToString()), //17
                    i == 0 ? "1" : (pss == 1 ? "1" : passsmalls[1].ToString()), //18
                    i == 0 ? "2" : (pss == 2 ? "2" : passsmalls[2].ToString()), //19
                    i == 0 ? "3" : (pss == 3 ? "3" : passsmalls[3].ToString()), //20
                    i == 0 ? "4" : (pss == 4 ? "4" : passsmalls[4].ToString()), //21
                    i == 0 ? "5" : (pss == 5 ? "5" : passsmalls[5].ToString()), //22
                    i == 0 ? "0" : (psb == 0 ? "0" : passbigs[0].ToString()), //23
                    i == 0 ? "1" : (psb == 1 ? "1" : passbigs[1].ToString()), //24
                    i == 0 ? "2" : (psb == 2 ? "2" : passbigs[2].ToString()), //25
                    i == 0 ? "3" : (psb == 3 ? "3" : passbigs[3].ToString()), //26
                    i == 0 ? "4" : (psb == 4 ? "4" : passbigs[4].ToString()), //27
                    i == 0 ? "5" : (psb == 5 ? "5" : passbigs[5].ToString()), //28
                    clz == 4 ? "4" : clzs[0].ToString(), // 29
                    clz == 5 ? "5" : clzs[1].ToString(), //30
                    clz == 6 ? "6" : clzs[2].ToString(), //31
                    clz == 7 ? "7" : clzs[3].ToString(), //32
                    clz == 8 ? "8" : clzs[4].ToString(), //33
                    clz == 9 ? "9" : clzs[5].ToString(), //34
                    lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", //35
                    lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""", //36
                    lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""", //37
                    lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""", //38
                    lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""", //39
                    lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""", //40
                    lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""", //41
                    lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""", //42
                    lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""", //43
                    lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //44
                    lotteryNumExit[10] ? @"class=""redball""" : @"class=""grayfont""", //45

                    i == 0 ? @"class=""noneball middledata""" : (pss == 0 ? @"class=""blueball middledata""  id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""), //46
                    i == 0 ? @"class=""noneball middledata""" : (pss == 1 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""), //47
                    i == 0 ? @"class=""noneball middledata""" : (pss == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""), //48
                    i == 0 ? @"class=""noneball middledata""" : (pss == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""), //49
                    i == 0 ? @"class=""noneball middledata""" : (pss == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""), //50
                    i == 0 ? @"class=""noneball middledata""" : (pss == 5 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""),//51

                    i == 0 ? @"class=""noneball""" : (psb == 0 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //52
                    i == 0 ? @"class=""noneball""" : (psb == 1 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //53
                    i == 0 ? @"class=""noneball""" : (psb == 2 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //54
                    i == 0 ? @"class=""noneball""" : (psb == 3 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //55
                    i == 0 ? @"class=""noneball""" : (psb == 4 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //56
                    i == 0 ? @"class=""noneball""" : (psb == 5 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont"""), //57

                    clz == 4 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 58
                    clz == 5 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", //59
                    clz == 6 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", //60
                    clz == 7 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", //61
                    clz == 8 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""", //62
                    clz == 9 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""" //63
                     );

            }

            html += @"
                            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
			            <td class=""unclk"">01</td>
			            <td class=""unclk"">02</td>
			            <td class=""unclk"">03</td>
			            <td class=""unclk"">04</td>
			            <td class=""unclk"">05</td>
			            <td class=""unclk"">06</td>
			            <td class=""unclk"">07</td>
			            <td class=""unclk"">08</td>
			            <td class=""unclk"">09</td>
			            <td class=""unclk"">10</td>
			            <td class=""unclk"">11</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
		            </tr>
		            <tr  class=""headfoot"">
					            <td colspan=""11"">开奖号码分布图</td>
			            <td colspan=""6"">传小个数</td>
			            <td colspan=""6"">传大个数</td>
			            <td colspan=""6"">差临值</td>
		            </tr>
	            </table>
            </body>
            </html>
            ";

            return html;

        }

        private static int skip1(int[] arr1, int[] arr2)
        {
            int count = 0;
            for (int i = 0; i < arr1.Length; i++)
            {
                for (int ii = 0; ii < arr2.Length; ii++)
                {
                    if (arr2[ii] - arr1[i] == 1)
                    {
                        count++;
                    }
                }
            }
            return count;
        }

        #endregion

        #region 和值走势图
        public static string GetHtmlHe1ZouShi(List<Lottery> lotterys, List<string> days)
        {
            string d1 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";

            }

            d1 = d1.Substring(0, d1.Length - 1);

            #region TOP
            string TOP = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title></title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

		                table{{
			                width: 1300px; 
			                text-align:center;
                            margin:auto;
		                }}

 td.grayfont{{
	color:gray;
}}
		                .redballfont{{
			                color:red;
		                }}

		                td.equalwidth{{
			                width: 32px;
		                }}

		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   

                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">
                           function drawlines(){{
                                DrawLine(""{0}"",""19"", ""4"");
                            }}

                        $(document).ready(function(){{
                            drawlines();
                        }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                    </script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
                                 document.title =""clk"";
								$(this).removeClass(""clk"");
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
                <table>
	                <tr class=""headfoot"">
		                <td rowspan=""2"" style=""width:7.7%"">期号</td>
		                <td rowspan=""2"" colspan=""5"" style=""width:11.5%"">开奖号码</td>
		                <td colspan=""31"">和值走势图</td>
	                </tr>
	                <tr class=""headfoot"">
		                <td class=""equalwidth"">15</td>
		                <td class=""equalwidth"">16</td>
		                <td class=""equalwidth"">17</td>
		                <td class=""equalwidth"">18</td>
		                <td class=""equalwidth"">19</td>
		                <td class=""equalwidth"">20</td>
		                <td class=""equalwidth"">21</td>
		                <td class=""equalwidth"">22</td>
		                <td class=""equalwidth"">23</td>
		                <td class=""equalwidth"">24</td>
		                <td class=""equalwidth"">25</td>
		                <td class=""equalwidth"">26</td>
		                <td class=""equalwidth"">27</td>
		                <td class=""equalwidth"">28</td>
		                <td class=""equalwidth"">29</td>
		                <td class=""equalwidth"">30</td>
		                <td class=""equalwidth"">31</td>
		                <td class=""equalwidth"">32</td>
		                <td class=""equalwidth"">33</td>
		                <td class=""equalwidth"">34</td>
		                <td class=""equalwidth"">35</td>
		                <td class=""equalwidth"">36</td>
		                <td class=""equalwidth"">37</td>
		                <td class=""equalwidth"">38</td>
		                <td class=""equalwidth"">39</td>
		                <td class=""equalwidth"">40</td>
		                <td class=""equalwidth"">41</td>
		                <td class=""equalwidth"">42</td>
		                <td class=""equalwidth"">43</td>
		                <td class=""equalwidth"">44</td>
		                <td class=""equalwidth"">45</td>
	                </tr>
            ", d1);
            #endregion

            string html = TOP;

            int[] he1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int sum = lottery.GetSumOfLottery();

                for (int ii = 0; ii < 31; ii++)
                {
                    if (ii + 15 == sum)
                    {
                        he1[ii] = 0;
                    }
                    else
                    {
                        he1[ii]++;
                    }
                }

                html += string.Format(@"
                    <tr>
		                    <td {37}>{0}</td>
		                    <td {38}>{1}</td>
		                    <td {39}>{2}</td>
		                    <td {40}>{3}</td>
		                    <td {41}>{4}</td>
		                    <td {42}>{5}</td>
		                    <td {43}>{6}</td>
		                    <td {44}>{7}</td>
		                    <td {45}>{8}</td>
		                    <td {46}>{9}</td>
		                    <td {47}>{10}</td>
		                    <td {48}>{11}</td>
		                    <td {49}>{12}</td>
		                    <td {50}>{13}</td>
		                    <td {51}>{14}</td>
		                    <td {52}>{15}</td>
		                    <td {53}>{16}</td>
		                    <td {54}>{17}</td>
		                    <td {55}>{18}</td>
		                    <td {56}>{19}</td>
		                    <td {57}>{20}</td>
		                    <td {58}>{21}</td>
		                    <td {59}>{22}</td>
		                    <td {60}>{23}</td>
		                    <td {61}>{24}</td>
		                    <td {62}>{25}</td>
		                    <td {63}>{26}</td>
		                    <td {64}>{27}</td>
		                    <td {65}>{28}</td>
		                    <td {66}>{29}</td>
		                    <td {67}>{30}</td>
		                    <td {68}>{31}</td>
		                    <td {69}>{32}</td>
		                    <td {70}>{33}</td>
		                    <td {71}>{34}</td>
		                    <td {72}>{35}</td>
		                    <td {73}>{36}</td>
	                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                 sum == 15 ? "15" : he1[0].ToString(), //6
                 sum == 16 ? "16" : he1[1].ToString(), //7
                 sum == 17 ? "17" : he1[2].ToString(), //8
                 sum == 18 ? "18" : he1[3].ToString(), //9
                 sum == 19 ? "19" : he1[4].ToString(), //10
                 sum == 20 ? "20" : he1[5].ToString(), //11
                 sum == 21 ? "21" : he1[6].ToString(), //12
                 sum == 22 ? "22" : he1[7].ToString(), //13
                 sum == 23 ? "23" : he1[8].ToString(), //14
                 sum == 24 ? "24" : he1[9].ToString(), //15
                 sum == 25 ? "25" : he1[10].ToString(), //16
                 sum == 26 ? "26" : he1[11].ToString(), //17
                 sum == 27 ? "27" : he1[12].ToString(), //18
                 sum == 28 ? "28" : he1[13].ToString(), //19
                 sum == 29 ? "29" : he1[14].ToString(), //20
                 sum == 30 ? "30" : he1[15].ToString(), //21
                 sum == 31 ? "31" : he1[16].ToString(), //22
                 sum == 32 ? "32" : he1[17].ToString(), //23
                 sum == 33 ? "33" : he1[18].ToString(), //24
                 sum == 34 ? "34" : he1[19].ToString(), //25
                 sum == 35 ? "35" : he1[20].ToString(), //26
                 sum == 36 ? "36" : he1[21].ToString(), //27
                 sum == 37 ? "37" : he1[22].ToString(), //28
                 sum == 38 ? "38" : he1[23].ToString(), //29
                 sum == 39 ? "39" : he1[24].ToString(), //30
                 sum == 40 ? "40" : he1[25].ToString(), //31
                 sum == 41 ? "41" : he1[26].ToString(), //32
                 sum == 42 ? "42" : he1[27].ToString(), //33
                 sum == 43 ? "43" : he1[28].ToString(), //34
                 sum == 44 ? "44" : he1[29].ToString(), //35
                 sum == 45 ? "45" : he1[30].ToString(), //36
                 "",
                 @"class=""middledata redballfont equalwidth""",
                 @"class=""middledata redballfont equalwidth""",
                 @"class=""middledata redballfont equalwidth""",
                 @"class=""middledata redballfont equalwidth""",
                 @"class=""middledata redballfont equalwidth""",
                 sum == 15 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //6
                 sum == 16 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //7
                 sum == 17 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //8
                 sum == 18 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //9
                 sum == 19 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //10
                 sum == 20 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //11
                 sum == 21 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //12
                 sum == 22 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //13
                 sum == 23 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //14
                 sum == 24 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //15
                 sum == 25 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //16
                 sum == 26 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //17
                 sum == 27 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //18
                 sum == 28 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //19
                 sum == 29 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //20
                 sum == 30 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //21
                 sum == 31 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //22
                 sum == 32 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //23
                 sum == 33 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //24
                 sum == 34 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //25
                 sum == 35 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //26
                 sum == 36 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //27
                 sum == 37 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //28
                 sum == 38 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //29
                 sum == 39 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //30
                 sum == 40 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //31
                 sum == 41 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //32
                 sum == 42 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //33
                 sum == 43 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //34
                 sum == 44 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //35
                 sum == 45 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""" //36
                 );
            }

            html += @"
                            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
					            <td class=""unclk"">15</td>
		            <td class=""unclk"">16</td>
		            <td class=""unclk"">17</td>
		            <td class=""unclk"">18</td>
		            <td class=""unclk"">19</td>
		            <td class=""unclk"">20</td>
		            <td class=""unclk"">21</td>
		            <td class=""unclk"">22</td>
		            <td class=""unclk"">23</td>
		            <td class=""unclk"">24</td>
		            <td class=""unclk"">25</td>
		            <td class=""unclk"">26</td>
		            <td class=""unclk"">27</td>
		            <td class=""unclk"">28</td>
		            <td class=""unclk"">29</td>
		            <td class=""unclk"">30</td>
		            <td class=""unclk"">31</td>
		            <td class=""unclk"">32</td>
		            <td class=""unclk"">33</td>
		            <td class=""unclk"">34</td>
		            <td class=""unclk"">35</td>
		            <td class=""unclk"">36</td>
		            <td class=""unclk"">37</td>
		            <td class=""unclk"">38</td>
		            <td class=""unclk"">39</td>
		            <td class=""unclk"">40</td>
		            <td class=""unclk"">41</td>
		            <td class=""unclk"">42</td>
		            <td class=""unclk"">43</td>
		            <td class=""unclk"">44</td>
		            <td class=""unclk"">45</td>
	            </tr>
	            <tr class=""headfoot"">
	            <td colspan=""31"">和值走势图</td>
	            </tr>
            </body>
            </html>

                ";

            return html;
        }
        #endregion

        #region 合值 跨度 临码和
        public static string GetHtmlHZ_KD_LMHZoushiTu(List<Lottery> lotterys, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {

                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";

                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string top = string.Format(@"
                    <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                        <html lang=""en"">
                        <head>
	                        <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                        <title></title>
		                        <style type=""text/css"">
		                        .headfoot{{
			                        background-color:rgb(245,234,190);
			                        font:normal 20px arial,sans-serif;
		                        }}

		                        table, tr, td{{ 
			                        border-collapse: collapse;
			                        border:1px solid black;
		                        }}

		                        td{{
			                        height: 32px;
		                        }}

		                        table{{
			                        width: 1050px; 
			                        text-align:center;
                            margin:auto;
		                        }}

 td.grayfont{{
	color:gray;
}}
		                        .redballfont{{
			                        color:red;
		                        }}

		                        td.equalwidth{{
			                        width: 32px;
		                        }}


                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                        .redball{{
			                        background-image: url(image/ball_red.png);
			                        background-repeat: no-repeat;
			                        color: white;
			                        font-weight: bold;
			                        background-position:center center;
		                        }}
		
		                        .blueball{{
			                        background-image: url(image/ball_bule.png);
			                        background-repeat: no-repeat;
			                        color: white;
			                        font-weight: bold;
			                        background-position:center center;
		                        }}   


		                        .eredball{{
			                        background-image: url(image/qred.png);
			                        background-repeat: no-repeat;
			                        color: red;
			                        font-weight: bold;
			                        background-position:center center;
		                        }}

		                        .eblueball{{
			                        background-image: url(image/qbule.png);
			                        background-repeat: no-repeat;
			                        color: blue;
			                        font-weight: bold;
			                        background-position:center center;
		                        }}                

		                        .middledata{{
			                        background-color:rgb(249,242,223);
		                        }}
	                        </style>

                            <script type=""text/javascript"" src=""jq142.js""></script>
	                        <script type=""text/javascript"" src=""drawline.js""></script>
                            <script type=""text/javascript"">
                            function drawlines(){{
				                    DrawLine(""{0}"",""19"", ""4"");
				                    DrawLine_blue(""{1}"",""19"", ""4"");
                                    DrawLine(""{2}"",""19"", ""4"");
                            }}
                                $(document).ready(function(){{
                                    drawlines();
                                }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                            </script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                        </head>
                        <body>
	                        <table>
		                        <tr class=""headfoot"">
			                        <td rowspan=""2"" style=""width:9.6%"">期号</td>
			                        <td rowspan=""2"" colspan=""5"" style=""width:14.3%"">开奖号码</td>
			                        <td colspan=""10"">合值走势图</td>
			                        <td colspan=""7"">跨度走势图</td>
			                        <td colspan=""7"">临码和走势图</td>
		                        </tr>
		                        <tr class=""headfoot"">
			                        <td class=""equalwidth"">0</td>
			                        <td class=""equalwidth"">1</td>
			                        <td class=""equalwidth"">2</td>
			                        <td class=""equalwidth"">3</td>
			                        <td class=""equalwidth"">4</td>
			                        <td class=""equalwidth"">5</td>
			                        <td class=""equalwidth"">6</td>
			                        <td class=""equalwidth"">7</td>
			                        <td class=""equalwidth"">8</td>
			                        <td class=""equalwidth"">9</td>
			                        <td class=""equalwidth"">4</td>
			                        <td class=""equalwidth"">5</td>
			                        <td class=""equalwidth"">6</td>
			                        <td class=""equalwidth"">7</td>
			                        <td class=""equalwidth"">8</td>
			                        <td class=""equalwidth"">9</td>
			                        <td class=""equalwidth"">10</td>
			                        <td class=""equalwidth"">0</td>
			                        <td class=""equalwidth"">1</td>
			                        <td class=""equalwidth"">2</td>
			                        <td class=""equalwidth"">3</td>
			                        <td class=""equalwidth"">4</td>
			                        <td class=""equalwidth"">5</td>
			                        <td class=""equalwidth"">6</td>
		                        </tr>
                ", d1, d2, d3);
            #endregion

            string html = top;

            int[] he2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] skips = new int[] { 0, 0, 0, 0, 0, 0, 0 };
            int[] nearSums = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int he = lottery.GetSmallBitOfSum();
                int skip = lottery.GetSpan();
                int near = lottery.GetLinMaHe();

                for (int ii = 0; ii <= 9; ii++)
                {
                    if (ii == he)
                    {
                        he2[ii] = 0;
                    }
                    else
                    {
                        he2[ii]++;
                    }
                }

                for (int ii = 0; ii < 7; ii++)
                {
                    if (ii + 4 == skip)
                    {
                        skips[ii] = 0;
                    }
                    else
                    {
                        skips[ii]++;
                    }

                    if (ii == near)
                    {
                        nearSums[ii] = 0;
                    }
                    else
                    {
                        nearSums[ii]++;
                    }
                }


                html += string.Format(@"
                    		<tr>
			                    <td>{0}</td>
			                    <td class=""middledata redballfont equalwidth"">{1}</td>
			                    <td class=""middledata redballfont equalwidth"">{2}</td>
			                    <td class=""middledata redballfont equalwidth"">{3}</td>
			                    <td class=""middledata redballfont equalwidth"">{4}</td>
			                    <td class=""middledata redballfont equalwidth"">{5}</td>
			                    <td {30}>{6}</td>
			                    <td {31}>{7}</td>
			                    <td {32}>{8}</td>
			                    <td {33}>{9}</td>
			                    <td {34}>{10}</td>
			                    <td {35}>{11}</td>
			                    <td {36}>{12}</td>
			                    <td {37}>{13}</td>
			                    <td {38}>{14}</td>
			                    <td {39}>{15}</td>
			                    <td {40}>{16}</td>
			                    <td {41}>{17}</td>
			                    <td {42}>{18}</td>
			                    <td {43}>{19}</td>
			                    <td {44}>{20}</td>
			                    <td {45}>{21}</td>
			                    <td {46}>{22}</td>
			                    <td {47}>{23}</td>
			                    <td {48}>{24}</td>
			                    <td {49}>{25}</td>
			                    <td {50}>{26}</td>
			                    <td {51}>{27}</td>
			                    <td {52}>{28}</td>
			                    <td {53}>{29}</td>
		                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                 he == 0 ? "0" : he2[0].ToString(), // 6
                 he == 1 ? "1" : he2[1].ToString(), // 7
                 he == 2 ? "2" : he2[2].ToString(), // 8
                 he == 3 ? "3" : he2[3].ToString(), // 9
                 he == 4 ? "4" : he2[4].ToString(), // 10
                 he == 5 ? "5" : he2[5].ToString(), // 11
                 he == 6 ? "6" : he2[6].ToString(), // 12
                 he == 7 ? "7" : he2[7].ToString(), // 13
                 he == 8 ? "8" : he2[8].ToString(), // 14
                 he == 9 ? "9" : he2[9].ToString(), // 15
                 skip == 4 ? "4" : skips[0].ToString(), // 16
                 skip == 5 ? "5" : skips[1].ToString(), // 17
                 skip == 6 ? "6" : skips[2].ToString(), // 18
                 skip == 7 ? "7" : skips[3].ToString(), // 19
                 skip == 8 ? "8" : skips[4].ToString(), // 20
                 skip == 9 ? "9" : skips[5].ToString(), // 21
                 skip == 10 ? "10" : skips[6].ToString(), // 22
                near == 0 ? "0" : nearSums[0].ToString(), // 23
                near == 1 ? "1" : nearSums[1].ToString(), // 24
                near == 2 ? "2" : nearSums[2].ToString(), // 25
                near == 3 ? "3" : nearSums[3].ToString(), // 26
                near == 4 ? "4" : nearSums[4].ToString(), // 27
                near == 5 ? "5" : nearSums[5].ToString(), // 28
                near == 6 ? "6" : nearSums[6].ToString(),// 29

                 he == 0 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 30
                 he == 1 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",// 31
                 he == 2 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 32
                 he == 3 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 33
                 he == 4 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 34
                 he == 5 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 35
                 he == 6 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 36
                 he == 7 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",// 37
                 he == 8 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 38
                 he == 9 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 39

                  skip == 4 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",  // 40
                 skip == 5 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 41
                 skip == 6 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",  // 42
                 skip == 7 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",  // 43
                 skip == 8 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",  // 44
                 skip == 9 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 45
                 skip == 10 ? @"class=""middledata blueball"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",  // 46

                near == 0 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",// 47
                near == 1 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",// 48
                near == 2 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""", // 49
                near == 3 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",// 50
                near == 4 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""", // 51
                near == 5 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""", // 52
                near == 6 ? @"class=""redball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont"""// 53
                    );
            }

            html += @"
                    <tr class=""headfoot"">
			                    <td rowspan=""2"" colspan=""6"">提交选择</td>
                                 <td class=""unclk"">0</td>
			                    <td class=""unclk"">1</td>
			                    <td class=""unclk"">2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
			                    <td class=""unclk"">9</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
			                    <td class=""unclk"">9</td>
			                    <td class=""unclk"">10</td>
			                    <td class=""unclk"">0</td>
			                    <td class=""unclk"">1</td>
			                    <td class=""unclk"">2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
		                    </tr>
		                    <tr class=""headfoot"">
						                    <td colspan=""10"">合值走势图</td>
			                    <td colspan=""7"">跨度走势图</td>
			                    <td colspan=""7"">临码和走势图</td>
		                    </tr>
	                    </table>
                    </body>
                    </html>
                ";

            return html;
        }
        #endregion

        #region 集临个数 溃临个数 断临走势 临码群组 012路个数


        public static string GetHtmlJKDL012(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";
            string d2 = "";
            string d3 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region TOP
            string TOP = string.Format(@"
            <!DOCTYPE HTML>
            <html lang=""en-US"">
            <head>
	            <meta charset=""UTF-8"">
	            <title>cyy3</title>
	            <style type=""text/css"">
		            .headfoot{{
			            background-color:rgb(245,234,190);
			            font:normal 20px arial,sans-serif;
		            }}

		            table, tr, td{{ 
			            border-collapse: collapse;
			            border:1px solid black;
		            }}

		            td{{
			            height: 32px;
		            }}

		            table{{
			            width: 1150px; 
			            text-align:center;
                            margin:auto;
		            }}

		            .redballfont{{
			            color:red;
		            }}

		            td.equalwidth{{
			            width: 32px;
		            }}

                     td.grayfont{{
	                    color:gray;
                    }}
		            .redball{{
			            background-image: url(image/ball_red.png);
			            background-repeat: no-repeat;
			            color: white;
			            font-weight: bold;
			            background-position:center center;
		            }}
		
		            .blueball{{
			            background-image: url(image/ball_bule.png);
			            background-repeat: no-repeat;
			            color: white;
			            font-weight: bold;
			            background-position:center center;
		            }}   

                    .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		            .eredball{{
			            background-image: url(image/qred.png);
			            background-repeat: no-repeat;
			            color: red;
			            font-weight: bold;
			            background-position:center center;
		            }}

		            .eblueball{{
			            background-image: url(image/qbule.png);
			            background-repeat: no-repeat;
			            color: blue;
			            font-weight: bold;
			            background-position:center center;
		            }}                

		            .middledata{{
			            background-color:rgb(249,242,223);
		            }}
	            </style>
                <script type=""text/javascript"" src=""jq142.js""></script>
	            <script type=""text/javascript"" src=""drawline.js""></script>
                <script type=""text/javascript"">
                            function drawlines(){{
                                DrawLine(""{0}"",""19"", ""4"");
                                DrawLine_blue(""{1}"",""19"", ""4"");
                                DrawLine_blue(""{2}"",""19"", ""4"");
                            }}
                    $(document).ready(function(){{
                        drawlines();
                    }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                </script>

                <script type=""text/javascript"">

					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
            </head>
            <body>
	            <table>
		            <tr class=""headfoot"">
			            <td rowspan=""2"" style=""width:8.8%"">期号</td>
			            <td colspan=""5"" rowspan=""2"" style=""width:13%"">开奖号码</td>
			            <td colspan=""5"">集临个数</td>
			            <td colspan=""6"">溃临个数</td>
			            <td colspan=""11"">断临走势</td>
			            <td colspan=""3"">临码群组</td>
			            <td colspan=""3"">012路个数</td>
		            </tr>
		            <tr class=""headfoot"">
			            <td class=""equalwidth"">1</td>
			            <td class=""equalwidth"">2</td>
			            <td class=""equalwidth"">3</td>
			            <td class=""equalwidth"">4</td>
			            <td class=""equalwidth"">5</td>
			            <td class=""equalwidth"">1</td>
			            <td class=""equalwidth"">2</td>
			            <td class=""equalwidth"">3</td>
			            <td class=""equalwidth"">4</td>
			            <td class=""equalwidth"">5</td>
			            <td class=""equalwidth"">6</td>
			            <td class=""equalwidth"">1</td>
			            <td class=""equalwidth"">2</td>
			            <td class=""equalwidth"">3</td>
			            <td class=""equalwidth"">4</td>
			            <td class=""equalwidth"">5</td>
			            <td class=""equalwidth"">6</td>
			            <td class=""equalwidth"">7</td>
			            <td class=""equalwidth"">8</td>
			            <td class=""equalwidth"">9</td>
			            <td class=""equalwidth"">10</td>
			            <td class=""equalwidth"">11</td>
			            <td class=""equalwidth"">0</td>
			            <td class=""equalwidth"">1</td>
			            <td class=""equalwidth"">2</td>
			            <td class=""equalwidth"">0</td>
			            <td class=""equalwidth"">1</td>
			            <td class=""equalwidth"">2</td>
		            </tr>
            ", d1, d2, d3);
            #endregion

            string html = TOP;

            int[] jlgss = new int[] { 0, 0, 0, 0, 0 };
            int[] klgss = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] dlzss = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] lmqs = new int[] { 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int jlgs = lottery.ExistMaxLinkedNum;

                for (int ii = 0; ii < 5; ii++)
                {
                    if (jlgs == ii + 1)
                    {
                        jlgss[ii] = 0;
                    }
                    else
                    {
                        jlgss[ii]++;
                    }
                }

                int klgs = lottery.NotExistMaxLinkedNum;

                for (int ii = 0; ii < 6; ii++)
                {
                    if (klgs == ii + 1)
                    {
                        klgss[ii] = 0;
                    }
                    else
                    {
                        klgss[ii]++;
                    }
                }

                int[] dls = lottery.GetDuanLins();

                for (int ii = 0; ii < dlzss.Length; ii++)
                {
                    dlzss[ii]++;
                }

                foreach (int n in dls)
                {
                    dlzss[n - 1] = 0;
                }


                int lmq = lottery.GetLinkCount();

                for (int ii = 0; ii < 3; ii++)
                {
                    if (lmq == ii)
                    {
                        lmqs[ii] = 0;
                    }
                    else
                    {
                        lmqs[ii]++;
                    }
                }



                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont"">{1}</td>
			            <td class=""middledata redballfont"">{2}</td>
			            <td class=""middledata redballfont"">{3}</td>
			            <td class=""middledata redballfont"">{4}</td>
			            <td class=""middledata redballfont"">{5}</td>
			            <td {34}>{6}</td>
			            <td {35}>{7}</td>
			            <td {36}>{8}</td>
			            <td {37}>{9}</td>
			            <td {38}>{10}</td>
			            <td {39}>{11}</td>
			            <td {40}>{12}</td>
			            <td {41}>{13}</td>
			            <td {42}>{14}</td>
			            <td {43}>{15}</td>
			            <td {44}>{16}</td>
			            <td {45}>{17}</td>
			            <td {46}>{18}</td>
			            <td {47}>{19}</td>
			            <td {48}>{20}</td>
			            <td {49}>{21}</td>
			            <td {50}>{22}</td>
			            <td {51}>{23}</td>
			            <td {52}>{24}</td>
			            <td {53}>{25}</td>
			            <td {54}>{26}</td>
			            <td {55}>{27}</td>
			            <td {56}>{28}</td>
			            <td {57}>{29}</td>
			            <td {58}>{30}</td>
			            <td>{31}</td>
			            <td>{32}</td>
			            <td>{33}</td>
		            </tr>

                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),  // 0 -5
                jlgs == 1 ? "1" : jlgss[0].ToString(),
                jlgs == 2 ? "2" : jlgss[1].ToString(),
                jlgs == 3 ? "3" : jlgss[2].ToString(),
                jlgs == 4 ? "4" : jlgss[3].ToString(),
                jlgs == 5 ? "5" : jlgss[4].ToString(), // 6-10
                klgs == 1 ? "1" : klgss[0].ToString(),
                klgs == 2 ? "2" : klgss[1].ToString(),
                klgs == 3 ? "3" : klgss[2].ToString(),
                klgs == 4 ? "4" : klgss[3].ToString(),
                klgs == 5 ? "5" : klgss[4].ToString(),
                klgs == 6 ? "6" : klgss[5].ToString(), // 11- 16
                Array.IndexOf<int>(dls, 1) != -1 ? "1" : dlzss[0].ToString(),
                Array.IndexOf<int>(dls, 2) != -1 ? "2" : dlzss[1].ToString(),
                Array.IndexOf<int>(dls, 3) != -1 ? "3" : dlzss[2].ToString(),
                Array.IndexOf<int>(dls, 4) != -1 ? "4" : dlzss[3].ToString(),
                Array.IndexOf<int>(dls, 5) != -1 ? "5" : dlzss[4].ToString(),
                Array.IndexOf<int>(dls, 6) != -1 ? "6" : dlzss[5].ToString(),
                Array.IndexOf<int>(dls, 7) != -1 ? "7" : dlzss[6].ToString(),
                Array.IndexOf<int>(dls, 8) != -1 ? "8" : dlzss[7].ToString(),
                Array.IndexOf<int>(dls, 9) != -1 ? "9" : dlzss[8].ToString(),
                Array.IndexOf<int>(dls, 10) != -1 ? "10" : dlzss[9].ToString(),
                Array.IndexOf<int>(dls, 11) != -1 ? "11" : dlzss[10].ToString(),//17-27
                lmq == 0 ? "0" : lmqs[0].ToString(),
                lmq == 1 ? "1" : lmqs[1].ToString(),
                lmq == 2 ? "2" : lmqs[2].ToString(),
                lottery.count0.ToString(),
                lottery.count1.ToString(),
                lottery.count2.ToString(),//28-33

                jlgs == 1 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                jlgs == 2 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                jlgs == 3 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                jlgs == 4 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                jlgs == 5 ? @"class=""redball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",// 34-38

                klgs == 1 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata  grayfont""",
                klgs == 2 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                klgs == 3 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                klgs == 4 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                klgs == 5 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                klgs == 6 ? @"class=""blueball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 39-44

                Array.IndexOf<int>(dls, 1) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 2) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 3) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 4) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 5) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 6) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 7) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 8) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 9) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 10) != -1 ? @"class=""redball""" : @"class=""grayfont""",
                Array.IndexOf<int>(dls, 11) != -1 ? @"class=""redball""" : @"class=""grayfont""", // 45-55

                lmq == 0 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                lmq == 1 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                lmq == 2 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont"""
                 );
            }

            html += @"
                <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""6"">提交选择</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">7</td>
			                <td class=""unclk"">8</td>
			                <td class=""unclk"">9</td>
			                <td class=""unclk"">10</td>
			                <td class=""unclk"">11</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
		                </tr>
		
		                <tr class=""headfoot"">
			                <td colspan=""5"">集临个数</td>
			                <td colspan=""6"">溃临个数</td>
			                <td colspan=""11"">断临走势</td>
			                <td colspan=""3"">临码群组</td>
			                <td colspan=""3"">012路个数</td>
		                </tr>
	                </table>
                </body>
                </html>

            ";

            return html;
        }

        #endregion

        #region 012路个数比例
        public static string GetHtml012RateZoushi(List<Lottery> lotterys, List<string> days)
        {
            #region top
            const string TOP = @"
            <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title></title>
	                <style type=""text/css"">
		                .headfoot{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }

		                table, tr, td{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }

		                td{
			                height: 32px;
		                }

		                table{
			                width: 1100px; 
			                text-align:center;
                            margin:auto;
		                }

		                .redballfont{
			                color:red;
		                }

		                td.equalwidth{
			                width: 80px;
		                }

                        .nike{
                            background-image: url(image/nike.png);
			                background-repeat: no-repeat;
                            background-position:center center;
                        }

 td.grayfont{
	color:gray;
}

		                .redball{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }
		
		                .blueball{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }   


		                .eredball{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }
                        .clk{
					        background-color:red;
				        }
				
				        .unclk{
					
				        }  
		                .eblueball{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }                

		                .middledata{
			                background-color:rgb(249,242,223);
		                }
	                </style>
<script type=""text/javascript"" src=""jq142.js""></script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                 document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:9.2%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:13.6%"">开奖号码</td>
			                <td colspan=""16"">012路个数比例走势</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">3:2:0</td>
			                <td class=""equalwidth"">2:0:3</td>
			                <td class=""equalwidth"">1:0:4</td>
			                <td class=""equalwidth"">0:4:1</td>
			                <td class=""equalwidth"">3:0:2</td>
			                <td class=""equalwidth"">2:2:1</td>
			                <td class=""equalwidth"">1:3:1</td>
			                <td class=""equalwidth"">0:1:4</td>
			                <td class=""equalwidth"">3:1:1</td>
			                <td class=""equalwidth"">2:1:2</td>
			                <td class=""equalwidth"">1:1:3</td>
			                <td class=""equalwidth"">0:3:2</td>
			                <td class=""equalwidth"">2:3:0</td>
			                <td class=""equalwidth"">1:4:0</td>
			                <td class=""equalwidth"">1:2:2</td>
			                <td class=""equalwidth"">0:2:3</td>
		                </tr>    
            ";
            #endregion

            string html = TOP;

            int[] rate012s = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int r0 = lottery.count0;
                int r1 = lottery.count1;
                int r2 = lottery.count2;

                for (int ii = 0; ii < rate012s.Length; ii++)
                {
                    rate012s[ii]++;
                }

                if (r0 == 3 && r1 == 2 && r2 == 0)
                {
                    rate012s[0] = 0;
                }

                if (r0 == 2 && r1 == 0 && r2 == 3)
                {
                    rate012s[1] = 0;
                }
                if (r0 == 1 && r1 == 0 && r2 == 4)
                {
                    rate012s[2] = 0;
                }
                if (r0 == 0 && r1 == 4 && r2 == 1)
                {
                    rate012s[3] = 0;
                }
                if (r0 == 3 && r1 == 0 && r2 == 2)
                {
                    rate012s[4] = 0;
                }
                if (r0 == 2 && r1 == 2 && r2 == 1)
                {
                    rate012s[5] = 0;
                }
                if (r0 == 1 && r1 == 3 && r2 == 1)
                {
                    rate012s[6] = 0;
                }
                if (r0 == 0 && r1 == 1 && r2 == 4)
                {
                    rate012s[7] = 0;
                }
                if (r0 == 3 && r1 == 1 && r2 == 1)
                {
                    rate012s[8] = 0;
                }
                if (r0 == 2 && r1 == 1 && r2 == 2)
                {
                    rate012s[9] = 0;
                }
                if (r0 == 1 && r1 == 1 && r2 == 3)
                {
                    rate012s[10] = 0;
                }
                if (r0 == 0 && r1 == 3 && r2 == 2)
                {
                    rate012s[11] = 0;
                }
                if (r0 == 2 && r1 == 3 && r2 == 0)
                {
                    rate012s[12] = 0;
                }
                if (r0 == 1 && r1 == 4 && r2 == 0)
                {
                    rate012s[13] = 0;
                }
                if (r0 == 1 && r1 == 2 && r2 == 2)
                {
                    rate012s[14] = 0;
                }
                if (r0 == 0 && r1 == 2 && r2 == 3)
                {
                    rate012s[15] = 0;
                }

                html += string.Format(@"
                    		<tr>
			                    <td>{0}</td>
			                    <td class=""middledata redballfont"">{1}</td>
			                    <td class=""middledata redballfont"">{2}</td>
			                    <td class=""middledata redballfont"">{3}</td>
			                    <td class=""middledata redballfont"">{4}</td>
			                    <td class=""middledata redballfont"">{5}</td>
			                    <td {22}>{6}</td>
			                    <td {23}>{7}</td>
			                    <td {24}>{8}</td>
			                    <td {25}>{9}</td>
			                    <td {26}>{10}</td>
			                    <td {27}>{11}</td>
			                    <td {28}>{12}</td>
			                    <td {29}>{13}</td>
			                    <td {30}>{14}</td>
			                    <td {31}>{15}</td>
			                    <td {32}>{16}</td>
			                    <td {33}>{17}</td>
			                    <td {34}>{18}</td>
			                    <td {35}>{19}</td>
			                    <td {36}>{20}</td>
			                    <td {37}>{21}</td>
		                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                rate012s[0] == 0 ? "" : rate012s[0].ToString(),
                 rate012s[1] == 0 ? "" : rate012s[1].ToString(),
                 rate012s[2] == 0 ? "" : rate012s[2].ToString(),
                 rate012s[3] == 0 ? "" : rate012s[3].ToString(),
                 rate012s[4] == 0 ? "" : rate012s[4].ToString(),
                 rate012s[5] == 0 ? "" : rate012s[5].ToString(),
                 rate012s[6] == 0 ? "" : rate012s[6].ToString(),
                 rate012s[7] == 0 ? "" : rate012s[7].ToString(),
                 rate012s[8] == 0 ? "" : rate012s[8].ToString(),
                 rate012s[9] == 0 ? "" : rate012s[9].ToString(),
                 rate012s[10] == 0 ? "" : rate012s[10].ToString(),
                 rate012s[11] == 0 ? "" : rate012s[11].ToString(),
                 rate012s[12] == 0 ? "" : rate012s[12].ToString(),
                 rate012s[13] == 0 ? "" : rate012s[13].ToString(),
                 rate012s[14] == 0 ? "" : rate012s[14].ToString(),
                 rate012s[15] == 0 ? "" : rate012s[15].ToString(),

                 rate012s[0] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[1] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[2] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[3] == 0 ? @"class=""nike""" : @"class=""grayfont""",

                  rate012s[4] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[5] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[6] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[7] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",

                 rate012s[8] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[9] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[10] == 0 ? @"class=""nike""" : @"class=""grayfont""",
                 rate012s[11] == 0 ? @"class=""nike""" : @"class=""grayfont""",

                  rate012s[12] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[13] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[14] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont""",
                 rate012s[15] == 0 ? @"class=""nike middledata""" : @"class=""middledata grayfont"""

                 );
            }

            html += @"
                <tr class=""headfoot"">
			        <td rowspan=""2"" colspan=""6"">提交选择</td>
			        <td class=""unclk"">3:2:0</td>
			        <td class=""unclk"">2:0:3</td>
			        <td class=""unclk"">1:0:4</td>
			        <td class=""unclk"">0:4:1</td>
			        <td class=""unclk"">3:0:2</td>
			        <td class=""unclk"">2:2:1</td>
			        <td class=""unclk"">1:3:1</td>
			        <td class=""unclk"">0:1:4</td>
			        <td class=""unclk"">3:1:1</td>
			        <td class=""unclk"">2:1:2</td>
			        <td class=""unclk"">1:1:3</td>
			        <td class=""unclk"">0:3:2</td>
			        <td class=""unclk"">2:3:0</td>
			        <td class=""unclk"">1:4:0</td>
			        <td class=""unclk"">1:2:2</td>
			        <td class=""unclk"">0:2:3</td>
		        </tr>
		        <tr class=""headfoot"">
			        <td colspan=""16"">012路个数比例走势图</td>
		        </tr>
	        </table>
        </body>
        </html>
            ";

            return html;
        }
        #endregion

        #region 跨码走势图
        public static string GetHtmlKuaMaZoushi(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";

            }

            d1 = d1.Substring(0, d1.Length - 1);
            #region TOP
            string TOP = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>跨码走势</title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

		                table{{
			                width: 1000px; 
			                text-align:center;
                            margin:auto;
		                }}

		                .redballfont{{
			                color:red;
		                }}

		                td.equalwidth{{
			                width: 32px;
		                }}
                        
                        .glasses{{
                            background-color:red;
                            background-position:center center;
			                color: white;
                        }}

		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}

 td.grayfont{{
	color:gray;
}}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   

                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">
                            function drawlines(){{
                                DrawLine_blue(""{0}"",""19"", ""4"");
                            }}

                        $(document).ready(function(){{
                            drawlines();
                        }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                    </script>
                        <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                    document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:10.1%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:15%"">开奖号码</td>
			                <td colspan=""9"">跨码走势图</td>
			                <td colspan=""5"">跨码个数走势</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td>01-03</td>
			                <td>02-04</td>
			                <td>03-05</td>
			                <td>04-06</td>
			                <td>05-07</td>
			                <td>06-08</td>
			                <td>07-09</td>
			                <td>08-10</td>
			                <td>09-11</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
		                </tr>
            ", d1);
            #endregion

            string html = TOP;

            int[] kmss = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] kmcounts = new int[] { 0, 0, 0, 0, 0 };
            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];
                List<int> kms = lottery.GetKuaMas();


                for (int ii = 0; ii < kmss.Length; ii++)
                {
                    kmss[ii]++;
                }

                foreach (int n in kms)
                {
                    kmss[n - 1] = 0;
                }

                for (int ii = 0; ii <= 4; ii++)
                {
                    if (kms.Count == ii)
                    {
                        kmcounts[ii] = 0;
                    }
                    else
                    {
                        kmcounts[ii]++;
                    }
                }

                html += string.Format(@"
                            <tr>
                                <td>{0}</td>
			                    <td class=""middledata redballfont"">{1}</td>
			                    <td class=""middledata redballfont"">{2}</td>
			                    <td class=""middledata redballfont"">{3}</td>
			                    <td class=""middledata redballfont"">{4}</td>
			                    <td class=""middledata redballfont"">{5}</td>
			                    <td {20}>{6}</td>
			                    <td {21}>{7}</td>
			                    <td {22}>{8}</td>
			                    <td {23}>{9}</td>
			                    <td {24}>{10}</td>
			                    <td {25}>{11}</td>
			                    <td {26}>{12}</td>
			                    <td {27}>{13}</td>
			                    <td {28}>{14}</td>
			                    <td {29}>{15}</td>
			                    <td {30}>{16}</td>
			                    <td {31}>{17}</td>
			                    <td {32}>{18}</td>
			                    <td {33}>{19}</td>
			                    
		                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                    kms.Contains(1) ? "01-03" : kmss[0].ToString(),
                    kms.Contains(2) ? "02-04" : kmss[1].ToString(),
                    kms.Contains(3) ? "03-05" : kmss[2].ToString(),
                    kms.Contains(4) ? "04-06" : kmss[3].ToString(),
                    kms.Contains(5) ? "05-07" : kmss[4].ToString(),
                    kms.Contains(6) ? "06-08" : kmss[5].ToString(),
                    kms.Contains(7) ? "07-09" : kmss[6].ToString(),
                    kms.Contains(8) ? "08-10" : kmss[7].ToString(),
                    kms.Contains(9) ? "09-11" : kmss[8].ToString(),
                    kms.Count == 0 ? "0" : kmcounts[0].ToString(),
                    kms.Count == 1 ? "1" : kmcounts[1].ToString(),
                    kms.Count == 2 ? "2" : kmcounts[2].ToString(),
                    kms.Count == 3 ? "3" : kmcounts[3].ToString(),
                    kms.Count == 4 ? "4" : kmcounts[4].ToString(),

                    kms.Contains(1) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(2) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(3) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(4) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(5) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(6) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(7) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(8) ? @"class=""glasses""" : @"class=""grayfont""",
                    kms.Contains(9) ? @"class=""glasses""" : @"class=""grayfont""",

                    kms.Count == 0 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    kms.Count == 1 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    kms.Count == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    kms.Count == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    kms.Count == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont"""
                 );
            }

            html += @"
                                <tr  class=""headfoot"">
			                <td rowspan=""2"" colspan=""6"">提交选择</td>
			                <td class=""unclk"">01-03</td>
			                <td class=""unclk"">02-04</td>
			                <td class=""unclk"">03-05</td>
			                <td class=""unclk"">04-06</td>
			                <td class=""unclk"">05-07</td>
			                <td class=""unclk"">06-08</td>
			                <td class=""unclk"">07-09</td>
			                <td class=""unclk"">08-10</td>
			                <td class=""unclk"">09-11</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
		                </tr>
		                <tr  class=""headfoot"">
			                <td colspan=""9"">跨码走势图</td>
			                <td colspan=""5"">跨码个数走势</td>
		                </tr>
	                </table>
                </body>
                </html>

            ";

            return html;
        }
        #endregion

        #region 临码间隔
        public static string GetHtmlLMJGZoushi(List<Lottery> lotterys, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";
            string d4 = "";
            string d5 = "";
            string d6 = "";
            string d7 = "";
            string d8 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
                d4 += "d4" + i.ToString() + ",";
                d5 += "d5" + i.ToString() + ",";
                d6 += "d6" + i.ToString() + ",";
                d7 += "d7" + i.ToString() + ",";
                d8 += "d8" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);
            d4 = d4.Substring(0, d4.Length - 1);

            d5 = d5.Substring(0, d5.Length - 1);
            d6 = d6.Substring(0, d6.Length - 1);
            d7 = d7.Substring(0, d7.Length - 1);
            d8 = d8.Substring(0, d8.Length - 1);

            #region top
            string TOP = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                    <html lang=""en"">
                    <head>
	                    <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                    <title></title>
	                    <style type=""text/css"">
		                    .headfoot{{
			                    background-color:rgb(245,234,190);
			                    font:normal 20px arial,sans-serif;
		                    }}

		                    table, tr, td{{ 
			                    border-collapse: collapse;
			                    border:1px solid black;
		                    }}

		                    td{{
			                    height: 32px;
		                    }}

		                    table{{
			                    width: 1600px; 
			                    text-align:center;
                                margin:auto;
		                    }}

		                    .redballfont{{
			                    color:red;
		                    }}

		                    td.equalwidth{{
			                    width: 32px;
		                    }}

                             td.grayfont{{
	                            color:gray;
                            }}

		                    .redball{{
			                    background-image: url(image/ball_red.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}
		
		                    .blueball{{
			                    background-image: url(image/ball_bule.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}   

                        .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                    .eredball{{
			                    background-image: url(image/qred.png);
			                    background-repeat: no-repeat;
			                    color: red;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}

		                    .eblueball{{
			                    background-image: url(image/qbule.png);
			                    background-repeat: no-repeat;
			                    color: blue;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}                

		                    .middledata{{
			                    background-color:rgb(249,242,223);
		                    }}
	                    </style>
                    <script type=""text/javascript"" src=""jq142.js""></script>
	                <script type=""text/javascript"" src=""drawline.js""></script>
                    <script type=""text/javascript"">
                         function drawlines(){{
                                DrawLine_blue(""{0}"",""19"", ""4"");                        
                                DrawLine(""{1}"",""19"", ""4"");
                                DrawLine_blue(""{2}"",""19"", ""4"");
                                DrawLine(""{3}"",""19"", ""4"");
                                DrawLine_blue(""{4}"",""19"", ""4"");
                                DrawLine(""{5}"",""19"", ""4"");
                                DrawLine_blue(""{6}"",""19"", ""4"");
                                DrawLine(""{7}"",""19"", ""4"");
                            }}

                    $(document).ready(function(){{
                        drawlines();
                    }});

						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                </script>

                <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                    </head>
                    <body>
	                    <table>
		                    <tr class=""headfoot"">
			                    <td rowspan=""2"" style=""width:6.3%"">期号</td>
			                    <td rowspan=""2"" colspan=""5"" style=""width:9.4%"">开奖号码</td>
			                    <td colspan=""11"">开奖号码分布图</td>
			                    <td colspan=""7"">首尾最大间距</td>
			                    <td colspan=""5"">间0个数</td>
			                    <td colspan=""5"">间1个数</td>
			                    <td colspan=""4"">间2个数</td>
			                    <td colspan=""3"">间3个数</td>
			                    <td colspan=""2"">间4个数</td>
			                    <td colspan=""2"">间5个数</td>
			                    <td colspan=""2"">间6个数</td>
		                    </tr>
		                    <tr class=""headfoot"">
			                    <td class=""equalwidth"">01</td>
			                    <td class=""equalwidth"">02</td>
			                    <td class=""equalwidth"">03</td>
			                    <td class=""equalwidth"">04</td>
			                    <td class=""equalwidth"">05</td>
			                    <td class=""equalwidth"">06</td>
			                    <td class=""equalwidth"">07</td>
			                    <td class=""equalwidth"">08</td>
			                    <td class=""equalwidth"">09</td>
			                    <td class=""equalwidth"">10</td>
			                    <td class=""equalwidth"">11</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
		                    </tr>
    
            ", d1, d2, d3, d4, d5, d6, d7, d8);

            #endregion

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] swzdjjs = new int[] { 0, 0, 0, 0, 0, 0, 0 };

            int[] j0s = new int[] { 0, 0, 0, 0, 0 };
            int[] j1s = new int[] { 0, 0, 0, 0, 0 };
            int[] j2s = new int[] { 0, 0, 0, 0 };
            int[] j3s = new int[] { 0, 0, 0 };
            int[] j4s = new int[] { 0, 0 };
            int[] j5s = new int[] { 0, 0 };
            int[] j6s = new int[] { 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                for (int ii = 1; ii <= 11; ii++)
                {

                    if (Array.IndexOf<int>(lottery.GetArray(), ii) == -1)
                    {
                        preExistCount[ii - 1]++;
                        lotteryNumExit[ii - 1] = false;
                    }
                    else
                    {
                        preExistCount[ii - 1] = 0;
                        lotteryNumExit[ii - 1] = true;
                    }
                }

                int maxJJ = lottery.GetShouWeiZuiDaJJ();

                for (int ii = 0; ii <= 6; ii++)
                {
                    if (ii == maxJJ)
                    {
                        swzdjjs[ii] = 0;
                    }
                    else
                    {
                        swzdjjs[ii]++;
                    }

                }


                int[] skips = lottery.GetJianGeCount();

                #region 0
                for (int ii = 0; ii <= 4; ii++)
                {
                    if (skips[0] == ii)
                    {
                        j0s[ii] = 0;
                    }
                    else
                    {
                        j0s[ii]++;
                    }
                }
                #endregion

                #region 1
                for (int ii = 0; ii <= 4; ii++)
                {
                    if (skips[1] == ii)
                    {
                        j1s[ii] = 0;
                    }
                    else
                    {
                        j1s[ii]++;
                    }
                }
                #endregion

                #region 2
                for (int ii = 0; ii <= 3; ii++)
                {
                    if (skips[2] == ii)
                    {
                        j2s[ii] = 0;
                    }
                    else
                    {
                        j2s[ii]++;
                    }
                }
                #endregion

                #region 3
                for (int ii = 0; ii <= 2; ii++)
                {
                    if (skips[3] == ii)
                    {
                        j3s[ii] = 0;
                    }
                    else
                    {
                        j3s[ii]++;
                    }
                }
                #endregion

                #region 4
                for (int ii = 0; ii <= 1; ii++)
                {
                    if (skips[4] == ii)
                    {
                        j4s[ii] = 0;
                    }
                    else
                    {
                        j4s[ii]++;
                    }
                }
                #endregion

                #region 5
                for (int ii = 0; ii <= 1; ii++)
                {
                    if (skips[5] == ii)
                    {
                        j5s[ii] = 0;
                    }
                    else
                    {
                        j5s[ii]++;
                    }
                }
                #endregion

                #region 6
                for (int ii = 0; ii <= 1; ii++)
                {
                    if (skips[6] == ii)
                    {
                        j6s[ii] = 0;
                    }
                    else
                    {
                        j6s[ii]++;
                    }
                }
                #endregion



                html += string.Format(@"
                       <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont"">{1}</td>
			            <td class=""middledata redballfont"">{2}</td>
			            <td class=""middledata redballfont"">{3}</td>
			            <td class=""middledata redballfont"">{4}</td>
			            <td class=""middledata redballfont"">{5}</td>
			            <td {47}>{6}</td>
			            <td {48}>{7}</td>
			            <td {49}>{8}</td>
			            <td {50}>{9}</td>
			            <td {51}>{10}</td>
			            <td {52}>{11}</td>
			            <td {53}>{12}</td>
			            <td {54}>{13}</td>
			            <td {55}>{14}</td>
			            <td {56}>{15}</td>
			            <td {57}>{16}</td>
			            <td {58}>{17}</td>
			            <td {59}>{18}</td>
			            <td {60}>{19}</td>
			            <td {61}>{20}</td>
			            <td {62}>{21}</td>
			            <td {63}>{22}</td>
			            <td {64}>{23}</td>
			            <td {65}>{24}</td>
			            <td {66}>{25}</td>
			            <td {67}>{26}</td>
			            <td {68}>{27}</td>
			            <td {69}>{28}</td>
			            <td {70}>{29}</td>
			            <td {71}>{30}</td>
			            <td {72}>{31}</td>
			            <td {73}>{32}</td>
			            <td {74}>{33}</td>
			            <td {75}>{34}</td>
			            <td {76}>{35}</td>
			            <td {77}>{36}</td>
			            <td {78}>{37}</td>
			            <td {79}>{38}</td>
			            <td {80}>{39}</td>
			            <td {81}>{40}</td>
			            <td {82}>{41}</td>
			            <td {83}>{42}</td>
			            <td {84}>{43}</td>
			            <td {85}>{44}</td>
			            <td {86}>{45}</td>
			            <td {87}>{46}</td>
		            </tr>
		
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                    lotteryNumExit[0] ? "01" : preExistCount[0].ToString(),  //6
                    lotteryNumExit[1] ? "02" : preExistCount[1].ToString(),  //7
                    lotteryNumExit[2] ? "03" : preExistCount[2].ToString(),  //8
                    lotteryNumExit[3] ? "04" : preExistCount[3].ToString(),  //9
                    lotteryNumExit[4] ? "05" : preExistCount[4].ToString(),  //10
                    lotteryNumExit[5] ? "06" : preExistCount[5].ToString(),  //11
                    lotteryNumExit[6] ? "07" : preExistCount[6].ToString(),   //12
                    lotteryNumExit[7] ? "08" : preExistCount[7].ToString(),   //13
                    lotteryNumExit[8] ? "09" : preExistCount[8].ToString(),  //14
                    lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), // 15
                    lotteryNumExit[10] ? "11" : preExistCount[10].ToString(), //16
                    maxJJ == 0 ? "0" : swzdjjs[0].ToString(),
                    maxJJ == 1 ? "1" : swzdjjs[1].ToString(),
                    maxJJ == 2 ? "2" : swzdjjs[2].ToString(),
                    maxJJ == 3 ? "3" : swzdjjs[3].ToString(),
                    maxJJ == 4 ? "4" : swzdjjs[4].ToString(),
                    maxJJ == 5 ? "5" : swzdjjs[5].ToString(),
                    maxJJ == 6 ? "6" : swzdjjs[6].ToString(),
                    skips[0] == 0 ? "0" : j0s[0].ToString(),
                    skips[0] == 1 ? "1" : j0s[1].ToString(),
                    skips[0] == 2 ? "2" : j0s[2].ToString(),
                    skips[0] == 3 ? "3" : j0s[3].ToString(),
                    skips[0] == 4 ? "4" : j0s[4].ToString(),
                    skips[1] == 0 ? "0" : j1s[0].ToString(),
                    skips[1] == 1 ? "1" : j1s[1].ToString(),
                    skips[1] == 2 ? "2" : j1s[2].ToString(),
                    skips[1] == 3 ? "3" : j1s[3].ToString(),
                    skips[1] == 4 ? "4" : j1s[4].ToString(),
                    skips[2] == 0 ? "0" : j2s[0].ToString(),
                    skips[2] == 1 ? "1" : j2s[1].ToString(),
                    skips[2] == 2 ? "2" : j2s[2].ToString(),
                    skips[2] == 3 ? "3" : j2s[3].ToString(),
                    skips[3] == 0 ? "0" : j3s[0].ToString(),
                    skips[3] == 1 ? "1" : j3s[1].ToString(),
                    skips[3] == 2 ? "2" : j3s[2].ToString(),
                    skips[4] == 0 ? "0" : j4s[0].ToString(),
                    skips[4] == 1 ? "1" : j4s[1].ToString(),
                    skips[5] == 0 ? "0" : j5s[0].ToString(),
                    skips[5] == 1 ? "1" : j5s[1].ToString(),
                    skips[6] == 0 ? "0" : j6s[0].ToString(),
                    skips[6] == 1 ? "1" : j6s[1].ToString(),

                    lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", //24
                    lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""", //25
                    lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""", //26
                    lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""", //27
                    lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""", //28
                    lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""", //29
                    lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""", //30
                    lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""", //31
                    lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""", //32
                    lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //33
                    lotteryNumExit[10] ? @"class=""redball""" : @"class=""grayfont""",  //34

                    maxJJ == 0 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 1 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 2 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 3 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 4 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 5 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    maxJJ == 6 ? @"class=""eblueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",

                     skips[0] == 0 ? @"class=""eredball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[0] == 1 ? @"class=""eredball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[0] == 2 ? @"class=""eredball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[0] == 3 ? @"class=""eredball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[0] == 4 ? @"class=""eredball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",

                     skips[1] == 0 ? @"class=""eblueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[1] == 1 ? @"class=""eblueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[1] == 2 ? @"class=""eblueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[1] == 3 ? @"class=""eblueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[1] == 4 ? @"class=""eblueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",

                    skips[2] == 0 ? @"class=""eredball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[2] == 1 ? @"class=""eredball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[2] == 2 ? @"class=""eredball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[2] == 3 ? @"class=""eredball"" id=""d4" + i.ToString() + @"""" : @"class=""grayfont""",

                    skips[3] == 0 ? @"class=""eblueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[3] == 1 ? @"class=""eblueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[3] == 2 ? @"class=""eblueball middledata"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont middledata""",

                    skips[4] == 0 ? @"class=""redball"" id=""d6" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[4] == 1 ? @"class=""redball"" id=""d6" + i.ToString() + @"""" : @"class=""grayfont""",

                     skips[5] == 0 ? @"class=""eblueball middledata"" id=""d7" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                    skips[5] == 1 ? @"class=""eblueball middledata"" id=""d7" + i.ToString() + @"""" : @"class=""grayfont middledata""",

                    skips[6] == 0 ? @"class=""eredball"" id=""d8" + i.ToString() + @"""" : @"class=""grayfont""",
                    skips[6] == 1 ? @"class=""eredball"" id=""d8" + i.ToString() + @"""" : @"class=""grayfont"""

                 );
            }

            html += @"
                	     <tr  class=""headfoot"">
			                <td rowspan=""2"" colspan=""6"">提交选择</td>
			                <td class=""unclk"">01</td>
			                <td class=""unclk"">02</td>
			                <td class=""unclk"">03</td>
			                <td class=""unclk"">04</td>
			                <td class=""unclk"">05</td>
			                <td class=""unclk"">06</td>
			                <td class=""unclk"">07</td>
			                <td class=""unclk"">08</td>
			                <td class=""unclk"">09</td>
			                <td class=""unclk"">10</td>
			                <td class=""unclk"">11</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">5</td>
			                <td class=""unclk"">6</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">4</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""11"">开奖号码分布图</td>
			                <td colspan=""7"">首尾最大间距</td>
			                <td colspan=""5"">间0个数</td>
			                <td colspan=""5"">间1个数</td>
			                <td colspan=""4"">间2个数</td>
			                <td colspan=""3"">间3个数</td>
			                <td colspan=""2"">间4个数</td>
			                <td colspan=""2"">间5个数</td>
			                <td colspan=""2"">间6个数</td>
		                </tr >
		
		
	                </table>
                </body>
                </html>

                ";

            return html;
        }
        #endregion

        #region 隔位两码合
        public static string GetHtmlGWLMHZouShi(List<Lottery> lotterys, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";

            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                    <html lang=""en"">
                    <head>
	                    <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                    <title></title>
	                    <style type=""text/css"">
		                    .headfoot{{
			                    background-color:rgb(245,234,190);
			                    font:normal 20px arial,sans-serif;
		                    }}

		                    table, tr, td{{ 
			                    border-collapse: collapse;
			                    border:1px solid black;
		                    }}

		                    td{{
			                    height: 32px;
		                    }}

		                    table{{
			                    width: 1600px; 
			                    text-align:center;
                                margin:auto;
		                    }}

		                    .redballfont{{
			                    color:red;
		                    }}

		                    td.equalwidth{{
			                    width: 32px;
		                    }}

                            .eblackball{{
			                    background-image: url(image/qblack.png);
			                    background-repeat: no-repeat;
			                    color: black;
			                    font-weight: bold;
			                    background-position:center center;
                            }}

		                    .redball{{
			                    background-image: url(image/ball_red.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}
		
		                    .blueball{{
			                    background-image: url(image/ball_bule.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}   

 td.grayfont{{
	color:gray;
}}
	

                         .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                    .eredball{{
			                    background-image: url(image/qred.png);
			                    background-repeat: no-repeat;
			                    color: red;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}

		                    .eblueball{{
			                    background-image: url(image/qbule.png);
			                    background-repeat: no-repeat;
			                    color: blue;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}                

		                    .middledata{{
			                    background-color:rgb(249,242,223);
		                    }}
	                    </style>
                <script type=""text/javascript"" src=""jq142.js""></script>
	            <script type=""text/javascript"" src=""drawline.js""></script>
                <script type=""text/javascript"">
                      function drawlines(){{      
                        DrawLine_blue(""{0}"",""19"", ""4"");                        
                        DrawLine(""{1}"",""19"", ""4"");
                        DrawLine_blue(""{2}"",""19"", ""4"");
                        }}
                        
                    $(document).ready(function(){{
                        drawlines();
                    }});
                            
                        
						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});
                </script>
                <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                    </head>
                    <body>
	                    <table>
		                    <tr class=""headfoot"">
			                    <td rowspan=""2"" style=""width:6.3%"">期号</td>
			                    <td rowspan=""2"" colspan=""5"" style=""width:9.4%"">开奖号码</td>
			                    <td colspan=""10"">隔位两码合分布图</td>
			                    <td colspan=""10"">第一位</td>
			                    <td colspan=""10"">第二位</td>
			                    <td colspan=""10"">第三位</td>
		                    </tr>
		                    <tr class=""headfoot"">
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">9</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">9</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">9</td>
			                    <td class=""equalwidth"">0</td>
			                    <td class=""equalwidth"">1</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">9</td>
		                    </tr>
    
            ", d1, d2, d3);
            #endregion

            int[] gwhfb = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            string html = top;

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int[] gwhs = lottery.GetGeWeiHe();

                for (int ii = 0; ii < gwhfb.Length; ii++)
                {
                    gwhfb[ii]++;
                }

                foreach (int n in gwhfb)
                {
                    gwhfb[n] = 0;
                }


                #region 1
                for (int ii = 0; ii <= 9; ii++)
                {
                    if (ii == gwhs[0])
                    {
                        f1[ii] = 0;
                    }
                    else
                    {
                        f1[ii]++;
                    }
                }
                #endregion

                #region 2
                for (int ii = 0; ii <= 9; ii++)
                {
                    if (ii == gwhs[1])
                    {
                        f2[ii] = 0;
                    }
                    else
                    {
                        f2[ii]++;
                    }
                }
                #endregion

                #region 3
                for (int ii = 0; ii <= 9; ii++)
                {
                    if (ii == gwhs[2])
                    {
                        f3[ii] = 0;
                    }
                    else
                    {
                        f3[ii]++;
                    }
                }
                #endregion


                Array.Sort(gwhs, 0, 3);

                html += string.Format(@"
		            <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont"">{1}</td>
			            <td class=""middledata redballfont"">{2}</td>
			            <td class=""middledata redballfont"">{3}</td>
			            <td class=""middledata redballfont"">{4}</td>
			            <td class=""middledata redballfont"">{5}</td>
			            <td {46}>{6}</td>
			            <td {47}>{7}</td>
			            <td {48}>{8}</td>
			            <td {49}>{9}</td>
			            <td {50}>{10}</td>
			            <td {51}>{11}</td>
			            <td {52}>{12}</td>
			            <td {53}>{13}</td>
			            <td {54}>{14}</td>
			            <td {55}>{15}</td>
			            <td {56}>{16}</td>
			            <td {57}>{17}</td>
			            <td {58}>{18}</td>
			            <td {59}>{19}</td>
			            <td {60}>{20}</td>
			            <td {61}>{21}</td>
			            <td {62}>{22}</td>
			            <td {63}>{23}</td>
			            <td {64}>{24}</td>
			            <td {65}>{25}</td>
			            <td {66}>{26}</td>
			            <td {67}>{27}</td>
			            <td {68}>{28}</td>
			            <td {69}>{29}</td>
			            <td {70}>{30}</td>
			            <td {71}>{31}</td>
			            <td {72}>{32}</td>
			            <td {73}>{33}</td>
			            <td {74}>{34}</td>
			            <td {75}>{35}</td>
			            <td {76}>{36}</td>
			            <td {77}>{37}</td>
			            <td {78}>{38}</td>
			            <td {79}>{39}</td>
			            <td {80}>{40}</td>
			            <td {81}>{41}</td>
			            <td {82}>{42}</td>
			            <td {83}>{43}</td>
			            <td {84}>{44}</td>
			            <td {85}>{45}</td>
		            </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                     gwhs.Contains<int>(0) ? "0" : gwhfb[0].ToString(),
                     gwhs.Contains<int>(1) ? "1" : gwhfb[1].ToString(),
                     gwhs.Contains<int>(2) ? "2" : gwhfb[2].ToString(),
                     gwhs.Contains<int>(3) ? "3" : gwhfb[3].ToString(),
                     gwhs.Contains<int>(4) ? "4" : gwhfb[4].ToString(),
                     gwhs.Contains<int>(5) ? "5" : gwhfb[5].ToString(),
                     gwhs.Contains<int>(6) ? "6" : gwhfb[6].ToString(),
                     gwhs.Contains<int>(7) ? "7" : gwhfb[7].ToString(),
                     gwhs.Contains<int>(8) ? "8" : gwhfb[8].ToString(),
                     gwhs.Contains<int>(9) ? "9" : gwhfb[9].ToString(),
                     gwhs[0] == 0 ? "0" : f1[0].ToString(),
                     gwhs[0] == 1 ? "1" : f1[1].ToString(),
                     gwhs[0] == 2 ? "2" : f1[2].ToString(),
                     gwhs[0] == 3 ? "3" : f1[3].ToString(),
                     gwhs[0] == 4 ? "4" : f1[4].ToString(),
                     gwhs[0] == 5 ? "5" : f1[5].ToString(),
                     gwhs[0] == 6 ? "6" : f1[6].ToString(),
                     gwhs[0] == 7 ? "7" : f1[7].ToString(),
                     gwhs[0] == 8 ? "8" : f1[8].ToString(),
                     gwhs[0] == 9 ? "9" : f1[9].ToString(),
                     gwhs[1] == 0 ? "0" : f2[0].ToString(),
                     gwhs[1] == 1 ? "1" : f2[1].ToString(),
                     gwhs[1] == 2 ? "2" : f2[2].ToString(),
                     gwhs[1] == 3 ? "3" : f2[3].ToString(),
                     gwhs[1] == 4 ? "4" : f2[4].ToString(),
                     gwhs[1] == 5 ? "5" : f2[5].ToString(),
                     gwhs[1] == 6 ? "6" : f2[6].ToString(),
                     gwhs[1] == 7 ? "7" : f2[7].ToString(),
                     gwhs[1] == 8 ? "8" : f2[8].ToString(),
                     gwhs[1] == 9 ? "9" : f2[9].ToString(),
                     gwhs[2] == 0 ? "0" : f3[0].ToString(),
                     gwhs[2] == 1 ? "1" : f3[1].ToString(),
                     gwhs[2] == 2 ? "2" : f3[2].ToString(),
                     gwhs[2] == 3 ? "3" : f3[3].ToString(),
                     gwhs[2] == 4 ? "4" : f3[4].ToString(),
                     gwhs[2] == 5 ? "5" : f3[5].ToString(),
                     gwhs[2] == 6 ? "6" : f3[6].ToString(),
                     gwhs[2] == 7 ? "7" : f3[7].ToString(),
                     gwhs[2] == 8 ? "8" : f3[8].ToString(),
                     gwhs[2] == 9 ? "9" : f3[9].ToString(),


                     gwhs.Contains<int>(0) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(1) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(2) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(3) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(4) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(5) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(6) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(7) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(8) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwhs.Contains<int>(9) ? @"class=""eblackball""" : @"class=""grayfont""",

                     gwhs[0] == 0 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 1 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 5 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 6 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 7 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 8 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[0] == 9 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                      gwhs[1] == 0 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 1 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 2 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 3 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 4 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 5 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 6 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 7 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 8 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwhs[1] == 9 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",

                      gwhs[2] == 0 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 1 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 2 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 3 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 4 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 5 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 6 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 7 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 8 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                     gwhs[2] == 9 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont"""


                    );

            }

            html += @"
		            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
		            </tr>
		            <tr  class=""headfoot"">
			            <td colspan=""10"">隔位两码合分布图</td>
			            <td colspan=""10"">第一位</td>
			            <td colspan=""10"">第二位</td>
			            <td colspan=""10"">第三位</td>
		            </tr>
	            </table>
            </body>
            </html>
            ";


            return html;
        }

        #endregion

        #region 隔位两码差
        public static string GetHtmlGWLMCZouShi(List<Lottery> lotterys, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";


            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                    <html lang=""en"">
                    <head>
	                    <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                    <title></title>
	                    <style type=""text/css"">
		                    .headfoot{{
			                    background-color:rgb(245,234,190);
			                    font:normal 20px arial,sans-serif;
		                    }}

		                    table, tr, td{{ 
			                    border-collapse: collapse;
			                    border:1px solid black;
		                    }}

		                    td{{
			                    height: 32px;
		                    }}

		                    table{{
			                    width: 1300px; 
			                    text-align:center;
                                margin:auto;
		                    }}

                            .eblackball{{
			                    background-image: url(image/qblack.png);
			                    background-repeat: no-repeat;
			                    color: black;
			                    font-weight: bold;
			                    background-position:center center;
                            }}
		                    .redballfont{{
			                    color:red;
		                    }}

                             td.grayfont{{
	                            color:gray;
                            }}

		                    td.equalwidth{{
			                    width: 32px;
		                    }}

		                    .redball{{
			                    background-image: url(image/ball_red.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}
		                .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}      
		                    .blueball{{
			                    background-image: url(image/ball_bule.png);
			                    background-repeat: no-repeat;
			                    color: white;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}   


		                    .eredball{{
			                    background-image: url(image/qred.png);
			                    background-repeat: no-repeat;
			                    color: red;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}

		                    .eblueball{{
			                    background-image: url(image/qbule.png);
			                    background-repeat: no-repeat;
			                    color: blue;
			                    font-weight: bold;
			                    background-position:center center;
		                    }}                

		                    .middledata{{
			                    background-color:rgb(249,242,223);
		                    }}
	                    </style>
                        <script type=""text/javascript"" src=""jq142.js""></script>
	                    <script type=""text/javascript"" src=""drawline.js""></script>
                        <script type=""text/javascript"">
                            function drawlines(){{
                                DrawLine_blue(""{0}"",""19"", ""4"");                        
                                DrawLine(""{1}"",""19"", ""4"");
                                DrawLine_blue(""{2}"",""19"", ""4"");
                            }}
                            $(document).ready(function(){{
                                drawlines();
                            }});
						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});

                        </script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                            document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                    </head>
                    <body>
	                    <table>
		                    <tr class=""headfoot"">
			                    <td rowspan=""2"" style=""width:7.8%"">期号</td>
			                    <td rowspan=""2"" colspan=""5"" style=""width:11.5%"">开奖号码</td>
			                    <td colspan=""7"">隔位两码差分布图</td>
			                    <td colspan=""7"">第一位</td>
			                    <td colspan=""7"">第二位</td>
			                    <td colspan=""7"">第三位</td>
		                    </tr>
		                    <tr class=""headfoot"">
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
			                    <td class=""equalwidth"">2</td>
			                    <td class=""equalwidth"">3</td>
			                    <td class=""equalwidth"">4</td>
			                    <td class=""equalwidth"">5</td>
			                    <td class=""equalwidth"">6</td>
			                    <td class=""equalwidth"">7</td>
			                    <td class=""equalwidth"">8</td>
		                    </tr>
    
            ", d1, d2, d3);
            #endregion

            int[] gwhfb = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] f3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };


            string html = top;

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int[] gwcs = lottery.GetGeWeiCha();

                for (int ii = 0; ii < gwhfb.Length; ii++)
                {
                    gwhfb[ii]++;
                }

                foreach (int n in gwhfb)
                {
                    gwhfb[n] = 0;
                }


                #region 1
                for (int ii = 2; ii <= 8; ii++)
                {
                    if (ii == gwcs[0])
                    {
                        f1[ii - 2] = 0;
                    }
                    else
                    {
                        f1[ii - 2]++;
                    }
                }
                #endregion

                #region 2
                for (int ii = 2; ii <= 8; ii++)
                {
                    if (ii == gwcs[1])
                    {
                        f2[ii - 2] = 0;
                    }
                    else
                    {
                        f2[ii - 2]++;
                    }
                }
                #endregion

                #region 3
                for (int ii = 2; ii <= 8; ii++)
                {
                    if (ii == gwcs[2])
                    {
                        f3[ii - 2] = 0;
                    }
                    else
                    {
                        f3[ii - 2]++;
                    }
                }
                #endregion


                Array.Sort(gwcs, 0, 3);

                html += string.Format(@"
		            <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont"">{1}</td>
			            <td class=""middledata redballfont"">{2}</td>
			            <td class=""middledata redballfont"">{3}</td>
			            <td class=""middledata redballfont"">{4}</td>
			            <td class=""middledata redballfont"">{5}</td>
			            <td {34}>{6}</td>
			            <td {35}>{7}</td>
			            <td {36}>{8}</td>
			            <td {37}>{9}</td>
			            <td {38}>{10}</td>
			            <td {39}>{11}</td>
			            <td {40}>{12}</td>
			            <td {41}>{13}</td>
			            <td {42}>{14}</td>
			            <td {43}>{15}</td>
			            <td {44}>{16}</td>
			            <td {45}>{17}</td>
			            <td {46}>{18}</td>
			            <td {47}>{19}</td>
			            <td {48}>{20}</td>
			            <td {49}>{21}</td>
			            <td {50}>{22}</td>
			            <td {51}>{23}</td>
			            <td {52}>{24}</td>
			            <td {53}>{25}</td>
			            <td {54}>{26}</td>
			            <td {55}>{27}</td>
			            <td {56}>{28}</td>
			            <td {57}>{29}</td>
			            <td {58}>{30}</td>
			            <td {59}>{31}</td>
			            <td {60}>{32}</td>
			            <td {61}>{33}</td>
		            </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),// 0 - 5
                     gwcs.Contains<int>(2) ? "2" : gwhfb[2].ToString(),
                     gwcs.Contains<int>(3) ? "3" : gwhfb[3].ToString(),
                     gwcs.Contains<int>(4) ? "4" : gwhfb[4].ToString(),
                     gwcs.Contains<int>(5) ? "5" : gwhfb[5].ToString(),
                     gwcs.Contains<int>(6) ? "6" : gwhfb[6].ToString(),
                     gwcs.Contains<int>(7) ? "7" : gwhfb[7].ToString(),
                     gwcs.Contains<int>(8) ? "8" : gwhfb[8].ToString(),
                     gwcs[0] == 2 ? "2" : f1[0].ToString(),
                     gwcs[0] == 3 ? "3" : f1[1].ToString(),
                     gwcs[0] == 4 ? "4" : f1[2].ToString(),
                     gwcs[0] == 5 ? "5" : f1[3].ToString(),
                     gwcs[0] == 6 ? "6" : f1[4].ToString(),
                     gwcs[0] == 7 ? "7" : f1[5].ToString(),
                     gwcs[0] == 8 ? "8" : f1[6].ToString(),
                     gwcs[1] == 2 ? "2" : f2[0].ToString(),
                     gwcs[1] == 3 ? "3" : f2[1].ToString(),
                     gwcs[1] == 4 ? "4" : f2[2].ToString(),
                     gwcs[1] == 5 ? "5" : f2[3].ToString(),
                     gwcs[1] == 6 ? "6" : f2[4].ToString(),
                     gwcs[1] == 7 ? "7" : f2[5].ToString(),
                     gwcs[1] == 8 ? "8" : f2[6].ToString(),
                     gwcs[2] == 2 ? "2" : f3[0].ToString(),
                     gwcs[2] == 3 ? "3" : f3[1].ToString(),
                     gwcs[2] == 4 ? "4" : f3[2].ToString(),
                     gwcs[2] == 5 ? "5" : f3[3].ToString(),
                     gwcs[2] == 6 ? "6" : f3[4].ToString(),
                     gwcs[2] == 7 ? "7" : f3[5].ToString(),
                     gwcs[2] == 8 ? "8" : f3[6].ToString(),


                     gwcs.Contains<int>(2) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(3) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(4) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(5) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(6) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(7) ? @"class=""eblackball""" : @"class=""grayfont""",
                     gwcs.Contains<int>(8) ? @"class=""eblackball""" : @"class=""grayfont""",

                     gwcs[0] == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 5 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 6 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 7 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[0] == 8 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont middledata""",

                     gwcs[1] == 2 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 3 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 4 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 5 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 6 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 7 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                     gwcs[1] == 8 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",

                      gwcs[2] == 2 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 3 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 4 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 5 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 6 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 7 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata""",
                     gwcs[2] == 8 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont middledata"""
                    );

            }

            html += @"
		            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
			            			                    <td>2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
			                    <td class=""unclk"">2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
			                    <td class=""unclk"">2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
			                    <td class=""unclk"">2</td>
			                    <td class=""unclk"">3</td>
			                    <td class=""unclk"">4</td>
			                    <td class=""unclk"">5</td>
			                    <td class=""unclk"">6</td>
			                    <td class=""unclk"">7</td>
			                    <td class=""unclk"">8</td>
		            </tr>
		            <tr  class=""headfoot"">
			                    <td colspan=""7"">隔位两码差分布图</td>
			                    <td colspan=""7"">第一位</td>
			                    <td colspan=""7"">第二位</td>
			                    <td colspan=""7"">第三位</td>
		            </tr>
	            </table>
            </body>
            </html>
            ";


            return html;
        }

        #endregion      

        #region 智能值走势
        public static string GetHtmlZhinengZhiZouShi(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";
            string d2 = "";
            string d3 = "";
            string d4 = "";
            string d5 = "";

            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
                d4 += "d4" + i.ToString() + ",";
                d5 += "d5" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);
            d4 = d4.Substring(0, d4.Length - 1);
            d5 = d5.Substring(0, d5.Length - 1);

            #region TOP
            string top = string.Format(@"
                <!DOCTYPE HTML PUBLIC """"-//W3C//DTD HTML 4.01//EN"""" """"http://www.w3.org/TR/html4/strict.dtd"""">
                <html lang=""""en"""">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>定位走势图</title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

		                table{{
			                width: 1600px; 
			                text-align:center;
                            margin:auto;
		                }}

		                .redballfont{{
			                color:red;
		                }}

		                td.equalwidth{{
			                width: 32px;
		                }}

 td.grayfont{{
	color:gray;
}}
		

		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   
                         .clk{{
					        background-color:red;
				        }}
				
				        .unclk{{
					
				        }}

		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
 <script type=""text/javascript"" src=""jq142.js""></script>
	                    <script type=""text/javascript"" src=""drawline.js""></script>
                        <script type=""text/javascript"">
                            function drawlines(){{
                                DrawLine_blue(""{0}"",""19"", ""4"");                        
                                DrawLine(""{1}"",""19"", ""4"");
                                DrawLine_blue(""{2}"",""19"", ""4"");
                                DrawLine(""{3}"",""19"", ""4"");
                                DrawLine_blue(""{4}"",""19"", ""4"");
                            }}
                            $(document).ready(function(){{
                                drawlines();
                            }});
						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});

                        </script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:6.3%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:9.4%"">开奖号码</td>
			                <td colspan=""10"">智能A走势</td>
			                <td colspan=""10"">智能B走势</td>
			                <td colspan=""8"">智能C走势</td>
			                <td colspan=""6"">智能D走势</td>
			                <td colspan=""5"">智能E走势</td>
		                </tr>
		
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">8</td>
			                <td class=""equalwidth"">9</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">8</td>
			                <td class=""equalwidth"">9</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">6</td>
			                <td class=""equalwidth"">7</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
		                </tr>
            ", d1,d2,d3,d4,d5);
            #endregion;

            string html = top;

            int[] ass = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] bss = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] css = new int[] { 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] dss = new int[] { 0, 0, 0, 0, 0, 0 };
            int[] ess = new int[] { 0, 0, 0, 0, 0 };

            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                int ai_a = lottery.GetAI_A();
                int ai_b = lottery.GetAI_B();
                int ai_c = lottery.GetAI_C();
                int ai_d = lottery.GetAI_D();
                int ai_e = lottery.GetAI_E();

                for (int ii = 0; ii <= 9; ii++)
                {
                    if (ii == ai_a)
                    {
                        ass[ii] = 0;
                    }
                    else
                    {
                        ass[ii]++;
                    }

                    if (ii == ai_b)
                    {
                        bss[ii] = 0;
                    }
                    else
                    {
                        bss[ii]++;
                    }



                    if (ii <= 7)
                    {
                        if (ii == ai_c)
                        {
                            css[ii] = 0;
                        }
                        else
                        {
                            css[ii]++;
                        }

                        if (ii <= 5)
                        {
                            if (ii == ai_d)
                            {
                                dss[ii] = 0;
                            }
                            else
                            {
                                dss[ii]++;
                            }

                            if (ii <= 4)
                            {

                                if (ii == ai_e)
                                {
                                    ess[ii] = 0;
                                }
                                else
                                {
                                    ess[ii]++;
                                }
                            }
                        }
                    }

                }




                html += string.Format(@"
		                <tr>
			                <td>{0}</td>
			                <td class=""middledata redballfont"">{1}</td>
			                <td class=""middledata redballfont"">{2}</td>
			                <td class=""middledata redballfont"">{3}</td>
			                <td class=""middledata redballfont"">{4}</td>
			                <td class=""middledata redballfont"">{5}</td>
			                <td {45}>{6}</td>
			                <td {46}>{7}</td>
			                <td {47}>{8}</td>
			                <td {48}>{9}</td>
			                <td {49}>{10}</td>
			                <td {50}>{11}</td>
			                <td {51}>{12}</td>
			                <td {52}>{13}</td>
			                <td {53}>{14}</td>
			                <td {54}>{15}</td>
			                <td {55}>{16}</td>
			                <td {56}>{17}</td>
			                <td {57}>{18}</td>
			                <td {58}>{19}</td>
			                <td {59}>{20}</td>
			                <td {60}>{21}</td>
			                <td {61}>{22}</td>
			                <td {62}>{23}</td>
			                <td {63}>{24}</td>
			                <td {64}>{25}</td>
			                <td {65}>{26}</td>
			                <td {66}>{27}</td>
			                <td {67}>{28}</td>
			                <td {68}>{29}</td>
			                <td {69}>{30}</td>
			                <td {70}>{31}</td>
			                <td {71}>{32}</td>
			                <td {72}>{33}</td>
			                <td {73}>{34}</td>
			                <td {74}>{35}</td>
			                <td {75}>{36}</td>
			                <td {76}>{37}</td>
			                <td {77}>{38}</td>
			                <td {78}>{39}</td>
			                <td {79}>{40}</td>
			                <td {80}>{41}</td>
			                <td {81}>{42}</td>
			                <td {82}>{43}</td>
			                <td {83}>{44}</td>
		                </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),
                ai_a == 0 ? "0" : ass[0].ToString(),
                ai_a == 1 ? "1" : ass[1].ToString(),
                ai_a == 2 ? "2" : ass[2].ToString(),
                ai_a == 3 ? "3" : ass[3].ToString(),
                ai_a == 4 ? "4" : ass[4].ToString(),
                ai_a == 5 ? "5" : ass[5].ToString(),
                ai_a == 6 ? "6" : ass[6].ToString(),
                ai_a == 7 ? "7" : ass[7].ToString(),
                ai_a == 8 ? "8" : ass[8].ToString(),
                ai_a == 9 ? "9" : ass[9].ToString(),
                ai_b == 0 ? "0" : bss[0].ToString(),
                ai_b == 1 ? "1" : bss[0].ToString(),
                ai_b == 2 ? "2" : bss[0].ToString(),
                ai_b == 3 ? "3" : bss[0].ToString(),
                ai_b == 4 ? "4" : bss[0].ToString(),
                ai_b == 5 ? "5" : bss[0].ToString(),
                ai_b == 6 ? "6" : bss[0].ToString(),
                ai_b == 7 ? "7" : bss[0].ToString(),
                ai_b == 8 ? "8" : bss[0].ToString(),
                ai_b == 9 ? "9" : bss[0].ToString(),
                ai_c == 0?"0":css[0].ToString(),
                ai_c == 1?"1":css[1].ToString(),
                ai_c == 2?"2":css[2].ToString(),
                ai_c == 3?"3":css[3].ToString(),
                ai_c == 4?"4":css[4].ToString(),
                ai_c == 5?"5":css[5].ToString(),
                ai_c == 6?"6":css[6].ToString(),
                ai_c == 7?"7":css[7].ToString(),

                ai_d == 0?"0":dss[0].ToString(),
                ai_d == 1?"1":dss[1].ToString(),
                ai_d == 2?"2":dss[2].ToString(),
                ai_d == 3?"3":dss[3].ToString(),
                ai_d == 4?"4":dss[4].ToString(),
                ai_d == 5?"5":dss[5].ToString(),


                ai_e == 0?"0":ess[0].ToString(),
                ai_e == 1?"1":ess[1].ToString(),
                ai_e == 2?"2":ess[2].ToString(),
                ai_e == 3?"3":ess[3].ToString(),
                ai_e == 4?"4":ess[4].ToString(),

                ai_a == 0 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 1 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 2 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 3 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 4 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 5 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 6 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 7 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 8 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_a == 9 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",

                  ai_b == 0 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 1 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 2 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 3 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 4 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 5 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 6 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 7 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 8 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_b == 9 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                                  ai_c == 0 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 1 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 2 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 3 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 4 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 5 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 6 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_c == 7 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",

                                  ai_d == 0 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_d == 1 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_d == 2 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_d == 3 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_d == 4 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                  ai_d == 5 ? @"class=""redball middledata"" id=""d4" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                                  ai_e == 0 ? @"class=""blueball"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_e == 1 ? @"class=""blueball"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_e == 2 ? @"class=""blueball"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_e == 3 ? @"class=""blueball"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_e == 4 ? @"class=""blueball"" id=""d5" + i.ToString() + @"""" : @"class=""grayfont"""


                 );
            }

            html += @"	
		            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
						            <td>0</td>
			            <td  class=""unclk"">1</td>
			            <td  class=""unclk"">2</td>
			            <td  class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">8</td>
			            <td class=""unclk"">9</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">6</td>
			            <td class=""unclk"">7</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
			            <td class=""unclk"">0</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
		            </tr>
		            <tr  class=""headfoot"">
			            <td colspan=""10"">智能A走势</td>
			            <td colspan=""10"">智能B走势</td>
			            <td colspan=""8"">智能C走势</td>
			            <td colspan=""6"">智能D走势</td>
			            <td colspan=""5"">智能E走势</td>
		            </tr>
	            </table>
            </body>
            </html>
            ";

            return html;

        }
        #endregion

        #region 智能数据
        public static string GetHtmlZHInengShuJUZouShi(List<Lottery> lotterys, List<string> days)
        {

            string d1 = "";

            for (int i = 0; i < lotterys.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);

            #region TOP
            string top = string.Format(@"
                 <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>定位走势图</title>
	                <style type=""text/css"">
		                .headfoot{{
			                background-color:rgb(245,234,190);
			                font:normal 20px arial,sans-serif;
		                }}

		                table, tr, td{{ 
			                border-collapse: collapse;
			                border:1px solid black;
		                }}

		                td{{
			                height: 32px;
		                }}

                        .nike{{
                            background-image: url(image/nike.png);
			                background-repeat: no-repeat;
                            background-position:center center;
                        }}

		                table{{
			                width: 1000px; 
			                text-align:center;
                            margin:auto;
		                }}

		                .redballfont{{
			                color:red;
		                }}

		                td.equalwidth{{
			                width: 32px;
		                }}

		                .redball{{
			                background-image: url(image/ball_red.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}
		
		                .blueball{{
			                background-image: url(image/ball_bule.png);
			                background-repeat: no-repeat;
			                color: white;
			                font-weight: bold;
			                background-position:center center;
		                }}   

                    .clk{{
					        background-color:red;
				        }}
				
 td.grayfont{{
	color:gray;
}}
		

				        .unclk{{
					
				        }}


		                .eredball{{
			                background-image: url(image/qred.png);
			                background-repeat: no-repeat;
			                color: red;
			                font-weight: bold;
			                background-position:center center;
		                }}

		                .eblueball{{
			                background-image: url(image/qbule.png);
			                background-repeat: no-repeat;
			                color: blue;
			                font-weight: bold;
			                background-position:center center;
		                }}                

		                .middledata{{
			                background-color:rgb(249,242,223);
		                }}
	                </style>
<script type=""text/javascript"" src=""jq142.js""></script>
	                    <script type=""text/javascript"" src=""drawline.js""></script>
                        <script type=""text/javascript"">
                            function drawlines(){{
                                DrawLine_blue(""{0}"",""19"", ""4"");                        
                            }}
                            $(document).ready(function(){{
                                drawlines();
                            }});
						jQuery(window).resize(function(){{
							$(""canvas"").remove();
							drawlines();
						}});

                        </script>
                    <script type=""text/javascript"">
					$(document).ready(function()
					{{
                        document.title =""unclk"";
					  $(""td.unclk"").click(
						function()
						{{
							if ($(this).hasClass(""clk""))
							{{
								$(this).removeClass(""clk"");
                                document.title =""clk"";
							}}
							else 
							{{
								$(this).addClass(""clk"");
                                document.title =""clk"";
							}}				
						}});
					}});
				</script>
            
                </head>
                <body>
	                <table>
		                <tr class=""headfoot"">
			                <td rowspan=""2"" style=""width:10%"">期号</td>
			                <td rowspan=""2"" colspan=""5"" style=""width:15%"">开奖号码</td>
			                <td colspan=""4"">智能A</td>
			                <td colspan=""4"">智能B</td>
			                <td colspan=""4"">智能C</td>
			                <td colspan=""4"">智能D</td>
			                <td colspan=""5"">智能值F走势</td>
		                </tr>
	
		                <tr class=""headfoot"">
			                <td  class=""equalwidth"">A1</td>
			                <td  class=""equalwidth"">A2</td>
			                <td  class=""equalwidth"">A3</td>
			                <td  class=""equalwidth"">A4</td>
			                <td class=""equalwidth"">B1</td>
			                <td class=""equalwidth"">B2</td>
			                <td  class=""equalwidth"">B3</td>
			                <td  class=""equalwidth"">B4</td>
			                <td  class=""equalwidth"">C1</td>
			                <td  class=""equalwidth"">C2</td>
			                <td  class=""equalwidth"">C3</td>
			                <td  class=""equalwidth"">C4</td>
			                <td  class=""equalwidth"">D1</td>
			                <td  class=""equalwidth"">D2</td>
			                <td  class=""equalwidth"">D3</td>
			                <td  class=""equalwidth"">D4</td>
			                <td  class=""equalwidth"">1</td>
			                <td  class=""equalwidth"">2</td>
			                <td  class=""equalwidth"">3</td>
			                <td class=""equalwidth"">4</td>
			                <td class=""equalwidth"">5</td>
		                </tr>
            ", d1);
            #endregion

            string html = top;

            int[] ass = new int[] { 0,0,0,0};
            int[] bss = new int[] { 0,0,0,0};
            int[] css = new int[] { 0, 0, 0, 0 };
            int[] dss = new int[] { 0,0,0,0};
            int[] fss = new int[] { 0,0,0,0,0};

           
            for (int i = 0; i < lotterys.Count; i++)
            {
                Lottery lottery = lotterys[i];

                List<int> a_ai= lottery.Get_AI_A();
                List<int> b_ai = lottery.Get_AI_B();
                List<int> c_ai = lottery.Get_AI_C();
                List<int> d_ai = lottery.Get_AI_D();

                int ai_f = lottery.GetAI_F();

                for (int ii = 0; ii < 4 ; ii++) {
                    if (a_ai.Contains(ii))
                    {
                        ass[ii] = 0;
                    }
                    else {
                        ass[ii]++;
                    }

                    if (b_ai.Contains(ii))
                    {
                        bss[ii] = 0;
                    }
                    else {
                        bss[ii]++;
                    }

                    if (c_ai.Contains(ii))
                    {
                        css[ii] = 0;
                    }
                    else {
                        css[ii]++;
                    }

                    if (d_ai.Contains(ii))
                    {
                        dss[ii] = 0;
                    }
                    else {
                        dss[ii]++;
                    }
                }

                for (int ii = 1; ii <= 5; ii++) {
                    if (ai_f == ii)
                    {
                        fss[ii - 1] = 0;
                    }
                    else {
                        fss[ii - 1]++;
                    }
                }

                    html += string.Format(@"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont"">{1}</td>
			            <td class=""middledata redballfont"">{2}</td>
			            <td class=""middledata redballfont"">{3}</td>
			            <td class=""middledata redballfont"">{4}</td>
			            <td class=""middledata redballfont"">{5}</td>
			            <td {27}>{6}</td>
			            <td {28}>{7}</td>
			            <td {29}>{8}</td>
			            <td {30}>{9}</td>
			            <td {31}>{10}</td>
			            <td {32}>{11}</td>
			            <td {33}>{12}</td>
			            <td {34}>{13}</td>
			            <td {35}>{14}</td>
			            <td {36}>{15}</td>
			            <td {37}>{16}</td>
			            <td {38}>{17}</td>
			            <td {39}>{18}</td>
			            <td {40}>{19}</td>
			            <td {41}>{20}</td>
			            <td {42}>{21}</td>
			            <td {43}>{22}</td>
			            <td {44}>{23}</td>
			            <td {45}>{24}</td>
			            <td {46}>{25}</td>
			            <td {47}>{26}</td>
		            </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), lottery.PreSort[3].ToString("D2"), lottery.PreSort[4].ToString("D2"),
                 a_ai.Contains(0)?"":ass[0].ToString(),
                 a_ai.Contains(1)?"":ass[1].ToString(),
                 a_ai.Contains(2)?"":ass[2].ToString(),
                 a_ai.Contains(3)?"":ass[3].ToString(),
                 b_ai.Contains(0)?"":bss[0].ToString(),
                b_ai.Contains(1)?"":bss[1].ToString(),
                b_ai.Contains(2)?"":bss[2].ToString(),
                b_ai.Contains(3)?"":bss[3].ToString(),
                c_ai.Contains(0)?"":css[0].ToString(),
                c_ai.Contains(1)?"":css[1].ToString(),
                c_ai.Contains(2)?"":css[2].ToString(),
                c_ai.Contains(3)?"":css[3].ToString(),
                                 d_ai.Contains(0)?"":dss[0].ToString(),
               d_ai.Contains(1)?"":dss[1].ToString(),
                d_ai.Contains(2)?"":dss[2].ToString(),
                d_ai.Contains(3)?"":dss[3].ToString(),
                ai_f == 0?"1":fss[0].ToString(),
                ai_f == 1?"2":fss[1].ToString(),
                ai_f == 2?"3":fss[2].ToString(),
                ai_f == 3?"4":fss[3].ToString(),
                ai_f == 4?"5":fss[4].ToString(),

               a_ai.Contains(0) ? @"class=""nike""" : @"class=""grayfont""",
               a_ai.Contains(1) ? @"class=""nike""" : @"class=""grayfont""",
               a_ai.Contains(2) ? @"class=""nike""" : @"class=""grayfont""",
               a_ai.Contains(3) ? @"class=""nike""" : @"class=""grayfont""",

                b_ai.Contains(0) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                b_ai.Contains(1) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                b_ai.Contains(2) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                b_ai.Contains(3) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",

                c_ai.Contains(0) ? @"class=""nike""" : @"class=""grayfont""",
               c_ai.Contains(1) ? @"class=""nike""" : @"class=""grayfont""",
               c_ai.Contains(2) ? @"class=""nike""" : @"class=""grayfont""",
               c_ai.Contains(3) ? @"class=""nike""" : @"class=""grayfont""",

                d_ai.Contains(0) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                d_ai.Contains(1) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                d_ai.Contains(2) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",
                d_ai.Contains(3) ? @"class=""nike middledata""" : @"class=""grayfont middledata""",

                ai_f == 0 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_f == 1 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_f == 2 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_f == 3 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                ai_f == 4 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont"""
                );
            }

            html += @"
		            <tr  class=""headfoot"">
			            <td rowspan=""2"" colspan=""6"">提交选择</td>
			            <td  class=""unclk"">A1</td>
			            <td class=""unclk"">A2</td>
			            <td class=""unclk"">A3</td>
			            <td class=""unclk"">A4</td>
			            <td class=""unclk"">B1</td>
			            <td class=""unclk"">B2</td>
			            <td class=""unclk"">B3</td>
			            <td class=""unclk"">B4</td>
			            <td class=""unclk"">C1</td>
			            <td class=""unclk"">C2</td>
			            <td class=""unclk"">C3</td>
			            <td class=""unclk"">C4</td>
			            <td class=""unclk"">D1</td>
			            <td class=""unclk"">D2</td>
			            <td class=""unclk"">D3</td>
			            <td class=""unclk"">D4</td>
			            <td class=""unclk"">1</td>
			            <td class=""unclk"">2</td>
			            <td class=""unclk"">3</td>
			            <td class=""unclk"">4</td>
			            <td class=""unclk"">5</td>
		            </tr>
		            <tr  class=""headfoot"">
			            <td colspan=""4"">智能A</td>
			            <td colspan=""4"">智能B</td>
			            <td colspan=""4"">智能C</td>
			            <td colspan=""4"">智能D</td>
			            <td colspan=""5"">智能值F走势</td>
		            </tr>
	            </table>
            </body>
            </html>

            ";

            return html;

        }
        #endregion

    }
}
