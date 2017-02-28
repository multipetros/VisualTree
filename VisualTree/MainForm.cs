/* 
 * VisualTree: Main form
 * (c) 2017, Petros Kyladitis <http://www.multipetros.gr>
 * 
 * This is free software distributed under the GNU GPL 3, for license details see at license.txt 
 * file, distributed with this program source, or see at <http://www.gnu.org/licenses/>
 * 
 */
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO ;
using System.Diagnostics ;
using System.Resources;
using System.Globalization;
using Multipetros.Config ;

namespace VisualTree{
	public partial class MainForm : Form{
		//constant string representing registry setting key names
		private readonly string WND_TOP = "top" ;
		private readonly string WND_LEFT = "left" ;
		private readonly string WND_WIDTH = "width" ;
		private readonly string WND_HEIGHT = "height" ;
		private readonly string WND_FONT = "font" ;
		private readonly string WND_BG_COLOR = "bgcolor" ;
		private readonly string WND_COLOR = "color" ;
		private readonly string WND_LANG = "lang" ;
		private readonly string WND_ACSII_OPT = "ascii" ;
		private readonly string WND_FILES_OPT = "files" ;
		
		/*import kernel func to determinate system console codepage*/
		[System.Runtime.InteropServices.DllImport("kernel32.dll")]
		public static extern int GetSystemDefaultLCID();
		
		ResourceManager resmgr ;
		string[] langs = new string[]{"en","el"} ; //available language resources
		CultureInfo ci ;
		RegistryIni ini = new RegistryIni(Application.CompanyName, Application.ProductName) ;
		
		public MainForm(){
			InitializeComponent();
			resmgr = new ResourceManager(typeof(MainForm)) ;
		}
		
		private int GetConsoleCodepage(){
			int lcid = GetSystemDefaultLCID();
			System.Globalization.CultureInfo sysCulture = System.Globalization.CultureInfo.GetCultureInfo(lcid);
			return sysCulture.TextInfo.OEMCodePage;			
		}
		
