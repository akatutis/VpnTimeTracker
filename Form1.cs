using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VpnTimeTracker
{
	public partial class Form1 : Form
	{
		private int INTERNET_CONNECTION_MODEM = 0x01;
		private int INTERNET_CONNECTION_LAN = 0x02;
		private int INTERNET_CONNECTION_PROXY = 0x04;
		private int INTERNET_CONNECTION_MODEM_BUSY = 0x08;
		private int INTERNET_RAS_INSTALLED = 0x10;
		private int INTERNET_CONNECTION_OFFLINE = 0x20;
		private int INTERNET_CONNECTION_CONFIGURED = 0x40;

		public Form1()
		{
			InitializeComponent();
		}

		[DllImport("wininet.dll")]
		private static extern bool InternetGetConnectedState(out int connectionDescription, int reservedValue);

		private void button1_Click(object sender, EventArgs e)
		{
			int description = 0;
			bool isConnected = InternetGetConnectedState(out description, 0);
			if (isConnected == true)
			{
				label1.Text = "User is Connected to Internet " + description;
			}
			else
			{
				label1.Text = "Disconnected " + description;
			}

			if ((description & INTERNET_CONNECTION_CONFIGURED) == INTERNET_CONNECTION_CONFIGURED)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_CONFIGURED";
			}
			
			if ((description & INTERNET_CONNECTION_LAN) == INTERNET_CONNECTION_LAN)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_LAN";
			}
			
			if ((description & INTERNET_CONNECTION_MODEM) == INTERNET_CONNECTION_MODEM)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_MODEM";
			}
			
			if ((description & INTERNET_CONNECTION_MODEM_BUSY) == INTERNET_CONNECTION_MODEM_BUSY)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_MODEM_BUSY";
			}
			
			if ((description & INTERNET_CONNECTION_OFFLINE) == INTERNET_CONNECTION_OFFLINE)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_OFFLINE";
			}
			
			if ((description & INTERNET_CONNECTION_PROXY) == INTERNET_CONNECTION_PROXY)
			{
				label1.Text += Environment.NewLine + "INTERNET_CONNECTION_PROXY";
			}
			
			if ((description & INTERNET_RAS_INSTALLED) == INTERNET_RAS_INSTALLED)
			{
				label1.Text += Environment.NewLine + "INTERNET_RAS_INSTALLED";
			}
		}
	}
}
