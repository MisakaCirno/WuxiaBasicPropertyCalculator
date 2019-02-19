using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 天刀五维加成计算器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*大吉大利，No Bug Pleas.*/

            //设置窗口宽度，下拉框默认选中内容避免BUG
            Width = 358;
            CB_MP1.SelectedIndex = 0; 
            CB_MP2.SelectedIndex = 0; 
        }

        private void OnlyNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            //如果输入的不是数字键，也不是回车键、Backspace键，则取消该输入
            if (!(Char.IsNumber(e.KeyChar)) && e.KeyChar != (char)13 && e.KeyChar != (char)8)
            {
                e.Handled = true;
            }
        }

        private void IfChangeText(object sender, EventArgs e)
        {
            TextBox TextInBox = (TextBox)sender;
            if (TextInBox.Text == "")
            {
                TextInBox.Text = "0";
            }
        }

        private void IfSelectText(object sender, EventArgs e)
        {
            TextBox t_TextBOX = (TextBox)sender;
            if (t_TextBOX.Text=="0")
            {
                t_TextBOX.SelectAll();
            }
        }

        private void IfSelectedIndexChanged(object sender, EventArgs e)
        {
            AfterButtonClick();
        }

        private void CB_DB_CheckedChanged(object sender, EventArgs e) //窗口变形
        {
            if (CB_DB.Checked == true)
            {
                Width = 508;
                G_ZD2.Visible = true;
                CleanUpAll();
                WWJS(CB_MP1.SelectedIndex, 1);
                WWJS(CB_MP2.SelectedIndex, 2);
            }
            else
            {
                Width = 358;
                G_ZD2.Visible = false;
            }
        }

        private void B_JS_Click(object sender, EventArgs e) //计算属性
        {
            AfterButtonClick();

        }

        private void AfterButtonClick()
        {
            CleanUpAll();
            if (CB_DB.Checked == true) //判断对比多选框是否选中
            {
                WWJS(CB_MP1.SelectedIndex, 1); //选中了就计算两边
                WWJS(CB_MP2.SelectedIndex, 2);
            }
            else
            {
                WWJS(CB_MP1.SelectedIndex, 1); //没选中就计算一边
            }
        }

        private void CleanUpAll() //清空计算结果
        {
            L_WG_R1.Text = "0";
            L_WF_R1.Text = "0";
            L_NG_R1.Text = "0";
            L_NF_R1.Text = "0";
            L_QX_R1.Text = "0";
            L_MZ_R1.Text = "0%";
            L_HX_R1.Text = "0%";
            L_HS_R1.Text = "0%";
            L_GD_R1.Text = "0%";
            L_RJ_R1.Text = "0%";

            L_WG_R2.Text = "0";
            L_WF_R2.Text = "0";
            L_NG_R2.Text = "0";
            L_NF_R2.Text = "0";
            L_QX_R2.Text = "0";
            L_MZ_R2.Text = "0%";
            L_HX_R2.Text = "0%";
            L_HS_R2.Text = "0%";
            L_GD_R2.Text = "0%";
            L_RJ_R2.Text = "0%";
        }

        private void WWJS( int MP,int WZ) //MP=门派 WZ=位置
        {
            double temp = 0;
            if (WZ == 1) //判断存放计算结果的位置
            {
                switch (MP) //判断计算的门派
                {
                    case 0://移花
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.3);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_GG.Text) * 0.2);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        //百分号会影响计算，先扣掉百分号，之后再加上。
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_DC.Text) * 0.4);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        break;
                    case 1://神刀
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.45);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_LD.Text) * 1);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 6.5);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_DC.Text) * 0.2);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        break;
                    case 2://太白
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.35);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.01);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_DC.Text) * 0.35);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_SF.Text) * 0.3);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 3://神威
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.8);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 10);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 4://丐帮
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.55);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 7.5);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 5://唐门
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 5);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_DC.Text) * 0.55);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 6://真武
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.65);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_GG.Text) * 0.1);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 6);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.1);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.01);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 7://天香
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.6);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.45);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.3);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.01);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_SF.Text) * 0.1);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 8://五毒
                        //力道
                        temp = Convert.ToDouble(L_WG_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.65);
                        L_WG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R1.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R1.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R1.Text) + (Convert.ToDouble(T_GG.Text) * 5);
                        L_QX_R1.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R1.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R1.Text = temp.ToString()+"%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_NG_R1.Text) + (Convert.ToDouble(T_DC.Text) * 0.1);
                        L_NG_R1.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R1.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R1.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R1.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    default:
                        MessageBox.Show("五维转换数据出错！");
                        break;
                }
            }
            else
            {
                switch (MP) //判断计算的门派
                {
                    case 0://移花
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.3);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_GG.Text) * 0.2);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        //百分号会影响计算，先扣掉百分号，之后再加上。
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_DC.Text) * 0.4);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        break;
                    case 1://神刀
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.45);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_LD.Text) * 1);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 6.5);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_DC.Text) * 0.2);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        break;
                    case 2://太白
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.35);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.01);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_DC.Text) * 0.35);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_SF.Text) * 0.3);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 3://神威
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.8);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 10);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 4://丐帮
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.55);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 7.5);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 5://唐门
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 5);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_DC.Text) * 0.55);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 6://真武
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.65);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_GG.Text) * 0.1);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 6);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.1);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.01);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 7://天香
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.6);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 7);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.45);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.3);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.01);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_SF.Text) * 0.1);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    case 8://五毒
                        //力道
                        temp = Convert.ToDouble(L_WG_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.65);
                        L_WG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_WF_R2.Text) + (Convert.ToDouble(T_LD.Text) * 0.4);
                        L_WF_R2.Text = temp.ToString();
                        temp = 0;

                        //根骨
                        temp = Convert.ToDouble(L_QX_R2.Text) + (Convert.ToDouble(T_GG.Text) * 5);
                        L_QX_R2.Text = temp.ToString();
                        temp = 0;

                        //气劲
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.4);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_NF_R2.Text) + (Convert.ToDouble(T_QJ.Text) * 0.2);
                        L_NF_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_HS_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_QJ.Text) * 0.005);
                        L_HS_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //洞察
                        temp = Convert.ToDouble(L_NG_R2.Text) + (Convert.ToDouble(T_DC.Text) * 0.1);
                        L_NG_R2.Text = temp.ToString();
                        temp = 0;
                        temp = Convert.ToDouble(L_MZ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_MZ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_HX_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_DC.Text) * 0.02);
                        L_HX_R2.Text = temp.ToString() + "%";
                        temp = 0;

                        //身法
                        temp = Convert.ToDouble(L_GD_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.02);
                        L_GD_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        temp = Convert.ToDouble(L_RJ_R2.Text.Replace("%", "")) + (Convert.ToDouble(T_SF.Text) * 0.015);
                        L_RJ_R2.Text = temp.ToString() + "%";
                        temp = 0;
                        break;
                    default:
                        MessageBox.Show("五维转换数据出错！");
                        break;
                }
            }
        }
    }
}
