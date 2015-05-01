using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.SqlClient;
using System.Data;
using MySql.Data.MySqlClient;
using System.Security.Cryptography;
using System.Net;
using System.IO;
using System.Windows.Forms;

namespace CyyClient
{

    public enum LotteryType11_5
    {
        SD_11_5 = 1, GD_11_5, JX_11_5, CQ_11_5, JS_11_5, ZJ_11_5, SH_11_5
    }

    public enum LotteryType11_3
    {
        SD_11_3 = 1, GD_11_3, JX_11_3, CQ_11_3, JS_11_3, ZJ_11_3, SH_11_3
    }


    public struct LotteryInfo
    {
        public string Day { get; set; }
        public string Data { get; set; }
    }

    class CyyDatabase
    {
        public static CyyDatabase cyyDB = null;

        // localhost
        //private const string sqlConnectionCommand = @"Data Source=(local);Initial Catalog=WinData;User ID=sa;Password=123";

        // SQL server
        //private const string sqlConnectionCommand = @"Data Source=qds-010.hichina.com;Initial Catalog=qds0100145_db;User ID=qds0100145;Password=CYYDB2014";
        //private const string sqlConnectionCommand = @"server=localhost; user id=root; password=123456; database=cyydb";

        //private SqlConnection sqlConnection = new SqlConnection(sqlConnectionCommand);

        // MySQL
//        private const string sqlConnectionCommand = @"server=qdm-011.hichina.com; user id=qdm0110106; password=CYYDB2014; database=qdm0110106_db";
        private const string sqlConnectionCommand = @"server=120.27.30.10; user id=admin; password=admin; database=cyydb;Charset=utf8";
        private MySqlConnection sqlConnection = new MySqlConnection(sqlConnectionCommand);

        private CyyDatabase() { }

        public static CyyDatabase GetDatabase()
        {
            if (cyyDB == null)
            {
                cyyDB = new CyyDatabase();
            }

            return cyyDB;
        }

        public void DbOpen()
        {
            try
            {
                if (sqlConnection.State != ConnectionState.Open)
                {
                    sqlConnection.Open();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "无法打开连接！");
                return;
            }
        }

        public void DbClose()
        {
            sqlConnection.Close();
        }

        #region 获取往期彩票信息
        public List<LotteryInfo> GetLotteryInfos(int lotteryType, int cpname, int realCPName)
        {
            DbOpen();
            StringBuilder sbSQL = new StringBuilder(@"SELECT CDay, CData FROM cyyCPData where ctype = ");

            sbSQL.Append(lotteryType);

            sbSQL.Append(@" ORDER BY CDAY DESC LIMIT 150");
            string SQL = sbSQL.ToString();
            MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);

            MySqlDataReader dataReader = cmd.ExecuteReader();

            List<LotteryInfo> lotteryInfos = new List<LotteryInfo>();

            while (dataReader.Read())
            {
                // 11选5
                if (realCPName == 1)
                {
                    lotteryInfos.Add(new LotteryInfo { Data = dataReader["CData"].ToString(), Day = dataReader["CDay"].ToString() });
                }
                // 11选3
                else if (realCPName == 2)
                {
                    lotteryInfos.Add(new LotteryInfo { Data = dataReader["CData"].ToString().Substring(0, 6), Day = dataReader["CDay"].ToString() });
                }
            }

            dataReader.Close();
            DbClose();
            return lotteryInfos;
        }
        #endregion


