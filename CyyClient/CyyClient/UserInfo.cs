using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CyyClient
{
    public class UserInfo
    {
        DataTable dt = null;

        public int Count
        {
            get { return dt.Rows.Count; }
        }

        public UserInfo(DataTable dt)
        {
            this.dt = dt;
        }

        public string this[string clnName]
        {
            get
            {
                return dt.Rows[0][clnName].ToString();
            }
            set
            {
                dt.Rows[0][clnName] = value;
            }
        }


    }
}
