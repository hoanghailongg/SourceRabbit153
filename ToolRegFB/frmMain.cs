using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using DeviceId;
using HttpRequest;
using KAutoHelper;
using Newtonsoft.Json.Linq;
using ns1;
using ns2;
using ns3;
using ns5;
using ns6;
using ns7;
using ns8;
using ns9;
using ToolRegFB.Properties;

namespace ToolRegFB
{
	public class frmMain : Form
	{
		[CompilerGenerated]
		private sealed class Class31
		{
			public string string_0;

			public frmMain frmMain_0;

			internal void method_0()
			{
				try
				{
					if (string_0 == "start")
					{
						frmMain_0.btnReg.Enabled = false;
						frmMain_0.btnSaveConf.Enabled = false;
						frmMain_0.btnAutoConfig.Enabled = false;
						frmMain_0.btnStop.Enabled = true;
					}
					else if (string_0 == "stop")
					{
						frmMain_0.btnReg.Enabled = true;
						frmMain_0.btnSaveConf.Enabled = true;
						frmMain_0.btnAutoConfig.Enabled = true;
						frmMain_0.btnStop.Enabled = false;
					}
				}
				catch (Exception)
				{
				}
			}
		}

		[CompilerGenerated]
		private sealed class Class32
		{
			public frmMain frmMain_0;

			public Thread thread_0;

			public MethodInvoker methodInvoker_0;

			public MethodInvoker methodInvoker_1;

			internal void method_0()
			{
				while (true)
				{
					try
					{
						if (frmMain_0.bool_1 && frmMain_0.list_4.Count > 0)
						{
							bool flag = false;
							while (!flag)
							{
								flag = true;
								for (int i = 0; i < frmMain_0.list_4.Count; i++)
								{
									string text = Class2.smethod_36(frmMain_0.list_4[i].int_0);
									if (string.IsNullOrEmpty(text))
									{
										flag = false;
									}
									else
									{
										frmMain_0.list_4[i].DeviceId = text;
									}
								}
							}
							frmMain_0.bool_1 = false;
						}
					}
					catch
					{
					}
					frmMain_0.method_51(5.0);
				}
			}

			internal void method_1()
			{
				frmMain_0.dgvAcc.Rows.Clear();
			}

			internal void method_2()
			{
				frmMain_0.stIPCur.Text = frmMain_0.method_54();
			}

			internal void method_3()
			{
				frmMain_0.stIPCur.Text = frmMain_0.method_54();
			}

			internal void method_4()
			{
				frmMain_0.btnStop.Text = "Dừng lại";
				frmMain_0.plTrangThai.Text = "Kết thúc đăng ký";
			}
		}

		[CompilerGenerated]
		private sealed class Class33
		{
			public int int_0;

			public List<int> list_0;

			public bool bool_0;

			public bool bool_1;

			public Class32 class32_0;

			internal void method_0()
			{
				class32_0.frmMain_0.method_19("start");
				int num = 0;
				class32_0.frmMain_0.dgvAcc.Invoke((MethodInvoker)delegate
				{
					class32_0.frmMain_0.dgvAcc.Rows.Clear();
				});
				if (class32_0.frmMain_0.int_36 == 0)
				{
					string text = "";
					int num2 = class32_0.frmMain_0.int_1;
					if (num2 == 0)
					{
						num2 = 1;
					}
					int num3 = 0;
					while (num3 < num2 && (class32_0.frmMain_0.queue_0 == null || class32_0.frmMain_0.queue_0.Count != 0))
					{
						text = ((num2 > 1) ? $"Lượt {num3 + 1}/{num2}. " : "");
						if (num2 > 1)
						{
							class32_0.frmMain_0.method_20("Đang reg..." + text);
						}
						else
						{
							class32_0.frmMain_0.method_20("Đang reg...");
						}
						Common.smethod_62(0.5);
						if (class32_0.frmMain_0.bool_0)
						{
							break;
						}
						int num4 = 0;
						while (num4 < class32_0.frmMain_0.int_11 && !class32_0.frmMain_0.bool_0 && !class32_0.frmMain_0.bool_0)
						{
							if (int_0 < class32_0.frmMain_0.int_11)
							{
								Class34 CS_0024_003C_003E8__locals1 = new Class34
								{
									class33_0 = this
								};
								Interlocked.Increment(ref int_0);
								CS_0024_003C_003E8__locals1.int_0 = 0;
								class32_0.frmMain_0.dgvAcc.Invoke((MethodInvoker)delegate
								{
									CS_0024_003C_003E8__locals1.int_0 = CS_0024_003C_003E8__locals1.class33_0.class32_0.frmMain_0.dgvAcc.Rows.Add();
								});
								num4++;
								Thread thread = new Thread((ThreadStart)delegate
								{
									try
									{
										int num9 = Common.smethod_83(ref CS_0024_003C_003E8__locals1.class33_0.list_0);
										CS_0024_003C_003E8__locals1.class33_0.class32_0.frmMain_0.method_24(CS_0024_003C_003E8__locals1.int_0, num9 + 1, CS_0024_003C_003E8__locals1.class33_0.bool_0, CS_0024_003C_003E8__locals1.class33_0.class32_0.frmMain_0.string_9);
										Common.smethod_65(ref CS_0024_003C_003E8__locals1.class33_0.list_0, num9 + 1);
										Interlocked.Decrement(ref CS_0024_003C_003E8__locals1.class33_0.int_0);
									}
									catch
									{
										Interlocked.Decrement(ref CS_0024_003C_003E8__locals1.class33_0.int_0);
									}
								})
								{
									Name = CS_0024_003C_003E8__locals1.int_0.ToString()
								};
								class32_0.frmMain_0.list_3.Add(thread);
								Common.smethod_62(1.0);
								thread.Start();
							}
							else
							{
								for (int i = 0; i < class32_0.frmMain_0.list_3.Count(); i++)
								{
									class32_0.frmMain_0.list_3[i].Join();
								}
								for (int j = 0; j < class32_0.frmMain_0.list_3.Count(); j++)
								{
									try
									{
										class32_0.frmMain_0.list_3[j].Abort();
									}
									catch
									{
									}
								}
								class32_0.frmMain_0.list_3.Clear();
								int_0 = 0;
							}
							if (class32_0.frmMain_0.int_9 == 6 && class32_0.frmMain_0.bool_12)
							{
								try
								{
									for (int k = 0; k < class32_0.frmMain_0.list_3.Count; k++)
									{
										class32_0.frmMain_0.list_3[k].Join();
										class32_0.frmMain_0.list_3.RemoveAt(k--);
									}
								}
								catch
								{
								}
							}
							if (class32_0.frmMain_0.bool_0)
							{
								break;
							}
						}
						for (int l = 0; l < class32_0.frmMain_0.list_3.Count(); l++)
						{
							class32_0.frmMain_0.list_3[l].Join();
						}
						for (int m = 0; m < class32_0.frmMain_0.list_3.Count(); m++)
						{
							try
							{
								class32_0.frmMain_0.list_3[m].Abort();
							}
							catch
							{
							}
						}
						class32_0.frmMain_0.list_3.Clear();
						num++;
						if (!class32_0.frmMain_0.bool_0 && num >= class32_0.frmMain_0.int_8 && (class32_0.frmMain_0.int_9 == 1 || class32_0.frmMain_0.int_9 == 4))
						{
							class32_0.frmMain_0.method_20("Đang đổi IP...");
							bool_1 = Common.smethod_56(class32_0.frmMain_0.int_9, 0, class32_0.frmMain_0.string_10, "");
							num = 0;
							if (bool_1)
							{
								class32_0.frmMain_0.Invoke((MethodInvoker)delegate
								{
									class32_0.frmMain_0.stIPCur.Text = class32_0.frmMain_0.method_54();
								});
							}
						}
						if (num3 + 1 < num2)
						{
							int num5 = class32_0.frmMain_0.random_0.Next(0, 10);
							int tickCount = Environment.TickCount;
							while ((Environment.TickCount - tickCount) / 1000 - num5 < 0)
							{
								class32_0.frmMain_0.method_20(string.Format("Chạy lượt tiếp theo sau {time} giây...".Replace("{time}", (num5 - (Environment.TickCount - tickCount) / 1000).ToString())));
								Common.smethod_62(0.5);
								if (Settings.Default.isAutoClearLD)
								{
									Common.smethod_39(class32_0.frmMain_0.string_9);
								}
								if (class32_0.frmMain_0.bool_0)
								{
									break;
								}
							}
						}
						if (!class32_0.frmMain_0.bool_0)
						{
							num3++;
						}
						else if (class32_0.frmMain_0.bool_0)
						{
							class32_0.frmMain_0.method_19("stop");
							break;
						}
					}
				}
				else
				{
					while (!class32_0.frmMain_0.bool_0)
					{
						if (class32_0.frmMain_0.int_9 == 1 || class32_0.frmMain_0.int_9 == 4)
						{
							class32_0.frmMain_0.method_20("Đang đổi IP...");
							bool_1 = Common.smethod_56(class32_0.frmMain_0.int_9, 0, class32_0.frmMain_0.string_10, "");
							num = 0;
							if (bool_1)
							{
								class32_0.frmMain_0.Invoke((MethodInvoker)delegate
								{
									class32_0.frmMain_0.stIPCur.Text = class32_0.frmMain_0.method_54();
								});
							}
						}
						if (class32_0.frmMain_0.queue_0 != null && class32_0.frmMain_0.queue_0.Count == 0)
						{
							break;
						}
						class32_0.frmMain_0.method_20("Đang reg...");
						Common.smethod_62(0.5);
						if (class32_0.frmMain_0.bool_0)
						{
							break;
						}
						int num6 = 0;
						while (num6 < class32_0.frmMain_0.int_11)
						{
							Class35 CS_0024_003C_003E8__locals0 = new Class35
							{
								class33_0 = this
							};
							if (class32_0.frmMain_0.bool_0)
							{
								break;
							}
							CS_0024_003C_003E8__locals0.int_0 = 0;
							class32_0.frmMain_0.dgvAcc.Invoke((MethodInvoker)delegate
							{
								CS_0024_003C_003E8__locals0.int_0 = CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.dgvAcc.Rows.Add();
							});
							num6++;
							Thread thread2 = new Thread((ThreadStart)delegate
							{
								while (!CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.bool_0)
								{
									if (!CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.bool_0)
									{
										try
										{
											CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.dgvAcc.Invoke((MethodInvoker)delegate
											{
												CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.dgvAcc.Rows[CS_0024_003C_003E8__locals0.int_0].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
											});
											CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.method_24(CS_0024_003C_003E8__locals0.int_0, CS_0024_003C_003E8__locals0.int_0 + 1, CS_0024_003C_003E8__locals0.class33_0.bool_0, CS_0024_003C_003E8__locals0.class33_0.class32_0.frmMain_0.string_9);
											Common.smethod_62(1.0);
										}
										catch
										{
										}
									}
								}
							});
							thread2.Name = CS_0024_003C_003E8__locals0.int_0.ToString();
							thread2.Start();
							class32_0.frmMain_0.list_3.Add(thread2);
							if (class32_0.frmMain_0.int_9 != 6 || !class32_0.frmMain_0.bool_12)
							{
								continue;
							}
							try
							{
								for (int n = 0; n < class32_0.frmMain_0.list_3.Count; n++)
								{
									class32_0.frmMain_0.list_3[n].Join();
									class32_0.frmMain_0.list_3.RemoveAt(n--);
								}
							}
							catch
							{
							}
						}
						for (int num7 = 0; num7 < class32_0.frmMain_0.list_3.Count(); num7++)
						{
							try
							{
								class32_0.frmMain_0.list_3[num7].Join();
							}
							catch
							{
							}
						}
						for (int num8 = 0; num8 < class32_0.frmMain_0.list_3.Count(); num8++)
						{
							try
							{
								class32_0.frmMain_0.list_3[num8].Abort();
							}
							catch
							{
							}
						}
						class32_0.frmMain_0.list_3.Clear();
					}
				}
				class32_0.frmMain_0.method_50();
				class32_0.frmMain_0.method_19("stop");
				class32_0.frmMain_0.list_4.Clear();
				class32_0.frmMain_0.btnStop.Invoke((MethodInvoker)delegate
				{
					class32_0.frmMain_0.btnStop.Text = "Dừng lại";
					class32_0.frmMain_0.plTrangThai.Text = "Kết thúc đăng ký";
				});
				if (Settings.Default.isAutoClearLD)
				{
					Common.smethod_39(class32_0.frmMain_0.string_9);
				}
				try
				{
					class32_0.thread_0.Abort();
				}
				catch
				{
				}
			}
		}

		[CompilerGenerated]
		private sealed class Class34
		{
			public int int_0;

			public Class33 class33_0;

			internal void method_0()
			{
				int_0 = class33_0.class32_0.frmMain_0.dgvAcc.Rows.Add();
			}

			internal void method_1()
			{
				try
				{
					int num = Common.smethod_83(ref class33_0.list_0);
					class33_0.class32_0.frmMain_0.method_24(int_0, num + 1, class33_0.bool_0, class33_0.class32_0.frmMain_0.string_9);
					Common.smethod_65(ref class33_0.list_0, num + 1);
					Interlocked.Decrement(ref class33_0.int_0);
				}
				catch
				{
					Interlocked.Decrement(ref class33_0.int_0);
				}
			}
		}

		[CompilerGenerated]
		private sealed class Class35
		{
			public int int_0;

			public Class33 class33_0;

			public MethodInvoker methodInvoker_0;

			internal void method_0()
			{
				int_0 = class33_0.class32_0.frmMain_0.dgvAcc.Rows.Add();
			}

			internal void method_1()
			{
				while (!class33_0.class32_0.frmMain_0.bool_0)
				{
					if (class33_0.class32_0.frmMain_0.bool_0)
					{
						continue;
					}
					try
					{
						class33_0.class32_0.frmMain_0.dgvAcc.Invoke((MethodInvoker)delegate
						{
							class33_0.class32_0.frmMain_0.dgvAcc.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
						});
						class33_0.class32_0.frmMain_0.method_24(int_0, int_0 + 1, class33_0.bool_0, class33_0.class32_0.frmMain_0.string_9);
						Common.smethod_62(1.0);
					}
					catch
					{
					}
				}
			}

			internal void method_2()
			{
				class33_0.class32_0.frmMain_0.dgvAcc.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
			}
		}

		[CompilerGenerated]
		private sealed class Class36
		{
			public frmMain frmMain_0;

			public string string_0;

			internal void method_0()
			{
				frmMain_0.plTrangThai.Text = string_0;
			}
		}

		[CompilerGenerated]
		private sealed class Class37
		{
			public frmMain frmMain_0;

			public int int_0;

			public Device device_0;

			internal void method_0()
			{
				frmMain_0.dgvAcc.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
			}

			internal void method_1()
			{
				frmMain_0.dgvAcc.Rows[int_0].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
			}

			internal void method_2()
			{
				frmViewLD.frmViewLD_0.method_4(device_0.int_0);
			}
		}

		[CompilerGenerated]
		private sealed class Class38
		{
			public DataGridView dataGridView_0;

			public int int_0;

			public string string_0;

			public string string_1;

			internal void method_0()
			{
				dataGridView_0.Rows[int_0].Cells[string_0].Value = string_1;
			}
		}

		[CompilerGenerated]
		private sealed class Class39
		{
			public int int_0;

			public frmMain frmMain_0;

			internal void method_0()
			{
				int i;
				for (i = 0; i < int_0; i++)
				{
					Class2.smethod_24("add", 0, bool_0: true, frmMain_0.txtLinkLD.Text);
				}
				MessageBox.Show("Tạo thành công " + i + " LDPlayer");
			}
		}

		public static frmMain frmMain_0;

		private Random random_0 = new Random();

		private List<int> list_0 = new List<int>();

		private List<string> list_1 = new List<string>();

		private List<string> list_2 = new List<string>();

		private bool bool_0;

		private string[] string_0 = File.ReadAllLines("data/US/firstname_female.txt");

		private string[] string_1 = File.ReadAllLines("data/US/firstname_male.txt");

		private string[] string_2 = File.ReadAllLines("data/US/lastname.txt");

		private string[] string_3 = File.ReadAllLines("data/VN/firstname_female.txt");

		private string[] string_4 = File.ReadAllLines("data/VN/firstname_male.txt");

		private string[] string_5 = File.ReadAllLines("data/VN/lastname.txt");

		private string[] string_6 = File.ReadAllLines("data/THAI/firstname_female.txt");

		private string[] string_7 = File.ReadAllLines("data/THAI/firstname_male.txt");

		private string[] string_8 = File.ReadAllLines("data/THAI/lastname.txt");

		private int int_0 = 0;

		private int int_1 = 0;

		private int int_2 = 0;

		private int int_3 = 0;

		private int int_4 = 0;

		private int int_5 = 0;

		private int int_6 = 0;

		private int int_7 = 0;

		private string string_9 = "";

		private int int_8 = 0;

		private int int_9 = 0;

		private string string_10 = "";

		private string string_11 = "";

		private string string_12 = "";

		private int int_10 = 0;

		public string string_13;

		private int int_11 = 0;

		private List<Thread> list_3;

		public bool bool_1;

		private List<Device> list_4;

		private object object_0;

		private int int_12 = 0;

		private string string_14 = "";

		private int int_13 = 0;

		private int int_14 = 0;

		private bool bool_2 = false;

		private bool bool_3 = false;

		private bool bool_4 = false;

		private bool bool_5 = false;

		private bool bool_6 = false;

		private bool bool_7 = false;

		private int int_15 = 0;

		private int int_16 = 0;

		private bool bool_8 = false;

		private int int_17;

		private object object_1;

		private int int_18;

		private object object_2;

		private object object_3;

		private object object_4;

		private bool bool_9;

		private List<Class67> list_5;

		private List<string> list_6;

		private string string_15 = "";

		private int int_19 = 0;

		private int int_20 = 0;

		private object object_5 = new object();

		private string string_16 = "";

		private int int_21 = 0;

		private List<string> list_7 = null;

		private int int_22;

		private int int_23;

		private object object_6;

		private bool bool_10 = false;

		private string string_17 = "";

		private static List<float> list_8 = new List<float>();

		private static List<float> list_9 = new List<float>();

		protected static PerformanceCounter performanceCounter_0;

		protected static PerformanceCounter performanceCounter_1;

		private object object_7 = new object();

		private object object_8 = new object();

		private object object_9 = new object();

		private object object_10 = new object();

		private object object_11 = new object();

		private object object_12;

		private List<string> list_10 = new List<string>();

		private List<string> list_11 = new List<string>();

		private List<Class51> list_12 = null;

		private int int_24 = 0;

		private object object_13 = new object();

		private object object_14 = new object();

		private string string_18;

		private string string_19;

		private List<string> list_13 = new List<string>();

		private Queue<string> queue_0;

		private Queue<string> queue_1;

		private bool bool_11 = false;

		private int int_25;

		private List<Class73> list_14 = new List<Class73>();

		private List<Class68> list_15 = new List<Class68>();

		private List<Class61> list_16 = new List<Class61>();

		private int int_26;

		private int int_27;

		private bool bool_12 = false;

		private List<string> list_17 = new List<string>();

		private List<string> list_18 = new List<string>();

		private List<string> list_19 = new List<string>();

		private List<string> list_20;

		private int int_28;

		private int int_29;

		private bool bool_13;

		private bool bool_14;

		private int int_30;

		private int int_31;

		private int int_32;

		private int int_33;

		private bool bool_15;

		private int int_34 = 10;

		private int int_35 = 0;

		private int int_36 = 0;

		private bool bool_16 = false;

		private bool bool_17 = false;

		private int int_37 = 0;

		private int int_38 = 0;

		private string string_20 = "";

		private int int_39 = 0;

		private int int_40 = 0;

		private IContainer icontainer_0 = null;

		private StatusStrip statusStrip1;

		private ToolStripStatusLabel toolStripStatusLabel1;

		private ToolStripStatusLabel stTotalSuccess;

		private ToolStripStatusLabel toolStripStatusLabel3;

		private ToolStripStatusLabel toolStripStatusLabel4;

		private ToolStripStatusLabel stTotalFail;

		private ToolStripStatusLabel toolStripStatusLabel6;

		private ToolStripStatusLabel stIPCur;

		private ToolStripStatusLabel toolStripStatusLabel2;

		private ContextMenuStrip contextMenuStrip1;

		private ToolStripMenuItem copyToolStripMenuItem;

		private ToolStripMenuItem uidPassToolStripMenuItem;

		private ToolStripMenuItem uidPassTokenCookieToolStripMenuItem;

		private ToolStripMenuItem toolStripMenuItem_0;

		private ToolStripMenuItem toolStripMenuItem_1;

		private ToolStripMenuItem toolStripMenuItem_2;

		private ToolStripStatusLabel toolStripStatusLabel5;

		private ToolStripStatusLabel lblCountSelect;

		private ToolStripStatusLabel toolStripStatusLabel7;

		private ToolStripMenuItem toolStripMenuItem_3;

		private ToolStripMenuItem toolStripMenuItem_4;

		private ToolStripMenuItem uidPass2FAToolStripMenuItem;

		private ToolStripMenuItem liveToolStripMenuItem;

		private ToolStripMenuItem dieToolStripMenuItem;

		private ToolStripMenuItem checkpointToolStripMenuItem;

		private ToolStripMenuItem mailPassMailToolStripMenuItem;

		private ToolStripStatusLabel toolStripStatusLabel8;

		private ToolStripStatusLabel toolStripStatusLabel9;

		private ToolStripStatusLabel plTrangThai;

		private ToolStripStatusLabel toolStripStatusLabel10;

		private System.Windows.Forms.Timer timer_0;

		private PictureBox pictureBox1;

		private Button btnClose;

		private Button btnMinimized;

		private Label label28;

		private Panel panel4;

		private System.Windows.Forms.Timer timer_1;

		private ToolStripStatusLabel toolStripStatusLabel14;

		private ToolStripStatusLabel lblTimeExpired;

		private ToolStripStatusLabel toolStripStatusLabel15;

		private ToolStripStatusLabel toolStripStatusLabel16;

		private ToolStripStatusLabel lblMachineName;

		private ToolStripMenuItem allToolStripMenuItem;

		private BunifuDragControl bunifuDragControl_0;

		private Button btnMaximum;

		private Panel pnlContainer;

		private Button btnAutoConfig;

		private Button btnSaveConf;

		private Button btnStop;

		private Button btnReg;

		private GroupBox groupBox2;

		private DataGridView dgvAcc;

		private GroupBox groupBox1;

		private GroupBox groupBox7;

		private TextBox txtLinkAvartar;

		private Button btnNhapanh;

		private Panel panel3;

		private RadioButton rbRandomMF;

		private RadioButton rbFemale;

		private RadioButton rbMale;

		private CheckBox chkCoverImg;

		private CheckBox chkAvartar;

		private CheckBox chk2FA;

		private CheckBox chkRandomPass;

		private Label label14;

		private Label label13;

		private TextBox txtPassFb;

		private Label label12;

		private ComboBox cbNameReg;

		private GroupBox groupBox6;

		private Panel panel2;

		private Panel plNovery;

		private RadioButton rdNoveriMail;

		private RadioButton rdNovriPhone;

		private Label label18;

		private Label label17;

		private ComboBox cbMailAo;

		private ComboBox cbbPhoneCountry;

		private Panel plVeriPhone;

		private Button btnCheckSim;

		private Label label9;

		private Label label10;

		private ComboBox cbDvSim;

		private TextBox txtAPISim;

		private RadioButton rdThuePhone;

		private RadioButton rdNoVeri;

		private RadioButton rdConfMail;

		private GroupBox groupBox8;

		private Panel pnlTuongTac;

		private GroupBox gbCamxuc;

		private CheckBox chkGian;

		private CheckBox chkBuon;

		private CheckBox chkHaha;

		private CheckBox chkTym;

		private CheckBox chkLike;

		private Panel plAddfriend;

		private NumericUpDown nFriendTo;

		private Label label25;

		private NumericUpDown nFriendFrom;

		private Label label26;

		private Label label27;

		private CheckBox chkInNewfeed;

		private CheckBox chkWatch;

		private CheckBox chkWStory;

		private CheckBox chkAddFUID;

		private CheckBox chkReadNotifi;

		private GroupBox groupBox5;

		private Panel panel5;

		private Panel plCheckDoiIP;

		private Button btnTestChangeIP;

		private NumericUpDown numChangeIP;

		private Label label20;

		private Label label21;

		private Panel plChangeIPDcom;

		private Button btnGetDcom;

		private TextBox txtNameDcom;

		private RadioButton rdHMA;

		private RadioButton rdChangeIPDcom;

		private RadioButton rdNoChangeIP;

		private GroupBox groupBox4;

		private Panel panel7;

		private NumericUpDown numDelayTo;

		private RadioButton rdDelayLD;

		private Label label4;

		private NumericUpDown numDelayFr;

		private Label label5;

		private TextBox txtLinkLD;

		private NumericUpDown numDeClsTo;

		private NumericUpDown numDeClsFr;

		private Label label7;

		private RadioButton rdNormal;

		private Label label8;

		private Label label6;

		private Label label3;

		private GroupBox groupBox3;

		private NumericUpDown numOTP;

		private NumericUpDown nudSoLuotChay;

		private NumericUpDown numThrLdPlay;

		private Label label24;

		private Label label11;

		private Button button1;

		private Label label23;

		private Label label2;

		private Label label1;

		private RadioButton rdSwap;

		private TabControl tabProxy;

		private TabPage tabPage1;

		private LinkLabel linkLabel1;

		private Panel plTinsoftProxy;

		private NumericUpDown nudLuongPerIPTinsoft;

		private Button btnCheckProxy;

		private Label label16;

		private Label label29;

		private Label label15;

		private TextBox txtProxy;

		private ComboBox cbLocationProxy;

		private RadioButton rdTinsoftProxy;

		private RadioButton rdProxy;

		private TabPage tabPage3;

		private Panel pnlIpPort;

		private RadioButton rdIPPortUserPass;

		private Label lblListProxyIP;

		private ComboBox cbbTypeProxyIP;

		private Label label30;

		private RichTextBox txtListProxyIp;

		private Label label31;

		private Label label33;

		private Label label34;

		private RadioButton rdIPDong;

		private RadioButton rdIPStatic;

		private TabPage tabPage4;

		private Panel panel1;

		private Panel plXproxy;

		private Panel panel8;

		private Label label53;

		private RadioButton rbXproxyResetAllProxy;

		private RadioButton rbXproxyResetEachProxy;

		private CheckBox ckbWaitDoneAllXproxy;

		private RichTextBox txtListXProxy;

		private RadioButton rbSock5Proxy;

		private RadioButton rbHttpProxy;

		private Label label35;

		private Label lblCountXproxy;

		private Label label52;

		private Label label51;

		private Label label37;

		private NumericUpDown nudDelayResetXProxy;

		private NumericUpDown nudLuongPerIPXProxy;

		private Label label38;

		private TextBox txtServiceURLXProxy;

		private RadioButton rbXproxy;

		private Label label39;

		private NumericUpDown nudDelayQR2Fa;

		private Label label40;

		private Label label36;

		private TabPage tabPage2;

		private LinkLabel linkLabel2;

		private Panel pnlAPIMinProxy;

		private Button btnCheckAPIMinProxy;

		private RichTextBox txtApiKeyMinProxy;

		private Label lblAPIMinKey;

		private Label label32;

		private Label label50;

		private NumericUpDown nudLuongPerIPMinProxy;

		private RadioButton rdMinProxy;

		private TabPage tabPage5;

		private Panel plTMProxy;

		private RichTextBox txtApiKeyTMProxy;

		private Label lblCountTmProxy;

		private Label label42;

		private NumericUpDown nudLuongPerIPTMProxy;

		private RadioButton rbTMProxy;

		private LinkLabel linkLabel3;

		private TabControl tabMailVeri;

		private TabPage tabPage6;

		private Panel plVeriMail;

		private Panel plHotmailReg;

		private Button btnCheckAPIAny;

		private TextBox txtPassmail;

		private TextBox txtAPIAnyCat;

		private Label label22;

		private CheckBox ckRdPassmail;

		private CheckBox chkHideBrowser;

		private CheckBox ckTaoMailBox;

		private Label label19;

		private Button btnNhapHotmail;

		private RadioButton rdHotMailReg;

		private RadioButton rdHotMailRegisted;

		private TabPage tabPage7;

		private Panel pnlTemmail;

		private LinkLabel lnkTempMailIO;

		private RadioButton rdTempMailIO;

		private NumericUpDown nAgeTo;

		private NumericUpDown nAgeFrom;

		private Label label43;

		private Label label41;

		private ComboBox cbbPrePhone;

		private TextBox txtListDauso;

		private DataGridViewCheckBoxColumn cChose;

		private DataGridViewTextBoxColumn cId;

		private DataGridViewTextBoxColumn status;

		private DataGridViewTextBoxColumn uid;

		private DataGridViewTextBoxColumn pass;

		private DataGridViewTextBoxColumn ho;

		private DataGridViewTextBoxColumn ten;

		private DataGridViewTextBoxColumn age;

		private DataGridViewTextBoxColumn gender;

		private DataGridViewTextBoxColumn conf_2fa;

		private DataGridViewTextBoxColumn token;

		private DataGridViewTextBoxColumn cookie;

		private DataGridViewTextBoxColumn email;

		private DataGridViewTextBoxColumn passMail;

		private DataGridViewTextBoxColumn phone;

		private DataGridViewTextBoxColumn proxy;

		private DataGridViewTextBoxColumn cInfo;

		private DataGridViewTextBoxColumn cDevice;

		private Label label45;

		private ComboBox cbModeRunReg;

		private Panel pnlSoLanReg;

		private CheckBox ckCheckIP;

		private Button btnOutpuData;

		private ToolStripMenuItem phoneToolStripMenuItem;

		private TabPage tabPage8;

		private LinkLabel lnkShopLike;

		private Panel plProxyShopLike;

		private RichTextBox txtAPIKeyShoplike;

		private Label lblAPIKeyShopLike;

		private Label label47;

		private NumericUpDown nudThreadShopLike;

		private RadioButton rbProxyShoplike;

		private Button btnCheckTMProxy;

		private NumericUpDown nudTimeWaitOTP;

		private Label label48;

		private Label label46;

		private LinkLabel lnkMailTM;

		private RadioButton rdMailTM;

		private BunifuDragControl bunifuDragControl_1;

		private Button btnManagerLD;

		private Button btnRepairLD;

		private Button btnCreateLDPLayer;

		private Button btnTurnOffAllLD;

		private TabPage tabPage9;

		private RadioButton rdProxyOrbit;

		private Panel pnlProxyFree;

		private RadioButton rdProxyFreeRandom;

		private RadioButton rdProxyFreeUS;

		private RadioButton rdProxyFreeVN;

		public frmMain(string timeExpired)
		{
			InitializeComponent();
			frmMain_0 = this;
			base.MaximizedBounds = Screen.FromHandle(base.Handle).WorkingArea;
			base.WindowState = FormWindowState.Maximized;
			method_58();
			method_61();
			btnReg.Enabled = true;
			btnStop.Enabled = false;
			btnSaveConf.Enabled = true;
			int_18 = 0;
			object_2 = new object();
			int_17 = 0;
			object_1 = new object();
			object_3 = new object();
			object_4 = new object();
			bool_9 = false;
			list_5 = null;
			list_6 = null;
			list_3 = new List<Thread>();
			list_7 = (from string_0 in Directory.GetFiles(AppDomain.CurrentDomain.BaseDirectory + "extension")
				where Path.GetExtension(string_0) == ".crx"
				select string_0).ToList();
			if (Settings.Default.isDongBoDB)
			{
				method_0();
			}
			stIPCur.Text = method_54();
			tabProxy.Controls.Remove(tabPage2);
			try
			{
				Common.int_0 = Screen.PrimaryScreen.Bounds.Width;
				Common.int_1 = Screen.PrimaryScreen.Bounds.Height;
				int_22 = 2 * Common.int_0 / 6;
				int_23 = Common.int_1 / 2;
			}
			catch
			{
			}
			string text = Common.smethod_79(new DeviceIdBuilder().AddMachineName().AddProcessorId().AddMotherboardSerialNumber()
				.AddSystemDriveSerialNumber()
				.ToString());
			lblMachineName.Text = text;
			lblTimeExpired.Text = Convert.ToDateTime(timeExpired).ToString("dd/MM/yyyy");
		}

		private void method_0()
		{
			Class48 @class = new Class48("setting_danhba.ini");
			int_28 = ((@class.method_1("nPhoneFr") == null) ? 1 : Convert.ToInt32(@class.method_1("nPhoneFr")));
			int_29 = ((@class.method_1("nPhoneTo") != null) ? Convert.ToInt32(@class.method_1("nPhoneTo")) : 10);
			int_30 = ((@class.method_1("nKetbanFr") != null) ? Convert.ToInt32(@class.method_1("nKetbanFr")) : 2);
			int_31 = ((@class.method_1("nKetBanTo") != null) ? Convert.ToInt32(@class.method_1("nKetBanTo")) : 5);
			int_32 = ((@class.method_1("nDelayFr") != null) ? Convert.ToInt32(@class.method_1("nDelayFr")) : 2);
			int_33 = ((@class.method_1("nDelayTo") != null) ? Convert.ToInt32(@class.method_1("nDelayTo")) : 5);
			bool_13 = @class.method_1("ckDeletePhone") != null && Convert.ToBoolean(@class.method_1("ckDeletePhone"));
			bool_14 = @class.method_1("ckAddFriends") != null && Convert.ToBoolean(@class.method_1("ckAddFriends"));
			string text = ((@class.method_1("txtListPhone") != null) ? @class.method_1("txtListPhone") : "");
			if (text != string.Empty)
			{
				list_20 = new List<string>();
				string[] array = text.Split('|');
				for (int i = 0; i < array.Length; i++)
				{
					list_20.Add(array[i]);
				}
			}
		}

		public string method_1(int int_41, string string_21)
		{
			return Class15.smethod_3(dgvAcc, int_41, string_21);
		}

		void OnLoad(EventArgs e)
		{
			Application.Idle += method_2;
		}

		private void method_2(object sender, EventArgs e)
		{
			Application.Idle -= method_2;
			new Thread((ThreadStart)delegate
			{
				while (true)
				{
					try
					{
						string text = Class2.smethod_34("adb devices");
						if (!text.Contains("List of devices attached"))
						{
							Common.smethod_63("adb");
							bool_1 = true;
						}
					}
					catch
					{
					}
					Common.smethod_62(30.0);
				}
			}).Start();
		}

		private string method_3()
		{
			return string_2[random_0.Next(0, string_2.Length - 1)];
		}

		private string method_4()
		{
			return string_0[random_0.Next(0, string_0.Length - 1)];
		}

		private string method_5()
		{
			return string_1[random_0.Next(0, string_1.Length - 1)];
		}

		private string method_6()
		{
			return string_5[random_0.Next(0, string_5.Length - 1)];
		}

		private string method_7()
		{
			return string_4[random_0.Next(0, string_4.Length - 1)];
		}

		private string method_8()
		{
			return string_3[random_0.Next(0, string_3.Length - 1)];
		}

		private string method_9()
		{
			return string_8[random_0.Next(0, string_8.Length - 1)].Trim();
		}

		private string method_10()
		{
			return string_7[random_0.Next(0, string_7.Length - 1)].Trim();
		}

		private string method_11()
		{
			return string_6[random_0.Next(0, string_6.Length - 1)].Trim();
		}

		private string method_12()
		{
			string text = "Nguyen|Tran|Le|Pham|Hoang|Huynh|Phan|Vu|Vo|Dang|Dinh|Trinh|Doan|Bui|Do|Ho|Ngo|Duong|Ly|Dao|Ung|Lieu|Mai";
			string[] array = text.Split('|');
			return array[random_0.Next(0, array.Length - 1)];
		}

		public void method_13()
		{
			try
			{
				plTrangThai.Text = "Dừng chạy";
				plTrangThai.ForeColor = Color.Red;
				bool_0 = true;
				if (list_3.Count > 0)
				{
					list_3.Clear();
				}
				if (list_4 != null && list_4.Count > 0)
				{
					list_4.Clear();
				}
				method_19("stop");
			}
			catch
			{
			}
		}

		private string method_14()
		{
			string text = "Kim Quyen|Phuoc Thien|Quynh Tran|Vinh|Binh|Huynh Ngoc Dung| Van|Thanh Bich|Thu Hien|Bao Ngoc|Thao|Huynh Truc Vy|Ba Duy|Thuy Linh|Huyen Tram|Ngoc Hoa|Hoang Quyen|Ngoc Diep|Thanh Ha|Hoang Phuong|Truc Ly|Tram|Trang Oanh|My|Nhu|Lai|Kim|Phuc|Phuong|Tram Anh|Dieu Anh|Quynh Anh|Ngoc Diep|Kim Khanh|Ngoc Lien|Cat TuongDiệu Ái|Khả Ái|Ngọc Ái|Hoài An|Huệ An|Minh An|Phương An|Thanh An|Hải Ân|Huệ Ân|Bảo Anh|Diệp Anh|Diệu Anh|Hải Anh|Hồng Anh|Huyền Anh|Kiều Anh|Kim Anh|Lan Anh|Mai Anh|Minh Anh|Mỹ Anh|Ngọc Anh|Nguyệt Anh|Như Anh|Phương Anh|Quế Anh|Quỳnh Anh|Thục Anh|Thúy Anh|Thùy Anh|Trâm Anh|Trang Anh|Tú Anh|Tuyết Anh|Vân Anh|Yến Anh|Kim Ánh|Ngọc Ánh|Nguyệt Ánh|Nhật Ánh|Băng Băng|Lệ Băng|Tuyết Băng|Như Bảo|Gia Bảo|Xuân Bảo|Ngọc Bích|An Bình|Thái Bình|Sơn Ca|Ngọc Cầm|Nguyệt Cầm|Thi Cầm|Bảo Châu|Bích Châu|Diễm Châu|Hải Châu|Hoàn Châu|Hồng Châu|Linh Châu|Loan Châu|Ly Châu|Mai Châu|Minh Châu|Trân Châu|Diệp Chi|Diễm Chi|Hạnh Chi|Khánh Chi|Kim Chi|Lan Chi|Lệ Chi|Linh Chi|Mai Chi|Phương Chi|Quế Chi|Quỳnh Chi|Bích Chiêu|Hoàng Cúc|Kim Cương|Trang Ðài|Tâm Đan|Thanh Đan|Linh Ðan|Quỳnh Dao|Anh Ðào|Bích Ðào|Hồng Ðào|Ngọc Ðào|Thục Ðào|Trúc Ðào|An Di|Thiên Di|Hồng Diễm|Kiều Diễm|Phương Diễm|Thúy Diễm|Bích Diệp|Hồng Diệp|Ngọc Diệp|Bích Ðiệp|Hồng Ðiệp|Mộng Ðiệp|Ngọc Ðiệp|Huyền Diệu|Tâm Ðoan|Thục Ðoan|Hạnh Dung|Kiều Dung|Kim Dung|Mỹ Dung|Nghi Dung|Ngọc Dung|Phương Dung|Quỳnh Dung|Thùy Dung|Ánh Dương|Chiêu Dương|Thùy Dương|Hải Ðường|Bích Duyên|Kỳ Duyên|Linh Duyên|Minh Duyên|Mỹ Duyên|Thu Duyên|Bảo An|Bình An|Ðăng An|Duy An|Khánh An|Nam An|Phước An|Thành An|Thế An|Thiên An|Trường An|Việt An|Xuân An|Công Ân|Ðức Ân|Gia Ân|Hoàng Ân|Minh Ân|Phú Ân|Thành Ân|Thiên Ân|Thiện Ân|Duy Bảo|Gia Bảo|Hữu Bảo|Nguyên Bảo|Quốc Bảo|Thiệu Bảo|Tiểu Bảo|Ðức Bình|Gia Bình|Khải Ca|Gia Cần|Duy Cẩn|Gia Cẩn|Hữu Canh|Gia Cảnh|Hữu Cảnh|Minh Cảnh|Ngọc Cảnh|Đức Cao|Xuân Cao|Bảo Chấn|Bảo Châu|";
			string[] array = text.Split('|');
			return array[random_0.Next(0, array.Length - 1)];
		}

		private void method_15(object sender, EventArgs e)
		{
		}

		private void method_16(object sender, EventArgs e)
		{
		}

		private void method_17(object sender, EventArgs e)
		{
		}

		private void method_18(object sender, EventArgs e)
		{
		}

		public void method_19(string string_21)
		{
			if (!base.IsHandleCreated)
			{
				return;
			}
			Invoke((MethodInvoker)delegate
			{
				try
				{
					if (string_21 == "start")
					{
						btnReg.Enabled = false;
						btnSaveConf.Enabled = false;
						btnAutoConfig.Enabled = false;
						btnStop.Enabled = true;
					}
					else if (string_21 == "stop")
					{
						btnReg.Enabled = true;
						btnSaveConf.Enabled = true;
						btnAutoConfig.Enabled = true;
						btnStop.Enabled = false;
					}
				}
				catch (Exception)
				{
				}
			});
		}

		private void btnReg_Click(object sender, EventArgs e)
		{
			list_4 = new List<Device>();
			Thread thread_0 = null;
			try
			{
				thread_0 = new Thread((ThreadStart)delegate
				{
					while (true)
					{
						try
						{
							if (this.bool_1 && list_4.Count > 0)
							{
								bool flag = false;
								while (!flag)
								{
									flag = true;
									for (int num17 = 0; num17 < list_4.Count; num17++)
									{
										string text3 = Class2.smethod_36(list_4[num17].int_0);
										if (string.IsNullOrEmpty(text3))
										{
											flag = false;
										}
										else
										{
											list_4[num17].DeviceId = text3;
										}
									}
								}
								this.bool_1 = false;
							}
						}
						catch
						{
						}
						method_51(5.0);
					}
				});
				thread_0.IsBackground = true;
				thread_0.Start();
			}
			catch
			{
			}
			try
			{
				Class48 @class = new Class48("setting.ini");
				int_11 = Convert.ToInt32(@class.method_1("nudThread"));
				if (int_11 <= 0)
				{
					MessageBox.Show("Số luồng phải > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				method_60();
				int_1 = Convert.ToInt32(@class.method_1("nudSoLuotChay"));
				int_7 = Convert.ToInt32(@class.method_1("nudThoiGianChoNhapOTP"));
				int_2 = Convert.ToInt32(@class.method_1("optionMemu"));
				int_3 = Convert.ToInt32(@class.method_1("numDelayFr"));
				int_4 = Convert.ToInt32(@class.method_1("numDelayTo"));
				int_5 = Convert.ToInt32(@class.method_1("numDeClsFr"));
				int_6 = Convert.ToInt32(@class.method_1("numDeClsTo"));
				int_9 = Convert.ToInt32(@class.method_1("typeChangeIp"));
				string_9 = @class.method_1("linkLD").ToString();
				string_10 = @class.method_1("txtProfileNameDcom").ToString();
				string_12 = @class.method_1("typeVerify");
				int_21 = Convert.ToInt32(@class.method_1("cbbPhoneCountry"));
				int_12 = Convert.ToInt32(@class.method_1("typeNameReg"));
				string_14 = @class.method_1("passFB").ToString();
				bool_5 = Convert.ToBoolean(@class.method_1("isRdPass"));
				int_13 = Convert.ToInt32(@class.method_1("typeGender"));
				int_15 = Convert.ToInt32(@class.method_1("ageFrom"));
				int_16 = Convert.ToInt32(@class.method_1("ageTo"));
				bool_2 = Convert.ToBoolean(@class.method_1("is2Fa"));
				bool_3 = Convert.ToBoolean(@class.method_1("isAvartar"));
				bool_4 = Convert.ToBoolean(@class.method_1("isCoverImg"));
				bool_7 = Convert.ToBoolean(@class.method_1("isLanguage"));
				bool_6 = Convert.ToBoolean(@class.method_1("is2Fa"));
				string_15 = @class.method_1("txtAPIProxy").ToString();
				int_8 = Convert.ToInt32(@class.method_1("iSoLuotDoiIpMotLan"));
				bool_10 = Convert.ToBoolean(@class.method_1("ckTaoMailBox"));
				string_17 = @class.method_1("txtPassmail");
				string_11 = @class.method_1("txtAPISim");
				string_16 = @class.method_1("txtAPIAnyCat");
				int_24 = Convert.ToInt32(@class.method_1("nudLuongPerIPMinProxy"));
				string_18 = @class.method_1("linkAvartar");
				string_19 = @class.method_1("linkCover");
				bool_11 = Convert.ToBoolean(@class.method_1("ckRdPassmail"));
				bool bool_0 = Convert.ToInt32(@class.method_1("modeRun")) == 1;
				bool_15 = Settings.Default.isDongBoDB;
				int_34 = Convert.ToInt32(@class.method_1("nudDelayQR2Fa"));
				int_15 = ((@class.method_1("nAgeFrom") == "") ? 18 : Convert.ToInt32(@class.method_1("nAgeFrom")));
				int_16 = ((@class.method_1("nAgeTo") == "") ? 35 : Convert.ToInt32(@class.method_1("nAgeTo")));
				int_36 = ((!(@class.method_1("cbModeRunReg") == "")) ? Convert.ToInt32(@class.method_1("cbModeRunReg")) : 0);
				int_14 = ((@class.method_1("nudTimeWaitOTP") == "") ? 60 : Convert.ToInt32(@class.method_1("nudTimeWaitOTP")));
				if (Settings.Default.isVeriPhoneNoveri)
				{
					Class48 class2 = new Class48("setting_veriaccnoveri.ini");
					bool_16 = Settings.Default.isVeriPhoneNoveri;
					string_20 = ((class2.method_1("apikey") == "") ? "" : class2.method_1("apikey"));
					int_37 = ((!(class2.method_1("typePhone") == "")) ? Convert.ToInt32(class2.method_1("typePhone")) : 0);
					int_39 = ((class2.method_1("nudTimeGetPhone") == "") ? 10 : Convert.ToInt32(class2.method_1("nudTimeGetPhone")));
				}
				if (Settings.Default.isVeriMailNoveri)
				{
					Class48 class3 = new Class48("setting_verimailaccnoveri.ini");
					bool_17 = Settings.Default.isVeriMailNoveri;
					int_38 = ((!(class3.method_1("typeMail") == "")) ? Convert.ToInt32(class3.method_1("typeMail")) : 0);
				}
				if (int_1 == 0)
				{
					MessageBox.Show("Số lượt chạy > 0", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (!Directory.Exists(string_9))
				{
					MessageBox.Show("Đường dẫn LDPlayer không tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (chkAvartar.Checked && string_18 == string.Empty)
				{
					MessageBox.Show("Đường dẫn Folder avatar không hợp lệ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (rdProxy.Checked && rdIPPortUserPass.Checked)
				{
					list_13.Clear();
					List<string> list = txtListProxyIp.Lines.ToList();
					list = Common.smethod_77(list);
					foreach (string item6 in list)
					{
						list_13.Add(item6);
					}
					list_13 = Common.smethod_38(list_13);
					if (list_13.Count == 0)
					{
						MessageBox.Show("Vui lòng nhập danh sách proxy cần chạy", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						txtListProxyIp.Focus();
						return;
					}
					if (list_13.Count < int_11)
					{
						MessageBox.Show("Không đủ proxy để chạy với số luồng hiện tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					queue_0 = new Queue<string>(list_13);
				}
				if (int_9 == 2)
				{
					list_6 = Class67.smethod_2(string_15);
					if (list_6.Count == 0)
					{
						MessageBox.Show("Proxy Tinsoft không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					list_5 = new List<Class67>();
					int_19 = Convert.ToInt32(@class.method_1("nudLuongPerIPTinsoft"));
					int_20 = Convert.ToInt32(@class.method_1("cbbLocationTinsoft"));
					if (int_19 == 0)
					{
						MessageBox.Show("Số luồng chạy proxy Tinsoft > 0!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					for (int i = 0; i < list_6.Count; i++)
					{
						Class67 item = new Class67(list_6[i], int_19, int_20);
						list_5.Add(item);
					}
					if (list_6.Count * int_19 < int_11)
					{
						int_11 = list_6.Count * int_19;
					}
				}
				else if (int_9 == 1)
				{
					try
					{
						ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
						{
							UseShellExecute = false,
							RedirectStandardOutput = true,
							CreateNoWindow = true
						};
						Process process = Process.Start(startInfo);
						string text = process.StandardOutput.ReadToEnd();
						if (text.Split('\n').Length <= 3)
						{
							MessageBox.Show("Vui lòng kết nối Dcom trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
							return;
						}
					}
					catch
					{
						MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
						return;
					}
				}
				else if (int_9 == 3)
				{
					if (list_11.Count == 0)
					{
						MessageBox.Show("MinProxy không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					list_12 = new List<Class51>();
					for (int j = 0; j < list_11.Count; j++)
					{
						Class51 item2 = new Class51(list_11[j], 0, int_24);
						list_12.Add(item2);
					}
					if (list_11.Count * int_24 < int_11)
					{
						int_11 = list_11.Count * int_24;
					}
				}
				else if (int_9 == 6)
				{
					if (list_17.Count == 0)
					{
						MessageBox.Show("XProxy không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					int_26 = Convert.ToInt32(@class.method_1("typeRunXproxy"));
					int_27 = Convert.ToInt32(@class.method_1("nudDelayResetXProxy"));
					bool_12 = Convert.ToBoolean(@class.method_1("ckbWaitDoneAllXproxy"));
					list_14 = new List<Class73>();
					for (int k = 0; k < list_17.Count; k++)
					{
						Class73 item3 = new Class73(@class.method_1("txtServiceURLXProxy"), list_17[k], Convert.ToInt32(@class.method_1("typeRunXproxy")), Convert.ToInt32(@class.method_1("nudLuongPerIPXProxy")));
						list_14.Add(item3);
					}
					if (list_17.Count * Convert.ToInt32(@class.method_1("nudLuongPerIPXProxy")) < int_11)
					{
						int_11 = list_17.Count * Convert.ToInt32(@class.method_1("nudLuongPerIPXProxy"));
					}
				}
				else if (int_9 == 7)
				{
					if (list_18.Count == 0)
					{
						MessageBox.Show("TMProxy không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					list_15 = new List<Class68>();
					for (int l = 0; l < list_18.Count; l++)
					{
						Class68 item4 = new Class68(list_18[l], 0, Convert.ToInt32(@class.method_1("nudLuongPerIPTMProxy")));
						list_15.Add(item4);
					}
					if (list_18.Count * Convert.ToInt32(@class.method_1("nudLuongPerIPTMProxy")) < int_11)
					{
						int_11 = list_18.Count * Convert.ToInt32(@class.method_1("nudLuongPerIPTMProxy"));
					}
				}
				else if (int_9 == 8)
				{
					if (list_19.Count == 0)
					{
						MessageBox.Show("Proxy Shoplike không đủ, vui lòng mua thêm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					list_16 = new List<Class61>();
					for (int m = 0; m < list_19.Count; m++)
					{
						Class61 item5 = new Class61(list_19[m], 0, Convert.ToInt32(@class.method_1("nudThreadShopLike")));
						list_16.Add(item5);
					}
					if (list_19.Count * Convert.ToInt32(@class.method_1("nudThreadShopLike")) < int_11)
					{
						int_11 = list_19.Count * Convert.ToInt32(@class.method_1("nudThreadShopLike"));
					}
				}
				else if (int_9 == 5)
				{
					int_35 = ((!(@class.method_1("cbbTypeProxyIP") == "")) ? Convert.ToInt32(@class.method_1("cbbTypeProxyIP")) : 0);
				}
				else if (int_9 == 9)
				{
					int_40 = ((!(@class.method_1("typeProxyOrbit") == "")) ? Convert.ToInt32(@class.method_1("typeProxyOrbit")) : 0);
				}
				if (rdHotMailRegisted.Checked)
				{
					list_1 = File.ReadAllLines("hotmail.txt").ToList();
					list_1 = Common.smethod_77(list_1);
					if (list_1.Count <= 0 || list_1.Count < int_11)
					{
						MessageBox.Show("Vui lòng nhập thêm hotmail đã đăng ký!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
				}
				if (Settings.Default.isAddMailReg)
				{
					list_2 = File.ReadAllLines("EmailVeri.txt").ToList();
					list_2 = Common.smethod_77(list_2);
					if (list_2.Count <= 0 || list_2.Count < int_11)
					{
						MessageBox.Show("Email không đủ để add sau khi reg", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					queue_1 = new Queue<string>(list_2);
				}
				if (string_12.Substring(0, 1) == "0")
				{
					if (string_12.Substring(1, 1) != "0" && Settings.Default.isVeriPhoneNoveri)
					{
						MessageBox.Show("Vui lòng tắt chức năng veri phone cho noveri trong Cài đặt nâng cao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					if (string_12.Substring(1, 1) != "0" && Settings.Default.isVeriMailNoveri)
					{
						MessageBox.Show("Vui lòng tắt chức năng veri mail cho noveri trong Cài đặt nâng cao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
					if (Settings.Default.isVeriMailNoveri && Settings.Default.isVeriPhoneNoveri)
					{
						MessageBox.Show("Vui lòng chỉ sử dụng 1 kiểu veri cho noveri trong Cài đặt nâng cao", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
						return;
					}
				}
				if (string_12.Substring(0, 1) != "0" && (Settings.Default.isVeriMailNoveri || Settings.Default.isVeriPhoneNoveri))
				{
					MessageBox.Show("Vui lòng tắt chức năng veri cho noveri trong Cài đặt nâng cao trước khi reg veri trực tiếp", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				int int_0 = 0;
				this.bool_0 = false;
				bool bool_1 = false;
				List<int> list_0 = new List<int>();
				for (int n = 0; n < int_11; n++)
				{
					list_0.Add(0);
				}
				method_21(bool_0);
				for (int num = 0; num < int_11; num++)
				{
					frmViewLD.frmViewLD_0.method_0(num + 1);
				}
				new Thread((ThreadStart)delegate
				{
					method_19("start");
					int num2 = 0;
					dgvAcc.Invoke((MethodInvoker)delegate
					{
						dgvAcc.Rows.Clear();
					});
					if (int_36 == 0)
					{
						string text2 = "";
						int num3 = int_1;
						if (num3 == 0)
						{
							num3 = 1;
						}
						int num4 = 0;
						while (num4 < num3 && (queue_0 == null || queue_0.Count != 0))
						{
							text2 = ((num3 > 1) ? $"Lượt {num4 + 1}/{num3}. " : "");
							if (num3 > 1)
							{
								method_20("Đang reg..." + text2);
							}
							else
							{
								method_20("Đang reg...");
							}
							Common.smethod_62(0.5);
							if (this.bool_0)
							{
								break;
							}
							int num5 = 0;
							while (num5 < int_11 && !this.bool_0 && !this.bool_0)
							{
								if (int_0 < int_11)
								{
									Interlocked.Increment(ref int_0);
									int int_2 = 0;
									dgvAcc.Invoke((MethodInvoker)delegate
									{
										int_2 = dgvAcc.Rows.Add();
									});
									num5++;
									Thread thread = new Thread((ThreadStart)delegate
									{
										try
										{
											int num16 = Common.smethod_83(ref list_0);
											method_24(int_2, num16 + 1, bool_0, string_9);
											Common.smethod_65(ref list_0, num16 + 1);
											Interlocked.Decrement(ref int_0);
										}
										catch
										{
											Interlocked.Decrement(ref int_0);
										}
									})
									{
										Name = int_2.ToString()
									};
									list_3.Add(thread);
									Common.smethod_62(1.0);
									thread.Start();
								}
								else
								{
									for (int num6 = 0; num6 < list_3.Count(); num6++)
									{
										list_3[num6].Join();
									}
									for (int num7 = 0; num7 < list_3.Count(); num7++)
									{
										try
										{
											list_3[num7].Abort();
										}
										catch
										{
										}
									}
									list_3.Clear();
									int_0 = 0;
								}
								if (int_9 == 6 && bool_12)
								{
									try
									{
										for (int num8 = 0; num8 < list_3.Count; num8++)
										{
											list_3[num8].Join();
											list_3.RemoveAt(num8--);
										}
									}
									catch
									{
									}
								}
								if (this.bool_0)
								{
									break;
								}
							}
							for (int num9 = 0; num9 < list_3.Count(); num9++)
							{
								list_3[num9].Join();
							}
							for (int num10 = 0; num10 < list_3.Count(); num10++)
							{
								try
								{
									list_3[num10].Abort();
								}
								catch
								{
								}
							}
							list_3.Clear();
							num2++;
							if (!this.bool_0 && num2 >= int_8 && (int_9 == 1 || int_9 == 4))
							{
								method_20("Đang đổi IP...");
								bool_1 = Common.smethod_56(int_9, 0, string_10, "");
								num2 = 0;
								if (bool_1)
								{
									Invoke((MethodInvoker)delegate
									{
										stIPCur.Text = method_54();
									});
								}
							}
							if (num4 + 1 < num3)
							{
								int num11 = random_0.Next(0, 10);
								int tickCount = Environment.TickCount;
								while ((Environment.TickCount - tickCount) / 1000 - num11 < 0)
								{
									method_20(string.Format("Chạy lượt tiếp theo sau {time} giây...".Replace("{time}", (num11 - (Environment.TickCount - tickCount) / 1000).ToString())));
									Common.smethod_62(0.5);
									if (Settings.Default.isAutoClearLD)
									{
										Common.smethod_39(string_9);
									}
									if (this.bool_0)
									{
										break;
									}
								}
							}
							if (!this.bool_0)
							{
								num4++;
							}
							else if (this.bool_0)
							{
								method_19("stop");
								break;
							}
						}
					}
					else
					{
						while (!this.bool_0)
						{
							if (int_9 == 1 || int_9 == 4)
							{
								method_20("Đang đổi IP...");
								bool_1 = Common.smethod_56(int_9, 0, string_10, "");
								num2 = 0;
								if (bool_1)
								{
									Invoke((MethodInvoker)delegate
									{
										stIPCur.Text = method_54();
									});
								}
							}
							if (queue_0 != null && queue_0.Count == 0)
							{
								break;
							}
							method_20("Đang reg...");
							Common.smethod_62(0.5);
							if (this.bool_0)
							{
								break;
							}
							int num12 = 0;
							while (num12 < int_11)
							{
								if (this.bool_0)
								{
									break;
								}
								int int_ = 0;
								dgvAcc.Invoke((MethodInvoker)delegate
								{
									int_ = dgvAcc.Rows.Add();
								});
								num12++;
								Thread thread2 = new Thread((ThreadStart)delegate
								{
									while (!this.bool_0)
									{
										if (!this.bool_0)
										{
											try
											{
												dgvAcc.Invoke((MethodInvoker)delegate
												{
													dgvAcc.Rows[int_].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 255);
												});
												method_24(int_, int_ + 1, bool_0, string_9);
												Common.smethod_62(1.0);
											}
											catch
											{
											}
										}
									}
								});
								thread2.Name = int_.ToString();
								thread2.Start();
								list_3.Add(thread2);
								if (int_9 == 6 && bool_12)
								{
									try
									{
										for (int num13 = 0; num13 < list_3.Count; num13++)
										{
											list_3[num13].Join();
											list_3.RemoveAt(num13--);
										}
									}
									catch
									{
									}
								}
							}
							for (int num14 = 0; num14 < list_3.Count(); num14++)
							{
								try
								{
									list_3[num14].Join();
								}
								catch
								{
								}
							}
							for (int num15 = 0; num15 < list_3.Count(); num15++)
							{
								try
								{
									list_3[num15].Abort();
								}
								catch
								{
								}
							}
							list_3.Clear();
						}
					}
					method_50();
					method_19("stop");
					list_4.Clear();
					btnStop.Invoke((MethodInvoker)delegate
					{
						btnStop.Text = "Dừng lại";
						plTrangThai.Text = "Kết thúc đăng ký";
					});
					if (Settings.Default.isAutoClearLD)
					{
						Common.smethod_39(string_9);
					}
					try
					{
						thread_0.Abort();
					}
					catch
					{
					}
				}).Start();
			}
			catch
			{
				plTrangThai.Text = "Kết thúc đăng ký";
				btnStop.Text = "Dừng lại";
				method_19("stop");
				method_50();
				list_4.Clear();
				list_4.Clear();
				if (Settings.Default.isAutoClearLD)
				{
					Common.smethod_39(string_9);
				}
				try
				{
					thread_0.Abort();
				}
				catch
				{
				}
			}
		}

		private void method_20(string string_21)
		{
			try
			{
				Invoke((MethodInvoker)delegate
				{
					plTrangThai.Text = string_21;
				});
			}
			catch
			{
			}
		}

		private void method_21(bool bool_18)
		{
			if (!Common.smethod_84("frmViewLD"))
			{
				frmViewLD obj = new frmViewLD();
				obj.bool_0 = bool_18;
				obj.Show();
			}
		}

		public void method_22(int int_41, string string_21, object object_15, bool bool_18 = true)
		{
			if (bool_18 || !(object_15.ToString().Trim() == ""))
			{
				Class15.smethod_4(dgvAcc, int_41, string_21, object_15);
			}
		}

		private bool method_23(Device device_0)
		{
			device_0.method_103();
			device_0.method_121(1.0);
			bool flag = false;
			int num = 0;
			device_0.method_91(262, 387);
			device_0.method_121(1.0);
			while (num < 5)
			{
				num++;
				if (device_0.method_52("DataClick\\xposed\\on"))
				{
					flag = true;
					break;
				}
			}
			if (!flag)
			{
				device_0.method_91(97, 222);
				device_0.method_121(2.0);
				device_0.method_91(53, 247);
				int i = 0;
				bool flag2 = false;
				for (; i < 60; i++)
				{
					if (device_0.method_52("DataClick\\xposed\\rememberchoice"))
					{
						flag2 = true;
						break;
					}
				}
				if (flag2)
				{
					device_0.method_91(240, 463);
					device_0.method_121(10.0);
					device_0.method_69();
					flag = (device_0.method_11() ? true : false);
				}
			}
			return flag;
		}

		private void method_24(int int_41, int int_42, bool bool_18, string string_21)
		{
			Device device = null;
			string text = null;
			Class67 @class = null;
			Class51 class2 = null;
			Class73 class3 = null;
			Class68 class4 = null;
			Class61 class5 = null;
			int num = 0;
			string text2 = "";
			string text3 = "";
			string text4 = "";
			string text5 = "";
			string text6 = "";
			string text7 = "";
			string text8 = "";
			string text9 = "";
			string text10 = "";
			bool flag = false;
			bool flag2 = ((!(string_12.Substring(0, 1) == "0")) ? true : false);
			int num2 = 0;
			int num3 = 0;
			bool flag3 = false;
			bool flag4 = false;
			bool flag5 = false;
			int num4 = 0;
			method_52((int_41 + 1).ToString(), "cId", int_41, 0, dgvAcc);
			if (bool_0)
			{
				return;
			}
			while (true)
			{
				switch (int_9)
				{
				case 8:
					method_62(int_41, "Đang lấy Proxy ShopLike ...");
					if (int_36 == 1)
					{
						lock (object_5)
						{
							while (!bool_0)
							{
								class5 = null;
								while (!bool_0)
								{
									foreach (Class61 item in list_16)
									{
										if (class5 == null || item.int_1 < class5.int_1)
										{
											class5 = item;
											if (class5.int_1 != class5.int_2)
											{
												break;
											}
										}
									}
									if (class5.int_1 != class5.int_2)
									{
										break;
									}
								}
								if (bool_0)
								{
									break;
								}
								if (class5.int_1 > 0 || class5.method_1())
								{
									text2 = class5.proxy;
									if (text2 == "")
									{
										text2 = class5.method_3();
									}
									Class61 class16 = class5;
									class16.int_0++;
									class16 = class5;
									class16.int_1++;
									break;
								}
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...");
								break;
							}
							text3 = "(IP: " + text2.Split(':')[0] + ") ";
							if (ckCheckIP.Checked)
							{
								bool flag33 = true;
								method_62(int_41, text3 + "Check IP...");
								text4 = Common.smethod_35(text2, 0);
								if (text4 == "")
								{
									flag33 = false;
								}
								if (!flag33)
								{
									Class61 class16 = class5;
									class16.int_0--;
									class16 = class5;
									class16.int_1--;
									continue;
								}
							}
							method_52(text2, "proxy", int_41, 0, dgvAcc);
							goto default;
						}
					}
					lock (object_5)
					{
						while (!bool_0)
						{
							class5 = null;
							while (!bool_0)
							{
								foreach (Class61 item2 in list_16)
								{
									if (class5 == null || item2.int_1 < class5.int_1)
									{
										class5 = item2;
										if (class5.int_1 != class5.int_2)
										{
											break;
										}
									}
								}
								if (class5.int_1 != class5.int_2)
								{
									break;
								}
							}
							if (bool_0)
							{
								break;
							}
							if (class5.int_1 > 0 || class5.method_1())
							{
								text2 = class5.proxy;
								if (text2 == "")
								{
									text2 = class5.method_3();
								}
								Class61 class16 = class5;
								class16.int_0++;
								class16 = class5;
								class16.int_1++;
								break;
							}
						}
						if (bool_0)
						{
							method_62(int_41, text3 + "Dừng chạy...");
							break;
						}
						text3 = "(IP: " + text2.Split(':')[0] + ") ";
						if (ckCheckIP.Checked)
						{
							bool flag34 = true;
							method_62(int_41, text3 + "Check IP...");
							text4 = Common.smethod_35(text2, 0);
							if (text4 == "")
							{
								flag34 = false;
							}
							if (!flag34)
							{
								Class61 class16 = class5;
								class16.int_0--;
								class16 = class5;
								class16.int_1--;
								continue;
							}
						}
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
					}
				case 7:
					method_62(int_41, "Đang lấy TMProxy...");
					if (int_36 == 1)
					{
						lock (object_5)
						{
							while (!bool_0)
							{
								class4 = null;
								while (!bool_0)
								{
									foreach (Class68 item3 in list_15)
									{
										if (class4 == null || item3.int_1 < class4.int_1 || item3.next_change == 0)
										{
											class4 = item3;
											if (class4.int_1 != class4.int_2)
											{
												break;
											}
										}
									}
									if (class4.next_change > 0)
									{
										method_62(int_41, "Thời gian lấy Proxy kế tiếp: " + class4.next_change + " giây");
									}
									if (class4.int_1 != class4.int_2)
									{
										break;
									}
								}
								if (!bool_0)
								{
									if (class4.int_1 > 0 || class4.method_4())
									{
										text2 = class4.proxy;
										if (text2 == "")
										{
											text2 = class4.method_7();
										}
										Class68 class11 = class4;
										Class68 class12 = class11;
										class12.int_0++;
										class11 = class4;
										class12 = class11;
										class12.int_1++;
										break;
									}
									continue;
								}
								method_62(int_41, text3 + "Dừng chạy...");
								break;
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...");
								break;
							}
							text3 = "(IP: " + text2.Split(':')[0] + ") ";
							if (ckCheckIP.Checked)
							{
								bool flag31 = true;
								method_62(int_41, text3 + "Check IP...");
								text4 = Common.smethod_35(text2, 0);
								if (text4 == "")
								{
									flag31 = false;
								}
								if (!flag31)
								{
									Class68 class13 = class4;
									Class68 class12 = class13;
									class12.int_0--;
									class13 = class4;
									class12 = class13;
									class12.int_1--;
									continue;
								}
							}
							method_52(text2, "proxy", int_41, 0, dgvAcc);
							goto default;
						}
					}
					lock (object_5)
					{
						while (!bool_0)
						{
							class4 = null;
							while (!bool_0)
							{
								foreach (Class68 item4 in list_15)
								{
									if (class4 == null || item4.int_1 < class4.int_1)
									{
										class4 = item4;
										if (class4.int_1 != class4.int_2)
										{
											break;
										}
									}
								}
								if (class4.next_change > 0)
								{
									method_62(int_41, "Thời gian lấy Proxy kế tiếp: " + class4.next_change + " giây");
								}
								if (class4.int_1 != class4.int_2)
								{
									break;
								}
							}
							if (!bool_0)
							{
								if (class4.int_1 > 0 || class4.method_4())
								{
									text2 = class4.proxy;
									if (text2 == "")
									{
										text2 = class4.method_7();
									}
									Class68 class14 = class4;
									Class68 class12 = class14;
									class12.int_0++;
									class14 = class4;
									class12 = class14;
									class12.int_1++;
									break;
								}
								continue;
							}
							method_62(int_41, text3 + "Dừng chạy...");
							break;
						}
						if (bool_0)
						{
							method_62(int_41, text3 + "Dừng chạy...");
							break;
						}
						text3 = "(IP: " + text2.Split(':')[0] + ") ";
						if (ckCheckIP.Checked)
						{
							bool flag32 = true;
							method_62(int_41, text3 + "Check IP...");
							text4 = Common.smethod_35(text2, 0);
							if (text4 == "")
							{
								flag32 = false;
							}
							if (!flag32)
							{
								Class68 class15 = class4;
								Class68 class12 = class15;
								class12.int_0--;
								class15 = class4;
								class12 = class15;
								class12.int_1--;
								continue;
							}
						}
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
					}
				case 6:
					method_62(int_41, "Đang lấy Proxy...");
					if (int_36 == 1)
					{
						lock (object_5)
						{
							if (int_26 == 0)
							{
								while (!bool_0)
								{
									class3 = null;
									while (!bool_0)
									{
										foreach (Class73 item5 in list_14)
										{
											if (item5.bool_0 && (class3 == null || item5.int_2 < class3.int_2))
											{
												class3 = item5;
												if (class3.int_2 != class3.int_3)
												{
													break;
												}
											}
										}
										if (class3.int_2 != class3.int_3)
										{
											break;
										}
									}
									if (!bool_0)
									{
										if (!class3.bool_0 || (class3.int_2 <= 0 && !class3.method_2()))
										{
											class3.bool_0 = false;
											continue;
										}
										text2 = class3.string_1;
										num = class3.int_0;
										Class73 class19 = class3;
										Class73 class20 = class19;
										class20.int_1++;
										class19 = class3;
										class20 = class19;
										class20.int_2++;
										break;
									}
									method_62(int_41, text3 + "Dừng chạy!");
									break;
								}
							}
							else
							{
								while (!bool_0)
								{
									class3 = null;
									List<Class73> list5 = new List<Class73>();
									foreach (Class73 item6 in list_14)
									{
										if (item6.bool_0)
										{
											if (item6.int_2 < item6.int_3)
											{
												list5.Add(item6);
											}
											else if (item6.int_1 == 0)
											{
												item6.method_1();
												item6.int_2 = 0;
											}
										}
									}
									for (int num72 = 0; num72 < list5.Count; num72++)
									{
										if (list5[num72].method_4(0))
										{
											class3 = list5[num72];
											break;
										}
									}
									if (class3 != null)
									{
										text2 = class3.string_1;
										num = class3.int_0;
										Class73 class21 = class3;
										Class73 class20 = class21;
										class20.int_1++;
										class21 = class3;
										class20 = class21;
										class20.int_2++;
										break;
									}
								}
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy!");
								break;
							}
							text3 = "(IP: " + text2 + ") ";
							if (ckCheckIP.Checked)
							{
								bool flag35 = true;
								method_62(int_41, text3 + "Check IP...");
								text4 = Common.smethod_36(text2, num, int_27 * 60);
								if (text4 == "")
								{
									class3.bool_0 = false;
									flag35 = false;
								}
								if (!flag35)
								{
									Class73 class20 = class3;
									class20.int_1--;
									class20 = class3;
									class20.int_2--;
									continue;
								}
							}
							method_52(text2, "proxy", int_41, 0, dgvAcc);
							goto default;
						}
					}
					lock (object_5)
					{
						if (int_26 == 0)
						{
							while (!bool_0)
							{
								class3 = null;
								while (!bool_0)
								{
									foreach (Class73 item7 in list_14)
									{
										if (item7.bool_0 && (class3 == null || item7.int_2 < class3.int_2))
										{
											class3 = item7;
											if (class3.int_2 != class3.int_3)
											{
												break;
											}
										}
									}
									if (class3.int_2 != class3.int_3)
									{
										break;
									}
								}
								if (!bool_0)
								{
									if (!class3.bool_0 || (class3.int_2 <= 0 && !class3.method_2()))
									{
										class3.bool_0 = false;
										continue;
									}
									text2 = class3.string_1;
									num = class3.int_0;
									Class73 class20 = class3;
									class20.int_1++;
									class20 = class3;
									class20.int_2++;
									break;
								}
								method_62(int_41, text3 + "Dừng chạy!");
								break;
							}
						}
						else
						{
							while (!bool_0)
							{
								class3 = null;
								List<Class73> list6 = new List<Class73>();
								foreach (Class73 item8 in list_14)
								{
									if (item8.bool_0)
									{
										if (item8.int_2 < item8.int_3)
										{
											list6.Add(item8);
										}
										else if (item8.int_1 == 0)
										{
											item8.method_1();
											item8.int_2 = 0;
										}
									}
								}
								for (int num73 = 0; num73 < list6.Count; num73++)
								{
									if (list6[num73].method_4(0))
									{
										class3 = list6[num73];
										break;
									}
								}
								if (class3 != null)
								{
									text2 = class3.string_1;
									num = class3.int_0;
									Class73 class20 = class3;
									class20.int_1++;
									class20 = class3;
									class20.int_2++;
									break;
								}
							}
						}
						if (bool_0)
						{
							method_62(int_41, text3 + "Dừng chạy!");
							break;
						}
						text3 = "(IP: " + text2 + ") ";
						if (ckCheckIP.Checked)
						{
							bool flag36 = true;
							method_62(int_41, text3 + "Check IP...");
							text4 = Common.smethod_36(text2, num, int_27 * 60);
							if (text4 == "")
							{
								class3.bool_0 = false;
								flag36 = false;
							}
							if (!flag36)
							{
								Class73 class20 = class3;
								class20.int_1--;
								class20 = class3;
								class20.int_2--;
								continue;
							}
						}
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
					}
				case 3:
					method_62(int_41, "Đang lấy Api MinProxy...");
					class2 = null;
					flag = false;
					if (list_12.Count != 0)
					{
						lock (object_5)
						{
							while (true)
							{
								if (!bool_0)
								{
									if (bool_0)
									{
										break;
									}
									foreach (Class51 item9 in list_12)
									{
										if (item9.int_1 != 0)
										{
											if (class2 == null || item9.int_2 < class2.int_2)
											{
												class2 = item9;
											}
											continue;
										}
										class2 = item9;
										break;
									}
									if (class2.int_2 >= class2.int_3)
									{
										continue;
									}
								}
								if (class2 != null)
								{
									Class51 class17 = class2;
									Class51 class18 = class17;
									class18.int_1++;
									class17 = class2;
									class18 = class17;
									class18.int_2++;
									goto IL_11ec;
								}
								break;
							}
						}
						goto IL_13e9;
					}
					method_62(int_41, "Hết proxy rồi!!!.");
					break;
				case 2:
					method_62(int_41, "Đang lấy proxy Tinsoft...");
					if (int_36 == 1)
					{
						lock (object_5)
						{
							while (!bool_0)
							{
								@class = null;
								while (!bool_0)
								{
									foreach (Class67 item10 in list_5)
									{
										if (@class == null || item10.int_2 < @class.int_2 || item10.next_change == 0)
										{
											@class = item10;
											if (@class.int_2 != @class.int_3)
											{
												break;
											}
										}
									}
									if (@class.next_change > 0)
									{
										method_62(int_41, "Thời gian lấy Proxy kế tiếp: " + @class.next_change + " giây");
									}
									if (@class.int_2 != @class.int_3)
									{
										break;
									}
								}
								if (!bool_0)
								{
									if (@class.int_2 > 0 || @class.method_2())
									{
										text2 = @class.proxy;
										if (text2 == "")
										{
											text2 = @class.method_3();
										}
										Class67 class6 = @class;
										Class67 class7 = class6;
										class7.int_1++;
										class6 = @class;
										class7 = class6;
										class7.int_2++;
										break;
									}
									continue;
								}
								method_62(int_41, text3 + "Dừng chạy!");
								break;
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy", device);
								break;
							}
							text3 = "(IP: " + text2.Split(':')[0] + ") ";
							if (ckCheckIP.Checked)
							{
								bool flag8 = true;
								method_62(int_41, text3 + "Check IP...");
								text4 = Common.smethod_35(text2, 0);
								if (text4 == "")
								{
									flag8 = false;
								}
								if (!flag8)
								{
									Class67 class8 = @class;
									Class67 class7 = class8;
									class7.int_1--;
									class8 = @class;
									class7 = class8;
									class7.int_2--;
									continue;
								}
							}
							method_52(text2, "proxy", int_41, 0, dgvAcc);
							goto default;
						}
					}
					lock (object_5)
					{
						while (!bool_0)
						{
							@class = null;
							while (!bool_0)
							{
								foreach (Class67 item11 in list_5)
								{
									if (@class == null || item11.int_2 < @class.int_2)
									{
										@class = item11;
										if (@class.int_2 != @class.int_3)
										{
											break;
										}
									}
								}
								if (@class.next_change > 0)
								{
									method_62(int_41, "Thời gian lấy Proxy kế tiếp: " + @class.next_change + " giây");
								}
								if (@class.int_2 != @class.int_3)
								{
									break;
								}
							}
							if (!bool_0)
							{
								if (@class.int_2 > 0 || @class.method_2())
								{
									text2 = @class.proxy;
									if (text2 == "")
									{
										text2 = @class.method_3();
									}
									Class67 class9 = @class;
									Class67 class7 = class9;
									class7.int_1++;
									class9 = @class;
									class7 = class9;
									class7.int_2++;
									break;
								}
								continue;
							}
							method_62(int_41, text3 + "Dừng chạy!");
							break;
						}
						if (bool_0)
						{
							method_62(int_41, text3 + "Dừng chạy", device);
							break;
						}
						text3 = "(IP: " + text2.Split(':')[0] + ") ";
						if (ckCheckIP.Checked)
						{
							bool flag9 = true;
							method_62(int_41, text3 + "Check IP...");
							text4 = Common.smethod_35(text2, 0);
							if (text4 == "")
							{
								flag9 = false;
							}
							if (!flag9)
							{
								Class67 class10 = @class;
								Class67 class7 = class10;
								class7.int_1--;
								class10 = @class;
								class7 = class10;
								class7.int_2--;
								continue;
							}
						}
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
					}
				case 5:
					method_62(int_41, "Lấy proxy từ danh sách...");
					if (int_36 == 1)
					{
						if (queue_0.Count == 0)
						{
							queue_0 = new Queue<string>(list_13);
						}
						text2 = queue_0.Dequeue();
						if (text2 != "")
						{
							text3 = "(IP: " + text2.Split(':')[0] + ") ";
						}
						if (ckCheckIP.Checked)
						{
							method_62(int_41, text3 + "Check IP...");
							bool flag6 = false;
							int num5 = 0;
							while (true)
							{
								if (num5 < 5)
								{
									if (!bool_0)
									{
										Common.smethod_62(1.0);
										text4 = Common.smethod_35(text2, int_35);
										if (!(text4 != ""))
										{
											if (bool_0)
											{
												break;
											}
											num5++;
											continue;
										}
										flag6 = true;
									}
									else
									{
										method_62(int_41, text3 + "Dừng chạy...", device);
									}
								}
								if (!flag6)
								{
									goto IL_1a83;
								}
								goto IL_1ac3;
							}
							break;
						}
						goto IL_1ac3;
					}
					lock (object_5)
					{
						if (queue_0.Count == 0)
						{
							break;
						}
						text2 = queue_0.Dequeue();
						if (text2 != "")
						{
							text3 = "(IP: " + text2.Split(':')[0] + ") ";
						}
						if (!ckCheckIP.Checked)
						{
							goto IL_1c28;
						}
						method_62(int_41, text3 + "Check IP...");
						bool flag7 = false;
						int num6 = 0;
						while (true)
						{
							if (num6 < 5)
							{
								if (!bool_0)
								{
									Common.smethod_62(1.0);
									text4 = Common.smethod_35(text2, int_35);
									if (!(text4 != ""))
									{
										if (!bool_0)
										{
											num6++;
											continue;
										}
										break;
									}
									flag7 = true;
								}
								else
								{
									method_62(int_41, text3 + "Dừng chạy...", device);
								}
							}
							if (!flag7)
							{
								if (text2 != "")
								{
									method_62(int_41, text3 + "Không thể kết nối proxy!");
								}
								else
								{
									method_62(int_41, text3 + "Không có kết nối Internet!");
								}
								break;
							}
							goto IL_1c28;
						}
						goto end_IL_1ae8;
						IL_1c28:
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
						end_IL_1ae8:;
					}
					break;
				case 9:
					method_62(int_41, "Đang lấy Proxy free ...");
					lock (object_5)
					{
						if (bool_0)
						{
							method_62(int_41, text3 + "Dừng chạy!");
							break;
						}
						text2 = Common.smethod_85(int_40);
						if (text2 == "")
						{
							method_62(int_41, "Đã hết proxy free... Vui lòng chọn loại khác");
							break;
						}
						text3 = "(IP: " + text2.Split(':')[0] + ") ";
						method_52(text2, "proxy", int_41, 0, dgvAcc);
						goto default;
					}
				default:
					{
						try
						{
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...", device);
								break;
							}
							if (bool_18)
							{
								method_22(int_41, "cDevice", int_42.ToString());
								device = new Device(string_21, int_42.ToString() ?? "", string_18);
								goto IL_1f3e;
							}
							string text11 = method_1(int_41, "cDevice");
							if (text11 == "" || !Directory.Exists(string_21 + "\\vms\\leidian" + text11))
							{
								if (bool_0)
								{
									method_62(int_41, text3 + "Dừng chạy...", device);
									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
									break;
								}
								method_62(int_41, text3 + "Tạo thiết bị, chờ đến lượt...", device);
								object obj = object_3;
								lock (obj)
								{
									method_62(int_41, text3 + "Tạo thiết bị...", device);
									List<string> second = Class2.smethod_31(string_21);
									Class2.smethod_29(string_21);
									int num7 = 0;
									while (true)
									{
										if (num7 >= 30)
										{
											goto IL_1e63;
										}
										if (!bool_0)
										{
											text11 = Class2.smethod_31(string_21).Except(second).First();
											if (!(text11 != ""))
											{
												num7++;
												continue;
											}
											goto IL_1e63;
										}
										method_62(int_41, text3 + "Dừng chạy...", device);
										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
										goto end_IL_1d06;
										IL_1e63:
										if (text11 == "")
										{
											method_62(int_41, text3 + "Tạo thiết bị thất bại!");
											method_49("Tạo LD thất bại", device.int_0, int_41, int_42, device, bool_18: false);
											goto end_IL_1928;
										}
										break;
									}
								}
								device = new Device(string_21, text11, string_18);
								device.PathLDPlayer = string_21;
								method_22(int_41, "cDevice", text11);
								method_62(int_41, text3 + "Cấu hình LDPlayer...");
								device.method_117();
								device.method_116();
								goto IL_1f3e;
							}
							device = new Device(string_21, text11 ?? "", string_18);
							goto IL_1f3e;
							IL_1f3e:
							device.method_117();
							device.method_116();
							method_62(int_41, text3 + "Chờ đến lượt...");
							object obj2 = object_2;
							lock (obj2)
							{
								if (int_2 == 0)
								{
									do
									{
										if (bool_9)
										{
											Common.smethod_62(0.5);
											continue;
										}
										bool_9 = true;
										break;
									}
									while (!bool_0);
								}
								else if (int_18 > 0)
								{
									int num8 = random_0.Next(int_3, int_4);
									if (num8 > 0)
									{
										int tickCount = Environment.TickCount;
										while ((Environment.TickCount - tickCount) / 1000 - num8 < 0)
										{
											method_62(int_41, text3 + "Mở thiê\u0301t bi\u0323 sau {time}s...".Replace("{time}", (num8 - (Environment.TickCount - tickCount) / 1000).ToString()));
											Common.smethod_62(0.5);
											if (!bool_0)
											{
												continue;
											}
											method_62(int_41, text3 + "Dừng chạy...", device);
											goto end_IL_1d06;
										}
									}
								}
								else
								{
									int_18++;
								}
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...");
								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							method_62(int_41, text3 + "Mở thiết bị...");
							device.method_118();
							if (device.process == null)
							{
								method_62(int_41, text3 + "Lỗi mở thiết bị");
								method_49("Lỗi mở LD", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...", device);
								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							text8 = device.method_114();
							frmViewLD.frmViewLD_0.method_9(device.process.MainWindowHandle, device.int_0, int_41 + 1, text8);
							if (!device.method_11())
							{
								method_62(int_41, text3 + "Lỗi mở thiết bị");
								method_49("Lỗi mở LD", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							method_62(int_41, text3 + "Mở thiết bị thành công", device);
							list_4.Add(device);
							method_51(5.0);
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...", device);
								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							text = (device.DeviceId = Class2.smethod_36(device.int_0));
							device.list_0 = device.method_108();
							bool flag10 = true;
							try
							{
								if (bool_0)
								{
									method_62(int_41, text3 + "Dừng chạy...", device);
									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
									break;
								}
								method_62(int_41, text3 + "Kiểm tra App cần cài đặt", device);
								if (Settings.Default.typeRunApp == 0)
								{
									if (device.list_0.Contains("com.facebook.katana"))
									{
										goto IL_2311;
									}
									method_62(int_41, text3 + "Cài đặt App Facebook Katana...", device);
									while (true)
									{
										if (!bool_0)
										{
											flag10 = false;
											if (!(flag10 = device.method_109(Class25.smethod_0() + "\\app\\facebook.apk")))
											{
												continue;
											}
											goto IL_2311;
										}
										method_62(int_41, text3 + "Dừng chạy...", device);
										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
										break;
									}
									break;
								}
								if (device.list_0.Contains("com.facebook.lite"))
								{
									goto IL_2413;
								}
								method_62(int_41, text3 + "Cài đặt App Facebook Lite...", device);
								while (true)
								{
									if (!bool_0)
									{
										flag10 = false;
										if (!(flag10 = device.method_109(Class25.smethod_0() + "\\app\\facebooklite.apk")))
										{
											continue;
										}
										goto IL_2413;
									}
									method_62(int_41, text3 + "Dừng chạy...", device);
									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
									break;
								}
								goto end_IL_2237;
								IL_2311:
								if (!device.list_0.Contains("com.android.adbkeyboard"))
								{
									method_62(int_41, text3 + "Cài đặt App Keyboard...", device);
									while (true)
									{
										if (!bool_0)
										{
											flag10 = false;
											if (!(flag10 = device.method_109(Class25.smethod_0() + "\\app\\ADBKeyboard.apk")))
											{
												continue;
											}
											goto IL_24d0;
										}
										method_62(int_41, text3 + "Dừng chạy...", device);
										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
										break;
									}
									break;
								}
								goto IL_24d0;
								IL_2413:
								if (device.list_0.Contains("cz.october.app"))
								{
									goto IL_2491;
								}
								method_62(int_41, text3 + "Cài đặt App Keyboard...", device);
								while (true)
								{
									if (!bool_0)
									{
										flag10 = false;
										if (!(flag10 = device.method_109(Class25.smethod_0() + "\\app\\keyboard.apk")))
										{
											continue;
										}
										goto IL_2491;
									}
									method_62(int_41, text3 + "Dừng chạy...", device);
									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
									break;
								}
								goto end_IL_2237;
								IL_2491:
								device.method_46("shell ime set cz.october.app/.KeyboardReceiver");
								goto IL_24d0;
								end_IL_2237:;
							}
							catch
							{
								method_62(int_41, text3 + "Cài đặt các ứng dụng không thành công", device);
								method_49("Cài đặt các ứng dụng không thành công", device.int_0, int_41, int_42, device, bool_18: false);
							}
							goto end_IL_1d06;
							IL_2876:
							if (text10 != "")
							{
								method_62(int_41, text3 + "Lỗi treo LD khi kết nối proxy");
								method_49("Lỗi treo LD khi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							if (Settings.Default.typeRunApp == 0)
							{
								while (true)
								{
									IL_909d:
									method_62(int_41, text3 + "Mở App Facebook Katana", device);
									device.method_39();
									try
									{
										if (bool_0)
										{
											method_62(int_41, text3 + "Dừng chạy...", device);
											method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
											break;
										}
										if (device.method_95())
										{
											string text13 = string.Empty;
											bool flag11 = true;
											if (!rdThuePhone.Checked || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "2")
											{
											}
											method_62(int_41, text3 + "Đăng ký Facebook Katana", device);
											for (int i = 0; i < 20; i++)
											{
												if (device.method_91(158, 415))
												{
													flag11 = true;
													break;
												}
											}
											if (!flag11)
											{
												method_62(int_41, text3 + "Lỗi khi đăng ký", device);
												method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											if (bool_0)
											{
												method_62(int_41, text3 + "Dừng chạy...");
												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											int num9 = 0;
											while (true)
											{
												if (num9 < 30)
												{
													text13 = device.method_93();
													if (device.method_120(text13).Count == 1)
													{
														num9++;
														continue;
													}
													if (device.method_82("join facebook", text13) || device.method_82("tham gia facebook", text13))
													{
														if (bool_0)
														{
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														flag11 = true;
														if (device.method_82("\"next\"", text13))
														{
															device.method_99("\"next\"");
														}
														else
														{
															device.method_99("\"tiếp\"");
														}
													}
													else
													{
														flag11 = false;
													}
												}
												if (!flag11)
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...");
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												method_62(int_41, text3 + "Tạo thông tin đăng ký", device);
												string text14 = "";
												string text15 = "";
												string text16 = "";
												string text17 = "";
												string text18 = "";
												string text19 = "";
												string text20 = "";
												string text21 = "";
												string text22 = "";
												string text23 = "";
												string text24 = "";
												string text25 = "";
												string text26 = "";
												string[] array = new string[11]
												{
													"thg 1", "thg 2", "thg 3", "thg 4", "thg 5", "thg 6", "thg 7", "thg 8", "thg 10", "thg 11",
													"thg 12"
												};
												string text27 = random_0.Next(0, 2).ToString();
												string text28 = "";
												string text29 = "";
												if (int_13 == 0)
												{
													text27 = "0";
												}
												else if (int_13 == 1)
												{
													text27 = "1";
												}
												if (int_12 == 0)
												{
													text14 = method_6();
													text15 = ((!(text27 == "0")) ? method_7() : method_8());
												}
												else if (int_12 == 1)
												{
													text14 = method_3();
													text15 = ((!(text27 == "0")) ? method_5() : method_4());
												}
												else if (int_12 == 2)
												{
													text14 = method_9();
													text15 = ((!(text27 == "0")) ? method_10() : method_11());
													text28 = method_3();
													text29 = ((!(text27 == "0")) ? method_5() : method_4());
												}
												text16 = ((int_12 == 2) ? ((!bool_5) ? string_14.Trim() : Common.smethod_75(text29 + text28)) : ((!bool_5) ? string_14.Trim() : Common.smethod_75(text15 + text14)));
												text24 = random_0.Next(1, 28).ToString();
												text25 = array[random_0.Next(0, 11)].ToString();
												text26 = random_0.Next(Convert.ToInt32(DateTime.Now.Year.ToString()) - int_16, Convert.ToInt32(DateTime.Now.Year.ToString()) - int_15).ToString();
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												method_52(text14, "ho", int_41, 0, dgvAcc);
												method_52(text15, "ten", int_41, 0, dgvAcc);
												method_52((text27 == "1") ? "Nam" : "Nữ", "gender", int_41, 0, dgvAcc);
												method_52(text16, "pass", int_41, 0, dgvAcc);
												method_52((Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(text26)).ToString(), "age", int_41, 0, dgvAcc);
												text17 = string_11;
												if (bool_16)
												{
													text17 = string_20;
												}
												try
												{
													for (int j = 0; j < 5; j++)
													{
														if (!bool_0)
														{
															text13 = device.method_93();
															if (device.method_120(text13).Count == 1)
															{
																continue;
															}
															if (device.method_82("enter the name you use in real life.", text13) || device.method_82("nhập tên bạn sử dụng trong đời thực", text13))
															{
																flag11 = true;
																if (device.method_82("nhập tên bạn sử dụng trong đời thực", text13))
																{
																	method_62(int_41, text3 + "Nhập họ", device);
																	device.method_100(text14);
																	device.method_121(1.0);
																	method_62(int_41, text3 + "Nhập tên...", device);
																	device.method_121(1.0);
																	if (device.method_82("\"last name\"", text13))
																	{
																		device.method_99("\"last name\"", text13);
																	}
																	else if (device.method_52("DataClick\\image\\ten"))
																	{
																		device.method_3("DataClick\\image\\ten");
																	}
																	else
																	{
																		ADBHelper.TapByPercent(text, 59.5, 42.9);
																	}
																	device.method_121(1.0);
																	device.method_100(text15);
																	break;
																}
																method_62(int_41, text3 + "Nhập tên", device);
																device.method_121(1.0);
																device.method_100(text15);
																device.method_121(1.0);
																method_62(int_41, text3 + "Nhập họ...", device);
																device.method_121(1.0);
																if (device.method_82("\"last name\"", text13))
																{
																	device.method_99("\"last name\"", text13);
																}
																else if (device.method_52("DataClick\\image\\ten"))
																{
																	device.method_3("DataClick\\image\\ten");
																}
																else
																{
																	ADBHelper.TapByPercent(text, 59.5, 42.9);
																}
																device.method_121(1.0);
																device.method_100(text14);
															}
															else
															{
																flag11 = false;
															}
															break;
														}
														method_62(int_41, text3 + "Dừng chạy...");
														method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
														goto end_IL_2a36;
													}
												}
												catch
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (!flag11)
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												device.method_121(1.0);
												if (device.method_82("\"next\""))
												{
													device.method_99("\"next\"");
												}
												else
												{
													device.method_99("\"tiếp\"");
												}
												try
												{
													method_62(int_41, text3 + "Chọn ngày tháng năm sinh...", device);
													int num10 = 0;
													while (true)
													{
														if (num10 < 10)
														{
															text13 = device.method_93();
															if (!device.method_82("sinh nhật của bạn khi nào?", text13))
															{
																flag11 = false;
																num10++;
																continue;
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...");
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																break;
															}
															flag11 = true;
															if (device.method_82("\"select birthday\"", text13))
															{
																device.method_99("\"select birthday\"", text13);
															}
															else if (device.method_82("\"chọn ngày sinh\"", text13))
															{
																device.method_99("\"chọn ngày sinh\"", text13);
															}
															else
															{
																ADBHelper.TapByPercent(text, 49.8, 41.0);
															}
															device.method_121(1.0);
														}
														if (flag11)
														{
															device.method_91(108, 247);
															device.method_100(text24);
															device.method_121(1.0);
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																break;
															}
															device.method_7(156, 246);
															device.method_100(text25);
															device.method_121(1.0);
															device.method_91(206, 247);
															device.method_100(text26);
															device.method_121(1.0);
															device.method_99("\"ok\"", "", 10);
															device.method_121(1.0);
															if (device.method_82("\"next\"", text13))
															{
																device.method_99("\"next\"", "", 10);
															}
															else
															{
																device.method_99("\"tiếp\"", "", 10);
															}
															flag11 = true;
														}
														goto IL_3513;
													}
												}
												catch
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
												}
												break;
												IL_3513:
												if (!flag11)
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												try
												{
													for (int k = 0; k < 10; k++)
													{
														text13 = device.method_93();
														if (device.method_120(text13).Count == 1)
														{
															continue;
														}
														if (device.method_82("what's your gender?", text13) || device.method_82("giới tính của bạn là gì?", text13))
														{
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_2a36;
															}
															method_62(int_41, text3 + "Chọn giới tính...", device);
															if (text27 == "0")
															{
																device.method_91(38, 183);
															}
															else if (text27 == "1")
															{
																device.method_91(30, 223);
															}
															flag11 = true;
															device.method_121(1.0);
															if (device.method_82("\"next\"", text13))
															{
																device.method_99("\"next\"", "", 10);
															}
															else
															{
																device.method_99("\"tiếp\"", "", 10);
															}
														}
														else
														{
															flag11 = false;
														}
														break;
													}
												}
												catch
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (!flag11)
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													flag11 = false;
													break;
												}
												while (true)
												{
													IL_3756:
													try
													{
														for (int l = 0; l < 10; l++)
														{
															text13 = device.method_93();
															if (device.method_120(text13).Count == 1)
															{
																continue;
															}
															if (!device.method_82("enter your mobile number", text13) && !device.method_82("nhập số di động của bạn", text13) && !device.method_82("nhập địa chỉ email của bạn", text13))
															{
																flag11 = false;
																continue;
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...");
																flag11 = false;
																break;
															}
															if (string_12.Substring(0, 1) == "0")
															{
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	flag11 = false;
																	break;
																}
																if (string_12.Substring(1, 1) == "0")
																{
																	if (bool_0)
																	{
																		method_62(int_41, text3 + "Dừng chạy...");
																		flag11 = false;
																		break;
																	}
																	method_62(int_41, text3 + "Đang tạo số điện thoại ảo....", device);
																	if (device.method_52("DataClick\\image\\x"))
																	{
																		device.method_3("DataClick\\image\\x");
																	}
																	else
																	{
																		device.method_91(295, 209);
																	}
																	text23 = method_72(int_21);
																	if (text23 == string.Empty)
																	{
																		method_62(int_41, text3 + "Không tạo được số điện thoại ảo...", device);
																		flag11 = false;
																		return;
																	}
																	method_51(2.0);
																	flag11 = true;
																	method_62(int_41, text3 + "Số điện thoại ảo:" + text23, device);
																	method_52(text23, "phone", int_41, 0, dgvAcc);
																	device.method_100(text23);
																	flag2 = false;
																	break;
																}
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																if (device.method_82("\"đăng ký bằng địa chỉ email\"", null, 10.0))
																{
																	device.method_99("\"đăng ký bằng địa chỉ email\"", "", 10);
																}
																else if (device.method_82("\"sign up with email address\"", null, 10.0))
																{
																	device.method_99("\"sign up with email address\"", "", 10);
																}
																if (Convert.ToInt32(string_12.Substring(2, 1)) != 3)
																{
																	method_62(int_41, text3 + "Đang tạo Email ảo....", device);
																	text22 = method_76(text15, text14, Convert.ToInt32(string_12.Substring(2, 1)));
																}
																else
																{
																	method_62(int_41, text3 + "Đang lấy mail từ Temp-mail.io....", device);
																	string text30 = method_73();
																	text22 = Common.smethod_19(text30);
																}
																if (text22 == string.Empty)
																{
																	method_62(int_41, text3 + "Không tạo được email ảo...", device);
																	method_49("Không tạo được email ảo", device.int_0, int_41, int_42, device, bool_18: false);
																	flag11 = false;
																}
																else
																{
																	method_51(2.0);
																	flag11 = true;
																	method_62(int_41, text3 + "Email ảo:" + text22, device);
																	method_52(text22, "email", int_41, 0, dgvAcc);
																	device.method_100(text22);
																}
																break;
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																flag11 = false;
																break;
															}
															if (rdThuePhone.Checked)
															{
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	flag11 = false;
																	break;
																}
																try
																{
																	if (bool_0)
																	{
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		flag11 = false;
																		break;
																	}
																	int num11 = 0;
																	while (true)
																	{
																		if (num11 != 2)
																		{
																			method_62(int_41, text3 + "Đang lấy số điện thoại....", device);
																			if (device.method_52("DataClick\\image\\x"))
																			{
																				device.method_3("DataClick\\image\\x");
																			}
																			else
																			{
																				device.method_91(295, 209);
																			}
																			if (string_12.Substring(2, 1) == "0")
																			{
																				text5 = Common.smethod_47(text17, ref text18);
																			}
																			else if (string_12.Substring(2, 1) == "1")
																			{
																				text5 = Common.smethod_57(text17, ref text18);
																			}
																			else if (string_12.Substring(2, 1) == "2")
																			{
																				text5 = Common.smethod_21(text17, ref text18);
																			}
																			else if (string_12.Substring(2, 1) == "3")
																			{
																				text5 = Common.smethod_48(text17);
																				text9 = text5;
																			}
																			else if (string_12.Substring(2, 1) == "4")
																			{
																				text5 = Common.smethod_22(text17, ref text18);
																			}
																			else if (string_12.Substring(2, 1) == "5")
																			{
																				text5 = Common.smethod_23(text17, ref text18);
																			}
																			else if (string_12.Substring(2, 1) == "6")
																			{
																				text5 = Common.smethod_24(text17, ref text18);
																			}
																			if (!bool_0)
																			{
																				if (text5 == "")
																				{
																					num11++;
																					method_62(int_41, text3 + "Không lấy được số điện thoại. Lấy số khác!!!", device);
																					device.method_121(2.0);
																					continue;
																				}
																				if (text5 == "Đã hết số điện thoại, chờ cập nhật" && string_12.Substring(2, 1) == "3")
																				{
																					method_62(int_41, text3 + "Đã hết số điện thoại...", device);
																					flag11 = false;
																					break;
																				}
																				if (text5 == "API sai" && string_12.Substring(2, 1) == "3")
																				{
																					method_62(int_41, text3 + "API sai. Kiểm tra lại API key..", device);
																					flag11 = false;
																					break;
																				}
																				if (bool_0)
																				{
																					method_62(int_41, text3 + "Dừng chạy...", device);
																					flag11 = false;
																					break;
																				}
																				if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
																				{
																					text5 = "+84" + text5;
																				}
																				if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "4")
																				{
																					text5 = "+1" + text5;
																				}
																				method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																				method_52(text5, "phone", int_41, 0, dgvAcc);
																				device.method_100(text5);
																				flag2 = true;
																				goto IL_4cf7;
																			}
																			method_62(int_41, text3 + "Dừng chạy...");
																			method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																			goto end_IL_3756;
																		}
																		flag11 = false;
																		method_62(int_41, text3 + "Đã hết số điện thoại", device);
																		break;
																	}
																}
																catch
																{
																	method_62(int_41, text3 + "Lỗi khi lấy số điện thoại", device);
																	flag11 = false;
																}
																break;
															}
															if (!rdConfMail.Checked)
															{
																break;
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...");
																flag11 = false;
																break;
															}
															if (num4 == 0)
															{
																if (device.method_82("\"đăng ký bằng địa chỉ email\"", "", 10.0))
																{
																	device.method_99("\"đăng ký bằng địa chỉ email\"", "", 10);
																}
																else if (device.method_82("\"sign up with email address\"", "", 10.0))
																{
																	device.method_99("\"sign up with email address\"", "", 10);
																}
															}
															string text31 = string_12.Substring(2, 1);
															int num12 = 0;
															if (text31 == null)
															{
																break;
															}
															if (!(text31 == "0"))
															{
																if (!(text31 == "1"))
																{
																	method_62(int_41, text3 + "Đang lấy TempMail...", device);
																	while (true)
																	{
																		string text32 = method_73();
																		string text33 = Common.smethod_19(text32);
																		if (!(text33 != ""))
																		{
																			if (num12 != 5)
																			{
																				num12++;
																				continue;
																			}
																			method_62(int_41, text3 + "Lỗi không lấy được tempmail...", device);
																			flag11 = false;
																			goto end_IL_37d2;
																		}
																		method_52(text33, "email", int_41, 0, dgvAcc);
																		flag2 = true;
																		device.method_100(text33);
																		device.method_121(1.0);
																		if (num4 == 0)
																		{
																			break;
																		}
																		if (device.method_82("\"next\""))
																		{
																			device.method_99("\"next\"", "", 10);
																		}
																		else
																		{
																			device.method_99("\"tiếp\"", "", 10);
																		}
																		goto IL_4ccc;
																	}
																}
																else
																{
																	string text34 = list_1[int_41];
																	if (!(text34 != ""))
																	{
																		break;
																	}
																	method_62(int_41, text3 + "Nhập hotmail có sẵn....", device);
																	text6 = text34.Split('|')[0];
																	text7 = text34.Split('|')[1];
																	if (bool_0)
																	{
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_3756;
																	}
																	method_52(text6, "email", int_41, 0, dgvAcc);
																	method_52(text7, "passMail", int_41, 0, dgvAcc);
																	device.method_100(text6);
																	flag2 = true;
																	device.method_121(1.0);
																}
															}
															else
															{
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...");
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																method_51(2.0);
																method_62(int_41, text3 + "Đăng ký hotmail....", device);
																while (!method_85(int_41))
																{
																	method_52("Đang tạo lại mail khác", "status", int_41, 0, dgvAcc);
																	flag11 = false;
																}
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	flag11 = false;
																	break;
																}
																text6 = method_39(int_41);
																text7 = method_40(int_41);
																File.AppendAllText("output/facebook/hotmail.txt", string.Concat(new string[4]
																{
																	text6,
																	"|",
																	text7,
																	Environment.NewLine
																}));
																device.method_100(text6);
																flag2 = true;
																device.method_121(1.0);
															}
															goto IL_4cf7;
															continue;
															end_IL_37d2:
															break;
														}
													}
													catch
													{
														method_62(int_41, text3 + "Tạo tài khoản thất bại", device);
														method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													if (!flag11)
													{
														method_62(int_41, text3 + "Tạo tài khoản thất bại", device);
														method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													goto IL_4cf7;
													IL_4cf7:
													if (!bool_0)
													{
														if (device.method_82("\"next\""))
														{
															device.method_99("\"next\"", "", 10);
														}
														else
														{
															device.method_99("\"tiếp\"", "", 10);
														}
														try
														{
															for (int m = 0; m < 5; m++)
															{
																text13 = device.method_93();
																if (device.method_120(text13).Count == 1)
																{
																	continue;
																}
																if (device.method_82("choose a password", text13) || device.method_82("chọn mật khẩu", text13))
																{
																	if (bool_0)
																	{
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_3756;
																	}
																	flag11 = true;
																	method_62(int_41, text3 + "Nhập mật khẩu...", device);
																	device.method_102(text16.Trim());
																	device.method_121(1.0);
																	if (device.method_82("\"next\""))
																	{
																		device.method_99("\"next\"", "", 10);
																	}
																	else
																	{
																		device.method_99("\"tiếp\"", "", 10);
																	}
																}
																else
																{
																	flag11 = false;
																}
																break;
															}
														}
														catch
														{
															method_62(int_41, text3 + "Lỗi khi đăng ký", device);
															method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														if (flag11)
														{
															if (!bool_0)
															{
																int num13 = 0;
																while (true)
																{
																	if (num13 < 5)
																	{
																		text13 = device.method_93();
																		if (device.method_120(text13).Count == 1)
																		{
																			num13++;
																			continue;
																		}
																		if (device.method_82("finish signing up", text13) || device.method_82("hoàn tất đăng ký", text13))
																		{
																			if (bool_0)
																			{
																				method_62(int_41, text3 + "Dừng chạy...", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_3756;
																			}
																			flag11 = true;
																			method_62(int_41, text3 + "Đăng ký...", device);
																			device.method_121(2.0);
																			if (device.method_82("\"sign up\""))
																			{
																				device.method_99("\"sign up\"");
																			}
																			else
																			{
																				device.method_99("\"đăng ký\"");
																			}
																		}
																		else
																		{
																			flag11 = false;
																		}
																	}
																	if (flag11)
																	{
																		if (!bool_0)
																		{
																			break;
																		}
																		method_62(int_41, text3 + "Dừng chạy...");
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	}
																	else
																	{
																		method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																		method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																	}
																	goto end_IL_3756;
																}
																goto IL_4ccc;
															}
															method_62(int_41, text3 + "Dừng chạy...");
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "Lỗi khi đăng ký", device);
														method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													method_62(int_41, text3 + "Dừng chạy...");
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
													IL_4ccc:
													while (true)
													{
														IL_4ccc_2:
														device.method_121(1.0);
														method_62(int_41, text3 + "Check status đăng ký...", device);
														int num14 = 0;
														try
														{
															while (true)
															{
																if (!bool_0)
																{
																	if (num14 != 30)
																	{
																		num14++;
																		text13 = device.method_93();
																		if (device.method_120(text13).Count == 1)
																		{
																			continue;
																		}
																		if (!bool_0)
																		{
																			if (device.method_82("bạn đã có tài khoản facebook chưa?", text13) || device.method_82("do you already have a facebook account?", text13))
																			{
																				if (device.method_82("no, create new account", text13))
																				{
																					device.method_99("no, create new account", "", 10);
																				}
																				else
																				{
																					device.method_99("không, tạo tài khoản mới", "", 10);
																				}
																				goto IL_4ccc_2;
																			}
																			if (device.method_82("use a different name", text13) || device.method_82("chọn tên của bạn", text13) || device.method_82("bạn tên gì?", text13))
																			{
																				flag11 = false;
																				method_62(int_41, text3 + "Trùng tên...thực hiện đăng ký lại", device);
																				device.method_70();
																				device.method_121(1.0);
																				goto end_IL_4ccc;
																			}
																			if (!device.method_82("next time, log in with one tap", text13) && !device.method_82("lần sau, đăng nhập bằng một lần nhấn", text13))
																			{
																				if (device.method_82("enter your mobile number", text13) || device.method_82("nhập số di động của bạn", text13))
																				{
																					method_62(int_41, text3 + "Lỗi xác nhận số điện thoại. Tạo lại...", device);
																					device.method_70();
																					device.method_121(1.0);
																					goto end_IL_4ccc;
																				}
																				if (!device.method_82("do you already have a facebook account?", text13) && !device.method_82("bạn đã có tài khoản facebook chưa?", text13))
																				{
																					if (!device.method_82("the action attempted has been deemed abusive or is otherwise disallowed", text13) && !device.method_82("an unknown error occurred", text13) && !device.method_82("we couldn't create your account", text13) && !device.method_82("chúng tôi không thể tạo tài khoản của bạn", text13) && !device.method_82("một lỗi không xác định đã xảy ra", text13) && !device.method_82("hành động đã cố gắng bị coi là lạm dụng hoặc không được phép", text13) && !device.method_82("gần đây số điện thoại bạn đang cố gắng xác minh đã được sử dụng để xác minh một tài khoản khác. Vui lòng thử số khác.", text13))
																					{
																						if (device.method_82("we need more information", text13) || device.method_82("Something went wrong. Please try again.", text13) || device.method_82("chúng tôi cần thêm thông tin", text13))
																						{
																							if (Settings.Default.isThuVeriCheckPoint)
																							{
																								method_62(int_41, text3 + "Checkpoint...thử xác nhận", device);
																								flag3 = true;
																								goto IL_4e67;
																							}
																							method_62(int_41, text3 + "Checkpoint 282. Lưu acc...", device);
																							flag5 = true;
																							method_42(int_41, "Checkpoint");
																							goto IL_738b;
																						}
																						if (!device.method_82("there was an issue with your connection. check the following and try again.", text13) && !device.method_82("đã xảy ra lỗi", text13) && !device.method_82("đã xảy ra sự cố với kết nối của bạn. hãy kiểm tra những vấn đề sau và thử lại:", text13))
																						{
																							if (!device.method_52("DataClick\\image\\siginfail"))
																							{
																								if (!device.method_82("vui lòng nhập địa chỉ email hợp lệ.", text13))
																								{
																									if (device.method_82("tên hoặc họ trên facebook không được quá ngắn", text13))
																									{
																										flag11 = false;
																										method_62(int_41, text3 + "Lỗi khi đăng ký. Thực hiện đăng ký lại", device);
																										device.method_70();
																										device.method_121(1.0);
																										goto end_IL_4ccc;
																									}
																									if (!device.method_82("mất kết nối", text13))
																									{
																										continue;
																									}
																									flag11 = false;
																									method_62(int_41, text3 + "Lỗi mất kết nối", device);
																								}
																								else
																								{
																									if (num4 != 5)
																									{
																										method_62(int_41, text3 + "Lấy mail khác...lần " + (num4 + 1), device);
																										device.method_121(1.0);
																										if (device.method_52("DataClick\\image\\x"))
																										{
																											device.method_3("DataClick\\image\\x");
																										}
																										else
																										{
																											device.method_91(295, 209);
																										}
																										num4++;
																										goto IL_3756;
																									}
																									method_62(int_41, text3 + "Lỗi email không hợp lệ", device);
																									flag11 = false;
																								}
																							}
																							else
																							{
																								flag11 = false;
																								method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																							}
																						}
																						else
																						{
																							flag11 = false;
																							method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																						}
																					}
																					else if (bool_0)
																					{
																						method_62(int_41, text3 + "Dừng chạy...");
																						flag11 = false;
																					}
																					else
																					{
																						flag11 = false;
																						method_62(int_41, text3 + "Lỗi khi đăng ký. Thử lại sau", device);
																					}
																				}
																				else
																				{
																					if (!bool_0)
																					{
																						if (device.method_82("không, tạo tài khoản mới", text13))
																						{
																							device.method_99("không, tạo tài khoản mới", text13, 10);
																						}
																						else if (device.method_82("no, create new account", text13))
																						{
																							device.method_99("no, create new account", text13, 10);
																						}
																						goto IL_4ccc_2;
																					}
																					method_62(int_41, text3 + "Dừng chạy...", device);
																					flag11 = false;
																				}
																			}
																			else
																			{
																				flag11 = true;
																				method_62(int_41, text3 + "Đăng ký thành công...", device);
																				if (device.method_82("\"not now\"", text13))
																				{
																					device.method_99("\"not now\"", "", 10);
																				}
																				else
																				{
																					device.method_99("\"lúc khác\"", "", 10);
																				}
																			}
																		}
																		else
																		{
																			method_62(int_41, text3 + "Dừng chạy...");
																			flag11 = false;
																		}
																		goto IL_4dbc;
																	}
																	method_62(int_41, text3 + "Không check được status...");
																	method_49("Không check được status đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																break;
															}
														}
														catch (Exception exception_)
														{
															method_62(int_41, text3 + "Lỗi khi đăng ký", device);
															method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
															Common.smethod_82(exception_, "Check_status_dangky");
														}
														goto end_IL_3756;
														IL_4dbc:
														if (!flag11)
														{
															method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_3756;
														}
														if (bool_0)
														{
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_3756;
														}
														method_62(int_41, text3 + "Lưu mật khẩu và số điện thoại...", device);
														device.method_121(1.0);
														if (device.method_52("DataClick\\image\\ok1"))
														{
															device.method_3("DataClick\\image\\ok1");
														}
														else
														{
															device.method_91(160, 356);
														}
														goto IL_4e67;
														IL_738b:
														device.method_121(1.0);
														string text35 = device.method_13();
														text19 = Regex.Match(text35.Split('|')[1] + ";", "c_user=(.*?);").Groups[1].Value;
														if (text19.Trim() != "")
														{
															method_52(text19, "uid", int_41, 0, dgvAcc);
														}
														text20 = text35.Split('|')[0];
														text21 = text35.Split('|')[1];
														method_52(text20, "token", int_41, 0, dgvAcc);
														method_52(text21, "cookie", int_41, 0, dgvAcc);
														if (!flag5)
														{
															if (!flag11)
															{
																method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															method_62(int_41, text3 + "Chuyển đổi ngôn ngữ về English...", device);
															device.method_122();
															int n = 0;
															device.method_121(1.0);
															for (; n < 10; n++)
															{
																string text36 = device.method_93();
																if (!device.method_99("english", text36))
																{
																	device.method_121(1.0);
																	continue;
																}
																flag11 = true;
																break;
															}
															if (flag11)
															{
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																device.method_121(5.0);
																if (Settings.Default.isAddMailReg && flag2)
																{
																	string text37 = queue_1.Dequeue();
																	method_62(int_41, text3 + "Thêm mail sau khi reg...", device);
																	device.method_128();
																	device.method_121(10.0);
																	if (device.method_52("DataClick\\image\\addmailreg", null, 1))
																	{
																		device.method_3("DataClick\\image\\addmailreg", null, 1);
																	}
																	device.method_121(5.0);
																	if (device.method_52("DataClick\\image\\input", null, 1))
																	{
																		device.method_3("DataClick\\image\\input", null, 1);
																	}
																	device.method_121(2.0);
																	device.method_100(text37);
																	device.method_121(1.0);
																	if (device.method_52("DataClick\\image\\addmail", null, 1))
																	{
																		device.method_3("DataClick\\image\\addmail", null, 1);
																	}
																	device.method_121(5.0);
																}
																try
																{
																	if (bool_3)
																	{
																		try
																		{
																			if (bool_0)
																			{
																				method_62(int_41, text3 + "Dừng chạy...", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_3756;
																			}
																			method_62(int_41, text3 + "Up avatar...", device);
																			int num15 = 1;
																			int num16 = 0;
																			string text38 = "";
																			int num17 = 0;
																			while (true)
																			{
																				if (bool_0)
																				{
																					method_62(int_41, text3 + "Dừng chạy...", device);
																					method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																					break;
																				}
																				if (num17 != 5)
																				{
																					device.method_12();
																					if (flag2 || !device.method_52("DataClick\\image\\checkpoint"))
																					{
																						text38 = device.method_93();
																						num17++;
																						switch (method_44(device, int_41, ""))
																						{
																						case 0:
																							method_62(int_41, text3 + "Up lại avatar...", device);
																							continue;
																						case 2:
																							continue;
																						case 3:
																							goto end_IL_7690;
																						}
																						bool flag12 = device.method_99("profile picture", "", 10);
																						while (flag12)
																						{
																							if (!bool_0)
																							{
																								num15++;
																								int num18 = num15;
																								int num19 = num18;
																								if (num19 == 1 || num19 != 2)
																								{
																									break;
																								}
																								flag12 = false;
																								device.method_85("shell rm /sdcard/*.png");
																								device.method_85("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures");
																								device.method_121(1.0);
																								if (!device.method_99("select profile picture", "", 5))
																								{
																									continue;
																								}
																								int num20 = 0;
																								while (true)
																								{
																									if (num20 < 5)
																									{
																										if (bool_0)
																										{
																											method_62(int_41, text3 + "Dừng chạy...", device);
																											method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																											break;
																										}
																										text38 = device.method_93();
																										switch (device.method_84(text38, 0.0, "\"allow\"", "\"enable gallery access", "\"want to upload your photos", "\"photo\""))
																										{
																										case 1:
																											device.method_99("\"allow\"", text38);
																											goto IL_7902;
																										case 2:
																											device.method_99("\"enable gallery access", text38);
																											goto IL_7902;
																										case 3:
																											device.method_99("\"want to upload your photos", text38);
																											device.method_121(2.0);
																											device.method_74();
																											goto IL_7902;
																										default:
																											goto IL_7902;
																										case 4:
																											break;
																										}
																									}
																									List<string> list = device.method_76("\"photo\"", text38);
																									if (list.Count >= 10)
																									{
																										int num21 = random_0.Next(0, 10);
																										int num22 = 0;
																										while (true)
																										{
																											if (num22 < num21 && !device.method_81(1000, 1, "[125,444][179,465]", "[146,313][223,348]", "[124,359][196,423]"))
																											{
																												if (!bool_0)
																												{
																													device.method_121(1.0);
																													num22++;
																													continue;
																												}
																												method_62(int_41, text3 + "Dừng chạy...", device);
																												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																												break;
																											}
																											text38 = device.method_93();
																											goto IL_79b3;
																										}
																										break;
																									}
																									goto IL_79b3;
																									IL_7902:
																									device.method_121(1.0);
																									num20++;
																									continue;
																									IL_79b3:
																									string value = (from string_0 in device.method_76("\"photo\"", text38)
																										orderby Guid.NewGuid()
																										select string_0).FirstOrDefault();
																									if (!string.IsNullOrEmpty(value))
																									{
																										device.method_89(value);
																										device.method_121(1.0);
																										flag12 = device.method_99("\"save\"", "", 10);
																										flag11 = true;
																									}
																									goto IL_7a2c;
																								}
																								goto end_IL_776e;
																							}
																							method_62(int_41, text3 + "Dừng chạy...", device);
																							method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																							goto end_IL_776e;
																							IL_7a2c:;
																						}
																					}
																				}
																				else
																				{
																					method_62(int_41, text3 + "Không up được avartar...", device);
																				}
																				goto end_IL_7690;
																				continue;
																				end_IL_776e:
																				break;
																			}
																		}
																		catch
																		{
																			goto IL_8211;
																		}
																		goto end_IL_3756;
																	}
																	end_IL_7690:;
																}
																catch (Exception)
																{
																	method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																if (!flag11)
																{
																	method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																if (bool_4)
																{
																	try
																	{
																		device.method_115(string_19);
																		method_62(int_41, text3 + "Up cover photo...", device);
																		bool flag13 = false;
																		string text39 = "";
																		int num23 = 1;
																		int num24 = 0;
																		while (true)
																		{
																			if (!bool_0)
																			{
																				if (num24 != 5)
																				{
																					device.method_12();
																					if (flag2 || !device.method_52("DataClick\\image\\checkpoint"))
																					{
																						text39 = device.method_93();
																						num24++;
																						switch (method_44(device, int_41, text3))
																						{
																						case 0:
																							method_62(int_41, text3 + "Up lại cover photo...", device);
																							continue;
																						case 2:
																							continue;
																						case 3:
																							goto IL_7fe5;
																						}
																						string text40 = device.method_97("profile picture", "", 10);
																						if (text40 != "")
																						{
																							string[] array2 = text40.Split('[', ',', ']');
																							device.method_91(Convert.ToInt32(array2[1]) - 10, Convert.ToInt32(array2[2]) - 10);
																							flag13 = true;
																						}
																						while (flag13)
																						{
																							if (!bool_0)
																							{
																								num23++;
																								switch (num23)
																								{
																								case 2:
																								{
																									flag13 = false;
																									device.method_85("shell rm /sdcard.png");
																									device.method_85("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures");
																									device.method_121(1.0);
																									if (!device.method_99("upload photo", "", 5))
																									{
																										continue;
																									}
																									int num25 = 0;
																									while (true)
																									{
																										if (num25 < 5)
																										{
																											if (bool_0)
																											{
																												method_62(int_41, text3 + "Dừng chạy...", device);
																												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																												goto end_IL_7c2c;
																											}
																											text39 = device.method_93();
																											switch (device.method_84(text39, 0.0, "\"allow\"", "\"enable gallery access", "\"want to upload your photos", "\"photo\""))
																											{
																											case 1:
																												device.method_99("\"allow\"", text39);
																												goto IL_7e16;
																											case 2:
																												device.method_99("\"enable gallery access", text39);
																												goto IL_7e16;
																											case 3:
																												device.method_99("\"want to upload your photos", text39);
																												device.method_121(2.0);
																												device.method_74();
																												goto IL_7e16;
																											default:
																												goto IL_7e16;
																											case 4:
																												break;
																											}
																										}
																										List<string> list2 = device.method_76("\"photo\"", text39);
																										if (list2.Count >= 24)
																										{
																											int num26 = random_0.Next(0, 5);
																											for (int num27 = 0; num27 < num26; num27++)
																											{
																												if (device.method_81(1000, 1, "[125,444][179,465]", "[146,313][223,348]", "[124,359][196,423]"))
																												{
																													break;
																												}
																												device.method_121(1.0);
																											}
																											text39 = device.method_93();
																										}
																										string value2 = (from string_0 in device.method_76("\"photo\"", text39)
																											orderby Guid.NewGuid()
																											select string_0).FirstOrDefault();
																										if (!string.IsNullOrEmpty(value2))
																										{
																											device.method_89(value2);
																											device.method_121(1.0);
																											flag13 = device.method_99("\"save\"", "", 10);
																											flag11 = true;
																										}
																										break;
																										IL_7e16:
																										device.method_121(1.0);
																										num25++;
																									}
																									continue;
																								}
																								case 3:
																									device.method_121(3.0);
																									flag13 = device.method_75(60.0, "uploading your cover photo.");
																									continue;
																								}
																								break;
																							}
																							method_62(int_41, text3 + "Dừng chạy...", device);
																							method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																							goto end_IL_7c2c;
																						}
																					}
																				}
																				else
																				{
																					method_62(int_41, text3 + "Không up được cover photo...", device);
																				}
																				goto IL_7fe5;
																			}
																			method_62(int_41, text3 + "Dừng chạy...", device);
																			method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																			break;
																			continue;
																			end_IL_7c2c:
																			break;
																		}
																	}
																	catch
																	{
																		goto IL_8211;
																	}
																	goto end_IL_3756;
																}
																goto IL_7fe5;
															}
															flag11 = false;
															method_62(int_41, text3 + "Không đổi được ngôn ngữ. Ko thể làm các step tiếp theo", device);
														}
														goto IL_8211;
														IL_4e67:
														string text44;
														if (flag3)
														{
															device.method_99("\"tiếp tục\"");
															for (int num28 = 0; num28 < 5; num28++)
															{
																text13 = device.method_93();
																if (device.method_82("giúp chúng tôi xác nhận đó là bạn", text13))
																{
																	method_62(int_41, "Captcha...Không xác thực", device);
																	method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
															}
															if (string_12.Substring(0, 1) == "0" && !flag2)
															{
																if (bool_16)
																{
																	int num29 = 0;
																	while (true)
																	{
																		if (num29 == 0)
																		{
																			method_62(int_41, text3 + "Đang lấy số điện thoại...", device);
																		}
																		else
																		{
																			method_62(int_41, text3 + "Lấy số khác...Lần: " + num29, device);
																			device.method_121(1.0);
																			int tickCount2 = Environment.TickCount;
																			while ((Environment.TickCount - tickCount2) / 1000 - int_39 < 0)
																			{
																				if (!bool_0)
																				{
																					method_62(int_41, "Thời gian lấy số tiếp theo {time}s...".Replace("{time}", (int_39 - (Environment.TickCount - tickCount2) / 1000).ToString()), device);
																					continue;
																				}
																				method_62(int_41, "Dừng chạy!", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_52b9;
																			}
																		}
																		text5 = "";
																		if (int_37 == 0)
																		{
																			text5 = Common.smethod_21(text17, ref text18);
																		}
																		else if (int_37 == 1)
																		{
																			text5 = Common.smethod_48(text17);
																			text9 = text5;
																		}
																		else if (int_37 == 2)
																		{
																			text5 = Common.smethod_22(text17, ref text18);
																		}
																		else if (int_37 == 3)
																		{
																			text5 = Common.smethod_23(text17, ref text18);
																		}
																		else if (int_37 == 4)
																		{
																			text5 = Common.smethod_24(text17, ref text18);
																		}
																		if (text5 != "")
																		{
																			if (!(text5 == "API sai"))
																			{
																				if (!(text5 == "Đã hết số điện thoại, chờ cập nhật"))
																				{
																					if (int_37 == 0 || int_37 == 1 || int_37 == 2)
																					{
																						text5 = "+1" + text5;
																					}
																					if (device.method_52("DataClick\\image\\inputsdtemail"))
																					{
																						device.method_3("DataClick\\image\\inputsdtemail");
																					}
																					else
																					{
																						device.method_99("nhập số điện thoại hoặc email mới");
																					}
																					method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																					method_52(text5, "phone", int_41, 0, dgvAcc);
																					device.method_121(1.0);
																					device.method_102(text5);
																					device.method_121(1.0);
																					if (device.method_52("DataClick\\image\\sendcodeotp"))
																					{
																						device.method_3("DataClick\\image\\sendcodeotp");
																					}
																					else
																					{
																						device.method_99("gửi mã đăng nhập");
																					}
																					bool flag14 = false;
																					for (int num30 = 0; num30 < 5; num30++)
																					{
																						text13 = device.method_93();
																						if (device.method_82("nhập mã mà chúng tôi vừa gửi qua tin nhắn văn bản", text13))
																						{
																							flag14 = true;
																							break;
																						}
																					}
																					if (!flag14)
																					{
																						if (num29 != 5)
																						{
																							device.method_44("nhập số điện thoại hoặc email mới");
																							num29++;
																							continue;
																						}
																						method_62(int_41, text3 + "Hết số điện thoại", device);
																						method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																						break;
																					}
																					method_62(int_41, text3 + "Đang lấy mã OTP...", device);
																					string text41 = string.Empty;
																					if (int_37 == 0)
																					{
																						text41 = Common.smethod_26(text17, text18, int_14);
																					}
																					else if (int_37 == 1)
																					{
																						text41 = Common.smethod_28(text17, text9, int_14);
																					}
																					else if (int_37 == 2)
																					{
																						text41 = Common.smethod_27(text17, text18, int_14);
																					}
																					else if (int_37 == 3)
																					{
																						text41 = Common.smethod_45(text17, text18, int_14);
																					}
																					else if (int_37 == 4)
																					{
																						text41 = Common.smethod_46(text17, text18, int_14);
																					}
																					if (!(text41 != ""))
																					{
																						if (num29 != 5)
																						{
																							if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
																							{
																								device.method_3("DataClick\\image\\capnhatthongtinlienhe");
																							}
																							else
																							{
																								device.method_99("cập nhật thông tin liên hệ");
																							}
																							num29++;
																							continue;
																						}
																						method_62(int_41, text3 + "Hết số điện thoại", device);
																						method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																						break;
																					}
																					if (device.method_52("DataClick\\image\\inputotpckp"))
																					{
																						device.method_3("DataClick\\image\\inputotpckp");
																					}
																					else
																					{
																						device.method_91(32, 173);
																					}
																					device.method_121(1.0);
																					device.method_102(text41);
																					device.method_121(1.0);
																					device.method_99("\"tiếp\"");
																					bool flag15 = false;
																					for (int num31 = 0; num31 < 20; num31++)
																					{
																						text13 = device.method_93();
																						if (device.method_82("bạn có thể dùng facebook", text13))
																						{
																							flag15 = true;
																							flag4 = true;
																							flag2 = true;
																							break;
																						}
																					}
																					if (flag15)
																					{
																						if (device.method_52("DataClick\\image\\truycapfacebook"))
																						{
																							device.method_3("DataClick\\image\\truycapfacebook");
																						}
																						else
																						{
																							device.method_91(160, 165);
																						}
																						flag11 = true;
																						device.method_121(1.0);
																					}
																					else
																					{
																						method_62(int_41, text3 + "Checkpoint 282. Lưu acc", device);
																						method_42(int_41, "Checkpoint");
																						flag5 = true;
																					}
																				}
																				else
																				{
																					method_62(int_41, text3 + "Hết số điện thoại. Chuyển sang noveri", device);
																					flag2 = false;
																					device.method_12();
																				}
																				goto IL_738b;
																			}
																			method_62(int_41, text3 + "API key sai...", device);
																			method_49("API key sai", device.int_0, int_41, int_42, device, bool_18: false);
																			break;
																		}
																		if (text5 == "Đã hết số điện thoại, chờ cập nhật")
																		{
																			method_62(int_41, text3 + "Hết số điện thoại", device);
																			method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																		}
																		else
																		{
																			method_62(int_41, text3 + "Hết số điện thoại", device);
																			method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																		}
																		break;
																		continue;
																		end_IL_52b9:
																		break;
																	}
																	goto end_IL_3756;
																}
																if (bool_17)
																{
																	int num32 = 0;
																	while (true)
																	{
																		method_62(int_41, text3 + "Đang lấy tempmail.io", device);
																		string text42 = "";
																		string text43 = method_73();
																		if (int_38 == 0)
																		{
																			text42 = Common.smethod_19(text43);
																		}
																		if (!(text42 != ""))
																		{
																			break;
																		}
																		if (device.method_52("DataClick\\image\\inputsdtemail"))
																		{
																			device.method_3("DataClick\\image\\inputsdtemail");
																		}
																		else
																		{
																			device.method_99("nhập số điện thoại hoặc email mới");
																		}
																		method_62(int_41, text3 + "TempMail:" + text42, device);
																		method_52(text42, "email", int_41, 0, dgvAcc);
																		device.method_121(1.0);
																		device.method_102(text42);
																		device.method_121(1.0);
																		if (device.method_52("DataClick\\image\\sendcodeotp"))
																		{
																			device.method_3("DataClick\\image\\sendcodeotp");
																		}
																		else
																		{
																			device.method_99("gửi mã đăng nhập");
																		}
																		bool flag16 = false;
																		for (int num33 = 0; num33 < 5; num33++)
																		{
																			text13 = device.method_93();
																			if (device.method_82("nhập mã xác nhận", text13))
																			{
																				flag16 = true;
																				break;
																			}
																		}
																		if (flag16)
																		{
																			method_62(int_41, text3 + "Đang lấy mã OTP...", device);
																			text44 = Common.smethod_20(method_39(int_41));
																			if (!(text44 != ""))
																			{
																				if (num32 != 5)
																				{
																					if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
																					{
																						device.method_3("DataClick\\image\\capnhatthongtinlienhe");
																					}
																					else
																					{
																						device.method_99("cập nhật thông tin liên hệ");
																					}
																					num32++;
																					continue;
																				}
																				method_62(int_41, text3 + "Không thể xác thực tài khoản", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_3756;
																			}
																			goto IL_5776;
																		}
																		if (num32 != 5)
																		{
																			if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
																			{
																				device.method_3("DataClick\\image\\capnhatthongtinlienhe");
																			}
																			else
																			{
																				device.method_99("cập nhật thông tin liên hệ");
																			}
																			num32++;
																			continue;
																		}
																		method_62(int_41, text3 + "Không thể xác thực tài khoản", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_3756;
																	}
																}
															}
														}
														while (true)
														{
															if (string_12.Substring(0, 1) == "0" && !flag2)
															{
																if (bool_16)
																{
																	if (!bool_0)
																	{
																		text13 = device.method_93();
																		if (device.method_82("change phone number", text13))
																		{
																			device.method_99("change phone number", text13);
																		}
																		else
																		{
																			device.method_99("thay đổi số điện thoại", text13);
																		}
																		while (true)
																		{
																			if (num2 == 0)
																			{
																				method_62(int_41, text3 + "Đang lấy số điện thoại...", device);
																			}
																			else
																			{
																				method_62(int_41, text3 + "Lấy số khác...Lần: " + num2, device);
																				device.method_121(1.0);
																				int tickCount3 = Environment.TickCount;
																				while ((Environment.TickCount - tickCount3) / 1000 - int_39 < 0)
																				{
																					if (!bool_0)
																					{
																						method_62(int_41, "Thời gian lấy số tiếp theo {time}s...".Replace("{time}", (int_39 - (Environment.TickCount - tickCount3) / 1000).ToString()), device);
																						continue;
																					}
																					method_62(int_41, "Dừng chạy!", device);
																					method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																					goto end_IL_5c15;
																				}
																			}
																			text5 = "";
																			if (int_37 == 0)
																			{
																				text5 = Common.smethod_21(text17, ref text18);
																			}
																			else if (int_37 == 1)
																			{
																				text5 = Common.smethod_48(text17);
																				text9 = text5;
																			}
																			else if (int_37 == 2)
																			{
																				text5 = Common.smethod_22(text17, ref text18);
																			}
																			else if (int_37 == 3)
																			{
																				text5 = Common.smethod_23(text17, ref text18);
																			}
																			else if (int_37 == 4)
																			{
																				text5 = Common.smethod_24(text17, ref text18);
																			}
																			if (text5 != "")
																			{
																				if (!(text5 == "API sai"))
																				{
																					if (!(text5 == "Đã hết số điện thoại, chờ cập nhật"))
																					{
																						if (int_37 == 0 || int_37 == 1 || int_37 == 2)
																						{
																							text5 = "+1" + text5;
																						}
																						method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																						method_52(text5, "phone", int_41, 0, dgvAcc);
																						device.method_121(1.0);
																						if (num2 == 0)
																						{
																							if (device.method_52("DataClick\\image\\phone"))
																							{
																								device.method_3("DataClick\\image\\phone");
																							}
																							else
																							{
																								device.method_91(36, 147);
																							}
																						}
																						device.method_121(1.0);
																						device.method_102(text5);
																						device.method_121(1.0);
																						if (device.method_52("DataClick\\image\\continue"))
																						{
																							device.method_3("DataClick\\image\\continue");
																						}
																						bool flag17 = false;
																						for (int num34 = 0; num34 < 5; num34++)
																						{
																							text13 = device.method_93();
																							if (!device.method_82("nhập mã từ sms của bạn", text13))
																							{
																								flag17 = true;
																								continue;
																							}
																							flag17 = false;
																							break;
																						}
																						if (!flag17)
																						{
																							goto IL_5c24;
																						}
																						if (num2 != 5)
																						{
																							device.method_44("số điện thoại di động");
																							num2++;
																							continue;
																						}
																						goto IL_5e64;
																					}
																					goto IL_5e8d;
																				}
																				method_62(int_41, text3 + "API key sai...", device);
																				method_49("API key sai", device.int_0, int_41, int_42, device, bool_18: false);
																				break;
																			}
																			if (num2 != 5)
																			{
																				num2++;
																				continue;
																			}
																			goto IL_5ee2;
																			continue;
																			end_IL_5c15:
																			break;
																		}
																	}
																	else
																	{
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	}
																	break;
																}
																if (bool_17)
																{
																	if (!bool_0)
																	{
																		text13 = device.method_93();
																		if (device.method_82("email confirmation", text13))
																		{
																			device.method_99("email confirmation", text13);
																		}
																		else
																		{
																			device.method_99("xác nhận qua email", text13);
																		}
																		method_62(int_41, text3 + "Đang lấy tempmail.io", device);
																		string text45 = "";
																		while (true)
																		{
																			string text46 = method_73();
																			if (int_38 == 0)
																			{
																				text45 = Common.smethod_19(text46);
																			}
																			if (text45 != "")
																			{
																				method_52(text45, "email", int_41, 0, dgvAcc);
																				if (device.method_52("DataClick\\image\\emailveri"))
																				{
																					device.method_3("DataClick\\image\\emailveri");
																				}
																				device.method_121(1.0);
																				device.method_102(text45);
																				device.method_121(1.0);
																				if (device.method_52("DataClick\\image\\continue"))
																				{
																					device.method_3("DataClick\\image\\continue");
																				}
																				bool flag18 = false;
																				for (int num35 = 0; num35 < 5; num35++)
																				{
																					text13 = device.method_93();
																					if (!device.method_82("nhập mã từ email của bạn", text13))
																					{
																						flag18 = true;
																						continue;
																					}
																					flag18 = false;
																					break;
																				}
																				if (!flag18)
																				{
																					break;
																				}
																				if (num3 != 5)
																				{
																					device.method_44("địa chỉ email");
																					num3++;
																					method_62(int_41, text3 + "Lấy mail khác...Lần: " + num3, device);
																					continue;
																				}
																				goto IL_5f39;
																			}
																			if (num3 != 5)
																			{
																				num3++;
																				method_62(int_41, text3 + "Lấy mail khác...Lần: " + num3, device);
																				continue;
																			}
																			goto IL_5f62;
																		}
																		flag2 = true;
																		continue;
																	}
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																flag2 = false;
																device.method_12();
															}
															else
															{
																while (true)
																{
																	IL_6c5f:
																	text13 = device.method_93();
																	if (!device.method_82("enter your mobile number", text13) && !device.method_82("nhập số di động của bạn", text13))
																	{
																		int num36 = 0;
																		while (num36 < 2)
																		{
																			text13 = device.method_93();
																			if (device.method_120(text13).Count == 1)
																			{
																				num36++;
																				continue;
																			}
																			goto IL_6008;
																		}
																		goto IL_6064;
																	}
																	flag2 = false;
																	method_62(int_41, text3 + "Lỗi xác nhận số điện thoại hoặc email... Goto Newfeed", device);
																	device.method_124();
																	break;
																	IL_6008:
																	if (device.method_82("enter the code from your sms", text13) || device.method_82("nhập mã từ sms của bạn", text13) || device.method_82("nhập mã từ email của bạn", text13))
																	{
																		if (!bool_0)
																		{
																			flag11 = true;
																			goto IL_6064;
																		}
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_5e1f;
																	}
																	flag2 = false;
																	method_62(int_41, text3 + "Lỗi xác nhận số điện thoại hoặc email... Goto Newfeed", device);
																	device.method_124();
																	break;
																	IL_6064:
																	if (flag11)
																	{
																		if (!bool_0)
																		{
																			try
																			{
																				if (rdThuePhone.Checked || bool_16)
																				{
																					int num37 = 0;
																					int num38 = 0;
																					while (num38 < 2)
																					{
																						if (!bool_0)
																						{
																							method_62(int_41, text3 + "Đang lấy mã OTP...", device);
																							string text47 = string.Empty;
																							if (rdThuePhone.Checked)
																							{
																								if (string_12.Substring(2, 1) == "0")
																								{
																									text47 = Common.smethod_44(text17, text18, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "1")
																								{
																									text47 = Common.smethod_61(text17, text18, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "2")
																								{
																									text47 = Common.smethod_26(text17, text18, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "3")
																								{
																									text47 = Common.smethod_28(text17, text9, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "4")
																								{
																									text47 = Common.smethod_27(text17, text18, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "5")
																								{
																									text47 = Common.smethod_45(text17, text18, int_14);
																								}
																								else if (string_12.Substring(2, 1) == "6")
																								{
																									text47 = Common.smethod_46(text17, text18, int_14);
																								}
																							}
																							else if (bool_16)
																							{
																								if (int_37 == 0)
																								{
																									text47 = Common.smethod_26(text17, text18, int_14);
																								}
																								else if (int_37 == 1)
																								{
																									text47 = Common.smethod_28(text17, text9, int_14);
																								}
																								else if (int_37 == 2)
																								{
																									text47 = Common.smethod_27(text17, text18, int_14);
																								}
																								else if (int_37 == 3)
																								{
																									text47 = Common.smethod_45(text17, text18, int_14);
																								}
																								else if (int_37 == 4)
																								{
																									text47 = Common.smethod_46(text17, text18, int_14);
																								}
																							}
																							if (!(text47 == ""))
																							{
																								flag11 = true;
																								method_62(int_41, text3 + "Mã OTP:" + text47, device);
																								if (device.method_52("DataClick\\image\\confirmcode2fa", null, 1))
																								{
																									device.method_3("DataClick\\image\\confirmcode2fa", null, 1);
																								}
																								device.method_102(text47);
																								break;
																							}
																							if (!bool_0)
																							{
																								num37++;
																								text13 = device.method_93();
																								if (device.method_120(text13).Count == 1)
																								{
																									goto IL_639d;
																								}
																								method_62(int_41, text3 + "Không lấy được mã OTP...", device);
																								if (!device.method_82("account confirmation", text13) && !device.method_82("xác nhận tài khoản", text13))
																								{
																									goto IL_639d;
																								}
																								if (!bool_0)
																								{
																									if (!device.method_82("change phone number", text13) && !device.method_82("thay đổi số điện thoại", text13))
																									{
																										goto IL_639d;
																									}
																									if (bool_0)
																									{
																										method_62(int_41, text3 + "Dừng chạy...");
																										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																										break;
																									}
																									if (device.method_82("change phone number", text13))
																									{
																										device.method_99("change phone number", text13);
																									}
																									else
																									{
																										device.method_99("thay đổi số điện thoại", text13);
																									}
																									device.method_121(1.0);
																									while (true)
																									{
																										method_62(int_41, text3 + "Đang lấy số điện thoại khác...", device);
																										if (!rdThuePhone.Checked)
																										{
																											if (bool_16)
																											{
																												if (int_37 == 0)
																												{
																													text5 = Common.smethod_21(text17, ref text18);
																												}
																												else if (int_37 == 1)
																												{
																													text5 = Common.smethod_48(text17);
																													text9 = text5;
																												}
																												else if (int_37 == 2)
																												{
																													text5 = Common.smethod_22(text17, ref text18);
																												}
																												else if (int_37 == 3)
																												{
																													text5 = Common.smethod_23(text17, ref text18);
																												}
																												else if (int_37 == 4)
																												{
																													text5 = Common.smethod_24(text17, ref text18);
																												}
																											}
																										}
																										else if (string_12.Substring(2, 1) == "0")
																										{
																											text5 = Common.smethod_47(text17, ref text18);
																										}
																										else if (string_12.Substring(2, 1) == "1")
																										{
																											text5 = Common.smethod_57(text17, ref text18);
																										}
																										else if (string_12.Substring(2, 1) == "2")
																										{
																											text5 = Common.smethod_21(text17, ref text18);
																										}
																										else if (string_12.Substring(2, 1) == "3")
																										{
																											text5 = Common.smethod_48(text17);
																											text9 = text5;
																										}
																										else if (string_12.Substring(2, 1) == "4")
																										{
																											text5 = Common.smethod_22(text17, ref text18);
																										}
																										else if (string_12.Substring(2, 1) == "5")
																										{
																											text5 = Common.smethod_23(text17, ref text18);
																										}
																										else if (string_12.Substring(2, 1) == "6")
																										{
																											text5 = Common.smethod_24(text17, ref text18);
																										}
																										if (text5 == "")
																										{
																											if (!bool_0)
																											{
																												method_62(int_41, text3 + "Không lấy được số điện thoại. Lấy số khác", device);
																												continue;
																											}
																											method_62(int_41, text3 + "Dừng chạy...", device);
																											method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																											break;
																										}
																										if (text5 == "Đã hết số điện thoại, chờ cập nhật" && string_12.Substring(2, 1) == "3")
																										{
																											method_62(int_41, text3 + "Đã hết số điện thoại...", device);
																											method_49("Đã hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																											goto end_IL_63b1;
																										}
																										if (text5 == "API sai")
																										{
																											method_62(int_41, text3 + "API key sai...Kiểm tra lại", device);
																											method_49("API key sai...Kiểm tra lại", device.int_0, int_41, int_42, device, bool_18: false);
																											goto end_IL_63b1;
																										}
																										if (bool_0)
																										{
																											method_62(int_41, text3 + "Dừng chạy...", device);
																											method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																											break;
																										}
																										if (rdThuePhone.Checked)
																										{
																											if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
																											{
																												text5 = "+84" + text5;
																											}
																											if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "4")
																											{
																												text5 = "+1" + text5;
																											}
																										}
																										else if (bool_16)
																										{
																											if (int_37 == 3)
																											{
																												text5 = "+84" + text5;
																											}
																											if (int_37 == 0 || int_37 == 1 || int_37 == 2)
																											{
																												text5 = "+1" + text5;
																											}
																										}
																										method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																										method_52(text5, "phone", int_41, 0, dgvAcc);
																										device.method_121(1.0);
																										if (device.method_52("DataClick\\image\\phone"))
																										{
																											device.method_3("DataClick\\image\\phone");
																										}
																										else
																										{
																											device.method_91(36, 147);
																										}
																										device.method_121(1.0);
																										device.method_102(text5);
																										device.method_121(1.0);
																										if (device.method_52("DataClick\\image\\continue"))
																										{
																											device.method_3("DataClick\\image\\continue");
																										}
																										device.method_121(3.0);
																										goto IL_6c5f;
																									}
																								}
																								else
																								{
																									method_62(int_41, text3 + "Dừng chạy...", device);
																									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																								}
																							}
																							else
																							{
																								method_62(int_41, text3 + "Dừng chạy...");
																								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																							}
																						}
																						else
																						{
																							method_62(int_41, text3 + "Dừng chạy...", device);
																							method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																						}
																						goto end_IL_607a;
																						IL_639d:
																						if (num37 != 5)
																						{
																							num38++;
																							continue;
																						}
																						flag2 = false;
																						device.method_12();
																						goto end_IL_6c5f;
																						continue;
																						end_IL_63b1:
																						break;
																					}
																					goto IL_6c84;
																				}
																				if (rdConfMail.Checked)
																				{
																					if (bool_0)
																					{
																						method_62(int_41, text3 + "Dừng chạy...", device);
																						method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																						goto end_IL_5e1f;
																					}
																					string text48 = string_12.Substring(2, 1);
																					if (text48 != null)
																					{
																						if (!(text48 == "0"))
																						{
																							if (!(text48 == "1"))
																							{
																								string text49 = Common.smethod_20(method_39(int_41));
																								if (!(text49 != ""))
																								{
																									method_62(int_41, text3 + "Mail không nhận OTP - NoVeri account. Goto", device);
																									flag11 = true;
																									flag2 = false;
																									device.method_124();
																									break;
																								}
																								if (device.method_52("DataClick\\image\\confirmcode2fa", null, 1))
																								{
																									device.method_3("DataClick\\image\\confirmcode2fa", null, 1);
																								}
																								device.method_102(text49);
																								flag11 = true;
																							}
																						}
																						else
																						{
																							string text50 = Common.smethod_31(text6, text7);
																							if (text50 == "")
																							{
																								flag2 = false;
																								method_52("Mail không nhận được OTP. Goto Newfeed", "status", int_41, 2, dgvAcc);
																								device.method_124();
																							}
																							if (text50.Contains("kcon"))
																							{
																								flag2 = false;
																								method_52("Không kê\u0301t nô\u0301i đươ\u0323c server hotmail!", "status", int_41, 2, dgvAcc);
																								device.method_124();
																							}
																							if (device.method_52("DataClick\\image\\confirmcode2fa", null, 1))
																							{
																								device.method_3("DataClick\\image\\confirmcode2fa", null, 1);
																							}
																							device.method_102(text50);
																							flag11 = true;
																						}
																					}
																					goto IL_6c84;
																				}
																				if (bool_17)
																				{
																					string text51 = Common.smethod_20(method_39(int_41));
																					if (!(text51 != ""))
																					{
																						method_62(int_41, text3 + "Mail không nhận OTP - NoVeri account. Goto", device);
																						flag11 = true;
																						flag2 = false;
																						device.method_124();
																						break;
																					}
																					if (device.method_52("DataClick\\image\\confirmcode2fa", null, 1))
																					{
																						device.method_3("DataClick\\image\\confirmcode2fa", null, 1);
																					}
																					flag2 = true;
																					device.method_102(text51);
																					flag11 = true;
																				}
																				goto IL_6c84;
																				end_IL_607a:;
																			}
																			catch (Exception ex2)
																			{
																				method_62(int_41, text3 + "Lỗi khi xác nhận. Lỗi: " + ex2.Message, device);
																				method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																			}
																		}
																		else
																		{
																			method_62(int_41, text3 + "Dừng chạy...", device);
																			method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		}
																	}
																	else
																	{
																		method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																		method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																	}
																	goto end_IL_5e1f;
																	IL_6c84:
																	if (!flag11)
																	{
																		method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																		method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_5e1f;
																	}
																	if (bool_0)
																	{
																		method_62(int_41, text3 + "Dừng chạy...", device);
																		method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																		goto end_IL_5e1f;
																	}
																	if (device.method_82("\"confirm\"", text13))
																	{
																		device.method_99("\"confirm\"");
																	}
																	else
																	{
																		device.method_99("\"xác nhận\"");
																	}
																	device.method_121(15.0);
																	int num39 = 0;
																	while (true)
																	{
																		if (num39 < 10)
																		{
																			text13 = device.method_93();
																			if (device.method_120(text13).Count == 1)
																			{
																				goto IL_6eac;
																			}
																			if (!device.method_82("skip", text13) && !device.method_82("bỏ qua", text13))
																			{
																				if (!device.method_82("we need more information", text13) && !device.method_82("Something went wrong. Please try again.", text13) && !device.method_82("chúng tôi cần thêm thông tin", text13))
																				{
																					if (device.method_82("enter the code from your sms", text13) || device.method_82("nhập mã từ sms của bạn", text13) || device.method_82("nhập mã từ email của bạn", text13))
																					{
																						if (num39 == 3)
																						{
																							flag2 = false;
																							method_62(int_41, text3 + "Lỗi xác thực số điện thoại từ Facebook...Goto Newfeed", device);
																							break;
																						}
																						method_62(int_41, text3 + "Xác nhận lại lần " + num39, device);
																						device.method_121(2.0);
																						if (device.method_82("\"confirm\"", text13))
																						{
																							device.method_99("\"confirm\"");
																						}
																						else
																						{
																							device.method_99("\"xác nhận\"");
																						}
																						flag11 = true;
																						flag2 = true;
																					}
																					goto IL_6eac;
																				}
																				method_62(int_41, text3 + "Checkpoint 282. Lưu acc", device);
																				method_42(int_41, "Checkpoint");
																				flag5 = true;
																				break;
																			}
																			if (bool_0)
																			{
																				method_62(int_41, text3 + "Dừng chạy...", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_5e1f;
																			}
																			flag11 = true;
																			if (device.method_82("skip", text13))
																			{
																				device.method_99("\"skip\"");
																			}
																			else
																			{
																				device.method_99("\"bỏ qua\"");
																			}
																		}
																		if (!flag11)
																		{
																			method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																			method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																			goto end_IL_5e1f;
																		}
																		if (bool_0)
																		{
																			method_62(int_41, text3 + "Dừng chạy...", device);
																			method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																			goto end_IL_5e1f;
																		}
																		method_62(int_41, text3 + "Thêm 5 bạn bè gợi ý...", device);
																		device.method_121(2.0);
																		text13 = device.method_93();
																		if (device.method_82("add 5 friends", text13) || device.method_82("thêm 5 người bạn", text13) || device.method_82("mời tất cả", text13))
																		{
																			if (bool_0)
																			{
																				method_62(int_41, text3 + "Dừng chạy...", device);
																				method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																				goto end_IL_5e1f;
																			}
																			flag11 = true;
																			if (device.method_82("add 5 friends", text13))
																			{
																				device.method_99("\"add 5 friends\"", "", 10);
																			}
																			else if (device.method_82("thêm 5 người bạn", text13))
																			{
																				device.method_99("\"thêm 5 người bạn\"", "", 10);
																			}
																			else if (device.method_82("mời tất cả", text13))
																			{
																				device.method_99("\"mời tất cả\"", "", 10);
																			}
																		}
																		else
																		{
																			flag11 = true;
																			if (device.method_82("skip", text13))
																			{
																				device.method_99("\"skip\"", "", 10);
																			}
																			else if (device.method_82("bỏ qua", text13))
																			{
																				device.method_99("\"bỏ qua\"", "", 10);
																			}
																			else if (device.method_82("xong", text13))
																			{
																				device.method_99("\"xong\"", "", 10);
																			}
																			else if (device.method_82("tiếp", text13))
																			{
																				device.method_99("\"tiếp\"", "", 10);
																			}
																		}
																		if (!flag11)
																		{
																			method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																			method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																			goto end_IL_5e1f;
																		}
																		if (bool_0)
																		{
																			method_62(int_41, text3 + "Dừng chạy...", device);
																			method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																			goto end_IL_5e1f;
																		}
																		device.method_121(1.0);
																		if (device.method_82("\"xong\""))
																		{
																			device.method_99("\"xong\"");
																		}
																		if (device.method_82("\"ok\""))
																		{
																			device.method_99("\"ok\"");
																		}
																		break;
																		IL_6eac:
																		num39++;
																	}
																	break;
																	continue;
																	end_IL_6c5f:
																	break;
																}
															}
															goto IL_738b;
															IL_5e64:
															method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
															flag2 = false;
															device.method_12();
															goto IL_738b;
															IL_5c24:
															flag2 = true;
															continue;
															IL_5e8d:
															method_62(int_41, text3 + "Hết số điện thoại. Chuyển sang noveri", device);
															flag2 = false;
															device.method_12();
															goto IL_738b;
															IL_5ee2:
															method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
															flag2 = false;
															device.method_12();
															goto IL_738b;
															IL_5f39:
															method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
															flag2 = false;
															device.method_12();
															goto IL_738b;
															IL_5f62:
															method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
															flag2 = false;
															device.method_12();
															goto IL_738b;
															continue;
															end_IL_5e1f:
															break;
														}
														goto end_IL_3756;
														IL_5776:
														if (device.method_52("DataClick\\image\\inputotpckp"))
														{
															device.method_3("DataClick\\image\\inputotpckp");
														}
														else
														{
															device.method_91(32, 173);
														}
														device.method_121(1.0);
														device.method_102(text44);
														device.method_99("\"tiếp\"");
														bool flag19 = false;
														for (int num40 = 0; num40 < 20; num40++)
														{
															text13 = device.method_93();
															if (device.method_82("bạn có thể dùng facebook", text13))
															{
																flag19 = true;
																flag4 = true;
																flag2 = true;
																break;
															}
														}
														if (flag19)
														{
															if (device.method_52("DataClick\\image\\truycapfacebook"))
															{
																device.method_3("DataClick\\image\\truycapfacebook");
															}
															else
															{
																device.method_91(160, 165);
															}
															flag11 = true;
															device.method_121(1.0);
														}
														else
														{
															method_62(int_41, text3 + "Checkpoint 282. Lưu acc", device);
															method_42(int_41, "Checkpoint");
															flag5 = true;
														}
														goto IL_738b;
														IL_7fe5:
														if (!flag11)
														{
															method_62(int_41, text3 + "Lỗi khi đăng ký", device);
															method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_3756;
														}
														if (bool_0)
														{
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_3756;
														}
														if (bool_6)
														{
															method_62(int_41, text3 + "Bật 2FA...", device);
															try
															{
																for (int num41 = 0; num41 < 2; num41++)
																{
																	if (!bool_0)
																	{
																		int num42 = 0;
																		num42 = ((!flag2) ? method_35(int_41, int_42, device, 1) : method_34(int_41, device));
																		if (num42 != 1)
																		{
																			method_62(int_41, text3 + "Bật 2FA thất bại. Thử bật lại...");
																			continue;
																		}
																		method_62(int_41, text3 + "Bật 2FA thành công", device);
																		device.method_121(1.0);
																		break;
																	}
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
															}
															catch (Exception exception_2)
															{
																Common.smethod_82(exception_2, "HDOnOff2FA");
																goto IL_8211;
															}
														}
														if (bool_15)
														{
															try
															{
																method_62(int_41, text3 + "Đồng bộ danh bạ...", device);
																device.method_124();
																device.method_121(1.0);
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	goto end_IL_3756;
																}
																int num43 = 0;
																for (int num44 = 0; num44 < 2; num44++)
																{
																	if (method_30(int_41, text3, device, int_28, int_29, bool_13, bool_14, int_30, int_31, int_32, int_33) != 0)
																	{
																		method_62(int_41, text3 + "Đồng bộ danh bạ xong...", device);
																		break;
																	}
																}
																goto IL_8211;
															}
															catch (Exception)
															{
																goto IL_8211;
															}
														}
														goto IL_8211;
														IL_8211:
														if (text19 != "")
														{
															string text52 = "";
															text52 = ((int_9 == 5) ? ("|" + method_38(int_41)) : "");
															if (!flag2)
															{
																if (flag5)
																{
																	object obj12 = object_10;
																	lock (obj12)
																	{
																		File.AppendAllText("output/facebook/acc_282.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																	}
																}
																else
																{
																	string text53 = method_37(int_41);
																	object obj12 = object_7;
																	if (text53 != "")
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/Noverify_2fa.txt", text19 + "|" + text16 + "|" + text53 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																		}
																	}
																	else
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/Noverify.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																		}
																	}
																}
															}
															else if (rdThuePhone.Checked || bool_16)
															{
																string text54 = method_37(int_41);
																object obj12 = object_8;
																if (Settings.Default.isThuVeriCheckPoint && flag4)
																{
																	if (text54 != "")
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/VerifySdt_checkpoint282_2fa.txt", text19 + "|" + text16 + "|" + text54 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																		}
																	}
																	else
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/VerifySdt_checkpoint282.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																		}
																	}
																}
																else if (text54 != "")
																{
																	lock (obj12)
																	{
																		File.AppendAllText("output/facebook/VerifySdt_2fa.txt", text19 + "|" + text16 + "|" + text54 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																	}
																}
																else
																{
																	lock (obj12)
																	{
																		File.AppendAllText("output/facebook/VerifySdt.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + Environment.NewLine);
																	}
																}
															}
															else
															{
																string text55 = method_37(int_41);
																object obj12 = object_9;
																if (rdHotMailReg.Checked || rdHotMailRegisted.Checked)
																{
																	if (text55 != "")
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/VerifyHotMail_2fa.txt", text19 + "|" + text16 + "|" + text55 + "|" + text20 + "|" + text21 + "|" + text6 + "|" + text7 + "|" + text52 + Environment.NewLine);
																		}
																	}
																	else
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/VerifyHotMail.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text6 + "|" + text7 + "|" + text52 + Environment.NewLine);
																		}
																	}
																}
																else if (rdTempMailIO.Checked)
																{
																	if (text55 != "")
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/Verify_tempmail_2fa.txt", text19 + "|" + text16 + "|" + text55 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																		}
																	}
																	else
																	{
																		lock (obj12)
																		{
																			File.AppendAllText("output/facebook/Verify_tempmail.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																		}
																	}
																}
																else if (bool_17)
																{
																	if (Settings.Default.isThuVeriCheckPoint && flag4)
																	{
																		if (int_38 == 0)
																		{
																			if (text55 != "")
																			{
																				lock (obj12)
																				{
																					File.AppendAllText("output/facebook/VerifyMail_checkpoint282_2fa.txt", text19 + "|" + text16 + "|" + text55 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																				}
																			}
																			else
																			{
																				lock (obj12)
																				{
																					File.AppendAllText("output/facebook/VerifyMail_checkpoint282.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																				}
																			}
																		}
																	}
																	else if (int_38 == 0)
																	{
																		if (text55 != "")
																		{
																			lock (obj12)
																			{
																				File.AppendAllText("output/facebook/Verify_tempmail_2fa.txt", text19 + "|" + text16 + "|" + text55 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																			}
																		}
																		else
																		{
																			lock (obj12)
																			{
																				File.AppendAllText("output/facebook/Verify_tempmail.txt", text19 + "|" + text16 + "|" + text20 + "|" + text21 + "|" + text52 + "|" + method_39(int_41) + Environment.NewLine);
																			}
																		}
																	}
																}
															}
														}
														device.method_121(1.0);
														method_62(int_41, text3 + "Tắt app Facebook và mở lại", device);
														device.method_121(1.0);
														device.method_70();
														device.method_121(3.0);
														device.method_105();
														device.method_121(1.0);
														if (flag11)
														{
															if (chkReadNotifi.Checked)
															{
																method_62(int_41, text3 + "Đọc thông báo", device);
																device.method_121(1.0);
																method_32(int_41, text3, device);
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															if (chkWStory.Checked)
															{
																method_62(int_41, text3 + "Lướt story", device);
																device.method_121(1.0);
																method_29(int_41, text3, device);
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															if (chkAddFUID.Checked)
															{
																method_62(int_41, text3 + "Thêm bạn bè gợi ý", device);
																int int_43 = Convert.ToInt32(nFriendFrom.Value);
																int int_44 = Convert.ToInt32(nFriendFrom.Value);
																device.method_121(1.0);
																method_28(int_41, text3, device, int_43, int_44);
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															if (chkInNewfeed.Checked)
															{
																method_62(int_41, text3 + "Tương tác newsfeed", device);
																device.method_121(1.0);
																method_26(int_41, text3, device);
															}
															if (bool_0)
															{
																method_62(int_41, text3 + "Dừng chạy...", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_3756;
															}
															if (chkWatch.Checked)
															{
																method_62(int_41, text3 + "Xem watch", device);
																device.method_121(1.0);
																method_25(int_41, text3, device, 1, 5, 10, 20, bool_18: true, 1, 5, bool_19: true, 1, 3, bool_20: false, null, 0, 0, 100, 100, 100);
															}
														}
														if (Settings.Default.isCheckUID)
														{
															method_62(int_41, text3 + "Check uid và wall...", device);
															device.method_121(1.0);
															if (method_48(text19) && Common.smethod_33(text19).StartsWith("0|"))
															{
																method_42(int_41, "Live");
																if (flag5)
																{
																	method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
																}
																else
																{
																	method_49("Tạo tài khoản thành công", device.int_0, int_41, int_42, device, bool_18: true);
																}
															}
															else
															{
																method_42(int_41, "Die");
																method_49("Tài khoản die!!!", device.int_0, int_41, int_42, device, bool_18: false);
															}
														}
														else if (flag5)
														{
															method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
														}
														else
														{
															method_49("Tạo tài khoản thành công", device.int_0, int_41, int_42, device, bool_18: true);
														}
														goto end_IL_3756;
														continue;
														end_IL_4ccc:
														break;
													}
													goto IL_909d;
													continue;
													end_IL_3756:
													break;
												}
												break;
												continue;
												end_IL_2a36:
												break;
											}
											break;
										}
										method_62(int_41, text3 + "Bị treo LD khi mở app facebook. Thực hiện lại.", device);
										device.method_70();
										device.method_121(1.0);
										continue;
									}
									catch (Exception exception_3)
									{
										method_62(int_41, text3 + "Lỗi treo LD khi mở app Facebook", device);
										method_49("Lỗi treo LD khi mở app Facebook", device.int_0, int_41, int_42, device, bool_18: false);
										Common.smethod_82(exception_3, "ErrorOpenAppFacebook");
									}
									break;
								}
								break;
							}
							method_62(int_41, text3 + "Mở App Facebook Lite", device);
							device.method_40();
							string text56 = "";
							try
							{
								if (bool_0)
								{
									method_62(int_41, text3 + "Dừng chạy...", device);
									method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
									break;
								}
								device.method_106();
								bool flag20 = false;
								bool flag21 = false;
								bool flag22 = false;
								int num45 = 0;
								for (int num46 = 0; num46 < 30; num46++)
								{
									if (device.method_52("DataClick\\fblite\\facebook"))
									{
										flag20 = true;
										break;
									}
								}
								if (flag20)
								{
									device.method_121(5.0);
									method_62(int_41, text3 + "Đăng ký facebook lite", device);
									if (device.method_52("DataClick\\fblite\\tiengviet"))
									{
										device.method_3("DataClick\\fblite\\tiengviet");
									}
									device.method_121(5.0);
									if (!device.method_52("DataClick\\fblite\\createaccount"))
									{
										device.method_91(32, 376);
										device.method_121(1.0);
									}
									if (device.method_52("DataClick\\fblite\\createaccount"))
									{
										device.method_3("DataClick\\fblite\\createaccount");
									}
									device.method_121(1.0);
									if (device.method_52("DataClick\\fblite\\next"))
									{
										device.method_3("DataClick\\fblite\\next");
									}
									device.method_121(1.0);
									method_62(int_41, text3 + "Tạo thông tin đăng ký", device);
									string text57 = "";
									string text58 = "";
									string text59 = "";
									string text60 = "";
									string text61 = "";
									string text62 = "";
									string text63 = "";
									string text64 = "";
									string text65 = "";
									string text66 = "";
									string text67 = "";
									string text68 = "";
									string text69 = "";
									string text70 = "";
									string text71 = "";
									bool flag23 = false;
									string text72 = random_0.Next(0, 2).ToString();
									if (int_13 == 0)
									{
										text72 = "0";
									}
									else if (int_13 == 1)
									{
										text72 = "1";
									}
									if (int_12 == 0)
									{
										text57 = method_6();
										text58 = ((!(text72 == "0")) ? method_7() : method_8());
									}
									else if (int_12 == 1)
									{
										text57 = method_3();
										text58 = ((!(text72 == "0")) ? method_5() : method_4());
									}
									else if (int_12 == 2)
									{
										text57 = method_9();
										text58 = ((!(text72 == "0")) ? method_10() : method_11());
										text70 = method_3();
										text71 = ((!(text72 == "0")) ? method_5() : method_4());
									}
									text59 = ((int_12 == 2) ? ((!bool_5) ? string_14.Trim() : Common.smethod_75(text71 + text70)) : ((!bool_5) ? string_14.Trim() : Common.smethod_75(text58 + text57)));
									method_52(text57, "ho", int_41, 0, dgvAcc);
									method_52(text58, "ten", int_41, 0, dgvAcc);
									method_52((text72 == "1") ? "Nam" : "Nữ", "gender", int_41, 0, dgvAcc);
									method_52(text59, "pass", int_41, 0, dgvAcc);
									text60 = string_11;
									if (bool_16)
									{
										text60 = string_20;
									}
									for (int num47 = 0; num47 < 10; num47++)
									{
										text56 = device.method_93();
										if (device.method_52("DataClick\\fblite\\whatyourname"))
										{
											flag23 = true;
											break;
										}
									}
									if (!flag23)
									{
										method_62(int_41, text3 + "Lỗi khi đăng ký", device);
										method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
										break;
									}
									method_62(int_41, text3 + "Nhập họ", device);
									device.method_49(text57, bool_0: false, bool_1: false);
									device.method_121(2.0);
									method_62(int_41, text3 + "Nhập tên", device);
									device.method_91(176, 165);
									device.method_121(2.0);
									device.method_49(text58, bool_0: false, bool_1: false);
									device.method_121(2.0);
									if (device.method_52("DataClick\\fblite\\next"))
									{
										device.method_3("DataClick\\fblite\\next");
									}
									device.method_121(1.0);
									for (int num48 = 0; num48 < 5; num48++)
									{
										text56 = device.method_93();
										if (!device.method_52("DataClick\\fblite\\yourphone"))
										{
											flag23 = false;
											continue;
										}
										flag23 = true;
										break;
									}
									if (!flag23)
									{
										method_62(int_41, text3 + "Lỗi khi đăng ký", device);
										method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
										break;
									}
									while (true)
									{
										if (!(string_12.Substring(0, 1) == "0"))
										{
											if (bool_0)
											{
												method_62(int_41, text3 + "Dừng chạy...", device);
												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											if (rdThuePhone.Checked)
											{
												try
												{
													int num49 = 0;
													while (true)
													{
														if (num49 != 2)
														{
															method_62(int_41, text3 + "Đang lấy số điện thoại....", device);
															if (string_12.Substring(2, 1) == "0")
															{
																text5 = Common.smethod_47(text60, ref text61);
															}
															else if (string_12.Substring(2, 1) == "1")
															{
																text5 = Common.smethod_57(text60, ref text61);
															}
															else if (string_12.Substring(2, 1) == "2")
															{
																text5 = Common.smethod_21(text60, ref text61);
															}
															else if (string_12.Substring(2, 1) == "3")
															{
																text5 = Common.smethod_48(text60);
																text9 = text5;
															}
															else if (string_12.Substring(2, 1) == "4")
															{
																text5 = Common.smethod_22(text60, ref text61);
															}
															else if (string_12.Substring(2, 1) == "5")
															{
																text5 = Common.smethod_23(text60, ref text61);
															}
															else if (string_12.Substring(2, 1) == "6")
															{
																text5 = Common.smethod_24(text60, ref text61);
															}
															if (!bool_0)
															{
																if (text5 == "")
																{
																	num49++;
																	method_62(int_41, text3 + "Không lấy được số điện thoại. Lấy số khác!!!", device);
																	device.method_121(2.0);
																	continue;
																}
																if (text5 == "Đã hết số điện thoại, chờ cập nhật" && string_12.Substring(2, 1) == "3")
																{
																	method_62(int_41, text3 + "Đã hết số điện thoại...", device);
																	method_49("Đã hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																if (text5 == "API sai" && string_12.Substring(2, 1) == "3")
																{
																	method_62(int_41, text3 + "API sai. Kiểm tra lại API key..", device);
																	method_49("API sai. Kiểm tra lại API key..", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy...", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
																{
																	text5 = "+84" + text5;
																}
																if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "4")
																{
																	text5 = "+1" + text5;
																}
																method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																method_52(text5, "phone", int_41, 0, dgvAcc);
																device.method_121(1.0);
																device.method_91(117, 181);
																device.method_121(1.0);
																device.method_45();
																device.method_121(1.0);
																device.method_49(text5, bool_0: false, bool_1: false);
																flag2 = true;
																device.method_121(1.0);
																if (device.method_52("DataClick\\fblite\\next"))
																{
																	device.method_3("DataClick\\fblite\\next");
																}
																goto IL_9eb2;
															}
															method_62(int_41, text3 + "Dừng chạy...");
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "Đã hết số điện thoại", device);
														method_49("Đã hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
												}
												catch
												{
													method_62(int_41, text3 + "Lỗi khi lấy số điện thoại", device);
													method_49("Lỗi khi lấy số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
												}
												break;
											}
											if (rdConfMail.Checked)
											{
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												if (num4 == 0 && device.method_52("DataClick\\fblite\\registerbymail"))
												{
													device.method_3("DataClick\\fblite\\registerbymail");
												}
												string text73 = string_12.Substring(2, 1);
												int num50 = 0;
												if (text73 != null)
												{
													if (!(text73 == "0"))
													{
														if (!(text73 == "1"))
														{
															method_62(int_41, text3 + "Đang lấy TempMail...", device);
															while (true)
															{
																string text74 = method_73();
																string text75 = Common.smethod_19(text74);
																if (!(text75 != ""))
																{
																	if (num50 != 5)
																	{
																		num50++;
																		continue;
																	}
																	method_62(int_41, text3 + "Lỗi không lấy được tempmail...", device);
																	goto end_IL_a96f;
																}
																method_52(text75, "email", int_41, 0, dgvAcc);
																flag2 = true;
																device.method_91(59, 184);
																device.method_121(1.0);
																device.method_49(text75, bool_0: false, bool_1: false);
																device.method_121(1.0);
																if (device.method_52("DataClick\\fblite\\next"))
																{
																	device.method_3("DataClick\\fblite\\next");
																}
																break;
															}
														}
														else
														{
															string text76 = list_1[int_41];
															if (text76 != "")
															{
																method_62(int_41, text3 + "Nhập hotmail có sẵn....", device);
																text6 = text76.Split('|')[0];
																text7 = text76.Split('|')[1];
																if (bool_0)
																{
																	method_62(int_41, text3 + "Dừng chạy...", device);
																	method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																method_52(text6, "email", int_41, 0, dgvAcc);
																method_52(text7, "passMail", int_41, 0, dgvAcc);
																device.method_91(59, 184);
																device.method_121(1.0);
																device.method_49(text6, bool_0: false, bool_1: false);
																device.method_121(1.0);
																if (device.method_52("DataClick\\fblite\\next"))
																{
																	device.method_3("DataClick\\fblite\\next");
																}
															}
														}
													}
													else
													{
														for (int num51 = 0; num51 < 5; num51++)
														{
															if (!bool_0)
															{
																method_51(2.0);
																method_62(int_41, text3 + "Đăng ký hotmail....", device);
																while (!method_85(int_41))
																{
																	method_52("Đang tạo lại mail khác", "status", int_41, 0, dgvAcc);
																}
																if (!bool_0)
																{
																	text6 = method_39(int_41);
																	text7 = method_40(int_41);
																	File.AppendAllText("output/facebook/hotmail.txt", string.Concat(new string[4]
																	{
																		text6,
																		"|",
																		text7,
																		Environment.NewLine
																	}));
																	device.method_121(1.0);
																	device.method_91(59, 184);
																	device.method_121(1.0);
																	device.method_49(text6, bool_0: false, bool_1: false);
																	if (device.method_52("DataClick\\fblite\\next"))
																	{
																		device.method_3("DataClick\\fblite\\next");
																	}
																	continue;
																}
																method_62(int_41, text3 + "Dừng chạy...");
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_a96f;
															}
															method_62(int_41, text3 + "Dừng chạy...");
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_a96f;
														}
													}
												}
											}
										}
										else
										{
											if (bool_0)
											{
												method_62(int_41, text3 + "Dừng chạy...", device);
												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											if (string_12.Substring(1, 1) == "0")
											{
												method_62(int_41, text3 + "Đang tạo số điện thoại ảo....", device);
												device.method_91(117, 181);
												device.method_121(2.0);
												device.method_45();
												text66 = method_72(int_21);
												method_62(int_41, text3 + "Số điện thoại ảo:" + text66, device);
												method_52(text66, "phone", int_41, 0, dgvAcc);
												device.method_121(1.0);
												device.method_49(text66, bool_0: false, bool_1: false);
												device.method_121(1.0);
												if (device.method_52("DataClick\\fblite\\next"))
												{
													device.method_3("DataClick\\fblite\\next");
												}
											}
											else
											{
												if (device.method_52("DataClick\\fblite\\registerbymail"))
												{
													device.method_3("DataClick\\fblite\\registerbymail");
												}
												device.method_121(1.0);
												device.method_91(27, 182);
												device.method_45();
												if (Convert.ToInt32(string_12.Substring(2, 1)) != 3)
												{
													method_62(int_41, text3 + "Đang tạo Email ảo....", device);
													text65 = method_76(text58, text57, Convert.ToInt32(string_12.Substring(2, 1)));
												}
												else
												{
													method_62(int_41, text3 + "Đang lấy mail từ Temp-mail.io....", device);
													string text77 = method_73();
													text65 = Common.smethod_19(text77);
												}
												if (text65 == string.Empty)
												{
													method_62(int_41, text3 + "Không tạo được email ảo...", device);
													method_49("Không tạo được email ảo", device.int_0, int_41, int_42, device, bool_18: false);
												}
												method_62(int_41, text3 + "Email ảo:" + text65, device);
												method_52(text65, "email", int_41, 0, dgvAcc);
												device.method_121(1.0);
												device.method_49(text65, bool_0: false, bool_1: false);
												device.method_121(1.0);
												if (device.method_52("DataClick\\fblite\\next"))
												{
													device.method_3("DataClick\\fblite\\next");
												}
											}
										}
										goto IL_9eb2;
										IL_a50c:
										if (num45 != 5)
										{
											method_62(int_41, text3 + "Thử nhập lại mật khẩu", device);
											flag22 = true;
											num45++;
											goto IL_a53f;
										}
										bool flag24 = false;
										goto IL_ac6f;
										IL_a6eb:
										method_62(int_41, text3 + "Trùng số. Lấy số khác", device);
										flag21 = true;
										continue;
										IL_d388:
										string text78 = device.method_14(int_42.ToString());
										if (text78 != "")
										{
											text62 = text78.Split('|')[0];
											text64 = text78.Split('|')[1];
											text63 = text78.Split('|')[2];
											method_52(text62, "uid", int_41, 0, dgvAcc);
											method_52(text63, "token", int_41, 0, dgvAcc);
											method_52(text64, "cookie", int_41, 0, dgvAcc);
										}
										if (!flag5 && flag2)
										{
											if (bool_3)
											{
												method_62(int_41, text3 + "Up avatar...", device);
												if (method_65(text62, device))
												{
													method_62(int_41, text3 + "Up avatar thành công", device);
												}
												else
												{
													method_62(int_41, text3 + "Up avatar thất bại", device);
												}
											}
											if (bool_6)
											{
												method_62(int_41, text3 + "Bật 2FA...", device);
												if (method_64(int_41, device))
												{
													method_62(int_41, text3 + "Bật 2FA thành công", device);
												}
												else
												{
													method_62(int_41, text3 + "Bật 2FA thất bại", device);
												}
											}
										}
										string text79 = "";
										text79 = ((int_9 == 5) ? ("|" + method_38(int_41)) : "");
										if (text62 != "")
										{
											if (!flag2)
											{
												if (flag5)
												{
													object obj14 = object_10;
													lock (obj14)
													{
														File.AppendAllText("output/facebook/acc_282.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
													}
												}
												else
												{
													string text80 = method_37(int_41);
													object obj14 = object_7;
													if (text80 != "")
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/Noverify_2fa.txt", text62 + "|" + text59 + "|" + text80 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
														}
													}
													else
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/Noverify.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
														}
													}
												}
											}
											else if (rdThuePhone.Checked || bool_16)
											{
												string text81 = method_37(int_41);
												object obj14 = object_8;
												if (Settings.Default.isThuVeriCheckPoint && flag4)
												{
													if (text81 != "")
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/VerifySdt_checkpoint282_2fa.txt", text62 + "|" + text59 + "|" + text81 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
														}
													}
													else
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/VerifySdt_checkpoint282.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
														}
													}
												}
												else if (text81 != "")
												{
													lock (obj14)
													{
														File.AppendAllText("output/facebook/VerifySdt_2fa.txt", text62 + "|" + text59 + "|" + text81 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
													}
												}
												else
												{
													lock (obj14)
													{
														File.AppendAllText("output/facebook/VerifySdt.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + Environment.NewLine);
													}
												}
											}
											else
											{
												string text82 = method_37(int_41);
												object obj14 = object_9;
												if (rdHotMailReg.Checked || rdHotMailRegisted.Checked)
												{
													if (text82 != "")
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/VerifyHotMail_2fa.txt", text62 + "|" + text59 + "|" + text82 + "|" + text63 + "|" + text64 + "|" + text6 + "|" + text7 + "|" + text79 + Environment.NewLine);
														}
													}
													else
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/VerifyHotMail.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text6 + "|" + text7 + "|" + text79 + Environment.NewLine);
														}
													}
												}
												else if (rdTempMailIO.Checked)
												{
													if (text82 != "")
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/Verify_tempmail_2fa.txt", text62 + "|" + text59 + "|" + text82 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
														}
													}
													else
													{
														lock (obj14)
														{
															File.AppendAllText("output/facebook/Verify_tempmail.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
														}
													}
												}
												else if (bool_17)
												{
													if (Settings.Default.isThuVeriCheckPoint && flag4)
													{
														if (int_38 == 0)
														{
															if (text82 != "")
															{
																lock (obj14)
																{
																	File.AppendAllText("output/facebook/VerifyMail_checkpoint282_2fa.txt", text62 + "|" + text59 + "|" + text82 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
																}
															}
															else
															{
																lock (obj14)
																{
																	File.AppendAllText("output/facebook/VerifyMail_checkpoint282.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
																}
															}
														}
													}
													else if (int_38 == 0)
													{
														if (text82 != "")
														{
															lock (obj14)
															{
																File.AppendAllText("output/facebook/Verify_tempmail_2fa.txt", text62 + "|" + text59 + "|" + text82 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
															}
														}
														else
														{
															lock (obj14)
															{
																File.AppendAllText("output/facebook/Verify_tempmail.txt", text62 + "|" + text59 + "|" + text63 + "|" + text64 + "|" + text79 + "|" + method_39(int_41) + Environment.NewLine);
															}
														}
													}
												}
											}
										}
										if (Settings.Default.isCheckUID)
										{
											method_62(int_41, text3 + "Check uid và wall...", device);
											device.method_121(1.0);
											if (method_48(text62) && Common.smethod_33(text62).StartsWith("0|"))
											{
												method_42(int_41, "Live");
												if (flag5)
												{
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
												}
												else
												{
													method_49("Tạo tài khoản thành công", device.int_0, int_41, int_42, device, bool_18: true);
												}
											}
											else
											{
												method_42(int_41, "Die");
												method_49("Tài khoản die!!!", device.int_0, int_41, int_42, device, bool_18: false);
											}
										}
										else if (flag5)
										{
											method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
										}
										else
										{
											method_49("Tạo tài khoản thành công", device.int_0, int_41, int_42, device, bool_18: true);
										}
										break;
										IL_ac06:
										if (Settings.Default.isThuVeriCheckPoint)
										{
											method_62(int_41, text3 + "Checkpoint...thử xác nhận", device);
											flag3 = true;
											goto IL_aca6;
										}
										method_62(int_41, text3 + "Checkpoint 282!!!", device);
										flag5 = true;
										flag2 = false;
										method_42(int_41, "Checkpoint");
										goto IL_d388;
										IL_aca6:
										string text86;
										if (flag3)
										{
											if (bool_0)
											{
												method_62(int_41, text3 + "Dừng chạy...", device);
												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											device.method_99("\"tiếp tục\"");
											for (int num52 = 0; num52 < 5; num52++)
											{
												text56 = device.method_93();
												if (device.method_82("giúp chúng tôi xác nhận đó là bạn", text56))
												{
													method_62(int_41, "Captcha...Không xác thực", device);
													method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
													goto end_IL_a96f;
												}
											}
											if (bool_16 || rdThuePhone.Checked)
											{
												int num53 = 0;
												while (true)
												{
													if (num53 == 0)
													{
														method_62(int_41, text3 + "Đang lấy số điện thoại...", device);
													}
													else
													{
														if (bool_0)
														{
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "Lấy số khác...Lần: " + num53, device);
														device.method_121(1.0);
														int tickCount4 = Environment.TickCount;
														while ((Environment.TickCount - tickCount4) / 1000 - int_39 < 0)
														{
															if (!bool_0)
															{
																method_62(int_41, "Thời gian lấy số tiếp theo {time}s...".Replace("{time}", (int_39 - (Environment.TickCount - tickCount4) / 1000).ToString()), device);
																continue;
															}
															method_62(int_41, "Dừng chạy!", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_b4a0;
														}
													}
													text5 = "";
													if (bool_16)
													{
														if (int_37 == 0)
														{
															text5 = Common.smethod_21(text60, ref text61);
														}
														else if (int_37 == 1)
														{
															text5 = Common.smethod_48(text60);
															text9 = text5;
														}
														else if (int_37 == 2)
														{
															text5 = Common.smethod_22(text60, ref text61);
														}
														else if (int_37 == 3)
														{
															text5 = Common.smethod_23(text60, ref text61);
														}
														else if (int_37 == 4)
														{
															text5 = Common.smethod_24(text60, ref text61);
														}
													}
													else if (string_12.Substring(2, 1) == "0")
													{
														text5 = Common.smethod_47(text60, ref text61);
													}
													else if (string_12.Substring(2, 1) == "1")
													{
														text5 = Common.smethod_57(text60, ref text61);
													}
													else if (string_12.Substring(2, 1) == "2")
													{
														text5 = Common.smethod_21(text60, ref text61);
													}
													else if (string_12.Substring(2, 1) == "3")
													{
														text5 = Common.smethod_48(text60);
														text9 = text5;
													}
													else if (string_12.Substring(2, 1) == "4")
													{
														text5 = Common.smethod_22(text60, ref text61);
													}
													else if (string_12.Substring(2, 1) == "5")
													{
														text5 = Common.smethod_23(text60, ref text61);
													}
													else if (string_12.Substring(2, 1) == "6")
													{
														text5 = Common.smethod_24(text60, ref text61);
													}
													if (text5 != "")
													{
														if (!(text5 == "API sai"))
														{
															if (text5 == "Đã hết số điện thoại, chờ cập nhật")
															{
																method_62(int_41, text3 + "Hết số điện thoại. Chuyển sang noveri", device);
																flag2 = false;
																device.method_12();
															}
															if (int_37 == 0 || int_37 == 1 || int_37 == 2)
															{
																text5 = "+1" + text5;
															}
															if (device.method_52("DataClick\\image\\inputsdtemail"))
															{
																device.method_3("DataClick\\image\\inputsdtemail");
															}
															else
															{
																device.method_99("nhập số điện thoại hoặc email mới");
															}
															method_62(int_41, text3 + "Số điện thoại:" + text5, device);
															method_52(text5, "phone", int_41, 0, dgvAcc);
															device.method_121(1.0);
															device.method_102(text5);
															device.method_121(1.0);
															if (device.method_52("DataClick\\image\\sendcodeotp"))
															{
																device.method_3("DataClick\\image\\sendcodeotp");
															}
															else
															{
																device.method_99("gửi mã đăng nhập");
															}
															bool flag25 = false;
															for (int num54 = 0; num54 < 5; num54++)
															{
																text56 = device.method_93();
																if (device.method_82("nhập mã mà chúng tôi vừa gửi qua tin nhắn văn bản", text56))
																{
																	flag25 = true;
																	break;
																}
															}
															if (flag25)
															{
																method_62(int_41, text3 + "Đang lấy mã OTP...", device);
																string text83 = string.Empty;
																if (bool_16)
																{
																	if (int_37 == 0)
																	{
																		text83 = Common.smethod_26(text60, text61, int_14);
																	}
																	else if (int_37 == 1)
																	{
																		text83 = Common.smethod_28(text60, text9, int_14);
																	}
																	else if (int_37 == 2)
																	{
																		text83 = Common.smethod_27(text60, text61, int_14);
																	}
																	else if (int_37 == 3)
																	{
																		text83 = Common.smethod_45(text60, text61, int_14);
																	}
																	else if (int_37 == 4)
																	{
																		text83 = Common.smethod_46(text60, text61, int_14);
																	}
																}
																else if (string_12.Substring(2, 1) == "0")
																{
																	text83 = Common.smethod_44(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "1")
																{
																	text83 = Common.smethod_61(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "2")
																{
																	text83 = Common.smethod_26(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "3")
																{
																	text83 = Common.smethod_28(text60, text9, int_14);
																}
																else if (string_12.Substring(2, 1) == "4")
																{
																	text83 = Common.smethod_27(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "5")
																{
																	text83 = Common.smethod_45(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "6")
																{
																	text83 = Common.smethod_46(text60, text61, int_14);
																}
																if (!(text83 != ""))
																{
																	if (num53 != 5)
																	{
																		if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
																		{
																			device.method_3("DataClick\\image\\capnhatthongtinlienhe");
																		}
																		else
																		{
																			device.method_99("cập nhật thông tin liên hệ");
																		}
																		num53++;
																		continue;
																	}
																	method_62(int_41, text3 + "Hết số điện thoại", device);
																	method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																if (device.method_52("DataClick\\image\\inputotpckp"))
																{
																	device.method_3("DataClick\\image\\inputotpckp");
																}
																else
																{
																	device.method_91(32, 173);
																}
																device.method_121(1.0);
																device.method_102(text83);
																device.method_121(1.0);
																device.method_99("\"tiếp\"");
																bool flag26 = false;
																for (int num55 = 0; num55 < 20; num55++)
																{
																	text56 = device.method_93();
																	if (device.method_82("bạn có thể dùng facebook", text56))
																	{
																		flag26 = true;
																		flag4 = true;
																		flag2 = true;
																		break;
																	}
																}
																if (flag26)
																{
																	if (device.method_52("DataClick\\image\\truycapfacebook"))
																	{
																		device.method_3("DataClick\\image\\truycapfacebook");
																	}
																	else
																	{
																		device.method_91(160, 165);
																	}
																	device.method_121(1.0);
																}
																else
																{
																	method_62(int_41, text3 + "Checkpoint 282. Lưu acc", device);
																	method_42(int_41, "Checkpoint");
																	flag5 = true;
																}
																goto IL_d388;
															}
															if (num53 != 5)
															{
																device.method_44("nhập số điện thoại hoặc email mới");
																num53++;
																continue;
															}
															method_62(int_41, text3 + "Hết số điện thoại", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "API key sai...", device);
														method_49("API key sai", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													if (text5 == "Đã hết số điện thoại, chờ cập nhật")
													{
														method_62(int_41, text3 + "Hết số điện thoại", device);
														method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
													}
													else
													{
														method_62(int_41, text3 + "Hết số điện thoại", device);
														method_49("Hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
													}
													break;
													continue;
													end_IL_b4a0:
													break;
												}
												break;
											}
											if (bool_17 || rdConfMail.Checked)
											{
												if (rdConfMail.Checked)
												{
													if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
													{
														device.method_3("DataClick\\image\\capnhatthongtinlienhe");
													}
													else
													{
														device.method_99("cập nhật thông tin liên hệ");
													}
												}
												int num56 = 0;
												while (true)
												{
													method_62(int_41, text3 + "Đang lấy tempmail.io", device);
													string text84 = "";
													string text85 = method_73();
													if (int_38 == 0)
													{
														text84 = Common.smethod_19(text85);
													}
													if (!(text84 != ""))
													{
														break;
													}
													if (device.method_52("DataClick\\image\\inputsdtemail"))
													{
														device.method_3("DataClick\\image\\inputsdtemail");
														method_62(int_41, text3 + "TempMail:" + text84, device);
														method_52(text84, "email", int_41, 0, dgvAcc);
														device.method_121(1.0);
														device.method_102(text84);
														device.method_121(1.0);
														if (device.method_52("DataClick\\image\\sendcodeotp"))
														{
															device.method_3("DataClick\\image\\sendcodeotp");
														}
														else
														{
															device.method_99("gửi mã đăng nhập");
														}
													}
													bool flag27 = false;
													for (int num57 = 0; num57 < 5; num57++)
													{
														text56 = device.method_93();
														if (device.method_82("nhập mã xác nhận", text56))
														{
															flag27 = true;
															break;
														}
													}
													if (flag27)
													{
														method_62(int_41, text3 + "Đang lấy mã OTP...", device);
														text86 = Common.smethod_20(method_39(int_41));
														if (!(text86 != ""))
														{
															if (num56 != 5)
															{
																if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
																{
																	device.method_3("DataClick\\image\\capnhatthongtinlienhe");
																}
																else
																{
																	device.method_99("cập nhật thông tin liên hệ");
																}
																num56++;
																continue;
															}
															method_62(int_41, text3 + "Không thể xác thực tài khoản", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															goto end_IL_a96f;
														}
														goto IL_b9eb;
													}
													if (num56 != 5)
													{
														if (device.method_52("DataClick\\image\\capnhatthongtinlienhe"))
														{
															device.method_3("DataClick\\image\\capnhatthongtinlienhe");
														}
														else
														{
															device.method_99("cập nhật thông tin liên hệ");
														}
														num56++;
														continue;
													}
													method_62(int_41, text3 + "Không thể xác thực tài khoản", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													goto end_IL_a96f;
												}
											}
										}
										goto IL_bf36;
										IL_9eb2:
										if (!bool_0)
										{
											if (!flag21)
											{
												for (int num58 = 0; num58 < 5; num58++)
												{
													text56 = device.method_93();
													if (!device.method_52("DataClick\\fblite\\yourbirthday"))
													{
														flag23 = false;
														continue;
													}
													flag23 = true;
													break;
												}
												if (flag23)
												{
													method_62(int_41, text3 + "Nhập ngày sinh....", device);
													List<string> list3 = new List<string>();
													list3.Add("160,468");
													list3.Add("54,393");
													list3.Add("160,392");
													list3.Add("267,392");
													list3.Add("53,417");
													list3.Add("160,415");
													list3.Add("268,414");
													list3.Add("52,441");
													list3.Add("160,443");
													list3.Add("268,440");
													List<string> list4 = list3;
													text68 = random_0.Next(1, 12).ToString();
													text67 = random_0.Next(1, 28).ToString();
													text69 = random_0.Next(Convert.ToInt32(DateTime.Now.Year.ToString()) - int_16, Convert.ToInt32(DateTime.Now.Year.ToString()) - int_15).ToString();
													method_52((Convert.ToInt32(DateTime.Now.Year.ToString()) - Convert.ToInt32(text69)).ToString(), "age", int_41, 0, dgvAcc);
													if (text68.Length < 2)
													{
														text68 = "0" + text68;
													}
													if (text67.Length < 2)
													{
														text67 = "0" + text67;
													}
													device.method_121(1.0);
													char[] array3 = text67.ToCharArray();
													foreach (char c in array3)
													{
														int index = Convert.ToInt32(c.ToString());
														device.method_47(Convert.ToInt32(list4[index].Split(',')[0]), Convert.ToInt32(list4[index].Split(',')[1]));
													}
													device.method_121(1.0);
													char[] array4 = text68.ToCharArray();
													foreach (char c2 in array4)
													{
														int index2 = Convert.ToInt32(c2.ToString());
														device.method_47(Convert.ToInt32(list4[index2].Split(',')[0]), Convert.ToInt32(list4[index2].Split(',')[1]));
													}
													device.method_121(1.0);
													char[] array5 = text69.ToCharArray();
													foreach (char c3 in array5)
													{
														int index3 = Convert.ToInt32(c3.ToString());
														device.method_47(Convert.ToInt32(list4[index3].Split(',')[0]), Convert.ToInt32(list4[index3].Split(',')[1]));
													}
													device.method_121(1.0);
													if (device.method_52("DataClick\\fblite\\next"))
													{
														device.method_3("DataClick\\fblite\\next");
													}
													device.method_121(1.0);
													if (!bool_0)
													{
														for (int num62 = 0; num62 < 5; num62++)
														{
															text56 = device.method_93();
															if (!device.method_52("DataClick\\fblite\\yourgender"))
															{
																flag23 = false;
																continue;
															}
															flag23 = true;
															break;
														}
														if (flag23)
														{
															method_62(int_41, text3 + "Chọn giới tính....", device);
															if (text72 == "0")
															{
																device.method_91(300, 169);
															}
															else if (text72 == "1")
															{
																device.method_91(303, 200);
															}
															device.method_121(1.0);
															if (!bool_0)
															{
																for (int num63 = 0; num63 < 5; num63++)
																{
																	text56 = device.method_93();
																	if (!device.method_52("DataClick\\fblite\\createpass"))
																	{
																		flag23 = false;
																		continue;
																	}
																	flag23 = true;
																	break;
																}
																if (!flag23)
																{
																	method_62(int_41, text3 + "Lỗi khi đăng ký", device);
																	method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
																	break;
																}
																goto IL_a53f;
															}
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "Lỗi khi đăng ký", device);
														method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												method_62(int_41, text3 + "Lỗi khi đăng ký", device);
												method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											goto IL_a6c7;
										}
										method_62(int_41, text3 + "Dừng chạy...", device);
										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
										break;
										IL_bf36:
										method_62(int_41, text3 + "Lưu thông tin đăng nhập..", device);
										device.method_91(233, 455);
										while (true)
										{
											if (string_12.Substring(0, 1) == "0" && !flag2)
											{
												if (bool_16)
												{
													device.method_121(1.0);
													device.method_91(53, 292);
													device.method_121(1.0);
													while (true)
													{
														if (num2 == 0)
														{
															method_62(int_41, text3 + "Đang lấy số điện thoại...", device);
														}
														else
														{
															method_62(int_41, text3 + "Lấy số khác...Lần: " + num2, device);
															device.method_121(1.0);
															int tickCount5 = Environment.TickCount;
															while ((Environment.TickCount - tickCount5) / 1000 - int_39 < 0)
															{
																if (!bool_0)
																{
																	method_62(int_41, "Thời gian lấy số tiếp theo {time}s...".Replace("{time}", (int_39 - (Environment.TickCount - tickCount5) / 1000).ToString()), device);
																	continue;
																}
																method_62(int_41, "Dừng chạy!", device);
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_c2be;
															}
														}
														text5 = "";
														if (int_37 == 0)
														{
															text5 = Common.smethod_21(text60, ref text61);
														}
														else if (int_37 == 1)
														{
															text5 = Common.smethod_48(text60);
															text9 = text5;
														}
														else if (int_37 == 2)
														{
															text5 = Common.smethod_22(text60, ref text61);
														}
														else if (int_37 == 3)
														{
															text5 = Common.smethod_23(text60, ref text61);
														}
														else if (int_37 == 4)
														{
															text5 = Common.smethod_24(text60, ref text61);
														}
														if (text5 != "")
														{
															if (!(text5 == "API sai"))
															{
																if (!(text5 == "Đã hết số điện thoại, chờ cập nhật"))
																{
																	if (int_37 == 0 || int_37 == 1 || int_37 == 2)
																	{
																		text5 = "+1" + text5;
																	}
																	method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																	method_52(text5, "phone", int_41, 0, dgvAcc);
																	device.method_121(1.0);
																	device.method_91(300, 110);
																	device.method_121(1.0);
																	device.method_45();
																	device.method_121(1.0);
																	device.method_49(text5, bool_0: false, bool_1: false);
																	device.method_121(1.0);
																	if (device.method_52("DataClick\\fblite\\next"))
																	{
																		device.method_3("DataClick\\fblite\\next");
																	}
																	bool flag28 = false;
																	for (int num64 = 0; num64 < 10; num64++)
																	{
																		if (!device.method_52("DataClick\\fblite\\inputsmsopt"))
																		{
																			flag28 = true;
																			continue;
																		}
																		flag28 = false;
																		break;
																	}
																	if (!flag28)
																	{
																		goto IL_c2cd;
																	}
																	if (num2 != 5)
																	{
																		device.method_121(1.0);
																		device.method_91(53, 292);
																		device.method_121(1.0);
																		device.method_91(300, 110);
																		device.method_121(1.0);
																		device.method_45();
																		num2++;
																		continue;
																	}
																	goto IL_c54b;
																}
																goto IL_c574;
															}
															method_62(int_41, text3 + "API key sai...", device);
															method_49("API key sai", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														if (num2 != 5)
														{
															num2++;
															continue;
														}
														goto IL_c5c4;
														continue;
														end_IL_c2be:
														break;
													}
													break;
												}
												if (bool_17)
												{
													device.method_121(1.0);
													device.method_91(53, 321);
													device.method_121(1.0);
													method_62(int_41, text3 + "Đang lấy tempmail.io", device);
													string text87 = "";
													while (true)
													{
														string text88 = method_73();
														if (int_38 == 0)
														{
															text87 = Common.smethod_19(text88);
														}
														if (text87 != "")
														{
															method_52(text87, "email", int_41, 0, dgvAcc);
															device.method_91(300, 110);
															device.method_121(1.0);
															device.method_45();
															device.method_121(1.0);
															device.method_49(text87, bool_0: false, bool_1: false);
															device.method_121(1.0);
															if (device.method_52("DataClick\\fblite\\next"))
															{
																device.method_3("DataClick\\fblite\\next");
															}
															bool flag29 = false;
															for (int num65 = 0; num65 < 10; num65++)
															{
																text56 = device.method_93();
																if (!device.method_52("DataClick\\fblite\\inputsmsopt"))
																{
																	flag29 = true;
																	continue;
																}
																flag29 = false;
																break;
															}
															if (!flag29)
															{
																break;
															}
															if (num3 != 5)
															{
																device.method_121(1.0);
																device.method_91(53, 321);
																device.method_121(1.0);
																device.method_91(300, 110);
																device.method_121(1.0);
																device.method_45();
																num3++;
																method_62(int_41, text3 + "Lấy mail khác...Lần: " + num3, device);
																continue;
															}
															goto IL_c5e8;
														}
														if (num3 != 5)
														{
															num3++;
															method_62(int_41, text3 + "Lấy mail khác...Lần: " + num3, device);
															continue;
														}
														goto IL_c611;
													}
													flag2 = true;
													continue;
												}
												flag2 = false;
												device.method_125();
												goto IL_d388;
											}
											while (true)
											{
												if (rdThuePhone.Checked || bool_16)
												{
													int num66 = 0;
													int num67 = 0;
													while (num67 < 2)
													{
														if (!bool_0)
														{
															method_62(int_41, text3 + "Đang lấy mã OTP...", device);
															string text89 = string.Empty;
															if (rdThuePhone.Checked)
															{
																if (string_12.Substring(2, 1) == "0")
																{
																	text89 = Common.smethod_44(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "1")
																{
																	text89 = Common.smethod_61(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "2")
																{
																	text89 = Common.smethod_26(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "3")
																{
																	text89 = Common.smethod_28(text60, text9, int_14);
																}
																else if (string_12.Substring(2, 1) == "4")
																{
																	text89 = Common.smethod_27(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "5")
																{
																	text89 = Common.smethod_45(text60, text61, int_14);
																}
																else if (string_12.Substring(2, 1) == "6")
																{
																	text89 = Common.smethod_46(text60, text61, int_14);
																}
															}
															else if (bool_16)
															{
																if (int_37 == 0)
																{
																	text89 = Common.smethod_26(text60, text61, int_14);
																}
																else if (int_37 == 1)
																{
																	text89 = Common.smethod_28(text60, text9, int_14);
																}
																else if (int_37 == 2)
																{
																	text89 = Common.smethod_27(text60, text61, int_14);
																}
																else if (int_37 == 3)
																{
																	text89 = Common.smethod_45(text60, text61, int_14);
																}
																else if (int_37 == 4)
																{
																	text89 = Common.smethod_46(text60, text61, int_14);
																}
															}
															if (text89 == "")
															{
																if (!bool_0)
																{
																	num66++;
																	method_62(int_41, text3 + "Không lấy được mã OTP...", device);
																	if (!device.method_52("DataClick\\fblite\\inputsmsopt"))
																	{
																		if (num66 == 5)
																		{
																			flag2 = false;
																			device.method_125();
																		}
																		num67++;
																		continue;
																	}
																	goto IL_c952;
																}
																method_62(int_41, text3 + "Dừng chạy...");
																method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
																goto end_IL_cdda;
															}
															flag2 = true;
															method_62(int_41, text3 + "Mã OTP:" + text89, device);
															device.method_91(154, 177);
															device.method_121(1.0);
															device.method_49(text89, bool_0: false, bool_1: false);
															device.method_121(1.0);
															device.method_91(160, 211);
															break;
														}
														method_62(int_41, text3 + "Dừng chạy...", device);
														method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
														goto end_IL_cdda;
													}
												}
												else if (rdConfMail.Checked)
												{
													method_62(int_41, text3 + "Đang lấy mã OTP...", device);
													if (bool_0)
													{
														method_62(int_41, text3 + "Dừng chạy...", device);
														method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
														break;
													}
													string text90 = string_12.Substring(2, 1);
													if (text90 != null)
													{
														if (!(text90 == "0"))
														{
															if (!(text90 == "1"))
															{
																string text91 = Common.smethod_20(method_39(int_41));
																if (!(text91 != ""))
																{
																	method_62(int_41, text3 + "Mail không nhận OTP - NoVeri account. Goto", device);
																	flag2 = false;
																	device.method_124();
																	goto IL_d388;
																}
																device.method_91(154, 177);
																device.method_121(1.0);
																device.method_49(text91, bool_0: false, bool_1: false);
																device.method_121(1.0);
																device.method_91(160, 211);
															}
														}
														else
														{
															string text92 = Common.smethod_31(text6, text7);
															if (text92 == "")
															{
																flag2 = false;
																method_52("Mail không nhận được OTP. Goto Newfeed", "status", int_41, 2, dgvAcc);
																device.method_124();
															}
															if (text92.Contains("kcon"))
															{
																flag2 = false;
																method_52("Không kê\u0301t nô\u0301i đươ\u0323c server hotmail!", "status", int_41, 2, dgvAcc);
																device.method_124();
															}
															flag2 = true;
															device.method_121(1.0);
															device.method_91(154, 177);
															device.method_121(1.0);
															device.method_49(text92, bool_0: false, bool_1: false);
															device.method_121(1.0);
															device.method_91(160, 211);
														}
													}
												}
												else if (bool_17)
												{
													string text93 = Common.smethod_20(method_39(int_41));
													if (!(text93 != ""))
													{
														method_62(int_41, text3 + "Mail không nhận OTP - NoVeri account. Goto", device);
														flag2 = false;
														device.method_124();
														goto IL_d388;
													}
													device.method_91(137, 180);
													device.method_121(1.0);
													flag2 = true;
													device.method_49(text93, bool_0: false, bool_1: false);
													device.method_121(1.0);
													device.method_91(160, 211);
												}
												goto IL_d253;
												IL_d253:
												device.method_121(10.0);
												for (int num68 = 0; num68 < 10; num68++)
												{
													if (device.method_52("DataClick\\fblite\\skip"))
													{
														device.method_3("DataClick\\fblite\\skip");
														break;
													}
												}
												device.method_121(1.0);
												if (device.method_52("DataClick\\fblite\\skip"))
												{
													device.method_3("DataClick\\fblite\\skip");
												}
												device.method_121(5.0);
												text56 = device.method_93();
												if (device.method_82("thêm bạn bè", text56))
												{
													device.method_3("DataClick\\fblite\\skip");
													device.method_121(1.0);
													device.method_91(153, 320);
												}
												device.method_121(1.0);
												device.method_91(133, 311);
												if (bool_0)
												{
													method_62(int_41, text3 + "Dừng chạy...", device);
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												goto IL_d388;
												IL_c952:
												if (!bool_0)
												{
													device.method_121(1.0);
													device.method_91(53, 292);
													device.method_121(1.0);
													while (true)
													{
														method_62(int_41, text3 + "Đang lấy số điện thoại khác...", device);
														if (!rdThuePhone.Checked)
														{
															if (bool_16)
															{
																if (int_37 == 0)
																{
																	text5 = Common.smethod_21(text60, ref text61);
																}
																else if (int_37 == 1)
																{
																	text5 = Common.smethod_48(text60);
																	text9 = text5;
																}
																else if (int_37 == 2)
																{
																	text5 = Common.smethod_22(text60, ref text61);
																}
																else if (int_37 == 3)
																{
																	text5 = Common.smethod_23(text60, ref text61);
																}
																else if (int_37 == 4)
																{
																	text5 = Common.smethod_24(text60, ref text61);
																}
															}
														}
														else if (string_12.Substring(2, 1) == "0")
														{
															text5 = Common.smethod_47(text60, ref text61);
														}
														else if (string_12.Substring(2, 1) == "1")
														{
															text5 = Common.smethod_57(text60, ref text61);
														}
														else if (string_12.Substring(2, 1) == "2")
														{
															text5 = Common.smethod_21(text60, ref text61);
														}
														else if (string_12.Substring(2, 1) == "3")
														{
															text5 = Common.smethod_48(text60);
															text9 = text5;
														}
														else if (string_12.Substring(2, 1) == "4")
														{
															text5 = Common.smethod_22(text60, ref text61);
														}
														else if (string_12.Substring(2, 1) == "5")
														{
															text5 = Common.smethod_23(text60, ref text61);
														}
														else if (string_12.Substring(2, 1) == "6")
														{
															text5 = Common.smethod_24(text60, ref text61);
														}
														if (!(text5 == ""))
														{
															break;
														}
														if (!bool_0)
														{
															method_62(int_41, text3 + "Không lấy được số điện thoại. Lấy số khác", device);
															continue;
														}
														method_62(int_41, text3 + "Dừng chạy...", device);
														method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
														goto end_IL_cdda;
													}
													if (!(text5 == "Đã hết số điện thoại, chờ cập nhật") || !(string_12.Substring(2, 1) == "3"))
													{
														if (!(text5 == "API sai"))
														{
															if (!bool_0)
															{
																if (rdThuePhone.Checked)
																{
																	if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
																	{
																		text5 = "+84" + text5;
																	}
																	if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "4")
																	{
																		text5 = "+1" + text5;
																	}
																}
																else if (bool_16)
																{
																	if (int_37 == 3)
																	{
																		text5 = "+84" + text5;
																	}
																	if (int_37 == 0 || int_37 == 1 || int_37 == 2)
																	{
																		text5 = "+1" + text5;
																	}
																}
																method_62(int_41, text3 + "Số điện thoại:" + text5, device);
																method_52(text5, "phone", int_41, 0, dgvAcc);
																device.method_121(1.0);
																device.method_91(64, 104);
																device.method_121(1.0);
																device.method_45();
																device.method_121(1.0);
																device.method_49(text5, bool_0: false, bool_1: false);
																device.method_121(1.0);
																device.method_3("DataClick\\fblite\\next1", null, 5);
																device.method_121(1.0);
																continue;
															}
															method_62(int_41, text3 + "Dừng chạy...", device);
															method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
															break;
														}
														method_62(int_41, text3 + "API key sai...Kiểm tra lại", device);
														method_49("API key sai...Kiểm tra lại", device.int_0, int_41, int_42, device, bool_18: false);
													}
													else
													{
														method_62(int_41, text3 + "Đã hết số điện thoại...", device);
														method_49("Đã hết số điện thoại", device.int_0, int_41, int_42, device, bool_18: false);
													}
												}
												else
												{
													method_62(int_41, text3 + "Dừng chạy...");
													method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												}
												goto IL_d253;
												continue;
												end_IL_cdda:
												break;
											}
											break;
											IL_c5c4:
											method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
											flag2 = false;
											device.method_125();
											goto IL_d388;
											IL_c611:
											method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
											flag2 = false;
											device.method_125();
											goto IL_d388;
											IL_c574:
											method_62(int_41, text3 + "Hết số điện thoại. Chuyển sang noveri", device);
											flag2 = false;
											device.method_125();
											goto IL_d388;
											IL_c5e8:
											method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
											flag2 = false;
											device.method_126("");
											goto IL_d388;
											IL_c54b:
											method_62(int_41, text3 + "Không veri được. Chuyển sang noveri" + text5, device);
											flag2 = false;
											device.method_12();
											goto IL_d388;
											IL_c2cd:
											flag2 = true;
										}
										break;
										IL_ac56:
										method_62(int_41, text3 + "Đăng ký thành công..", device);
										flag24 = true;
										goto IL_ac6f;
										IL_ac6f:
										if (!flag24)
										{
											method_62(int_41, text3 + "Đăng ký không thành công..", device);
											method_49("Đăng ký không thành công", device.int_0, int_41, int_42, device, bool_18: false);
											break;
										}
										goto IL_aca6;
										IL_b9eb:
										if (device.method_52("DataClick\\image\\inputotpckp"))
										{
											device.method_3("DataClick\\image\\inputotpckp");
										}
										else
										{
											device.method_91(32, 173);
										}
										device.method_121(1.0);
										device.method_102(text86);
										device.method_99("\"tiếp\"");
										bool flag30 = false;
										for (int num69 = 0; num69 < 20; num69++)
										{
											text56 = device.method_93();
											if (device.method_82("bạn có thể dùng facebook", text56))
											{
												flag30 = true;
												flag4 = true;
												flag2 = true;
												break;
											}
										}
										if (flag30)
										{
											if (device.method_52("DataClick\\image\\truycapfacebook"))
											{
												device.method_3("DataClick\\image\\truycapfacebook");
											}
											else
											{
												device.method_91(160, 165);
											}
											device.method_121(1.0);
											goto IL_d388;
										}
										if (device.method_52("DataClick\\fblite\\yeucauxemxet"))
										{
											device.method_3("DataClick\\fblite\\yeucauxemxet");
										}
										device.method_121(1.0);
										while (true)
										{
											method_62(int_41, text3 + "Đang lấy số điện thoại...", device);
											text5 = "";
											if (!bool_16)
											{
												if (string_12.Substring(2, 1) == "0")
												{
													text5 = Common.smethod_47(text60, ref text61);
												}
												else if (string_12.Substring(2, 1) == "1")
												{
													text5 = Common.smethod_57(text60, ref text61);
												}
												else if (string_12.Substring(2, 1) == "2")
												{
													text5 = Common.smethod_21(text60, ref text61);
												}
												else if (string_12.Substring(2, 1) == "3")
												{
													text5 = Common.smethod_48(text60);
													text9 = text5;
												}
												else if (string_12.Substring(2, 1) == "4")
												{
													text5 = Common.smethod_22(text60, ref text61);
												}
												else if (string_12.Substring(2, 1) == "5")
												{
													text5 = Common.smethod_23(text60, ref text61);
												}
												else if (string_12.Substring(2, 1) == "6")
												{
													text5 = Common.smethod_24(text60, ref text61);
												}
											}
											else if (int_37 == 0)
											{
												text5 = Common.smethod_21(text60, ref text61);
											}
											else if (int_37 == 1)
											{
												text5 = Common.smethod_48(text60);
												text9 = text5;
											}
											else if (int_37 == 2)
											{
												text5 = Common.smethod_22(text60, ref text61);
											}
											else if (int_37 == 3)
											{
												text5 = Common.smethod_23(text60, ref text61);
											}
											else if (int_37 == 4)
											{
												text5 = Common.smethod_24(text60, ref text61);
											}
											if (text5 != "")
											{
												break;
											}
											device.method_91(270, 195);
											device.method_45();
										}
										if (bool_0)
										{
											method_62(int_41, text3 + "Dừng chạy...", device);
											method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
											break;
										}
										if (rdThuePhone.Checked)
										{
											if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
											{
												text5 = "+84" + text5;
											}
											if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "3" || string_12.Substring(2, 1) == "4")
											{
												text5 = "+1" + text5;
											}
										}
										else if (bool_16)
										{
											if (int_37 == 3)
											{
												text5 = "+84" + text5;
											}
											if (int_37 == 0 || int_37 == 1 || int_37 == 2)
											{
												text5 = "+1" + text5;
											}
										}
										device.method_91(270, 195);
										device.method_121(1.0);
										device.method_49(text5, bool_0: false, bool_1: false);
										device.method_121(1.0);
										device.method_91(160, 382);
										goto IL_bf36;
										IL_a6c7:
										while (true)
										{
											flag24 = false;
											method_62(int_41, text3 + "Check status đăng ký....", device);
											if (flag21)
											{
												device.method_121(10.0);
											}
											int num70 = 0;
											while (true)
											{
												text56 = device.method_93();
												if (!bool_0)
												{
													if (num70 != 30)
													{
														num70++;
														if (!device.method_52("DataClick\\fblite\\luuthongtindangnhap"))
														{
															if (!device.method_82("we need more information", text56) && !device.method_82("Something went wrong. Please try again.", text56) && !device.method_82("chúng tôi cần thêm thông tin", text56))
															{
																if (device.method_52("DataClick\\fblite\\yourphone"))
																{
																	goto IL_a6eb;
																}
																if (device.method_52("DataClick\\fblite\\whatyourname"))
																{
																	goto IL_a686;
																}
																if (!device.method_52("DataClick\\fblite\\createpass"))
																{
																	continue;
																}
																goto IL_a50c;
															}
															goto IL_ac06;
														}
														goto IL_ac56;
													}
													method_62(int_41, text3 + "Không check được status...");
													method_49("Không check được status đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												method_62(int_41, text3 + "Dừng chạy...", device);
												method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
												break;
											}
											break;
											IL_a686:
											method_62(int_41, text3 + "Trùng tên...", device);
											flag21 = true;
											device.method_91(175, 180);
										}
										break;
										IL_a53f:
										method_62(int_41, text3 + "Nhập mật khẩu....", device);
										device.method_46("shell ime set cz.october.app/.KeyboardReceiver");
										device.method_91(44, 176);
										device.method_121(1.0);
										device.method_45();
										device.method_121(1.0);
										device.method_49(text59, bool_0: false, bool_1: false);
										device.method_121(1.0);
										if (device.method_52("DataClick\\fblite\\next"))
										{
											device.method_3("DataClick\\fblite\\next");
										}
										device.method_121(1.0);
										if (!bool_0)
										{
											if (flag22)
											{
												device.method_121(10.0);
											}
											else
											{
												for (int num71 = 0; num71 < 5; num71++)
												{
													text56 = device.method_93();
													if (!device.method_52("DataClick\\fblite\\confirmregist"))
													{
														flag23 = false;
														continue;
													}
													flag23 = true;
													break;
												}
												if (!flag23)
												{
													method_62(int_41, text3 + "Lỗi khi đăng ký", device);
													method_49("Lỗi khi đăng ký", device.int_0, int_41, int_42, device, bool_18: false);
													break;
												}
												method_62(int_41, text3 + "Đăng ký....", device);
												device.method_91(160, 213);
												device.method_121(1.0);
											}
											goto IL_a6c7;
										}
										method_62(int_41, text3 + "Dừng chạy...", device);
										method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
										break;
										continue;
										end_IL_a96f:
										break;
									}
								}
								else
								{
									method_62(int_41, text3 + "Không mở được app Facebook lite");
									method_49("Không mở được app Facebook lite", device.int_0, int_41, int_42, device, bool_18: false);
								}
							}
							catch
							{
								method_62(int_41, text3 + "Lỗi treo LD");
								method_49("Lỗi treo LD", device.int_0, int_41, int_42, device, bool_18: false);
							}
							goto end_IL_1d06;
							IL_25fa:
							device.method_1("com.cell47.College_Proxy");
							method_62(int_41, text3 + "Đang kết nối proxy...", device);
							switch (int_9)
							{
							case 2:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								break;
							case 3:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								break;
							case 5:
								if (rdIPDong.Checked)
								{
									if (!method_88(device, text2))
									{
										method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
										method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
										goto end_IL_1928;
									}
									text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
									break;
								}
								device.method_4(text2);
								break;
							case 6:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								break;
							case 7:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								break;
							case 8:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								break;
							case 9:
								if (!method_88(device, text2))
								{
									method_62(int_41, text3 + "Lô\u0303i kết nối proxy!");
									method_49("Lỗi kết nối proxy", device.int_0, int_41, int_42, device, bool_18: false);
									goto end_IL_1928;
								}
								text10 = device.method_101(Device.KeyEvent.KEYCODE_HOME);
								device.method_4(text2);
								break;
							}
							goto IL_2876;
							IL_24d0:
							if (!flag10)
							{
								method_62(int_41, text3 + "Cài đặt các ứng dụng không thành công", device);
								method_49("Cài đặt các ứng dụng không thành công", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							if (Settings.Default.isOnGPSLD)
							{
								device.method_85("shell settings put secure location_providers_allowed +gps");
							}
							else
							{
								device.method_85("shell settings put secure location_providers_allowed -gps");
							}
							device.method_6();
							if (bool_0)
							{
								method_62(int_41, text3 + "Dừng chạy...", device);
								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							if (!(text2 != ""))
							{
								goto IL_2876;
							}
							if (device.list_0.Contains("com.cell47.College_Proxy"))
							{
								goto IL_25fa;
							}
							method_62(int_41, text3 + "Cài đặt App Proxy...", device);
							while (true)
							{
								if (!bool_0)
								{
									flag10 = false;
									if (!(flag10 = device.method_109(Class25.smethod_0() + "\\app\\collegeproxy.apk")))
									{
										continue;
									}
									goto IL_25fa;
								}
								method_62(int_41, text3 + "Dừng chạy...", device);
								method_49("Dừng chạy", device.int_0, int_41, int_42, device, bool_18: false);
								break;
							}
							end_IL_1d06:;
						}
						catch (Exception ex4)
						{
							method_62(int_41, text3 + "Lỗi khi đăng ký. Lỗi: " + ex4.Message, device);
							method_49("Tạo tài khoản thất bại", device.int_0, int_41, int_42, device, bool_18: false);
						}
						break;
					}
					IL_11ec:
					method_62(int_41, "Đang lấy Proxy từ API...");
					if (class2.int_2 > 1)
					{
						text2 = class2.method_6();
						goto IL_1336;
					}
					while (true)
					{
						switch (class2.method_3())
						{
						case 1:
							text2 = class2.proxy;
							goto IL_121c;
						default:
							goto IL_121c;
						case 0:
							method_62(int_41, "Đang lấy Proxy từ API: Chờ " + class2.next_change + " s");
							if (class2.next_change > 10)
							{
								Common.smethod_62(10.0);
							}
							else if (class2.next_change > 0)
							{
								Common.smethod_62(class2.next_change);
							}
							goto IL_121c;
						case -2:
							method_62(int_41, "Api không đúng");
							lock (object_5)
							{
								list_12.Remove(class2);
							}
							break;
						case -1:
							method_62(int_41, "Api hết hạn");
							lock (object_5)
							{
								list_12.Remove(class2);
							}
							break;
						}
						break;
						IL_121c:
						if (!(text2 != ""))
						{
							continue;
						}
						goto IL_1336;
					}
					continue;
					IL_1a83:
					if (text2 != "")
					{
						method_62(int_41, text3 + "Không thể kết nối proxy!");
					}
					else
					{
						method_62(int_41, text3 + "Không có kết nối Internet!");
					}
					break;
					IL_13e9:
					if (!flag)
					{
						lock (object_5)
						{
							Class51 class22 = class2;
							Class51 class18 = class22;
							class18.int_1--;
							class22 = class2;
							class18 = class22;
							class18.int_2--;
						}
						continue;
					}
					goto default;
					IL_1336:
					if (!(text2 == ""))
					{
						method_62(int_41, "Đang kiểm tra proxy...");
						if (!(Common.smethod_36(text2, 0, 15) == ""))
						{
							flag = true;
							if (ckCheckIP.Checked)
							{
								text3 = "(IP: " + text2.Split(':')[0] + ") ";
								method_62(int_41, text3 + "Check IP...");
								text4 = Common.smethod_35(text2, 0);
								if (text4 == "")
								{
									flag = false;
								}
							}
							method_52(text2, "proxy", int_41, 0, dgvAcc);
						}
					}
					goto IL_13e9;
					IL_1ac3:
					method_52(text2, "proxy", int_41, 0, dgvAcc);
					goto default;
					end_IL_1928:
					break;
				}
				break;
			}
			lock (object_14)
			{
				switch (int_9)
				{
				case 2:
					@class?.method_1(int_36);
					break;
				case 3:
					class2?.method_2(int_36);
					break;
				case 6:
					class3?.method_3(int_26, int_36);
					break;
				case 7:
					class4?.method_2(int_36);
					break;
				case 8:
					class5?.method_0(int_36);
					break;
				case 0:
				case 1:
				case 4:
				case 5:
					break;
				}
			}
		}

		private int method_25(int int_41, string string_21, Device device_0, int int_42, int int_43, int int_44, int int_45, bool bool_18, int int_46, int int_47, bool bool_19, int int_48, int int_49, bool bool_20, List<string> list_21, int int_50, int int_51, int int_52, int int_53, int int_54)
		{
			int num = 0;
			int num2 = random_0.Next(int_46, int_47 + 1);
			int num3 = random_0.Next(int_50, int_51 + 1);
			int num4 = random_0.Next(int_48, int_49 + 1);
			int num5 = random_0.Next(int_42, int_43 + 1);
			int num6 = 0;
			int num7 = 0;
			int num8 = 0;
			try
			{
				for (int i = 0; i < 10; i++)
				{
					while (true)
					{
						device_0.method_35();
						if (!device_0.method_82("more options", "", 5.0))
						{
							if (!device_0.method_52("DataClick\\image\\tryagain"))
							{
								if (!device_0.method_54())
								{
									switch (method_45(device_0, int_41, string_21))
									{
									case 1:
										continue;
									case 0:
										break;
									default:
										return num;
									}
								}
							}
							else
							{
								device_0.method_56("DataClick\\image\\tryagain");
							}
							break;
						}
						while (true)
						{
							if (num >= num5)
							{
								continue;
							}
							device_0.method_54();
							while (true)
							{
								if (!device_0.method_81(500, 1, "[97,401][179,413]", "[180,88][254,100]", "[99,416][169,456]"))
								{
									num++;
									device_0.method_23(int_44, int_45);
									if (bool_18 && num6 < num2 && Common.smethod_7(int_52))
									{
										string text = device_0.method_93();
										string value = device_0.method_76("\"like\"", text).LastOrDefault();
										if (!string.IsNullOrEmpty(value))
										{
											device_0.method_34(value);
											device_0.method_10(6);
											num6++;
										}
									}
									if (bool_20 && num7 < num3 && Common.smethod_7(int_54))
									{
										string text2 = device_0.method_93();
										string value2 = device_0.method_76("\"comment\"", text2).LastOrDefault();
										if (!string.IsNullOrEmpty(value2))
										{
											string text3 = list_21[device_0.method_15(0, list_21.Count - 1)];
											text3 = Common.smethod_9(text3, random_0);
											text3 = Class47.smethod_3(text3, random_0);
											device_0.method_89(value2);
											device_0.method_23(2.0, 3.0);
											device_0.method_54();
											device_0.method_93();
											int num9 = device_0.method_84(text2, 3.0, "\"comment…\"", "write a comment…\"");
											if (num9 == 1)
											{
												device_0.method_99("\"comment…\"", text2);
											}
											if (!device_0.method_8(10, "write a comment…\"", Device.smethod_0().ToArray()))
											{
												break;
											}
											device_0.method_100(text3);
											device_0.method_99("\"send\"", "", 3);
											device_0.method_23(2.0, 2.5);
											device_0.method_74(2);
											device_0.method_23(1.0, 1.5);
											num7++;
										}
									}
									if (bool_19 && num8 < num4 && Common.smethod_7(int_53))
									{
										string text4 = device_0.method_93();
										if (device_0.method_82("share", text4))
										{
											List<string> list = device_0.method_76("share", text4);
											string text5 = list[list.Count - 1];
											device_0.method_89(text5);
											device_0.method_99("\"share now\"", "", 3);
											device_0.method_23(1.5, 2.0);
											num8++;
										}
									}
									method_62(int_41, string_21 + "Đang xem watch" + string.Format(" {0} ({1}/{2})...", num, num5));
									continue;
								}
								return num;
							}
						}
					}
				}
			}
			catch
			{
			}
			return num;
		}

		private int method_26(int int_41, string string_21, Device device_0)
		{
			int result = 0;
			try
			{
				while (true)
				{
					device_0.method_124();
					device_0.method_23(1.0, 2.0);
					switch (method_45(device_0, int_41, string_21))
					{
					case 1:
						break;
					case 0:
						method_27(int_41, string_21, device_0, 10, 30, bool_18: true, 1, 5, bool_19: false, 0, 0, null, bool_20: true, 1, 3);
						goto end_IL_0003;
					default:
						goto end_IL_0003;
					}
					continue;
					end_IL_0003:
					break;
				}
			}
			catch (Exception)
			{
				result = -1;
			}
			return result;
		}

		private int method_27(int int_41, string string_21, Device device_0, int int_42, int int_43, bool bool_18, int int_44, int int_45, bool bool_19, int int_46, int int_47, List<string> list_21, bool bool_20, int int_48, int int_49)
		{
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			int num5 = 0;
			int num6 = 0;
			List<string> list = new List<string>();
			if (bool_18)
			{
				num4 = device_0.method_15(int_44, int_45);
			}
			if (list_21 != null)
			{
				list_21 = Common.smethod_77(list_21);
				list = Common.smethod_8(list_21);
			}
			if (bool_19)
			{
				num5 = device_0.method_15(int_46, int_47);
			}
			if (bool_20)
			{
				num6 = device_0.method_15(int_48, int_49);
			}
			List<string> list2 = new List<string>();
			List<string> list3 = new List<string>();
			List<string> list4 = new List<string>();
			int num7 = device_0.method_15(int_42, int_43);
			int tickCount = Environment.TickCount;
			while (Environment.TickCount - tickCount < num7 * 1000)
			{
				int num8 = method_45(device_0, int_41, string_21);
				if (num8 == 1)
				{
					device_0.method_124();
				}
				else if (num8 != 0)
				{
					break;
				}
				string text = device_0.method_93();
				list2 = device_0.method_76("like button. double tap and hold to react", text);
				if (list2.Count > 0 && bool_18 && num < num4 && device_0.method_15(1, 100) % 2 == 0)
				{
					string text2 = list2[list2.Count - 1];
					if (text2 != "" && device_0.method_34(text2, "[0,100][320,480]"))
					{
						device_0.method_23(1.0, 1.5);
						device_0.method_10(6);
						num++;
						device_0.method_23(1.0, 2.0);
						text = device_0.method_93();
					}
				}
				list3 = device_0.method_76("comment button", text);
				if (list3.Count > 0 && bool_19 && num2 < num5 && device_0.method_15(1, 100) % 2 == 0 && list_21 != null)
				{
					string text3 = list3[list3.Count - 1];
					if (text3 != "")
					{
						if (list.Count == 0)
						{
							list = Common.smethod_8(list_21);
						}
						string item = list[device_0.method_15(0, list.Count - 1)];
						list.Remove(item);
						item = Common.smethod_9(item, random_0);
						if (device_0.method_89(text3, "[0,100][320,480]"))
						{
							device_0.method_23(1.0, 2.0);
							device_0.method_100(item);
							device_0.method_23(1.0, 2.0);
							if (device_0.method_99("send"))
							{
								device_0.method_23(3.0, 5.0);
							}
							device_0.method_74(2, 0.3);
							num2++;
							device_0.method_23(1.0, 2.0);
							text = device_0.method_93();
						}
					}
				}
				list4 = device_0.method_76("share button", text);
				if (list4.Count > 0 && bool_20 && num3 < num6 && device_0.method_15(1, 100) % 2 == 0)
				{
					string text4 = list4[list4.Count - 1];
					if (text4 != "" && device_0.method_89(text4, "[0,100][320,480]"))
					{
						device_0.method_23(1.5, 2.0);
						device_0.method_99("share now");
						device_0.method_23(2.0, 3.0);
						num3++;
					}
				}
				if (device_0.method_81(500, 1, "[97,401][179,413]", "[180,88][254,100]"))
				{
					break;
				}
				device_0.method_23(1.5, 3.0);
			}
			return 0;
		}

		private int method_28(int int_41, string string_21, Device device_0, int int_42, int int_43)
		{
			int num = 0;
			try
			{
				int num2 = random_0.Next(int_42, int_43 + 1);
				if (num2 != 0)
				{
					while (true)
					{
						device_0.method_9();
						device_0.method_23(1.0, 2.0);
						switch (method_45(device_0, int_41, string_21))
						{
						case 0:
						{
							List<string> list = device_0.method_76("as a friend\"");
							if (list.Count == 0)
							{
								goto end_IL_0174;
							}
							for (int i = 0; i < num2 + 10; i++)
							{
								switch (method_45(device_0, int_41, string_21))
								{
								case 0:
								{
									string text = list[device_0.method_15(0, list.Count - 1)];
									if (text != "" && device_0.method_89(text))
									{
										num++;
										method_62(int_41, string_21 + "Đang" + string.Format(" kết bạn gợi ý ({1}/{2})...", num, num2));
										device_0.method_23(2.0, 5.0);
									}
									if (num >= num2)
									{
										goto end_IL_0166;
									}
									list = device_0.method_76("as a friend");
									if (list.Count != 0)
									{
										continue;
									}
									if (!device_0.method_81(device_0.method_15(200, 300)))
									{
										list = device_0.method_76("as a friend");
										if (list.Count != 0)
										{
											continue;
										}
									}
									goto end_IL_0166;
								}
								case 1:
									break;
								default:
									goto end_IL_0166;
								}
								goto end_IL_01a6;
								continue;
								end_IL_0166:
								break;
							}
							goto end_IL_0174;
						}
						case 1:
							break;
						default:
							goto end_IL_0174;
							end_IL_01a6:
							break;
						}
						continue;
						end_IL_0174:
						break;
					}
				}
			}
			catch
			{
				num = -1;
			}
			return num;
		}

		private int method_29(int int_41, string string_21, Device device_0)
		{
			int num = device_0.method_15(3, 5);
			try
			{
				while (true)
				{
					device_0.method_124();
					device_0.method_23(1.0, 2.0);
					switch (method_45(device_0, int_41, string_21))
					{
					case 1:
						break;
					case 0:
					{
						string text = device_0.method_97("'s story");
						if (!(text != ""))
						{
							goto end_IL_000a;
						}
						device_0.method_89(text);
						int tickCount = Environment.TickCount;
						while (Environment.TickCount - tickCount < num * 1000)
						{
							device_0.method_23(4.0, 8.0);
							if (list_10.Count > 0 && device_0.method_15(1, 9) % 3 == 0)
							{
								string text2 = "[165,445][195,470]";
								string text3 = "[35,445][65,470]";
								device_0.method_80(text2, text3);
								device_0.method_23(1.0, 1.5);
								int num2 = Convert.ToInt32(list_10[device_0.method_15(0, list_10.Count - 1)].ToString());
								device_0.method_10(num2);
								device_0.method_23(1.0, 1.5);
								device_0.method_89("[260,198][300,268]");
								device_0.method_23(1.0, 1.5);
							}
							device_0.method_89("[260,198][300,268]");
						}
						goto end_IL_000a;
					}
					default:
						goto end_IL_000a;
					}
					continue;
					end_IL_000a:
					break;
				}
			}
			catch
			{
			}
			return num;
		}

		private int method_30(int int_41, string string_21, Device device_0, int int_42, int int_43, bool bool_18, bool bool_19, int int_44, int int_45, int int_46, int int_47)
		{
			int result = 0;
			try
			{
				int num = device_0.method_15(int_42, int_43);
				List<string> list = new List<string>();
				if (!bool_18)
				{
					list = list_20.GetRange(0, num);
				}
				else
				{
					List<string> list2 = list_20;
					lock (list2)
					{
						if (list_20.Count > 0)
						{
							if (num > list_20.Count)
							{
								num = list_20.Count;
							}
							list = list_20.GetRange(0, num);
							list_20.RemoveRange(0, num);
						}
					}
				}
				if (list.Count > 0)
				{
					method_62(int_41, string_21 + "Import danh bạ...");
					string text = device_0.method_93();
					device_0.method_20(list);
					device_0.method_121(10.0);
					result = (device_0.method_19() ? 1 : 0);
					if (bool_19)
					{
						List<string> list3 = device_0.method_76("add friend", text, 5);
						if (list3.Count > 0)
						{
							int num2 = 0;
							int num3 = random_0.Next(int_44, int_45 + 1);
							if (num3 != 0)
							{
								int num4 = 0;
								for (int i = 0; i < num3 + 10; i++)
								{
									if (device_0.method_129())
									{
										num4++;
										if (num4 % 3 == 0 && method_31(device_0, int_41, string_21) != 0)
										{
											break;
										}
										string text2 = list3[device_0.method_15(0, list3.Count - 1)];
										if (text2 != "" && device_0.method_18("[0,130][320,480]", text2) && device_0.method_89(text2))
										{
											num2++;
											method_62(int_41, string_21 + "Add friends...");
											device_0.method_23(int_46, int_47);
										}
										if (num2 >= num3)
										{
											break;
										}
										list3 = device_0.method_76("add friend");
										if (list3.Count == 0 || (list3.Count == 1 && !device_0.method_18("[0,130][320,480]", list3[0])))
										{
											if (device_0.method_81(device_0.method_15(200, 300)))
											{
												break;
											}
											list3 = device_0.method_76("add friend");
											if (list3.Count == 0 || (list3.Count == 1 && !device_0.method_18("[0,130][320,480]", list3[0])))
											{
												break;
											}
										}
										continue;
									}
									return -2;
								}
							}
						}
					}
				}
			}
			catch (Exception)
			{
				throw;
			}
			return result;
		}

		private int method_31(Device device_0, int int_41, string string_21, bool bool_18 = true)
		{
			device_0.method_130("Check status...");
			string text = "";
			int num = device_0.method_60(ref text, bool_18);
			device_0.method_130($"Check status: {num}...");
			if ((num.ToString() ?? "").StartsWith("-1"))
			{
				if (device_0.method_82("\"ok\"", text))
				{
					device_0.method_121(1.0);
					device_0.method_99("\"ok\"", text);
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			int result;
			if (num3 != -1)
			{
				result = num;
			}
			else
			{
				if (bool_8 && device_0.method_87() != "Application")
				{
					device_0.method_70();
					string text2 = "";
					for (int i = 0; i < 10; i++)
					{
						text2 = device_0.method_61(0).Split('|')[1];
						if (text2 == "0")
						{
							break;
						}
					}
					if (text2 != "1" && method_46(device_0, int_41, string_21) == 1)
					{
						return 1;
					}
				}
				result = -1;
			}
			return result;
		}

		private int method_32(int int_41, string string_21, Device device_0)
		{
			int num = 0;
			int num2 = device_0.method_15(1, 5);
			try
			{
				string text = "manage the notification";
				List<string> list = new List<string>();
				while (num < num2)
				{
					for (int i = 0; i < 10; i++)
					{
						string text2 = device_0.method_93();
						list = device_0.method_76(text);
						if (list.Count <= 0)
						{
							if (!device_0.method_82("no notifications", text2))
							{
								while (true)
								{
									device_0.method_22();
									device_0.method_121(3.0);
									if (!device_0.method_54())
									{
										switch (method_45(device_0, int_41, string_21))
										{
										case 1:
											continue;
										case 0:
											break;
										default:
											return num;
										}
									}
									break;
								}
								continue;
							}
							method_62(int_41, string_21 + "Không có thông báo để đọc", device_0);
							return num;
						}
						if (list.Count <= 4)
						{
							num2 = list.Count;
						}
						Point point_;
						do
						{
							if (list.Count == 0)
							{
								if (!device_0.method_81(150))
								{
									list = device_0.method_76(text);
									if (list.Count != 0)
									{
										goto IL_00d5;
									}
								}
								return num;
							}
							goto IL_00d5;
							IL_00d5:
							string item = list[device_0.method_15(0, list.Count - 1)];
							list.Remove(item);
							point_ = device_0.method_88(item);
						}
						while (!device_0.method_98("[0,60][320,480]", point_));
						device_0.method_91(point_.X - device_0.method_15(100, 150), point_.Y);
						device_0.method_23(1.0, 2.0);
						int tickCount = Environment.TickCount;
						int num3 = device_0.method_15(3, 5);
						while (Environment.TickCount - tickCount < num3 * 1000 && !device_0.method_81())
						{
							device_0.method_23(1.0, 2.0);
						}
						num++;
						method_62(int_41, string_21 + "Đang" + string.Format(" Đọc thông báo ({1}/{2})...", num, num2), device_0);
						device_0.method_74();
						device_0.method_23(1.0, 2.0);
						break;
					}
				}
			}
			catch
			{
			}
			return num;
		}

		private void method_33(int int_41 = 0)
		{
			Common.smethod_62(random_0.Next(int_41 + 1, int_41 + 4));
		}

		private int method_34(int int_41, Device device_0)
		{
			string text = method_1(int_41, "pass");
			int result = 0;
			bool flag = false;
			string text2 = "";
			int num = 0;
			string text3 = "";
			for (int i = 0; i < 2 && !bool_0 && num != 5; i++)
			{
				device_0.method_127();
				device_0.method_121(5.0);
				if (!device_0.method_3("DataClick\\image\\usetwofactorauthentication"))
				{
					if (!device_0.method_81())
					{
						device_0.method_121(1.0);
						num++;
						continue;
					}
				}
				else
				{
					flag = true;
				}
				if (!flag)
				{
					continue;
				}
				int num2 = 0;
				while (num2 < 5)
				{
					text3 = device_0.method_93();
					if (!device_0.method_82("\"continue\"", text3))
					{
						if (!device_0.method_81())
						{
							device_0.method_121(1.0);
							num2++;
						}
						continue;
					}
					flag = true;
					device_0.method_99("\"continue\"", text3);
					break;
				}
				if (flag)
				{
					for (int j = 0; j < 5; j++)
					{
						try
						{
							method_62(int_41, "Chờ " + int_34 + " giây để quét QRCode", device_0);
							device_0.method_121(int_34);
							Bitmap bitmap_ = device_0.method_33();
							text2 = Common.smethod_66(bitmap_);
							text2 = Regex.Match(text2, "secret=(.*?)&").Groups[1].Value;
							if (!string.IsNullOrEmpty(text2))
							{
								break;
							}
							device_0.method_121(1.0);
							continue;
						}
						catch (Exception exception_)
						{
							method_62(int_41, "Không quét được mã QRCode. Thực hiện lại", device_0);
							Common.smethod_82(exception_, "ScanQRCode2Fa");
						}
						break;
					}
				}
				if (!string.IsNullOrEmpty(text2))
				{
					int num3 = 0;
					while (num3 < 5)
					{
						text3 = device_0.method_93();
						if (!device_0.method_99("\"continue\"", text3))
						{
							if (!device_0.method_81(500))
							{
								device_0.method_121(1.0);
								num3++;
								flag = false;
							}
							continue;
						}
						flag = true;
						break;
					}
					if (!flag)
					{
						continue;
					}
					int num4 = 0;
					while (num4 < 5)
					{
						if (!device_0.method_3("DataClick\\image\\enterthe6digitcode"))
						{
							continue;
						}
						string text4 = Common.smethod_72(text2);
						device_0.method_100(text4);
						device_0.method_99("\"continue\"");
						int num5 = 0;
						while (num5 < 5)
						{
							if (device_0.method_52("DataClick\\image\\thiscodeisntright"))
							{
								continue;
							}
							text3 = device_0.method_93();
							if (!device_0.method_82("incorrect password", text3))
							{
								if (device_0.method_82("\"password\"", text3))
								{
									if (text.Trim() == "")
									{
										break;
									}
									device_0.method_99("\"password\"", text3);
									device_0.method_100(text);
									device_0.method_3("DataClick\\image\\continue", null, 10);
								}
								else if (device_0.method_82("two-factor authentication is on", text3))
								{
									goto IL_0394;
								}
								device_0.method_121(1.0);
								num5++;
								continue;
							}
							method_42(int_41, "Changed pass");
							break;
						}
					}
					continue;
				}
				result = 0;
				break;
				IL_0394:
				flag = true;
				break;
			}
			if (text2 != "")
			{
				result = 1;
				method_22(int_41, "conf_2fa", text2);
			}
			return result;
		}

		private int method_35(int int_41, int int_42, Device device_0, int int_43)
		{
			try
			{
				method_1(int_41, "uid");
				string text = method_1(int_41, "pass");
				int num = 0;
				if (int_43 == 1)
				{
					int result = 0;
					int num2 = 0;
					try
					{
						int num3 = 0;
						while (num3 < 5)
						{
							device_0.method_124();
							num2++;
							num3++;
							if (num3 == 5)
							{
								break;
							}
							if (!device_0.method_3("DataClick\\image\\menu") || device_0.method_52("DataClick\\image\\fastermessage"))
							{
								continue;
							}
							bool flag = false;
							num2++;
							int num4 = 0;
							while (num4 < 5)
							{
								string text2 = device_0.method_93();
								if (!device_0.method_3("DataClick\\image\\settingandprivacy"))
								{
									if (!device_0.method_81(500))
									{
										device_0.method_121(1.0);
										num4++;
										continue;
									}
								}
								else
								{
									flag = true;
								}
								if (!flag)
								{
									goto end_IL_00d7;
								}
								flag = false;
								num2++;
								int num5 = 0;
								while (num5 < 5)
								{
									if (!device_0.method_3("DataClick\\image\\caidat"))
									{
										if (num5 % 2 != 1 || !device_0.method_81())
										{
											device_0.method_121(1.0);
											num5++;
											continue;
										}
									}
									else
									{
										flag = true;
									}
									if (!flag)
									{
										break;
									}
									flag = false;
									int num6 = 0;
									while (num6 < 5)
									{
										text2 = device_0.method_93();
										if (!device_0.method_3("DataClick\\image\\passwordandsecurity"))
										{
											if (!device_0.method_81())
											{
												device_0.method_121(1.0);
												num6++;
												continue;
											}
										}
										else
										{
											flag = true;
										}
										if (!flag)
										{
											break;
										}
										flag = false;
										int num7 = 0;
										while (num7 < 10)
										{
											text2 = device_0.method_93();
											if (!device_0.method_3("DataClick\\image\\usetwofactorauthentication"))
											{
												if (!device_0.method_81())
												{
													device_0.method_121(1.0);
													num7++;
													continue;
												}
											}
											else
											{
												flag = true;
											}
											if (!flag)
											{
												break;
											}
											flag = false;
											for (int i = 0; i < 10; i++)
											{
												text2 = device_0.method_93();
												if (device_0.method_3("DataClick\\image\\continue", null, 10))
												{
													flag = true;
													break;
												}
											}
											if (!flag)
											{
												break;
											}
											string text3 = "";
											string text4 = "";
											int num8 = 0;
											while (true)
											{
												if (num8 < 2)
												{
													try
													{
														method_62(int_41, "Chờ " + int_34 + " giây để quét QRCode", device_0);
														device_0.method_121(int_34);
														Bitmap bitmap_ = device_0.method_33();
														text4 = Common.smethod_66(bitmap_);
														text4 = Regex.Match(text4, "secret=(.*?)&").Groups[1].Value;
														if (string.IsNullOrEmpty(text4))
														{
															device_0.method_121(1.0);
															goto IL_0334;
														}
													}
													catch (Exception exception_)
													{
														method_62(int_41, "Không quét được mã QRCode. Thực hiện lại", device_0);
														Common.smethod_82(exception_, "ScanQRCode2Fa");
														break;
													}
												}
												if (!string.IsNullOrEmpty(text4))
												{
													int num9 = 0;
													int num10 = 0;
													while (true)
													{
														text3 = device_0.method_93();
														if (!device_0.method_99("\"continue\"", text3))
														{
															break;
														}
														flag = false;
														num10++;
														if (num10 != 5 && device_0.method_3("DataClick\\image\\enterthe6digitcode", null, 10))
														{
															string text5 = Common.smethod_72(text4);
															device_0.method_100(text5);
															device_0.method_99("\"continue\"");
															int num11 = 0;
															while (num11 < 5)
															{
																if (!device_0.method_52("DataClick\\image\\thiscodeisntright"))
																{
																	text2 = device_0.method_93();
																	if (!device_0.method_82("incorrect password", text2))
																	{
																		if (device_0.method_82("\"password\"", text2))
																		{
																			if (text.Trim() == "")
																			{
																				break;
																			}
																			device_0.method_99("\"password\"", text2);
																			device_0.method_100(text);
																			device_0.method_99("\"continue\"", text2);
																		}
																		else if (device_0.method_82("two-factor authentication is on", text2))
																		{
																			flag = true;
																			break;
																		}
																		device_0.method_121(1.0);
																		num11++;
																		continue;
																	}
																	method_42(int_41, "Changed pass");
																	break;
																}
																goto IL_0486;
															}
														}
														goto IL_04d3;
														IL_0486:
														num9++;
														if (num9 < 3)
														{
															device_0.method_99("\"back\"");
															continue;
														}
														goto IL_04d3;
														IL_04d3:
														if (text4 != "")
														{
															result = 1;
															method_22(int_41, "conf_2fa", text4);
														}
														break;
													}
												}
												else
												{
													result = 0;
												}
												break;
												IL_0334:
												num8++;
											}
											break;
										}
										break;
									}
									break;
								}
								goto end_IL_00d7;
							}
							continue;
							end_IL_00d7:
							break;
						}
					}
					catch
					{
					}
					return result;
				}
				return 0;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		public string method_36(int int_41)
		{
			return Class15.smethod_3(dgvAcc, int_41, "cInfo");
		}

		public string method_37(int int_41)
		{
			return Class15.smethod_3(dgvAcc, int_41, "conf_2fa");
		}

		public string method_38(int int_41)
		{
			return Class15.smethod_3(dgvAcc, int_41, "proxy");
		}

		public string method_39(int int_41)
		{
			return Class15.smethod_3(dgvAcc, int_41, "email");
		}

		public string method_40(int int_41)
		{
			return Class15.smethod_3(dgvAcc, int_41, "passMail");
		}

		private void method_41(int int_41 = -1)
		{
			if (int_41 == -1)
			{
				for (int i = 0; i < dgvAcc.RowCount; i++)
				{
					string text = method_36(i);
					if (text == "Live")
					{
						dgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
					}
					else if (text.Contains("Die") || text.Contains("Checkpoint") || text.Contains("Changed pass"))
					{
						dgvAcc.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
					}
				}
			}
			else
			{
				string text2 = method_36(int_41);
				if (text2 == "Live")
				{
					dgvAcc.Rows[int_41].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				}
				else if (text2.Contains("Die") || text2.Contains("Checkpoint") || text2.Contains("Changed pass"))
				{
					dgvAcc.Rows[int_41].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
				}
			}
		}

		public void method_42(int int_41, string string_21)
		{
			Class15.smethod_4(dgvAcc, int_41, "cInfo", string_21);
			method_41(int_41);
		}

		private bool method_43(Device device_0)
		{
			bool result = false;
			for (int i = 0; i < 60; i++)
			{
				string text = device_0.method_93();
				if (device_0.method_120(text).Count != 1)
				{
					if (device_0.method_82("we need more information", text, 5.0))
					{
						result = true;
						break;
					}
					if (device_0.method_82("Something went wrong. Please try again.", text, 5.0))
					{
						result = true;
						break;
					}
					if (device_0.method_82("chúng tôi cần thêm thông tin", text, 5.0))
					{
						result = true;
						break;
					}
				}
			}
			return result;
		}

		private int method_44(Device device_0, int int_41, string string_21)
		{
			int result = 0;
			int num = 0;
			int num2 = 5;
			int num3 = 0;
			while (true)
			{
				if (num3 < 2)
				{
					string text = device_0.method_93();
					if (device_0.method_120(text).Count != 1)
					{
						if (device_0.method_82("profile picture", text))
						{
							result = 1;
							break;
						}
						if (!device_0.method_82("reload page", text))
						{
							switch (method_45(device_0, int_41, string_21))
							{
							case 0:
								goto IL_00b3;
							default:
								result = 3;
								break;
							case 1:
								result = 2;
								break;
							}
							break;
						}
						num++;
						if (num >= num2)
						{
							break;
						}
						device_0.method_99("reload page", text);
					}
					else
					{
						device_0.method_99(device_0.method_120(text)[0], text);
					}
					goto IL_00b3;
				}
				return result;
				IL_00b3:
				device_0.method_121(1.0);
				num3++;
			}
			return result;
		}

		private int method_45(Device device_0, int int_41, string string_21)
		{
			device_0.method_130("Check status...");
			string text = "";
			int num = device_0.method_60(ref text);
			device_0.method_130($"Check status: {num}...");
			if ((num.ToString() ?? "").StartsWith("-1"))
			{
				if (device_0.method_82("\"ok\"", text))
				{
					device_0.method_99("\"ok\"", text);
				}
				else
				{
					device_0.method_54(text);
				}
				num = -1;
			}
			int num2 = num;
			int num3 = num2;
			int result;
			if (num3 != -1)
			{
				result = num;
			}
			else
			{
				if (bool_8)
				{
					device_0.method_70();
					string text2 = "";
					for (int i = 0; i < 10; i++)
					{
						text2 = device_0.method_61(0).Split('|')[1];
						if (text2 == "0")
						{
							break;
						}
					}
					if (text2 != "1" && method_46(device_0, int_41, string_21) == 1)
					{
						return 1;
					}
				}
				result = -1;
			}
			return result;
		}

		private int method_46(Device device_0, int int_41, string string_21)
		{
			return -1;
		}

		private void method_47(ToolStripStatusLabel toolStripStatusLabel_0)
		{
			try
			{
				int num = Convert.ToInt32(toolStripStatusLabel_0.Text);
				toolStripStatusLabel_0.Text = (num + 1).ToString();
			}
			catch
			{
			}
		}

		private bool method_48(string string_21)
		{
			return Common.smethod_64(string_21) && !string_21.StartsWith("0");
		}

		private void method_49(string string_21, int int_41, int int_42, int int_43, Device device_0, bool bool_18)
		{
			int num = random_0.Next(int_5, int_6 + 1);
			if (num > 0)
			{
				int tickCount = Environment.TickCount;
				while ((Environment.TickCount - tickCount) / 1000 - num < 0)
				{
					if (!bool_0)
					{
						method_62(int_42, "Đóng LD sau {time}s...".Replace("{time}", (num - (Environment.TickCount - tickCount) / 1000).ToString()));
						Common.smethod_62(0.5);
						continue;
					}
					method_62(int_42, "Dừng chạy!");
					break;
				}
			}
			if (!bool_18)
			{
				method_47(stTotalFail);
				method_62(int_42, string_21, device_0);
				dgvAcc.Invoke((MethodInvoker)delegate
				{
					dgvAcc.Rows[int_42].DefaultCellStyle.BackColor = Color.FromArgb(255, 182, 193);
				});
			}
			else
			{
				method_47(stTotalSuccess);
				method_62(int_42, string_21, device_0);
				dgvAcc.Invoke((MethodInvoker)delegate
				{
					dgvAcc.Rows[int_42].DefaultCellStyle.BackColor = Color.FromArgb(212, 237, 182);
				});
			}
			Invoke((MethodInvoker)delegate
			{
				frmViewLD.frmViewLD_0.method_4(device_0.int_0);
			});
			device_0.method_68();
			list_4.Remove(device_0);
			if (int_36 == 1 && File.Exists(string_9 + "\\vms\\config\\leidian" + int_41 + ".config"))
			{
				int num2 = 0;
				string text;
				do
				{
					num2++;
					text = string_9 + "\\vms\\config\\leidian" + int_41 + ".config";
				}
				while (!Common.smethod_76(text));
			}
			if (!Settings.Default.isAutoClearLD)
			{
				return;
			}
			if (Directory.Exists(string_9 + "\\vms\\leidian" + int_41))
			{
				int num3 = 0;
				string text2;
				do
				{
					num3++;
					text2 = string_9 + "\\vms\\leidian" + int_41;
				}
				while (!Common.smethod_40(text2));
			}
			if (File.Exists(string_9 + "\\vms\\config\\leidian" + int_41 + ".config"))
			{
				int num4 = 0;
				string text3;
				do
				{
					num4++;
					text3 = string_9 + "\\vms\\config\\leidian" + int_41 + ".config";
				}
				while (!Common.smethod_76(text3));
			}
		}

		private void method_50()
		{
			Common.smethod_73("frmViewLD");
		}

		private void method_51(double double_0)
		{
			Application.DoEvents();
			Thread.Sleep(Convert.ToInt32(double_0 * 1000.0));
		}

		private void method_52(string string_21, string string_22, int int_41, int int_42, DataGridView dataGridView_0)
		{
			try
			{
				dataGridView_0.Invoke((Action)delegate
				{
					dataGridView_0.Rows[int_41].Cells[string_22].Value = string_21;
				});
			}
			catch
			{
			}
		}

		private string method_53()
		{
			string text = "";
			string text2 = txtListDauso.Text.Trim();
			string text3 = text2.Split(',')[random_0.Next(0, text2.Split(',').Length)];
			return text + text3;
		}

		private string method_54()
		{
			string text = "";
			try
			{
				RequestHTTP requestHTTP = new RequestHTTP();
				requestHTTP.SetSSL(SecurityProtocolType.Tls12);
				requestHTTP.SetKeepAlive(k: true);
				requestHTTP.SetDefaultHeaders(new string[2] { "content-type: text/html,application/xhtml+xml,application/xml;q=0.9,*;q=0.8", "user-agent: Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/74.0.3729.131 Safari/537.36" });
				string json = requestHTTP.Request("GET", "http://lumtest.com/myip.json").ToString();
				JObject jObject = JObject.Parse(json);
				return jObject["ip"]!.ToString();
			}
			catch
			{
				return "Lỗi lấy IP";
			}
		}

		private void method_55(object sender, EventArgs e)
		{
		}

		private void method_56(int int_41)
		{
			Dictionary<string, string> dataSource = method_57(int_41);
			cbbPrePhone.DataSource = new BindingSource(dataSource, null);
			cbbPrePhone.ValueMember = "Key";
			cbbPrePhone.DisplayMember = "Value";
		}

		private Dictionary<string, string> method_57(int int_41)
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			List<string> list = ((int_41 == 0) ? Common.smethod_0() : Common.smethod_1());
			for (int i = 0; i < list.Count; i++)
			{
				string[] array = list[i].Split('|');
				dictionary.Add(array[0], array[1]);
			}
			return dictionary;
		}

		private void method_58()
		{
			Dictionary<string, string> dataSource = method_59();
			cbLocationProxy.DataSource = new BindingSource(dataSource, null);
			cbLocationProxy.ValueMember = "Key";
			cbLocationProxy.DisplayMember = "Value";
		}

		private Dictionary<string, string> method_59()
		{
			Dictionary<string, string> dictionary = new Dictionary<string, string>();
			List<string> list = Class67.smethod_3();
			for (int i = 0; i < list.Count; i++)
			{
				string[] array = list[i].Split('|');
				dictionary.Add(array[0], array[1]);
			}
			return dictionary;
		}

		private void method_60()
		{
			list_17.Clear();
			list_18.Clear();
			list_19.Clear();
			Class48 @class = new Class48("setting.ini");
			string text = @class.method_1("txtListXProxy");
			if (text != string.Empty)
			{
				string[] array = text.Split(';');
				string text2 = string.Empty;
				for (int i = 0; i < array.Length; i++)
				{
					list_17.Add(array[i]);
					text2 += array[i];
					if (i < array.Length - 1)
					{
						text2 += Environment.NewLine;
					}
				}
				txtListXProxy.Text = text2;
			}
			string text3 = @class.method_1("txtApiKeyTMProxy");
			if (text3 != string.Empty)
			{
				string[] array2 = text3.Split('|');
				string text4 = string.Empty;
				for (int j = 0; j < array2.Length; j++)
				{
					list_18.Add(array2[j]);
					text4 += array2[j];
					if (j < array2.Length - 1)
					{
						text4 += Environment.NewLine;
					}
				}
				txtApiKeyTMProxy.Text = text4;
			}
			string text5 = @class.method_1("txtAPIKeyShoplike");
			if (!(text5 != string.Empty))
			{
				return;
			}
			string[] array3 = text5.Split('|');
			string text6 = string.Empty;
			for (int k = 0; k < array3.Length; k++)
			{
				list_19.Add(array3[k]);
				text6 += array3[k];
				if (k < array3.Length - 1)
				{
					text6 += Environment.NewLine;
				}
			}
			txtAPIKeyShoplike.Text = text6;
		}

		private void method_61()
		{
			try
			{
				Class48 @class = new Class48("setting.ini");
				cbModeRunReg.SelectedIndex = ((!(@class.method_1("cbModeRunReg") == "")) ? Convert.ToInt32(@class.method_1("cbModeRunReg")) : 0);
				numThrLdPlay.Value = Convert.ToInt32(@class.method_1("nudThread"));
				numOTP.Value = Convert.ToInt32(@class.method_1("nudThoiGianChoNhapOTP"));
				rdNormal.Checked = ((Convert.ToInt32(@class.method_1("modeRun")) == 0) ? true : false);
				rdSwap.Checked = Convert.ToInt32(@class.method_1("modeRun")) == 1;
				rdDelayLD.Checked = true;
				numDelayFr.Value = Convert.ToInt32(@class.method_1("numDelayFr"));
				numDelayTo.Value = Convert.ToInt32(@class.method_1("numDelayTo"));
				numDeClsFr.Value = Convert.ToInt32(@class.method_1("numDeClsFr"));
				numDeClsTo.Value = Convert.ToInt32(@class.method_1("numDeClsTo"));
				numChangeIP.Value = Convert.ToInt32(@class.method_1("iSoLuotDoiIpMotLan"));
				nudSoLuotChay.Value = Convert.ToInt32(@class.method_1("nudSoLuotChay"));
				txtLinkLD.Text = @class.method_1("linkLD");
				txtNameDcom.Text = @class.method_1("txtProfileNameDcom");
				txtProxy.Text = @class.method_1("txtAPIProxy");
				nAgeFrom.Value = ((@class.method_1("nAgeFrom") == "") ? 18 : Convert.ToInt32(@class.method_1("nAgeFrom")));
				nAgeTo.Value = ((@class.method_1("nAgeTo") == "") ? 35 : Convert.ToInt32(@class.method_1("nAgeTo")));
				nudTimeWaitOTP.Value = ((@class.method_1("nudTimeWaitOTP") == "") ? 60 : Convert.ToInt32(@class.method_1("nudTimeWaitOTP")));
				nudLuongPerIPTinsoft.Value = Convert.ToInt32(@class.method_1("nudLuongPerIPTinsoft"));
				nudLuongPerIPMinProxy.Value = Convert.ToInt32(@class.method_1("nudLuongPerIPMinProxy"));
				plHotmailReg.Enabled = false;
				string text = @class.method_1("typeVerify");
				try
				{
					if (text.Substring(0, 1) == "0")
					{
						rdNoVeri.Checked = true;
						plVeriPhone.Enabled = false;
						plVeriMail.Enabled = false;
						if (text.Substring(1, 1) == "0")
						{
							rdNovriPhone.Checked = true;
							cbbPhoneCountry.SelectedIndex = Convert.ToInt32(text.Substring(2, 1));
						}
						else
						{
							rdNoveriMail.Checked = true;
							cbMailAo.SelectedIndex = Convert.ToInt32(text.Substring(2, 1));
						}
					}
					else
					{
						rdThuePhone.Checked = true;
						plNovery.Enabled = false;
						plVeriMail.Enabled = false;
						if (text.Substring(1, 1) == "0")
						{
							cbDvSim.SelectedIndex = Convert.ToInt32(text.Substring(2, 1));
						}
						else
						{
							rdConfMail.Checked = true;
							string text2 = text.Substring(2, 1);
							if (text2 != null)
							{
								switch (text2)
								{
								default:
									tabMailVeri.SelectTab(1);
									rdMailTM.Checked = true;
									break;
								case "2":
									tabMailVeri.SelectTab(1);
									rdTempMailIO.Checked = true;
									break;
								case "1":
									rdHotMailRegisted.Checked = true;
									tabMailVeri.SelectTab(0);
									break;
								case "0":
									rdHotMailReg.Checked = true;
									plHotmailReg.Enabled = true;
									tabMailVeri.SelectTab(0);
									break;
								}
							}
						}
					}
				}
				catch
				{
					rdNoVeri.Checked = true;
					rdNovriPhone.Checked = true;
				}
				ckTaoMailBox.Checked = Convert.ToBoolean(@class.method_1("ckTaoMailBox"));
				ckRdPassmail.Checked = Convert.ToBoolean(@class.method_1("ckRdPassmail"));
				txtPassmail.Text = @class.method_1("txtPassmail");
				txtAPISim.Text = @class.method_1("txtAPISim");
				txtAPIAnyCat.Text = @class.method_1("txtAPIAnyCat");
				cbNameReg.SelectedIndex = Convert.ToInt32(@class.method_1("typeNameReg"));
				txtPassFb.Text = @class.method_1("passFB");
				chkRandomPass.Checked = Convert.ToBoolean(@class.method_1("isRdPass"));
				ckCheckIP.Checked = !(@class.method_1("ckCheckIP") == "") && Convert.ToBoolean(@class.method_1("ckCheckIP"));
				switch (Convert.ToInt32(@class.method_1("typeGender")))
				{
				case 0:
					rbFemale.Checked = true;
					break;
				case 1:
					rbMale.Checked = true;
					break;
				case 2:
					rbRandomMF.Checked = true;
					break;
				}
				switch (Convert.ToInt32(@class.method_1("typeChangeIp")))
				{
				case 0:
					rdNoChangeIP.Checked = true;
					rdProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rdMinProxy.Checked = false;
					rbTMProxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rbXproxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plXproxy.Enabled = false;
					plTMProxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					tabProxy.Enabled = false;
					pnlProxyFree.Enabled = false;
					break;
				case 1:
					rdChangeIPDcom.Checked = true;
					rdProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbTMProxy.Checked = false;
					rdMinProxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rbXproxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plXproxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					plTMProxy.Enabled = false;
					tabProxy.Enabled = false;
					plTMProxy.Enabled = false;
					pnlProxyFree.Enabled = false;
					break;
				case 2:
					rdProxy.Checked = true;
					rdTinsoftProxy.Checked = true;
					rdMinProxy.Checked = false;
					rbTMProxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rbXproxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plXproxy.Enabled = false;
					plTMProxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					pnlProxyFree.Enabled = false;
					tabProxy.SelectTab(0);
					break;
				case 4:
					rdHMA.Checked = true;
					rdProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbTMProxy.Checked = false;
					rdMinProxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rbXproxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plChangeIPDcom.Enabled = false;
					plXproxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					plTMProxy.Enabled = false;
					tabProxy.Enabled = false;
					plTMProxy.Enabled = false;
					pnlProxyFree.Enabled = false;
					break;
				case 5:
					rdProxy.Checked = true;
					rdIPPortUserPass.Checked = true;
					rbTMProxy.Checked = false;
					rbXproxy.Checked = false;
					rdMinProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plXproxy.Enabled = false;
					plTMProxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					pnlProxyFree.Enabled = false;
					tabProxy.SelectTab(1);
					break;
				case 6:
					rdProxy.Checked = true;
					rbXproxy.Checked = true;
					rbTMProxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rdMinProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plTMProxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					pnlProxyFree.Enabled = false;
					tabProxy.SelectTab(2);
					break;
				case 7:
					rdProxy.Checked = true;
					rbTMProxy.Checked = true;
					rbXproxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rdMinProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbProxyShoplike.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plXproxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					pnlProxyFree.Enabled = false;
					tabProxy.SelectTab(3);
					break;
				case 8:
					rdProxy.Checked = true;
					rbProxyShoplike.Checked = true;
					rbXproxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rdMinProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbTMProxy.Checked = false;
					rdProxyOrbit.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plTMProxy.Enabled = false;
					plXproxy.Enabled = false;
					pnlProxyFree.Enabled = false;
					tabProxy.SelectTab(4);
					break;
				case 9:
					rdProxy.Checked = true;
					rdProxyOrbit.Checked = true;
					rbProxyShoplike.Checked = false;
					rbXproxy.Checked = false;
					rdIPPortUserPass.Checked = false;
					rdMinProxy.Checked = false;
					rdTinsoftProxy.Checked = false;
					rbTMProxy.Checked = false;
					plChangeIPDcom.Enabled = false;
					plTinsoftProxy.Enabled = false;
					pnlAPIMinProxy.Enabled = false;
					plCheckDoiIP.Enabled = false;
					plTMProxy.Enabled = false;
					plXproxy.Enabled = false;
					plProxyShopLike.Enabled = false;
					tabProxy.SelectTab(5);
					break;
				}
				txtListDauso.Text = ((@class.method_1("txtListDauso") == "") ? "" : @class.method_1("txtListDauso"));
				cbLocationProxy.SelectedValue = @class.method_1("cbbLocationTinsoft");
				chk2FA.Checked = Convert.ToBoolean(@class.method_1("is2Fa"));
				nudDelayQR2Fa.Value = ((@class.method_1("nudDelayQR2Fa") == "") ? 10 : Convert.ToInt32(@class.method_1("nudDelayQR2Fa")));
				chkAvartar.Checked = Convert.ToBoolean(@class.method_1("isAvartar"));
				chkCoverImg.Checked = Convert.ToBoolean(@class.method_1("isCoverImg"));
				cbbPhoneCountry.SelectedIndex = Convert.ToInt32(@class.method_1("cbbPhoneCountry"));
				chkAddFUID.Checked = Convert.ToBoolean(@class.method_1("chkAddFUID"));
				chkInNewfeed.Checked = Convert.ToBoolean(@class.method_1("chkInNewfeed"));
				chkWStory.Checked = Convert.ToBoolean(@class.method_1("chkWStory"));
				chkWatch.Checked = Convert.ToBoolean(@class.method_1("chkWatch"));
				chkReadNotifi.Checked = Convert.ToBoolean(@class.method_1("chkReadNotifi"));
				nFriendFrom.Value = Convert.ToInt32(@class.method_1("nFriendFrom"));
				nFriendTo.Value = Convert.ToInt32(@class.method_1("nFriendTo"));
				chkLike.Checked = Convert.ToBoolean(@class.method_1("chkLike"));
				chkBuon.Checked = Convert.ToBoolean(@class.method_1("chkBuon"));
				chkTym.Checked = Convert.ToBoolean(@class.method_1("chkTym"));
				chkGian.Checked = Convert.ToBoolean(@class.method_1("chkGian"));
				chkHaha.Checked = Convert.ToBoolean(@class.method_1("chkHaha"));
				chkHideBrowser.Checked = Convert.ToBoolean(@class.method_1("chkHideBrowser"));
				txtLinkAvartar.Text = ((@class.method_1("linkAvartar") == "") ? "" : @class.method_1("linkAvartar"));
				cbbTypeProxyIP.SelectedIndex = ((!(@class.method_1("cbbTypeProxyIP") == "")) ? Convert.ToInt32(@class.method_1("cbbTypeProxyIP")) : 0);
				int_25 = ((@class.method_1("cbbTypeProxyIP") == "") ? (-1) : Convert.ToInt32(@class.method_1("cbbTypeProxyIP")));
				rdIPDong.Checked = !(@class.method_1("rdIPDong") == "") && Convert.ToBoolean(@class.method_1("rdIPDong"));
				rdIPStatic.Checked = !(@class.method_1("rdIPStatic") == "") && Convert.ToBoolean(@class.method_1("rdIPStatic"));
				plAddfriend.Enabled = chkAddFUID.Checked;
				gbCamxuc.Enabled = chkWStory.Checked;
				pnlAPIMinProxy.Enabled = rdMinProxy.Checked;
				if (chkLike.Checked)
				{
					list_10.Add(1.ToString());
				}
				if (chkTym.Checked)
				{
					list_10.Add(2.ToString());
				}
				if (chkHaha.Checked)
				{
					list_10.Add(3.ToString());
				}
				if (chkBuon.Checked)
				{
					list_10.Add(4.ToString());
				}
				if (chkGian.Checked)
				{
					list_10.Add(5.ToString());
				}
				string text3 = @class.method_1("apiMinProxy");
				if (text3 != string.Empty)
				{
					string[] array = text3.Split('|');
					string text4 = string.Empty;
					for (int i = 0; i < array.Length; i++)
					{
						list_11.Add(array[i]);
						text4 += array[i];
						if (i < array.Length - 1)
						{
							text4 += Environment.NewLine;
						}
					}
					txtApiKeyMinProxy.Text = text4;
				}
				txtServiceURLXProxy.Text = ((@class.method_1("txtServiceURLXProxy") == "") ? "" : @class.method_1("txtServiceURLXProxy"));
				if (@class.method_1("typeXProxy") == "" || Convert.ToInt32(@class.method_1("typeXProxy")) == 0)
				{
					rbHttpProxy.Checked = true;
				}
				else
				{
					rbSock5Proxy.Checked = true;
				}
				nudLuongPerIPXProxy.Value = ((@class.method_1("nudLuongPerIPXProxy") == "") ? 1 : Convert.ToInt32(@class.method_1("nudLuongPerIPXProxy")));
				nudDelayResetXProxy.Value = ((@class.method_1("nudDelayResetXProxy") == "") ? 1 : Convert.ToInt32(@class.method_1("nudDelayResetXProxy")));
				ckbWaitDoneAllXproxy.Checked = !(@class.method_1("ckbWaitDoneAllXproxy") == "") && Convert.ToBoolean(@class.method_1("ckbWaitDoneAllXproxy"));
				if (@class.method_1("typeRunXproxy") == "" || Convert.ToInt32(@class.method_1("typeRunXproxy")) == 0)
				{
					rbXproxyResetEachProxy.Checked = true;
				}
				else
				{
					rbXproxyResetAllProxy.Checked = true;
				}
				string text5 = @class.method_1("txtListXProxy");
				if (text5 != string.Empty)
				{
					string[] array2 = text5.Split(';');
					string text6 = string.Empty;
					for (int j = 0; j < array2.Length; j++)
					{
						text6 += array2[j];
						if (j < array2.Length - 1)
						{
							text6 += Environment.NewLine;
						}
					}
					txtListXProxy.Text = text6;
				}
				nudLuongPerIPTMProxy.Value = ((@class.method_1("nudLuongPerIPTMProxy") == "") ? 1 : Convert.ToInt32(@class.method_1("nudLuongPerIPTMProxy")));
				string text7 = @class.method_1("txtApiKeyTMProxy");
				if (text7 != string.Empty)
				{
					string[] array3 = text7.Split('|');
					string text8 = string.Empty;
					for (int k = 0; k < array3.Length; k++)
					{
						text8 += array3[k];
						if (k < array3.Length - 1)
						{
							text8 += Environment.NewLine;
						}
					}
					txtApiKeyTMProxy.Text = text8;
				}
				nudThreadShopLike.Value = ((@class.method_1("nudThreadShopLike") == "") ? 1 : Convert.ToInt32(@class.method_1("nudThreadShopLike")));
				string text9 = @class.method_1("txtAPIKeyShoplike");
				if (text9 != string.Empty)
				{
					string[] array4 = text9.Split('|');
					string text10 = string.Empty;
					for (int l = 0; l < array4.Length; l++)
					{
						text10 += array4[l];
						if (l < array4.Length - 1)
						{
							text10 += Environment.NewLine;
						}
					}
					txtAPIKeyShoplike.Text = text10;
				}
				switch ((!(@class.method_1("typeProxyOrbit") == "")) ? Convert.ToInt32(@class.method_1("typeProxyOrbit")) : 0)
				{
				case 1:
					rdProxyFreeUS.Checked = true;
					break;
				case 2:
					rdProxyFreeRandom.Checked = true;
					break;
				default:
					rdProxyFreeVN.Checked = true;
					break;
				}
			}
			catch
			{
			}
		}

		private void btnSaveConf_Click(object sender, EventArgs e)
		{
			try
			{
				Class48 @class = new Class48("setting.ini");
				@class.method_2("cbModeRunReg", cbModeRunReg.SelectedIndex.ToString());
				@class.method_2("nudThread", numThrLdPlay.Value.ToString());
				@class.method_2("nudThoiGianChoNhapOTP", numOTP.Value.ToString());
				int num = 0;
				if (rdNormal.Checked)
				{
					num = 0;
				}
				else if (rdSwap.Checked)
				{
					num = 1;
				}
				@class.method_2("modeRun", num.ToString());
				int num2 = 0;
				if (rdDelayLD.Checked)
				{
					num2 = 1;
				}
				@class.method_2("optionMemu", num2.ToString());
				@class.method_2("numDelayFr", numDelayFr.Value.ToString());
				@class.method_2("numDelayTo", numDelayTo.Value.ToString());
				@class.method_2("numDeClsFr", numDeClsFr.Value.ToString());
				@class.method_2("numDeClsTo", numDeClsTo.Value.ToString());
				@class.method_2("linkLD", txtLinkLD.Text.Trim());
				@class.method_2("nAgeFrom", nAgeFrom.Value.ToString());
				@class.method_2("nAgeTo", nAgeTo.Value.ToString());
				@class.method_2("nudTimeWaitOTP", nudTimeWaitOTP.Value.ToString());
				int num3 = 0;
				if (rdNoChangeIP.Checked)
				{
					num3 = 0;
				}
				else if (rdChangeIPDcom.Checked)
				{
					num3 = 1;
				}
				else if (rdProxy.Checked)
				{
					if (rdTinsoftProxy.Checked)
					{
						num3 = 2;
					}
					else if (rdMinProxy.Checked)
					{
						num3 = 3;
					}
					else if (rdIPPortUserPass.Checked)
					{
						num3 = 5;
					}
					else if (rbXproxy.Checked)
					{
						num3 = 6;
					}
					else if (rbTMProxy.Checked)
					{
						num3 = 7;
					}
					else if (rbProxyShoplike.Checked)
					{
						num3 = 8;
					}
					else if (rdProxyOrbit.Checked)
					{
						num3 = 9;
					}
				}
				else if (rdHMA.Checked)
				{
					num3 = 4;
				}
				@class.method_2("rdIPStatic", rdIPStatic.Checked.ToString());
				@class.method_2("rdIPDong", rdIPDong.Checked.ToString());
				@class.method_2("typeChangeIp", num3.ToString());
				@class.method_2("txtProfileNameDcom", txtNameDcom.Text);
				@class.method_2("txtAPIProxy", txtProxy.Text);
				@class.method_2("cbbLocationTinsoft", cbLocationProxy.SelectedValue.ToString());
				@class.method_2("nudLuongPerIPTinsoft", nudLuongPerIPTinsoft.Value.ToString());
				@class.method_2("nudSoLuotChay", nudSoLuotChay.Value.ToString());
				@class.method_2("nudLuongPerIPMinProxy", nudLuongPerIPMinProxy.Value.ToString());
				@class.method_2("nudLuongPerIPTMProxy", nudLuongPerIPTMProxy.Value.ToString());
				@class.method_2("nudThreadShopLike", nudThreadShopLike.Value.ToString());
				@class.method_2("txtListDauso", txtListDauso.Text.ToString());
				int num4 = 0;
				if (rdProxyOrbit.Checked)
				{
					if (rdProxyFreeUS.Checked)
					{
						num4 = 1;
					}
					else if (rdProxyFreeRandom.Checked)
					{
						num4 = 2;
					}
				}
				@class.method_2("typeProxyOrbit", num4.ToString());
				if (txtApiKeyMinProxy.Text != "")
				{
					string[] array = txtApiKeyMinProxy.Text.Split('\n');
					if (array.Length != 0)
					{
						string text = string.Empty;
						for (int i = 0; i < array.Length; i++)
						{
							text += array[i];
							if (i < array.Length - 1)
							{
								text += "|";
							}
						}
						@class.method_2("apiMinProxy", text);
					}
				}
				else
				{
					@class.method_2("apiMinProxy", string.Empty);
				}
				if (txtApiKeyTMProxy.Text != "")
				{
					string[] array2 = txtApiKeyTMProxy.Text.Split('\n');
					if (array2.Length != 0)
					{
						string text2 = string.Empty;
						for (int j = 0; j < array2.Length; j++)
						{
							text2 += array2[j];
							if (j < array2.Length - 1)
							{
								text2 += "|";
							}
						}
						@class.method_2("txtApiKeyTMProxy", text2);
					}
				}
				else
				{
					@class.method_2("txtApiKeyTMProxy", string.Empty);
				}
				if (txtAPIKeyShoplike.Text != "")
				{
					string[] array3 = txtAPIKeyShoplike.Text.Split('\n');
					if (array3.Length != 0)
					{
						string text3 = string.Empty;
						for (int k = 0; k < array3.Length; k++)
						{
							text3 += array3[k];
							if (k < array3.Length - 1)
							{
								text3 += "|";
							}
						}
						@class.method_2("txtAPIKeyShoplike", text3);
					}
				}
				else
				{
					@class.method_2("txtAPIKeyShoplike", string.Empty);
				}
				string text4 = "";
				if (rdNoVeri.Checked)
				{
					if (rdNovriPhone.Checked)
					{
						text4 = "00" + cbbPhoneCountry.SelectedIndex;
					}
					else if (rdNoveriMail.Checked)
					{
						text4 = "01" + cbMailAo.SelectedIndex;
					}
				}
				else if (rdThuePhone.Checked)
				{
					text4 = "10" + cbDvSim.SelectedIndex;
				}
				else if (rdHotMailReg.Checked)
				{
					text4 = "110";
				}
				else if (rdHotMailRegisted.Checked)
				{
					text4 = "111";
				}
				else if (rdTempMailIO.Checked)
				{
					text4 = "112";
				}
				else if (rdMailTM.Checked)
				{
					text4 = "113";
				}
				@class.method_2("typeVerify", text4);
				@class.method_2("txtAPISim", txtAPISim.Text);
				@class.method_2("txtAPIAnyCat", txtAPIAnyCat.Text);
				@class.method_2("txtPassmail", txtPassmail.Text);
				@class.method_2("ckTaoMailBox", ckTaoMailBox.Checked.ToString());
				@class.method_2("ckRdPassmail", ckRdPassmail.Checked.ToString());
				@class.method_2("typeNameReg", cbNameReg.SelectedIndex.ToString());
				@class.method_2("passFB", txtPassFb.Text);
				@class.method_2("isRdPass", chkRandomPass.Checked.ToString());
				@class.method_2("ckCheckIP", ckCheckIP.Checked.ToString());
				int num5 = 0;
				@class.method_2("typeGender", ((!rbFemale.Checked) ? (rbMale.Checked ? 1 : 2) : 0).ToString());
				@class.method_2("is2Fa", chk2FA.Checked.ToString());
				@class.method_2("nudDelayQR2Fa", nudDelayQR2Fa.Value.ToString());
				@class.method_2("isAvartar", chkAvartar.Checked.ToString());
				@class.method_2("isCoverImg", chkCoverImg.Checked.ToString());
				@class.method_2("cbbPhoneCountry", cbbPhoneCountry.SelectedIndex.ToString());
				@class.method_2("iSoLuotDoiIpMotLan", numChangeIP.Value.ToString());
				@class.method_2("chkReadNotifi", chkReadNotifi.Checked.ToString());
				@class.method_2("chkWatch", chkWatch.Checked.ToString());
				@class.method_2("chkWStory", chkWStory.Checked.ToString());
				@class.method_2("chkInNewfeed", chkInNewfeed.Checked.ToString());
				@class.method_2("chkAddFUID", chkAddFUID.Checked.ToString());
				@class.method_2("nFriendFrom", nFriendFrom.Value.ToString());
				@class.method_2("nFriendTo", nFriendTo.Value.ToString());
				@class.method_2("chkLike", chkLike.Checked.ToString());
				@class.method_2("chkGian", chkGian.Checked.ToString());
				@class.method_2("chkHaha", chkHaha.Checked.ToString());
				@class.method_2("chkBuon", chkBuon.Checked.ToString());
				@class.method_2("chkTym", chkTym.Checked.ToString());
				@class.method_2("chkHideBrowser", chkHideBrowser.Checked.ToString());
				@class.method_2("linkAvartar", txtLinkAvartar.Text.Trim());
				if (rdIPPortUserPass.Checked)
				{
					@class.method_2("cbbTypeProxyIP", cbbTypeProxyIP.SelectedIndex.ToString());
				}
				@class.method_2("txtServiceURLXProxy", txtServiceURLXProxy.Text.Trim());
				int num6 = 0;
				if (rbSock5Proxy.Checked)
				{
					num6 = 1;
				}
				@class.method_2("typeXProxy", num6.ToString());
				@class.method_2("nudLuongPerIPXProxy", nudLuongPerIPXProxy.Value.ToString());
				@class.method_2("nudDelayResetXProxy", nudDelayResetXProxy.Value.ToString());
				@class.method_2("ckbWaitDoneAllXproxy", ckbWaitDoneAllXproxy.Checked.ToString());
				int num7 = 0;
				if (rbXproxyResetAllProxy.Checked)
				{
					num7 = 1;
				}
				@class.method_2("typeRunXproxy", num7.ToString());
				if (txtListXProxy.Text != "")
				{
					string[] array4 = txtListXProxy.Text.Split('\n');
					if (array4.Length != 0)
					{
						string text5 = string.Empty;
						for (int l = 0; l < array4.Length; l++)
						{
							text5 += array4[l];
							if (l < array4.Length - 1)
							{
								text5 += ";";
							}
						}
						@class.method_2("txtListXProxy", text5);
					}
				}
				else
				{
					@class.method_2("txtListXProxy", string.Empty);
				}
				MessageBox.Show("Lưu cấu hình thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch
			{
			}
		}

		private void btnStop_Click(object sender, EventArgs e)
		{
			btnStop.Text = "Đang dừng...";
			bool_0 = true;
			list_17.Clear();
			list_18.Clear();
			list_19.Clear();
		}

		private void method_62(int int_41, string string_21, Device device_0 = null)
		{
			try
			{
				method_52(string_21, "status", int_41, 0, dgvAcc);
				if (device_0 != null)
				{
					if (string_21.StartsWith("("))
					{
						string_21 = string_21.Substring(string_21.IndexOf(")") + 1);
					}
					device_0.method_112(string_21);
				}
			}
			catch (Exception exception_)
			{
				Common.smethod_82(exception_, "SetStatusAccount");
			}
		}

		private void btnCheckSim_Click(object sender, EventArgs e)
		{
			try
			{
				if (!rdThuePhone.Checked)
				{
					return;
				}
				string text = txtAPISim.Text.ToString();
				string empty = string.Empty;
				if (cbDvSim.SelectedIndex == 0)
				{
					empty = Common.smethod_10(text);
					if (empty == "")
					{
						MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Số tiền: " + empty, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (cbDvSim.SelectedIndex == 1)
				{
					empty = Common.smethod_15(text);
					if (empty == "")
					{
						MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Số tiền: " + empty, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (cbDvSim.SelectedIndex == 2)
				{
					if (Common.smethod_16(text))
					{
						MessageBox.Show("Api key hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Api key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (cbDvSim.SelectedIndex == 3)
				{
					MessageBox.Show("OTPMMO không hỗ trợ API check Balance!!!" + Environment.NewLine + "Bạn kiểm tra số tiền trên web https://otpmmo.com trước khi chạy nha! ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else if (cbDvSim.SelectedIndex == 4)
				{
					if (Common.smethod_17(text))
					{
						MessageBox.Show("Api key hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Api key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (cbDvSim.SelectedIndex == 5)
				{
					empty = Common.smethod_13(text);
					if (empty == "")
					{
						MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Số tiền: " + empty, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
				else if (cbDvSim.SelectedIndex == 6)
				{
					empty = Common.smethod_14(text);
					if (empty == "")
					{
						MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
					else
					{
						MessageBox.Show("Số tiền: " + empty, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					}
				}
			}
			catch (Exception)
			{
				MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void frmMain_Load(object sender, EventArgs e)
		{
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
		{
			method_13();
		}

		private void btnGetDcom_Click(object sender, EventArgs e)
		{
			try
			{
				ProcessStartInfo startInfo = new ProcessStartInfo("rasdial.exe")
				{
					UseShellExecute = false,
					RedirectStandardOutput = true,
					CreateNoWindow = true
				};
				Process process = Process.Start(startInfo);
				string text = process.StandardOutput.ReadToEnd();
				if (text.Split('\n').Length <= 3)
				{
					MessageBox.Show("Vui lòng kết nối Dcom trước!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					return;
				}
				txtNameDcom.Text = text.Split('\n').ToList()[1];
				MessageBox.Show("Lấy tên cấu hình Dcom thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			catch (Exception)
			{
				MessageBox.Show("Có lỗi xảy ra, vui lòng thử lại sau", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void method_63(object sender, EventArgs e)
		{
			plTinsoftProxy.Enabled = rdTinsoftProxy.Checked;
		}

		private void rdConfMail_CheckedChanged(object sender, EventArgs e)
		{
			Panel panel = plVeriMail;
			bool enabled = (pnlTemmail.Enabled = rdConfMail.Checked);
			panel.Enabled = enabled;
		}

		private void rdThuePhone_CheckedChanged(object sender, EventArgs e)
		{
			plVeriPhone.Enabled = rdThuePhone.Checked;
		}

		private void btnCheckProxy_Click(object sender, EventArgs e)
		{
			string text = txtProxy.Text.Trim();
			List<string> list = Class67.smethod_2(text);
			if (list.Count > 0)
			{
				MessageBox.Show($"Đang có {list.Count} proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Không có proxy khả dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rdNoVeri_CheckedChanged(object sender, EventArgs e)
		{
			plNovery.Enabled = rdNoVeri.Checked;
			rdNovriPhone.Checked = true;
		}

		private void toolStripMenuItem_1_Click(object sender, EventArgs e)
		{
			method_66("All");
		}

		private bool method_64(int int_41, Device device_0)
		{
			bool flag = false;
			string text = "";
			for (int i = 0; i < 3; i++)
			{
				device_0.method_125();
				device_0.method_121(5.0);
				for (int j = 0; j < 5; j++)
				{
					if (device_0.method_3("DataClick\\fblite\\menu"))
					{
						flag = true;
						break;
					}
				}
				int num = 0;
				if (!flag)
				{
					continue;
				}
				while (num < 5)
				{
					if (!device_0.method_3("DataClick\\fblite\\caidat"))
					{
						if (!device_0.method_81(500))
						{
							flag = false;
							device_0.method_121(1.0);
							num++;
						}
						continue;
					}
					flag = true;
					break;
				}
				int num2 = 0;
				if (!flag)
				{
					continue;
				}
				device_0.method_121(3.0);
				while (num2 < 5)
				{
					if (!device_0.method_3("DataClick\\fblite\\securityandlogin"))
					{
						if (!device_0.method_81(500))
						{
							flag = false;
							device_0.method_121(1.0);
							num2++;
						}
						continue;
					}
					flag = true;
					break;
				}
				int num3 = 0;
				if (!flag)
				{
					continue;
				}
				while (num3 < 5)
				{
					if (!device_0.method_3("DataClick\\fblite\\usetwoauthen"))
					{
						if (!device_0.method_81(500))
						{
							flag = false;
							device_0.method_121(1.0);
							num3++;
						}
						continue;
					}
					flag = true;
					break;
				}
				int k = 0;
				if (!flag)
				{
					continue;
				}
				for (; k < 5; k++)
				{
					if (!device_0.method_3("DataClick\\fblite\\useappverify"))
					{
						flag = false;
						continue;
					}
					flag = true;
					break;
				}
				if (!flag)
				{
					continue;
				}
				for (int l = 0; l < 3; l++)
				{
					try
					{
						method_62(int_41, "Chờ " + int_34 + " giây để quét QRCode", device_0);
						device_0.method_121(int_34);
						Bitmap bitmap_ = device_0.method_33();
						text = Common.smethod_67(bitmap_);
						text = Regex.Match(text, "secret=(.*?)&").Groups[1].Value;
						if (!string.IsNullOrEmpty(text))
						{
							flag = true;
							break;
						}
						flag = false;
						device_0.method_121(1.0);
						continue;
					}
					catch (Exception exception_)
					{
						method_62(int_41, "Không quét được mã QRCode. Thực hiện lại", device_0);
						Common.smethod_82(exception_, "ScanQRCode2Fa");
						flag = false;
					}
					break;
				}
				if (!string.IsNullOrEmpty(text))
				{
					method_22(int_41, "conf_2fa", text);
					int num4 = 0;
					while (num4 < 10)
					{
						if (!device_0.method_3("DataClick\\fblite\\next"))
						{
							if (!device_0.method_81(500))
							{
								flag = false;
								device_0.method_121(1.0);
								num4++;
							}
							continue;
						}
						flag = true;
						break;
					}
					if (flag)
					{
						string text2 = Common.smethod_72(text);
						device_0.method_121(2.0);
						device_0.method_3("DataClick\\fblite\\codeotp");
						device_0.method_121(1.0);
						device_0.method_49(text2, bool_0: false, bool_1: false);
						device_0.method_121(1.0);
						device_0.method_3("DataClick\\fblite\\next");
						device_0.method_121(5.0);
						break;
					}
				}
				else
				{
					flag = false;
				}
			}
			return flag;
		}

		private bool method_65(string string_21, Device device_0)
		{
			bool flag = false;
			device_0.method_126(string_21);
			device_0.method_121(1.0);
			for (int i = 0; i < 10; i++)
			{
				if (device_0.method_52("DataClick\\fblite\\x"))
				{
					device_0.method_3("DataClick\\fblite\\x");
					flag = true;
					break;
				}
			}
			if (flag)
			{
				device_0.method_85("shell rm /sdcard/*.png");
				device_0.method_85("shell am broadcast -a android.intent.action.MEDIA_MOUNTED -d file:///sdcard/Pictures");
				device_0.method_121(2.0);
				if (device_0.method_52("DataClick\\fblite\\avartar"))
				{
					device_0.method_3("DataClick\\fblite\\avartar");
				}
				device_0.method_121(2.0);
				if (device_0.method_52("DataClick\\fblite\\taianhlen"))
				{
					device_0.method_3("DataClick\\fblite\\taianhlen");
				}
				device_0.method_121(1.0);
				device_0.method_91(143, 324);
				string text = "";
				for (int j = 0; j < 5; j++)
				{
					text = device_0.method_94();
					List<string> list = device_0.method_77("\"android.widget.imageview\"", text);
					if (list.Count >= 2)
					{
						int num = random_0.Next(0, 10);
						for (int k = 0; k < num; k++)
						{
							if (device_0.method_81(500, 2, "[125,444][179,465]", "[146,313][223,348]", "[124,359][196,423]"))
							{
								break;
							}
							device_0.method_121(1.0);
						}
					}
					device_0.method_89("[40,100][300,400]");
					device_0.method_121(5.0);
					if (device_0.method_52("DataClick\\fblite\\capnhat"))
					{
						device_0.method_3("DataClick\\fblite\\capnhat");
						flag = true;
						device_0.method_121(10.0);
						break;
					}
				}
			}
			return flag;
		}

		private void method_66(string string_21)
		{
			switch (string_21)
			{
			case "ToggleCheck":
			{
				for (int k = 0; k < dgvAcc.SelectedRows.Count; k++)
				{
					int index = dgvAcc.SelectedRows[k].Index;
					method_22(index, "cChose", !Convert.ToBoolean(method_1(index, "cChose")));
				}
				method_67();
				break;
			}
			case "SelectHighline":
			{
				DataGridViewSelectedRowCollection selectedRows = dgvAcc.SelectedRows;
				for (int j = 0; j < selectedRows.Count; j++)
				{
					method_22(selectedRows[j].Index, "cChose", true);
				}
				method_67();
				break;
			}
			case "UnAll":
			{
				for (int l = 0; l < dgvAcc.RowCount; l++)
				{
					method_22(l, "cChose", false);
				}
				method_67(0);
				break;
			}
			case "All":
			{
				for (int i = 0; i < dgvAcc.RowCount; i++)
				{
					method_22(i, "cChose", true);
				}
				method_67(dgvAcc.RowCount);
				break;
			}
			}
		}

		private void method_67(int int_41 = -1)
		{
			if (int_41 == -1)
			{
				int_41 = 0;
				for (int i = 0; i < dgvAcc.Rows.Count; i++)
				{
					if (Convert.ToBoolean(dgvAcc.Rows[i].Cells["cChose"].Value))
					{
						int_41++;
					}
				}
			}
			lblCountSelect.Text = int_41.ToString();
		}

		private void toolStripMenuItem_3_Click(object sender, EventArgs e)
		{
			method_66("UnAll");
		}

		private void toolStripMenuItem_2_Click(object sender, EventArgs e)
		{
			method_66("SelectHighline");
		}

		private uint method_68(string string_21)
		{
			uint num = 0u;
			if (string_21 != null)
			{
				num = 2166136261u;
				for (int i = 0; i < string_21.Length; i++)
				{
					num = (string_21[i] ^ num) * 16777619;
				}
			}
			return num;
		}

		private void method_69(string string_21)
		{
			try
			{
				string text = "";
				List<string> list = new List<string>();
				int num = 0;
				while (true)
				{
					if (num < dgvAcc.Rows.Count)
					{
						if (Convert.ToBoolean(method_1(num, "cChose")))
						{
							break;
						}
						num++;
						continue;
					}
					return;
				}
				list.Add(method_1(num, "cId"));
				if (list.Count == 0)
				{
					MessageBox.Show("Vui lòng chọn danh sách tài khoản muốn copy thông tin!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				switch (method_68(string_21))
				{
				case 457434463u:
				{
					if (!(string_21 == "uid|pass|token|cookie"))
					{
						break;
					}
					for (int num9 = 0; num9 < dgvAcc.RowCount; num9++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num9].Cells["cChose"].Value))
						{
							text = text + method_1(num9, "uid") + "|" + method_1(num9, "pass") + "|" + method_1(num9, "token") + "|" + method_1(num9, "cookie") + "\r\n";
						}
					}
					break;
				}
				case 159575910u:
				{
					if (!(string_21 == "uid|pass"))
					{
						break;
					}
					for (int num7 = 0; num7 < dgvAcc.RowCount; num7++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num7].Cells["cChose"].Value))
						{
							text = text + method_1(num7, "uid") + "|" + method_1(num7, "pass") + "\r\n";
						}
					}
					break;
				}
				case 1329202400u:
				{
					if (!(string_21 == "mail|passmail"))
					{
						break;
					}
					for (int m = 0; m < dgvAcc.RowCount; m++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[m].Cells["cChose"].Value))
						{
							text = text + method_1(m, "email") + "|" + method_1(m, "passMail") + "\r\n";
						}
					}
					break;
				}
				case 738560386u:
					if (!(string_21 == "ma2fa"))
					{
					}
					break;
				case 1718322808u:
				{
					if (!(string_21 == "2fa"))
					{
						break;
					}
					for (int num3 = 0; num3 < dgvAcc.RowCount; num3++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num3].Cells["cChose"].Value))
						{
							text = text + method_1(num3, "cFa2") + "\r\n";
						}
					}
					break;
				}
				case 1556604621u:
				{
					if (!(string_21 == "uid"))
					{
						break;
					}
					for (int num12 = 0; num12 < dgvAcc.RowCount; num12++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num12].Cells["cChose"].Value))
						{
							text = text + method_1(num12, "cUid") + "\r\n";
						}
					}
					break;
				}
				case 2071622424u:
				{
					if (!(string_21 == "pass"))
					{
						break;
					}
					for (int num4 = 0; num4 < dgvAcc.RowCount; num4++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num4].Cells["cChose"].Value))
						{
							text = text + method_1(num4, "cPassword") + "\r\n";
						}
					}
					break;
				}
				case 2000032175u:
				{
					if (!(string_21 == "phone"))
					{
						break;
					}
					for (int j = 0; j < dgvAcc.RowCount; j++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[j].Cells["cChose"].Value))
						{
							text = text + method_1(j, "phone") + "\r\n";
						}
					}
					break;
				}
				case 2007449791u:
				{
					if (!(string_21 == "cookie"))
					{
						break;
					}
					for (int num10 = 0; num10 < dgvAcc.RowCount; num10++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num10].Cells["cChose"].Value))
						{
							string text2 = method_1(num10, "cCookies");
							text = text + text2 + "\r\n";
						}
					}
					break;
				}
				case 2337339239u:
				{
					if (!(string_21 == "useragent"))
					{
						break;
					}
					for (int num6 = 0; num6 < dgvAcc.RowCount; num6++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num6].Cells["cChose"].Value))
						{
							text = text + method_1(num6, "cUseragent") + "\r\n";
						}
					}
					break;
				}
				case 2107770459u:
				{
					if (!(string_21 == "proxy"))
					{
						break;
					}
					for (int n = 0; n < dgvAcc.RowCount; n++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[n].Cells["cChose"].Value))
						{
							text = text + method_1(n, "uid") + "|" + method_1(n, "pass") + "|" + method_1(n, "conf_2fa") + "|" + method_1(n, "cookie") + "|" + method_1(n, "token") + "|" + method_1(n, "ho") + "|" + method_1(n, "ten") + "|" + method_1(n, "gender") + "|" + method_1(n, "phone") + "|" + method_1(n, "email") + "|" + method_1(n, "passMail") + "|" + method_1(n, "proxy") + "\r\n";
						}
					}
					break;
				}
				case 2491017778u:
				{
					if (!(string_21 == "token"))
					{
						break;
					}
					for (int k = 0; k < dgvAcc.RowCount; k++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[k].Cells["cChose"].Value))
						{
							text = text + method_1(k, "cToken") + "\r\n";
						}
					}
					break;
				}
				case 2369371622u:
				{
					if (!(string_21 == "name"))
					{
						break;
					}
					for (int num11 = 0; num11 < dgvAcc.RowCount; num11++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num11].Cells["cChose"].Value))
						{
							text = text + method_1(num11, "cName") + "\r\n";
						}
					}
					break;
				}
				case 3144981877u:
				{
					if (!(string_21 == "uid|pass|2fa"))
					{
						break;
					}
					for (int num8 = 0; num8 < dgvAcc.RowCount; num8++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num8].Cells["cChose"].Value))
						{
							text = text + method_1(num8, "uid") + "|" + method_1(num8, "pass") + "|" + method_1(num8, "conf_2fa") + "\r\n";
						}
					}
					break;
				}
				case 2703251604u:
				{
					if (!(string_21 == "uid|pass|token|cookie|mail|passmail"))
					{
						break;
					}
					for (int num5 = 0; num5 < dgvAcc.RowCount; num5++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num5].Cells["cChose"].Value))
						{
							text = text + method_1(num5, "cUid") + "|" + method_1(num5, "cPassword") + "|" + method_1(num5, "cToken") + "|" + method_1(num5, "cCookies") + "|" + method_1(num5, "cEmail") + "|" + method_1(num5, "cPassMail") + "\r\n";
						}
					}
					break;
				}
				case 4025178668u:
				{
					if (!(string_21 == "birthday"))
					{
						break;
					}
					for (int num2 = 0; num2 < dgvAcc.RowCount; num2++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[num2].Cells["cChose"].Value))
						{
							text = text + method_1(num2, "cBirthday") + "\r\n";
						}
					}
					break;
				}
				case 3968918830u:
				{
					if (!(string_21 == "mail"))
					{
						break;
					}
					for (int l = 0; l < dgvAcc.RowCount; l++)
					{
						if (Convert.ToBoolean(dgvAcc.Rows[l].Cells["cChose"].Value))
						{
							text = text + method_1(l, "cEmail") + "\r\n";
						}
					}
					break;
				}
				case 3728375369u:
					if (string_21 == "uid|pass|token|cookie|mail|passmail|fa2")
					{
						for (int i = 0; i < dgvAcc.RowCount; i++)
						{
							if (Convert.ToBoolean(dgvAcc.Rows[i].Cells["cChose"].Value))
							{
								text = text + method_1(i, "cUid") + "|" + method_1(i, "cPassword") + "|" + method_1(i, "cToken") + "|" + method_1(i, "cCookies") + "|" + method_1(i, "cEmail") + "|" + method_1(i, "cPassMail") + "|" + method_1(i, "cFa2") + "\r\n";
							}
						}
					}
					else if (!(string_21 == "all"))
					{
					}
					break;
				}
				Clipboard.SetText(text.TrimEnd('\r', '\n'));
			}
			catch
			{
			}
		}

		private void uidPassToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("uid|pass");
		}

		private void uidPassTokenCookieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("uid|pass|token|cookie");
		}

		private void method_70(object sender, EventArgs e)
		{
		}

		private void method_71(object sender, EventArgs e)
		{
		}

		private string method_72(int int_41)
		{
			string text;
			do
			{
				text = "";
				text = method_53().Trim();
				int num = 10 - text.Length;
				if (int_41 == 209)
				{
					num--;
				}
				if (num > 0)
				{
					for (int i = 0; i < num; i++)
					{
						text += random_0.Next(0, 9);
					}
				}
				switch (int_41)
				{
				case 0:
					text = "+93" + text;
					break;
				case 1:
					text = "+355" + text;
					break;
				case 2:
					text = "+213" + text;
					break;
				case 3:
					text = "+684" + text;
					break;
				case 4:
					text = "+376" + text;
					break;
				case 5:
					text = "+244" + text;
					break;
				case 6:
					text = "+1264" + text;
					break;
				case 7:
					text = "+1268" + text;
					break;
				case 8:
					text = "+54" + text;
					break;
				case 9:
					text = "+374" + text;
					break;
				case 10:
					text = "+297" + text;
					break;
				case 11:
					text = "+61" + text;
					break;
				case 12:
					text = "+43" + text;
					break;
				case 13:
					text = "+994" + text;
					break;
				case 14:
					text = "+1242" + text;
					break;
				case 15:
					text = "+973" + text;
					break;
				case 16:
					text = "+880" + text;
					break;
				case 17:
					text = "+1246" + text;
					break;
				case 18:
					text = "+375" + text;
					break;
				case 19:
					text = "+32" + text;
					break;
				case 20:
					text = "+501" + text;
					break;
				case 21:
					text = "+229" + text;
					break;
				case 22:
					text = "+1441" + text;
					break;
				case 23:
					text = "+975" + text;
					break;
				case 24:
					text = "+591" + text;
					break;
				case 25:
					text = "+387" + text;
					break;
				case 26:
					text = "+267" + text;
					break;
				case 27:
					text = "+55" + text;
					break;
				case 28:
					text = "+673" + text;
					break;
				case 29:
					text = "+359" + text;
					break;
				case 30:
					text = "+226" + text;
					break;
				case 31:
					text = "+257" + text;
					break;
				case 32:
					text = "+855" + text;
					break;
				case 33:
					text = "+237" + text;
					break;
				case 34:
					text = "+1" + text;
					break;
				case 35:
					text = "+238" + text;
					break;
				case 36:
					text = "+1345" + text;
					break;
				case 37:
					text = "+236" + text;
					break;
				case 38:
					text = "+235" + text;
					break;
				case 39:
					text = "+246" + text;
					break;
				case 40:
					text = "+56" + text;
					break;
				case 41:
					text = "+86" + text;
					break;
				case 42:
					text = "+57" + text;
					break;
				case 43:
					text = "+269" + text;
					break;
				case 44:
					text = "+242" + text;
					break;
				case 45:
					text = "+243" + text;
					break;
				case 46:
					text = "+682" + text;
					break;
				case 47:
					text = "+506" + text;
					break;
				case 48:
					text = "+225" + text;
					break;
				case 49:
					text = "+385" + text;
					break;
				case 50:
					text = "+53" + text;
					break;
				case 51:
					text = "+420" + text;
					break;
				case 52:
					text = "+45" + text;
					break;
				case 53:
					text = "+253" + text;
					break;
				case 54:
					text = "+1767" + text;
					break;
				case 55:
					text = "+357" + text;
					break;
				case 56:
					text = "+593" + text;
					break;
				case 57:
					text = "+20" + text;
					break;
				case 58:
					text = "+503" + text;
					break;
				case 59:
					text = "+240" + text;
					break;
				case 60:
					text = "+372" + text;
					break;
				case 61:
					text = "+251" + text;
					break;
				case 62:
					text = "+298" + text;
					break;
				case 63:
					text = "+500" + text;
					break;
				case 64:
					text = "+679" + text;
					break;
				case 65:
					text = "+358" + text;
					break;
				case 66:
					text = "+33" + text;
					break;
				case 67:
					text = "+596" + text;
					break;
				case 68:
					text = "+594" + text;
					break;
				case 69:
					text = "+689" + text;
					break;
				case 70:
					text = "+241" + text;
					break;
				case 71:
					text = "+220" + text;
					break;
				case 72:
					text = "+995" + text;
					break;
				case 73:
					text = "+49" + text;
					break;
				case 74:
					text = "+233" + text;
					break;
				case 75:
					text = "+350" + text;
					break;
				case 76:
					text = "+30" + text;
					break;
				case 77:
					text = "+299" + text;
					break;
				case 78:
					text = "+1473" + text;
					break;
				case 79:
					text = "+590" + text;
					break;
				case 80:
					text = "+1671" + text;
					break;
				case 81:
					text = "+502" + text;
					break;
				case 82:
					text = "+224" + text;
					break;
				case 83:
					text = "+245" + text;
					break;
				case 84:
					text = "+592" + text;
					break;
				case 85:
					text = "+509" + text;
					break;
				case 86:
					text = "+504" + text;
					break;
				case 87:
					text = "+852" + text;
					break;
				case 88:
					text = "+36" + text;
					break;
				case 89:
					text = "+354" + text;
					break;
				case 90:
					text = "+91" + text;
					break;
				case 91:
					text = "+62" + text;
					break;
				case 92:
					text = "+98" + text;
					break;
				case 93:
					text = "+964" + text;
					break;
				case 94:
					text = "+353" + text;
					break;
				case 95:
					text = "+972" + text;
					break;
				case 96:
					text = "+39" + text;
					break;
				case 97:
					text = "+225" + text;
					break;
				case 98:
					text = "+1876" + text;
					break;
				case 99:
					text = "+81" + text;
					break;
				case 100:
					text = "+962" + text;
					break;
				case 101:
					text = "+254" + text;
					break;
				case 102:
					text = "+850" + text;
					break;
				case 103:
					text = "+82" + text;
					break;
				case 104:
					text = "+965" + text;
					break;
				case 105:
					text = "+996" + text;
					break;
				case 106:
					text = "+260" + text;
					break;
				case 107:
					text = "+263" + text;
					break;
				case 108:
					text = "+856" + text;
					break;
				case 109:
					text = "+371" + text;
					break;
				case 110:
					text = "+961" + text;
					break;
				case 111:
					text = "+266" + text;
					break;
				case 112:
					text = "+231" + text;
					break;
				case 113:
					text = "+218" + text;
					break;
				case 114:
					text = "+423" + text;
					break;
				case 115:
					text = "+370" + text;
					break;
				case 116:
					text = "+352" + text;
					break;
				case 117:
					text = "+853" + text;
					break;
				case 118:
					text = "+389" + text;
					break;
				case 119:
					text = "+261" + text;
					break;
				case 120:
					text = "+265" + text;
					break;
				case 121:
					text = "+60" + text;
					break;
				case 122:
					text = "+960" + text;
					break;
				case 123:
					text = "+223" + text;
					break;
				case 124:
					text = "+356" + text;
					break;
				case 125:
					text = "+692" + text;
					break;
				case 126:
					text = "+596" + text;
					break;
				case 127:
					text = "+222" + text;
					break;
				case 128:
					text = "+230" + text;
					break;
				case 129:
					text = "+52" + text;
					break;
				case 130:
					text = "+808" + text;
					break;
				case 131:
					text = "+373" + text;
					break;
				case 132:
					text = "+377" + text;
					break;
				case 133:
					text = "+976" + text;
					break;
				case 134:
					text = "+381" + text;
					break;
				case 135:
					text = "+1664" + text;
					break;
				case 136:
					text = "+212" + text;
					break;
				case 137:
					text = "+258" + text;
					break;
				case 138:
					text = "+95" + text;
					break;
				case 139:
					text = "+264" + text;
					break;
				case 140:
					text = "+977" + text;
					break;
				case 141:
					text = "+31" + text;
					break;
				case 142:
					text = "+599" + text;
					break;
				case 143:
					text = "+687" + text;
					break;
				case 144:
					text = "+64" + text;
					break;
				case 145:
					text = "+505" + text;
					break;
				case 146:
					text = "+227" + text;
					break;
				case 147:
					text = "+234" + text;
					break;
				case 148:
					text = "+1670" + text;
					break;
				case 149:
					text = "+47" + text;
					break;
				case 150:
					text = "+968" + text;
					break;
				case 151:
					text = "+92" + text;
					break;
				case 152:
					text = "+680" + text;
					break;
				case 153:
					text = "+507" + text;
					break;
				case 154:
					text = "+675" + text;
					break;
				case 155:
					text = "+595" + text;
					break;
				case 156:
					text = "+51" + text;
					break;
				case 157:
					text = "+63" + text;
					break;
				case 158:
					text = "+48" + text;
					break;
				case 159:
					text = "+351" + text;
					break;
				case 160:
					text = "+974" + text;
					break;
				case 161:
					text = "+262" + text;
					break;
				case 162:
					text = "+40" + text;
					break;
				case 163:
					text = "+7" + text;
					break;
				case 164:
					text = "+250" + text;
					break;
				case 165:
					text = "+378" + text;
					break;
				case 166:
					text = "+239" + text;
					break;
				case 167:
					text = "+966" + text;
					break;
				case 168:
					text = "+221" + text;
					break;
				case 169:
					text = "+248" + text;
					break;
				case 170:
					text = "+232" + text;
					break;
				case 171:
					text = "+65" + text;
					break;
				case 172:
					text = "+421" + text;
					break;
				case 173:
					text = "+386" + text;
					break;
				case 174:
					text = "+677" + text;
					break;
				case 175:
					text = "+252" + text;
					break;
				case 176:
					text = "+27" + text;
					break;
				case 177:
					text = "+34" + text;
					break;
				case 178:
					text = "+94" + text;
					break;
				case 179:
					text = "+1869" + text;
					break;
				case 180:
					text = "+1758" + text;
					break;
				case 181:
					text = "+1784" + text;
					break;
				case 182:
					text = "+249" + text;
					break;
				case 183:
					text = "+597" + text;
					break;
				case 184:
					text = "+268" + text;
					break;
				case 185:
					text = "+46" + text;
					break;
				case 186:
					text = "+41" + text;
					break;
				case 187:
					text = "+963" + text;
					break;
				case 188:
					text = "+886" + text;
					break;
				case 189:
					text = "+992" + text;
					break;
				case 190:
					text = "+255" + text;
					break;
				case 191:
					text = "+66" + text;
					break;
				case 192:
					text = "+228" + text;
					break;
				case 193:
					text = "+676" + text;
					break;
				case 194:
					text = "+1868" + text;
					break;
				case 195:
					text = "+216" + text;
					break;
				case 196:
					text = "+90" + text;
					break;
				case 197:
					text = "+993" + text;
					break;
				case 198:
					text = "+1649" + text;
					break;
				case 199:
					text = "+688" + text;
					break;
				case 200:
					text = "+256" + text;
					break;
				case 201:
					text = "+380" + text;
					break;
				case 202:
					text = "+971" + text;
					break;
				case 203:
					text = "+44" + text;
					break;
				case 204:
					text = "+1" + text;
					break;
				case 205:
					text = "+598" + text;
					break;
				case 206:
					text = "+998" + text;
					break;
				case 207:
					text = "+678" + text;
					break;
				case 208:
					text = "+58" + text;
					break;
				case 209:
					text = "+84" + text;
					break;
				case 210:
					text = "+1284" + text;
					break;
				case 211:
					text = "+1340" + text;
					break;
				case 212:
					text = "+685" + text;
					break;
				case 213:
					text = "+967" + text;
					break;
				case 214:
					text = "+381" + text;
					break;
				case 215:
					text = "+243" + text;
					break;
				case 216:
					text = "+381" + text;
					break;
				}
				if (text.Trim().Length > 13)
				{
					text = text.Remove(text.Trim().Length - 1, 1);
				}
			}
			while (text.Trim().Length < 10);
			return text;
		}

		private string method_73()
		{
			string text = "";
			List<string> list = new List<string>(new string[10] { "thejoker5.com", "greencafe24.com", "crepeau12.com", "coffeetimer24.com", "popcornfarm7.com", "cashflow35.com", "bestparadize.com", "the23app.com", "blondemorkin.com", "kobrandly.com" });
			return list[random_0.Next(0, list.Count)].ToString();
		}

		private string method_74()
		{
			string text = "205|251|659|256|334|907|520|928|480|602|623|501|479|870|341|442|628|657|669|747|752|764|951|209|559|408|831|510|213|310|424|323|562|707|369|627|530|714|949|626|909|916|760|619|858|935|818|415|925|661|805|650|211|720|970|303|719|203|475|860|959|302|411|202|911|239|386|689|754|941|954|561|407|727|352|904|850|786|863|305|321|813|470|478|770|678|404|706|912|229|710|671|808|208|312|773|630|847|708|815|224|331|464|872|217|618|309|260|317|219|765|812|563|641|515|319|712|876|620|785|913|316|270|859|606|502|225|337|985|504|318|207|227|240|443|667|410|301|339|351|774|781|857|978|508|617|413|231|269|989|734|517|313|810|248|278|586|679|947|906|616|320|612|763|952|218|507|651|228|601|557|573|636|660|975|314|816|417|664|406|402|308|775|702|506|603|551|848|862|732|908|201|973|609|856|505|575|585|845|917|516|212|646|315|518|347|718|607|914|631|716|252|336|828|910|980|984|919|704|701|283|380|567|216|614|937|330|234|440|419|740|513|580|918|405|541|971|445|610|835|878|484|717|570|412|215|267|814|724|787|939|401|306|803|843|864|605|731|865|931|423|615|901|325|361|430|432|469|682|737|979|214|972|254|940|713|281|832|956|817|806|903|210|830|409|936|512|915|340|385|435|801|802|276|434|540|571|757|703|804|509|206|425|253|360|564|304|262|920|414|715|608|307|867|866|456|011|880|881|882|500|611|311|200|300|400|700|711|811|800|877|888";
			string[] array = text.Split('|');
			return array[random_0.Next(0, array.Length - 1)];
		}

		private string method_75(string string_21)
		{
			string_21 = string_21.ToLower().Replace(" ", "");
			string_21 = Common.smethod_74(string_21);
			return string_21;
		}

		private string method_76(string string_21, string string_22, int int_41)
		{
			string string_23 = string_21 + string_22;
			string_23 = method_75(string_23);
			string_23 += random_0.Next(0, 1000);
			string_23 = string_23.ToLower();
			switch (int_41)
			{
			case 0:
				string_23 += "@gmail.com";
				break;
			case 1:
				string_23 += "@yahoo.com";
				break;
			case 2:
				string_23 += "@hotmail.com";
				break;
			}
			return string_23;
		}

		private void ckCheckIP_CheckedChanged(object sender, EventArgs e)
		{
			txtPassFb.Enabled = !chkRandomPass.Checked;
		}

		private void method_77(object sender, DataGridViewCellEventArgs e)
		{
			if (e.ColumnIndex == 0)
			{
				try
				{
					dgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dgvAcc.CurrentRow.Cells["cChose"].Value);
					method_67();
				}
				catch
				{
				}
			}
		}

		private void method_78(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void method_79(object sender, DataGridViewCellEventArgs e)
		{
		}

		private void method_80(object sender, DataGridViewCellEventArgs e)
		{
			try
			{
				dgvAcc.CurrentRow.Cells["cChose"].Value = !Convert.ToBoolean(dgvAcc.CurrentRow.Cells["cChose"].Value);
				method_67();
			}
			catch
			{
			}
		}

		private void uidPass2FAToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("uid|pass|2fa");
		}

		private void btnCheckAPIAny_Click(object sender, EventArgs e)
		{
			string text = txtAPIAnyCat.Text.ToString();
			string text2 = Common.smethod_30(text);
			if (text2 == "")
			{
				MessageBox.Show("API key này không tồn tại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Số tiền còn dư: " + text2 + " $", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void btnNhapanh_Click(object sender, EventArgs e)
		{
			try
			{
				FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
				folderBrowserDialog.ShowNewFolderButton = true;
				DialogResult dialogResult = folderBrowserDialog.ShowDialog();
				if (dialogResult == DialogResult.OK)
				{
					txtLinkAvartar.Text = folderBrowserDialog.SelectedPath;
					_ = folderBrowserDialog.RootFolder;
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Lỗi: " + ex.Message, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		public string method_81()
		{
			string result = "";
			try
			{
				string path = txtLinkLD.Text + "\\vms\\config\\leidian0.config";
				string text = txtLinkLD.Text + "\\vms\\config\\leidian1.config";
				if (File.Exists(text))
				{
					path = text;
				}
				JObject jObject = JObject.Parse(File.ReadAllText(path));
				result = jObject["statusSettings.sharedPictures"]!.ToString();
			}
			catch
			{
			}
			return result;
		}

		private void liveToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_82(sender, e);
		}

		private void method_82(object sender, EventArgs e)
		{
			method_83("cInfo", (sender as ToolStripMenuItem).Text);
		}

		private void method_83(string string_21, string string_22)
		{
			for (int i = 0; i < dgvAcc.RowCount; i++)
			{
				dgvAcc.Rows[i].Cells["cChose"].Value = method_1(i, string_21).Contains(string_22);
			}
			method_67();
		}

		private void dieToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_82(sender, e);
		}

		private void checkpointToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_82(sender, e);
		}

		private string method_84(Random random_1, int int_41)
		{
			string text = "";
			string text2 = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
			for (int i = 0; i < int_41; i++)
			{
				text += text2[random_1.Next(0, text2.Length)];
			}
			return text;
		}

		private bool method_85(int int_41)
		{
			bool result = false;
			Class7 @class = new Class7();
			@class.Position = Common.smethod_2(int_41);
			@class.Size = new Point(int_22, int_23);
			string userAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/93.0.4577.82 Safari/537.36";
			try
			{
				@class.HideBrowser = chkHideBrowser.Checked;
				@class.UserAgent = userAgent;
				@class.method_0();
			}
			catch (Exception)
			{
			}
			method_52("Đang đăng ky\u0301 ta\u0300i khoa\u0309n hotmail...", "status", int_41, 1, dgvAcc);
			@class.method_3("https://signup.live.com/signup");
			@class.method_31(5.0);
			string string_ = method_6();
			string string_2 = method_7();
			string text = method_76(string_2, string_, 2);
			string string_3 = (bool_11 ? method_84(random_0, 15) : string_17);
			method_52(text, "email", int_41, 0, dgvAcc);
			method_52(string_3, "passMail", int_41, 0, dgvAcc);
			if (@class.method_16("[name=\"MemberName\"]", 60.0))
			{
				@class.method_12(4, "[name=\"MemberName\"]", text, 0.0);
			}
			@class.method_31(3.0);
			if (text.EndsWith("@hotmail.com"))
			{
				@class.method_32(1, "LiveDomainBoxList", "hotmail.com");
			}
			if (!@class.method_20(2, "MemberName"))
			{
				@class.method_6("document.querySelector('#iSignupAction').click()");
			}
			if (!@class.method_16("#PasswordInput", 10.0))
			{
				if (@class.method_16("#MemberName"))
				{
					method_52("Mail không thê\u0309 đăng ky\u0301!", "status", int_41, 1, dgvAcc);
				}
				else
				{
					method_52("Không load đươ\u0323c trang!", "status", int_41, 1, dgvAcc);
				}
			}
			else
			{
				@class.method_12(1, "PasswordInput", string_3, 0.0);
				@class.method_31(1.0);
				if (!@class.method_20(1, "PasswordInput"))
				{
					@class.method_6("document.querySelector('#iSignupAction').click()");
				}
				@class.method_31(1.0);
				if (@class.method_16("#LastName", 60.0))
				{
					@class.method_12(1, "LastName", method_12(), 0.1);
					method_51(0.5);
					@class.method_12(1, "FirstName", method_14(), 0.1);
					method_51(0.5);
				}
				if (!@class.method_20(1, "LastName"))
				{
					@class.method_6("document.querySelector('#iSignupAction').click()");
				}
				@class.method_31(1.0);
				if (@class.method_16("[name=\"BirthDay\"]", 60.0))
				{
					@class.method_32(2, "BirthDay", random_0.Next(1, 28).ToString());
				}
				if (@class.method_16("[name=\"BirthMonth\"]", 60.0))
				{
					@class.method_32(2, "BirthMonth", random_0.Next(1, 12).ToString());
				}
				if (@class.method_16("[name=\"BirthYear\"]", 60.0) && !@class.method_32(2, "BirthYear", random_0.Next(1970, 2000).ToString()))
				{
					@class.method_11(2, "BirthYear", random_0.Next(1970, 2000).ToString());
				}
				@class.method_31(1.0);
				@class.method_6("document.querySelector('#iSignupAction').click()");
				method_51(3.0);
				while (true)
				{
					IL_05e9:
					int num = @class.method_19(90.0, "#hipTemplateContainer>div:nth-child(3)>input", "#wlspispHipChallengeContainer>div:nth-child(2)>input", "#HipEnforcementForm");
					if (num != 1)
					{
						if (num == 2)
						{
							if (!method_86(@class, int_41, string_11))
							{
								break;
							}
							while (true)
							{
								num = @class.method_19(90.0, "#KmsiCheckboxField", "#hipTemplateContainer>div:nth-child(3)>input", "#uhfSkipToMain", "#o365header", "#HipEnforcementForm", "#idPageTitle");
								if (num != 1)
								{
									if (num == 3 || num == 4)
									{
										break;
									}
									if (num == 5)
									{
										while (true)
										{
											method_52("Đang giải funcaptcha...", "status", int_41, 1, dgvAcc);
											string text2 = Common.smethod_32(txtAPIAnyCat.Text.Trim(), "https://signup.live.com", "B7D8911C-5CC8-A9A3-35B0-554ACEE604DA");
											@class.chromeDriver_0.SwitchTo().Frame(0);
											@class.method_6("parent.postMessage(JSON.stringify({eventId: \"challenge-complete\",payload: {sessionToken: \"" + text2 + "\"}}), \"*\")");
											@class.method_31(1.0);
											switch (@class.method_19(30.0, "#KmsiCheckboxField", "#o365header", "#wlspispHipChallengeContainer>div:nth-child(2)>input", "#HipEnforcementForm"))
											{
											case 4:
												break;
											case 1:
												goto end_IL_0421;
											case 3:
												goto IL_0526;
											default:
												goto IL_05e9;
											case 2:
												goto end_IL_0593;
											}
											continue;
											end_IL_0421:
											break;
										}
										@class.method_7(1, "KmsiCheckboxField");
										@class.method_31(1.0);
										@class.method_7(1, "idSIButton9");
										@class.method_31(1.0);
										continue;
									}
									if (num != 6)
									{
										break;
									}
									method_52("Không load đươ\u0323c trang!", "status", int_41, 1, dgvAcc);
									goto end_IL_05e9;
								}
								try
								{
									try
									{
										@class.method_7(1, "KmsiCheckboxField");
									}
									catch
									{
										@class.method_6("document.querySelector('#KmsiCheckboxField').click()");
									}
									@class.method_31(1.0);
									try
									{
										@class.method_7(1, "idSIButton9");
									}
									catch
									{
										@class.method_6("document.querySelector('#idSIButton9').click()");
									}
								}
								catch
								{
									break;
								}
								continue;
								IL_0526:
								if (!method_86(@class, int_41, string_11))
								{
									goto end_IL_05e9;
								}
								continue;
								end_IL_0593:
								break;
							}
						}
						else if (num == 3)
						{
							int num2;
							do
							{
								method_52("Đang giải funcaptcha...", "status", int_41, 1, dgvAcc);
								string text3 = Common.smethod_32(txtAPIAnyCat.Text.Trim(), "https://signup.live.com", "B7D8911C-5CC8-A9A3-35B0-554ACEE604DA");
								@class.chromeDriver_0.SwitchTo().Frame(0);
								@class.method_6("parent.postMessage(JSON.stringify({eventId: \"challenge-complete\",payload: {sessionToken: \"" + text3 + "\"}}), \"*\")");
								@class.method_31(1.0);
								num2 = @class.method_19(30.0, "#KmsiCheckboxField", "#o365header", "#wlspispHipChallengeContainer>div:nth-child(2)>input", "#HipEnforcementForm");
							}
							while (num2 == 4);
							if (num2 == 1)
							{
								@class.method_7(1, "KmsiCheckboxField");
								@class.method_31(1.0);
								@class.method_7(1, "idSIButton9");
								@class.method_31(1.0);
							}
							else if (num2 == 3 && !method_86(@class, int_41, string_11))
							{
								break;
							}
						}
					}
					if (bool_10)
					{
						@class.method_31(1.0);
						method_52("Đang ta\u0323o mailbox...", "status", int_41, 1, dgvAcc);
						@class.method_31(1.0);
						@class.method_3("https://outlook.live.com/mail/0");
						@class.method_31(5.0);
						int num3 = @class.method_19(90.0, "#owaBranding_container", ".ms-Modal-scrollableContent");
						if (num3 == 1 || num3 == 2)
						{
							method_52("Tạo mailbox thành công!", "status", int_41, 1, dgvAcc);
						}
					}
					method_52("Đăng ký Mail thành công!", "status", int_41, 1, dgvAcc);
					result = true;
					break;
					continue;
					end_IL_05e9:
					break;
				}
			}
			@class.method_23();
			return result;
		}

		private bool method_86(Class7 class7_0, int int_41, string string_21)
		{
			bool result = false;
			string text = "";
			string text2 = "";
			string text3 = "";
			int num = 5;
			try
			{
				method_52("Đang xác minh sđt...", "status", int_41, 1, dgvAcc);
				class7_0.method_6("document.querySelector(\"#wlspispHipChallengeContainer > div:nth-child(1) > select\").value=\"VN\"");
				method_52("Đang lâ\u0301y sđt...", "status", int_41, 0, dgvAcc);
				if (string_21 == "")
				{
					method_52("Không có api, không thể lấy sđt!", "status", int_41, 0, dgvAcc);
				}
				else
				{
					while (true)
					{
						string text4 = string.Empty;
						if (!(string_12.Substring(2, 1) == "0"))
						{
							if (string_12.Substring(2, 1) == "1")
							{
								text4 = Common.smethod_58(string_11);
							}
							else if (string_12.Substring(2, 1) == "2")
							{
								text4 = Common.smethod_59(string_11);
							}
							else if (string_12.Substring(2, 1) == "4")
							{
								text4 = Common.smethod_60(string_11);
							}
						}
						else
						{
							text4 = Common.smethod_42(string_11, "hotmail");
						}
						text = text4.Split('|')[0];
						text2 = text4.Split('|')[1];
						if (text2 == "")
						{
							method_52("Không lâ\u0301y đươ\u0323c sđt! Đang lấy lại...", "status", int_41, 0, dgvAcc);
							continue;
						}
						if (string_12.Substring(2, 1) == "0" || string_12.Substring(2, 1) == "1")
						{
							text2 = "+84" + text2;
						}
						else if (string_12.Substring(2, 1) == "2" || string_12.Substring(2, 1) == "4")
						{
							text2 = "+1" + text2;
						}
						if (class7_0.method_16("#wlspispHipChallengeContainer>div:nth-child(2)>input", 10.0))
						{
							class7_0.method_14(4, "#wlspispHipChallengeContainer>div:nth-child(2)>input");
							class7_0.method_11(4, "#wlspispHipChallengeContainer>div:nth-child(2)>input", text2);
						}
						class7_0.method_31(3.0);
						class7_0.method_6("document.querySelector('#wlspispHipControlButtonsContainer>a').click()");
						class7_0.method_31(3.0);
						if (!Convert.ToBoolean(class7_0.method_6("return document.querySelector('#iSignupAction').disabled+''").ToString()))
						{
							break;
						}
						if (num >= 0)
						{
							method_52("Sđt không dùng được! Đang lấy số khác...", "status", int_41, 0, dgvAcc);
							num--;
							continue;
						}
						return result;
					}
					method_52("Đơ\u0323i lâ\u0301y ma\u0303 code...", "status", int_41, 0, dgvAcc);
					if (string_12.Substring(2, 1) == "0")
					{
						text3 = Common.smethod_43(string_11, text, int_14);
					}
					else if (string_12.Substring(2, 1) == "1")
					{
						text3 = Common.smethod_61(string_11, text, int_14);
					}
					else if (string_12.Substring(2, 1) == "2")
					{
						text3 = Common.smethod_26(string_11, text, int_14);
					}
					else if (string_12.Substring(2, 1) == "4")
					{
						text3 = Common.smethod_27(string_11, text, int_14);
					}
					if (text3 == "")
					{
						method_52("Không lâ\u0301y đươ\u0323c ma\u0303 code!", "status", int_41, 0, dgvAcc);
					}
					else
					{
						if (class7_0.method_16("#wlspispHipSolutionContainer>div>input", 10.0))
						{
							class7_0.method_11(4, "#wlspispHipSolutionContainer>div>input", text3);
						}
						class7_0.method_31(3.0);
						class7_0.method_6("document.querySelector('#iSignupAction').click()");
						class7_0.method_31(3.0);
						result = true;
					}
				}
			}
			catch (Exception)
			{
			}
			return result;
		}

		private void method_87(object sender, EventArgs e)
		{
		}

		private bool method_88(Device device_0, string string_21)
		{
			bool result = false;
			try
			{
				device_0.method_86("com.cell47.College_Proxy");
				int i = 0;
				int num = 0;
				num = string_21.Split(':').Length;
				for (; i < 5; i++)
				{
					if (device_0.method_87() == "com.cell47.College_Proxy/com.cell47.College_Proxy.ui.MainActivity")
					{
						break;
					}
					device_0.method_121(1.0);
				}
				if (device_0.method_75(30.0, "please wait"))
				{
					string text = device_0.method_93();
					if (device_0.method_82("stop proxy service", text))
					{
						device_0.method_99("stop proxy service", text);
						device_0.method_121(1.0);
						text = device_0.method_93();
					}
					string text2 = device_0.method_2();
					List<string> list = new List<string> { "125,90", "125,125", "125,160", "125,195" };
					for (int j = 0; j < num; j++)
					{
						device_0.method_7(Convert.ToInt32(list[j].Split(',')[0]), Convert.ToInt32(list[j].Split(',')[1]));
						device_0.method_121(1.0);
						device_0.method_102(string_21.Split(':')[j].ToString());
						device_0.method_121(1.0);
					}
					device_0.method_99("start proxy service", text);
					string text3 = "127.0.0.1:" + (device_0.int_0 * 2 + 5555);
					for (int k = 0; k < 5; k++)
					{
						text = device_0.method_93();
						int num2 = device_0.method_84(text, 0.0, "connection request", "stop proxy service", "yêu cầu kết nối");
						if (num2 == 0)
						{
							Class2.smethod_35(text3);
							method_89();
							continue;
						}
						if (num2 == 1 || num2 == 3)
						{
							device_0.method_99("ok", text);
							device_0.method_121(1.0);
						}
						Class2.smethod_35(text3);
						method_89();
						string text4 = "";
						for (int l = 0; l < 2; l++)
						{
							text4 = device_0.method_2();
							if (text4 != "" && !text4.Contains("error"))
							{
								break;
							}
							Thread.Sleep(1000);
						}
						return text2 != text4 && !text4.Contains("error") && text4 != "";
					}
				}
			}
			catch (Exception exception_)
			{
				Common.smethod_82(exception_, "Error_ConnectProxy");
			}
			return result;
		}

		public void method_89()
		{
			for (int i = 0; i < list_4.Count; i++)
			{
				string text = Class2.smethod_36(list_4[i].int_0);
				if (!string.IsNullOrEmpty(text))
				{
					list_4[i].DeviceId = text;
				}
			}
		}

		private void mailPassMailToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("mail|passmail");
		}

		private void timer_0_Tick(object sender, EventArgs e)
		{
		}

		private void method_90(object sender, EventArgs e)
		{
		}

		private void method_91(object sender, EventArgs e)
		{
			plAddfriend.Enabled = chkAddFUID.Checked;
		}

		private void chkWStory_CheckedChanged(object sender, EventArgs e)
		{
			gbCamxuc.Enabled = chkWStory.Checked;
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void btnMinimized_Click(object sender, EventArgs e)
		{
			base.WindowState = FormWindowState.Minimized;
		}

		private void method_92(object sender, EventArgs e)
		{
		}

		private void rdNoChangeIP_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void timer_1_Tick(object sender, EventArgs e)
		{
		}

		private void frmMain_Paint(object sender, PaintEventArgs e)
		{
		}

		private void btnCheckAPIMinProxy_Click(object sender, EventArgs e)
		{
			try
			{
				List<string> list = new List<string>();
				List<string> list2 = txtApiKeyMinProxy.Lines.ToList();
				list2 = Common.smethod_77(list2);
				foreach (string item in list2)
				{
					if (Class51.smethod_0(item))
					{
						list.Add(item);
					}
				}
				txtApiKeyMinProxy.Lines = list.ToArray();
				if (list.Count > 0)
				{
					MessageBox.Show($"Đang có {list.Count} proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Không có proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Không có proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void rbMale_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void rdHMA_CheckedChanged(object sender, EventArgs e)
		{
			method_93();
		}

		private void method_93()
		{
			plCheckDoiIP.Enabled = rdChangeIPDcom.Checked || rdHMA.Checked;
			RadioButton radioButton = rdProxy;
			RadioButton radioButton2 = rdIPPortUserPass;
			RadioButton radioButton3 = rdTinsoftProxy;
			bool flag2 = (rdMinProxy.Checked = !rdChangeIPDcom.Checked && !rdHMA.Checked);
			bool flag4 = (radioButton3.Checked = flag2);
			bool @checked = (radioButton2.Checked = flag4);
			radioButton.Checked = @checked;
		}

		private void rdChangeIPDcom_CheckedChanged(object sender, EventArgs e)
		{
			plChangeIPDcom.Enabled = rdChangeIPDcom.Checked;
			method_93();
		}

		private void method_94(object sender, EventArgs e)
		{
		}

		private void method_95(object sender, EventArgs e)
		{
			method_21(bool_18: false);
			for (int i = 0; i < 2; i++)
			{
				frmViewLD.frmViewLD_0.method_0(i + 1);
			}
		}

		private void btnTestChangeIP_Click(object sender, EventArgs e)
		{
			Class48 @class = new Class48("setting.ini");
			int num = Convert.ToInt32(@class.method_1("typeChangeIp"));
			if (num == 1 || num == 4)
			{
				if (Common.smethod_56(num, 0, @class.method_1("txtProfileNameDcom").ToString(), ""))
				{
					stIPCur.Text = method_54();
					MessageBox.Show("Đổi IP thành công. IP mới: " + stIPCur.Text, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
				else
				{
					MessageBox.Show("Đổi IP thất bại", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				}
			}
		}

		private void method_96(object sender, EventArgs e)
		{
		}

		private void btnNhapHotmail_Click(object sender, EventArgs e)
		{
			Process.Start("hotmail.txt");
		}

		private void allToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("proxy");
		}

		private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://tinsoftproxy.com/");
		}

		private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://minproxy.vn/");
		}

		private void method_97(object sender, EventArgs e)
		{
		}

		private void btnAutoConfig_Click(object sender, EventArgs e)
		{
			frmAutoFunction frmAutoFunction = new frmAutoFunction();
			frmAutoFunction.ShowDialog();
		}

		private void method_98(object sender, EventArgs e)
		{
		}

		private void btnMaximum_Click(object sender, EventArgs e)
		{
			method_99();
		}

		private void method_99()
		{
			base.MaximizedBounds = Screen.FromHandle(base.Handle).WorkingArea;
			if (base.WindowState == FormWindowState.Minimized)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else if (base.WindowState == FormWindowState.Normal)
			{
				base.WindowState = FormWindowState.Maximized;
			}
			else if (base.WindowState == FormWindowState.Maximized)
			{
				base.WindowState = FormWindowState.Normal;
			}
		}

		private void rdNormal_CheckedChanged(object sender, EventArgs e)
		{
			rdSwap.Checked = !rdNormal.Checked;
		}

		private void rdSwap_CheckedChanged(object sender, EventArgs e)
		{
			rdNormal.Checked = !rdSwap.Checked;
		}

		private void rdProxy_CheckedChanged(object sender, EventArgs e)
		{
			tabProxy.Enabled = rdProxy.Checked;
		}

		private void rdTinsoftProxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rdTinsoftProxy.Checked)
			{
				RadioButton radioButton = rdMinProxy;
				RadioButton radioButton2 = rdIPPortUserPass;
				RadioButton radioButton3 = rbXproxy;
				RadioButton radioButton4 = rbTMProxy;
				RadioButton radioButton5 = rdProxyOrbit;
				rbProxyShoplike.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			plTinsoftProxy.Enabled = rdTinsoftProxy.Checked;
		}

		private void rdMinProxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rdMinProxy.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdIPPortUserPass;
				RadioButton radioButton3 = rbXproxy;
				RadioButton radioButton4 = rbTMProxy;
				rbProxyShoplike.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			pnlAPIMinProxy.Enabled = rdMinProxy.Checked;
		}

		private void txtApiKeyMinProxy_TextChanged(object sender, EventArgs e)
		{
			List<string> list = txtApiKeyMinProxy.Lines.ToList();
			list = Common.smethod_77(list);
			lblAPIMinKey.Text = $"Nhập API KEY ({list.Count.ToString()}):";
		}

		private void rdIPPortUserPass_CheckedChanged(object sender, EventArgs e)
		{
			if (rdIPPortUserPass.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdMinProxy;
				RadioButton radioButton3 = rbXproxy;
				RadioButton radioButton4 = rbTMProxy;
				RadioButton radioButton5 = rbProxyShoplike;
				rdProxyOrbit.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			pnlIpPort.Enabled = rdIPPortUserPass.Checked;
		}

		private void txtListProxyIp_TextChanged(object sender, EventArgs e)
		{
			List<string> list = txtListProxyIp.Lines.ToList();
			list = Common.smethod_77(list);
			lblListProxyIP.Text = $"Danh sa\u0301ch Proxy ({list.Count.ToString()}):";
		}

		private void rdIPStatic_CheckedChanged(object sender, EventArgs e)
		{
			rdIPDong.Checked = !rdIPStatic.Checked;
		}

		private void rdIPDong_CheckedChanged(object sender, EventArgs e)
		{
			rdIPStatic.Checked = !rdIPDong.Checked;
		}

		private void rbXproxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rbXproxy.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdMinProxy;
				RadioButton radioButton3 = rdIPPortUserPass;
				RadioButton radioButton4 = rbTMProxy;
				RadioButton radioButton5 = rbProxyShoplike;
				rdProxyOrbit.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			plXproxy.Enabled = rbXproxy.Checked;
		}

		private void txtListXProxy_TextChanged(object sender, EventArgs e)
		{
			List<string> list = txtListXProxy.Lines.ToList();
			list = Common.smethod_77(list);
			lblCountXproxy.Text = $"Nhập proxy ({list.Count.ToString()}):";
		}

		private void rbTMProxy_CheckedChanged(object sender, EventArgs e)
		{
			if (rbTMProxy.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdMinProxy;
				RadioButton radioButton3 = rdIPPortUserPass;
				RadioButton radioButton4 = rbXproxy;
				RadioButton radioButton5 = rbProxyShoplike;
				rdProxyOrbit.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			plTMProxy.Enabled = rbTMProxy.Checked;
		}

		private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://tmproxy.com/");
		}

		private void method_100(object sender, EventArgs e)
		{
		}

		private void txtApiKeyTMProxy_TextChanged(object sender, EventArgs e)
		{
			try
			{
				List<string> list = txtApiKeyTMProxy.Lines.ToList();
				list = Common.smethod_77(list);
				lblCountTmProxy.Text = $"Nhập API KEY ({list.Count.ToString()}):";
			}
			catch
			{
			}
		}

		private void lnkTempMailIO_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://temp-mail.io/");
		}

		private void rdHotMailReg_CheckedChanged(object sender, EventArgs e)
		{
			if (rdHotMailReg.Checked)
			{
				plHotmailReg.Enabled = rdHotMailReg.Checked;
				rdTempMailIO.Checked = false;
				rdMailTM.Checked = false;
			}
		}

		private void rdHotMailRegisted_CheckedChanged(object sender, EventArgs e)
		{
			if (rdHotMailRegisted.Checked)
			{
				rdTempMailIO.Checked = false;
				rdMailTM.Checked = false;
				btnNhapHotmail.Enabled = true;
			}
		}

		private void rdTempMailIO_CheckedChanged(object sender, EventArgs e)
		{
			if (rdTempMailIO.Checked)
			{
				rdHotMailReg.Checked = false;
				rdHotMailRegisted.Checked = false;
				rdMailTM.Checked = false;
			}
		}

		private void cbbPhoneCountry_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbbPhoneCountry.SelectedIndex == 0)
			{
				method_56(0);
			}
			else if (cbbPhoneCountry.SelectedIndex == 1)
			{
				method_56(1);
			}
		}

		private void cbbPrePhone_SelectedIndexChanged(object sender, EventArgs e)
		{
			string[] array = cbbPrePhone.SelectedItem.ToString().Split('[', ']', ',');
			txtListDauso.Text += array[2];
			txtListDauso.Text += ",";
		}

		private void cbModeRunReg_SelectedIndexChanged(object sender, EventArgs e)
		{
			pnlSoLanReg.Enabled = ((cbModeRunReg.SelectedIndex == 0) ? true : false);
		}

		private void btnOutpuData_Click(object sender, EventArgs e)
		{
			try
			{
				string text = "output\\facebook\\";
				if (Directory.Exists(text))
				{
					Process.Start("explorer.exe", text);
				}
			}
			catch
			{
				MessageBox.Show("Không tìm thấy folder data", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void phoneToolStripMenuItem_Click(object sender, EventArgs e)
		{
			method_69("phone");
		}

		private void lnkShopLike_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://proxy.shoplike.vn/");
		}

		private void rbProxyShoplike_CheckedChanged(object sender, EventArgs e)
		{
			if (rbProxyShoplike.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdMinProxy;
				RadioButton radioButton3 = rdIPPortUserPass;
				RadioButton radioButton4 = rbXproxy;
				RadioButton radioButton5 = rbTMProxy;
				rdProxyOrbit.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			plProxyShopLike.Enabled = rbProxyShoplike.Checked;
		}

		private void txtAPIKeyShoplike_TextChanged(object sender, EventArgs e)
		{
			List<string> list = txtAPIKeyShoplike.Lines.ToList();
			list = Common.smethod_77(list);
			lblAPIKeyShopLike.Text = $"Nhập API KEY ({list.Count.ToString()}):";
		}

		private void method_101(object sender, EventArgs e)
		{
		}

		private void btnCheckTMProxy_Click(object sender, EventArgs e)
		{
			List<string> list = new List<string>();
			List<string> list2 = txtApiKeyTMProxy.Lines.ToList();
			list2 = Common.smethod_77(list2);
			foreach (string item in list2)
			{
				if (Class68.smethod_0(item))
				{
					list.Add(item);
				}
			}
			txtApiKeyTMProxy.Lines = list.ToArray();
			if (list.Count > 0)
			{
				MessageBox.Show($"Đang có {list.Count} proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
			else
			{
				MessageBox.Show("Không có proxy khả dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
			}
		}

		private void method_102(object sender, LinkLabelLinkClickedEventArgs e)
		{
			Process.Start("https://mail.tm/vi/");
		}

		private void method_103(object sender, EventArgs e)
		{
		}

		private void rdMailTM_CheckedChanged(object sender, EventArgs e)
		{
			if (rdMailTM.Checked)
			{
				rdHotMailReg.Checked = false;
				rdHotMailRegisted.Checked = false;
				rdTempMailIO.Checked = false;
			}
		}

		private void btnManagerLD_Click(object sender, EventArgs e)
		{
			if (txtLinkLD.Text == "" || !Directory.Exists(txtLinkLD.Text))
			{
				MessageBox.Show("Đường dẫn LDPlayer không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			Task task = new Task(delegate
			{
				Process.Start(txtLinkLD.Text + "\\dnmultiplayer.exe");
			});
			task.Start();
		}

		private void btnRepairLD_Click(object sender, EventArgs e)
		{
			if (txtLinkLD.Text == "" || !Directory.Exists(txtLinkLD.Text))
			{
				MessageBox.Show("Đường dẫn LDPlayer không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			Task task = new Task(delegate
			{
				Process.Start(txtLinkLD.Text + "\\dnrepairer.exe");
				method_51(10.0);
				MessageBox.Show("Sửa chữa LDPlayer thành công", "Thông báo");
			});
			task.Start();
		}

		private void btnCreateLDPLayer_Click(object sender, EventArgs e)
		{
			if (txtLinkLD.Text == "" || !Directory.Exists(txtLinkLD.Text))
			{
				MessageBox.Show("Đường dẫn LDPlayer không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			string value = "";
			if (Common.smethod_11("Thông báo", "Nhập số lượng LDPlayer muốn tạo", ref value) != DialogResult.OK)
			{
				return;
			}
			int int_0 = Convert.ToInt32(value);
			new Task(delegate
			{
				int i;
				for (i = 0; i < int_0; i++)
				{
					Class2.smethod_24("add", 0, bool_0: true, txtLinkLD.Text);
				}
				MessageBox.Show("Tạo thành công " + i + " LDPlayer");
			}).Start();
		}

		private void btnTurnOffAllLD_Click(object sender, EventArgs e)
		{
			if (txtLinkLD.Text == "" || !Directory.Exists(txtLinkLD.Text))
			{
				MessageBox.Show("Đường dẫn LDPlayer không hợp lệ", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				return;
			}
			Class2.smethod_24("quitall", 0, bool_0: true, txtLinkLD.Text);
			list_3.Clear();
		}

		private void rdProxyOrbit_CheckedChanged(object sender, EventArgs e)
		{
			if (rdProxyOrbit.Checked)
			{
				RadioButton radioButton = rdTinsoftProxy;
				RadioButton radioButton2 = rdMinProxy;
				RadioButton radioButton3 = rdIPPortUserPass;
				RadioButton radioButton4 = rbXproxy;
				RadioButton radioButton5 = rbTMProxy;
				rbProxyShoplike.Checked = false;
				radioButton5.Checked = false;
				radioButton4.Checked = false;
				radioButton3.Checked = false;
				radioButton2.Checked = false;
				radioButton.Checked = false;
			}
			pnlProxyFree.Enabled = rdProxyOrbit.Checked;
		}

		private void method_104(object sender, EventArgs e)
		{
		}

		void Dispose(bool disposing)
		{
			if (disposing && icontainer_0 != null)
			{
				icontainer_0.Dispose();
			}
			Dispose(disposing);
		}

		private void InitializeComponent()
		{
			icontainer_0 = new System.ComponentModel.Container();
			System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle = new System.Windows.Forms.DataGridViewCellStyle();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolRegFB.frmMain));
			contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(icontainer_0);
			toolStripMenuItem_0 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_2 = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_4 = new System.Windows.Forms.ToolStripMenuItem();
			liveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			dieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			checkpointToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			toolStripMenuItem_3 = new System.Windows.Forms.ToolStripMenuItem();
			copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPass2FAToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			uidPassTokenCookieToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			mailPassMailToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			phoneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			statusStrip1 = new System.Windows.Forms.StatusStrip();
			toolStripStatusLabel9 = new System.Windows.Forms.ToolStripStatusLabel();
			plTrangThai = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel10 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
			stTotalSuccess = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel3 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel4 = new System.Windows.Forms.ToolStripStatusLabel();
			stTotalFail = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel6 = new System.Windows.Forms.ToolStripStatusLabel();
			stIPCur = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel7 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel14 = new System.Windows.Forms.ToolStripStatusLabel();
			lblCountSelect = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel8 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel16 = new System.Windows.Forms.ToolStripStatusLabel();
			lblTimeExpired = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel15 = new System.Windows.Forms.ToolStripStatusLabel();
			toolStripStatusLabel5 = new System.Windows.Forms.ToolStripStatusLabel();
			lblMachineName = new System.Windows.Forms.ToolStripStatusLabel();
			timer_0 = new System.Windows.Forms.Timer(icontainer_0);
			label28 = new System.Windows.Forms.Label();
			panel4 = new System.Windows.Forms.Panel();
			btnMaximum = new System.Windows.Forms.Button();
			btnClose = new System.Windows.Forms.Button();
			btnMinimized = new System.Windows.Forms.Button();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			timer_1 = new System.Windows.Forms.Timer(icontainer_0);
			bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
			pnlContainer = new System.Windows.Forms.Panel();
			btnTurnOffAllLD = new System.Windows.Forms.Button();
			btnCreateLDPLayer = new System.Windows.Forms.Button();
			btnRepairLD = new System.Windows.Forms.Button();
			btnManagerLD = new System.Windows.Forms.Button();
			btnOutpuData = new System.Windows.Forms.Button();
			btnAutoConfig = new System.Windows.Forms.Button();
			btnSaveConf = new System.Windows.Forms.Button();
			btnStop = new System.Windows.Forms.Button();
			btnReg = new System.Windows.Forms.Button();
			groupBox2 = new System.Windows.Forms.GroupBox();
			dgvAcc = new System.Windows.Forms.DataGridView();
			cChose = new System.Windows.Forms.DataGridViewCheckBoxColumn();
			cId = new System.Windows.Forms.DataGridViewTextBoxColumn();
			status = new System.Windows.Forms.DataGridViewTextBoxColumn();
			uid = new System.Windows.Forms.DataGridViewTextBoxColumn();
			pass = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ho = new System.Windows.Forms.DataGridViewTextBoxColumn();
			ten = new System.Windows.Forms.DataGridViewTextBoxColumn();
			age = new System.Windows.Forms.DataGridViewTextBoxColumn();
			gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
			conf_2fa = new System.Windows.Forms.DataGridViewTextBoxColumn();
			token = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cookie = new System.Windows.Forms.DataGridViewTextBoxColumn();
			email = new System.Windows.Forms.DataGridViewTextBoxColumn();
			passMail = new System.Windows.Forms.DataGridViewTextBoxColumn();
			phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
			proxy = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
			cDevice = new System.Windows.Forms.DataGridViewTextBoxColumn();
			groupBox1 = new System.Windows.Forms.GroupBox();
			groupBox7 = new System.Windows.Forms.GroupBox();
			txtLinkAvartar = new System.Windows.Forms.TextBox();
			nAgeTo = new System.Windows.Forms.NumericUpDown();
			nAgeFrom = new System.Windows.Forms.NumericUpDown();
			nudDelayQR2Fa = new System.Windows.Forms.NumericUpDown();
			btnNhapanh = new System.Windows.Forms.Button();
			label40 = new System.Windows.Forms.Label();
			panel3 = new System.Windows.Forms.Panel();
			rbRandomMF = new System.Windows.Forms.RadioButton();
			rbFemale = new System.Windows.Forms.RadioButton();
			rbMale = new System.Windows.Forms.RadioButton();
			chkCoverImg = new System.Windows.Forms.CheckBox();
			chkAvartar = new System.Windows.Forms.CheckBox();
			label36 = new System.Windows.Forms.Label();
			chk2FA = new System.Windows.Forms.CheckBox();
			chkRandomPass = new System.Windows.Forms.CheckBox();
			label14 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			txtPassFb = new System.Windows.Forms.TextBox();
			label43 = new System.Windows.Forms.Label();
			label41 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			cbNameReg = new System.Windows.Forms.ComboBox();
			groupBox6 = new System.Windows.Forms.GroupBox();
			panel2 = new System.Windows.Forms.Panel();
			tabMailVeri = new System.Windows.Forms.TabControl();
			tabPage6 = new System.Windows.Forms.TabPage();
			plVeriMail = new System.Windows.Forms.Panel();
			plHotmailReg = new System.Windows.Forms.Panel();
			btnCheckAPIAny = new System.Windows.Forms.Button();
			txtPassmail = new System.Windows.Forms.TextBox();
			txtAPIAnyCat = new System.Windows.Forms.TextBox();
			label22 = new System.Windows.Forms.Label();
			ckRdPassmail = new System.Windows.Forms.CheckBox();
			chkHideBrowser = new System.Windows.Forms.CheckBox();
			ckTaoMailBox = new System.Windows.Forms.CheckBox();
			label19 = new System.Windows.Forms.Label();
			btnNhapHotmail = new System.Windows.Forms.Button();
			rdHotMailReg = new System.Windows.Forms.RadioButton();
			rdHotMailRegisted = new System.Windows.Forms.RadioButton();
			tabPage7 = new System.Windows.Forms.TabPage();
			pnlTemmail = new System.Windows.Forms.Panel();
			lnkMailTM = new System.Windows.Forms.LinkLabel();
			rdMailTM = new System.Windows.Forms.RadioButton();
			lnkTempMailIO = new System.Windows.Forms.LinkLabel();
			rdTempMailIO = new System.Windows.Forms.RadioButton();
			plNovery = new System.Windows.Forms.Panel();
			rdNoveriMail = new System.Windows.Forms.RadioButton();
			rdNovriPhone = new System.Windows.Forms.RadioButton();
			label18 = new System.Windows.Forms.Label();
			txtListDauso = new System.Windows.Forms.TextBox();
			label17 = new System.Windows.Forms.Label();
			cbMailAo = new System.Windows.Forms.ComboBox();
			cbbPhoneCountry = new System.Windows.Forms.ComboBox();
			plVeriPhone = new System.Windows.Forms.Panel();
			btnCheckSim = new System.Windows.Forms.Button();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			cbDvSim = new System.Windows.Forms.ComboBox();
			txtAPISim = new System.Windows.Forms.TextBox();
			rdThuePhone = new System.Windows.Forms.RadioButton();
			rdNoVeri = new System.Windows.Forms.RadioButton();
			rdConfMail = new System.Windows.Forms.RadioButton();
			cbbPrePhone = new System.Windows.Forms.ComboBox();
			groupBox8 = new System.Windows.Forms.GroupBox();
			pnlTuongTac = new System.Windows.Forms.Panel();
			gbCamxuc = new System.Windows.Forms.GroupBox();
			chkGian = new System.Windows.Forms.CheckBox();
			chkBuon = new System.Windows.Forms.CheckBox();
			chkHaha = new System.Windows.Forms.CheckBox();
			chkTym = new System.Windows.Forms.CheckBox();
			chkLike = new System.Windows.Forms.CheckBox();
			plAddfriend = new System.Windows.Forms.Panel();
			nFriendTo = new System.Windows.Forms.NumericUpDown();
			label25 = new System.Windows.Forms.Label();
			nFriendFrom = new System.Windows.Forms.NumericUpDown();
			label26 = new System.Windows.Forms.Label();
			label27 = new System.Windows.Forms.Label();
			chkInNewfeed = new System.Windows.Forms.CheckBox();
			chkWatch = new System.Windows.Forms.CheckBox();
			chkWStory = new System.Windows.Forms.CheckBox();
			chkAddFUID = new System.Windows.Forms.CheckBox();
			chkReadNotifi = new System.Windows.Forms.CheckBox();
			groupBox5 = new System.Windows.Forms.GroupBox();
			panel5 = new System.Windows.Forms.Panel();
			tabProxy = new System.Windows.Forms.TabControl();
			tabPage1 = new System.Windows.Forms.TabPage();
			linkLabel1 = new System.Windows.Forms.LinkLabel();
			plTinsoftProxy = new System.Windows.Forms.Panel();
			nudLuongPerIPTinsoft = new System.Windows.Forms.NumericUpDown();
			btnCheckProxy = new System.Windows.Forms.Button();
			label16 = new System.Windows.Forms.Label();
			label29 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			txtProxy = new System.Windows.Forms.TextBox();
			cbLocationProxy = new System.Windows.Forms.ComboBox();
			rdTinsoftProxy = new System.Windows.Forms.RadioButton();
			tabPage2 = new System.Windows.Forms.TabPage();
			linkLabel2 = new System.Windows.Forms.LinkLabel();
			pnlAPIMinProxy = new System.Windows.Forms.Panel();
			btnCheckAPIMinProxy = new System.Windows.Forms.Button();
			txtApiKeyMinProxy = new System.Windows.Forms.RichTextBox();
			lblAPIMinKey = new System.Windows.Forms.Label();
			label32 = new System.Windows.Forms.Label();
			label50 = new System.Windows.Forms.Label();
			nudLuongPerIPMinProxy = new System.Windows.Forms.NumericUpDown();
			rdMinProxy = new System.Windows.Forms.RadioButton();
			tabPage3 = new System.Windows.Forms.TabPage();
			pnlIpPort = new System.Windows.Forms.Panel();
			cbbTypeProxyIP = new System.Windows.Forms.ComboBox();
			label33 = new System.Windows.Forms.Label();
			label31 = new System.Windows.Forms.Label();
			rdIPDong = new System.Windows.Forms.RadioButton();
			rdIPStatic = new System.Windows.Forms.RadioButton();
			label34 = new System.Windows.Forms.Label();
			label30 = new System.Windows.Forms.Label();
			txtListProxyIp = new System.Windows.Forms.RichTextBox();
			lblListProxyIP = new System.Windows.Forms.Label();
			rdIPPortUserPass = new System.Windows.Forms.RadioButton();
			tabPage4 = new System.Windows.Forms.TabPage();
			panel1 = new System.Windows.Forms.Panel();
			plXproxy = new System.Windows.Forms.Panel();
			panel8 = new System.Windows.Forms.Panel();
			label53 = new System.Windows.Forms.Label();
			rbXproxyResetAllProxy = new System.Windows.Forms.RadioButton();
			rbXproxyResetEachProxy = new System.Windows.Forms.RadioButton();
			ckbWaitDoneAllXproxy = new System.Windows.Forms.CheckBox();
			txtListXProxy = new System.Windows.Forms.RichTextBox();
			rbSock5Proxy = new System.Windows.Forms.RadioButton();
			rbHttpProxy = new System.Windows.Forms.RadioButton();
			label35 = new System.Windows.Forms.Label();
			lblCountXproxy = new System.Windows.Forms.Label();
			label52 = new System.Windows.Forms.Label();
			label51 = new System.Windows.Forms.Label();
			label39 = new System.Windows.Forms.Label();
			label37 = new System.Windows.Forms.Label();
			nudDelayResetXProxy = new System.Windows.Forms.NumericUpDown();
			nudLuongPerIPXProxy = new System.Windows.Forms.NumericUpDown();
			label38 = new System.Windows.Forms.Label();
			txtServiceURLXProxy = new System.Windows.Forms.TextBox();
			rbXproxy = new System.Windows.Forms.RadioButton();
			tabPage5 = new System.Windows.Forms.TabPage();
			linkLabel3 = new System.Windows.Forms.LinkLabel();
			plTMProxy = new System.Windows.Forms.Panel();
			btnCheckTMProxy = new System.Windows.Forms.Button();
			txtApiKeyTMProxy = new System.Windows.Forms.RichTextBox();
			lblCountTmProxy = new System.Windows.Forms.Label();
			label42 = new System.Windows.Forms.Label();
			nudLuongPerIPTMProxy = new System.Windows.Forms.NumericUpDown();
			rbTMProxy = new System.Windows.Forms.RadioButton();
			tabPage8 = new System.Windows.Forms.TabPage();
			lnkShopLike = new System.Windows.Forms.LinkLabel();
			plProxyShopLike = new System.Windows.Forms.Panel();
			txtAPIKeyShoplike = new System.Windows.Forms.RichTextBox();
			lblAPIKeyShopLike = new System.Windows.Forms.Label();
			label47 = new System.Windows.Forms.Label();
			nudThreadShopLike = new System.Windows.Forms.NumericUpDown();
			rbProxyShoplike = new System.Windows.Forms.RadioButton();
			tabPage9 = new System.Windows.Forms.TabPage();
			pnlProxyFree = new System.Windows.Forms.Panel();
			rdProxyFreeRandom = new System.Windows.Forms.RadioButton();
			rdProxyFreeUS = new System.Windows.Forms.RadioButton();
			rdProxyFreeVN = new System.Windows.Forms.RadioButton();
			rdProxyOrbit = new System.Windows.Forms.RadioButton();
			plCheckDoiIP = new System.Windows.Forms.Panel();
			btnTestChangeIP = new System.Windows.Forms.Button();
			numChangeIP = new System.Windows.Forms.NumericUpDown();
			label20 = new System.Windows.Forms.Label();
			label21 = new System.Windows.Forms.Label();
			plChangeIPDcom = new System.Windows.Forms.Panel();
			btnGetDcom = new System.Windows.Forms.Button();
			txtNameDcom = new System.Windows.Forms.TextBox();
			rdProxy = new System.Windows.Forms.RadioButton();
			rdHMA = new System.Windows.Forms.RadioButton();
			rdChangeIPDcom = new System.Windows.Forms.RadioButton();
			rdNoChangeIP = new System.Windows.Forms.RadioButton();
			groupBox4 = new System.Windows.Forms.GroupBox();
			panel7 = new System.Windows.Forms.Panel();
			numDelayTo = new System.Windows.Forms.NumericUpDown();
			rdDelayLD = new System.Windows.Forms.RadioButton();
			label4 = new System.Windows.Forms.Label();
			numDelayFr = new System.Windows.Forms.NumericUpDown();
			label5 = new System.Windows.Forms.Label();
			txtLinkLD = new System.Windows.Forms.TextBox();
			numDeClsTo = new System.Windows.Forms.NumericUpDown();
			numDeClsFr = new System.Windows.Forms.NumericUpDown();
			label7 = new System.Windows.Forms.Label();
			rdSwap = new System.Windows.Forms.RadioButton();
			rdNormal = new System.Windows.Forms.RadioButton();
			label8 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			groupBox3 = new System.Windows.Forms.GroupBox();
			pnlSoLanReg = new System.Windows.Forms.Panel();
			nudSoLuotChay = new System.Windows.Forms.NumericUpDown();
			label23 = new System.Windows.Forms.Label();
			label24 = new System.Windows.Forms.Label();
			nudTimeWaitOTP = new System.Windows.Forms.NumericUpDown();
			numOTP = new System.Windows.Forms.NumericUpDown();
			numThrLdPlay = new System.Windows.Forms.NumericUpDown();
			label48 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			button1 = new System.Windows.Forms.Button();
			label45 = new System.Windows.Forms.Label();
			cbModeRunReg = new System.Windows.Forms.ComboBox();
			label46 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			ckCheckIP = new System.Windows.Forms.CheckBox();
			bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
			contextMenuStrip1.SuspendLayout();
			statusStrip1.SuspendLayout();
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			pnlContainer.SuspendLayout();
			groupBox2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)dgvAcc).BeginInit();
			groupBox1.SuspendLayout();
			groupBox7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nAgeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nAgeFrom).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDelayQR2Fa).BeginInit();
			panel3.SuspendLayout();
			groupBox6.SuspendLayout();
			panel2.SuspendLayout();
			tabMailVeri.SuspendLayout();
			tabPage6.SuspendLayout();
			plVeriMail.SuspendLayout();
			plHotmailReg.SuspendLayout();
			tabPage7.SuspendLayout();
			pnlTemmail.SuspendLayout();
			plNovery.SuspendLayout();
			plVeriPhone.SuspendLayout();
			groupBox8.SuspendLayout();
			pnlTuongTac.SuspendLayout();
			gbCamxuc.SuspendLayout();
			plAddfriend.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nFriendTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nFriendFrom).BeginInit();
			groupBox5.SuspendLayout();
			panel5.SuspendLayout();
			tabProxy.SuspendLayout();
			tabPage1.SuspendLayout();
			plTinsoftProxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).BeginInit();
			tabPage2.SuspendLayout();
			pnlAPIMinProxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPMinProxy).BeginInit();
			tabPage3.SuspendLayout();
			pnlIpPort.SuspendLayout();
			tabPage4.SuspendLayout();
			panel1.SuspendLayout();
			plXproxy.SuspendLayout();
			panel8.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayResetXProxy).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).BeginInit();
			tabPage5.SuspendLayout();
			plTMProxy.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).BeginInit();
			tabPage8.SuspendLayout();
			plProxyShopLike.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudThreadShopLike).BeginInit();
			tabPage9.SuspendLayout();
			pnlProxyFree.SuspendLayout();
			plCheckDoiIP.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numChangeIP).BeginInit();
			plChangeIPDcom.SuspendLayout();
			groupBox4.SuspendLayout();
			panel7.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)numDelayTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)numDelayFr).BeginInit();
			((System.ComponentModel.ISupportInitialize)numDeClsTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)numDeClsFr).BeginInit();
			groupBox3.SuspendLayout();
			pnlSoLanReg.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudTimeWaitOTP).BeginInit();
			((System.ComponentModel.ISupportInitialize)numOTP).BeginInit();
			((System.ComponentModel.ISupportInitialize)numThrLdPlay).BeginInit();
			SuspendLayout();
			contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_0, toolStripMenuItem_3, copyToolStripMenuItem });
			contextMenuStrip1.Name = "contextMenuStrip1";
			contextMenuStrip1.Size = new System.Drawing.Size(174, 76);
			toolStripMenuItem_0.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { toolStripMenuItem_1, toolStripMenuItem_2, toolStripMenuItem_4 });
			toolStripMenuItem_0.Name = "chọnToolStripMenuItem";
			toolStripMenuItem_0.Size = new System.Drawing.Size(173, 24);
			toolStripMenuItem_0.Text = "Chọn";
			toolStripMenuItem_1.Name = "tấtCảToolStripMenuItem";
			toolStripMenuItem_1.Size = new System.Drawing.Size(158, 26);
			toolStripMenuItem_1.Text = "Tất cả";
			toolStripMenuItem_1.Click += new System.EventHandler(toolStripMenuItem_1_Click);
			toolStripMenuItem_2.Name = "bôiĐenToolStripMenuItem";
			toolStripMenuItem_2.Size = new System.Drawing.Size(158, 26);
			toolStripMenuItem_2.Text = "Bôi đen";
			toolStripMenuItem_2.Click += new System.EventHandler(toolStripMenuItem_2_Click);
			toolStripMenuItem_4.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[3] { liveToolStripMenuItem, dieToolStripMenuItem, checkpointToolStripMenuItem });
			toolStripMenuItem_4.Name = "trạngTháiToolStripMenuItem";
			toolStripMenuItem_4.Size = new System.Drawing.Size(158, 26);
			toolStripMenuItem_4.Text = "Trạng thái";
			liveToolStripMenuItem.Name = "liveToolStripMenuItem";
			liveToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
			liveToolStripMenuItem.Text = "Live";
			liveToolStripMenuItem.Click += new System.EventHandler(liveToolStripMenuItem_Click);
			dieToolStripMenuItem.Name = "dieToolStripMenuItem";
			dieToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
			dieToolStripMenuItem.Text = "Die";
			dieToolStripMenuItem.Click += new System.EventHandler(dieToolStripMenuItem_Click);
			checkpointToolStripMenuItem.Name = "checkpointToolStripMenuItem";
			checkpointToolStripMenuItem.Size = new System.Drawing.Size(166, 26);
			checkpointToolStripMenuItem.Text = "Checkpoint";
			checkpointToolStripMenuItem.Click += new System.EventHandler(checkpointToolStripMenuItem_Click);
			toolStripMenuItem_3.Name = "bỏChọnTấtCảToolStripMenuItem";
			toolStripMenuItem_3.Size = new System.Drawing.Size(173, 24);
			toolStripMenuItem_3.Text = "Bỏ chọn tất cả";
			toolStripMenuItem_3.Click += new System.EventHandler(toolStripMenuItem_3_Click);
			copyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[6] { uidPassToolStripMenuItem, uidPass2FAToolStripMenuItem, uidPassTokenCookieToolStripMenuItem, mailPassMailToolStripMenuItem, phoneToolStripMenuItem, allToolStripMenuItem });
			copyToolStripMenuItem.Name = "copyToolStripMenuItem";
			copyToolStripMenuItem.Size = new System.Drawing.Size(173, 24);
			copyToolStripMenuItem.Text = "Copy";
			uidPassToolStripMenuItem.Name = "uidPassToolStripMenuItem";
			uidPassToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			uidPassToolStripMenuItem.Text = "Uid|Pass";
			uidPassToolStripMenuItem.Click += new System.EventHandler(uidPassToolStripMenuItem_Click);
			uidPass2FAToolStripMenuItem.Name = "uidPass2FAToolStripMenuItem";
			uidPass2FAToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			uidPass2FAToolStripMenuItem.Text = "Uid|Pass|2FA";
			uidPass2FAToolStripMenuItem.Click += new System.EventHandler(uidPass2FAToolStripMenuItem_Click);
			uidPassTokenCookieToolStripMenuItem.Name = "uidPassTokenCookieToolStripMenuItem";
			uidPassTokenCookieToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			uidPassTokenCookieToolStripMenuItem.Text = "Uid|Pass|Token|Cookie";
			uidPassTokenCookieToolStripMenuItem.Click += new System.EventHandler(uidPassTokenCookieToolStripMenuItem_Click);
			mailPassMailToolStripMenuItem.Name = "mailPassMailToolStripMenuItem";
			mailPassMailToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			mailPassMailToolStripMenuItem.Text = "Mail|PassMail";
			mailPassMailToolStripMenuItem.Click += new System.EventHandler(mailPassMailToolStripMenuItem_Click);
			phoneToolStripMenuItem.Name = "phoneToolStripMenuItem";
			phoneToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			phoneToolStripMenuItem.Text = "Phone";
			phoneToolStripMenuItem.Click += new System.EventHandler(phoneToolStripMenuItem_Click);
			allToolStripMenuItem.Name = "allToolStripMenuItem";
			allToolStripMenuItem.Size = new System.Drawing.Size(239, 26);
			allToolStripMenuItem.Text = "All";
			allToolStripMenuItem.Click += new System.EventHandler(allToolStripMenuItem_Click);
			statusStrip1.BackColor = System.Drawing.SystemColors.Control;
			statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
			statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[20]
			{
				toolStripStatusLabel9, plTrangThai, toolStripStatusLabel10, toolStripStatusLabel1, stTotalSuccess, toolStripStatusLabel3, toolStripStatusLabel4, stTotalFail, toolStripStatusLabel2, toolStripStatusLabel6,
				stIPCur, toolStripStatusLabel7, toolStripStatusLabel14, lblCountSelect, toolStripStatusLabel8, toolStripStatusLabel16, lblTimeExpired, toolStripStatusLabel15, toolStripStatusLabel5, lblMachineName
			});
			statusStrip1.Location = new System.Drawing.Point(0, 1026);
			statusStrip1.Name = "statusStrip1";
			statusStrip1.Size = new System.Drawing.Size(1924, 29);
			statusStrip1.TabIndex = 3;
			statusStrip1.Text = "statusStrip1";
			toolStripStatusLabel9.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel9.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel9.Name = "toolStripStatusLabel9";
			toolStripStatusLabel9.Size = new System.Drawing.Size(97, 23);
			toolStripStatusLabel9.Text = "Trạng thái:";
			plTrangThai.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			plTrangThai.ForeColor = System.Drawing.Color.FromArgb(189, 6, 30);
			plTrangThai.Name = "plTrangThai";
			plTrangThai.Size = new System.Drawing.Size(81, 23);
			plTrangThai.Text = "Chưa chạy";
			toolStripStatusLabel10.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel10.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel10.Name = "toolStripStatusLabel10";
			toolStripStatusLabel10.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel10.Text = "|";
			toolStripStatusLabel1.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel1.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel1.Name = "toolStripStatusLabel1";
			toolStripStatusLabel1.Size = new System.Drawing.Size(108, 23);
			toolStripStatusLabel1.Text = "Thành công:";
			stTotalSuccess.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			stTotalSuccess.ForeColor = System.Drawing.Color.FromArgb(6, 189, 11);
			stTotalSuccess.Name = "stTotalSuccess";
			stTotalSuccess.Size = new System.Drawing.Size(18, 23);
			stTotalSuccess.Text = "0";
			toolStripStatusLabel3.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel3.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel3.Name = "toolStripStatusLabel3";
			toolStripStatusLabel3.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel3.Text = "|";
			toolStripStatusLabel4.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel4.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel4.Name = "toolStripStatusLabel4";
			toolStripStatusLabel4.Size = new System.Drawing.Size(81, 23);
			toolStripStatusLabel4.Text = "Thất bại:";
			stTotalFail.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			stTotalFail.ForeColor = System.Drawing.Color.Red;
			stTotalFail.Name = "stTotalFail";
			stTotalFail.Size = new System.Drawing.Size(18, 23);
			stTotalFail.Text = "0";
			toolStripStatusLabel2.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel2.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel2.Name = "toolStripStatusLabel2";
			toolStripStatusLabel2.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel2.Text = "|";
			toolStripStatusLabel6.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel6.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel6.Name = "toolStripStatusLabel6";
			toolStripStatusLabel6.Size = new System.Drawing.Size(95, 23);
			toolStripStatusLabel6.Text = "IP hiện tại:";
			stIPCur.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			stIPCur.ForeColor = System.Drawing.Color.FromArgb(6, 40, 189);
			stIPCur.Name = "stIPCur";
			stIPCur.Size = new System.Drawing.Size(74, 23);
			stIPCur.Text = "currentIP";
			toolStripStatusLabel7.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel7.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel7.Name = "toolStripStatusLabel7";
			toolStripStatusLabel7.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel7.Text = "|";
			toolStripStatusLabel14.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel14.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel14.Name = "toolStripStatusLabel14";
			toolStripStatusLabel14.Size = new System.Drawing.Size(80, 23);
			toolStripStatusLabel14.Text = "Đã chọn:";
			lblCountSelect.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblCountSelect.ForeColor = System.Drawing.Color.FromArgb(189, 6, 165);
			lblCountSelect.Name = "lblCountSelect";
			lblCountSelect.Size = new System.Drawing.Size(18, 23);
			lblCountSelect.Text = "0";
			toolStripStatusLabel8.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel8.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel8.Name = "toolStripStatusLabel8";
			toolStripStatusLabel8.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel8.Text = "|";
			toolStripStatusLabel16.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel16.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel16.Name = "toolStripStatusLabel16";
			toolStripStatusLabel16.Size = new System.Drawing.Size(117, 23);
			toolStripStatusLabel16.Text = "Hạn sử dụng:";
			lblTimeExpired.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblTimeExpired.ForeColor = System.Drawing.Color.FromArgb(173, 18, 16);
			lblTimeExpired.Name = "lblTimeExpired";
			lblTimeExpired.Size = new System.Drawing.Size(18, 23);
			lblTimeExpired.Text = "0";
			toolStripStatusLabel15.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel15.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel15.Name = "toolStripStatusLabel15";
			toolStripStatusLabel15.Size = new System.Drawing.Size(14, 23);
			toolStripStatusLabel15.Text = "|";
			toolStripStatusLabel5.Font = new System.Drawing.Font("Segoe UI", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			toolStripStatusLabel5.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			toolStripStatusLabel5.Name = "toolStripStatusLabel5";
			toolStripStatusLabel5.Size = new System.Drawing.Size(79, 23);
			toolStripStatusLabel5.Text = "Mã máy:";
			lblMachineName.Font = new System.Drawing.Font("Segoe UI", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			lblMachineName.ForeColor = System.Drawing.Color.FromArgb(86, 89, 10);
			lblMachineName.Name = "lblMachineName";
			lblMachineName.Size = new System.Drawing.Size(18, 23);
			lblMachineName.Text = "0";
			timer_0.Interval = 1000;
			timer_0.Tick += new System.EventHandler(timer_0_Tick);
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Nirmala UI", 16.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label28.ForeColor = System.Drawing.Color.White;
			label28.Location = new System.Drawing.Point(42, 2);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(498, 38);
			label28.TabIndex = 6;
			label28.Text = "Auto Register Facebook On LDPlayer";
			panel4.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
			panel4.Controls.Add(btnMaximum);
			panel4.Controls.Add(btnClose);
			panel4.Controls.Add(btnMinimized);
			panel4.Controls.Add(label28);
			panel4.Controls.Add(pictureBox1);
			panel4.Dock = System.Windows.Forms.DockStyle.Top;
			panel4.Location = new System.Drawing.Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(1924, 46);
			panel4.TabIndex = 7;
			btnMaximum.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMaximum.FlatAppearance.BorderSize = 0;
			btnMaximum.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMaximum.ForeColor = System.Drawing.Color.White;
			btnMaximum.Image = ns5.Class74.icons8_maximize_button_20;
			btnMaximum.Location = new System.Drawing.Point(1842, 2);
			btnMaximum.Name = "btnMaximum";
			btnMaximum.Size = new System.Drawing.Size(44, 34);
			btnMaximum.TabIndex = 7;
			btnMaximum.UseVisualStyleBackColor = true;
			btnMaximum.Click += new System.EventHandler(btnMaximum_Click);
			btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnClose.FlatAppearance.BorderSize = 0;
			btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnClose.Image = ns5.Class74.icons8_x_20;
			btnClose.Location = new System.Drawing.Point(1877, 0);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(44, 39);
			btnClose.TabIndex = 5;
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			btnMinimized.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnMinimized.FlatAppearance.BorderSize = 0;
			btnMinimized.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnMinimized.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnMinimized.Image = ns5.Class74.icons8_minimize_window_20;
			btnMinimized.Location = new System.Drawing.Point(1804, 0);
			btnMinimized.Name = "btnMinimized";
			btnMinimized.Size = new System.Drawing.Size(44, 39);
			btnMinimized.TabIndex = 5;
			btnMinimized.UseVisualStyleBackColor = true;
			btnMinimized.Click += new System.EventHandler(btnMinimized_Click);
			pictureBox1.Image = ns5.Class74.icons8_facebook_970;
			pictureBox1.Location = new System.Drawing.Point(2, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 40);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			timer_1.Interval = 5000;
			timer_1.Tick += new System.EventHandler(timer_1_Tick);
			bunifuDragControl_0.Fixed = true;
			bunifuDragControl_0.Horizontal = true;
			bunifuDragControl_0.TargetControl = panel4;
			bunifuDragControl_0.Vertical = true;
			pnlContainer.Controls.Add(btnTurnOffAllLD);
			pnlContainer.Controls.Add(btnCreateLDPLayer);
			pnlContainer.Controls.Add(btnRepairLD);
			pnlContainer.Controls.Add(btnManagerLD);
			pnlContainer.Controls.Add(btnOutpuData);
			pnlContainer.Controls.Add(btnAutoConfig);
			pnlContainer.Controls.Add(btnSaveConf);
			pnlContainer.Controls.Add(btnStop);
			pnlContainer.Controls.Add(btnReg);
			pnlContainer.Controls.Add(groupBox2);
			pnlContainer.Controls.Add(groupBox1);
			pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlContainer.Location = new System.Drawing.Point(0, 46);
			pnlContainer.Name = "pnlContainer";
			pnlContainer.Size = new System.Drawing.Size(1924, 980);
			pnlContainer.TabIndex = 8;
			btnTurnOffAllLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnTurnOffAllLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnTurnOffAllLD.ForeColor = System.Drawing.Color.FromArgb(50, 89, 168);
			btnTurnOffAllLD.Image = ns5.Class74.icons8_interface_25;
			btnTurnOffAllLD.Location = new System.Drawing.Point(527, 92);
			btnTurnOffAllLD.Name = "btnTurnOffAllLD";
			btnTurnOffAllLD.Size = new System.Drawing.Size(170, 63);
			btnTurnOffAllLD.TabIndex = 11;
			btnTurnOffAllLD.Text = "Tắt tất cả LDPlayer";
			btnTurnOffAllLD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnTurnOffAllLD.UseVisualStyleBackColor = true;
			btnTurnOffAllLD.Click += new System.EventHandler(btnTurnOffAllLD_Click);
			btnCreateLDPLayer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCreateLDPLayer.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnCreateLDPLayer.ForeColor = System.Drawing.Color.FromArgb(168, 50, 160);
			btnCreateLDPLayer.Image = ns5.Class74.icons8_new_25;
			btnCreateLDPLayer.Location = new System.Drawing.Point(351, 92);
			btnCreateLDPLayer.Name = "btnCreateLDPLayer";
			btnCreateLDPLayer.Size = new System.Drawing.Size(170, 63);
			btnCreateLDPLayer.TabIndex = 11;
			btnCreateLDPLayer.Text = "Tạo mới LDPlayer";
			btnCreateLDPLayer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnCreateLDPLayer.UseVisualStyleBackColor = true;
			btnCreateLDPLayer.Click += new System.EventHandler(btnCreateLDPLayer_Click);
			btnRepairLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnRepairLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnRepairLD.ForeColor = System.Drawing.Color.FromArgb(50, 168, 148);
			btnRepairLD.Image = ns5.Class74.icons8_job_25;
			btnRepairLD.Location = new System.Drawing.Point(175, 92);
			btnRepairLD.Name = "btnRepairLD";
			btnRepairLD.Size = new System.Drawing.Size(170, 63);
			btnRepairLD.TabIndex = 11;
			btnRepairLD.Text = "Sửa chữa LDPlayer";
			btnRepairLD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnRepairLD.UseVisualStyleBackColor = true;
			btnRepairLD.Click += new System.EventHandler(btnRepairLD_Click);
			btnManagerLD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnManagerLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnManagerLD.ForeColor = System.Drawing.Color.FromArgb(168, 78, 50);
			btnManagerLD.Image = ns5.Class74.icons8_player_25;
			btnManagerLD.Location = new System.Drawing.Point(12, 92);
			btnManagerLD.Name = "btnManagerLD";
			btnManagerLD.Size = new System.Drawing.Size(157, 61);
			btnManagerLD.TabIndex = 11;
			btnManagerLD.Text = "Quản lý LDPlayer";
			btnManagerLD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnManagerLD.UseVisualStyleBackColor = true;
			btnManagerLD.Click += new System.EventHandler(btnManagerLD_Click);
			btnOutpuData.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnOutpuData.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnOutpuData.ForeColor = System.Drawing.Color.FromArgb(168, 50, 155);
			btnOutpuData.Image = ns5.Class74.icons8_folder_25;
			btnOutpuData.Location = new System.Drawing.Point(608, 16);
			btnOutpuData.Name = "btnOutpuData";
			btnOutpuData.Size = new System.Drawing.Size(143, 61);
			btnOutpuData.TabIndex = 11;
			btnOutpuData.Text = "Output Data";
			btnOutpuData.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnOutpuData.UseVisualStyleBackColor = true;
			btnOutpuData.Click += new System.EventHandler(btnOutpuData_Click);
			btnAutoConfig.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAutoConfig.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnAutoConfig.ForeColor = System.Drawing.Color.FromArgb(66, 135, 245);
			btnAutoConfig.Image = ns5.Class74.icons8_automation_25;
			btnAutoConfig.Location = new System.Drawing.Point(452, 16);
			btnAutoConfig.Name = "btnAutoConfig";
			btnAutoConfig.Size = new System.Drawing.Size(150, 61);
			btnAutoConfig.TabIndex = 11;
			btnAutoConfig.Text = "Cài đặt nâng cao";
			btnAutoConfig.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnAutoConfig.UseVisualStyleBackColor = true;
			btnAutoConfig.Click += new System.EventHandler(btnAutoConfig_Click);
			btnSaveConf.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnSaveConf.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnSaveConf.ForeColor = System.Drawing.Color.FromArgb(245, 99, 66);
			btnSaveConf.Image = ns5.Class74.icons8_setting_25;
			btnSaveConf.Location = new System.Drawing.Point(305, 16);
			btnSaveConf.Name = "btnSaveConf";
			btnSaveConf.Size = new System.Drawing.Size(140, 61);
			btnSaveConf.TabIndex = 12;
			btnSaveConf.Text = "Lưu cấu hình";
			btnSaveConf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnSaveConf.UseVisualStyleBackColor = true;
			btnSaveConf.Click += new System.EventHandler(btnSaveConf_Click);
			btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnStop.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnStop.ForeColor = System.Drawing.Color.Red;
			btnStop.Image = ns5.Class74.icons8_stop_25__1_;
			btnStop.Location = new System.Drawing.Point(158, 15);
			btnStop.Name = "btnStop";
			btnStop.Size = new System.Drawing.Size(140, 61);
			btnStop.TabIndex = 13;
			btnStop.Text = "Dừng lại";
			btnStop.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnStop.UseVisualStyleBackColor = true;
			btnStop.Click += new System.EventHandler(btnStop_Click);
			btnReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			btnReg.ForeColor = System.Drawing.Color.FromArgb(37, 189, 6);
			btnReg.Image = ns5.Class74.icons8_start_25__1_;
			btnReg.Location = new System.Drawing.Point(12, 15);
			btnReg.Name = "btnReg";
			btnReg.Size = new System.Drawing.Size(140, 61);
			btnReg.TabIndex = 14;
			btnReg.Text = "Bắt đầu";
			btnReg.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			btnReg.UseVisualStyleBackColor = true;
			btnReg.Click += new System.EventHandler(btnReg_Click);
			groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
			groupBox2.BackColor = System.Drawing.SystemColors.Control;
			groupBox2.Controls.Add(dgvAcc);
			groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox2.Location = new System.Drawing.Point(12, 165);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(735, 806);
			groupBox2.TabIndex = 10;
			groupBox2.TabStop = false;
			groupBox2.Text = "Danh sách tài khoản";
			dgvAcc.AllowUserToAddRows = false;
			dgvAcc.AllowUserToDeleteRows = false;
			dgvAcc.BorderStyle = System.Windows.Forms.BorderStyle.None;
			dataGridViewCellStyle.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
			dataGridViewCellStyle.BackColor = System.Drawing.SystemColors.Control;
			dataGridViewCellStyle.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			dataGridViewCellStyle.ForeColor = System.Drawing.SystemColors.WindowText;
			dataGridViewCellStyle.SelectionBackColor = System.Drawing.SystemColors.Highlight;
			dataGridViewCellStyle.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
			dataGridViewCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
			dgvAcc.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle;
			dgvAcc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvAcc.Columns.AddRange(cChose, cId, status, uid, pass, ho, ten, age, gender, conf_2fa, token, cookie, email, passMail, phone, proxy, cInfo, cDevice);
			dgvAcc.ContextMenuStrip = contextMenuStrip1;
			dgvAcc.Dock = System.Windows.Forms.DockStyle.Fill;
			dgvAcc.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
			dgvAcc.Location = new System.Drawing.Point(3, 23);
			dgvAcc.Name = "dgvAcc";
			dgvAcc.RowHeadersVisible = false;
			dgvAcc.RowHeadersWidth = 51;
			dgvAcc.RowTemplate.Height = 24;
			dgvAcc.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
			dgvAcc.Size = new System.Drawing.Size(729, 780);
			dgvAcc.TabIndex = 1;
			cChose.HeaderText = "Chọn";
			cChose.MinimumWidth = 6;
			cChose.Name = "cChose";
			cChose.Resizable = System.Windows.Forms.DataGridViewTriState.True;
			cChose.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
			cChose.Width = 85;
			cId.HeaderText = "STT";
			cId.MinimumWidth = 6;
			cId.Name = "cId";
			cId.Width = 50;
			status.HeaderText = "Trạng thái";
			status.MinimumWidth = 6;
			status.Name = "status";
			status.Width = 350;
			uid.HeaderText = "UID";
			uid.MinimumWidth = 6;
			uid.Name = "uid";
			uid.Width = 125;
			pass.HeaderText = "Mật khẩu";
			pass.MinimumWidth = 6;
			pass.Name = "pass";
			pass.Width = 125;
			ho.HeaderText = "Họ";
			ho.MinimumWidth = 6;
			ho.Name = "ho";
			ho.Width = 125;
			ten.HeaderText = "Tên";
			ten.MinimumWidth = 6;
			ten.Name = "ten";
			ten.Width = 125;
			age.HeaderText = "Tuổi";
			age.MinimumWidth = 6;
			age.Name = "age";
			age.Width = 125;
			gender.HeaderText = "Giới tính";
			gender.MinimumWidth = 6;
			gender.Name = "gender";
			gender.Width = 125;
			conf_2fa.HeaderText = "2Fa";
			conf_2fa.MinimumWidth = 6;
			conf_2fa.Name = "conf_2fa";
			conf_2fa.Width = 125;
			token.HeaderText = "Token";
			token.MinimumWidth = 6;
			token.Name = "token";
			token.Width = 125;
			cookie.HeaderText = "Cookie";
			cookie.MinimumWidth = 6;
			cookie.Name = "cookie";
			cookie.Width = 125;
			email.HeaderText = "Email";
			email.MinimumWidth = 6;
			email.Name = "email";
			email.Width = 125;
			passMail.HeaderText = "Pass Mail";
			passMail.MinimumWidth = 6;
			passMail.Name = "passMail";
			passMail.Width = 125;
			phone.HeaderText = "Phone";
			phone.MinimumWidth = 6;
			phone.Name = "phone";
			phone.Width = 125;
			proxy.HeaderText = "Proxy";
			proxy.MinimumWidth = 6;
			proxy.Name = "proxy";
			proxy.Width = 125;
			cInfo.HeaderText = "Tình trạng";
			cInfo.MinimumWidth = 6;
			cInfo.Name = "cInfo";
			cInfo.Width = 125;
			cDevice.HeaderText = "LD index";
			cDevice.MinimumWidth = 6;
			cDevice.Name = "cDevice";
			cDevice.Width = 125;
			groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right;
			groupBox1.BackColor = System.Drawing.SystemColors.Control;
			groupBox1.Controls.Add(groupBox7);
			groupBox1.Controls.Add(groupBox6);
			groupBox1.Controls.Add(groupBox8);
			groupBox1.Controls.Add(groupBox5);
			groupBox1.Controls.Add(groupBox4);
			groupBox1.Controls.Add(groupBox3);
			groupBox1.Font = new System.Drawing.Font("Nirmala UI", 10.8f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox1.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox1.Location = new System.Drawing.Point(753, 9);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(1159, 968);
			groupBox1.TabIndex = 9;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình";
			groupBox7.Controls.Add(txtLinkAvartar);
			groupBox7.Controls.Add(nAgeTo);
			groupBox7.Controls.Add(nAgeFrom);
			groupBox7.Controls.Add(nudDelayQR2Fa);
			groupBox7.Controls.Add(btnNhapanh);
			groupBox7.Controls.Add(label40);
			groupBox7.Controls.Add(panel3);
			groupBox7.Controls.Add(chkCoverImg);
			groupBox7.Controls.Add(chkAvartar);
			groupBox7.Controls.Add(label36);
			groupBox7.Controls.Add(chk2FA);
			groupBox7.Controls.Add(chkRandomPass);
			groupBox7.Controls.Add(label14);
			groupBox7.Controls.Add(label13);
			groupBox7.Controls.Add(txtPassFb);
			groupBox7.Controls.Add(label43);
			groupBox7.Controls.Add(label41);
			groupBox7.Controls.Add(label12);
			groupBox7.Controls.Add(cbNameReg);
			groupBox7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox7.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox7.Location = new System.Drawing.Point(598, 21);
			groupBox7.Name = "groupBox7";
			groupBox7.Size = new System.Drawing.Size(547, 257);
			groupBox7.TabIndex = 1;
			groupBox7.TabStop = false;
			groupBox7.Text = "Cấu hình tài khoản";
			txtLinkAvartar.Location = new System.Drawing.Point(155, 199);
			txtLinkAvartar.Name = "txtLinkAvartar";
			txtLinkAvartar.Size = new System.Drawing.Size(201, 24);
			txtLinkAvartar.TabIndex = 6;
			nAgeTo.Location = new System.Drawing.Point(466, 21);
			nAgeTo.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
			nAgeTo.Minimum = new decimal(new int[4] { 35, 0, 0, 0 });
			nAgeTo.Name = "nAgeTo";
			nAgeTo.Size = new System.Drawing.Size(58, 24);
			nAgeTo.TabIndex = 1;
			nAgeTo.Value = new decimal(new int[4] { 35, 0, 0, 0 });
			nAgeFrom.Location = new System.Drawing.Point(357, 21);
			nAgeFrom.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
			nAgeFrom.Minimum = new decimal(new int[4] { 18, 0, 0, 0 });
			nAgeFrom.Name = "nAgeFrom";
			nAgeFrom.Size = new System.Drawing.Size(55, 24);
			nAgeFrom.TabIndex = 1;
			nAgeFrom.Value = new decimal(new int[4] { 18, 0, 0, 0 });
			nudDelayQR2Fa.Location = new System.Drawing.Point(401, 163);
			nudDelayQR2Fa.Maximum = new decimal(new int[4] { 60, 0, 0, 0 });
			nudDelayQR2Fa.Minimum = new decimal(new int[4] { 10, 0, 0, 0 });
			nudDelayQR2Fa.Name = "nudDelayQR2Fa";
			nudDelayQR2Fa.Size = new System.Drawing.Size(67, 24);
			nudDelayQR2Fa.TabIndex = 1;
			nudDelayQR2Fa.Value = new decimal(new int[4] { 10, 0, 0, 0 });
			btnNhapanh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnNhapanh.Location = new System.Drawing.Point(373, 191);
			btnNhapanh.Name = "btnNhapanh";
			btnNhapanh.Size = new System.Drawing.Size(131, 40);
			btnNhapanh.TabIndex = 5;
			btnNhapanh.Text = "Folder ảnh";
			btnNhapanh.UseVisualStyleBackColor = true;
			btnNhapanh.Click += new System.EventHandler(btnNhapanh_Click);
			label40.AutoSize = true;
			label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label40.Location = new System.Drawing.Point(489, 166);
			label40.Name = "label40";
			label40.Size = new System.Drawing.Size(34, 18);
			label40.TabIndex = 0;
			label40.Text = "giây";
			panel3.Controls.Add(rbRandomMF);
			panel3.Controls.Add(rbFemale);
			panel3.Controls.Add(rbMale);
			panel3.Location = new System.Drawing.Point(85, 109);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(273, 40);
			panel3.TabIndex = 4;
			rbRandomMF.AutoSize = true;
			rbRandomMF.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbRandomMF.Location = new System.Drawing.Point(146, 10);
			rbRandomMF.Name = "rbRandomMF";
			rbRandomMF.Size = new System.Drawing.Size(103, 22);
			rbRandomMF.TabIndex = 1;
			rbRandomMF.TabStop = true;
			rbRandomMF.Text = "Ngẫu nhiên";
			rbRandomMF.UseVisualStyleBackColor = true;
			rbFemale.AutoSize = true;
			rbFemale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbFemale.Location = new System.Drawing.Point(81, 10);
			rbFemale.Name = "rbFemale";
			rbFemale.Size = new System.Drawing.Size(48, 22);
			rbFemale.TabIndex = 1;
			rbFemale.TabStop = true;
			rbFemale.Text = "Nữ";
			rbFemale.UseVisualStyleBackColor = true;
			rbMale.AutoSize = true;
			rbMale.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rbMale.Location = new System.Drawing.Point(8, 10);
			rbMale.Name = "rbMale";
			rbMale.Size = new System.Drawing.Size(61, 22);
			rbMale.TabIndex = 1;
			rbMale.TabStop = true;
			rbMale.Text = "Nam";
			rbMale.UseVisualStyleBackColor = true;
			rbMale.CheckedChanged += new System.EventHandler(rbMale_CheckedChanged);
			chkCoverImg.AutoSize = true;
			chkCoverImg.Location = new System.Drawing.Point(16, 228);
			chkCoverImg.Name = "chkCoverImg";
			chkCoverImg.Size = new System.Drawing.Size(125, 22);
			chkCoverImg.TabIndex = 3;
			chkCoverImg.Text = "Thay ảnh bìa";
			chkCoverImg.UseVisualStyleBackColor = true;
			chkAvartar.AutoSize = true;
			chkAvartar.Location = new System.Drawing.Point(16, 199);
			chkAvartar.Name = "chkAvartar";
			chkAvartar.Size = new System.Drawing.Size(123, 22);
			chkAvartar.TabIndex = 3;
			chkAvartar.Text = "Thay avartar";
			chkAvartar.UseVisualStyleBackColor = true;
			label36.AutoSize = true;
			label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label36.Location = new System.Drawing.Point(252, 166);
			label36.Name = "label36";
			label36.Size = new System.Drawing.Size(139, 18);
			label36.TabIndex = 0;
			label36.Text = "Delay QRcode 2FA:";
			chk2FA.AutoSize = true;
			chk2FA.Location = new System.Drawing.Point(16, 166);
			chk2FA.Name = "chk2FA";
			chk2FA.Size = new System.Drawing.Size(209, 22);
			chk2FA.TabIndex = 3;
			chk2FA.Text = "Bật bảo mật 2 lớp (2FA)";
			chk2FA.UseVisualStyleBackColor = true;
			chkRandomPass.AutoSize = true;
			chkRandomPass.Location = new System.Drawing.Point(172, 81);
			chkRandomPass.Name = "chkRandomPass";
			chkRandomPass.Size = new System.Drawing.Size(114, 22);
			chkRandomPass.TabIndex = 3;
			chkRandomPass.Text = "Ngẫu nhiên";
			chkRandomPass.UseVisualStyleBackColor = true;
			chkRandomPass.CheckedChanged += new System.EventHandler(ckCheckIP_CheckedChanged);
			label14.AutoSize = true;
			label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label14.Location = new System.Drawing.Point(13, 122);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(66, 18);
			label14.TabIndex = 1;
			label14.Text = "Giới tính:";
			label13.AutoSize = true;
			label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label13.Location = new System.Drawing.Point(13, 57);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(144, 18);
			label13.TabIndex = 1;
			label13.Text = "Mật khẩu Facebook:";
			txtPassFb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPassFb.Location = new System.Drawing.Point(171, 53);
			txtPassFb.Name = "txtPassFb";
			txtPassFb.Size = new System.Drawing.Size(143, 24);
			txtPassFb.TabIndex = 2;
			label43.AutoSize = true;
			label43.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label43.Location = new System.Drawing.Point(422, 24);
			label43.Name = "label43";
			label43.Size = new System.Drawing.Size(32, 18);
			label43.TabIndex = 1;
			label43.Text = "đến";
			label41.AutoSize = true;
			label41.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label41.Location = new System.Drawing.Point(291, 24);
			label41.Name = "label41";
			label41.Size = new System.Drawing.Size(60, 18);
			label41.TabIndex = 1;
			label41.Text = "Độ tuổi:";
			label12.AutoSize = true;
			label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label12.Location = new System.Drawing.Point(13, 27);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(92, 18);
			label12.TabIndex = 1;
			label12.Text = "Tên đăng ký:";
			cbNameReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbNameReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbNameReg.FormattingEnabled = true;
			cbNameReg.Items.AddRange(new object[3] { "Tên Việt", "Tên nước ngoài", "Thailand" });
			cbNameReg.Location = new System.Drawing.Point(119, 21);
			cbNameReg.Name = "cbNameReg";
			cbNameReg.Size = new System.Drawing.Size(154, 26);
			cbNameReg.TabIndex = 2;
			groupBox6.Controls.Add(panel2);
			groupBox6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox6.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox6.Location = new System.Drawing.Point(598, 284);
			groupBox6.Name = "groupBox6";
			groupBox6.Size = new System.Drawing.Size(547, 525);
			groupBox6.TabIndex = 0;
			groupBox6.TabStop = false;
			groupBox6.Text = "Cấu hình xác minh";
			panel2.AutoScroll = true;
			panel2.Controls.Add(tabMailVeri);
			panel2.Controls.Add(plNovery);
			panel2.Controls.Add(plVeriPhone);
			panel2.Controls.Add(rdThuePhone);
			panel2.Controls.Add(rdNoVeri);
			panel2.Controls.Add(rdConfMail);
			panel2.Controls.Add(cbbPrePhone);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(3, 20);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(541, 502);
			panel2.TabIndex = 7;
			tabMailVeri.Controls.Add(tabPage6);
			tabMailVeri.Controls.Add(tabPage7);
			tabMailVeri.Location = new System.Drawing.Point(10, 251);
			tabMailVeri.Name = "tabMailVeri";
			tabMailVeri.SelectedIndex = 0;
			tabMailVeri.Size = new System.Drawing.Size(522, 248);
			tabMailVeri.TabIndex = 6;
			tabPage6.Controls.Add(plVeriMail);
			tabPage6.Location = new System.Drawing.Point(4, 27);
			tabPage6.Name = "tabPage6";
			tabPage6.Padding = new System.Windows.Forms.Padding(3);
			tabPage6.Size = new System.Drawing.Size(514, 217);
			tabPage6.TabIndex = 0;
			tabPage6.Text = "Hotmail";
			tabPage6.UseVisualStyleBackColor = true;
			plVeriMail.AutoScroll = true;
			plVeriMail.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVeriMail.Controls.Add(plHotmailReg);
			plVeriMail.Controls.Add(btnNhapHotmail);
			plVeriMail.Controls.Add(rdHotMailReg);
			plVeriMail.Controls.Add(rdHotMailRegisted);
			plVeriMail.Dock = System.Windows.Forms.DockStyle.Fill;
			plVeriMail.Location = new System.Drawing.Point(3, 3);
			plVeriMail.Name = "plVeriMail";
			plVeriMail.Size = new System.Drawing.Size(508, 211);
			plVeriMail.TabIndex = 3;
			plHotmailReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plHotmailReg.Controls.Add(btnCheckAPIAny);
			plHotmailReg.Controls.Add(txtPassmail);
			plHotmailReg.Controls.Add(txtAPIAnyCat);
			plHotmailReg.Controls.Add(label22);
			plHotmailReg.Controls.Add(ckRdPassmail);
			plHotmailReg.Controls.Add(chkHideBrowser);
			plHotmailReg.Controls.Add(ckTaoMailBox);
			plHotmailReg.Controls.Add(label19);
			plHotmailReg.Location = new System.Drawing.Point(31, 29);
			plHotmailReg.Name = "plHotmailReg";
			plHotmailReg.Size = new System.Drawing.Size(434, 140);
			plHotmailReg.TabIndex = 4;
			btnCheckAPIAny.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCheckAPIAny.Location = new System.Drawing.Point(320, 2);
			btnCheckAPIAny.Name = "btnCheckAPIAny";
			btnCheckAPIAny.Size = new System.Drawing.Size(111, 45);
			btnCheckAPIAny.TabIndex = 3;
			btnCheckAPIAny.Text = "Kiểm tra";
			btnCheckAPIAny.UseVisualStyleBackColor = true;
			btnCheckAPIAny.Click += new System.EventHandler(btnCheckAPIAny_Click);
			txtPassmail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtPassmail.Location = new System.Drawing.Point(145, 82);
			txtPassmail.Name = "txtPassmail";
			txtPassmail.Size = new System.Drawing.Size(151, 24);
			txtPassmail.TabIndex = 2;
			txtAPIAnyCat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAPIAnyCat.Location = new System.Drawing.Point(145, 12);
			txtAPIAnyCat.Name = "txtAPIAnyCat";
			txtAPIAnyCat.Size = new System.Drawing.Size(151, 24);
			txtAPIAnyCat.TabIndex = 2;
			label22.AutoSize = true;
			label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label22.Location = new System.Drawing.Point(4, 85);
			label22.Name = "label22";
			label22.Size = new System.Drawing.Size(104, 18);
			label22.TabIndex = 0;
			label22.Text = "Mật khẩu mail:";
			ckRdPassmail.AutoSize = true;
			ckRdPassmail.Location = new System.Drawing.Point(302, 84);
			ckRdPassmail.Name = "ckRdPassmail";
			ckRdPassmail.Size = new System.Drawing.Size(93, 22);
			ckRdPassmail.TabIndex = 3;
			ckRdPassmail.Text = "Random";
			ckRdPassmail.UseVisualStyleBackColor = true;
			ckRdPassmail.CheckedChanged += new System.EventHandler(ckCheckIP_CheckedChanged);
			chkHideBrowser.AutoSize = true;
			chkHideBrowser.Location = new System.Drawing.Point(7, 112);
			chkHideBrowser.Name = "chkHideBrowser";
			chkHideBrowser.Size = new System.Drawing.Size(132, 22);
			chkHideBrowser.TabIndex = 3;
			chkHideBrowser.Text = "Ẩn trình duyệt";
			chkHideBrowser.UseVisualStyleBackColor = true;
			ckTaoMailBox.AutoSize = true;
			ckTaoMailBox.Location = new System.Drawing.Point(7, 48);
			ckTaoMailBox.Name = "ckTaoMailBox";
			ckTaoMailBox.Size = new System.Drawing.Size(338, 22);
			ckTaoMailBox.TabIndex = 3;
			ckTaoMailBox.Text = "Tự động tạo Mailbox (Hotmail + Outlook)";
			ckTaoMailBox.UseVisualStyleBackColor = true;
			ckTaoMailBox.CheckedChanged += new System.EventHandler(chkWStory_CheckedChanged);
			label19.AutoSize = true;
			label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label19.Location = new System.Drawing.Point(4, 15);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(114, 18);
			label19.TabIndex = 0;
			label19.Text = "API Anycaptcha:";
			btnNhapHotmail.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnNhapHotmail.Location = new System.Drawing.Point(187, 175);
			btnNhapHotmail.Name = "btnNhapHotmail";
			btnNhapHotmail.Size = new System.Drawing.Size(178, 37);
			btnNhapHotmail.TabIndex = 3;
			btnNhapHotmail.Text = "Nhập Hotmail";
			btnNhapHotmail.UseVisualStyleBackColor = true;
			btnNhapHotmail.Click += new System.EventHandler(btnNhapHotmail_Click);
			rdHotMailReg.AutoSize = true;
			rdHotMailReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdHotMailReg.Location = new System.Drawing.Point(10, 7);
			rdHotMailReg.Name = "rdHotMailReg";
			rdHotMailReg.Size = new System.Drawing.Size(198, 22);
			rdHotMailReg.TabIndex = 1;
			rdHotMailReg.TabStop = true;
			rdHotMailReg.Text = "Hotmail (tự động đăng ký)";
			rdHotMailReg.UseVisualStyleBackColor = true;
			rdHotMailReg.CheckedChanged += new System.EventHandler(rdHotMailReg_CheckedChanged);
			rdHotMailRegisted.AutoSize = true;
			rdHotMailRegisted.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdHotMailRegisted.Location = new System.Drawing.Point(10, 185);
			rdHotMailRegisted.Name = "rdHotMailRegisted";
			rdHotMailRegisted.Size = new System.Drawing.Size(155, 22);
			rdHotMailRegisted.TabIndex = 1;
			rdHotMailRegisted.TabStop = true;
			rdHotMailRegisted.Text = "Hotmail đã đăng ký";
			rdHotMailRegisted.UseVisualStyleBackColor = true;
			rdHotMailRegisted.CheckedChanged += new System.EventHandler(rdHotMailRegisted_CheckedChanged);
			tabPage7.Controls.Add(pnlTemmail);
			tabPage7.Location = new System.Drawing.Point(4, 27);
			tabPage7.Name = "tabPage7";
			tabPage7.Padding = new System.Windows.Forms.Padding(3);
			tabPage7.Size = new System.Drawing.Size(514, 217);
			tabPage7.TabIndex = 1;
			tabPage7.Text = "TempMail";
			tabPage7.UseVisualStyleBackColor = true;
			pnlTemmail.Controls.Add(lnkMailTM);
			pnlTemmail.Controls.Add(rdMailTM);
			pnlTemmail.Controls.Add(lnkTempMailIO);
			pnlTemmail.Controls.Add(rdTempMailIO);
			pnlTemmail.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlTemmail.Location = new System.Drawing.Point(3, 3);
			pnlTemmail.Name = "pnlTemmail";
			pnlTemmail.Size = new System.Drawing.Size(508, 211);
			pnlTemmail.TabIndex = 0;
			lnkMailTM.AutoSize = true;
			lnkMailTM.Location = new System.Drawing.Point(159, 41);
			lnkMailTM.Name = "lnkMailTM";
			lnkMailTM.Size = new System.Drawing.Size(137, 18);
			lnkMailTM.TabIndex = 165;
			lnkMailTM.TabStop = true;
			lnkMailTM.Text = "https://mail.tm/vi/";
			lnkMailTM.Visible = false;
			rdMailTM.AutoSize = true;
			rdMailTM.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdMailTM.Location = new System.Drawing.Point(11, 39);
			rdMailTM.Name = "rdMailTM";
			rdMailTM.Size = new System.Drawing.Size(84, 22);
			rdMailTM.TabIndex = 164;
			rdMailTM.Text = "Mail.tm";
			rdMailTM.UseVisualStyleBackColor = true;
			rdMailTM.Visible = false;
			rdMailTM.CheckedChanged += new System.EventHandler(rdMailTM_CheckedChanged);
			lnkTempMailIO.AutoSize = true;
			lnkTempMailIO.Location = new System.Drawing.Point(159, 13);
			lnkTempMailIO.Name = "lnkTempMailIO";
			lnkTempMailIO.Size = new System.Drawing.Size(158, 18);
			lnkTempMailIO.TabIndex = 159;
			lnkTempMailIO.TabStop = true;
			lnkTempMailIO.Text = "https://temp-mail.io/";
			lnkTempMailIO.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkTempMailIO_LinkClicked);
			rdTempMailIO.AutoSize = true;
			rdTempMailIO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdTempMailIO.Location = new System.Drawing.Point(11, 11);
			rdTempMailIO.Name = "rdTempMailIO";
			rdTempMailIO.Size = new System.Drawing.Size(127, 22);
			rdTempMailIO.TabIndex = 158;
			rdTempMailIO.Text = "Temp-Mail.io";
			rdTempMailIO.UseVisualStyleBackColor = true;
			rdTempMailIO.CheckedChanged += new System.EventHandler(rdTempMailIO_CheckedChanged);
			plNovery.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plNovery.Controls.Add(rdNoveriMail);
			plNovery.Controls.Add(rdNovriPhone);
			plNovery.Controls.Add(label18);
			plNovery.Controls.Add(txtListDauso);
			plNovery.Controls.Add(label17);
			plNovery.Controls.Add(cbMailAo);
			plNovery.Controls.Add(cbbPhoneCountry);
			plNovery.Location = new System.Drawing.Point(10, 36);
			plNovery.Name = "plNovery";
			plNovery.Size = new System.Drawing.Size(522, 74);
			plNovery.TabIndex = 5;
			rdNoveriMail.AutoSize = true;
			rdNoveriMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdNoveriMail.Location = new System.Drawing.Point(6, 41);
			rdNoveriMail.Name = "rdNoveriMail";
			rdNoveriMail.Size = new System.Drawing.Size(77, 22);
			rdNoveriMail.TabIndex = 1;
			rdNoveriMail.Text = "Mail ảo";
			rdNoveriMail.UseVisualStyleBackColor = true;
			rdNovriPhone.AutoSize = true;
			rdNovriPhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdNovriPhone.Location = new System.Drawing.Point(6, 3);
			rdNovriPhone.Name = "rdNovriPhone";
			rdNovriPhone.Size = new System.Drawing.Size(93, 22);
			rdNovriPhone.TabIndex = 1;
			rdNovriPhone.Text = "Phone ảo";
			rdNovriPhone.UseVisualStyleBackColor = true;
			label18.AutoSize = true;
			label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label18.Location = new System.Drawing.Point(96, 43);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(81, 18);
			label18.TabIndex = 0;
			label18.Text = "Loại mail:";
			txtListDauso.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtListDauso.Location = new System.Drawing.Point(348, 2);
			txtListDauso.Name = "txtListDauso";
			txtListDauso.Size = new System.Drawing.Size(166, 24);
			txtListDauso.TabIndex = 2;
			label17.AutoSize = true;
			label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label17.Location = new System.Drawing.Point(115, 5);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(81, 18);
			label17.TabIndex = 0;
			label17.Text = "Quốc gia:";
			cbMailAo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbMailAo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbMailAo.FormattingEnabled = true;
			cbMailAo.Items.AddRange(new object[4] { "Gmail", "Yahoo", "Hotmail", "Temp-mail.io" });
			cbMailAo.Location = new System.Drawing.Point(194, 38);
			cbMailAo.Name = "cbMailAo";
			cbMailAo.Size = new System.Drawing.Size(114, 26);
			cbMailAo.TabIndex = 2;
			cbbPhoneCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbPhoneCountry.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbPhoneCountry.FormattingEnabled = true;
			cbbPhoneCountry.Items.AddRange(new object[217]
			{
				"Afghanistan", "Albania", "Algeria", "American Samoa", "Andorra", "Angola", "Anguilla", "Antigua & Barbuda", "Argentina", "Armenia",
				"Aruba", "Australia (Úc)", "Austria (Áo)", "Azerbaijan", "Bahamas", "Bahrain", "Bangladesh", "Barbados", "Belarus", "Bỉ",
				"Belize", "Benin", "Bermuda", "Bhutan", "Bolivia", "Bosnia & Herzegovina", "Botswana", "Brazil", "Brunei Darussalam", "Bulgaria",
				"Burkina Faso", "Burundi", "Cambodia (Campuchia)", "Cameroon", "Canada", "Cape Verde", "Cayman Islands", "Central African Republic", "Chad", "Chagos Archipelago",
				"Chile", "China (Trung Quốc)", "Colombia", "Comoros", "Congo", "Congo, Dem. Rep. of", "Cook Islands", "Costa Rica", "Côte d’lvoire", "Croatia",
				"Cuba", "Czech Republic (Séc)", "Denmark (Đan Mạch)", "Djibouti", "Dominica", "Cyprus", "Ecuador", "Egypt (DST", "El Salvador", "Equatorial Guinea",
				"Estonia", "Ethiopia", "Faeroe Islands", "Falkland Islands", "Fiji", "Finland (Phần Lan)", "France (Pháp)", "French Antilles", "French Guiana", "French Polynesia††",
				"Gabon", "Gambia", "Georgia", "Germany (Đức)", "Ghana", "Gibraltar", "Greece (Hy Lạp)", "Greenland", "Grenada", "Guadeloupe",
				"Guam", "Guatemala", "Guinea", "Guinea-Bissau", "Guyana", "Haiti", "Honduras", "Hong Kong", "Hungary", "Iceland",
				"India (Ấn Độ)", "Indonesia", "Iran", "Iraq", "Ireland", "Israel", "Italy", "Ivory Coast", "Jamaica", "Japan (Nhật Bản)",
				"Jordan", "Kenya", "Korea, North (Hàn Quốc)", "Korea, South (Triều Tiên)", "Kuwait", "Kyrgyzstan", "Zambia", "Zimbabwe", "Laos (Lào)", "Latvia",
				"Lebanon", "Lesotho", "Liberia", "Libya", "Liechtenstein", "Lithuania", "Luxembourg", "Macau", "Macedonia", "Madagascar",
				"Malawi", "Malaysia", "Maldives", "Mali", "Malta", "Marshall Islands", "Martinique", "Mauritania", "Mauritius", "Mexico",
				"Midway Islands", "Moldova", "Monaco", "Mongolia", "Montenegro & Serbia", "Montserrat", "Morocco", "Mozambique", "Myanmar (Burma)", "Namibia",
				"Nepal", "Netherlands", "Netherlands Antilles", "New Caledonia", "New Zealand", "Nicaragua", "Niger Republic", "Nigeria", "Northern Mariana Isl.", "Norway",
				"Oman", "Pakistan", "Palau", "Panama", "Papua New Guinea", "Paraguay", "Peru", "Philippines", "Poland (Ba Lan)", "Portugal (Bồ Đào Nha)",
				"Qatar", "Reunion Island", "Romania", "Russia (Nga)", "Rwanda", "San Marino", "Sใo Tom\u0e49 & Principe", "Saudi Arabia", "Senegal", "Seychelles",
				"Sierra Leone", "Singapore", "Slovak Republic", "Slovenia", "Solomon Islands", "Somalia", "South Africa (Nam Phi)", "Spain (Tây Ban Nha)", "Sri Lanka", "St. Kitts & Nevis",
				"St. Lucia", "St. Vincents & Grenadines", "Sudan", "Suriname", "Swaziland", "Sweden (Thụy Điển)", "Switzerland (Thụy Sĩ)", "Syria", "Taiwan (Đài Loan)", "Tajikistan",
				"Tanzania", "Thái Lan", "Togo", "Tonga", "Trinidad & Tobago", "Tunisia", "Turkey (Thổ Nhĩ Kì)", "Turkmenistan", "Turks & Caicos Islands", "Tuvalu",
				"Uganda", "Ukraine", "United Arab Emirates (Ả Rập)", "United Kingdom (Vương Quốc Anh)", "United States (Mỹ)", "Uruguay", "Uzbekistan", "Vanuatu", "Venezuela", "Vietnam",
				"Virgin Islands, British", "Virgin Islands, U.S.", "Western Samoa", "Yemen", "Yugoslavia", "Zaire", "Serbia"
			});
			cbbPhoneCountry.Location = new System.Drawing.Point(206, 2);
			cbbPhoneCountry.Name = "cbbPhoneCountry";
			cbbPhoneCountry.Size = new System.Drawing.Size(136, 26);
			cbbPhoneCountry.TabIndex = 2;
			cbbPhoneCountry.SelectedIndexChanged += new System.EventHandler(cbbPhoneCountry_SelectedIndexChanged);
			plVeriPhone.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plVeriPhone.Controls.Add(btnCheckSim);
			plVeriPhone.Controls.Add(label9);
			plVeriPhone.Controls.Add(label10);
			plVeriPhone.Controls.Add(cbDvSim);
			plVeriPhone.Controls.Add(txtAPISim);
			plVeriPhone.Location = new System.Drawing.Point(10, 141);
			plVeriPhone.Name = "plVeriPhone";
			plVeriPhone.Size = new System.Drawing.Size(522, 78);
			plVeriPhone.TabIndex = 4;
			btnCheckSim.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCheckSim.Location = new System.Drawing.Point(407, 27);
			btnCheckSim.Name = "btnCheckSim";
			btnCheckSim.Size = new System.Drawing.Size(100, 45);
			btnCheckSim.TabIndex = 3;
			btnCheckSim.Text = "Kiểm tra";
			btnCheckSim.UseVisualStyleBackColor = true;
			btnCheckSim.Click += new System.EventHandler(btnCheckSim_Click);
			label9.AutoSize = true;
			label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label9.Location = new System.Drawing.Point(3, 9);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(126, 18);
			label9.TabIndex = 0;
			label9.Text = "Chọn dịch vụ sim:";
			label10.AutoSize = true;
			label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label10.Location = new System.Drawing.Point(3, 43);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(34, 18);
			label10.TabIndex = 0;
			label10.Text = "API:";
			cbDvSim.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbDvSim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbDvSim.FormattingEnabled = true;
			cbDvSim.Items.AddRange(new object[7] { "chothuesimcode - 1000đ/sms", "viotp - 1100đ/sms", "codetextnow - 450đ/sms", "otpmmo - 450đ/sms", "primeotp - 450đ/sms", "tempsms.co - 900đ/sms", "rabbitotp - 450đ/sms" });
			cbDvSim.Location = new System.Drawing.Point(151, 5);
			cbDvSim.Name = "cbDvSim";
			cbDvSim.Size = new System.Drawing.Size(233, 26);
			cbDvSim.TabIndex = 2;
			txtAPISim.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtAPISim.Location = new System.Drawing.Point(59, 39);
			txtAPISim.Name = "txtAPISim";
			txtAPISim.Size = new System.Drawing.Size(325, 24);
			txtAPISim.TabIndex = 2;
			rdThuePhone.AutoSize = true;
			rdThuePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdThuePhone.Location = new System.Drawing.Point(10, 116);
			rdThuePhone.Name = "rdThuePhone";
			rdThuePhone.Size = new System.Drawing.Size(150, 22);
			rdThuePhone.TabIndex = 1;
			rdThuePhone.Text = "Thuê số điện thoại";
			rdThuePhone.UseVisualStyleBackColor = true;
			rdThuePhone.CheckedChanged += new System.EventHandler(rdThuePhone_CheckedChanged);
			rdNoVeri.AutoSize = true;
			rdNoVeri.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdNoVeri.Location = new System.Drawing.Point(10, 7);
			rdNoVeri.Name = "rdNoVeri";
			rdNoVeri.Size = new System.Drawing.Size(135, 22);
			rdNoVeri.TabIndex = 1;
			rdNoVeri.Text = "Không xác minh";
			rdNoVeri.UseVisualStyleBackColor = true;
			rdNoVeri.CheckedChanged += new System.EventHandler(rdNoVeri_CheckedChanged);
			rdConfMail.AutoSize = true;
			rdConfMail.Checked = true;
			rdConfMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdConfMail.Location = new System.Drawing.Point(10, 224);
			rdConfMail.Name = "rdConfMail";
			rdConfMail.Size = new System.Drawing.Size(150, 22);
			rdConfMail.TabIndex = 1;
			rdConfMail.TabStop = true;
			rdConfMail.Text = "Xác minh qua mail";
			rdConfMail.UseVisualStyleBackColor = true;
			rdConfMail.CheckedChanged += new System.EventHandler(rdConfMail_CheckedChanged);
			cbbPrePhone.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbPrePhone.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbPrePhone.FormattingEnabled = true;
			cbbPrePhone.Items.AddRange(new object[2] { "VN", "USA" });
			cbbPrePhone.Location = new System.Drawing.Point(418, 0);
			cbbPrePhone.Name = "cbbPrePhone";
			cbbPrePhone.Size = new System.Drawing.Size(89, 26);
			cbbPrePhone.TabIndex = 2;
			cbbPrePhone.Visible = false;
			cbbPrePhone.SelectedIndexChanged += new System.EventHandler(cbbPrePhone_SelectedIndexChanged);
			groupBox8.Controls.Add(pnlTuongTac);
			groupBox8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox8.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox8.Location = new System.Drawing.Point(598, 817);
			groupBox8.Name = "groupBox8";
			groupBox8.Size = new System.Drawing.Size(547, 133);
			groupBox8.TabIndex = 0;
			groupBox8.TabStop = false;
			groupBox8.Text = "Tương tác sau khi reg thành công";
			pnlTuongTac.AutoScroll = true;
			pnlTuongTac.Controls.Add(gbCamxuc);
			pnlTuongTac.Controls.Add(plAddfriend);
			pnlTuongTac.Controls.Add(chkInNewfeed);
			pnlTuongTac.Controls.Add(chkWatch);
			pnlTuongTac.Controls.Add(chkWStory);
			pnlTuongTac.Controls.Add(chkAddFUID);
			pnlTuongTac.Controls.Add(chkReadNotifi);
			pnlTuongTac.Dock = System.Windows.Forms.DockStyle.Fill;
			pnlTuongTac.Location = new System.Drawing.Point(3, 20);
			pnlTuongTac.Name = "pnlTuongTac";
			pnlTuongTac.Size = new System.Drawing.Size(541, 110);
			pnlTuongTac.TabIndex = 6;
			gbCamxuc.Controls.Add(chkGian);
			gbCamxuc.Controls.Add(chkBuon);
			gbCamxuc.Controls.Add(chkHaha);
			gbCamxuc.Controls.Add(chkTym);
			gbCamxuc.Controls.Add(chkLike);
			gbCamxuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			gbCamxuc.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			gbCamxuc.Location = new System.Drawing.Point(142, 64);
			gbCamxuc.Name = "gbCamxuc";
			gbCamxuc.Size = new System.Drawing.Size(351, 44);
			gbCamxuc.TabIndex = 12;
			gbCamxuc.TabStop = false;
			gbCamxuc.Text = "Cảm xúc";
			chkGian.AutoSize = true;
			chkGian.Location = new System.Drawing.Point(276, 22);
			chkGian.Name = "chkGian";
			chkGian.Size = new System.Drawing.Size(61, 22);
			chkGian.TabIndex = 3;
			chkGian.Text = "Giận";
			chkGian.UseVisualStyleBackColor = true;
			chkBuon.AutoSize = true;
			chkBuon.Location = new System.Drawing.Point(203, 22);
			chkBuon.Name = "chkBuon";
			chkBuon.Size = new System.Drawing.Size(65, 22);
			chkBuon.TabIndex = 3;
			chkBuon.Text = "Buồn";
			chkBuon.UseVisualStyleBackColor = true;
			chkHaha.AutoSize = true;
			chkHaha.Location = new System.Drawing.Point(135, 22);
			chkHaha.Name = "chkHaha";
			chkHaha.Size = new System.Drawing.Size(65, 22);
			chkHaha.TabIndex = 3;
			chkHaha.Text = "Haha";
			chkHaha.UseVisualStyleBackColor = true;
			chkTym.AutoSize = true;
			chkTym.Location = new System.Drawing.Point(72, 23);
			chkTym.Name = "chkTym";
			chkTym.Size = new System.Drawing.Size(59, 22);
			chkTym.TabIndex = 3;
			chkTym.Text = "Tym";
			chkTym.UseVisualStyleBackColor = true;
			chkLike.AutoSize = true;
			chkLike.Location = new System.Drawing.Point(12, 23);
			chkLike.Name = "chkLike";
			chkLike.Size = new System.Drawing.Size(57, 22);
			chkLike.TabIndex = 3;
			chkLike.Text = "Like";
			chkLike.UseVisualStyleBackColor = true;
			plAddfriend.Controls.Add(nFriendTo);
			plAddfriend.Controls.Add(label25);
			plAddfriend.Controls.Add(nFriendFrom);
			plAddfriend.Controls.Add(label26);
			plAddfriend.Controls.Add(label27);
			plAddfriend.Location = new System.Drawing.Point(217, 25);
			plAddfriend.Name = "plAddfriend";
			plAddfriend.Size = new System.Drawing.Size(300, 33);
			plAddfriend.TabIndex = 11;
			nFriendTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nFriendTo.Location = new System.Drawing.Point(194, 9);
			nFriendTo.Name = "nFriendTo";
			nFriendTo.Size = new System.Drawing.Size(55, 24);
			nFriendTo.TabIndex = 1;
			label25.AutoSize = true;
			label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label25.Location = new System.Drawing.Point(8, 11);
			label25.Name = "label25";
			label25.Size = new System.Drawing.Size(71, 18);
			label25.TabIndex = 0;
			label25.Text = "Số lượng:";
			nFriendFrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nFriendFrom.Location = new System.Drawing.Point(88, 9);
			nFriendFrom.Name = "nFriendFrom";
			nFriendFrom.Size = new System.Drawing.Size(55, 24);
			nFriendFrom.TabIndex = 1;
			label26.AutoSize = true;
			label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label26.Location = new System.Drawing.Point(153, 11);
			label26.Name = "label26";
			label26.Size = new System.Drawing.Size(32, 18);
			label26.TabIndex = 0;
			label26.Text = "đến";
			label27.AutoSize = true;
			label27.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label27.Location = new System.Drawing.Point(258, 11);
			label27.Name = "label27";
			label27.Size = new System.Drawing.Size(32, 18);
			label27.TabIndex = 0;
			label27.Text = "bạn";
			chkInNewfeed.AutoSize = true;
			chkInNewfeed.Location = new System.Drawing.Point(16, 30);
			chkInNewfeed.Name = "chkInNewfeed";
			chkInNewfeed.Size = new System.Drawing.Size(175, 22);
			chkInNewfeed.TabIndex = 6;
			chkInNewfeed.Text = "Tương tác Newfeed";
			chkInNewfeed.UseVisualStyleBackColor = true;
			chkWatch.AutoSize = true;
			chkWatch.Location = new System.Drawing.Point(16, 59);
			chkWatch.Name = "chkWatch";
			chkWatch.Size = new System.Drawing.Size(117, 22);
			chkWatch.TabIndex = 7;
			chkWatch.Text = "Xem Watch";
			chkWatch.UseVisualStyleBackColor = true;
			chkWStory.AutoSize = true;
			chkWStory.Location = new System.Drawing.Point(16, 91);
			chkWStory.Name = "chkWStory";
			chkWStory.Size = new System.Drawing.Size(109, 22);
			chkWStory.TabIndex = 8;
			chkWStory.Text = "Xem Story";
			chkWStory.UseVisualStyleBackColor = true;
			chkWStory.CheckedChanged += new System.EventHandler(chkWStory_CheckedChanged);
			chkAddFUID.AutoSize = true;
			chkAddFUID.Location = new System.Drawing.Point(227, 3);
			chkAddFUID.Name = "chkAddFUID";
			chkAddFUID.Size = new System.Drawing.Size(128, 22);
			chkAddFUID.TabIndex = 9;
			chkAddFUID.Text = "Kết bạn gợi ý";
			chkAddFUID.UseVisualStyleBackColor = true;
			chkReadNotifi.AutoSize = true;
			chkReadNotifi.Location = new System.Drawing.Point(16, 3);
			chkReadNotifi.Name = "chkReadNotifi";
			chkReadNotifi.Size = new System.Drawing.Size(141, 22);
			chkReadNotifi.TabIndex = 10;
			chkReadNotifi.Text = "Đọc thông báo";
			chkReadNotifi.UseVisualStyleBackColor = true;
			groupBox5.Controls.Add(panel5);
			groupBox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox5.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox5.Location = new System.Drawing.Point(6, 360);
			groupBox5.Name = "groupBox5";
			groupBox5.Size = new System.Drawing.Size(585, 596);
			groupBox5.TabIndex = 0;
			groupBox5.TabStop = false;
			groupBox5.Text = "Cấu hình đổi IP";
			panel5.AutoScroll = true;
			panel5.Controls.Add(tabProxy);
			panel5.Controls.Add(plCheckDoiIP);
			panel5.Controls.Add(plChangeIPDcom);
			panel5.Controls.Add(rdProxy);
			panel5.Controls.Add(rdHMA);
			panel5.Controls.Add(rdChangeIPDcom);
			panel5.Controls.Add(rdNoChangeIP);
			panel5.Location = new System.Drawing.Point(3, 20);
			panel5.Name = "panel5";
			panel5.Size = new System.Drawing.Size(579, 574);
			panel5.TabIndex = 7;
			tabProxy.Controls.Add(tabPage1);
			tabProxy.Controls.Add(tabPage2);
			tabProxy.Controls.Add(tabPage3);
			tabProxy.Controls.Add(tabPage4);
			tabProxy.Controls.Add(tabPage5);
			tabProxy.Controls.Add(tabPage8);
			tabProxy.Controls.Add(tabPage9);
			tabProxy.Location = new System.Drawing.Point(39, 198);
			tabProxy.Name = "tabProxy";
			tabProxy.SelectedIndex = 0;
			tabProxy.Size = new System.Drawing.Size(537, 372);
			tabProxy.TabIndex = 157;
			tabPage1.Controls.Add(linkLabel1);
			tabPage1.Controls.Add(plTinsoftProxy);
			tabPage1.Controls.Add(rdTinsoftProxy);
			tabPage1.Location = new System.Drawing.Point(4, 27);
			tabPage1.Name = "tabPage1";
			tabPage1.Padding = new System.Windows.Forms.Padding(3);
			tabPage1.Size = new System.Drawing.Size(529, 341);
			tabPage1.TabIndex = 0;
			tabPage1.Text = "Tinsoft";
			tabPage1.UseVisualStyleBackColor = true;
			linkLabel1.AutoSize = true;
			linkLabel1.Location = new System.Drawing.Point(186, 19);
			linkLabel1.Name = "linkLabel1";
			linkLabel1.Size = new System.Drawing.Size(191, 18);
			linkLabel1.TabIndex = 159;
			linkLabel1.TabStop = true;
			linkLabel1.Text = "https://tinsoftproxy.com/";
			linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel1_LinkClicked);
			plTinsoftProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTinsoftProxy.Controls.Add(nudLuongPerIPTinsoft);
			plTinsoftProxy.Controls.Add(btnCheckProxy);
			plTinsoftProxy.Controls.Add(label16);
			plTinsoftProxy.Controls.Add(label29);
			plTinsoftProxy.Controls.Add(label15);
			plTinsoftProxy.Controls.Add(txtProxy);
			plTinsoftProxy.Controls.Add(cbLocationProxy);
			plTinsoftProxy.Location = new System.Drawing.Point(19, 45);
			plTinsoftProxy.Name = "plTinsoftProxy";
			plTinsoftProxy.Size = new System.Drawing.Size(452, 109);
			plTinsoftProxy.TabIndex = 158;
			nudLuongPerIPTinsoft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			nudLuongPerIPTinsoft.Location = new System.Drawing.Point(285, 58);
			nudLuongPerIPTinsoft.Name = "nudLuongPerIPTinsoft";
			nudLuongPerIPTinsoft.Size = new System.Drawing.Size(55, 24);
			nudLuongPerIPTinsoft.TabIndex = 1;
			btnCheckProxy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnCheckProxy.Location = new System.Drawing.Point(272, 5);
			btnCheckProxy.Name = "btnCheckProxy";
			btnCheckProxy.Size = new System.Drawing.Size(101, 34);
			btnCheckProxy.TabIndex = 3;
			btnCheckProxy.Text = "Check";
			btnCheckProxy.UseVisualStyleBackColor = true;
			btnCheckProxy.Click += new System.EventHandler(btnCheckProxy_Click);
			label16.AutoSize = true;
			label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label16.Location = new System.Drawing.Point(176, 61);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(88, 18);
			label16.TabIndex = 0;
			label16.Text = "Số luồng/IP:";
			label29.AutoSize = true;
			label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label29.Location = new System.Drawing.Point(5, 13);
			label29.Name = "label29";
			label29.Size = new System.Drawing.Size(94, 18);
			label29.TabIndex = 6;
			label29.Text = "API key user:";
			label15.AutoSize = true;
			label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label15.Location = new System.Drawing.Point(5, 61);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(40, 18);
			label15.TabIndex = 0;
			label15.Text = "Vị trí:";
			txtProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtProxy.Location = new System.Drawing.Point(108, 10);
			txtProxy.Name = "txtProxy";
			txtProxy.Size = new System.Drawing.Size(149, 24);
			txtProxy.TabIndex = 2;
			cbLocationProxy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbLocationProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbLocationProxy.FormattingEnabled = true;
			cbLocationProxy.Location = new System.Drawing.Point(50, 58);
			cbLocationProxy.Name = "cbLocationProxy";
			cbLocationProxy.Size = new System.Drawing.Size(110, 26);
			cbLocationProxy.TabIndex = 2;
			rdTinsoftProxy.AutoSize = true;
			rdTinsoftProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdTinsoftProxy.Location = new System.Drawing.Point(22, 17);
			rdTinsoftProxy.Name = "rdTinsoftProxy";
			rdTinsoftProxy.Size = new System.Drawing.Size(134, 22);
			rdTinsoftProxy.TabIndex = 157;
			rdTinsoftProxy.Text = "Proxy Tinsoft:";
			rdTinsoftProxy.UseVisualStyleBackColor = true;
			rdTinsoftProxy.CheckedChanged += new System.EventHandler(rdTinsoftProxy_CheckedChanged);
			tabPage2.Controls.Add(linkLabel2);
			tabPage2.Controls.Add(pnlAPIMinProxy);
			tabPage2.Controls.Add(rdMinProxy);
			tabPage2.Location = new System.Drawing.Point(4, 27);
			tabPage2.Name = "tabPage2";
			tabPage2.Padding = new System.Windows.Forms.Padding(3);
			tabPage2.Size = new System.Drawing.Size(529, 341);
			tabPage2.TabIndex = 1;
			tabPage2.Text = "MinProxy - IPV6 động";
			tabPage2.UseVisualStyleBackColor = true;
			linkLabel2.AutoSize = true;
			linkLabel2.Location = new System.Drawing.Point(311, 16);
			linkLabel2.Name = "linkLabel2";
			linkLabel2.Size = new System.Drawing.Size(155, 18);
			linkLabel2.TabIndex = 159;
			linkLabel2.TabStop = true;
			linkLabel2.Text = "https://minproxy.vn/";
			linkLabel2.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel2_LinkClicked);
			pnlAPIMinProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlAPIMinProxy.Controls.Add(btnCheckAPIMinProxy);
			pnlAPIMinProxy.Controls.Add(txtApiKeyMinProxy);
			pnlAPIMinProxy.Controls.Add(lblAPIMinKey);
			pnlAPIMinProxy.Controls.Add(label32);
			pnlAPIMinProxy.Controls.Add(label50);
			pnlAPIMinProxy.Controls.Add(nudLuongPerIPMinProxy);
			pnlAPIMinProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			pnlAPIMinProxy.Location = new System.Drawing.Point(24, 46);
			pnlAPIMinProxy.Margin = new System.Windows.Forms.Padding(4);
			pnlAPIMinProxy.Name = "pnlAPIMinProxy";
			pnlAPIMinProxy.Size = new System.Drawing.Size(443, 288);
			pnlAPIMinProxy.TabIndex = 158;
			btnCheckAPIMinProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCheckAPIMinProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnCheckAPIMinProxy.ForeColor = System.Drawing.Color.Black;
			btnCheckAPIMinProxy.Location = new System.Drawing.Point(212, 209);
			btnCheckAPIMinProxy.Margin = new System.Windows.Forms.Padding(4);
			btnCheckAPIMinProxy.Name = "btnCheckAPIMinProxy";
			btnCheckAPIMinProxy.Size = new System.Drawing.Size(69, 33);
			btnCheckAPIMinProxy.TabIndex = 145;
			btnCheckAPIMinProxy.Text = "Check";
			btnCheckAPIMinProxy.UseVisualStyleBackColor = true;
			btnCheckAPIMinProxy.Click += new System.EventHandler(btnCheckAPIMinProxy_Click);
			txtApiKeyMinProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtApiKeyMinProxy.Location = new System.Drawing.Point(8, 28);
			txtApiKeyMinProxy.Margin = new System.Windows.Forms.Padding(4);
			txtApiKeyMinProxy.Name = "txtApiKeyMinProxy";
			txtApiKeyMinProxy.Size = new System.Drawing.Size(424, 171);
			txtApiKeyMinProxy.TabIndex = 144;
			txtApiKeyMinProxy.Text = "";
			txtApiKeyMinProxy.WordWrap = false;
			txtApiKeyMinProxy.TextChanged += new System.EventHandler(txtApiKeyMinProxy_TextChanged);
			lblAPIMinKey.AutoSize = true;
			lblAPIMinKey.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblAPIMinKey.Location = new System.Drawing.Point(4, 2);
			lblAPIMinKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblAPIMinKey.Name = "lblAPIMinKey";
			lblAPIMinKey.Size = new System.Drawing.Size(148, 21);
			lblAPIMinKey.TabIndex = 79;
			lblAPIMinKey.Text = "Nhập API KEY (0):";
			label32.AutoSize = true;
			label32.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label32.ForeColor = System.Drawing.Color.Red;
			label32.Location = new System.Drawing.Point(6, 255);
			label32.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label32.Name = "label32";
			label32.Size = new System.Drawing.Size(166, 21);
			label32.TabIndex = 139;
			label32.Text = "(Mỗi API key 1 dòng)";
			label50.AutoSize = true;
			label50.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label50.Location = new System.Drawing.Point(4, 213);
			label50.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label50.Name = "label50";
			label50.Size = new System.Drawing.Size(101, 21);
			label50.TabIndex = 139;
			label50.Text = "Số luồng/IP:";
			nudLuongPerIPMinProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPMinProxy.Location = new System.Drawing.Point(117, 211);
			nudLuongPerIPMinProxy.Margin = new System.Windows.Forms.Padding(4);
			nudLuongPerIPMinProxy.Name = "nudLuongPerIPMinProxy";
			nudLuongPerIPMinProxy.Size = new System.Drawing.Size(89, 27);
			nudLuongPerIPMinProxy.TabIndex = 140;
			nudLuongPerIPMinProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rdMinProxy.AutoSize = true;
			rdMinProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdMinProxy.Location = new System.Drawing.Point(24, 14);
			rdMinProxy.Name = "rdMinProxy";
			rdMinProxy.Size = new System.Drawing.Size(255, 22);
			rdMinProxy.TabIndex = 157;
			rdMinProxy.Text = "MinProxy.vn: Proxy IPV6 động";
			rdMinProxy.UseVisualStyleBackColor = true;
			rdMinProxy.CheckedChanged += new System.EventHandler(rdMinProxy_CheckedChanged);
			tabPage3.Controls.Add(pnlIpPort);
			tabPage3.Controls.Add(rdIPPortUserPass);
			tabPage3.Location = new System.Drawing.Point(4, 27);
			tabPage3.Name = "tabPage3";
			tabPage3.Padding = new System.Windows.Forms.Padding(3);
			tabPage3.Size = new System.Drawing.Size(529, 341);
			tabPage3.TabIndex = 2;
			tabPage3.Text = "Proxy có sẵn";
			tabPage3.UseVisualStyleBackColor = true;
			pnlIpPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlIpPort.Controls.Add(cbbTypeProxyIP);
			pnlIpPort.Controls.Add(label33);
			pnlIpPort.Controls.Add(label31);
			pnlIpPort.Controls.Add(rdIPDong);
			pnlIpPort.Controls.Add(rdIPStatic);
			pnlIpPort.Controls.Add(label34);
			pnlIpPort.Controls.Add(label30);
			pnlIpPort.Controls.Add(txtListProxyIp);
			pnlIpPort.Controls.Add(lblListProxyIP);
			pnlIpPort.Location = new System.Drawing.Point(10, 43);
			pnlIpPort.Name = "pnlIpPort";
			pnlIpPort.Size = new System.Drawing.Size(476, 291);
			pnlIpPort.TabIndex = 159;
			cbbTypeProxyIP.Cursor = System.Windows.Forms.Cursors.Hand;
			cbbTypeProxyIP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbbTypeProxyIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbbTypeProxyIP.FormattingEnabled = true;
			cbbTypeProxyIP.Items.AddRange(new object[2] { "HTTP và HTTPs", "Sock5" });
			cbbTypeProxyIP.Location = new System.Drawing.Point(111, 4);
			cbbTypeProxyIP.Margin = new System.Windows.Forms.Padding(4);
			cbbTypeProxyIP.Name = "cbbTypeProxyIP";
			cbbTypeProxyIP.Size = new System.Drawing.Size(171, 27);
			cbbTypeProxyIP.TabIndex = 127;
			label33.AutoSize = true;
			label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label33.ForeColor = System.Drawing.Color.Red;
			label33.Location = new System.Drawing.Point(304, 8);
			label33.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label33.Name = "label33";
			label33.Size = new System.Drawing.Size(163, 20);
			label33.TabIndex = 124;
			label33.Text = "(1 tài khoản/1 Proxy)";
			label31.AutoSize = true;
			label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label31.ForeColor = System.Drawing.Color.Red;
			label31.Location = new System.Drawing.Point(308, 63);
			label31.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label31.Name = "label31";
			label31.Size = new System.Drawing.Size(148, 20);
			label31.TabIndex = 124;
			label31.Text = "(Mỗi proxy 1 dòng)";
			rdIPDong.AutoSize = true;
			rdIPDong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdIPDong.Location = new System.Drawing.Point(166, 36);
			rdIPDong.Name = "rdIPDong";
			rdIPDong.Size = new System.Drawing.Size(69, 22);
			rdIPDong.TabIndex = 10;
			rdIPDong.TabStop = true;
			rdIPDong.Text = "Động";
			rdIPDong.UseVisualStyleBackColor = true;
			rdIPDong.CheckedChanged += new System.EventHandler(rdIPDong_CheckedChanged);
			rdIPStatic.AutoSize = true;
			rdIPStatic.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdIPStatic.Location = new System.Drawing.Point(90, 36);
			rdIPStatic.Name = "rdIPStatic";
			rdIPStatic.Size = new System.Drawing.Size(61, 22);
			rdIPStatic.TabIndex = 10;
			rdIPStatic.TabStop = true;
			rdIPStatic.Text = "Tĩnh";
			rdIPStatic.UseVisualStyleBackColor = true;
			rdIPStatic.CheckedChanged += new System.EventHandler(rdIPStatic_CheckedChanged);
			label34.AutoSize = true;
			label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label34.Location = new System.Drawing.Point(5, 38);
			label34.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label34.Name = "label34";
			label34.Size = new System.Drawing.Size(67, 20);
			label34.TabIndex = 124;
			label34.Text = "Kiểu IP:";
			label30.AutoSize = true;
			label30.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label30.Location = new System.Drawing.Point(5, 8);
			label30.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label30.Name = "label30";
			label30.Size = new System.Drawing.Size(93, 20);
			label30.TabIndex = 124;
			label30.Text = "Loa\u0323i Proxy:";
			txtListProxyIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtListProxyIp.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtListProxyIp.Location = new System.Drawing.Point(9, 90);
			txtListProxyIp.Margin = new System.Windows.Forms.Padding(4);
			txtListProxyIp.Name = "txtListProxyIp";
			txtListProxyIp.Size = new System.Drawing.Size(453, 218);
			txtListProxyIp.TabIndex = 119;
			txtListProxyIp.Text = "";
			txtListProxyIp.WordWrap = false;
			txtListProxyIp.TextChanged += new System.EventHandler(txtListProxyIp_TextChanged);
			lblListProxyIP.AutoSize = true;
			lblListProxyIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			lblListProxyIP.Location = new System.Drawing.Point(5, 63);
			lblListProxyIP.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblListProxyIP.Name = "lblListProxyIP";
			lblListProxyIP.Size = new System.Drawing.Size(168, 20);
			lblListProxyIP.TabIndex = 7;
			lblListProxyIP.Text = "Danh sa\u0301ch Proxy (0):";
			rdIPPortUserPass.AutoSize = true;
			rdIPPortUserPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			rdIPPortUserPass.Location = new System.Drawing.Point(19, 15);
			rdIPPortUserPass.Name = "rdIPPortUserPass";
			rdIPPortUserPass.Size = new System.Drawing.Size(301, 22);
			rdIPPortUserPass.TabIndex = 158;
			rdIPPortUserPass.Text = "IP:Port hoặc IP:Port:User:Password";
			rdIPPortUserPass.UseVisualStyleBackColor = true;
			rdIPPortUserPass.CheckedChanged += new System.EventHandler(rdIPPortUserPass_CheckedChanged);
			tabPage4.Controls.Add(panel1);
			tabPage4.Location = new System.Drawing.Point(4, 27);
			tabPage4.Name = "tabPage4";
			tabPage4.Padding = new System.Windows.Forms.Padding(3);
			tabPage4.Size = new System.Drawing.Size(529, 341);
			tabPage4.TabIndex = 3;
			tabPage4.Text = "Xproxy, Mobi, OBC, Eager, S Proxy";
			tabPage4.UseVisualStyleBackColor = true;
			panel1.Controls.Add(plXproxy);
			panel1.Controls.Add(rbXproxy);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Location = new System.Drawing.Point(3, 3);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(523, 335);
			panel1.TabIndex = 0;
			plXproxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plXproxy.Controls.Add(panel8);
			plXproxy.Controls.Add(ckbWaitDoneAllXproxy);
			plXproxy.Controls.Add(txtListXProxy);
			plXproxy.Controls.Add(rbSock5Proxy);
			plXproxy.Controls.Add(rbHttpProxy);
			plXproxy.Controls.Add(label35);
			plXproxy.Controls.Add(lblCountXproxy);
			plXproxy.Controls.Add(label52);
			plXproxy.Controls.Add(label51);
			plXproxy.Controls.Add(label39);
			plXproxy.Controls.Add(label37);
			plXproxy.Controls.Add(nudDelayResetXProxy);
			plXproxy.Controls.Add(nudLuongPerIPXProxy);
			plXproxy.Controls.Add(label38);
			plXproxy.Controls.Add(txtServiceURLXProxy);
			plXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plXproxy.Location = new System.Drawing.Point(7, 35);
			plXproxy.Margin = new System.Windows.Forms.Padding(4);
			plXproxy.Name = "plXproxy";
			plXproxy.Size = new System.Drawing.Size(512, 296);
			plXproxy.TabIndex = 144;
			panel8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			panel8.Controls.Add(label53);
			panel8.Controls.Add(rbXproxyResetAllProxy);
			panel8.Controls.Add(rbXproxyResetEachProxy);
			panel8.Location = new System.Drawing.Point(214, 162);
			panel8.Margin = new System.Windows.Forms.Padding(4);
			panel8.Name = "panel8";
			panel8.Size = new System.Drawing.Size(292, 67);
			panel8.TabIndex = 152;
			label53.AutoSize = true;
			label53.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label53.Location = new System.Drawing.Point(1, 7);
			label53.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label53.Name = "label53";
			label53.Size = new System.Drawing.Size(107, 21);
			label53.TabIndex = 155;
			label53.Text = "Chế độ chạy:";
			rbXproxyResetAllProxy.AutoSize = true;
			rbXproxyResetAllProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbXproxyResetAllProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbXproxyResetAllProxy.Location = new System.Drawing.Point(120, 36);
			rbXproxyResetAllProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rbXproxyResetAllProxy.Name = "rbXproxyResetAllProxy";
			rbXproxyResetAllProxy.Size = new System.Drawing.Size(167, 25);
			rbXproxyResetAllProxy.TabIndex = 153;
			rbXproxyResetAllProxy.Text = "Reset tất cả proxy";
			rbXproxyResetAllProxy.UseVisualStyleBackColor = true;
			rbXproxyResetEachProxy.AutoSize = true;
			rbXproxyResetEachProxy.Checked = true;
			rbXproxyResetEachProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbXproxyResetEachProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbXproxyResetEachProxy.Location = new System.Drawing.Point(120, 9);
			rbXproxyResetEachProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rbXproxyResetEachProxy.Name = "rbXproxyResetEachProxy";
			rbXproxyResetEachProxy.Size = new System.Drawing.Size(158, 25);
			rbXproxyResetEachProxy.TabIndex = 154;
			rbXproxyResetEachProxy.TabStop = true;
			rbXproxyResetEachProxy.Text = "Reset từng proxy";
			rbXproxyResetEachProxy.UseVisualStyleBackColor = true;
			ckbWaitDoneAllXproxy.AutoSize = true;
			ckbWaitDoneAllXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			ckbWaitDoneAllXproxy.Location = new System.Drawing.Point(216, 64);
			ckbWaitDoneAllXproxy.Margin = new System.Windows.Forms.Padding(4);
			ckbWaitDoneAllXproxy.Name = "ckbWaitDoneAllXproxy";
			ckbWaitDoneAllXproxy.Size = new System.Drawing.Size(165, 25);
			ckbWaitDoneAllXproxy.TabIndex = 145;
			ckbWaitDoneAllXproxy.Text = "Đợi chạy xong hết";
			ckbWaitDoneAllXproxy.UseVisualStyleBackColor = true;
			txtListXProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtListXProxy.Location = new System.Drawing.Point(8, 87);
			txtListXProxy.Margin = new System.Windows.Forms.Padding(4);
			txtListXProxy.Name = "txtListXProxy";
			txtListXProxy.Size = new System.Drawing.Size(200, 203);
			txtListXProxy.TabIndex = 144;
			txtListXProxy.Text = "";
			txtListXProxy.WordWrap = false;
			txtListXProxy.TextChanged += new System.EventHandler(txtListXProxy_TextChanged);
			rbSock5Proxy.AutoSize = true;
			rbSock5Proxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbSock5Proxy.Location = new System.Drawing.Point(201, 33);
			rbSock5Proxy.Margin = new System.Windows.Forms.Padding(4);
			rbSock5Proxy.Name = "rbSock5Proxy";
			rbSock5Proxy.Size = new System.Drawing.Size(74, 25);
			rbSock5Proxy.TabIndex = 82;
			rbSock5Proxy.Text = "Sock5";
			rbSock5Proxy.UseVisualStyleBackColor = true;
			rbHttpProxy.AutoSize = true;
			rbHttpProxy.Checked = true;
			rbHttpProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbHttpProxy.Location = new System.Drawing.Point(120, 34);
			rbHttpProxy.Margin = new System.Windows.Forms.Padding(4);
			rbHttpProxy.Name = "rbHttpProxy";
			rbHttpProxy.Size = new System.Drawing.Size(63, 25);
			rbHttpProxy.TabIndex = 82;
			rbHttpProxy.TabStop = true;
			rbHttpProxy.Text = "Http";
			rbHttpProxy.UseVisualStyleBackColor = true;
			label35.AutoSize = true;
			label35.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label35.Location = new System.Drawing.Point(4, 34);
			label35.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label35.Name = "label35";
			label35.Size = new System.Drawing.Size(91, 21);
			label35.TabIndex = 79;
			label35.Text = "Loại Proxy:";
			lblCountXproxy.AutoSize = true;
			lblCountXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblCountXproxy.Location = new System.Drawing.Point(4, 62);
			lblCountXproxy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblCountXproxy.Name = "lblCountXproxy";
			lblCountXproxy.Size = new System.Drawing.Size(127, 21);
			lblCountXproxy.TabIndex = 79;
			lblCountXproxy.Text = "Nhập Proxy (0):";
			label52.AutoSize = true;
			label52.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label52.Location = new System.Drawing.Point(525, 127);
			label52.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label52.Name = "label52";
			label52.Size = new System.Drawing.Size(43, 21);
			label52.TabIndex = 139;
			label52.Text = "phút";
			label51.AutoSize = true;
			label51.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label51.Location = new System.Drawing.Point(211, 135);
			label51.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label51.Name = "label51";
			label51.Size = new System.Drawing.Size(180, 21);
			label51.TabIndex = 139;
			label51.Text = "Chờ reset proxy tối đa:";
			label39.AutoSize = true;
			label39.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label39.Location = new System.Drawing.Point(454, 133);
			label39.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label39.Name = "label39";
			label39.Size = new System.Drawing.Size(43, 21);
			label39.TabIndex = 139;
			label39.Text = "phút";
			label37.AutoSize = true;
			label37.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label37.Location = new System.Drawing.Point(211, 99);
			label37.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label37.Name = "label37";
			label37.Size = new System.Drawing.Size(101, 21);
			label37.TabIndex = 139;
			label37.Text = "Số luồng/IP:";
			nudDelayResetXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudDelayResetXProxy.Location = new System.Drawing.Point(396, 132);
			nudDelayResetXProxy.Margin = new System.Windows.Forms.Padding(4);
			nudDelayResetXProxy.Name = "nudDelayResetXProxy";
			nudDelayResetXProxy.Size = new System.Drawing.Size(50, 27);
			nudDelayResetXProxy.TabIndex = 140;
			nudDelayResetXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			nudLuongPerIPXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPXProxy.Location = new System.Drawing.Point(324, 98);
			nudLuongPerIPXProxy.Margin = new System.Windows.Forms.Padding(4);
			nudLuongPerIPXProxy.Name = "nudLuongPerIPXProxy";
			nudLuongPerIPXProxy.Size = new System.Drawing.Size(58, 27);
			nudLuongPerIPXProxy.TabIndex = 140;
			nudLuongPerIPXProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label38.AutoSize = true;
			label38.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label38.Location = new System.Drawing.Point(4, 6);
			label38.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label38.Name = "label38";
			label38.Size = new System.Drawing.Size(104, 21);
			label38.TabIndex = 79;
			label38.Text = "Service URL:";
			txtServiceURLXProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			txtServiceURLXProxy.ForeColor = System.Drawing.Color.Black;
			txtServiceURLXProxy.Location = new System.Drawing.Point(120, 2);
			txtServiceURLXProxy.Margin = new System.Windows.Forms.Padding(4);
			txtServiceURLXProxy.Name = "txtServiceURLXProxy";
			txtServiceURLXProxy.Size = new System.Drawing.Size(355, 27);
			txtServiceURLXProxy.TabIndex = 81;
			rbXproxy.AutoSize = true;
			rbXproxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbXproxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbXproxy.Location = new System.Drawing.Point(9, 5);
			rbXproxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rbXproxy.Name = "rbXproxy";
			rbXproxy.Size = new System.Drawing.Size(285, 25);
			rbXproxy.TabIndex = 143;
			rbXproxy.Text = "Xproxy, Mobi, OBC, Eager, S Proxy";
			rbXproxy.UseVisualStyleBackColor = true;
			rbXproxy.CheckedChanged += new System.EventHandler(rbXproxy_CheckedChanged);
			tabPage5.Controls.Add(linkLabel3);
			tabPage5.Controls.Add(plTMProxy);
			tabPage5.Controls.Add(rbTMProxy);
			tabPage5.Location = new System.Drawing.Point(4, 27);
			tabPage5.Name = "tabPage5";
			tabPage5.Padding = new System.Windows.Forms.Padding(3);
			tabPage5.Size = new System.Drawing.Size(529, 341);
			tabPage5.TabIndex = 4;
			tabPage5.Text = "TMProxy";
			tabPage5.UseVisualStyleBackColor = true;
			linkLabel3.AutoSize = true;
			linkLabel3.Location = new System.Drawing.Point(128, 17);
			linkLabel3.Name = "linkLabel3";
			linkLabel3.Size = new System.Drawing.Size(158, 18);
			linkLabel3.TabIndex = 160;
			linkLabel3.TabStop = true;
			linkLabel3.Text = "https://tmproxy.com";
			linkLabel3.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(linkLabel3_LinkClicked);
			plTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plTMProxy.Controls.Add(btnCheckTMProxy);
			plTMProxy.Controls.Add(txtApiKeyTMProxy);
			plTMProxy.Controls.Add(lblCountTmProxy);
			plTMProxy.Controls.Add(label42);
			plTMProxy.Controls.Add(nudLuongPerIPTMProxy);
			plTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plTMProxy.Location = new System.Drawing.Point(19, 46);
			plTMProxy.Margin = new System.Windows.Forms.Padding(4);
			plTMProxy.Name = "plTMProxy";
			plTMProxy.Size = new System.Drawing.Size(488, 288);
			plTMProxy.TabIndex = 148;
			btnCheckTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			btnCheckTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnCheckTMProxy.ForeColor = System.Drawing.Color.Black;
			btnCheckTMProxy.Location = new System.Drawing.Point(226, 233);
			btnCheckTMProxy.Margin = new System.Windows.Forms.Padding(4);
			btnCheckTMProxy.Name = "btnCheckTMProxy";
			btnCheckTMProxy.Size = new System.Drawing.Size(69, 33);
			btnCheckTMProxy.TabIndex = 145;
			btnCheckTMProxy.Text = "Check";
			btnCheckTMProxy.UseVisualStyleBackColor = true;
			btnCheckTMProxy.Click += new System.EventHandler(btnCheckTMProxy_Click);
			txtApiKeyTMProxy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtApiKeyTMProxy.Location = new System.Drawing.Point(8, 28);
			txtApiKeyTMProxy.Margin = new System.Windows.Forms.Padding(4);
			txtApiKeyTMProxy.Name = "txtApiKeyTMProxy";
			txtApiKeyTMProxy.Size = new System.Drawing.Size(470, 197);
			txtApiKeyTMProxy.TabIndex = 144;
			txtApiKeyTMProxy.Text = "";
			txtApiKeyTMProxy.WordWrap = false;
			txtApiKeyTMProxy.TextChanged += new System.EventHandler(txtApiKeyTMProxy_TextChanged);
			lblCountTmProxy.AutoSize = true;
			lblCountTmProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblCountTmProxy.Location = new System.Drawing.Point(4, 2);
			lblCountTmProxy.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblCountTmProxy.Name = "lblCountTmProxy";
			lblCountTmProxy.Size = new System.Drawing.Size(148, 21);
			lblCountTmProxy.TabIndex = 79;
			lblCountTmProxy.Text = "Nhập API KEY (0):";
			label42.AutoSize = true;
			label42.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label42.Location = new System.Drawing.Point(5, 238);
			label42.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label42.Name = "label42";
			label42.Size = new System.Drawing.Size(101, 21);
			label42.TabIndex = 139;
			label42.Text = "Số luồng/IP:";
			nudLuongPerIPTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudLuongPerIPTMProxy.Location = new System.Drawing.Point(118, 237);
			nudLuongPerIPTMProxy.Margin = new System.Windows.Forms.Padding(4);
			nudLuongPerIPTMProxy.Name = "nudLuongPerIPTMProxy";
			nudLuongPerIPTMProxy.Size = new System.Drawing.Size(89, 27);
			nudLuongPerIPTMProxy.TabIndex = 140;
			nudLuongPerIPTMProxy.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbTMProxy.AutoSize = true;
			rbTMProxy.Cursor = System.Windows.Forms.Cursors.Hand;
			rbTMProxy.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbTMProxy.Location = new System.Drawing.Point(19, 12);
			rbTMProxy.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rbTMProxy.Name = "rbTMProxy";
			rbTMProxy.Size = new System.Drawing.Size(94, 25);
			rbTMProxy.TabIndex = 147;
			rbTMProxy.Text = "TMProxy";
			rbTMProxy.UseVisualStyleBackColor = true;
			rbTMProxy.CheckedChanged += new System.EventHandler(rbTMProxy_CheckedChanged);
			tabPage8.Controls.Add(lnkShopLike);
			tabPage8.Controls.Add(plProxyShopLike);
			tabPage8.Controls.Add(rbProxyShoplike);
			tabPage8.Location = new System.Drawing.Point(4, 27);
			tabPage8.Name = "tabPage8";
			tabPage8.Padding = new System.Windows.Forms.Padding(3);
			tabPage8.Size = new System.Drawing.Size(529, 341);
			tabPage8.TabIndex = 5;
			tabPage8.Text = "Proxy.Shoplike";
			tabPage8.UseVisualStyleBackColor = true;
			lnkShopLike.AutoSize = true;
			lnkShopLike.Location = new System.Drawing.Point(217, 14);
			lnkShopLike.Name = "lnkShopLike";
			lnkShopLike.Size = new System.Drawing.Size(196, 18);
			lnkShopLike.TabIndex = 163;
			lnkShopLike.TabStop = true;
			lnkShopLike.Text = "https://proxy.shoplike.vn/";
			lnkShopLike.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(lnkShopLike_LinkClicked);
			plProxyShopLike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plProxyShopLike.Controls.Add(txtAPIKeyShoplike);
			plProxyShopLike.Controls.Add(lblAPIKeyShopLike);
			plProxyShopLike.Controls.Add(label47);
			plProxyShopLike.Controls.Add(nudThreadShopLike);
			plProxyShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			plProxyShopLike.Location = new System.Drawing.Point(20, 43);
			plProxyShopLike.Margin = new System.Windows.Forms.Padding(4);
			plProxyShopLike.Name = "plProxyShopLike";
			plProxyShopLike.Size = new System.Drawing.Size(488, 288);
			plProxyShopLike.TabIndex = 162;
			txtAPIKeyShoplike.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			txtAPIKeyShoplike.Location = new System.Drawing.Point(8, 28);
			txtAPIKeyShoplike.Margin = new System.Windows.Forms.Padding(4);
			txtAPIKeyShoplike.Name = "txtAPIKeyShoplike";
			txtAPIKeyShoplike.Size = new System.Drawing.Size(470, 197);
			txtAPIKeyShoplike.TabIndex = 144;
			txtAPIKeyShoplike.Text = "";
			txtAPIKeyShoplike.WordWrap = false;
			txtAPIKeyShoplike.TextChanged += new System.EventHandler(txtAPIKeyShoplike_TextChanged);
			lblAPIKeyShopLike.AutoSize = true;
			lblAPIKeyShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			lblAPIKeyShopLike.Location = new System.Drawing.Point(4, 2);
			lblAPIKeyShopLike.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			lblAPIKeyShopLike.Name = "lblAPIKeyShopLike";
			lblAPIKeyShopLike.Size = new System.Drawing.Size(148, 21);
			lblAPIKeyShopLike.TabIndex = 79;
			lblAPIKeyShopLike.Text = "Nhập API KEY (0):";
			label47.AutoSize = true;
			label47.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			label47.Location = new System.Drawing.Point(5, 238);
			label47.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label47.Name = "label47";
			label47.Size = new System.Drawing.Size(101, 21);
			label47.TabIndex = 139;
			label47.Text = "Số luồng/IP:";
			nudThreadShopLike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			nudThreadShopLike.Location = new System.Drawing.Point(118, 237);
			nudThreadShopLike.Margin = new System.Windows.Forms.Padding(4);
			nudThreadShopLike.Name = "nudThreadShopLike";
			nudThreadShopLike.Size = new System.Drawing.Size(89, 27);
			nudThreadShopLike.TabIndex = 140;
			nudThreadShopLike.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			rbProxyShoplike.AutoSize = true;
			rbProxyShoplike.Cursor = System.Windows.Forms.Cursors.Hand;
			rbProxyShoplike.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rbProxyShoplike.Location = new System.Drawing.Point(20, 9);
			rbProxyShoplike.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rbProxyShoplike.Name = "rbProxyShoplike";
			rbProxyShoplike.Size = new System.Drawing.Size(158, 25);
			rbProxyShoplike.TabIndex = 161;
			rbProxyShoplike.Text = "proxy.shoplike.vn";
			rbProxyShoplike.UseVisualStyleBackColor = true;
			rbProxyShoplike.CheckedChanged += new System.EventHandler(rbProxyShoplike_CheckedChanged);
			tabPage9.Controls.Add(pnlProxyFree);
			tabPage9.Controls.Add(rdProxyOrbit);
			tabPage9.Location = new System.Drawing.Point(4, 27);
			tabPage9.Name = "tabPage9";
			tabPage9.Padding = new System.Windows.Forms.Padding(3);
			tabPage9.Size = new System.Drawing.Size(529, 341);
			tabPage9.TabIndex = 6;
			tabPage9.Text = "Proxy Free";
			tabPage9.UseVisualStyleBackColor = true;
			pnlProxyFree.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlProxyFree.Controls.Add(rdProxyFreeRandom);
			pnlProxyFree.Controls.Add(rdProxyFreeUS);
			pnlProxyFree.Controls.Add(rdProxyFreeVN);
			pnlProxyFree.Location = new System.Drawing.Point(19, 45);
			pnlProxyFree.Name = "pnlProxyFree";
			pnlProxyFree.Size = new System.Drawing.Size(494, 56);
			pnlProxyFree.TabIndex = 163;
			rdProxyFreeRandom.AutoSize = true;
			rdProxyFreeRandom.Location = new System.Drawing.Point(297, 14);
			rdProxyFreeRandom.Name = "rdProxyFreeRandom";
			rdProxyFreeRandom.Size = new System.Drawing.Size(161, 22);
			rdProxyFreeRandom.TabIndex = 0;
			rdProxyFreeRandom.TabStop = true;
			rdProxyFreeRandom.Text = "Proxy Ngẫu nhiên";
			rdProxyFreeRandom.UseVisualStyleBackColor = true;
			rdProxyFreeUS.AutoSize = true;
			rdProxyFreeUS.Location = new System.Drawing.Point(158, 14);
			rdProxyFreeUS.Name = "rdProxyFreeUS";
			rdProxyFreeUS.Size = new System.Drawing.Size(100, 22);
			rdProxyFreeUS.TabIndex = 0;
			rdProxyFreeUS.TabStop = true;
			rdProxyFreeUS.Text = "Proxy US";
			rdProxyFreeUS.UseVisualStyleBackColor = true;
			rdProxyFreeVN.AutoSize = true;
			rdProxyFreeVN.Location = new System.Drawing.Point(24, 14);
			rdProxyFreeVN.Name = "rdProxyFreeVN";
			rdProxyFreeVN.Size = new System.Drawing.Size(99, 22);
			rdProxyFreeVN.TabIndex = 0;
			rdProxyFreeVN.TabStop = true;
			rdProxyFreeVN.Text = "Proxy VN";
			rdProxyFreeVN.UseVisualStyleBackColor = true;
			rdProxyOrbit.AutoSize = true;
			rdProxyOrbit.Cursor = System.Windows.Forms.Cursors.Hand;
			rdProxyOrbit.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			rdProxyOrbit.Location = new System.Drawing.Point(19, 19);
			rdProxyOrbit.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
			rdProxyOrbit.Name = "rdProxyOrbit";
			rdProxyOrbit.Size = new System.Drawing.Size(105, 25);
			rdProxyOrbit.TabIndex = 162;
			rdProxyOrbit.Text = "Proxy free";
			rdProxyOrbit.UseVisualStyleBackColor = true;
			rdProxyOrbit.CheckedChanged += new System.EventHandler(rdProxyOrbit_CheckedChanged);
			plCheckDoiIP.Controls.Add(btnTestChangeIP);
			plCheckDoiIP.Controls.Add(numChangeIP);
			plCheckDoiIP.Controls.Add(label20);
			plCheckDoiIP.Controls.Add(label21);
			plCheckDoiIP.Location = new System.Drawing.Point(34, 8);
			plCheckDoiIP.Name = "plCheckDoiIP";
			plCheckDoiIP.Size = new System.Drawing.Size(324, 36);
			plCheckDoiIP.TabIndex = 155;
			btnTestChangeIP.Cursor = System.Windows.Forms.Cursors.Hand;
			btnTestChangeIP.Font = new System.Drawing.Font("Tahoma", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 163);
			btnTestChangeIP.ForeColor = System.Drawing.Color.Black;
			btnTestChangeIP.Location = new System.Drawing.Point(221, 0);
			btnTestChangeIP.Margin = new System.Windows.Forms.Padding(4);
			btnTestChangeIP.Name = "btnTestChangeIP";
			btnTestChangeIP.Size = new System.Drawing.Size(103, 35);
			btnTestChangeIP.TabIndex = 156;
			btnTestChangeIP.Text = "Test";
			btnTestChangeIP.UseVisualStyleBackColor = true;
			btnTestChangeIP.Click += new System.EventHandler(btnTestChangeIP_Click);
			numChangeIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numChangeIP.Location = new System.Drawing.Point(93, 7);
			numChangeIP.Name = "numChangeIP";
			numChangeIP.Size = new System.Drawing.Size(55, 24);
			numChangeIP.TabIndex = 8;
			label20.AutoSize = true;
			label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label20.Location = new System.Drawing.Point(2, 10);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(80, 18);
			label20.TabIndex = 7;
			label20.Text = "Đổi IP sau:";
			label21.AutoSize = true;
			label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label21.Location = new System.Drawing.Point(152, 9);
			label21.Name = "label21";
			label21.Size = new System.Drawing.Size(52, 18);
			label21.TabIndex = 6;
			label21.Text = "lần reg";
			plChangeIPDcom.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			plChangeIPDcom.Controls.Add(btnGetDcom);
			plChangeIPDcom.Controls.Add(txtNameDcom);
			plChangeIPDcom.Location = new System.Drawing.Point(53, 108);
			plChangeIPDcom.Name = "plChangeIPDcom";
			plChangeIPDcom.Size = new System.Drawing.Size(346, 54);
			plChangeIPDcom.TabIndex = 13;
			btnGetDcom.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnGetDcom.Location = new System.Drawing.Point(172, 3);
			btnGetDcom.Name = "btnGetDcom";
			btnGetDcom.Size = new System.Drawing.Size(164, 45);
			btnGetDcom.TabIndex = 3;
			btnGetDcom.Text = "Lấy tên Dcom";
			btnGetDcom.UseVisualStyleBackColor = true;
			btnGetDcom.Click += new System.EventHandler(btnGetDcom_Click);
			txtNameDcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtNameDcom.Location = new System.Drawing.Point(8, 14);
			txtNameDcom.Name = "txtNameDcom";
			txtNameDcom.Size = new System.Drawing.Size(149, 24);
			txtNameDcom.TabIndex = 2;
			rdProxy.AutoSize = true;
			rdProxy.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdProxy.Location = new System.Drawing.Point(39, 170);
			rdProxy.Name = "rdProxy";
			rdProxy.Size = new System.Drawing.Size(67, 22);
			rdProxy.TabIndex = 10;
			rdProxy.TabStop = true;
			rdProxy.Text = "Proxy";
			rdProxy.UseVisualStyleBackColor = true;
			rdProxy.CheckedChanged += new System.EventHandler(rdProxy_CheckedChanged);
			rdHMA.AutoSize = true;
			rdHMA.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdHMA.Location = new System.Drawing.Point(423, 84);
			rdHMA.Name = "rdHMA";
			rdHMA.Size = new System.Drawing.Size(106, 22);
			rdHMA.TabIndex = 10;
			rdHMA.TabStop = true;
			rdHMA.Text = "Đổi IP HMA";
			rdHMA.UseVisualStyleBackColor = true;
			rdHMA.CheckedChanged += new System.EventHandler(rdHMA_CheckedChanged);
			rdChangeIPDcom.AutoSize = true;
			rdChangeIPDcom.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdChangeIPDcom.Location = new System.Drawing.Point(36, 84);
			rdChangeIPDcom.Name = "rdChangeIPDcom";
			rdChangeIPDcom.Size = new System.Drawing.Size(118, 22);
			rdChangeIPDcom.TabIndex = 10;
			rdChangeIPDcom.TabStop = true;
			rdChangeIPDcom.Text = "Đổi IP Dcom:";
			rdChangeIPDcom.UseVisualStyleBackColor = true;
			rdChangeIPDcom.CheckedChanged += new System.EventHandler(rdChangeIPDcom_CheckedChanged);
			rdNoChangeIP.AutoSize = true;
			rdNoChangeIP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdNoChangeIP.Location = new System.Drawing.Point(36, 50);
			rdNoChangeIP.Name = "rdNoChangeIP";
			rdNoChangeIP.Size = new System.Drawing.Size(113, 22);
			rdNoChangeIP.TabIndex = 11;
			rdNoChangeIP.TabStop = true;
			rdNoChangeIP.Text = "Không đổi IP";
			rdNoChangeIP.UseVisualStyleBackColor = true;
			rdNoChangeIP.CheckedChanged += new System.EventHandler(rdNoChangeIP_CheckedChanged);
			groupBox4.Controls.Add(panel7);
			groupBox4.Controls.Add(txtLinkLD);
			groupBox4.Controls.Add(numDeClsTo);
			groupBox4.Controls.Add(numDeClsFr);
			groupBox4.Controls.Add(label7);
			groupBox4.Controls.Add(rdSwap);
			groupBox4.Controls.Add(rdNormal);
			groupBox4.Controls.Add(label8);
			groupBox4.Controls.Add(label6);
			groupBox4.Controls.Add(label3);
			groupBox4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox4.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox4.Location = new System.Drawing.Point(7, 154);
			groupBox4.Name = "groupBox4";
			groupBox4.Size = new System.Drawing.Size(585, 200);
			groupBox4.TabIndex = 0;
			groupBox4.TabStop = false;
			groupBox4.Text = "Cấu hình LDPlayer";
			panel7.Controls.Add(numDelayTo);
			panel7.Controls.Add(rdDelayLD);
			panel7.Controls.Add(label4);
			panel7.Controls.Add(numDelayFr);
			panel7.Controls.Add(label5);
			panel7.Location = new System.Drawing.Point(15, 85);
			panel7.Name = "panel7";
			panel7.Size = new System.Drawing.Size(543, 33);
			panel7.TabIndex = 3;
			numDelayTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numDelayTo.Location = new System.Drawing.Point(411, 6);
			numDelayTo.Name = "numDelayTo";
			numDelayTo.Size = new System.Drawing.Size(55, 24);
			numDelayTo.TabIndex = 1;
			rdDelayLD.AutoSize = true;
			rdDelayLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdDelayLD.Location = new System.Drawing.Point(188, 6);
			rdDelayLD.Name = "rdDelayLD";
			rdDelayLD.Size = new System.Drawing.Size(96, 22);
			rdDelayLD.TabIndex = 1;
			rdDelayLD.TabStop = true;
			rdDelayLD.Text = "Delay mở:";
			rdDelayLD.UseVisualStyleBackColor = true;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(2, 9);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(98, 18);
			label4.TabIndex = 0;
			label4.Text = "Mở LDPlayer:";
			numDelayFr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numDelayFr.Location = new System.Drawing.Point(307, 6);
			numDelayFr.Name = "numDelayFr";
			numDelayFr.Size = new System.Drawing.Size(55, 24);
			numDelayFr.TabIndex = 1;
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(370, 9);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(32, 18);
			label5.TabIndex = 0;
			label5.Text = "đến";
			txtLinkLD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			txtLinkLD.Location = new System.Drawing.Point(202, 168);
			txtLinkLD.Name = "txtLinkLD";
			txtLinkLD.Size = new System.Drawing.Size(320, 24);
			txtLinkLD.TabIndex = 2;
			numDeClsTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numDeClsTo.Location = new System.Drawing.Point(320, 131);
			numDeClsTo.Name = "numDeClsTo";
			numDeClsTo.Size = new System.Drawing.Size(55, 24);
			numDeClsTo.TabIndex = 1;
			numDeClsFr.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			numDeClsFr.Location = new System.Drawing.Point(203, 132);
			numDeClsFr.Name = "numDeClsFr";
			numDeClsFr.Size = new System.Drawing.Size(55, 24);
			numDeClsFr.TabIndex = 1;
			label7.AutoSize = true;
			label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label7.Location = new System.Drawing.Point(273, 134);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(32, 18);
			label7.TabIndex = 0;
			label7.Text = "đến";
			rdSwap.AutoSize = true;
			rdSwap.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdSwap.Location = new System.Drawing.Point(203, 57);
			rdSwap.Name = "rdSwap";
			rdSwap.Size = new System.Drawing.Size(258, 22);
			rdSwap.TabIndex = 1;
			rdSwap.TabStop = true;
			rdSwap.Text = "Swap (Nhiều tài khoản/1 LDPlayer)";
			rdSwap.UseVisualStyleBackColor = true;
			rdSwap.CheckedChanged += new System.EventHandler(rdSwap_CheckedChanged);
			rdNormal.AutoSize = true;
			rdNormal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			rdNormal.Location = new System.Drawing.Point(203, 29);
			rdNormal.Name = "rdNormal";
			rdNormal.Size = new System.Drawing.Size(241, 22);
			rdNormal.TabIndex = 1;
			rdNormal.TabStop = true;
			rdNormal.Text = "Thường (1 tài khoản/1 LDPlayer)";
			rdNormal.UseVisualStyleBackColor = true;
			rdNormal.CheckedChanged += new System.EventHandler(rdNormal_CheckedChanged);
			label8.AutoSize = true;
			label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label8.Location = new System.Drawing.Point(16, 172);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(148, 18);
			label8.TabIndex = 0;
			label8.Text = "Đường dẫn LDPlayer:";
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(16, 134);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(150, 18);
			label6.TabIndex = 0;
			label6.Text = "Delay đóng LDPlayer:";
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(16, 30);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(159, 18);
			label3.TabIndex = 0;
			label3.Text = "Chế độ chạy LDPlayer:";
			groupBox3.Controls.Add(pnlSoLanReg);
			groupBox3.Controls.Add(nudTimeWaitOTP);
			groupBox3.Controls.Add(numOTP);
			groupBox3.Controls.Add(numThrLdPlay);
			groupBox3.Controls.Add(label48);
			groupBox3.Controls.Add(label11);
			groupBox3.Controls.Add(button1);
			groupBox3.Controls.Add(label45);
			groupBox3.Controls.Add(cbModeRunReg);
			groupBox3.Controls.Add(label46);
			groupBox3.Controls.Add(label2);
			groupBox3.Controls.Add(label1);
			groupBox3.Controls.Add(ckCheckIP);
			groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox3.ForeColor = System.Drawing.Color.FromArgb(24, 30, 54);
			groupBox3.Location = new System.Drawing.Point(7, 22);
			groupBox3.Name = "groupBox3";
			groupBox3.Size = new System.Drawing.Size(585, 126);
			groupBox3.TabIndex = 0;
			groupBox3.TabStop = false;
			groupBox3.Text = "Cấu hình chung";
			pnlSoLanReg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			pnlSoLanReg.Controls.Add(nudSoLuotChay);
			pnlSoLanReg.Controls.Add(label23);
			pnlSoLanReg.Controls.Add(label24);
			pnlSoLanReg.Location = new System.Drawing.Point(326, 22);
			pnlSoLanReg.Name = "pnlSoLanReg";
			pnlSoLanReg.Size = new System.Drawing.Size(217, 38);
			pnlSoLanReg.TabIndex = 3;
			nudSoLuotChay.Location = new System.Drawing.Point(92, 5);
			nudSoLuotChay.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			nudSoLuotChay.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			nudSoLuotChay.Name = "nudSoLuotChay";
			nudSoLuotChay.Size = new System.Drawing.Size(77, 24);
			nudSoLuotChay.TabIndex = 1;
			nudSoLuotChay.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label23.AutoSize = true;
			label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label23.Location = new System.Drawing.Point(6, 8);
			label23.Name = "label23";
			label23.Size = new System.Drawing.Size(79, 18);
			label23.TabIndex = 0;
			label23.Text = "Số lần reg:";
			label24.AutoSize = true;
			label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label24.Location = new System.Drawing.Point(175, 9);
			label24.Name = "label24";
			label24.Size = new System.Drawing.Size(27, 18);
			label24.TabIndex = 0;
			label24.Text = "lần";
			nudTimeWaitOTP.Location = new System.Drawing.Point(426, 61);
			nudTimeWaitOTP.Maximum = new decimal(new int[4] { 3600, 0, 0, 0 });
			nudTimeWaitOTP.Minimum = new decimal(new int[4] { 60, 0, 0, 0 });
			nudTimeWaitOTP.Name = "nudTimeWaitOTP";
			nudTimeWaitOTP.Size = new System.Drawing.Size(63, 24);
			nudTimeWaitOTP.TabIndex = 1;
			nudTimeWaitOTP.Value = new decimal(new int[4] { 60, 0, 0, 0 });
			numOTP.Location = new System.Drawing.Point(204, 91);
			numOTP.Minimum = new decimal(new int[4] { 2, 0, 0, 0 });
			numOTP.Name = "numOTP";
			numOTP.Size = new System.Drawing.Size(77, 24);
			numOTP.TabIndex = 1;
			numOTP.Value = new decimal(new int[4] { 2, 0, 0, 0 });
			numThrLdPlay.Location = new System.Drawing.Point(204, 61);
			numThrLdPlay.Maximum = new decimal(new int[4] { 10000, 0, 0, 0 });
			numThrLdPlay.Minimum = new decimal(new int[4] { 1, 0, 0, 0 });
			numThrLdPlay.Name = "numThrLdPlay";
			numThrLdPlay.Size = new System.Drawing.Size(77, 24);
			numThrLdPlay.TabIndex = 1;
			numThrLdPlay.Value = new decimal(new int[4] { 1, 0, 0, 0 });
			label48.AutoSize = true;
			label48.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label48.Location = new System.Drawing.Point(502, 63);
			label48.Name = "label48";
			label48.Size = new System.Drawing.Size(34, 18);
			label48.TabIndex = 0;
			label48.Text = "giây";
			label11.AutoSize = true;
			label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label11.Location = new System.Drawing.Point(287, 93);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(34, 18);
			label11.TabIndex = 0;
			label11.Text = "giây";
			button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			button1.ForeColor = System.Drawing.Color.FromArgb(37, 189, 6);
			button1.Image = ns5.Class74.icons8_start_25__1_;
			button1.Location = new System.Drawing.Point(-943, -131);
			button1.Name = "button1";
			button1.Size = new System.Drawing.Size(140, 61);
			button1.TabIndex = 2;
			button1.Text = "Bắt đầu";
			button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
			button1.UseVisualStyleBackColor = true;
			label45.AutoSize = true;
			label45.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label45.Location = new System.Drawing.Point(9, 29);
			label45.Name = "label45";
			label45.Size = new System.Drawing.Size(95, 18);
			label45.TabIndex = 0;
			label45.Text = "Chế độ chạy:";
			cbModeRunReg.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbModeRunReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			cbModeRunReg.FormattingEnabled = true;
			cbModeRunReg.Items.AddRange(new object[2] { "Theo số lần reg", "Theo số luồng LD" });
			cbModeRunReg.Location = new System.Drawing.Point(123, 26);
			cbModeRunReg.Name = "cbModeRunReg";
			cbModeRunReg.Size = new System.Drawing.Size(182, 26);
			cbModeRunReg.TabIndex = 2;
			cbModeRunReg.SelectedIndexChanged += new System.EventHandler(cbModeRunReg_SelectedIndexChanged);
			label46.AutoSize = true;
			label46.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label46.Location = new System.Drawing.Point(298, 65);
			label46.Name = "label46";
			label46.Size = new System.Drawing.Size(109, 18);
			label46.TabIndex = 0;
			label46.Text = "Time chờ OTP:";
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(10, 97);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(143, 18);
			label2.TabIndex = 0;
			label2.Text = "Thời gian nhập OTP:";
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(10, 67);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(170, 18);
			label1.TabIndex = 0;
			label1.Text = "Số luồng chạy LDPlayer:";
			ckCheckIP.AutoSize = true;
			ckCheckIP.Location = new System.Drawing.Point(326, 93);
			ckCheckIP.Name = "ckCheckIP";
			ckCheckIP.Size = new System.Drawing.Size(98, 22);
			ckCheckIP.TabIndex = 3;
			ckCheckIP.Text = "Check IP";
			ckCheckIP.UseVisualStyleBackColor = true;
			ckCheckIP.CheckedChanged += new System.EventHandler(ckCheckIP_CheckedChanged);
			bunifuDragControl_1.Fixed = true;
			bunifuDragControl_1.Horizontal = true;
			bunifuDragControl_1.TargetControl = label28;
			bunifuDragControl_1.Vertical = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			BackColor = System.Drawing.SystemColors.Control;
			base.ClientSize = new System.Drawing.Size(1924, 1055);
			base.Controls.Add(pnlContainer);
			base.Controls.Add(panel4);
			base.Controls.Add(statusStrip1);
			ForeColor = System.Drawing.Color.White;
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmMain";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Auto Register Facebook On LDPlayer";
			base.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			base.FormClosing += new System.Windows.Forms.FormClosingEventHandler(frmMain_FormClosing);
			base.Load += new System.EventHandler(frmMain_Load);
			base.Paint += new System.Windows.Forms.PaintEventHandler(frmMain_Paint);
			contextMenuStrip1.ResumeLayout(false);
			statusStrip1.ResumeLayout(false);
			statusStrip1.PerformLayout();
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			pnlContainer.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)dgvAcc).EndInit();
			groupBox1.ResumeLayout(false);
			groupBox7.ResumeLayout(false);
			groupBox7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nAgeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nAgeFrom).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDelayQR2Fa).EndInit();
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			groupBox6.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			tabMailVeri.ResumeLayout(false);
			tabPage6.ResumeLayout(false);
			plVeriMail.ResumeLayout(false);
			plVeriMail.PerformLayout();
			plHotmailReg.ResumeLayout(false);
			plHotmailReg.PerformLayout();
			tabPage7.ResumeLayout(false);
			pnlTemmail.ResumeLayout(false);
			pnlTemmail.PerformLayout();
			plNovery.ResumeLayout(false);
			plNovery.PerformLayout();
			plVeriPhone.ResumeLayout(false);
			plVeriPhone.PerformLayout();
			groupBox8.ResumeLayout(false);
			pnlTuongTac.ResumeLayout(false);
			pnlTuongTac.PerformLayout();
			gbCamxuc.ResumeLayout(false);
			gbCamxuc.PerformLayout();
			plAddfriend.ResumeLayout(false);
			plAddfriend.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nFriendTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nFriendFrom).EndInit();
			groupBox5.ResumeLayout(false);
			panel5.ResumeLayout(false);
			panel5.PerformLayout();
			tabProxy.ResumeLayout(false);
			tabPage1.ResumeLayout(false);
			tabPage1.PerformLayout();
			plTinsoftProxy.ResumeLayout(false);
			plTinsoftProxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTinsoft).EndInit();
			tabPage2.ResumeLayout(false);
			tabPage2.PerformLayout();
			pnlAPIMinProxy.ResumeLayout(false);
			pnlAPIMinProxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPMinProxy).EndInit();
			tabPage3.ResumeLayout(false);
			tabPage3.PerformLayout();
			pnlIpPort.ResumeLayout(false);
			pnlIpPort.PerformLayout();
			tabPage4.ResumeLayout(false);
			panel1.ResumeLayout(false);
			panel1.PerformLayout();
			plXproxy.ResumeLayout(false);
			plXproxy.PerformLayout();
			panel8.ResumeLayout(false);
			panel8.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudDelayResetXProxy).EndInit();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPXProxy).EndInit();
			tabPage5.ResumeLayout(false);
			tabPage5.PerformLayout();
			plTMProxy.ResumeLayout(false);
			plTMProxy.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudLuongPerIPTMProxy).EndInit();
			tabPage8.ResumeLayout(false);
			tabPage8.PerformLayout();
			plProxyShopLike.ResumeLayout(false);
			plProxyShopLike.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudThreadShopLike).EndInit();
			tabPage9.ResumeLayout(false);
			tabPage9.PerformLayout();
			pnlProxyFree.ResumeLayout(false);
			pnlProxyFree.PerformLayout();
			plCheckDoiIP.ResumeLayout(false);
			plCheckDoiIP.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numChangeIP).EndInit();
			plChangeIPDcom.ResumeLayout(false);
			plChangeIPDcom.PerformLayout();
			groupBox4.ResumeLayout(false);
			groupBox4.PerformLayout();
			panel7.ResumeLayout(false);
			panel7.PerformLayout();
			((System.ComponentModel.ISupportInitialize)numDelayTo).EndInit();
			((System.ComponentModel.ISupportInitialize)numDelayFr).EndInit();
			((System.ComponentModel.ISupportInitialize)numDeClsTo).EndInit();
			((System.ComponentModel.ISupportInitialize)numDeClsFr).EndInit();
			groupBox3.ResumeLayout(false);
			groupBox3.PerformLayout();
			pnlSoLanReg.ResumeLayout(false);
			pnlSoLanReg.PerformLayout();
			((System.ComponentModel.ISupportInitialize)nudSoLuotChay).EndInit();
			((System.ComponentModel.ISupportInitialize)nudTimeWaitOTP).EndInit();
			((System.ComponentModel.ISupportInitialize)numOTP).EndInit();
			((System.ComponentModel.ISupportInitialize)numThrLdPlay).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		[CompilerGenerated]
		private void method_105()
		{
			while (true)
			{
				try
				{
					string text = Class2.smethod_34("adb devices");
					if (!text.Contains("List of devices attached"))
					{
						Common.smethod_63("adb");
						bool_1 = true;
					}
				}
				catch
				{
				}
				Common.smethod_62(30.0);
			}
		}

		[CompilerGenerated]
		private void method_106()
		{
			Process.Start(txtLinkLD.Text + "\\dnmultiplayer.exe");
		}

		[CompilerGenerated]
		private void method_107()
		{
			Process.Start(txtLinkLD.Text + "\\dnrepairer.exe");
			method_51(10.0);
			MessageBox.Show("Sửa chữa LDPlayer thành công", "Thông báo");
		}
	}
}