        static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        static bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        #region Users表更新数据
        public DataTable UserLogin(string acc, string psw)
        {
            MD5 md5Hash = MD5.Create();
            string hash = GetMd5Hash(md5Hash, psw);
            DataSet dataSet = null;
            StringBuilder sbSQL = new StringBuilder(
                    @"SELECT user_name, realname, nickname, degreeid, UserLogined_day, UserLogined_ip, UserLisDay, city, province, 
                        CASE 
                            WHEN degreeid = 1 THEN 'NO'
                            ELSE 'OK'
                        END AS permission,
                        CASE
                            WHEN UserLisDay > NOW() THEN 'OK'
	                        ELSE 'OVER'
                        END AS state
                    FROM ecs_users WHERE user_name = '");
            sbSQL.Append(acc);
            sbSQL.Append(@"'");
            sbSQL.Append(@" AND Password = '");
            sbSQL.Append(hash.ToLower());
            sbSQL.Append(@"'");
            try
            {
            DbOpen();
                string SQL = sbSQL.ToString();
                MySqlDataAdapter adapter = new MySqlDataAdapter();
                adapter.TableMappings.Add("Table", "Users");

                MySqlCommand command = new MySqlCommand(SQL, sqlConnection);
                command.CommandType = CommandType.Text;

                adapter.SelectCommand = command;

                dataSet = new DataSet("Users");
                adapter.Fill(dataSet);
                DbClose();
            }
            catch (Exception e)
            {
                if (MessageBox.Show("用户登录出现异常,请重启软件!" + e.Message, "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    CyyMain.cyyMainExit();
                }
            }
            return dataSet.Tables["Users"];
        }

        // 检测是否重复登陆
        public int CheckCountOfSameOnlineUserLogin(string user_name)
        {
            int loginCount = 0;
            try
            {
                DbOpen();
                string SQL = @"Select Count(user_name) From cyy_OnlinesUsers WHERE user_name = '" + user_name + @"'";
                MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);

                MySqlDataReader dataReader = cmd.ExecuteReader();
                dataReader.Read();

                loginCount = int.Parse(dataReader["Count(user_name)"].ToString());
                dataReader.Close();
                DbClose();
            }
            catch (Exception e)
            {
                if (MessageBox.Show("用户登录出现异常,请重启软件!" + e.Message, "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    CyyMain.cyyMainExit();
                }
            }

            return loginCount;
        }
        #endregion

        private string GetLocateAndIP()
        {
            string ipDirection = "N/A";
            string addressDirection = "N/A";

            try
            {
                string direction = "";
                WebRequest request = WebRequest.Create("http://www.ip38.com");
                using (WebResponse response = request.GetResponse())
                using (StreamReader stream = new StreamReader(response.GetResponseStream(), System.Text.Encoding.Default))
                {
                    direction = stream.ReadToEnd();
                }
                string ipPre = "您的本机IP地址：[<font color=#FF0000>";
                string addressPre = "&nbsp;来自：<font color=#FF0000>";
                int ipFirst = direction.IndexOf(ipPre) + ipPre.Length;
                int ipLast = direction.LastIndexOf("</font>]&nbsp;来自");

                int addressFirst = direction.IndexOf(addressPre) + addressPre.Length;
                int addressLast = direction.LastIndexOf("</font></font></div>\n<div align=\"center\"> \n  <script language=\"javascript\">");

                ipDirection = direction.Substring(ipFirst, ipLast - ipFirst);
                addressDirection = direction.Substring(addressFirst, addressLast - addressFirst);
            }
            catch
            {
                ipDirection = "未知";
                addressDirection = "未知";
            }
            return ipDirection + "," + addressDirection;
        }

        public void InserUserOnline(UserInfo ui)
        {
            try
            {
                string[] ipAndAdress = GetLocateAndIP().Split(',');
                CyyMain.currentIP = ipAndAdress[0];

                CyyMain.currentAddress = ipAndAdress[1];
                DbOpen();
                string SQL1 = @"INSERT INTO cyy_OnlinesUsers(user_name, realname, nickname, degreeid, city, province, UserLogined_day,UserLogined_DaySave, versionName, versionID,UserLogined_ip, UserLogined_Address)
                        VALUES("
                      + @"'" + ui["user_name"] + @"',"
                      + @"'" + ui["realname"] + @"',"
                      + @"'" + ui["nickname"] + @"',"
                      + @"'" + ui["degreeid"] + @"',"
                      + @"'" + ui["city"] + @"',"
                      + @"'" + ui["province"] + @"',"
                      + @" NOW()"
                      + @", NOW()"
                      + @",'" + CyyMain.productKeyVersionNameString
                      + @"','" + CyyMain.proudctVersionString
                      + @"','" + CyyMain.currentIP
                      + @"','" + CyyMain.currentAddress
                      + @"');";

                string SQL2 = @"UPDATE ecs_users SET UserLogined_ip = '" + CyyMain.currentIP + "'" + ", UserLogined_Address = '" + CyyMain.currentAddress + @"'"
                    + " WHERE user_name = '" + ui["user_name"] + "'";
                string sql = SQL1 + "\r\n" + SQL2;
                MySqlCommand cmd = new MySqlCommand(sql, sqlConnection);

                cmd.ExecuteNonQuery();
                DbClose();
            }
            catch (Exception e)
            {
                if (MessageBox.Show("用户登录出现异常,请重启软件!" + e.Message, "警告", MessageBoxButtons.OK) == DialogResult.OK)
                {
                    CyyMain.cyyMainExit();
                }
            }
        }

        public void InsertDateNow(UserInfo ui)
        {
            DbOpen();
            string SQLMAX =
            @"SELECT 
                CASE
	                WHEN ISNULL(MAX(timestampdiff(second, UserLogined_daysave,now()))) = 1 THEN 0
	                ELSE 1
                END AS MX, MIN(UserLogined_daySave) AS ZX
                FROM cyy_OnlinesUsers
            WHERE  user_name = " + @"'" + ui["user_name"] + @"'";
            MySqlCommand cmdMax = new MySqlCommand(SQLMAX, sqlConnection);
            MySqlDataReader dataReaderMax = cmdMax.ExecuteReader();

            dataReaderMax.Read();
            int maxS = int.Parse(dataReaderMax["MX"].ToString());
            string date = dataReaderMax["ZX"].ToString();

            string tempDate;

            if (maxS > 30 || date == "")
            {
                tempDate = " NOW() ";
            }
            else
            {
                tempDate = @"'" + date + @"'";
            }

            dataReaderMax.Close();


            string SQLDEL = @"DELETE from cyy_OnlinesUsers WHERE user_name = " + @"'" + ui["user_name"] + @"'";
            MySqlCommand CMDDel = new MySqlCommand(SQLDEL, sqlConnection);
            CMDDel.ExecuteNonQuery();

            string SQL1 = @"INSERT INTO cyy_OnlinesUsers(user_name, nickname, city, province, UserLogined_day, UserLogined_ip,UserLogined_DaySave)
                        VALUES("
                + @"'" + ui["user_name"] + @"',"
                + @"'" + ui["nickname"] + @"',"
                + @"'" + ui["city"] + @"',"
                + @"'" + ui["province"] + @"',"
                + @" now(),"
                + @"'" + ui["UserLogined_ip"] + @"', " + tempDate + @");";
            MySqlCommand cmd = new MySqlCommand(SQL1, sqlConnection);
            cmd.ExecuteNonQuery();
            DbClose();

        }

        public void DeleteDateNow(string user_name)
        {
            try
            {
                DbOpen();
                string SQL = @"DELETE FROM cyy_OnlinesUsers WHERE user_name = " + @"'"
                    + user_name
                    + @"' AND versionName = " + @"'" + CyyMain.productKeyVersionNameString
                    + @"' AND versionID = '" + CyyMain.proudctVersionString + @"'";
                //+ @" ORDER BY mid DESC LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);
                cmd.ExecuteNonQuery();
                DbClose();
            }
            catch (Exception exxx)
            {

            }
        }

        public void UpdateOnlineUserData(string user_name)
        {
            if (!user_name.Equals(""))
            {
                if (CheckCountOfSameOnlineUserLogin(user_name) <= 0)
                {
                }
                else
                {
                    DbOpen();
                    // 
                    string SQL = @"UPDATE cyy_OnlinesUsers SET UserLogined_DaySave = NOW(), UserLogined_day = NOW() WHERE user_name = " + @"'" + user_name + @"'";

                    MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);
                    try
                    {
                        cmd.ExecuteNonQuery();
                        DbClose();
                    }
                    catch (Exception e)
                    {
                        if (MessageBox.Show("用户登录出现异常,请重启软件!" + e.Message, "警告", MessageBoxButtons.OK) == DialogResult.OK)
                        {
                            CyyMain.cyyMainExit();
                        }
                    }
                }

                DbOpen();
                //
                string SQLcyy_member = @"UPDATE ecs_users SET 
                                        UserLogined_day = NOW() 
                                        , LogonMinutes=LogonMinutes+1
                                        WHERE user_name = " + @"'" + user_name + @"'";

                MySqlCommand SQLcyy_memberCmd = new MySqlCommand(SQLcyy_member, sqlConnection);
                try
                {
                    SQLcyy_memberCmd.ExecuteNonQuery();
                    DbClose();
                }
                catch (Exception e)
                {
                    if (MessageBox.Show("用户登录出现异常,请重启软件!" + e.Message, "警告", MessageBoxButtons.OK) == DialogResult.OK)
                    {
                        CyyMain.cyyMainExit();
                    }
                }
            }
        }

        public void UpdateDateNow(string user_name)
        {
            DbOpen();
            string SQL = @"UPDATE cyy_OnlinesUsers SET UserLogined_DaySave = NOW() WHERE user_name = " + @"'" + user_name + @"'";

            MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);
            cmd.ExecuteNonQuery();

            SQL = @"SELECT
                        CASE
	                        WHEN ISNULL(timestampdiff(second, UserLogined_daysave,now())) = 1 THEN 0
	                        ELSE 1
                        END as diff, mid FROM cyy_OnlinesUsers";
            MySqlCommand cmdDiffAll = new MySqlCommand(SQL, sqlConnection);
            MySqlDataReader dataReaderDiffAll = cmdDiffAll.ExecuteReader();

            List<int> midList = new List<int>();

            while (dataReaderDiffAll.Read())
            {
                if (int.Parse(dataReaderDiffAll["diff"].ToString()) > 300)
                {
                    midList.Add(int.Parse(dataReaderDiffAll["mid"].ToString()));
                }
            }
            dataReaderDiffAll.Close();


            foreach (int i in midList)
            {
                string SQL2 = @"DELETE cyy_OnlinesUsers WHERE mid = " + @"'" + i.ToString() + @"'";

                MySqlCommand cmd3 = new MySqlCommand(SQL2, sqlConnection);
                cmd3.ExecuteNonQuery();
            }
            DbClose();

        }

        public string GetShows()
        {
            DbOpen();
            string SQL = @"SELECT * FROM cyyShows ORDER BY id DESC LIMIT 1";
            MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);

            MySqlDataReader dataReader = cmd.ExecuteReader();
            dataReader.Read();

            string txt = dataReader["Text"].ToString();
            dataReader.Close();
            DbClose();
            return txt;
        }

        public void Logout(string user_name)
        {
            try
            {
                DbOpen();
                string SQL = @"DELETE FROM cyy_OnlinesUsers WHERE user_name = " + user_name;

                MySqlCommand cmd = new MySqlCommand(SQL, sqlConnection);
                cmd.ExecuteNonQuery();
                DbClose();
            }
            catch
            {
                CyyMain.cyyMainExit();
            }
        }

    }
}
