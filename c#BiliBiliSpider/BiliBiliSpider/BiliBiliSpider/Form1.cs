using System;
using System.Data;
using System.Windows.Forms;

using MySql.Data;
using MySql.Data.MySqlClient;

namespace BiliBiliSpider
{
    public partial class Form1 : Form
    {

        private int start = 0;
        private int end = 100;
        private int page = 1;
        private int pageNum;

        public Form1()
        {
            InitializeComponent();
            inquiry(start, end);
        }

        private string mytableSql(int strat,int end) {

            return @"select * 
                    from mytable LIMIT " + strat + " ," + end;
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nextBtn = new System.Windows.Forms.Button();
            this.prevBtn = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.searchByName = new System.Windows.Forms.TextBox();
            this.searchByNameLabel = new System.Windows.Forms.Label();
            this.searchByNameBtn = new System.Windows.Forms.Button();
            this.animateInfo = new System.Windows.Forms.TextBox();
            this.animateVA = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(25, 175);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(780, 451);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellClick);
            // 
            // nextBtn
            // 
            this.nextBtn.Location = new System.Drawing.Point(450, 51);
            this.nextBtn.Name = "nextBtn";
            this.nextBtn.Size = new System.Drawing.Size(129, 44);
            this.nextBtn.TabIndex = 1;
            this.nextBtn.Text = "下一页";
            this.nextBtn.UseVisualStyleBackColor = true;
            this.nextBtn.Click += new System.EventHandler(this.nextBtn_Click);
            // 
            // prevBtn
            // 
            this.prevBtn.Location = new System.Drawing.Point(54, 51);
            this.prevBtn.Name = "prevBtn";
            this.prevBtn.Size = new System.Drawing.Size(129, 44);
            this.prevBtn.TabIndex = 2;
            this.prevBtn.Text = "上一页";
            this.prevBtn.UseVisualStyleBackColor = true;
            this.prevBtn.Click += new System.EventHandler(this.prevBtn_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(284, 67);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "第1页";
            // 
            // searchByName
            // 
            this.searchByName.Location = new System.Drawing.Point(811, 36);
            this.searchByName.Name = "searchByName";
            this.searchByName.Size = new System.Drawing.Size(148, 21);
            this.searchByName.TabIndex = 4;
            // 
            // searchByNameLabel
            // 
            this.searchByNameLabel.AutoSize = true;
            this.searchByNameLabel.Location = new System.Drawing.Point(764, 39);
            this.searchByNameLabel.Name = "searchByNameLabel";
            this.searchByNameLabel.Size = new System.Drawing.Size(41, 12);
            this.searchByNameLabel.TabIndex = 5;
            this.searchByNameLabel.Text = "漫名：";
            // 
            // searchByNameBtn
            // 
            this.searchByNameBtn.Location = new System.Drawing.Point(838, 88);
            this.searchByNameBtn.Name = "searchByNameBtn";
            this.searchByNameBtn.Size = new System.Drawing.Size(96, 33);
            this.searchByNameBtn.TabIndex = 6;
            this.searchByNameBtn.Text = "查询";
            this.searchByNameBtn.UseVisualStyleBackColor = true;
            this.searchByNameBtn.Click += new System.EventHandler(this.searchByNameBtn_Click);
            // 
            // animateInfo
            // 
            this.animateInfo.BackColor = System.Drawing.Color.White;
            this.animateInfo.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.animateInfo.Location = new System.Drawing.Point(824, 147);
            this.animateInfo.Multiline = true;
            this.animateInfo.Name = "animateInfo";
            this.animateInfo.ReadOnly = true;
            this.animateInfo.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.animateInfo.Size = new System.Drawing.Size(242, 401);
            this.animateInfo.TabIndex = 7;
            // 
            // animateVA
            // 
            this.animateVA.Font = new System.Drawing.Font("微软雅黑", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.animateVA.Location = new System.Drawing.Point(824, 555);
            this.animateVA.Multiline = true;
            this.animateVA.Name = "animateVA";
            this.animateVA.Size = new System.Drawing.Size(242, 71);
            this.animateVA.TabIndex = 8;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(967, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 35);
            this.button1.TabIndex = 9;
            this.button1.Text = "筛选";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.deleteBbutton_Click);
            // 
            // Form1
            // 
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1078, 652);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.animateVA);
            this.Controls.Add(this.animateInfo);
            this.Controls.Add(this.searchByNameBtn);
            this.Controls.Add(this.searchByNameLabel);
            this.Controls.Add(this.searchByName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.prevBtn);
            this.Controls.Add(this.nextBtn);
            this.Controls.Add(this.dataGridView1);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "BiliBili";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        private void connectDB() {
            Database DB = new Database();
            if (!DB.databasecon())
            {
                MessageBox.Show("database error!");
                return;
            }
        }

