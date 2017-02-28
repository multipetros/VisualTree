/* 
 * VisualTree: Main form designer partial class
 * (c) 2017, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */
namespace VisualTree
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
			this.menuStripMain = new System.Windows.Forms.MenuStrip();
			this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.selectFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.saveTreeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.backgroundColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aSCIINodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.viewFilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.languageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.englishToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.greekToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
			this.textBoxResults = new System.Windows.Forms.TextBox();
			this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.fontDialog = new System.Windows.Forms.FontDialog();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
			this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
			this.menuStripMain.SuspendLayout();
			this.SuspendLayout();
			// 
			// menuStripMain
			// 
			this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fileToolStripMenuItem,
									this.settingsToolStripMenuItem,
									this.languageToolStripMenuItem,
									this.aboutToolStripMenuItem});
			this.menuStripMain.Location = new System.Drawing.Point(0, 0);
			this.menuStripMain.Name = "menuStripMain";
			this.menuStripMain.Size = new System.Drawing.Size(483, 24);
			this.menuStripMain.TabIndex = 0;
			this.menuStripMain.Text = "menuStrip1";
			// 
			// fileToolStripMenuItem
			// 
			this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.selectFolderToolStripMenuItem,
									this.saveTreeToolStripMenuItem,
									this.toolStripSeparator1,
									this.exitToolStripMenuItem});
			this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
			this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
			this.fileToolStripMenuItem.Text = "File";
			// 
			// selectFolderToolStripMenuItem
			// 
			this.selectFolderToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("selectFolderToolStripMenuItem.Image")));
			this.selectFolderToolStripMenuItem.Name = "selectFolderToolStripMenuItem";
			this.selectFolderToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
			this.selectFolderToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.selectFolderToolStripMenuItem.Text = "Select Folder";
			this.selectFolderToolStripMenuItem.Click += new System.EventHandler(this.SelectFolderToolStripMenuItemClick);
			// 
			// saveTreeToolStripMenuItem
			// 
			this.saveTreeToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("saveTreeToolStripMenuItem.Image")));
			this.saveTreeToolStripMenuItem.Name = "saveTreeToolStripMenuItem";
			this.saveTreeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
			this.saveTreeToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.saveTreeToolStripMenuItem.Text = "Save Tree";
			this.saveTreeToolStripMenuItem.Click += new System.EventHandler(this.SaveTreeToolStripMenuItemClick);
			// 
			// exitToolStripMenuItem
			// 
			this.exitToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("exitToolStripMenuItem.Image")));
			this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
			this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
			this.exitToolStripMenuItem.Size = new System.Drawing.Size(184, 22);
			this.exitToolStripMenuItem.Text = "Exit";
			this.exitToolStripMenuItem.Click += new System.EventHandler(this.ExitToolStripMenuItemClick);
			// 
			// settingsToolStripMenuItem
			// 
			this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.fontToolStripMenuItem,
									this.backgroundColorToolStripMenuItem,
									this.toolStripSeparator2,
									this.aSCIINodesToolStripMenuItem,
									this.viewFilesToolStripMenuItem});
			this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
			this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
			this.settingsToolStripMenuItem.Text = "Settings";
			// 
			// fontToolStripMenuItem
			// 
			this.fontToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("fontToolStripMenuItem.Image")));
			this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
			this.fontToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.fontToolStripMenuItem.Text = "Font";
			this.fontToolStripMenuItem.Click += new System.EventHandler(this.FontToolStripMenuItemClick);
			// 
			// backgroundColorToolStripMenuItem
			// 
			this.backgroundColorToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("backgroundColorToolStripMenuItem.Image")));
			this.backgroundColorToolStripMenuItem.Name = "backgroundColorToolStripMenuItem";
			this.backgroundColorToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.backgroundColorToolStripMenuItem.Text = "Background color";
			this.backgroundColorToolStripMenuItem.Click += new System.EventHandler(this.BackgroundColorToolStripMenuItemClick);
			// 
			// aSCIINodesToolStripMenuItem
			// 
			this.aSCIINodesToolStripMenuItem.Name = "aSCIINodesToolStripMenuItem";
			this.aSCIINodesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.aSCIINodesToolStripMenuItem.Text = "ASCII nodes";
			this.aSCIINodesToolStripMenuItem.Click += new System.EventHandler(this.ASCIINodesToolStripMenuItemClick);
			// 
			// viewFilesToolStripMenuItem
			// 
			this.viewFilesToolStripMenuItem.Name = "viewFilesToolStripMenuItem";
			this.viewFilesToolStripMenuItem.Size = new System.Drawing.Size(168, 22);
			this.viewFilesToolStripMenuItem.Text = "View files";
			this.viewFilesToolStripMenuItem.Click += new System.EventHandler(this.ViewFilesToolStripMenuItemClick);
			// 
			// languageToolStripMenuItem
			// 
			this.languageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
									this.englishToolStripMenuItem,
									this.greekToolStripMenuItem});
			this.languageToolStripMenuItem.Name = "languageToolStripMenuItem";
			this.languageToolStripMenuItem.Size = new System.Drawing.Size(71, 20);
			this.languageToolStripMenuItem.Text = "Language";
			// 
			// englishToolStripMenuItem
			// 
			this.englishToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("englishToolStripMenuItem.Image")));
			this.englishToolStripMenuItem.Name = "englishToolStripMenuItem";
			this.englishToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.englishToolStripMenuItem.Text = "Englis&h";
			this.englishToolStripMenuItem.Click += new System.EventHandler(this.EnglishToolStripMenuItemClick);
			// 
			// greekToolStripMenuItem
			// 
			this.greekToolStripMenuItem.Image = ((System.Drawing.Image)(resources.GetObject("greekToolStripMenuItem.Image")));
			this.greekToolStripMenuItem.Name = "greekToolStripMenuItem";
			this.greekToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
			this.greekToolStripMenuItem.Text = "Ελλ&ηνικά";
			this.greekToolStripMenuItem.Click += new System.EventHandler(this.GreekToolStripMenuItemClick);
			// 
			// aboutToolStripMenuItem
			// 
			this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
			this.aboutToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
			this.aboutToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
			this.aboutToolStripMenuItem.Text = "About";
			this.aboutToolStripMenuItem.Click += new System.EventHandler(this.AboutToolStripMenuItemClick);
			// 
			// textBoxResults
			// 
			this.textBoxResults.AllowDrop = true;
			this.textBoxResults.BackColor = System.Drawing.SystemColors.Window;
			this.textBoxResults.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxResults.Font = new System.Drawing.Font("Consolas", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
			this.textBoxResults.Location = new System.Drawing.Point(0, 24);
			this.textBoxResults.MaxLength = 0;
			this.textBoxResults.Multiline = true;
			this.textBoxResults.Name = "textBoxResults";
			this.textBoxResults.ReadOnly = true;
			this.textBoxResults.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxResults.Size = new System.Drawing.Size(483, 314);
			this.textBoxResults.TabIndex = 1;
			this.textBoxResults.DragDrop += new System.Windows.Forms.DragEventHandler(this.TextBoxResultsDragDrop);
			this.textBoxResults.DragEnter += new System.Windows.Forms.DragEventHandler(this.TextBoxResultsDragEnter);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.DefaultExt = "txt";
			this.saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
			// 
			// fontDialog
			// 
			this.fontDialog.FontMustExist = true;
			this.fontDialog.ShowColor = true;
			// 
			// toolStripSeparator1
			// 
			this.toolStripSeparator1.Name = "toolStripSeparator1";
			this.toolStripSeparator1.Size = new System.Drawing.Size(181, 6);
			// 
			// toolStripSeparator2
			// 
			this.toolStripSeparator2.Name = "toolStripSeparator2";
			this.toolStripSeparator2.Size = new System.Drawing.Size(165, 6);
			// 
			// MainForm
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(483, 338);
			this.Controls.Add(this.textBoxResults);
			this.Controls.Add(this.menuStripMain);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MainMenuStrip = this.menuStripMain;
			this.MinimumSize = new System.Drawing.Size(499, 376);
			this.Name = "MainForm";
			this.Text = "VisualTree";
			this.Load += new System.EventHandler(this.MainFormLoad);
			this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainFormFormClosed);
			this.menuStripMain.ResumeLayout(false);
			this.menuStripMain.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();
		}
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
		private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
		private System.Windows.Forms.ToolStripMenuItem viewFilesToolStripMenuItem;
		private System.Windows.Forms.ColorDialog colorDialog;
		private System.Windows.Forms.FontDialog fontDialog;
		private System.Windows.Forms.ToolStripMenuItem greekToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem englishToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem languageToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aSCIINodesToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem backgroundColorToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
		private System.Windows.Forms.TextBox textBoxResults;
		private System.Windows.Forms.ToolStripMenuItem saveTreeToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem selectFolderToolStripMenuItem;
		private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
		private System.Windows.Forms.MenuStrip menuStripMain;
	}
}
