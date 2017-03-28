using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using System.Net.Mime;
using System.Data.SqlClient;


namespace LoginForm
{
    public partial class main : Form
    {
        
        public main()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string body = "From" + "revathy1619@gmail.com" + "\n";
          //  body += "subject" + txtmsg.Text + "\n";
            body += "Message" + txtmsg.Text + "\n";
            var smtp = new System.Net.Mail.SmtpClient();
            {
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.DeliveryMethod = System.Net.Mail.SmtpDeliveryMethod.Network;
                smtp.Credentials = new NetworkCredential("revathy1619@gmail.com", "h@rsh1619");
                smtp.Timeout = 20000;
            }
            {
                SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\SURESH\Documents\data.mdf;Integrated Security=True;Connect Timeout=30");
                con.Open();
                SqlCommand cmd = new SqlCommand("insert into main1 (Message) values ('" + txtmsg.Text + "')",con);
                cmd.ExecuteNonQuery();
                con.Close();

            }

        
            smtp.Send("revathy1619@gmail.com", txtemail.Text, txtname.Text, txtmsg.Text);
            MessageBox.Show("Your E-Mail sent successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Message_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            message ss = new message();
            ss.Show();
        }

        private void main_Load(object sender, EventArgs e)
        {

        }

       
       
    }
}
