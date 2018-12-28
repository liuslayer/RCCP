using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using System.Xml;

namespace BasicModuleManagement
{
    public partial class AddServerSet : Form
    {
        XmlDocument xml = new XmlDocument();
        string path = @".\ServerList.xml";
        public AddServerSet()
        {
            InitializeComponent();
        }
        //将新增的服务写入xml文件中
        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox3.Text == ""||textBox4.Text=="")
            {
                MessageBox.Show("请输入完整信息！");
                return;
            }
            //XmlDocument xml = new XmlDocument();
            if (!File.Exists(path))
            {
                XmlDeclaration xmldecl = xml.CreateXmlDeclaration("1.0", "utf-8", null);
                xml.AppendChild(xmldecl);
                XmlElement xmlelem = xml.CreateElement("services");
                xml.AppendChild(xmlelem);
                xml.Save(path);
            }
            try
            {
                xml.Load(path);
                XmlNode root = xml.SelectSingleNode("services");
                XmlNodeList list = root.ChildNodes;
                string DisplayName = textBox4.Text;
                string name = textBox1.Text;
                string[] s = maskedTextBox1.Text.Split('.');
                string ip = "";
                for (int i = 0; i < s.Length; i++)
                {
                    ip += s[i].Trim() + ".";
                }
                ip = ip.Substring(0, ip.Length - 1);
                string port = textBox3.Text;
                foreach (XmlNode node in list)
                {
                    if (node.Attributes["DisplayName"].InnerText.ToString() == DisplayName)
                    {
                        MessageBox.Show("该服务已添加！");
                        return;
                    }
                }

                //增加节点
                XmlElement ele = xml.CreateElement("server");
                ele.SetAttribute("DisplayName", DisplayName);
                ele.SetAttribute("name", name);
                ele.SetAttribute("ip", ip);
                ele.SetAttribute("port", port);
                XmlElement status = xml.CreateElement("serverStatus");
                status.InnerText = "";
                ele.AppendChild(status);
                root.AppendChild(ele);
                xml.Save(path);

                #region 操作服务器中的配置文件App.config
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                string SuperSocketPath = config.AppSettings.Settings["SuperSocketPath"].Value;
                string FileName = config.AppSettings.Settings["FileName"].Value;
                //XmlDocument xml = new XmlDocument();
                xml.Load(SuperSocketPath+@"\"+FileName+".exe.config");
                var root2 = xml.DocumentElement;
                XmlNodeList nodes = root2.ChildNodes;
                for (int i = 0; i < nodes.Count; i++)
                {
                    if(nodes[i].Name=="superSocket")
                    {
                        XmlNodeList childNodes = nodes[i].ChildNodes;
                        for (int j = 0; j < childNodes.Count; j++)
                        {
                            if(childNodes[j].Name=="servers")
                            {
                                XmlElement server = xml.CreateElement("server");
                                server.SetAttribute("name", name);
                                server.SetAttribute("serverTypeName", name);
                                server.SetAttribute("ip", ip);
                                server.SetAttribute("port", port);
                                childNodes[j].AppendChild(server);
                                xml.Save(SuperSocketPath + @"\" + FileName + ".exe.config");
                            }
                        }
                    }
                }
                #endregion

                MessageBox.Show("添加成功！");
                DialogResult = DialogResult.OK;
                Close();

            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.ToString());
                MessageBox.Show("添加失败！");
            }
        }

        private void maskedTextBox1_KeyDown(object sender, KeyEventArgs e)
        {
            //按“.”跳到下一个
            if(e.KeyCode==Keys.Decimal)
            {
                int pos = maskedTextBox1.SelectionStart;
                int max = (maskedTextBox1.MaskedTextProvider.Length - maskedTextBox1.MaskedTextProvider.EditPositionCount);
                int nextField = 0;
                for (int i = 1; i < maskedTextBox1.MaskedTextProvider.Length; i++)
                {
                    if(!maskedTextBox1.MaskedTextProvider.IsEditPosition(i)&&(pos+max)>=i)
                        nextField = i;
                }
                nextField += 1;
                maskedTextBox1.SelectionStart = nextField;
            }
        }

        private void maskedTextBox1_KeyUp(object sender, KeyEventArgs e)
        {
            
            string[] s = maskedTextBox1.Text.Split('.');
            if(maskedTextBox1.SelectionStart<4&& s[0].Trim()!="")
            {
                if (int.Parse(s[0]) > 255)
                {
                    MessageBox.Show(s[0] + "不是有效项。请指定一个介于0和255间的值");
                    maskedTextBox1.Text = "233." + s[1] + "." + s[2] + "." + s[3];
                    maskedTextBox1.SelectionStart = 4;
                }
            }
            else if(maskedTextBox1.SelectionStart>4&&maskedTextBox1.SelectionStart<8 && s[1].Trim() != "")
            {
                if (int.Parse(s[1]) > 255)
                {
                    MessageBox.Show(s[1] + "不是有效项。请指定一个介于0和255间的值");
                    maskedTextBox1.Text = s[0]+".255." + s[2] + "." + s[3];
                    maskedTextBox1.SelectionStart = 8;
                }
            }
            else if(maskedTextBox1.SelectionStart>8&&maskedTextBox1.SelectionStart<12 && s[2].Trim() != "")
            {
                if (int.Parse(s[2]) > 255)
                {
                    MessageBox.Show(s[2] + "不是有效项。请指定一个介于0和255间的值");
                    maskedTextBox1.Text = s[0] + "."+s[1]+".255."  + s[3];
                    maskedTextBox1.SelectionStart = 12;
                }
            }
            else if(maskedTextBox1.SelectionStart>12 && s[3].Trim() != "")
            {
                if (int.Parse(s[3]) > 255)
                {
                    MessageBox.Show(s[3] + "不是有效项。请指定一个介于0和255间的值");
                    maskedTextBox1.Text = s[0] + "." + s[1] + "." + s[2]+".255";
                }
            }

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex("[a-zA-Z\b\r\t]");
            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                MessageBox.Show("请输入英文字符。");
                e.Handled = true;
            }
        }

        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex("^[\u4e00-\u9fa5\b\r\t]$");
            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                //MessageBox.Show("请输入中文字符。");
                e.Handled = true;
            }
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            Regex reg = new Regex("^[0-9\b\r\n]*$");
            if (!reg.IsMatch(e.KeyChar.ToString()))
            {
                MessageBox.Show("请输入数字。");
                e.Handled = true;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            xml.Load(path);
            XmlNode root = xml.SelectSingleNode("services");
            XmlNodeList list = root.ChildNodes;
            string DisplayName = textBox4.Text;
            foreach (XmlNode node in list)
            {
                if (node.Attributes["DisplayName"].InnerText.ToString() == DisplayName)
                {
                    label10.Visible=true;
                    textBox4.Focus();
                    return;
                }
            }
            label10.Visible = false;
        }
    }
}
