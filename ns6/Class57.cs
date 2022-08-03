using System;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;
using ns3;

namespace ns6
{
	internal static class Class57
	{
		[STAThread]
		private static void Main()
		{
			bool createdNew = false;
			using (new Mutex(initiallyOwned: true, "MyToolRunning", out createdNew))
			{
				try
				{
					if (createdNew)
					{
						Application.EnableVisualStyles();
						Application.SetCompatibleTextRenderingDefault(defaultValue: false);
						if (!new WindowsPrincipal(WindowsIdentity.GetCurrent()).IsInRole(WindowsBuiltInRole.Administrator))
						{
							MessageBox.Show("Vui lòng chạy Tool bằng quyền Admin!\r\nPlease Run Aplication As Administrator!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							Environment.Exit(0);
						}
						Application.Run(new frmLoginUser());
					}
					else
					{
						MessageBox.Show("Rabbit Social Tool hiện đang chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				catch
				{
				}
			}
		}
	}
}
