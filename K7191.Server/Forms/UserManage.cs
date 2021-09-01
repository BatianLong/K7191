using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
    public partial class UserManage : Form
    {
        public UserManage()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //创建一些假冒数据
            UserModel peoples = new UserModel() { 
                    ID = 1, 
                    RealName = "赵南西",
                    Phone="18274278703",
                    Account="漂亮小姐姐",
                    Password="Znx19980408"
            };
            //这里指定两个数据库
            DbConnection dbConnection_1 = new SQLiteConnection("data source=C:\\K7191_20219.db");

            //对两个数据库分别操作
            var ctx1 = new UserContext(dbConnection_1);
            //ctx1.User.Add(peoples);
            //ctx1.SaveChanges();
            DBHelper<UserModel> dbhelper = new DBHelper<UserModel>(ctx1);
            dbhelper.Add(peoples);
        }
    }
}
