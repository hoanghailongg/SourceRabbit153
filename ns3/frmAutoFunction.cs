using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using ns4;
using ns5;
using ns6;
using ToolRegFB.Properties;

namespace ns3
{
	internal class frmAutoFunction : Form
	{
		private IContainer icontainer_0 = null;

		private Panel panel4;

		private Button btnClose;

		private Label label28;

		private PictureBox pictureBox1;

		private Panel panel1;

		private CheckBox chkAutoClearLD;

		private CheckBox cbTurnOnLDPlayer;

		private GroupBox groupBox1;

		private Panel panel2;

		private PictureBox pictureBox2;

		private NumericUpDown nudSizeFr;

		private ComboBox cbRamLD;

		private Label label3;

		private Label label2;

		private ComboBox cbCPULD;

		private Label label1;

		private NumericUpDown nudSizeTo;

		private NumericUpDown nudDPILD;

		private Label label4;

		private BunifuFlatButton btnSaveConf;

		private CheckBox ckAdbDebug;

		private BunifuDragControl bunifuDragControl_0;

		private GroupBox groupBox2;

		private Panel panel3;

		private Button btnDongBoDanhBa;

		private BunifuDragControl bunifuDragControl_1;

		private CheckBox ckDongBoDB;

		private Button btnAddMailReg;

		private CheckBox ckAddMailReg;

		private Label label5;

		private Button btnVeriphoneNoveri;

		private CheckBox ckVeriPhoneNoveri;

		private Button btnVeriMailNoveri;

		private CheckBox ckVeriMailNoveri;

		private CheckBox ckThuVeriCkpoint282;

		private RadioButton rdFbLite;

		private RadioButton rdFbKatana;

		private Label label6;

		private CheckBox ckCheckUIDAndWall;

		public frmAutoFunction()
		{
			InitializeComponent();
			method_0();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			Close();
		}

