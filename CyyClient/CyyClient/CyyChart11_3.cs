using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CyyClient
{
    class CyyChart11_3
    {
        #region 基本走势图
        public static string GetHtmlJiBenZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string Top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>基本走势图</title>
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
			                <td rowspan=""2"" colspan=""3"" style=""width:6%"">开奖号码</td>
			                <td colspan=""11"">第一位</td>
			                <td colspan=""11"">第二位</td>
			                <td colspan=""11"">第三位</td>
                            <td rowspan=""2"" style=""width:3%"">平衡指数</td>
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
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
		                </tr>
            ", d1, d2, d3);
            #endregion

            string html = Top;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };


            int[] num1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] num2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] num3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //for (int i = lotterys.Count - 1; i >= 0; i--)
            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

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


                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));
                //int[] lotteryArr = lottery.GetArray();

                #region num1
                for (int ii = 1; ii <= 11; ii++)
                {
                    if (ii != lot1)
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
                for (int ii = 1; ii <= 11; ii++)
                {
                    if (ii != lot2)
                    {
                        num2[ii - 1]++;
                    }
                    else
                    {
                        num2[ii - 1] = 0;
                    }
                }
                #endregion

                #region num3
                for (int ii = 1; ii <= 11; ii++)
                {
                    if (ii != lot3)
                    {
                        num3[ii - 1]++;
                    }
                    else
                    {
                        num3[ii - 1] = 0;
                    }
                }
                #endregion

                // 平衡指数
                string blanceState = "";
                if ((Math.Abs(int.Parse(lottery.PreSort[0].ToString("D2")) - int.Parse(lottery.PreSort[1].ToString("D2"))) - 1) > (Math.Abs(int.Parse(lottery.PreSort[1].ToString("D2")) - int.Parse(lottery.PreSort[2].ToString("D2"))) - 1))
                {
                    blanceState = "+";
                }

                if ((Math.Abs(int.Parse(lottery.PreSort[0].ToString("D2")) - int.Parse(lottery.PreSort[1].ToString("D2"))) - 1) == (Math.Abs(int.Parse(lottery.PreSort[1].ToString("D2")) - int.Parse(lottery.PreSort[2].ToString("D2"))) - 1))
                {
                    blanceState = "=";
                }

                if ((Math.Abs(int.Parse(lottery.PreSort[0].ToString("D2")) - int.Parse(lottery.PreSort[1].ToString("D2"))) - 1) < (Math.Abs(int.Parse(lottery.PreSort[1].ToString("D2")) - int.Parse(lottery.PreSort[2].ToString("D2"))) - 1))
                {
                    blanceState = "-";
                }

                html += string.Format(@"
                    <tr>
			        <td>{0}</td>
			        <td class=""middledata redballfont equalwidth"">{1}</td>
			        <td class=""middledata redballfont equalwidth"">{2}</td>
			        <td class=""middledata redballfont equalwidth"">{3}</td>
			        <td {37}>{4}</td>
			        <td {38}>{5}</td>
			        <td {39}>{6}</td>
			        <td {40}>{7}</td>
			        <td {41}>{8}</td>
			        <td {42}>{9}</td>
			        <td {43}>{10}</td>
			        <td {44}>{11}</td>
			        <td {45}>{12}</td>
			        <td {46}>{13}</td>
			        <td {47}>{14}</td>
			        <td {48}>{15}</td>
			        <td {49}>{16}</td>
			        <td {50}>{17}</td>
			        <td {51}>{18}</td>
			        <td {52}>{19}</td>
			        <td {53}>{20}</td>
			        <td {54}>{21}</td>
			        <td {55}>{22}</td>
			        <td {56}>{23}</td>
			        <td {57}>{24}</td>
			        <td {58}>{25}</td>
			        <td {59}>{26}</td>
			        <td {60}>{27}</td>
			        <td {61}>{28}</td>
			        <td {62}>{29}</td>
			        <td {63}>{30}</td>
			        <td {64}>{31}</td>
			        <td {65}>{32}</td>
			        <td {66}>{33}</td>
			        <td {67}>{34}</td>
			        <td {68}>{35}</td>
			        <td {69}>{36}</td>
                    <td {70}</td>
                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"),// 0 - 3

                    int.Parse(lottery.PreSort[0].ToString("D2")) == 1 ? "1" : num1[0].ToString(),//4
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 2 ? "2" : num1[1].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 3 ? "3" : num1[2].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 4 ? "4" : num1[3].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 5 ? "5" : num1[4].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 6 ? "6" : num1[5].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 7 ? "7" : num1[6].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 8 ? "8" : num1[7].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 9 ? "9" : num1[8].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 10 ? "10" : num1[9].ToString(),
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 11 ? "11" : num1[10].ToString(),//14

                    int.Parse(lottery.PreSort[1].ToString("D2")) == 1 ? "1" : num2[0].ToString(),//15
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 2 ? "2" : num2[1].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 3 ? "3" : num2[2].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 4 ? "4" : num2[3].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 5 ? "5" : num2[4].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 6 ? "6" : num2[5].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 7 ? "7" : num2[6].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 8 ? "8" : num2[7].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 9 ? "9" : num2[8].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 10 ? "10" : num2[9].ToString(),
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 11 ? "11" : num2[10].ToString(),//25

                    int.Parse(lottery.PreSort[2].ToString("D2")) == 1 ? "1" : num3[0].ToString(),//26
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 2 ? "2" : num3[1].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 3 ? "3" : num3[2].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 4 ? "4" : num3[3].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 5 ? "5" : num3[4].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 6 ? "6" : num3[5].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 7 ? "7" : num3[6].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 8 ? "8" : num3[7].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 9 ? "9" : num3[8].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 10 ? "10" : num3[9].ToString(),
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 11 ? "11" : num3[10].ToString(),//36

                    int.Parse(lottery.PreSort[0].ToString("D2")) == 1 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", // 37
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 2 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 3 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 4 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 5 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 6 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 7 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 8 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 9 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 10 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[0].ToString("D2")) == 11 ? @"class=""blueball"" id=""d1" + i.ToString() + @"""" : @"class=""grayfont""", //47 

                    int.Parse(lottery.PreSort[1].ToString("D2")) == 1 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 48
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 2 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 3 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 4 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 5 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 6 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 7 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 8 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 9 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 10 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    int.Parse(lottery.PreSort[1].ToString("D2")) == 11 ? @"class=""redball middledata"" id=""d2" + i.ToString() + @"""" : @"class=""middledata grayfont""", // 58

                    int.Parse(lottery.PreSort[2].ToString("D2")) == 1 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""", // 59
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 2 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 3 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 4 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 5 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 6 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 7 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 8 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 9 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 10 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""",
                    int.Parse(lottery.PreSort[2].ToString("D2")) == 11 ? @"class=""blueball"" id=""d3" + i.ToString() + @"""" : @"class=""grayfont""", // 69

                    @"class=""middledata grayfont"">" + blanceState // 70

                 );
            }

            html += @"
                    <tr  class=""headfoot"">
			        <td rowspan=""2"" colspan=""4"">提交选择</td>
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
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">11</td>
			        <td rowspan=""2"">平衡指数</td>
		        </tr>
		        <tr  class=""headfoot"">
			        <td colspan=""11"">第一位</td>
			        <td colspan=""11"">第二位</td>
			        <td colspan=""11"">第三位</td>
		        </tr>
	        </table>
        </body>
        </html>
        ";

            return html;
        }
        #endregion

        #region 分序走势图
        public static string GetHtmlFenxuZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string d1 = "";
            string d2 = "";
            string d3 = "";


            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                d1 += "d1" + i.ToString() + ",";
                d2 += "d2" + i.ToString() + ",";
                d3 += "d3" + i.ToString() + ",";
            }

            d1 = d1.Substring(0, d1.Length - 1);
            d2 = d2.Substring(0, d2.Length - 1);
            d3 = d3.Substring(0, d3.Length - 1);

            #region top
            string Top = string.Format(@"
                <!DOCTYPE HTML PUBLIC ""-//W3C//DTD HTML 4.01//EN"" ""http://www.w3.org/TR/html4/strict.dtd"">
                <html lang=""en"">
                <head>
	                <meta http-equiv=""Content-Type"" content=""text/html;charset=UTF-8"">
	                <title>分序走势图</title>
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
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""11"">开奖号码分序走势图</td>
			                <td colspan=""9"">序(一)</td>
			                <td colspan=""9"">序(二)</td>
			                <td colspan=""9"">序(三)</td>
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
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">02</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">03</td>
			                <td class=""equalwidth"">04</td>
			                <td class=""equalwidth"">05</td>
			                <td class=""equalwidth"">06</td>
			                <td class=""equalwidth"">07</td>
			                <td class=""equalwidth"">08</td>
			                <td class=""equalwidth"">09</td>
			                <td class=""equalwidth"">10</td>
			                <td class=""equalwidth"">11</td>
		                </tr>
            ", d1, d2, d3);
            #endregion

            string html = Top;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };


            int[] num1 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] num2 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            int[] num3 = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            //for (int i = lotterys.Count - 1; i >= 0; i--)
            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

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
                for (int ii = 1; ii <= 11; ii++)
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
                for (int ii = 1; ii <= 11; ii++)
                {
                    if (ii != lotteryArr[1])
                    {
                        num2[ii - 1]++;
                    }
                    else
                    {
                        num2[ii - 1] = 0;
                    }
                }
                #endregion

                #region num3
                for (int ii = 1; ii <= 11; ii++)
                {
                    if (ii != lotteryArr[2])
                    {
                        num3[ii - 1]++;
                    }
                    else
                    {
                        num3[ii - 1] = 0;
                    }
                }
                #endregion

                html += string.Format(@"
                    <tr>
			        <td>{0}</td>
			        <td class=""middledata redballfont equalwidth"">{1}</td>
			        <td class=""middledata redballfont equalwidth"">{2}</td>
			        <td class=""middledata redballfont equalwidth"">{3}</td>
			        <td {42}>{4}</td>
                    <td {43}>{5}</td>
                    <td {44}>{6}</td>
                    <td {45}>{7}</td>
                    <td {46}>{8}</td>
                    <td {47}>{9}</td>
                    <td {48}>{10}</td>
                    <td {49}>{11}</td>
                    <td {50}>{12}</td>
                    <td {51}>{13}</td>
                    <td {52}>{14}</td>
                    <td {53}>{15}</td>
                    <td {54}>{16}</td>
                    <td {55}>{17}</td>
                    <td {56}>{18}</td>
                    <td {57}>{19}</td>
                    <td {58}>{20}</td>
                    <td {59}>{21}</td>
                    <td {60}>{22}</td>
                    <td {61}>{23}</td>
                    <td {62}>{24}</td>
                    <td {63}>{25}</td>
                    <td {64}>{26}</td>
                    <td {65}>{27}</td>
                    <td {66}>{28}</td>
                    <td {67}>{29}</td>
                    <td {68}>{30}</td>
                    <td {69}>{31}</td>
                    <td {70}>{32}</td>
                    <td {71}>{33}</td>
                    <td {72}>{34}</td>
                    <td {73}>{35}</td>
                    <td {74}>{36}</td>
                    <td {75}>{37}</td>
                    <td {76}>{38}</td>
                    <td {77}>{39}</td>
                    <td {78}>{40}</td>
                    <td {79}>{41}</td>
                    </tr>
                ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"),// 0 - 3
                    lotteryNumExit[0] ? "01" : preExistCount[0].ToString(),  // 4
                    lotteryNumExit[1] ? "02" : preExistCount[1].ToString(),
                    lotteryNumExit[2] ? "03" : preExistCount[2].ToString(),
                    lotteryNumExit[3] ? "04" : preExistCount[3].ToString(),
                    lotteryNumExit[4] ? "05" : preExistCount[4].ToString(),
                    lotteryNumExit[5] ? "06" : preExistCount[5].ToString(),
                    lotteryNumExit[6] ? "07" : preExistCount[6].ToString(),
                    lotteryNumExit[7] ? "08" : preExistCount[7].ToString(),
                    lotteryNumExit[8] ? "09" : preExistCount[8].ToString(),
                    lotteryNumExit[9] ? "10" : preExistCount[9].ToString(),
                    lotteryNumExit[10] ? "11" : preExistCount[10].ToString(), // 14

                    lottery[0] == 1 ? "1" : num1[0].ToString(), //15
                    lottery[0] == 2 ? "2" : num1[1].ToString(),
                    lottery[0] == 3 ? "3" : num1[2].ToString(),
                    lottery[0] == 4 ? "4" : num1[3].ToString(),
                    lottery[0] == 5 ? "5" : num1[4].ToString(),
                    lottery[0] == 6 ? "6" : num1[5].ToString(),
                    lottery[0] == 7 ? "7" : num1[6].ToString(),
                    lottery[0] == 8 ? "8" : num1[7].ToString(),
                    lottery[0] == 9 ? "9" : num1[8].ToString(),

                    lottery[1] == 2 ? "2" : num2[1].ToString(),
                    lottery[1] == 3 ? "3" : num2[2].ToString(),
                    lottery[1] == 4 ? "4" : num2[3].ToString(),
                    lottery[1] == 5 ? "5" : num2[4].ToString(),
                    lottery[1] == 6 ? "6" : num2[5].ToString(),
                    lottery[1] == 7 ? "7" : num2[6].ToString(),
                    lottery[1] == 8 ? "8" : num2[7].ToString(),
                    lottery[1] == 9 ? "9" : num2[8].ToString(),
                    lottery[1] == 10 ? "10" : num2[9].ToString(),

                    lottery[2] == 3 ? "3" : num3[2].ToString(),
                    lottery[2] == 4 ? "4" : num3[3].ToString(),
                    lottery[2] == 5 ? "5" : num3[4].ToString(),
                    lottery[2] == 6 ? "6" : num3[5].ToString(),
                    lottery[2] == 7 ? "7" : num3[6].ToString(),
                    lottery[2] == 8 ? "8" : num3[7].ToString(),
                    lottery[2] == 9 ? "9" : num3[8].ToString(),
                    lottery[2] == 10 ? "10" : num3[9].ToString(),
                    lottery[2] == 11 ? "11" : num3[10].ToString(), //47

                    //
                    lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", //48
                    lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""",
                    lotteryNumExit[10] ? @"class=""redball""" : @"class=""grayfont""", //58

                    lottery[0] == 1 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""", //59
                    lottery[0] == 2 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 3 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 4 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 5 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 6 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 7 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 8 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[0] == 9 ? @"class=""blueball middledata"" id=""d1" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                    lottery[1] == 2 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 3 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 4 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 5 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 6 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 7 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 8 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 9 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",
                    lottery[1] == 10 ? @"class=""redball"" id=""d2" + i.ToString() + @"""" : @"class=""grayfont""",

                    lottery[2] == 3 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 4 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 5 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 6 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 7 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 8 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 9 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 10 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                    lottery[2] == 11 ? @"class=""blueball middledata"" id=""d3" + i.ToString() + @"""" : @"class=""middledata grayfont""" //91
                 );
            }

            html += @"
                    <tr  class=""headfoot"">
			        <td rowspan=""2"" colspan=""4"">提交选择</td>
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
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">02</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">03</td>
			        <td class=""unclk"">04</td>
			        <td class=""unclk"">05</td>
			        <td class=""unclk"">06</td>
			        <td class=""unclk"">07</td>
			        <td class=""unclk"">08</td>
			        <td class=""unclk"">09</td>
			        <td class=""unclk"">10</td>
			        <td class=""unclk"">11</td>
		        </tr>
		        <tr  class=""headfoot"">
			        <td colspan=""11"">开奖号码分序走势图</td>
			        <td colspan=""9"">序(一)</td>
			        <td colspan=""9"">序(二)</td>
			        <td colspan=""9"">序(三)</td>
		        </tr>
	        </table>
        </body>
        </html>
        ";

            return html;
        }

        #endregion

        #region 龙头凤尾 反边球距离
        public static string GetHtmlLtfwFbqjlZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string fddx = "";
            string fdds = "";
            string fdzh = "";
            string pddx = "";
            string pdds = "";
            string pdzh = "";
            string fbqjls = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                fddx += "fddx" + i.ToString() + ",";
                fdds += "fdds" + i.ToString() + ",";
                fdzh += "fdzh" + i.ToString() + ",";
                pddx += "pddx" + i.ToString() + ",";
                pdds += "pdds" + i.ToString() + ",";
                pdzh += "pdzh" + i.ToString() + ",";
                fbqjls += "fbqjl" + i.ToString() + ",";
            }

            fddx = fddx.Substring(0, fddx.Length - 1);
            fdds = fdds.Substring(0, fdds.Length - 1);
            fdzh = fdzh.Substring(0, fdzh.Length - 1);
            pddx = pddx.Substring(0, pddx.Length - 1);
            pdds = pdds.Substring(0, pdds.Length - 1);
            pdzh = pdzh.Substring(0, pdzh.Length - 1);
            fbqjls = fbqjls.Substring(0, fbqjls.Length - 1);

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
			                width: 1400px; 
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
                            DrawLine_blue(""{2}"",""19"", ""4"");
				            DrawLine(""{3}"",""19"", ""4"");
                            DrawLine_blue(""{4}"",""19"", ""4"");
				            DrawLine(""{5}"",""19"", ""4"");
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
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""6"">龙头</td>
			                <td colspan=""6"">凤尾</td>
			                <td colspan=""21"">反边球距离</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">大</td>
			                <td class=""equalwidth"">小</td>
			                <td class=""equalwidth"">单</td>
							<td class=""equalwidth"">双</td>
							<td class=""equalwidth"">质</td>
							<td class=""equalwidth"">和</td>
							<td class=""equalwidth"">大</td>
							<td class=""equalwidth"">小</td>
			                <td class=""equalwidth"">单</td>
			                <td class=""equalwidth"">双</td>
			                <td class=""equalwidth"">质</td>
							<td class=""equalwidth"">和</td>
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
		                </tr> 
                ", fddx, fdds, fdzh, pddx, pdds, pdzh, fbqjls);

            string html = TOP;

            int[] FanBianQiuJuLi = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };

            string LongtouDaxiaoString = "";
            string LongtouDanshuangString = "";
            string LongtouZhiheString = "";
            string FengweiDaxiaoString = "";
            string FengweiDanshuangString = "";
            string FengweiZhiheString = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 龙头凤尾大小单双质和
                // 龙头
                if (lot1 >= 6)
                {
                    LongtouDaxiaoString = "大";
                }
                else
                {
                    LongtouDaxiaoString = "小";
                }
                if ((lot1 == 1 || lot1 == 3 || lot1 == 5 || lot1 == 7 || lot1 == 9 || lot1 == 11))
                {
                    LongtouDanshuangString = "单";
                }
                else
                {
                    LongtouDanshuangString = "双";
                }
                if ((lot1 == 1 || lot1 == 2 || lot1 == 3 || lot1 == 5 || lot1 == 7 || lot1 == 11))
                {
                    LongtouZhiheString = "质";
                }
                else
                {
                    LongtouZhiheString = "和";
                }

                // 凤尾
                if (lot3 >= 6)
                {
                    FengweiDaxiaoString = "大";
                }
                else
                {
                    FengweiDaxiaoString = "小";
                }
                if ((lot3 == 1 || lot3 == 3 || lot3 == 5 || lot3 == 7 || lot3 == 9 || lot3 == 11))
                {
                    FengweiDanshuangString = "单";
                }
                else
                {
                    FengweiDanshuangString = "双";
                }
                if ((lot3 == 1 || lot3 == 2 || lot3 == 3 || lot3 == 5 || lot3 == 7 || lot3 == 11))
                {
                    FengweiZhiheString = "质";
                }
                else
                {
                    FengweiZhiheString = "和";
                }
                #endregion

                #region 反边球距离
                int fbqjl = lot1 - 1 + 11 - lot3;

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

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {4}</td>
						<td {5}</td>
                        <td {6}</td>
						<td {7}</td>
                        <td {8}</td>
						<td {9}</td>
                        <td {10}</td>
						<td {11}</td>
                        <td {12}</td>
						<td {13}</td>
                        <td {14}</td>
						<td {15}</td>
			           
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
			            <td {48}>{27}</td>
			            <td {49}>{28}</td>
			            <td {50}>{29}</td>
			            <td {51}>{30}</td>
						<td {52}>{31}</td>
			            <td {53}>{32}</td>
			            <td {54}>{33}</td>
			            <td {55}>{34}</td>
			            <td {56}>{35}</td>
			            <td {57}>{36}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3
                     LongtouDaxiaoString.Equals("大") ? @"class=""blueball"" id=""fddx" + i.ToString() + @""">大" : @"class=""grayfont""",
                     LongtouDaxiaoString.Equals("小") ? @"class=""blueball"" id=""fddx" + i.ToString() + @""">小" : @"class=""grayfont""",
                     LongtouDanshuangString.Equals("单") ? @"class=""redball"" id=""fdds" + i.ToString() + @""">单" : @"class=""grayfont""",
                     LongtouDanshuangString.Equals("双") ? @"class=""redball"" id=""fdds" + i.ToString() + @""">双" : @"class=""grayfont""",
                     LongtouZhiheString.Equals("质") ? @"class=""blueball"" id=""fdzh" + i.ToString() + @""">质" : @"class=""grayfont""",
                     LongtouZhiheString.Equals("和") ? @"class=""blueball"" id=""fdzh" + i.ToString() + @""">和" : @"class=""grayfont""",

                     FengweiDaxiaoString.Equals("大") ? @"class=""redball"" id=""pddx" + i.ToString() + @""">大" : @"class=""grayfont""",
                     FengweiDaxiaoString.Equals("小") ? @"class=""redball"" id=""pddx" + i.ToString() + @""">小" : @"class=""grayfont""",
                     FengweiDanshuangString.Equals("单") ? @"class=""blueball"" id=""pdds" + i.ToString() + @""">单" : @"class=""grayfont""",
                     FengweiDanshuangString.Equals("双") ? @"class=""blueball"" id=""pdds" + i.ToString() + @""">双" : @"class=""grayfont""",
                     FengweiZhiheString.Equals("质") ? @"class=""redball"" id=""pdzh" + i.ToString() + @""">质" : @"class=""grayfont""",
                     FengweiZhiheString.Equals("和") ? @"class=""redball"" id=""pdzh" + i.ToString() + @""">和" : @"class=""grayfont""",

                         fbqjl == 0 ? "0" : FanBianQiuJuLi[0].ToString(), //16
                         fbqjl == 1 ? "1" : FanBianQiuJuLi[1].ToString(),
                         fbqjl == 2 ? "2" : FanBianQiuJuLi[2].ToString(),
                         fbqjl == 3 ? "3" : FanBianQiuJuLi[3].ToString(),
                         fbqjl == 4 ? "4" : FanBianQiuJuLi[4].ToString(),
                         fbqjl == 5 ? "5" : FanBianQiuJuLi[5].ToString(),
                         fbqjl == 6 ? "6" : FanBianQiuJuLi[6].ToString(),
                         fbqjl == 7 ? "7" : FanBianQiuJuLi[7].ToString(),
                         fbqjl == 8 ? "8" : FanBianQiuJuLi[8].ToString(),
                         fbqjl == 9 ? "9" : FanBianQiuJuLi[9].ToString(),
                         fbqjl == 10 ? "10" : FanBianQiuJuLi[10].ToString(),
                         fbqjl == 11 ? "11" : FanBianQiuJuLi[11].ToString(),
                         fbqjl == 12 ? "12" : FanBianQiuJuLi[12].ToString(),
                         fbqjl == 13 ? "13" : FanBianQiuJuLi[13].ToString(),
                         fbqjl == 14 ? "14" : FanBianQiuJuLi[14].ToString(),
                         fbqjl == 15 ? "15" : FanBianQiuJuLi[15].ToString(),
                         fbqjl == 16 ? "16" : FanBianQiuJuLi[16].ToString(),
                         fbqjl == 17 ? "17" : FanBianQiuJuLi[17].ToString(),
                         fbqjl == 18 ? "18" : FanBianQiuJuLi[18].ToString(),
                         fbqjl == 19 ? "19" : FanBianQiuJuLi[19].ToString(),
                         fbqjl == 20 ? "20" : FanBianQiuJuLi[20].ToString(), //36

                        fbqjl == 0 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""", //37
                        fbqjl == 1 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 2 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 3 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 4 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 5 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 6 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 7 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 8 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 9 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class="" middledata grayfont""",
                        fbqjl == 10 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 11 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 12 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 13 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 14 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 15 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 16 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 17 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 18 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 19 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl == 20 ? @"class=""redball middledata"" id=""fbqjl" + i.ToString() + @"""" : @"class=""middledata grayfont""" //57
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
			                <td class=""unclk"">大</td>
			                <td class=""unclk"">小</td>
			                <td class=""unclk"">单</td>
			                <td class=""unclk"">双</td>
			                <td class=""unclk"">质</td>
			                <td class=""unclk"">和</td>
			                <td class=""unclk"">大</td>
			                <td class=""unclk"">小</td>
			                <td class=""unclk"">单</td>
			                <td class=""unclk"">双</td>
			                <td class=""unclk"">质</td>
			                <td class=""unclk"">和</td>
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
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""6"">龙头</td>
			                <td colspan=""6"">凤尾</td>
			                <td colspan=""21"">反边球距离</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }

        #endregion

        #region 最大临码跨距 边临和
        public static string GetHtmlZdlmkjBlhZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string zdlmkj = "";
            string blh = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                zdlmkj += "zdlmkj" + i.ToString() + ",";
                blh += "blh" + i.ToString() + ",";
            }

            zdlmkj = zdlmkj.Substring(0, zdlmkj.Length - 1);
            blh = blh.Substring(0, blh.Length - 1);

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
			                width: 1400px; 
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
			                <td rowspan=""2"" colspan=""3"" style=""width:9%"">开奖号码</td>
			                <td colspan=""16"">最大临码跨距</td>
			                <td colspan=""16"">边临和</td>
		                </tr>
		                <tr class=""headfoot"">
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
		                </tr> 
                ", zdlmkj, blh);

            string html = TOP;

            int[] ZdlmkjInt = new int[16];
            int[] BlhInt = new int[16];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 最大临码跨距

                int l1 = (11 - lot1) + (lot2 - 1);
                int l2 = (11 - lot2) + (lot3 - 1);

                int[] ll = new int[] { l1, l2 };

                Array.Sort<int>(ll);

                int Zuidalinmakuaju = ll[1];

                for (int ii = 5; ii < 21; ii++)
                {
                    if (ii == Zuidalinmakuaju)
                    {
                        ZdlmkjInt[ii - 5] = 0;
                    }
                    else
                    {
                        ZdlmkjInt[ii - 5]++;
                    }
                }
                #endregion

                #region 边临和
                int Bianlinhe = Zuidalinmakuaju + lot1 - 1 + 11 - lot3;

                for (int ii = 15; ii < 31; ii++)
                {
                    if (ii == Bianlinhe)
                    {
                        BlhInt[ii - 15] = 0;
                    }
                    else
                    {
                        BlhInt[ii - 15]++;
                    }
                }
                #endregion

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {36}>{4}</td>
			            <td {37}>{5}</td>
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
			            <td {67}>{35}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                         Zuidalinmakuaju == 5 ? "5" : ZdlmkjInt[0].ToString(), //4
                         Zuidalinmakuaju == 6 ? "6" : ZdlmkjInt[1].ToString(),
                         Zuidalinmakuaju == 7 ? "7" : ZdlmkjInt[2].ToString(),
                         Zuidalinmakuaju == 8 ? "8" : ZdlmkjInt[3].ToString(),
                         Zuidalinmakuaju == 9 ? "9" : ZdlmkjInt[4].ToString(),
                         Zuidalinmakuaju == 10 ? "10" : ZdlmkjInt[5].ToString(),
                         Zuidalinmakuaju == 11 ? "11" : ZdlmkjInt[6].ToString(),
                         Zuidalinmakuaju == 12 ? "12" : ZdlmkjInt[7].ToString(),
                         Zuidalinmakuaju == 13 ? "13" : ZdlmkjInt[8].ToString(),
                         Zuidalinmakuaju == 14 ? "14" : ZdlmkjInt[9].ToString(),
                         Zuidalinmakuaju == 15 ? "15" : ZdlmkjInt[10].ToString(),
                         Zuidalinmakuaju == 16 ? "16" : ZdlmkjInt[11].ToString(),
                         Zuidalinmakuaju == 17 ? "17" : ZdlmkjInt[12].ToString(),
                         Zuidalinmakuaju == 18 ? "18" : ZdlmkjInt[13].ToString(),
                         Zuidalinmakuaju == 19 ? "19" : ZdlmkjInt[14].ToString(),
                         Zuidalinmakuaju == 20 ? "20" : ZdlmkjInt[15].ToString(), //19

                        Bianlinhe == 15 ? "15" : BlhInt[0].ToString(), //20
                        Bianlinhe == 16 ? "16" : BlhInt[1].ToString(),
                        Bianlinhe == 17 ? "17" : BlhInt[2].ToString(),
                        Bianlinhe == 18 ? "18" : BlhInt[3].ToString(),
                        Bianlinhe == 19 ? "19" : BlhInt[4].ToString(),
                        Bianlinhe == 20 ? "20" : BlhInt[5].ToString(),
                        Bianlinhe == 21 ? "21" : BlhInt[6].ToString(),
                        Bianlinhe == 22 ? "22" : BlhInt[7].ToString(),
                        Bianlinhe == 23 ? "23" : BlhInt[8].ToString(),
                        Bianlinhe == 24 ? "24" : BlhInt[9].ToString(),
                        Bianlinhe == 25 ? "25" : BlhInt[10].ToString(),
                        Bianlinhe == 26 ? "26" : BlhInt[11].ToString(),
                        Bianlinhe == 27 ? "27" : BlhInt[12].ToString(),
                        Bianlinhe == 28 ? "28" : BlhInt[13].ToString(),
                        Bianlinhe == 29 ? "29" : BlhInt[14].ToString(),
                        Bianlinhe == 30 ? "30" : BlhInt[15].ToString(), //35

                        Zuidalinmakuaju == 5 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""", //35
                        Zuidalinmakuaju == 6 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 7 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 8 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 9 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 10 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 11 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 12 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 13 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 14 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 15 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 16 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 17 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 18 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 19 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""",
                        Zuidalinmakuaju == 20 ? @"class=""blueball"" id=""zdlmkj" + i.ToString() + @"""" : @"class=""grayfont""", //51

                        Bianlinhe == 15 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""", //52
                        Bianlinhe == 16 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 17 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 18 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 19 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 20 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 21 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 22 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 23 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 24 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 25 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 26 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 27 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 28 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 29 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe == 30 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont"""  //67
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""16"">最大临码跨距</td>
			                <td colspan=""16"">边临和</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }

        #endregion

        #region 形态/属性 跨度走势 012路
        public static string GetHtmlXtKd012(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string hmxt = "";
            string osgs = "";
            string xsgs = "";
            string zsgs = "";
            string kdzst = "";
            string fbq = "";
            string zdlk = "";
            string blh = "";
            string qhgj = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                hmxt += "hmxt" + i.ToString() + ",";
                osgs += "osgs" + i.ToString() + ",";
                xsgs += "xsgs" + i.ToString() + ",";
                zsgs += "zsgs" + i.ToString() + ",";
                kdzst += "kdzst" + i.ToString() + ",";
                fbq += "fbq" + i.ToString() + ",";
                zdlk += "zdlk" + i.ToString() + ",";
                blh += "blh" + i.ToString() + ",";
                qhgj += "qhgj" + i.ToString() + ",";
            }

            hmxt = hmxt.Substring(0, hmxt.Length - 1);
            osgs = osgs.Substring(0, osgs.Length - 1);
            xsgs = xsgs.Substring(0, xsgs.Length - 1);
            zsgs = zsgs.Substring(0, zsgs.Length - 1);
            kdzst = kdzst.Substring(0, kdzst.Length - 1);
            fbq = fbq.Substring(0, fbq.Length - 1);
            zdlk = zdlk.Substring(0, zdlk.Length - 1);
            blh = blh.Substring(0, blh.Length - 1);
            qhgj = qhgj.Substring(0, qhgj.Length - 1);

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
			                width: 1600px; 
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
                            DrawLine_blue(""{2}"",""19"", ""4"");
				            DrawLine(""{3}"",""19"", ""4"");
                            DrawLine_blue(""{4}"",""19"", ""4"");
				            DrawLine(""{5}"",""19"", ""4"");
                            DrawLine_blue(""{6}"",""19"", ""4"");
				            DrawLine(""{7}"",""19"", ""4"");
                            DrawLine_blue(""{8}"",""19"", ""4"");

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
			                <td rowspan=""3"" style=""width:8.5%"">期号</td>
			                <td rowspan=""3"" colspan=""3"" style=""width:9%"">开奖号码</td>
			                <td colspan=""4"" rowspan=""2"">号码形态</td>
			                <td colspan=""4"" rowspan=""2"">偶数个数</td>
			                <td colspan=""4"" rowspan=""2"">小数个数</td>
			                <td colspan=""4"" rowspan=""2"">质数个数</td>
			                <td colspan=""9"" rowspan=""2"">跨度走势图</td>
			                <td colspan=""12"">012路走势图</td>
                                <tr class=""headfoot"">
                                <td colspan=""3"">反边球</td>
                                <td colspan=""3"">最大临跨</td>
                                <td colspan=""3"">边临和</td>
                                <td colspan=""3"">前后轨迹</td>
                                </tr>
		                </tr>
		                <tr class=""headfoot"">
			                <td class=""equalwidth"">凹</td>
			                <td class=""equalwidth"">凸</td>
			                <td class=""equalwidth"">升</td>
			                <td class=""equalwidth"">降</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
							<td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">3</td>
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
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
			                <td class=""equalwidth"">0</td>
			                <td class=""equalwidth"">1</td>
			                <td class=""equalwidth"">2</td>
		                </tr> 
                ", hmxt, osgs, xsgs, zsgs, kdzst, fbq, zdlk, blh, qhgj);

            string html = TOP;

            int[] hmxtInt = new int[4];
            int[] osgsInt = new int[4];
            int[] xsgsInt = new int[4];
            int[] zsgsInt = new int[4];
            int[] kdzstInt = new int[9];
            int[] fbqInt = new int[3];
            int[] zdlkInt = new int[3];
            int[] blhInt = new int[3];
            int[] qhgjInt = new int[3];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 号码形态
                int hmxt012;

                if ((lot1 > lot2) && (lot3 > lot2))
                {
                    hmxt012 = 0;
                }
                else if ((lot1 < lot2) && (lot3 < lot2))
                {
                    hmxt012 = 1;
                }
                else if ((lot1 < lot2) && (lot3 > lot2))
                {
                    hmxt012 = 2;
                }
                else
                {
                    hmxt012 = 3;
                }

                for (int ii = 0; ii < 4; ii++)
                {
                    if (ii == hmxt012)
                    {
                        hmxtInt[ii] = 0;
                    }
                    else
                    {
                        hmxtInt[ii]++;
                    }
                }
                #endregion

                #region 偶数
                int osgs012 = ((lot1 % 2 == 0) ? 1 : 0) + ((lot2 % 2 == 0) ? 1 : 0) + ((lot3 % 2 == 0) ? 1 : 0);

                for (int ii = 0; ii < 4; ii++)
                {
                    if (ii == osgs012)
                    {
                        osgsInt[ii] = 0;
                    }
                    else
                    {
                        osgsInt[ii]++;
                    }
                }
                #endregion

                #region 小数
                int xsgs012 = ((lot1 <= 5) ? 1 : 0) + ((lot2 <= 5) ? 1 : 0) + ((lot3 <= 5) ? 1 : 0);

                for (int ii = 0; ii < 4; ii++)
                {
                    if (ii == xsgs012)
                    {
                        xsgsInt[ii] = 0;
                    }
                    else
                    {
                        xsgsInt[ii]++;
                    }
                }
                #endregion

                #region 质数
                int[] zhiT = new int[] { 1, 2, 3, 5, 7, 11 };

                int zsgs012 = ((Array.IndexOf<int>(zhiT, lot1) != -1) ? 1 : 0) + (((Array.IndexOf<int>(zhiT, lot2) != -1) ? 1 : 0) + ((Array.IndexOf<int>(zhiT, lot3) != -1) ? 1 : 0));

                for (int ii = 0; ii < 4; ii++)
                {
                    if (ii == zsgs012)
                    {
                        zsgsInt[ii] = 0;
                    }
                    else
                    {
                        zsgsInt[ii]++;
                    }
                }
                #endregion

                #region 跨度
                int kd012 = lottery[2] - lottery[0];
                for (int ii = 2; ii < 11; ii++)
                {
                    if (ii == kd012)
                    {
                        kdzstInt[ii - 2] = 0;
                    }
                    else
                    {
                        kdzstInt[ii - 2]++;
                    }
                }
                #endregion

                #region 反边球
                int fbqjl012 = (lot1 - 1 + 11 - lot3) % 3;

                for (int ii = 0; ii < 3; ii++)
                {
                    if (ii == fbqjl012)
                    {
                        fbqInt[ii] = 0;
                    }
                    else
                    {
                        fbqInt[ii]++;
                    }
                }
                #endregion

                #region 最大临跨
                int l1 = (11 - lot1) + (lot2 - 1);
                int l2 = (11 - lot2) + (lot3 - 1);
                int[] ll = new int[] { l1, l2 };
                Array.Sort<int>(ll);
                int Zuidalinmakuaju = ll[1];

                int zdlk012 = ll[1] % 3;

                for (int ii = 0; ii < 3; ii++)
                {
                    if (ii == zdlk012)
                    {
                        zdlkInt[ii] = 0;
                    }
                    else
                    {
                        zdlkInt[ii]++;
                    }
                }
                #endregion

                #region 边临和
                int Bianlinhe012 = (Zuidalinmakuaju + lot1 - 1 + 11 - lot3) % 3;

                for (int ii = 0; ii < 3; ii++)
                {
                    if (ii == Bianlinhe012)
                    {
                        blhInt[ii] = 0;
                    }
                    else
                    {
                        blhInt[ii]++;
                    }
                }
                #endregion

                #region 前后轨迹
                int qhgj012 = (Math.Abs(lot1 - 1) + Math.Abs(lot3 - 11)) % 3;

                for (int ii = 0; ii < 3; ii++)
                {
                    if (ii == qhgj012)
                    {
                        qhgjInt[ii] = 0;
                    }
                    else
                    {
                        qhgjInt[ii]++;
                    }
                }
                #endregion

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
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
                        <td {74}>{37}</td>
                        <td {75}>{38}</td>
                        <td {76}>{39}</td>
                        <td {77}>{40}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                         hmxt012 == 0 ? "凹" : hmxtInt[0].ToString(), //4
                         hmxt012 == 1 ? "凸" : hmxtInt[1].ToString(),
                         hmxt012 == 2 ? "升" : hmxtInt[2].ToString(),
                         hmxt012 == 3 ? "降" : hmxtInt[3].ToString(),

                         osgs012 == 0 ? "0" : osgsInt[0].ToString(),
                         osgs012 == 1 ? "1" : osgsInt[1].ToString(),
                         osgs012 == 2 ? "2" : osgsInt[2].ToString(),
                         osgs012 == 3 ? "3" : osgsInt[3].ToString(),

                         xsgs012 == 0 ? "0" : xsgsInt[0].ToString(),
                         xsgs012 == 1 ? "1" : xsgsInt[1].ToString(),
                         xsgs012 == 2 ? "2" : xsgsInt[2].ToString(),
                         xsgs012 == 3 ? "3" : xsgsInt[3].ToString(),

                         zsgs012 == 0 ? "0" : zsgsInt[0].ToString(),
                         zsgs012 == 1 ? "1" : zsgsInt[1].ToString(),
                         zsgs012 == 2 ? "2" : zsgsInt[2].ToString(),
                         zsgs012 == 3 ? "3" : zsgsInt[3].ToString(),

                         kd012 == 2 ? "2" : kdzstInt[0].ToString(),
                         kd012 == 3 ? "3" : kdzstInt[1].ToString(),
                         kd012 == 4 ? "4" : kdzstInt[2].ToString(),
                         kd012 == 5 ? "5" : kdzstInt[3].ToString(),
                         kd012 == 6 ? "6" : kdzstInt[4].ToString(),
                         kd012 == 7 ? "7" : kdzstInt[5].ToString(),
                         kd012 == 8 ? "8" : kdzstInt[6].ToString(),
                         kd012 == 9 ? "9" : kdzstInt[7].ToString(),
                         kd012 == 10 ? "10" : kdzstInt[8].ToString(),

                         fbqjl012 == 0 ? "0" : fbqInt[0].ToString(),
                         fbqjl012 == 1 ? "1" : fbqInt[1].ToString(),
                         fbqjl012 == 2 ? "2" : fbqInt[2].ToString(),

                         zdlk012 == 0 ? "0" : zdlkInt[0].ToString(),
                         zdlk012 == 1 ? "1" : zdlkInt[1].ToString(),
                         zdlk012 == 2 ? "2" : zdlkInt[2].ToString(),

                         Bianlinhe012 == 0 ? "0" : blhInt[0].ToString(),
                         Bianlinhe012 == 1 ? "1" : blhInt[1].ToString(),
                         Bianlinhe012 == 2 ? "2" : blhInt[2].ToString(),

                         qhgj012 == 0 ? "0" : qhgjInt[0].ToString(),
                         qhgj012 == 1 ? "1" : qhgjInt[1].ToString(),
                         qhgj012 == 2 ? "2" : qhgjInt[2].ToString(),

                        hmxt012 == 0 ? @"class=""blueball"" id=""hmxt" + i.ToString() + @"""" : @"class=""grayfont""",
                        hmxt012 == 1 ? @"class=""blueball"" id=""hmxt" + i.ToString() + @"""" : @"class=""grayfont""",
                        hmxt012 == 2 ? @"class=""blueball"" id=""hmxt" + i.ToString() + @"""" : @"class=""grayfont""",
                        hmxt012 == 3 ? @"class=""blueball"" id=""hmxt" + i.ToString() + @"""" : @"class=""grayfont""",

                        osgs012 == 0 ? @"class=""redball middledata"" id=""osgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        osgs012 == 1 ? @"class=""redball middledata"" id=""osgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        osgs012 == 2 ? @"class=""redball middledata"" id=""osgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        osgs012 == 3 ? @"class=""redball middledata"" id=""osgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        xsgs012 == 0 ? @"class=""blueball"" id=""xsgs" + i.ToString() + @"""" : @"class=""grayfont""",
                        xsgs012 == 1 ? @"class=""blueball"" id=""xsgs" + i.ToString() + @"""" : @"class=""grayfont""",
                        xsgs012 == 2 ? @"class=""blueball"" id=""xsgs" + i.ToString() + @"""" : @"class=""grayfont""",
                        xsgs012 == 3 ? @"class=""blueball"" id=""xsgs" + i.ToString() + @"""" : @"class=""grayfont""",

                        zsgs012 == 0 ? @"class=""redball middledata"" id=""zsgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        zsgs012 == 1 ? @"class=""redball middledata"" id=""zsgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        zsgs012 == 2 ? @"class=""redball middledata"" id=""zsgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        zsgs012 == 3 ? @"class=""redball middledata"" id=""zsgs" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        kd012 == 2 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 3 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 4 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 5 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 6 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 7 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 8 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 9 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",
                        kd012 == 10 ? @"class=""blueball"" id=""kdzst" + i.ToString() + @"""" : @"class=""grayfont""",

                        fbqjl012 == 0 ? @"class=""redball middledata"" id=""fbq" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl012 == 1 ? @"class=""redball middledata"" id=""fbq" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        fbqjl012 == 2 ? @"class=""redball middledata"" id=""fbq" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        zdlk012 == 0 ? @"class=""blueball"" id=""zdlk" + i.ToString() + @"""" : @"class=""grayfont""",
                        zdlk012 == 1 ? @"class=""blueball"" id=""zdlk" + i.ToString() + @"""" : @"class=""grayfont""",
                        zdlk012 == 2 ? @"class=""blueball"" id=""zdlk" + i.ToString() + @"""" : @"class=""grayfont""",

                        Bianlinhe012 == 0 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe012 == 1 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Bianlinhe012 == 2 ? @"class=""redball middledata"" id=""blh" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        qhgj012 == 0 ? @"class=""blueball"" id=""qhgj" + i.ToString() + @"""" : @"class=""grayfont""",
                        qhgj012 == 1 ? @"class=""blueball"" id=""qhgj" + i.ToString() + @"""" : @"class=""grayfont""",
                        qhgj012 == 2 ? @"class=""blueball"" id=""qhgj" + i.ToString() + @"""" : @"class=""grayfont"""
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""3"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
                            <td class=""unclk"">凹</td>
			                <td class=""unclk"">凸</td>
			                <td class=""unclk"">升</td>
			                <td class=""unclk"">降</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
							<td class=""unclk"">2</td>
			                <td class=""unclk"">3</td>
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
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
			                <td class=""unclk"">0</td>
			                <td class=""unclk"">1</td>
			                <td class=""unclk"">2</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""4"" rowspan=""2"">号码形态</td>
			                <td colspan=""4"" rowspan=""2"">偶数个数</td>
			                <td colspan=""4"" rowspan=""2"">小数个数</td>
			                <td colspan=""4"" rowspan=""2"">质数个数</td>
			                <td colspan=""9"" rowspan=""2"">跨度走势图</td>
			                <td colspan=""12"">012路走势图</td>
                                <tr class=""headfoot"">
                                <td colspan=""3"">反边球</td>
                                <td colspan=""3"">最大临跨</td>
                                <td colspan=""3"">边临和</td>
                                <td colspan=""3"">前后轨迹</td>
                                </tr>
		                </tr>
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 和值/合值
        public static string GetHtmlHzhzZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string hehezhi = "";
            string hezhi = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                hehezhi += "hehezhi" + i.ToString() + ",";
                hezhi += "hezhi" + i.ToString() + ",";
            }

            hehezhi = hehezhi.Substring(0, hehezhi.Length - 1);
            hezhi = hezhi.Substring(0, hezhi.Length - 1);

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
			                <td rowspan=""2"" colspan=""3"" style=""width:9%"">开奖号码</td>
			                <td colspan=""25"">和值走势图</td>
			                <td colspan=""10"">合值走势图</td>
		                </tr>
		                <tr class=""headfoot"">
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
                            <td class=""equalwidth"">22</td>
                            <td class=""equalwidth"">23</td>
                            <td class=""equalwidth"">24</td>
                            <td class=""equalwidth"">25</td>
                            <td class=""equalwidth"">26</td>
                            <td class=""equalwidth"">27</td>
                            <td class=""equalwidth"">28</td>
                            <td class=""equalwidth"">29</td>
                            <td class=""equalwidth"">30</td>
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
                ", hehezhi, hezhi);

            string html = TOP;

            int[] HehezhiInt = new int[25];
            int[] HezhiInt = new int[10];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 和值
                int Hehezhi = lot1 + lot2 + lot3;

                for (int ii = 6; ii < 31; ii++)
                {
                    if (ii == Hehezhi)
                    {
                        HehezhiInt[ii - 6] = 0;
                    }
                    else
                    {
                        HehezhiInt[ii - 6]++;
                    }
                }
                #endregion

                #region 合值
                int Hezhi = (lot1 + lot2 + lot3) % 10;

                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == Hezhi)
                    {
                        HezhiInt[ii] = 0;
                    }
                    else
                    {
                        HezhiInt[ii]++;
                    }
                }
                #endregion

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {39}>{4}</td>
                        <td {40}>{5}</td>
                        <td {41}>{6}</td>
                        <td {42}>{7}</td>
                        <td {43}>{8}</td>
                        <td {44}>{9}</td>
                        <td {45}>{10}</td>
                        <td {46}>{11}</td>
                        <td {47}>{12}</td>
                        <td {48}>{13}</td>
                        <td {49}>{14}</td>
                        <td {50}>{15}</td>
                        <td {51}>{16}</td>
                        <td {52}>{17}</td>
                        <td {53}>{18}</td>
                        <td {54}>{19}</td>
                        <td {55}>{20}</td>
                        <td {56}>{21}</td>
                        <td {57}>{22}</td>
                        <td {58}>{23}</td>
                        <td {59}>{24}</td>
                        <td {60}>{25}</td>
                        <td {61}>{26}</td>
                        <td {62}>{27}</td>
                        <td {63}>{28}</td>
                        <td {64}>{29}</td>
                        <td {65}>{30}</td>
                        <td {66}>{31}</td>
                        <td {67}>{32}</td>
                        <td {68}>{33}</td>
                        <td {69}>{34}</td>
                        <td {70}>{35}</td>
                        <td {71}>{36}</td>
                        <td {72}>{37}</td>
                        <td {73}>{38}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                         Hehezhi == 6 ? "6" : HehezhiInt[0].ToString(), //4
                         Hehezhi == 7 ? "7" : HehezhiInt[1].ToString(),
                         Hehezhi == 8 ? "8" : HehezhiInt[2].ToString(),
                         Hehezhi == 9 ? "9" : HehezhiInt[3].ToString(),
                         Hehezhi == 10 ? "10" : HehezhiInt[4].ToString(),
                         Hehezhi == 11 ? "11" : HehezhiInt[5].ToString(),
                         Hehezhi == 12 ? "12" : HehezhiInt[6].ToString(),
                         Hehezhi == 13 ? "13" : HehezhiInt[7].ToString(),
                         Hehezhi == 14 ? "14" : HehezhiInt[8].ToString(),
                         Hehezhi == 15 ? "15" : HehezhiInt[9].ToString(),
                         Hehezhi == 16 ? "16" : HehezhiInt[10].ToString(),
                         Hehezhi == 17 ? "17" : HehezhiInt[11].ToString(),
                         Hehezhi == 18 ? "18" : HehezhiInt[12].ToString(),
                         Hehezhi == 19 ? "19" : HehezhiInt[13].ToString(),
                         Hehezhi == 20 ? "20" : HehezhiInt[14].ToString(),
                         Hehezhi == 21 ? "21" : HehezhiInt[15].ToString(),
                         Hehezhi == 22 ? "22" : HehezhiInt[16].ToString(),
                         Hehezhi == 23 ? "23" : HehezhiInt[17].ToString(),
                         Hehezhi == 24 ? "24" : HehezhiInt[18].ToString(),
                         Hehezhi == 25 ? "25" : HehezhiInt[19].ToString(),
                         Hehezhi == 26 ? "26" : HehezhiInt[20].ToString(),
                         Hehezhi == 27 ? "27" : HehezhiInt[21].ToString(),
                         Hehezhi == 28 ? "28" : HehezhiInt[22].ToString(),
                         Hehezhi == 29 ? "29" : HehezhiInt[23].ToString(),
                         Hehezhi == 30 ? "30" : HehezhiInt[24].ToString(), //28

                        Hezhi == 0 ? "0" : HezhiInt[0].ToString(), //29
                        Hezhi == 1 ? "1" : HezhiInt[1].ToString(),
                        Hezhi == 2 ? "2" : HezhiInt[2].ToString(),
                        Hezhi == 3 ? "3" : HezhiInt[3].ToString(),
                        Hezhi == 4 ? "4" : HezhiInt[4].ToString(),
                        Hezhi == 5 ? "5" : HezhiInt[5].ToString(),
                        Hezhi == 6 ? "6" : HezhiInt[6].ToString(),
                        Hezhi == 7 ? "7" : HezhiInt[7].ToString(),
                        Hezhi == 8 ? "8" : HezhiInt[8].ToString(),
                        Hezhi == 9 ? "9" : HezhiInt[9].ToString(), // 38

                        Hehezhi == 6 ? @"class=""blueball""  id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 7 ? @"class=""blueball""  id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 8 ? @"class=""blueball""  id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 9 ? @"class=""blueball""  id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 10 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 11 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 12 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 13 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 14 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 15 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 16 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 17 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 18 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 19 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 20 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 21 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 22 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 23 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 24 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 25 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 26 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 27 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 28 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 29 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""",
                        Hehezhi == 30 ? @"class=""blueball"" id=""hehezhi" + i.ToString() + @"""" : @"class=""grayfont""", //63

                        Hezhi == 0 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""", //64
                        Hezhi == 1 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 2 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 3 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 4 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 5 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 6 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 7 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 8 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Hezhi == 9 ? @"class=""redball middledata"" id=""hezhi" + i.ToString() + @"""" : @"class=""middledata grayfont""" //72
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
                            <td class=""unclk"">22</td>
                            <td class=""unclk"">23</td>
                            <td class=""unclk"">24</td>
                            <td class=""unclk"">25</td>
                            <td class=""unclk"">26</td>
                            <td class=""unclk"">27</td>
                            <td class=""unclk"">28</td>
                            <td class=""unclk"">29</td>
                            <td class=""unclk"">30</td>
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
		                <tr class=""headfoot"">
			                <td colspan=""25"">和值走势图</td>
			                <td colspan=""10"">合值走势图</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 两码合走势
        public static string GetHtmlLmhZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string YiErHe = "";
            string YiSanHe = "";
            string ErSanHe = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                YiErHe += "YiErHe" + i.ToString() + ",";
                YiSanHe += "YiSanHe" + i.ToString() + ",";
                ErSanHe += "ErSanHe" + i.ToString() + ",";
            }

            YiErHe = YiErHe.Substring(0, YiErHe.Length - 1);
            YiSanHe = YiSanHe.Substring(0, YiSanHe.Length - 1);
            ErSanHe = ErSanHe.Substring(0, ErSanHe.Length - 1);

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
			                width: 1400px; 
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
			                <td rowspan=""2"" style=""width:7%"">期号</td>
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""10"">两码合分布图</td>
			                <td colspan=""10"">一/二位走势</td>
			                <td colspan=""10"">一/三位走势</td>
			                <td colspan=""10"">二/三位走势</td>
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
                ", YiErHe, YiSanHe, ErSanHe);

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] YiErHeInt = new int[10];
            int[] YiSanHeInt = new int[10];
            int[] ErSanHeInt = new int[10];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                int[] tempLot = new int[3];
                tempLot[0] = (lot1 + lot2) % 10;
                tempLot[1] = (lot1 + lot3) % 10;
                tempLot[2] = (lot2 + lot3) % 10;

                int liangmahe1 = tempLot[0];
                int liangmahe2 = tempLot[1];
                int liangmahe3 = tempLot[2];

                #region 分布
                Array.Sort(tempLot);

                for (int ii = 0; ii <= 9; ii++)
                {

                    if (Array.IndexOf<int>(tempLot, ii) == -1)
                    {
                        preExistCount[ii]++;
                        lotteryNumExit[ii] = false;
                    }
                    else
                    {
                        preExistCount[ii] = 0;
                        lotteryNumExit[ii] = true;
                    }
                }

                #endregion

                #region 1 2
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe1)
                    {
                        YiErHeInt[ii] = 0;
                    }
                    else
                    {
                        YiErHeInt[ii]++;
                    }
                }
                #endregion

                #region 1 3
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe2)
                    {
                        YiSanHeInt[ii] = 0;
                    }
                    else
                    {
                        YiSanHeInt[ii]++;
                    }
                }
                #endregion

                #region 2 3
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe3)
                    {
                        ErSanHeInt[ii] = 0;
                    }
                    else
                    {
                        ErSanHeInt[ii]++;
                    }
                }
                #endregion
                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {44}>{4}</td>
                        <td {45}>{5}</td>
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
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        lotteryNumExit[0] ? "0" : preExistCount[0].ToString(),  // 4
                        lotteryNumExit[1] ? "1" : preExistCount[1].ToString(),
                        lotteryNumExit[2] ? "2" : preExistCount[2].ToString(),
                        lotteryNumExit[3] ? "3" : preExistCount[3].ToString(),
                        lotteryNumExit[4] ? "4" : preExistCount[4].ToString(),
                        lotteryNumExit[5] ? "5" : preExistCount[5].ToString(),
                        lotteryNumExit[6] ? "6" : preExistCount[6].ToString(),
                        lotteryNumExit[7] ? "7" : preExistCount[7].ToString(),
                        lotteryNumExit[8] ? "8" : preExistCount[8].ToString(),
                        lotteryNumExit[9] ? "9" : preExistCount[9].ToString(), //13

                        liangmahe1 == 0 ? "0" : YiErHeInt[0].ToString(), //14
                        liangmahe1 == 1 ? "1" : YiErHeInt[1].ToString(),
                        liangmahe1 == 2 ? "2" : YiErHeInt[2].ToString(),
                        liangmahe1 == 3 ? "3" : YiErHeInt[3].ToString(),
                        liangmahe1 == 4 ? "4" : YiErHeInt[4].ToString(),
                        liangmahe1 == 5 ? "5" : YiErHeInt[5].ToString(),
                        liangmahe1 == 6 ? "6" : YiErHeInt[6].ToString(),
                        liangmahe1 == 7 ? "7" : YiErHeInt[7].ToString(),
                        liangmahe1 == 8 ? "8" : YiErHeInt[8].ToString(),
                        liangmahe1 == 9 ? "9" : YiErHeInt[9].ToString(), // 23

                        liangmahe2 == 0 ? "0" : YiSanHeInt[0].ToString(), //24
                        liangmahe2 == 1 ? "1" : YiSanHeInt[1].ToString(),
                        liangmahe2 == 2 ? "2" : YiSanHeInt[2].ToString(),
                        liangmahe2 == 3 ? "3" : YiSanHeInt[3].ToString(),
                        liangmahe2 == 4 ? "4" : YiSanHeInt[4].ToString(),
                        liangmahe2 == 5 ? "5" : YiSanHeInt[5].ToString(),
                        liangmahe2 == 6 ? "6" : YiSanHeInt[6].ToString(),
                        liangmahe2 == 7 ? "7" : YiSanHeInt[7].ToString(),
                        liangmahe2 == 8 ? "8" : YiSanHeInt[8].ToString(),
                        liangmahe2 == 9 ? "9" : YiSanHeInt[9].ToString(), // 33

                        liangmahe3 == 0 ? "0" : ErSanHeInt[0].ToString(), //34
                        liangmahe3 == 1 ? "1" : ErSanHeInt[1].ToString(),
                        liangmahe3 == 2 ? "2" : ErSanHeInt[2].ToString(),
                        liangmahe3 == 3 ? "3" : ErSanHeInt[3].ToString(),
                        liangmahe3 == 4 ? "4" : ErSanHeInt[4].ToString(),
                        liangmahe3 == 5 ? "5" : ErSanHeInt[5].ToString(),
                        liangmahe3 == 6 ? "6" : ErSanHeInt[6].ToString(),
                        liangmahe3 == 7 ? "7" : ErSanHeInt[7].ToString(),
                        liangmahe3 == 8 ? "8" : ErSanHeInt[8].ToString(),
                        liangmahe3 == 9 ? "9" : ErSanHeInt[9].ToString(), // 43

                        lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", // 44
                        lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //53

                        liangmahe1 == 0 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //54
                        liangmahe1 == 1 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 2 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 3 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 4 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 5 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 6 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 7 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 8 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 9 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63

                        liangmahe2 == 0 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""", //64
                        liangmahe2 == 1 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 2 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 3 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 4 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 5 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 6 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 7 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 8 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 9 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""", //73

                        liangmahe3 == 0 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //74
                        liangmahe3 == 1 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 2 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 3 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 4 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 5 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 6 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 7 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 8 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 9 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""" //83
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
		                <tr class=""headfoot"">
			                <td colspan=""10"">两码合分布图</td>
			                <td colspan=""10"">一/二位走势</td>
			                <td colspan=""10"">一/三位走势</td>
			                <td colspan=""10"">二/三位走势</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 两码合分序
        public static string GetHtmlLmhFenxu(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string YiErHe = "";
            string YiSanHe = "";
            string ErSanHe = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                YiErHe += "YiErHe" + i.ToString() + ",";
                YiSanHe += "YiSanHe" + i.ToString() + ",";
                ErSanHe += "ErSanHe" + i.ToString() + ",";
            }

            YiErHe = YiErHe.Substring(0, YiErHe.Length - 1);
            YiSanHe = YiSanHe.Substring(0, YiSanHe.Length - 1);
            ErSanHe = ErSanHe.Substring(0, ErSanHe.Length - 1);

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
			                width: 1400px; 
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
			                <td rowspan=""2"" style=""width:7%"">期号</td>
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""10"">两码合分布图</td>
			                <td colspan=""10"">序(一)走势</td>
			                <td colspan=""10"">序(二)走势</td>
			                <td colspan=""10"">序(三)走势</td>
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
                ", YiErHe, YiSanHe, ErSanHe);

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] YiErHeInt = new int[10];
            int[] YiSanHeInt = new int[10];
            int[] ErSanHeInt = new int[10];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                int[] tempLot = new int[3];
                tempLot[0] = (lot1 + lot2) % 10;
                tempLot[1] = (lot1 + lot3) % 10;
                tempLot[2] = (lot2 + lot3) % 10;

                int liangmahe1 = tempLot[0];
                int liangmahe2 = tempLot[1];
                int liangmahe3 = tempLot[2];

                #region 分布
                Array.Sort(tempLot);

                for (int ii = 0; ii <= 9; ii++)
                {

                    if (Array.IndexOf<int>(tempLot, ii) == -1)
                    {
                        preExistCount[ii]++;
                        lotteryNumExit[ii] = false;
                    }
                    else
                    {
                        preExistCount[ii] = 0;
                        lotteryNumExit[ii] = true;
                    }
                }

                #endregion

                liangmahe1 = tempLot[0];
                liangmahe2 = tempLot[1];
                liangmahe3 = tempLot[2];

                #region 1 2
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe1)
                    {
                        YiErHeInt[ii] = 0;
                    }
                    else
                    {
                        YiErHeInt[ii]++;
                    }
                }
                #endregion

                #region 1 3
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe2)
                    {
                        YiSanHeInt[ii] = 0;
                    }
                    else
                    {
                        YiSanHeInt[ii]++;
                    }
                }
                #endregion

                #region 2 3
                for (int ii = 0; ii < 10; ii++)
                {
                    if (ii == liangmahe3)
                    {
                        ErSanHeInt[ii] = 0;
                    }
                    else
                    {
                        ErSanHeInt[ii]++;
                    }
                }
                #endregion
                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {44}>{4}</td>
                        <td {45}>{5}</td>
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
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        lotteryNumExit[0] ? "0" : preExistCount[0].ToString(),  // 4
                        lotteryNumExit[1] ? "1" : preExistCount[1].ToString(),
                        lotteryNumExit[2] ? "2" : preExistCount[2].ToString(),
                        lotteryNumExit[3] ? "3" : preExistCount[3].ToString(),
                        lotteryNumExit[4] ? "4" : preExistCount[4].ToString(),
                        lotteryNumExit[5] ? "5" : preExistCount[5].ToString(),
                        lotteryNumExit[6] ? "6" : preExistCount[6].ToString(),
                        lotteryNumExit[7] ? "7" : preExistCount[7].ToString(),
                        lotteryNumExit[8] ? "8" : preExistCount[8].ToString(),
                        lotteryNumExit[9] ? "9" : preExistCount[9].ToString(), //13

                        liangmahe1 == 0 ? "0" : YiErHeInt[0].ToString(), //14
                        liangmahe1 == 1 ? "1" : YiErHeInt[1].ToString(),
                        liangmahe1 == 2 ? "2" : YiErHeInt[2].ToString(),
                        liangmahe1 == 3 ? "3" : YiErHeInt[3].ToString(),
                        liangmahe1 == 4 ? "4" : YiErHeInt[4].ToString(),
                        liangmahe1 == 5 ? "5" : YiErHeInt[5].ToString(),
                        liangmahe1 == 6 ? "6" : YiErHeInt[6].ToString(),
                        liangmahe1 == 7 ? "7" : YiErHeInt[7].ToString(),
                        liangmahe1 == 8 ? "8" : YiErHeInt[8].ToString(),
                        liangmahe1 == 9 ? "9" : YiErHeInt[9].ToString(), // 23

                        liangmahe2 == 0 ? "0" : YiSanHeInt[0].ToString(), //24
                        liangmahe2 == 1 ? "1" : YiSanHeInt[1].ToString(),
                        liangmahe2 == 2 ? "2" : YiSanHeInt[2].ToString(),
                        liangmahe2 == 3 ? "3" : YiSanHeInt[3].ToString(),
                        liangmahe2 == 4 ? "4" : YiSanHeInt[4].ToString(),
                        liangmahe2 == 5 ? "5" : YiSanHeInt[5].ToString(),
                        liangmahe2 == 6 ? "6" : YiSanHeInt[6].ToString(),
                        liangmahe2 == 7 ? "7" : YiSanHeInt[7].ToString(),
                        liangmahe2 == 8 ? "8" : YiSanHeInt[8].ToString(),
                        liangmahe2 == 9 ? "9" : YiSanHeInt[9].ToString(), // 33

                        liangmahe3 == 0 ? "0" : ErSanHeInt[0].ToString(), //34
                        liangmahe3 == 1 ? "1" : ErSanHeInt[1].ToString(),
                        liangmahe3 == 2 ? "2" : ErSanHeInt[2].ToString(),
                        liangmahe3 == 3 ? "3" : ErSanHeInt[3].ToString(),
                        liangmahe3 == 4 ? "4" : ErSanHeInt[4].ToString(),
                        liangmahe3 == 5 ? "5" : ErSanHeInt[5].ToString(),
                        liangmahe3 == 6 ? "6" : ErSanHeInt[6].ToString(),
                        liangmahe3 == 7 ? "7" : ErSanHeInt[7].ToString(),
                        liangmahe3 == 8 ? "8" : ErSanHeInt[8].ToString(),
                        liangmahe3 == 9 ? "9" : ErSanHeInt[9].ToString(), // 43

                        lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", // 44
                        lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //53

                        liangmahe1 == 0 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //54
                        liangmahe1 == 1 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 2 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 3 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 4 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 5 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 6 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 7 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 8 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe1 == 9 ? @"class=""blueball middledata"" id=""YiErHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63

                        liangmahe2 == 0 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""", //64
                        liangmahe2 == 1 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 2 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 3 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 4 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 5 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 6 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 7 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 8 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmahe2 == 9 ? @"class=""redball"" id=""YiSanHe" + i.ToString() + @"""" : @"class=""grayfont""", //73

                        liangmahe3 == 0 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""", //74
                        liangmahe3 == 1 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 2 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 3 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 4 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 5 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 6 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 7 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 8 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmahe3 == 9 ? @"class=""blueball middledata"" id=""ErSanHe" + i.ToString() + @"""" : @"class=""middledata grayfont""" //83
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
		                <tr class=""headfoot"">
			                <td colspan=""10"">两码合分布图</td>
			                <td colspan=""10"">序(一)走势</td>
			                <td colspan=""10"">序(二)走势</td>
			                <td colspan=""10"">序(三)走势</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 两码差走势
        public static string GetHtmlLmcZouShi(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string YiErCha = "";
            string YiSanCha = "";
            string ErSanCha = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                YiErCha += "YiErCha" + i.ToString() + ",";
                YiSanCha += "YiSanCha" + i.ToString() + ",";
                ErSanCha += "ErSanCha" + i.ToString() + ",";
            }

            YiErCha = YiErCha.Substring(0, YiErCha.Length - 1);
            YiSanCha = YiSanCha.Substring(0, YiSanCha.Length - 1);
            ErSanCha = ErSanCha.Substring(0, ErSanCha.Length - 1);

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
			                width: 1400px; 
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
			                <td rowspan=""2"" style=""width:7%"">期号</td>
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""10"">两码差分布图</td>
			                <td colspan=""10"">一/二位走势</td>
			                <td colspan=""10"">一/三位走势</td>
			                <td colspan=""10"">二/三位走势</td>
		                </tr>
		                <tr class=""headfoot"">
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
                ", YiErCha, YiSanCha, ErSanCha);

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] YiErChaInt = new int[10];
            int[] YiSanChaInt = new int[10];
            int[] ErSanChaInt = new int[10];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                int[] tempLot = new int[3];
                tempLot[0] = Math.Abs(lot1 - lot2);
                tempLot[1] = Math.Abs(lot1 - lot3);
                tempLot[2] = Math.Abs(lot2 - lot3);

                int liangmaCha1 = tempLot[0];
                int liangmaCha2 = tempLot[1];
                int liangmaCha3 = tempLot[2];

                #region 分布
                Array.Sort(tempLot);

                for (int ii = 1; ii <= 10; ii++)
                {
                    if (Array.IndexOf<int>(tempLot, ii) == -1)
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

                #endregion

                #region 1 2
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha1)
                    {
                        YiErChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        YiErChaInt[ii - 1]++;
                    }
                }
                #endregion

                #region 1 3
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha2)
                    {
                        YiSanChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        YiSanChaInt[ii - 1]++;
                    }
                }
                #endregion

                #region 2 3
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha3)
                    {
                        ErSanChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        ErSanChaInt[ii - 1]++;
                    }
                }
                #endregion
                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {44}>{4}</td>
                        <td {45}>{5}</td>
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
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        lotteryNumExit[0] ? "1" : preExistCount[0].ToString(),  // 4
                        lotteryNumExit[1] ? "2" : preExistCount[1].ToString(),
                        lotteryNumExit[2] ? "3" : preExistCount[2].ToString(),
                        lotteryNumExit[3] ? "4" : preExistCount[3].ToString(),
                        lotteryNumExit[4] ? "5" : preExistCount[4].ToString(),
                        lotteryNumExit[5] ? "6" : preExistCount[5].ToString(),
                        lotteryNumExit[6] ? "7" : preExistCount[6].ToString(),
                        lotteryNumExit[7] ? "8" : preExistCount[7].ToString(),
                        lotteryNumExit[8] ? "9" : preExistCount[8].ToString(),
                        lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), //13

                        liangmaCha1 == 1 ? "1" : YiErChaInt[0].ToString(),
                        liangmaCha1 == 2 ? "2" : YiErChaInt[1].ToString(),
                        liangmaCha1 == 3 ? "3" : YiErChaInt[2].ToString(),
                        liangmaCha1 == 4 ? "4" : YiErChaInt[3].ToString(),
                        liangmaCha1 == 5 ? "5" : YiErChaInt[4].ToString(),
                        liangmaCha1 == 6 ? "6" : YiErChaInt[5].ToString(),
                        liangmaCha1 == 7 ? "7" : YiErChaInt[6].ToString(),
                        liangmaCha1 == 8 ? "8" : YiErChaInt[7].ToString(),
                        liangmaCha1 == 9 ? "9" : YiErChaInt[8].ToString(), // 23
                        liangmaCha1 == 10 ? "10" : YiErChaInt[9].ToString(), // 23

                        liangmaCha2 == 1 ? "1" : YiSanChaInt[0].ToString(),
                        liangmaCha2 == 2 ? "2" : YiSanChaInt[1].ToString(),
                        liangmaCha2 == 3 ? "3" : YiSanChaInt[2].ToString(),
                        liangmaCha2 == 4 ? "4" : YiSanChaInt[3].ToString(),
                        liangmaCha2 == 5 ? "5" : YiSanChaInt[4].ToString(),
                        liangmaCha2 == 6 ? "6" : YiSanChaInt[5].ToString(),
                        liangmaCha2 == 7 ? "7" : YiSanChaInt[6].ToString(),
                        liangmaCha2 == 8 ? "8" : YiSanChaInt[7].ToString(),
                        liangmaCha2 == 9 ? "9" : YiSanChaInt[8].ToString(), // 33
                        liangmaCha2 == 10 ? "10" : YiSanChaInt[9].ToString(), // 33

                        liangmaCha3 == 1 ? "1" : ErSanChaInt[0].ToString(),
                        liangmaCha3 == 2 ? "2" : ErSanChaInt[1].ToString(),
                        liangmaCha3 == 3 ? "3" : ErSanChaInt[2].ToString(),
                        liangmaCha3 == 4 ? "4" : ErSanChaInt[3].ToString(),
                        liangmaCha3 == 5 ? "5" : ErSanChaInt[4].ToString(),
                        liangmaCha3 == 6 ? "6" : ErSanChaInt[5].ToString(),
                        liangmaCha3 == 7 ? "7" : ErSanChaInt[6].ToString(),
                        liangmaCha3 == 8 ? "8" : ErSanChaInt[7].ToString(),
                        liangmaCha3 == 9 ? "9" : ErSanChaInt[8].ToString(), // 43
                        liangmaCha3 == 10 ? "10" : ErSanChaInt[9].ToString(), // 43

                        lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", // 44
                        lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //53

                        liangmaCha1 == 1 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 2 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 3 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 4 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 5 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 6 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 7 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 8 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 9 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63
                        liangmaCha1 == 10 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63

                        liangmaCha2 == 1 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 2 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 3 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 4 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 5 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 6 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 7 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 8 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 9 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""", //73
                        liangmaCha2 == 10 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""", //73

                        liangmaCha3 == 1 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 2 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 3 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 4 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 5 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 6 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 7 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 8 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 9 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //83
                        liangmaCha3 == 10 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""" //83
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
			                <td colspan=""10"">两码差分布图</td>
			                <td colspan=""10"">一/二位走势</td>
			                <td colspan=""10"">一/三位走势</td>
			                <td colspan=""10"">二/三位走势</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 两码差分序
        public static string GetHtmlLmcFenxu(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string YiErCha = "";
            string YiSanCha = "";
            string ErSanCha = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                YiErCha += "YiErCha" + i.ToString() + ",";
                YiSanCha += "YiSanCha" + i.ToString() + ",";
                ErSanCha += "ErSanCha" + i.ToString() + ",";
            }

            YiErCha = YiErCha.Substring(0, YiErCha.Length - 1);
            YiSanCha = YiSanCha.Substring(0, YiSanCha.Length - 1);
            ErSanCha = ErSanCha.Substring(0, ErSanCha.Length - 1);

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
			                width: 1400px; 
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
			                <td rowspan=""2"" style=""width:7%"">期号</td>
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""10"">两码差分布图</td>
			                <td colspan=""10"">序(一)走势</td>
			                <td colspan=""10"">序(二)走势</td>
			                <td colspan=""10"">序(三)走势</td>
		                </tr>
		                <tr class=""headfoot"">
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
                ", YiErCha, YiSanCha, ErSanCha);

            string html = TOP;

            int[] preExistCount = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExit = new bool[] { false, false, false, false, false, false, false, false, false, false, false };

            int[] YiErChaInt = new int[10];
            int[] YiSanChaInt = new int[10];
            int[] ErSanChaInt = new int[10];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                int[] tempLot = new int[3];
                tempLot[0] = Math.Abs(lot1 - lot2);
                tempLot[1] = Math.Abs(lot1 - lot3);
                tempLot[2] = Math.Abs(lot2 - lot3);

                int liangmaCha1 = tempLot[0];
                int liangmaCha2 = tempLot[1];
                int liangmaCha3 = tempLot[2];

                #region 分布
                Array.Sort(tempLot);

                for (int ii = 1; ii <= 10; ii++)
                {
                    if (Array.IndexOf<int>(tempLot, ii) == -1)
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

                #endregion

                liangmaCha1 = tempLot[0];
                liangmaCha2 = tempLot[1];
                liangmaCha3 = tempLot[2];

                #region 1 2
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha1)
                    {
                        YiErChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        YiErChaInt[ii - 1]++;
                    }
                }
                #endregion

                #region 1 3
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha2)
                    {
                        YiSanChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        YiSanChaInt[ii - 1]++;
                    }
                }
                #endregion

                #region 2 3
                for (int ii = 1; ii < 11; ii++)
                {
                    if (ii == liangmaCha3)
                    {
                        ErSanChaInt[ii - 1] = 0;
                    }
                    else
                    {
                        ErSanChaInt[ii - 1]++;
                    }
                }
                #endregion
                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {44}>{4}</td>
                        <td {45}>{5}</td>
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
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        lotteryNumExit[0] ? "1" : preExistCount[0].ToString(),  // 4
                        lotteryNumExit[1] ? "2" : preExistCount[1].ToString(),
                        lotteryNumExit[2] ? "3" : preExistCount[2].ToString(),
                        lotteryNumExit[3] ? "4" : preExistCount[3].ToString(),
                        lotteryNumExit[4] ? "5" : preExistCount[4].ToString(),
                        lotteryNumExit[5] ? "6" : preExistCount[5].ToString(),
                        lotteryNumExit[6] ? "7" : preExistCount[6].ToString(),
                        lotteryNumExit[7] ? "8" : preExistCount[7].ToString(),
                        lotteryNumExit[8] ? "8" : preExistCount[8].ToString(),
                        lotteryNumExit[9] ? "10" : preExistCount[9].ToString(), //13

                        liangmaCha1 == 1 ? "1" : YiErChaInt[0].ToString(),
                        liangmaCha1 == 2 ? "2" : YiErChaInt[1].ToString(),
                        liangmaCha1 == 3 ? "3" : YiErChaInt[2].ToString(),
                        liangmaCha1 == 4 ? "4" : YiErChaInt[3].ToString(),
                        liangmaCha1 == 5 ? "5" : YiErChaInt[4].ToString(),
                        liangmaCha1 == 6 ? "6" : YiErChaInt[5].ToString(),
                        liangmaCha1 == 7 ? "7" : YiErChaInt[6].ToString(),
                        liangmaCha1 == 8 ? "8" : YiErChaInt[7].ToString(),
                        liangmaCha1 == 9 ? "9" : YiErChaInt[8].ToString(), // 23
                        liangmaCha1 == 10 ? "10" : YiErChaInt[9].ToString(), // 23

                        liangmaCha2 == 1 ? "1" : YiSanChaInt[0].ToString(),
                        liangmaCha2 == 2 ? "2" : YiSanChaInt[1].ToString(),
                        liangmaCha2 == 3 ? "3" : YiSanChaInt[2].ToString(),
                        liangmaCha2 == 4 ? "4" : YiSanChaInt[3].ToString(),
                        liangmaCha2 == 5 ? "5" : YiSanChaInt[4].ToString(),
                        liangmaCha2 == 6 ? "6" : YiSanChaInt[5].ToString(),
                        liangmaCha2 == 7 ? "7" : YiSanChaInt[6].ToString(),
                        liangmaCha2 == 8 ? "8" : YiSanChaInt[7].ToString(),
                        liangmaCha2 == 9 ? "9" : YiSanChaInt[8].ToString(), // 33
                        liangmaCha2 == 10 ? "10" : YiSanChaInt[9].ToString(), // 33

                        liangmaCha3 == 1 ? "1" : ErSanChaInt[0].ToString(),
                        liangmaCha3 == 2 ? "2" : ErSanChaInt[1].ToString(),
                        liangmaCha3 == 3 ? "3" : ErSanChaInt[2].ToString(),
                        liangmaCha3 == 4 ? "4" : ErSanChaInt[3].ToString(),
                        liangmaCha3 == 5 ? "5" : ErSanChaInt[4].ToString(),
                        liangmaCha3 == 6 ? "6" : ErSanChaInt[5].ToString(),
                        liangmaCha3 == 7 ? "7" : ErSanChaInt[6].ToString(),
                        liangmaCha3 == 8 ? "8" : ErSanChaInt[7].ToString(),
                        liangmaCha3 == 9 ? "9" : ErSanChaInt[8].ToString(), // 43
                        liangmaCha3 == 10 ? "10" : ErSanChaInt[9].ToString(), // 43

                        lotteryNumExit[0] ? @"class=""redball""" : @"class=""grayfont""", // 44
                        lotteryNumExit[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExit[9] ? @"class=""redball""" : @"class=""grayfont""", //53

                        liangmaCha1 == 1 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 2 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 3 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 4 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 5 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 6 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 7 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 8 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha1 == 9 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63
                        liangmaCha1 == 10 ? @"class=""blueball middledata"" id=""YiErCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //63

                        liangmaCha2 == 1 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 2 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 3 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 4 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 5 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 6 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 7 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 8 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""",
                        liangmaCha2 == 9 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""", //73
                        liangmaCha2 == 10 ? @"class=""redball"" id=""YiSanCha" + i.ToString() + @"""" : @"class=""grayfont""", //73

                        liangmaCha3 == 1 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 2 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 3 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 4 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 5 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 6 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 7 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 8 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        liangmaCha3 == 9 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""", //83
                        liangmaCha3 == 10 ? @"class=""blueball middledata"" id=""ErSanCha" + i.ToString() + @"""" : @"class=""middledata grayfont""" //83
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
			                <td colspan=""10"">两码差分布图</td>
			                <td colspan=""10"">序(一)走势</td>
			                <td colspan=""10"">序(二)走势</td>
			                <td colspan=""10"">序(三)走势</td>
		                </tr>
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 前后轨迹 合差/差和
        public static string GetHtmlQhgjHcch(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string Qianhouguiji = "";
            string Chahezoushi = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Qianhouguiji += "Qianhouguiji" + i.ToString() + ",";
                Chahezoushi += "Chahezoushi" + i.ToString() + ",";
            }

            Qianhouguiji = Qianhouguiji.Substring(0, Qianhouguiji.Length - 1);
            Chahezoushi = Chahezoushi.Substring(0, Chahezoushi.Length - 1);

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
			                width: 1400px; 
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
                            DrawLine_blue(""{1}"",""19"", ""4"");
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
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""21"">前后轨迹走势图</td>
			                <td colspan=""10"">合差走势</td>
			                <td colspan=""9"">差和走势</td>
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
                            <td class=""equalwidth"">6</td>
                            <td class=""equalwidth"">8</td>
                            <td class=""equalwidth"">10</td>
                            <td class=""equalwidth"">12</td>
                            <td class=""equalwidth"">14</td>
                            <td class=""equalwidth"">16</td>
                            <td class=""equalwidth"">18</td>
                            <td class=""equalwidth"">20</td>
		                </tr> 
                ", Qianhouguiji, Chahezoushi);

            string html = TOP;

            int[] QianhoujianjuInt = new int[21];

            int[] preExistCountHecha = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExitHecha = new bool[] { false, false, false, false, false, false, false, false, false, false };

            int[] LiangmachaheInt = new int[9];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 前后轨迹
                int qhgj = Math.Abs(lot1 - 1) + Math.Abs(lot3 - 11);

                for (int ii = 0; ii < 21; ii++)
                {
                    if (ii == qhgj)
                    {
                        QianhoujianjuInt[ii] = 0;
                    }
                    else
                    {
                        QianhoujianjuInt[ii]++;
                    }
                }
                #endregion

                #region 合差
                int[] tempHe = new int[3];
                tempHe[0] = (lot1 + lot2) % 10;
                tempHe[1] = (lot1 + lot3) % 10;
                tempHe[2] = (lot2 + lot3) % 10;
                Array.Sort(tempHe);

                int[] HechaJJ = new int[3];
                HechaJJ[0] = Math.Abs(tempHe[1] - tempHe[0]);
                HechaJJ[1] = Math.Abs(tempHe[2] - tempHe[1]);
                HechaJJ[2] = Math.Abs(tempHe[2] - tempHe[0]);
                Array.Sort(HechaJJ);

                for (int ii = 0; ii <= 9; ii++)
                {

                    if (Array.IndexOf<int>(HechaJJ, ii) == -1)
                    {
                        preExistCountHecha[ii]++;
                        lotteryNumExitHecha[ii] = false;
                    }
                    else
                    {
                        preExistCountHecha[ii] = 0;
                        lotteryNumExitHecha[ii] = true;
                    }
                }
                #endregion

                #region 差和
                int[] tempCha = new int[3];
                tempCha[0] = Math.Abs(lot1 - lot2);
                tempCha[1] = Math.Abs(lot1 - lot3);
                tempCha[2] = Math.Abs(lot2 - lot3);
                Array.Sort(tempCha);

                int Chahe = tempCha[1] + tempCha[0] + tempCha[2];

                for (int ii = 4, j = 0; ii < 21; )
                {
                    if (ii == Chahe)
                    {
                        LiangmachaheInt[j] = 0;
                    }
                    else
                    {
                        LiangmachaheInt[j]++;
                    }
                    ii += 2;
                    j++;
                }
                #endregion
                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                            <td {44}>{4}</td>
                            <td {45}>{5}</td>
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
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        qhgj == 0 ? "0" : QianhoujianjuInt[0].ToString(), //4
                        qhgj == 1 ? "1" : QianhoujianjuInt[1].ToString(),
                        qhgj == 2 ? "2" : QianhoujianjuInt[2].ToString(),
                        qhgj == 3 ? "3" : QianhoujianjuInt[3].ToString(),
                        qhgj == 4 ? "4" : QianhoujianjuInt[4].ToString(),
                        qhgj == 5 ? "5" : QianhoujianjuInt[5].ToString(),
                        qhgj == 6 ? "6" : QianhoujianjuInt[6].ToString(),
                        qhgj == 7 ? "7" : QianhoujianjuInt[7].ToString(),
                        qhgj == 8 ? "8" : QianhoujianjuInt[8].ToString(),
                        qhgj == 9 ? "9" : QianhoujianjuInt[9].ToString(),
                        qhgj == 10 ? "10" : QianhoujianjuInt[10].ToString(),
                        qhgj == 11 ? "11" : QianhoujianjuInt[11].ToString(),
                        qhgj == 12 ? "12" : QianhoujianjuInt[12].ToString(),
                        qhgj == 13 ? "13" : QianhoujianjuInt[13].ToString(),
                        qhgj == 14 ? "14" : QianhoujianjuInt[14].ToString(),
                        qhgj == 15 ? "15" : QianhoujianjuInt[15].ToString(),
                        qhgj == 16 ? "16" : QianhoujianjuInt[16].ToString(),
                        qhgj == 17 ? "17" : QianhoujianjuInt[17].ToString(),
                        qhgj == 18 ? "18" : QianhoujianjuInt[18].ToString(),
                        qhgj == 19 ? "19" : QianhoujianjuInt[19].ToString(),
                        qhgj == 20 ? "20" : QianhoujianjuInt[20].ToString(),

                        lotteryNumExitHecha[0] ? "0" : preExistCountHecha[0].ToString(), // 25
                        lotteryNumExitHecha[1] ? "1" : preExistCountHecha[1].ToString(),
                        lotteryNumExitHecha[2] ? "2" : preExistCountHecha[2].ToString(),
                        lotteryNumExitHecha[3] ? "3" : preExistCountHecha[3].ToString(),
                        lotteryNumExitHecha[4] ? "4" : preExistCountHecha[4].ToString(),
                        lotteryNumExitHecha[5] ? "5" : preExistCountHecha[5].ToString(),
                        lotteryNumExitHecha[6] ? "6" : preExistCountHecha[6].ToString(),
                        lotteryNumExitHecha[7] ? "7" : preExistCountHecha[7].ToString(),
                        lotteryNumExitHecha[8] ? "8" : preExistCountHecha[8].ToString(),
                        lotteryNumExitHecha[9] ? "9" : preExistCountHecha[9].ToString(),

                        Chahe == 4 ? "4" : LiangmachaheInt[0].ToString(),
                        Chahe == 6 ? "6" : LiangmachaheInt[1].ToString(),
                        Chahe == 8 ? "8" : LiangmachaheInt[2].ToString(),
                        Chahe == 10 ? "10" : LiangmachaheInt[3].ToString(),
                        Chahe == 12 ? "12" : LiangmachaheInt[4].ToString(),
                        Chahe == 14 ? "14" : LiangmachaheInt[5].ToString(),
                        Chahe == 16 ? "16" : LiangmachaheInt[6].ToString(),
                        Chahe == 18 ? "18" : LiangmachaheInt[7].ToString(),
                        Chahe == 20 ? "20" : LiangmachaheInt[8].ToString(),

                        qhgj == 0 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",//44
                        qhgj == 1 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 2 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 3 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 4 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 5 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 6 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 7 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 8 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 9 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 10 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 11 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 12 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 13 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 14 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 15 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 16 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 17 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 18 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 19 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        qhgj == 20 ? @"class=""blueball middledata"" id=""Qianhouguiji" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        lotteryNumExitHecha[0] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHecha[9] ? @"class=""redball""" : @"class=""grayfont""",

                        Chahe == 4 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 6 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 8 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 10 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 12 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 14 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 16 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 18 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        Chahe == 20 ? @"class=""blueball middledata"" id=""Chahezoushi" + i.ToString() + @"""" : @"class=""middledata grayfont"""
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
                            <td class=""unclk"">6</td>
                            <td class=""unclk"">8</td>
                            <td class=""unclk"">10</td>
                            <td class=""unclk"">12</td>
                            <td class=""unclk"">14</td>
                            <td class=""unclk"">16</td>
                            <td class=""unclk"">18</td>
                            <td class=""unclk"">20</td>
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""21"">前后轨迹走势图</</td>
			                <td colspan=""10"">合差走势</td>
			                <td colspan=""9"">差和走势</</td>
		                </tr>                  
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

        #region 两码合间距 两码差间距
        public static string GetHtmlLmHCJianJu(List<Lottery11_3> lotterys11_3, List<string> days)
        {
            string LmheJJ = "";
            string LmchaJJ = "";

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                LmheJJ += "LmheJJ" + i.ToString() + ",";
                LmchaJJ += "LmchaJJ" + i.ToString() + ",";
            }

            LmheJJ = LmheJJ.Substring(0, LmheJJ.Length - 1);
            LmchaJJ = LmchaJJ.Substring(0, LmchaJJ.Length - 1);

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
			                width: 1400px; 
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
                            DrawLine_blue(""{1}"",""19"", ""4"");
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
			                <td rowspan=""2"" colspan=""3"" style=""width:7%"">开奖号码</td>
			                <td colspan=""10"">两码合分布图</td>
			                <td colspan=""8"">两码合间距走势</td>
			                <td colspan=""10"">两码差分布图</td>
			                <td colspan=""8"">两码差间距走势</td>
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
		                </tr> 
                ", LmheJJ, LmchaJJ);

            string html = TOP;

            int[] preExistCountHe = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExitHe = new bool[] { false, false, false, false, false, false, false, false, false, false, false };
            int[] LiangmaheInt = new int[8];

            int[] preExistCountCha = new int[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            bool[] lotteryNumExitCha = new bool[] { false, false, false, false, false, false, false, false, false, false, false };
            int[] LiangmachaInt = new int[8];

            for (int i = 0; i < lotterys11_3.Count; i++)
            {
                Lottery11_3 lottery = lotterys11_3[i];

                int lot1 = int.Parse(lottery.PreSort[0].ToString("D2"));
                int lot2 = int.Parse(lottery.PreSort[1].ToString("D2"));
                int lot3 = int.Parse(lottery.PreSort[2].ToString("D2"));

                #region 合
                int[] tempHe = new int[3];
                tempHe[0] = (lot1 + lot2) % 10;
                tempHe[1] = (lot1 + lot3) % 10;
                tempHe[2] = (lot2 + lot3) % 10;
                Array.Sort(tempHe);

                int[] HeJJ = new int[2];
                HeJJ[0] = tempHe[1] - tempHe[0] - 1;
                HeJJ[1] = tempHe[2] - tempHe[1] - 1;
                Array.Sort(HeJJ);

                for (int ii = 0; ii <= 9; ii++)
                {

                    if (Array.IndexOf<int>(tempHe, ii) == -1)
                    {
                        preExistCountHe[ii]++;
                        lotteryNumExitHe[ii] = false;
                    }
                    else
                    {
                        preExistCountHe[ii] = 0;
                        lotteryNumExitHe[ii] = true;
                    }
                }

                // 间距
                for (int ii = 0; ii < 8; ii++)
                {
                    if (ii == HeJJ[1])
                    {
                        LiangmaheInt[ii] = 0;
                    }
                    else
                    {
                        LiangmaheInt[ii]++;
                    }
                }
                #endregion

                #region 差
                int[] tempCha = new int[3];
                tempCha[0] = Math.Abs(lot1 - lot2);
                tempCha[1] = Math.Abs(lot1 - lot3);
                tempCha[2] = Math.Abs(lot2 - lot3);
                Array.Sort(tempCha);

                int[] ChaJJ = new int[2];
                ChaJJ[0] = tempCha[1] - tempCha[0] - 1;
                ChaJJ[1] = tempCha[2] - tempCha[1] - 1;
                Array.Sort(ChaJJ);

                for (int ii = 0; ii <= 9; ii++)
                {

                    if (Array.IndexOf<int>(tempCha, ii) == -1)
                    {
                        preExistCountCha[ii]++;
                        lotteryNumExitCha[ii] = false;
                    }
                    else
                    {
                        preExistCountCha[ii] = 0;
                        lotteryNumExitCha[ii] = true;
                    }
                }

                // 间距
                for (int ii = 0; ii < 8; ii++)
                {
                    if (ii == ChaJJ[1])
                    {
                        LiangmachaInt[ii] = 0;
                    }
                    else
                    {
                        LiangmachaInt[ii]++;
                    }
                }
                #endregion

                html += string.Format(
                    @"
                    <tr>
			            <td>{0}</td>
			            <td class=""middledata redballfont equalwidth"">{1}</td>
			            <td class=""middledata redballfont equalwidth"">{2}</td>
			            <td class=""middledata redballfont equalwidth"">{3}</td>
                        <td {40}>{4}</td>
                        <td {41}>{5}</td>
                        <td {42}>{6}</td>
                        <td {43}>{7}</td>
                        <td {44}>{8}</td>
                        <td {45}>{9}</td>
                        <td {46}>{10}</td>
                        <td {47}>{11}</td>
                        <td {48}>{12}</td>
                        <td {49}>{13}</td>
                        <td {50}>{14}</td>
                        <td {51}>{15}</td>
                        <td {52}>{16}</td>
                        <td {53}>{17}</td>
                        <td {54}>{18}</td>
                        <td {55}>{19}</td>
                        <td {56}>{20}</td>
                        <td {57}>{21}</td>
                        <td {58}>{22}</td>
                        <td {59}>{23}</td>
                        <td {60}>{24}</td>
                        <td {61}>{25}</td>
                        <td {62}>{26}</td>
                        <td {63}>{27}</td>
                        <td {64}>{28}</td>
                        <td {65}>{29}</td>
                        <td {66}>{30}</td>
                        <td {67}>{31}</td>
                        <td {68}>{32}</td>
                        <td {69}>{33}</td>
                        <td {70}>{34}</td>
                        <td {71}>{35}</td>
                        <td {72}>{36}</td>
                        <td {73}>{37}</td>
                        <td {74}>{38}</td>
                        <td {75}>{39}</td>
		            </tr>
                    ", days[i], lottery.PreSort[0].ToString("D2"), lottery.PreSort[1].ToString("D2"), lottery.PreSort[2].ToString("D2"), // 0 - 3

                        lotteryNumExitHe[0] ? "0" : preExistCountHe[0].ToString(), // 4
                        lotteryNumExitHe[1] ? "1" : preExistCountHe[1].ToString(),
                        lotteryNumExitHe[2] ? "2" : preExistCountHe[2].ToString(),
                        lotteryNumExitHe[3] ? "3" : preExistCountHe[3].ToString(),
                        lotteryNumExitHe[4] ? "4" : preExistCountHe[4].ToString(),
                        lotteryNumExitHe[5] ? "5" : preExistCountHe[5].ToString(),
                        lotteryNumExitHe[6] ? "6" : preExistCountHe[6].ToString(),
                        lotteryNumExitHe[7] ? "7" : preExistCountHe[7].ToString(),
                        lotteryNumExitHe[8] ? "8" : preExistCountHe[8].ToString(),
                        lotteryNumExitHe[9] ? "9" : preExistCountHe[9].ToString(),

                        HeJJ[1] == 0 ? "0" : LiangmaheInt[0].ToString(),
                        HeJJ[1] == 1 ? "1" : LiangmaheInt[1].ToString(),
                        HeJJ[1] == 2 ? "2" : LiangmaheInt[2].ToString(),
                        HeJJ[1] == 3 ? "3" : LiangmaheInt[3].ToString(),
                        HeJJ[1] == 4 ? "4" : LiangmaheInt[4].ToString(),
                        HeJJ[1] == 5 ? "5" : LiangmaheInt[5].ToString(),
                        HeJJ[1] == 6 ? "6" : LiangmaheInt[6].ToString(),
                        HeJJ[1] == 7 ? "7" : LiangmaheInt[7].ToString(),

                        lotteryNumExitCha[0] ? "0" : preExistCountCha[0].ToString(),
                        lotteryNumExitCha[1] ? "1" : preExistCountCha[1].ToString(),
                        lotteryNumExitCha[2] ? "2" : preExistCountCha[2].ToString(),
                        lotteryNumExitCha[3] ? "3" : preExistCountCha[3].ToString(),
                        lotteryNumExitCha[4] ? "4" : preExistCountCha[4].ToString(),
                        lotteryNumExitCha[5] ? "5" : preExistCountCha[5].ToString(),
                        lotteryNumExitCha[6] ? "6" : preExistCountCha[6].ToString(),
                        lotteryNumExitCha[7] ? "7" : preExistCountCha[7].ToString(),
                        lotteryNumExitCha[8] ? "8" : preExistCountCha[8].ToString(),
                        lotteryNumExitCha[9] ? "9" : preExistCountCha[9].ToString(),

                        ChaJJ[1] == 0 ? "0" : LiangmachaInt[0].ToString(),
                        ChaJJ[1] == 1 ? "1" : LiangmachaInt[1].ToString(),
                        ChaJJ[1] == 2 ? "2" : LiangmachaInt[2].ToString(),
                        ChaJJ[1] == 3 ? "3" : LiangmachaInt[3].ToString(),
                        ChaJJ[1] == 4 ? "4" : LiangmachaInt[4].ToString(),
                        ChaJJ[1] == 5 ? "5" : LiangmachaInt[5].ToString(),
                        ChaJJ[1] == 6 ? "6" : LiangmachaInt[6].ToString(),
                        ChaJJ[1] == 7 ? "7" : LiangmachaInt[7].ToString(),

                        lotteryNumExitHe[0] ? @"class=""redball""" : @"class=""grayfont""", //40
                        lotteryNumExitHe[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitHe[9] ? @"class=""redball""" : @"class=""grayfont""",

                        HeJJ[1] == 0 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 1 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 2 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 3 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 4 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 5 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 6 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        HeJJ[1] == 7 ? @"class=""blueball middledata"" id=""LmheJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",

                        lotteryNumExitCha[0] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[1] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[2] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[3] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[4] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[5] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[6] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[7] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[8] ? @"class=""redball""" : @"class=""grayfont""",
                        lotteryNumExitCha[9] ? @"class=""redball""" : @"class=""grayfont""",

                        ChaJJ[1] == 0 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 1 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 2 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 3 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 4 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 5 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 6 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont""",
                        ChaJJ[1] == 7 ? @"class=""blueball middledata"" id=""LmchaJJ" + i.ToString() + @"""" : @"class=""middledata grayfont"""
                );
            }

            html +=
                @"
                    <tr class=""headfoot"">
			                <td rowspan=""2"" colspan=""4""><input type=""button"" value=""提交选择"" /></td>
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
		                </tr>
		                <tr class=""headfoot"">
			                <td colspan=""10"">两码合分布图</</td>
			                <td colspan=""8"">两码合间距走势</td>
			                <td colspan=""10"">两码差分布图</</td>
			                <td colspan=""8"">两码差间距走势</</td>
		                </tr>                  
		
	                </table>
	
                </body>
                </html>";

            return html;
        }
        #endregion

    }
}