        //search db
        private void inquiry(int strat,int end)
        {
            //initialize db
            Database DB = new Database();
            if (!DB.databasecon())
            {
                MessageBox.Show("database error!");
                return;
            }
            string sql = mytableSql(strat,end);
            MySqlDataAdapter mycommand = new MySqlDataAdapter(sql, DB.getconn());

            DataSet dataset1 = new DataSet();

            mycommand.Fill(dataset1, "mytable");


            dataGridView1.DataSource = dataset1.Tables["mytable"];
            dataGridView1.Columns[0].HeaderText = "番名";
            dataGridView1.Columns[1].Visible = false;
            dataGridView1.Columns[2].HeaderText = "分类";
            dataGridView1.Columns[3].HeaderText = "播放量";
            dataGridView1.Columns[4].HeaderText = "追番人数";
            dataGridView1.Columns[5].HeaderText = "弹幕数";
            dataGridView1.Columns[6].HeaderText = "上映时间";
            dataGridView1.Columns[7].HeaderText = "更新状态";
            dataGridView1.Columns[8].Visible = false;
            dataGridView1.Columns[9].Visible = false;
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;

            MySqlCommand cmd = new MySqlCommand("select count(*) from mytable", DB.getconn());
            pageNum = Convert.ToInt32(cmd.ExecuteScalar());
        }


        private void searchByNameFun(string animateName)
        {
            Database DB = new Database();
            if (!DB.databasecon())
            {
                MessageBox.Show("database error!");
                return;
            }
            string sql = "select * from mytable" + "where title = '" + animateName + "';";
            MySqlDataAdapter mycommand = new MySqlDataAdapter(sql, DB.getconn());

            DataSet dataset1 = new DataSet();
            mycommand.Fill(dataset1, "mytable");
            dataGridView1.DataSource = dataset1.Tables["mytable"];
        }

       

        private void prevBtn_Click(object sender, EventArgs e)
        {
            if (start <= 0) { return; }
            start -= 100;
            end -= 100;
            page--;
            this.label1.Text = "第" + page + "页";
            inquiry(start, end);
        }

        private void nextBtn_Click(object sender, EventArgs e)
        {
            if (end >= pageNum) { return; }
            start += 100;
            end += 100;
            page++;
            this.label1.Text = "第" + page + "页";
            inquiry(start, end);
        }

        private void searchByNameBtn_Click(object sender, EventArgs e)
        {
            if (this.searchByName.Text == "") { return; }
            searchByNameFun(this.searchByName.Text);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) { return; }
            string str = this.dataGridView1.Rows[e.RowIndex].Cells["info"].Value.ToString();
            string va = this.dataGridView1.Rows[e.RowIndex].Cells["VA"].Value.ToString();
            this.animateInfo.Text = str;
            this.animateVA.Text = va;
        }

        private void filterPlyaNum() {
           
            for (var i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string a = dataGridView1.Rows[i].Cells[3].Value.ToString();
                Console.WriteLine(Convert.ToInt32(a));
                if (Convert.ToInt32(dataGridView1.Rows[i].Cells[3].Value) < 1000000)
                {
                    CurrencyManager cm = (CurrencyManager)BindingContext[dataGridView1.DataSource];
                    cm.SuspendBinding(); //挂起数据绑定

                    dataGridView1.Rows[i].Visible = false;

                    cm.ResumeBinding();
                }
            }

           
        }

        private void deleteBbutton_Click(object sender, EventArgs e)
        {
            filterPlyaNum();
        }
    }

}