		private void method_0()
		{
			try
			{
				cbCPULD.Text = Settings.Default.CpuLD;
				cbRamLD.Text = Settings.Default.RamLD;
				nudSizeFr.Value = Settings.Default.SizeLDFrom;
				nudSizeTo.Value = Settings.Default.SizeLDTo;
				nudDPILD.Value = Settings.Default.DPILD;
				if (Settings.Default.isAutoClearLD)
				{
					chkAutoClearLD.Checked = true;
				}
				if (Settings.Default.isOnGPSLD)
				{
					cbTurnOnLDPlayer.Checked = true;
				}
				if (Settings.Default.isAdbDebug)
				{
					ckAdbDebug.Checked = true;
				}
				if (Settings.Default.isDongBoDB)
				{
					ckDongBoDB.Checked = true;
					btnDongBoDanhBa.Enabled = true;
				}
				if (Settings.Default.isAddMailReg)
				{
					ckAddMailReg.Checked = true;
					btnAddMailReg.Enabled = true;
				}
				if (Settings.Default.isVeriPhoneNoveri)
				{
					ckVeriPhoneNoveri.Checked = true;
					btnVeriphoneNoveri.Enabled = true;
				}
				if (Settings.Default.isVeriMailNoveri)
				{
					ckVeriMailNoveri.Checked = true;
					btnVeriMailNoveri.Enabled = true;
				}
				if (Settings.Default.isThuVeriCheckPoint)
				{
					ckThuVeriCkpoint282.Checked = true;
				}
				if (Settings.Default.typeRunApp == 0)
				{
					rdFbKatana.Checked = true;
					rdFbLite.Checked = false;
				}
				else
				{
					rdFbLite.Checked = true;
					rdFbKatana.Checked = false;
				}
				if (Settings.Default.isCheckUID)
				{
					ckCheckUIDAndWall.Checked = true;
				}
			}
			catch (Exception)
			{
				MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void chkAutoClearLD_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void cbTurnOnLDPlayer_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void nudSizeFr_ValueChanged(object sender, EventArgs e)
		{
		}

		private void label3_Click(object sender, EventArgs e)
		{
		}

		private void btnSaveConf_Click(object sender, EventArgs e)
		{
			try
			{
				if (cbCPULD.GetItemText(cbCPULD.SelectedItem) == string.Empty)
				{
					MessageBox.Show("Chưa chọn loại CPU", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (cbRamLD.GetItemText(cbRamLD.SelectedItem) == string.Empty)
				{
					MessageBox.Show("Chưa chọn loại Ram", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (nudSizeFr.Value < 320m)
				{
					MessageBox.Show("Chiều ngang LDPlayer tối thiểu là 320", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (nudSizeTo.Value < 480m)
				{
					MessageBox.Show("Chiều dọc LDPlayer tối thiểu là 480", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				if (nudDPILD.Value < 120m)
				{
					MessageBox.Show("DPI LDPlayer tối thiểu là 120", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
					return;
				}
				Settings.Default.CpuLD = cbCPULD.GetItemText(cbCPULD.SelectedItem);
				Settings.Default.RamLD = cbRamLD.GetItemText(cbRamLD.SelectedItem);
				Settings.Default.SizeLDFrom = Convert.ToInt32(nudSizeFr.Value);
				Settings.Default.SizeLDTo = Convert.ToInt32(nudSizeTo.Value);
				Settings.Default.DPILD = Convert.ToInt32(nudDPILD.Value);
				if (chkAutoClearLD.Checked)
				{
					Settings.Default.isAutoClearLD = true;
				}
				else
				{
					Settings.Default.isAutoClearLD = false;
				}
				if (cbTurnOnLDPlayer.Checked)
				{
					Settings.Default.isOnGPSLD = true;
				}
				else
				{
					Settings.Default.isOnGPSLD = false;
				}
				if (ckAdbDebug.Checked)
				{
					Settings.Default.isAdbDebug = true;
				}
				else
				{
					Settings.Default.isAdbDebug = false;
				}
				if (ckDongBoDB.Checked)
				{
					Settings.Default.isDongBoDB = true;
				}
				else
				{
					Settings.Default.isDongBoDB = false;
				}
				if (ckAddMailReg.Checked)
				{
					Settings.Default.isAddMailReg = true;
				}
				else
				{
					Settings.Default.isAddMailReg = false;
				}
				if (ckVeriPhoneNoveri.Checked)
				{
					Settings.Default.isVeriPhoneNoveri = true;
				}
				else
				{
					Settings.Default.isVeriPhoneNoveri = false;
				}
				if (ckVeriMailNoveri.Checked)
				{
					Settings.Default.isVeriMailNoveri = true;
				}
				else
				{
					Settings.Default.isVeriMailNoveri = false;
				}
				if (ckThuVeriCkpoint282.Checked)
				{
					Settings.Default.isThuVeriCheckPoint = true;
				}
				else
				{
					Settings.Default.isThuVeriCheckPoint = false;
				}
				if (rdFbKatana.Checked)
				{
					Settings.Default.typeRunApp = 0;
				}
				else
				{
					Settings.Default.typeRunApp = 1;
				}
				if (ckCheckUIDAndWall.Checked)
				{
					Settings.Default.isCheckUID = true;
				}
				else
				{
					Settings.Default.isCheckUID = false;
				}
				Settings.Default.Save();
				MessageBox.Show("Lưu cấu hình thành công!!!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
				Close();
			}
			catch
			{
				MessageBox.Show("Có lỗi xảy ra", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Hand);
			}
		}

		private void btnDongBoDanhBa_Click(object sender, EventArgs e)
		{
			frmDongBoDanhba frmDongBoDanhba = new frmDongBoDanhba();
			frmDongBoDanhba.ShowDialog();
		}

		private void ckDongBoDB_CheckedChanged(object sender, EventArgs e)
		{
			btnDongBoDanhBa.Enabled = ckDongBoDB.Checked;
		}

		private void btnAddMailReg_Click(object sender, EventArgs e)
		{
			Process.Start("EmailVeri.txt");
		}

		private void ckAddMailReg_CheckedChanged(object sender, EventArgs e)
		{
			btnAddMailReg.Enabled = ckAddMailReg.Checked;
		}

		private void ckVeriPhoneNoveri_CheckedChanged(object sender, EventArgs e)
		{
			btnVeriphoneNoveri.Enabled = ckVeriPhoneNoveri.Checked;
		}

		private void btnVeriphoneNoveri_Click(object sender, EventArgs e)
		{
			frmVeriPhoneNoveri frmVeriPhoneNoveri = new frmVeriPhoneNoveri();
			frmVeriPhoneNoveri.ShowDialog();
		}

		private void btnVeriMailNoveri_Click(object sender, EventArgs e)
		{
			frmVeriMailNoveri frmVeriMailNoveri = new frmVeriMailNoveri();
			frmVeriMailNoveri.ShowDialog();
		}

		private void ckVeriMailNoveri_CheckedChanged(object sender, EventArgs e)
		{
			btnVeriMailNoveri.Enabled = ckVeriMailNoveri.Checked;
		}

		private void ckThuVeriCkpoint282_CheckedChanged(object sender, EventArgs e)
		{
		}

		private void ckCheckUIDAndWall_Click(object sender, EventArgs e)
		{
			if (ckThuVeriCkpoint282.Checked)
			{
				switch (MessageBox.Show("Khi sử dụng tính năng này:\nNếu bạn chọn veri bằng số điện thoại, nếu xác thực thất bại, có thể mất tiền OTP.\nBạn có thể chọn veri qua tempmail nhưng tỉ lệ thành công không cao.\nBạn có đồng ý sử dụng tính năng này?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Asterisk))
				{
				case DialogResult.Yes:
					ckThuVeriCkpoint282.Checked = true;
					break;
				case DialogResult.No:
					ckThuVeriCkpoint282.Checked = false;
					break;
				}
			}
		}

		private void rdFbKatana_CheckedChanged(object sender, EventArgs e)
		{
			rdFbLite.Checked = !rdFbKatana.Checked;
		}

		private void rdFbLite_CheckedChanged(object sender, EventArgs e)
		{
			rdFbKatana.Checked = !rdFbLite.Checked;
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ns3.frmAutoFunction));
			panel4 = new System.Windows.Forms.Panel();
			btnClose = new System.Windows.Forms.Button();
			label28 = new System.Windows.Forms.Label();
			pictureBox1 = new System.Windows.Forms.PictureBox();
			panel1 = new System.Windows.Forms.Panel();
			btnSaveConf = new Bunifu.Framework.UI.BunifuFlatButton();
			groupBox2 = new System.Windows.Forms.GroupBox();
			panel3 = new System.Windows.Forms.Panel();
			rdFbLite = new System.Windows.Forms.RadioButton();
			rdFbKatana = new System.Windows.Forms.RadioButton();
			label5 = new System.Windows.Forms.Label();
			btnVeriMailNoveri = new System.Windows.Forms.Button();
			ckCheckUIDAndWall = new System.Windows.Forms.CheckBox();
			ckThuVeriCkpoint282 = new System.Windows.Forms.CheckBox();
			ckVeriMailNoveri = new System.Windows.Forms.CheckBox();
			btnVeriphoneNoveri = new System.Windows.Forms.Button();
			ckVeriPhoneNoveri = new System.Windows.Forms.CheckBox();
			btnAddMailReg = new System.Windows.Forms.Button();
			ckAddMailReg = new System.Windows.Forms.CheckBox();
			btnDongBoDanhBa = new System.Windows.Forms.Button();
			ckDongBoDB = new System.Windows.Forms.CheckBox();
			label6 = new System.Windows.Forms.Label();
			groupBox1 = new System.Windows.Forms.GroupBox();
			panel2 = new System.Windows.Forms.Panel();
			pictureBox2 = new System.Windows.Forms.PictureBox();
			ckAdbDebug = new System.Windows.Forms.CheckBox();
			chkAutoClearLD = new System.Windows.Forms.CheckBox();
			nudSizeTo = new System.Windows.Forms.NumericUpDown();
			nudDPILD = new System.Windows.Forms.NumericUpDown();
			nudSizeFr = new System.Windows.Forms.NumericUpDown();
			cbRamLD = new System.Windows.Forms.ComboBox();
			label4 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			cbCPULD = new System.Windows.Forms.ComboBox();
			label1 = new System.Windows.Forms.Label();
			cbTurnOnLDPlayer = new System.Windows.Forms.CheckBox();
			bunifuDragControl_0 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
			bunifuDragControl_1 = new Bunifu.Framework.UI.BunifuDragControl(icontainer_0);
			panel4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
			panel1.SuspendLayout();
			groupBox2.SuspendLayout();
			panel3.SuspendLayout();
			groupBox1.SuspendLayout();
			panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSizeTo).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudDPILD).BeginInit();
			((System.ComponentModel.ISupportInitialize)nudSizeFr).BeginInit();
			SuspendLayout();
			panel4.BackColor = System.Drawing.Color.FromArgb(46, 51, 73);
			panel4.Controls.Add(btnClose);
			panel4.Controls.Add(label28);
			panel4.Controls.Add(pictureBox1);
			panel4.Dock = System.Windows.Forms.DockStyle.Top;
			panel4.Location = new System.Drawing.Point(0, 0);
			panel4.Name = "panel4";
			panel4.Size = new System.Drawing.Size(1150, 46);
			panel4.TabIndex = 8;
			btnClose.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
			btnClose.FlatAppearance.BorderSize = 0;
			btnClose.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnClose.Image = ns5.Class74.icons8_x_20;
			btnClose.Location = new System.Drawing.Point(1103, 0);
			btnClose.Name = "btnClose";
			btnClose.Size = new System.Drawing.Size(44, 39);
			btnClose.TabIndex = 5;
			btnClose.UseVisualStyleBackColor = true;
			btnClose.Click += new System.EventHandler(btnClose_Click);
			label28.AutoSize = true;
			label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 16.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label28.ForeColor = System.Drawing.Color.White;
			label28.Location = new System.Drawing.Point(42, 8);
			label28.Name = "label28";
			label28.Size = new System.Drawing.Size(245, 32);
			label28.TabIndex = 6;
			label28.Text = "Cài đặt nâng cao";
			pictureBox1.Image = ns5.Class74.icons8_facebook_970;
			pictureBox1.Location = new System.Drawing.Point(2, 3);
			pictureBox1.Name = "pictureBox1";
			pictureBox1.Size = new System.Drawing.Size(40, 40);
			pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox1.TabIndex = 4;
			pictureBox1.TabStop = false;
			panel1.Controls.Add(btnSaveConf);
			panel1.Controls.Add(groupBox2);
			panel1.Controls.Add(groupBox1);
			panel1.Dock = System.Windows.Forms.DockStyle.Fill;
			panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			panel1.Location = new System.Drawing.Point(0, 46);
			panel1.Name = "panel1";
			panel1.Size = new System.Drawing.Size(1150, 404);
			panel1.TabIndex = 9;
			btnSaveConf.Activecolor = System.Drawing.Color.FromArgb(46, 139, 87);
			btnSaveConf.BackColor = System.Drawing.Color.FromArgb(46, 139, 87);
			btnSaveConf.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
			btnSaveConf.BorderRadius = 0;
			btnSaveConf.ButtonText = "Lưu cấu hình";
			btnSaveConf.Cursor = System.Windows.Forms.Cursors.Hand;
			btnSaveConf.DisabledColor = System.Drawing.Color.Gray;
			btnSaveConf.Dock = System.Windows.Forms.DockStyle.Bottom;
			btnSaveConf.Iconcolor = System.Drawing.Color.Transparent;
			btnSaveConf.Iconimage = (System.Drawing.Image)resources.GetObject("btnSaveConf.Iconimage");
			btnSaveConf.Iconimage_right = null;
			btnSaveConf.Iconimage_right_Selected = null;
			btnSaveConf.Iconimage_Selected = null;
			btnSaveConf.IconMarginLeft = 0;
			btnSaveConf.IconMarginRight = 0;
			btnSaveConf.IconRightVisible = true;
			btnSaveConf.IconRightZoom = 0.0;
			btnSaveConf.IconVisible = false;
			btnSaveConf.IconZoom = 90.0;
			btnSaveConf.IsTab = false;
			btnSaveConf.Location = new System.Drawing.Point(0, 345);
			btnSaveConf.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
			btnSaveConf.Name = "btnSaveConf";
			btnSaveConf.Normalcolor = System.Drawing.Color.FromArgb(46, 139, 87);
			btnSaveConf.OnHovercolor = System.Drawing.Color.FromArgb(36, 129, 77);
			btnSaveConf.OnHoverTextColor = System.Drawing.Color.White;
			btnSaveConf.selected = false;
			btnSaveConf.Size = new System.Drawing.Size(1150, 59);
			btnSaveConf.TabIndex = 2;
			btnSaveConf.Text = "Lưu cấu hình";
			btnSaveConf.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			btnSaveConf.Textcolor = System.Drawing.Color.White;
			btnSaveConf.TextFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75f, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
			btnSaveConf.Click += new System.EventHandler(btnSaveConf_Click);
			groupBox2.Controls.Add(panel3);
			groupBox2.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox2.Location = new System.Drawing.Point(513, 17);
			groupBox2.Name = "groupBox2";
			groupBox2.Size = new System.Drawing.Size(625, 308);
			groupBox2.TabIndex = 1;
			groupBox2.TabStop = false;
			groupBox2.Text = "Chức năng khác";
			panel3.Controls.Add(rdFbLite);
			panel3.Controls.Add(rdFbKatana);
			panel3.Controls.Add(label5);
			panel3.Controls.Add(btnVeriMailNoveri);
			panel3.Controls.Add(ckCheckUIDAndWall);
			panel3.Controls.Add(ckThuVeriCkpoint282);
			panel3.Controls.Add(ckVeriMailNoveri);
			panel3.Controls.Add(btnVeriphoneNoveri);
			panel3.Controls.Add(ckVeriPhoneNoveri);
			panel3.Controls.Add(btnAddMailReg);
			panel3.Controls.Add(ckAddMailReg);
			panel3.Controls.Add(btnDongBoDanhBa);
			panel3.Controls.Add(ckDongBoDB);
			panel3.Controls.Add(label6);
			panel3.Dock = System.Windows.Forms.DockStyle.Fill;
			panel3.Location = new System.Drawing.Point(3, 26);
			panel3.Name = "panel3";
			panel3.Size = new System.Drawing.Size(619, 279);
			panel3.TabIndex = 0;
			rdFbLite.AutoSize = true;
			rdFbLite.Location = new System.Drawing.Point(268, 7);
			rdFbLite.Name = "rdFbLite";
			rdFbLite.Size = new System.Drawing.Size(136, 27);
			rdFbLite.TabIndex = 129;
			rdFbLite.TabStop = true;
			rdFbLite.Text = "Facebook Lite";
			rdFbLite.UseVisualStyleBackColor = true;
			rdFbLite.CheckedChanged += new System.EventHandler(rdFbLite_CheckedChanged);
			rdFbKatana.AutoSize = true;
			rdFbKatana.Location = new System.Drawing.Point(91, 7);
			rdFbKatana.Name = "rdFbKatana";
			rdFbKatana.Size = new System.Drawing.Size(161, 27);
			rdFbKatana.TabIndex = 129;
			rdFbKatana.TabStop = true;
			rdFbKatana.Text = "Facebook katana";
			rdFbKatana.UseVisualStyleBackColor = true;
			rdFbKatana.CheckedChanged += new System.EventHandler(rdFbKatana_CheckedChanged);
			label5.AutoSize = true;
			label5.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label5.Location = new System.Drawing.Point(221, 88);
			label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(155, 23);
			label5.TabIndex = 128;
			label5.Text = "(Mỗi Email 1 dòng)";
			btnVeriMailNoveri.Enabled = false;
			btnVeriMailNoveri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnVeriMailNoveri.ForeColor = System.Drawing.Color.FromArgb(46, 51, 73);
			btnVeriMailNoveri.Location = new System.Drawing.Point(43, 160);
			btnVeriMailNoveri.Name = "btnVeriMailNoveri";
			btnVeriMailNoveri.Size = new System.Drawing.Size(288, 34);
			btnVeriMailNoveri.TabIndex = 0;
			btnVeriMailNoveri.Text = "Veri mail sau khi reg noveri";
			btnVeriMailNoveri.UseVisualStyleBackColor = true;
			btnVeriMailNoveri.Click += new System.EventHandler(btnVeriMailNoveri_Click);
			ckCheckUIDAndWall.AutoSize = true;
			ckCheckUIDAndWall.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckCheckUIDAndWall.Location = new System.Drawing.Point(15, 232);
			ckCheckUIDAndWall.Name = "ckCheckUIDAndWall";
			ckCheckUIDAndWall.Size = new System.Drawing.Size(155, 24);
			ckCheckUIDAndWall.TabIndex = 0;
			ckCheckUIDAndWall.Text = "Check UID và Wall";
			ckCheckUIDAndWall.UseVisualStyleBackColor = true;
			ckCheckUIDAndWall.CheckedChanged += new System.EventHandler(ckThuVeriCkpoint282_CheckedChanged);
			ckCheckUIDAndWall.Click += new System.EventHandler(ckCheckUIDAndWall_Click);
			ckThuVeriCkpoint282.AutoSize = true;
			ckThuVeriCkpoint282.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckThuVeriCkpoint282.Location = new System.Drawing.Point(15, 205);
			ckThuVeriCkpoint282.Name = "ckThuVeriCkpoint282";
			ckThuVeriCkpoint282.Size = new System.Drawing.Size(164, 24);
			ckThuVeriCkpoint282.TabIndex = 0;
			ckThuVeriCkpoint282.Text = "Giải checkpoint 282";
			ckThuVeriCkpoint282.UseVisualStyleBackColor = true;
			ckThuVeriCkpoint282.CheckedChanged += new System.EventHandler(ckThuVeriCkpoint282_CheckedChanged);
			ckVeriMailNoveri.AutoSize = true;
			ckVeriMailNoveri.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckVeriMailNoveri.Location = new System.Drawing.Point(15, 168);
			ckVeriMailNoveri.Name = "ckVeriMailNoveri";
			ckVeriMailNoveri.Size = new System.Drawing.Size(18, 17);
			ckVeriMailNoveri.TabIndex = 0;
			ckVeriMailNoveri.UseVisualStyleBackColor = true;
			ckVeriMailNoveri.CheckedChanged += new System.EventHandler(ckVeriMailNoveri_CheckedChanged);
			btnVeriphoneNoveri.Enabled = false;
			btnVeriphoneNoveri.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnVeriphoneNoveri.ForeColor = System.Drawing.Color.FromArgb(46, 51, 73);
			btnVeriphoneNoveri.Location = new System.Drawing.Point(43, 120);
			btnVeriphoneNoveri.Name = "btnVeriphoneNoveri";
			btnVeriphoneNoveri.Size = new System.Drawing.Size(288, 34);
			btnVeriphoneNoveri.TabIndex = 0;
			btnVeriphoneNoveri.Text = "Veri phone sau khi reg noveri";
			btnVeriphoneNoveri.UseVisualStyleBackColor = true;
			btnVeriphoneNoveri.Click += new System.EventHandler(btnVeriphoneNoveri_Click);
			ckVeriPhoneNoveri.AutoSize = true;
			ckVeriPhoneNoveri.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckVeriPhoneNoveri.Location = new System.Drawing.Point(15, 128);
			ckVeriPhoneNoveri.Name = "ckVeriPhoneNoveri";
			ckVeriPhoneNoveri.Size = new System.Drawing.Size(18, 17);
			ckVeriPhoneNoveri.TabIndex = 0;
			ckVeriPhoneNoveri.UseVisualStyleBackColor = true;
			ckVeriPhoneNoveri.CheckedChanged += new System.EventHandler(ckVeriPhoneNoveri_CheckedChanged);
			btnAddMailReg.Enabled = false;
			btnAddMailReg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnAddMailReg.ForeColor = System.Drawing.Color.FromArgb(46, 51, 73);
			btnAddMailReg.Location = new System.Drawing.Point(43, 82);
			btnAddMailReg.Name = "btnAddMailReg";
			btnAddMailReg.Size = new System.Drawing.Size(171, 34);
			btnAddMailReg.TabIndex = 0;
			btnAddMailReg.Text = "Thêm mail sau reg";
			btnAddMailReg.UseVisualStyleBackColor = true;
			btnAddMailReg.Click += new System.EventHandler(btnAddMailReg_Click);
			ckAddMailReg.AutoSize = true;
			ckAddMailReg.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckAddMailReg.Location = new System.Drawing.Point(15, 90);
			ckAddMailReg.Name = "ckAddMailReg";
			ckAddMailReg.Size = new System.Drawing.Size(18, 17);
			ckAddMailReg.TabIndex = 0;
			ckAddMailReg.UseVisualStyleBackColor = true;
			ckAddMailReg.CheckedChanged += new System.EventHandler(ckAddMailReg_CheckedChanged);
			btnDongBoDanhBa.Enabled = false;
			btnDongBoDanhBa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			btnDongBoDanhBa.ForeColor = System.Drawing.Color.FromArgb(46, 51, 73);
			btnDongBoDanhBa.Location = new System.Drawing.Point(43, 43);
			btnDongBoDanhBa.Name = "btnDongBoDanhBa";
			btnDongBoDanhBa.Size = new System.Drawing.Size(171, 34);
			btnDongBoDanhBa.TabIndex = 0;
			btnDongBoDanhBa.Text = "Đồng bộ danh bạ";
			btnDongBoDanhBa.UseVisualStyleBackColor = true;
			btnDongBoDanhBa.Click += new System.EventHandler(btnDongBoDanhBa_Click);
			ckDongBoDB.AutoSize = true;
			ckDongBoDB.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckDongBoDB.Location = new System.Drawing.Point(15, 51);
			ckDongBoDB.Name = "ckDongBoDB";
			ckDongBoDB.Size = new System.Drawing.Size(18, 17);
			ckDongBoDB.TabIndex = 0;
			ckDongBoDB.UseVisualStyleBackColor = true;
			ckDongBoDB.CheckedChanged += new System.EventHandler(ckDongBoDB_CheckedChanged);
			label6.AutoSize = true;
			label6.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label6.Location = new System.Drawing.Point(11, 10);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(73, 20);
			label6.TabIndex = 1;
			label6.Text = "Loại App:";
			groupBox1.Controls.Add(panel2);
			groupBox1.Font = new System.Drawing.Font("Segoe UI Semibold", 10.2f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			groupBox1.Location = new System.Drawing.Point(12, 17);
			groupBox1.Name = "groupBox1";
			groupBox1.Size = new System.Drawing.Size(477, 308);
			groupBox1.TabIndex = 1;
			groupBox1.TabStop = false;
			groupBox1.Text = "Cấu hình LDPlayer";
			panel2.Controls.Add(pictureBox2);
			panel2.Controls.Add(ckAdbDebug);
			panel2.Controls.Add(chkAutoClearLD);
			panel2.Controls.Add(nudSizeTo);
			panel2.Controls.Add(nudDPILD);
			panel2.Controls.Add(nudSizeFr);
			panel2.Controls.Add(cbRamLD);
			panel2.Controls.Add(label4);
			panel2.Controls.Add(label3);
			panel2.Controls.Add(label2);
			panel2.Controls.Add(cbCPULD);
			panel2.Controls.Add(label1);
			panel2.Controls.Add(cbTurnOnLDPlayer);
			panel2.Dock = System.Windows.Forms.DockStyle.Fill;
			panel2.Location = new System.Drawing.Point(3, 26);
			panel2.Name = "panel2";
			panel2.Size = new System.Drawing.Size(471, 279);
			panel2.TabIndex = 0;
			pictureBox2.Image = ns5.Class74.icons8_x_30;
			pictureBox2.Location = new System.Drawing.Point(156, 94);
			pictureBox2.Name = "pictureBox2";
			pictureBox2.Size = new System.Drawing.Size(35, 30);
			pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
			pictureBox2.TabIndex = 4;
			pictureBox2.TabStop = false;
			ckAdbDebug.AutoSize = true;
			ckAdbDebug.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			ckAdbDebug.Location = new System.Drawing.Point(33, 232);
			ckAdbDebug.Name = "ckAdbDebug";
			ckAdbDebug.Size = new System.Drawing.Size(414, 24);
			ckAdbDebug.TabIndex = 0;
			ckAdbDebug.Text = "ADB Debug (Dành cho các phiên bản LDPlayer cao hơn)";
			ckAdbDebug.UseVisualStyleBackColor = true;
			ckAdbDebug.CheckedChanged += new System.EventHandler(chkAutoClearLD_CheckedChanged);
			chkAutoClearLD.AutoSize = true;
			chkAutoClearLD.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			chkAutoClearLD.Location = new System.Drawing.Point(32, 202);
			chkAutoClearLD.Name = "chkAutoClearLD";
			chkAutoClearLD.Size = new System.Drawing.Size(233, 24);
			chkAutoClearLD.TabIndex = 0;
			chkAutoClearLD.Text = "Tự động clear cache LDPlayer";
			chkAutoClearLD.UseVisualStyleBackColor = true;
			chkAutoClearLD.CheckedChanged += new System.EventHandler(chkAutoClearLD_CheckedChanged);
			nudSizeTo.Location = new System.Drawing.Point(197, 94);
			nudSizeTo.Maximum = new decimal(new int[4] { 1920, 0, 0, 0 });
			nudSizeTo.Name = "nudSizeTo";
			nudSizeTo.Size = new System.Drawing.Size(67, 30);
			nudSizeTo.TabIndex = 3;
			nudSizeTo.ValueChanged += new System.EventHandler(nudSizeFr_ValueChanged);
			nudDPILD.Location = new System.Drawing.Point(83, 131);
			nudDPILD.Maximum = new decimal(new int[4] { 1000, 0, 0, 0 });
			nudDPILD.Name = "nudDPILD";
			nudDPILD.Size = new System.Drawing.Size(67, 30);
			nudDPILD.TabIndex = 3;
			nudDPILD.ValueChanged += new System.EventHandler(nudSizeFr_ValueChanged);
			nudSizeFr.Location = new System.Drawing.Point(83, 94);
			nudSizeFr.Maximum = new decimal(new int[4] { 1920, 0, 0, 0 });
			nudSizeFr.Name = "nudSizeFr";
			nudSizeFr.Size = new System.Drawing.Size(67, 30);
			nudSizeFr.TabIndex = 3;
			nudSizeFr.ValueChanged += new System.EventHandler(nudSizeFr_ValueChanged);
			cbRamLD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbRamLD.FormattingEnabled = true;
			cbRamLD.Items.AddRange(new object[9] { "256M", "512M", "768M", "1024M (Khuyến nghị)", "1536M", "2048M", "3072M", "4096M", "8192M" });
			cbRamLD.Location = new System.Drawing.Point(83, 52);
			cbRamLD.Name = "cbRamLD";
			cbRamLD.Size = new System.Drawing.Size(233, 31);
			cbRamLD.TabIndex = 2;
			label4.AutoSize = true;
			label4.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label4.Location = new System.Drawing.Point(28, 135);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(37, 20);
			label4.TabIndex = 1;
			label4.Text = "DPI:";
			label4.Click += new System.EventHandler(label3_Click);
			label3.AutoSize = true;
			label3.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label3.Location = new System.Drawing.Point(28, 101);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(42, 20);
			label3.TabIndex = 1;
			label3.Text = "SIZE:";
			label3.Click += new System.EventHandler(label3_Click);
			label2.AutoSize = true;
			label2.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label2.Location = new System.Drawing.Point(28, 57);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(46, 20);
			label2.TabIndex = 1;
			label2.Text = "RAM:";
			cbCPULD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			cbCPULD.FormattingEnabled = true;
			cbCPULD.Items.AddRange(new object[5] { "1 cores (Khuyến nghị)", "2 cores", "3 cores", "4 cores", "6 cores" });
			cbCPULD.Location = new System.Drawing.Point(83, 10);
			cbCPULD.Name = "cbCPULD";
			cbCPULD.Size = new System.Drawing.Size(233, 31);
			cbCPULD.TabIndex = 2;
			label1.AutoSize = true;
			label1.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			label1.Location = new System.Drawing.Point(28, 15);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(42, 20);
			label1.TabIndex = 1;
			label1.Text = "CPU:";
			cbTurnOnLDPlayer.AutoSize = true;
			cbTurnOnLDPlayer.Font = new System.Drawing.Font("Segoe UI Semibold", 9f, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
			cbTurnOnLDPlayer.Location = new System.Drawing.Point(32, 172);
			cbTurnOnLDPlayer.Name = "cbTurnOnLDPlayer";
			cbTurnOnLDPlayer.Size = new System.Drawing.Size(149, 24);
			cbTurnOnLDPlayer.TabIndex = 0;
			cbTurnOnLDPlayer.Text = "Bật GPS LDPlayer";
			cbTurnOnLDPlayer.UseVisualStyleBackColor = true;
			cbTurnOnLDPlayer.CheckedChanged += new System.EventHandler(cbTurnOnLDPlayer_CheckedChanged);
			bunifuDragControl_0.Fixed = true;
			bunifuDragControl_0.Horizontal = true;
			bunifuDragControl_0.TargetControl = panel4;
			bunifuDragControl_0.Vertical = true;
			bunifuDragControl_1.Fixed = true;
			bunifuDragControl_1.Horizontal = true;
			bunifuDragControl_1.TargetControl = label28;
			bunifuDragControl_1.Vertical = true;
			base.AutoScaleDimensions = new System.Drawing.SizeF(8f, 16f);
			base.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			base.ClientSize = new System.Drawing.Size(1150, 450);
			base.Controls.Add(panel1);
			base.Controls.Add(panel4);
			base.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
			base.Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
			base.Name = "frmAutoFunction";
			base.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			Text = "Cấu hình nâng cao";
			panel4.ResumeLayout(false);
			panel4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
			panel1.ResumeLayout(false);
			groupBox2.ResumeLayout(false);
			panel3.ResumeLayout(false);
			panel3.PerformLayout();
			groupBox1.ResumeLayout(false);
			panel2.ResumeLayout(false);
			panel2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSizeTo).EndInit();
			((System.ComponentModel.ISupportInitialize)nudDPILD).EndInit();
			((System.ComponentModel.ISupportInitialize)nudSizeFr).EndInit();
			ResumeLayout(false);
		}
	}
}
