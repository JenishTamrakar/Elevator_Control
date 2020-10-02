﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CtrlElevator
{
    public partial class ElevatorGui : Form
    {
        bool go_down = false;
        bool go_up = false;
        bool arrive_G = false;
        bool arrive_1 = false;
        DbCommand dbcmd = new DbCommand();


        public ElevatorGui()
        {
            InitializeComponent();
            //MessageBox.Show("" + doorLeftup.Left);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GlobalConnection.DbConnection();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            go_down = true;
            btnDown.BackColor = Color.Green;
            btnDown.Enabled = false;
            btnGFloor.Enabled = false;
            btnOpen.Enabled = false;
            btnClose.Enabled = false;
            timer_door_close_down.Enabled = true;
            timer_door_open_down.Enabled = false;
            arrive_G = false;
        }

        private void doorLeftdown_Click(object sender, EventArgs e)
        {

        }

        private void doorRightup_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureElevator_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox9_Click(object sender, EventArgs e)
        {

        }

        private void btnDown_Click(object sender, EventArgs e)
        {
                go_up = true;
                btnDown.BackColor = Color.Green;
                timer_door_close_up.Enabled = true;
                timer_door_open_up.Enabled = false;
                arrive_1 = false;
                btnUp.Enabled = false;
                btnClose.Enabled = false;
                btnOpen.Enabled = false;
                btn1Floor.Enabled = false;
        }

        private void timer_door_close_down_Tick(object sender, EventArgs e)
        {
            if (doorLeftdown.Left<=150 && doorRightdown.Left>=254)
            {
                CtrlDoor dcd = new CtrlDoor();
                dcd.Timer_door_close_down(doorLeftdown, doorRightdown);
            }
            else
            {
                timer_door_close_down.Enabled = false;
                dbcmd.SaveLog("Ground Floor Door Closing");
                LoadData();

                if (go_down == true)
                {
                    timer_up.Enabled = true;
                    go_down = false;
                }

            }
        }

        private void timer_up_Tick(object sender, EventArgs e)
        {
            if(pictureElevator.Top>=82)
            {
                Elevator eu = new Elevator();
                eu.Timer_up(pictureElevator);
            }
            else
            {
                timer_up.Enabled = false;
                dbcmd.SaveLog("Elevator Moving to the First Floor");
                LoadData();

                btnDown.Enabled = true;
                btnGFloor.Enabled = true;
                btnClose.Enabled = true;
                btnOpen.Enabled = true;
                btnUp.BackColor = Color.White;
                btn1Floor.BackColor = Color.White;
                timer_door_open_up.Enabled = true;
                timer_door_close_up.Enabled = false;
                arrive_1 = true;
                arrive_G = false;
            }
        }

        private void timer_door_close_up_Tick(object sender, EventArgs e)
        {
            if (doorLeftup.Left <= 150 && doorRightup.Left >= 254)
            {
                CtrlDoor dcu = new CtrlDoor();
                dcu.Timer_door_close_up(doorLeftup, doorRightup);
            }
            else
            {
                timer_door_close_up.Enabled = false;
                dbcmd.SaveLog("First Floor Door Closing");
                LoadData();

                if (go_up == true)
                {
                    timer_down.Enabled = true;
                    go_up = false;


                }
            }
        }

        private void timer_down_Tick(object sender, EventArgs e)
        {
            if (pictureElevator.Top <= 431)
            {
                Elevator ed = new Elevator();
                ed.Timer_down(pictureElevator);
            }
            else
            {
                timer_down.Enabled = false;
                dbcmd.SaveLog("Elevator Moving to the Ground Floor");
                LoadData();

                btnUp.Enabled = true;
                btn1Floor.Enabled = true;
                btnClose.Enabled = true;
                btnOpen.Enabled = true;
                btnDown.BackColor = Color.White;
                btnGFloor.BackColor = Color.White;

                timer_door_open_down.Enabled = true;
                timer_door_close_down.Enabled = false;
                arrive_G = true;
                arrive_1 = false;
            }
        }

        private void timer_door_open_up_Tick(object sender, EventArgs e)
        {
            if (doorLeftup.Left >= 50 && doorRightup.Left <= 340)
            {
                CtrlDoor dou = new CtrlDoor();
                dou.Timer_door_open_up(doorLeftup, doorRightup);
            }
            else
            {
                timer_door_open_up.Enabled = false;
                dbcmd.SaveLog("First Floor Door Opening");
                LoadData();

                btnDown.Enabled = true;
            }
        }

        private void timer_door_open_down_Tick(object sender, EventArgs e)
        {
            if (doorLeftdown.Left >= 51 && doorRightdown.Left <= 340)
            {
                CtrlDoor dod = new CtrlDoor();
                dod.Timer_door_open_down(doorLeftdown, doorRightdown);
            }
            else
            {
                timer_door_open_down.Enabled = false;
                dbcmd.SaveLog("Ground Floor Door Opening");
                LoadData();

            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            if (arrive_G == true)
            {
                timer_door_close_down.Enabled = true;
                timer_door_open_down.Enabled = false;
            }
            else if (arrive_1 == true)
            {
                timer_door_close_up.Enabled = true;
                timer_door_open_up.Enabled = false;
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (arrive_G == true)
            {
                timer_door_open_down.Enabled = true;
                timer_door_close_down.Enabled = false;
            }
            else if (arrive_1 == true)
            {
                timer_door_open_up.Enabled = true;
                timer_door_close_up.Enabled = false;
            }
        }

        private void btnGFloor_Click(object sender, EventArgs e)
        {
            go_up = true;
            btnGFloor.BackColor = Color.Green;
            arrive_1 = false;
            timer_door_close_up.Enabled = true;
            timer_door_open_up.Enabled = false;
        }

        private void btn1Floor_Click(object sender, EventArgs e)
        {
            go_down = true;
            btn1Floor.BackColor = Color.Green;
            arrive_G = false;
            timer_door_close_down.Enabled = true;
            timer_door_open_down.Enabled = false;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public void LoadData()
        {
            try
            {
                DbCommand dbcmd = new DbCommand();
                DataTable dt = dbcmd.ViewActionLog();
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Database Not Connected");
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }
    }
}