		private void GenerateTree(string folder){
			if(Directory.Exists(folder)){								
				selectFolderToolStripMenuItem.Enabled = false ;
				saveTreeToolStripMenuItem.Enabled = false ;
				textBoxResults.Clear() ;
				
				string args = "" ;
				if(aSCIINodesToolStripMenuItem.Checked) args += "/a " ;
				if(viewFilesToolStripMenuItem.Checked) args += "/f " ;
				
				Process treeCmd = new Process() ;
   				treeCmd.StartInfo.FileName = "tree.com" ;
   				treeCmd.StartInfo.Arguments = "\"" + folder + "\" " + args ;
   				treeCmd.StartInfo.RedirectStandardOutput = true ;
   				treeCmd.StartInfo.CreateNoWindow = true ;
   				treeCmd.StartInfo.UseShellExecute = false ;
  				treeCmd.StartInfo.StandardOutputEncoding = System.Text.Encoding.GetEncoding(GetConsoleCodepage()) ;
  				
   				treeCmd.EnableRaisingEvents = true ;
   				treeCmd.OutputDataReceived += new DataReceivedEventHandler(treeCmd_OutputDataReceived) ;
   				treeCmd.Exited += new EventHandler(treeCmd_Exited) ;
   				treeCmd.Start() ;
  				treeCmd.BeginOutputReadLine() ;
			}else{
				MessageBox.Show(GetRes("ErrorFolderNotFoundMsg"), GetRes("ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error) ;
			}
		}
		
		void treeCmd_OutputDataReceived(object sender, DataReceivedEventArgs e){  
            if(textBoxResults.InvokeRequired && !String.IsNullOrEmpty(e.Data)){
				textBoxResults.Invoke(new MethodInvoker(
					delegate() { 
						textBoxResults.AppendText(e.Data+"\r\n") ; 
					} 
				) );
			}
        }
		
		//when tree command end, make select folder and save tree menu
		//items enabled, checking firstly if delegation needed and do it
		void treeCmd_Exited( object sender, EventArgs e ){
			if(selectFolderToolStripMenuItem.GetCurrentParent().InvokeRequired){
                selectFolderToolStripMenuItem.GetCurrentParent().Invoke(new MethodInvoker( 
				    delegate() {
                		selectFolderToolStripMenuItem.Enabled = true; 
				    } 
				) );
			} else{
				selectFolderToolStripMenuItem.Enabled = true; 
			}
			if(saveTreeToolStripMenuItem.GetCurrentParent().InvokeRequired){  
                saveTreeToolStripMenuItem.GetCurrentParent().Invoke(new MethodInvoker(
					delegate() {
                		saveTreeToolStripMenuItem.Enabled = true; 
					}
				) );
			} else{
				saveTreeToolStripMenuItem.Enabled = true; 
			}
        } 
		
		void SelectFolderToolStripMenuItemClick(object sender, EventArgs e){
			DialogResult result = folderBrowserDialog.ShowDialog() ;
			if(result == DialogResult.OK){
				GenerateTree(folderBrowserDialog.SelectedPath) ;
			}
		}
		
		void SaveTreeToolStripMenuItemClick(object sender, EventArgs e){
			DialogResult result = saveFileDialog.ShowDialog() ;
			if(result == DialogResult.OK){
				try {
					File.WriteAllText(saveFileDialog.FileName, textBoxResults.Text) ;
				} catch (Exception err) {
					MessageBox.Show(err.Message, GetRes("ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				}
			}
		}
		
		void ExitToolStripMenuItemClick(object sender, EventArgs e){
			Application.Exit() ;
		}
		
		void AboutToolStripMenuItemClick(object sender, EventArgs e){
			MessageBox.Show(GetRes("AboutMsg"), GetRes("AboutTitle"), MessageBoxButtons.OK, MessageBoxIcon.Information) ;
		}
		
		void TextBoxResultsDragDrop(object sender, DragEventArgs e){			
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				string[] dirs = (string[])e.Data.GetData(DataFormats.FileDrop);
				if(Directory.Exists(dirs[0])){
					GenerateTree(dirs[0]) ;
				}else{
					MessageBox.Show(GetRes("ErrorDnDMsg"), GetRes("ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error) ;
				}
			}
		}
		
		void TextBoxResultsDragEnter(object sender, DragEventArgs e){
			if(e.Data.GetDataPresent(DataFormats.FileDrop)){
				e.Effect = DragDropEffects.Copy ;
			}
		}
		
		void EnglishToolStripMenuItemClick(object sender, EventArgs e){
			ci = new CultureInfo("en") ;
			LoadUIText() ;
		}
		
		void GreekToolStripMenuItemClick(object sender, EventArgs e){
			ci = new CultureInfo("el") ;
			LoadUIText() ;
		}
		
		string GetRes(string key){
			return resmgr.GetString(key, ci) ;
		}
		
		void FontToolStripMenuItemClick(object sender, EventArgs e){
			fontDialog.Font = textBoxResults.Font ;
			fontDialog.Color = textBoxResults.ForeColor ;
			DialogResult result = DialogResult.Abort ;
			try{
				result = fontDialog.ShowDialog() ;
			}catch(Exception err) {
				MessageBox.Show(err.Message, GetRes("ErrorTitle"), MessageBoxButtons.OK, MessageBoxIcon.Error) ;
			}
			if(result == DialogResult.OK){
				textBoxResults.Font = fontDialog.Font ;	
				textBoxResults.ForeColor = fontDialog.Color ;
			}
		}
		
		void BackgroundColorToolStripMenuItemClick(object sender, EventArgs e){
			colorDialog.Color = textBoxResults.BackColor ;
			DialogResult result = colorDialog.ShowDialog() ;
			if(result == DialogResult.OK){
				textBoxResults.BackColor = colorDialog.Color ;
			}
		}
		
		void MainFormLoad(object sender, System.EventArgs e){
			LoadSettings() ;
			LoadUIText() ;
		}
		
		void MainFormFormClosed(object sender, FormClosedEventArgs e){
			SaveSettings() ;
		}
		
		private void LoadUIText(){
			fileToolStripMenuItem.Text = GetRes("MenuFile");
			selectFolderToolStripMenuItem.Text = GetRes("MenuSelectFolder");
			saveTreeToolStripMenuItem.Text = GetRes("MenuSaveTree");
			exitToolStripMenuItem.Text = GetRes("MenuExit");
			settingsToolStripMenuItem.Text = GetRes("MenuSettings");
			fontToolStripMenuItem.Text = GetRes("MenuFont");
			backgroundColorToolStripMenuItem.Text = GetRes("MenuBackgroundColor");
			aSCIINodesToolStripMenuItem.Text = GetRes("MenuASCIINodes");
			languageToolStripMenuItem.Text = GetRes("MenuLanguage");
			aboutToolStripMenuItem.Text = GetRes("MenuAbout");
			viewFilesToolStripMenuItem.Text = GetRes("MenuViewFiles") ;
			saveFileDialog.Filter = GetRes("FileDialogFilter");
		}
		
		//Load settings from the registry and aply them to main window,
		//such as last position, dimensions and font family & size
		private void LoadSettings(){
			int top  ;
			int left  ;
			int height  ;
			int width  ;
			
			int.TryParse(ini[WND_TOP], out top) ;
			int.TryParse(ini[WND_LEFT], out left) ;
			int.TryParse(ini[WND_WIDTH], out width) ;
			int.TryParse(ini[WND_HEIGHT], out height) ;
			
			if(top > 0)
				Top = top ;
			
			if(left > 0)
				Left = left ;
			
			if(height >= MinimumSize.Height)
				Height = height ;
			
			if(width >= MinimumSize.Width)
				Width = width ;
			
			//load font 'serialized' string and convert it into a Font object, via the FontConverter class
			string fontStr = ini[WND_FONT] ;
			if(fontStr != ""){
				FontConverter fontCon = new FontConverter() ;
				try{
					Font fontObj = (Font)fontCon.ConvertFromString(fontStr) ;
					textBoxResults.Font = fontObj ;
				}catch(Exception){ }			
			}
			
			//load text fore color 'serialized' string and convert it into a Color struct, via the ColorConverter class
			string colorStr = ini[WND_COLOR] ;
			if(colorStr != ""){
				ColorConverter colorCon = new ColorConverter() ;
				try {
					Color color = (Color)colorCon.ConvertFromString(colorStr) ;
					textBoxResults.ForeColor = color ;
				} catch (Exception) { }
			}
			
			//load text background color 'serialized' string and convert it into a Color struct, via the ColorConverter class
			string bgColorStr = ini[WND_BG_COLOR] ;
			if(bgColorStr != ""){
				ColorConverter colorCon = new ColorConverter() ;
				try {
					Color bgcolor = (Color)colorCon.ConvertFromString(bgColorStr) ;
					textBoxResults.BackColor = bgcolor ;
				} catch (Exception) { }
			}
			
			string lang = ini[WND_LANG] ;
			if(lang != "" && (Array.IndexOf(langs, lang) >= 0)){
				ci = new CultureInfo(lang) ;
			}else{
				lang = CultureInfo.CurrentCulture.TwoLetterISOLanguageName ;
				if(Array.IndexOf(langs, lang) > -1){
					ci = CultureInfo.CurrentCulture ;
				}else{			
					lang = langs[0] ;
					ci = new CultureInfo(lang) ;
				}
			}
			
			string asciiStr = ini[WND_ACSII_OPT] ;
			bool asciiOpt = false ;
			bool.TryParse(asciiStr, out asciiOpt) ;
			aSCIINodesToolStripMenuItem.Checked = asciiOpt ;
			
			string viewFilesStr = ini[WND_FILES_OPT] ;
			bool viewFilesOpt = true ;
			bool.TryParse(viewFilesStr, out viewFilesOpt) ;
			viewFilesToolStripMenuItem.Checked = viewFilesOpt ;
		}

		//Save settings to the registry, such as last position, dimensions and font
		private void SaveSettings(){
			ini[WND_TOP] = Top.ToString() ;
			ini[WND_LEFT] = Left.ToString() ;
			ini[WND_WIDTH] = Width.ToString() ;
			ini[WND_HEIGHT] = Height.ToString() ;
			
			//use FontConverter call to 'serialize' the current Font object into string
			FontConverter fontCon = new FontConverter() ;
			ini[WND_FONT] = fontCon.ConvertToString(textBoxResults.Font) ;
			
			//use ColorConverter call to 'serialize' the current Color struct into string
			ColorConverter colorCon = new ColorConverter() ;
			ini[WND_COLOR] = colorCon.ConvertToString(textBoxResults.ForeColor) ;
			ini[WND_BG_COLOR] = colorCon.ConvertToString(textBoxResults.BackColor) ;
			
			ini[WND_LANG] = ci.TwoLetterISOLanguageName ;
			
			ini[WND_ACSII_OPT] = aSCIINodesToolStripMenuItem.Checked.ToString() ;
			ini[WND_FILES_OPT] = viewFilesToolStripMenuItem.Checked.ToString() ;
			
		}
		
		void ASCIINodesToolStripMenuItemClick(object sender, EventArgs e){
			aSCIINodesToolStripMenuItem.Checked = !aSCIINodesToolStripMenuItem.Checked ;
		}
		
		void ViewFilesToolStripMenuItemClick(object sender, EventArgs e){
			viewFilesToolStripMenuItem.Checked = !viewFilesToolStripMenuItem.Checked ;
		}
	}
}
