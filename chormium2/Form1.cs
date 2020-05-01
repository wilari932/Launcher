using CefSharp;
using CefSharp.SchemeHandler;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace chormium2
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			var settings = new CefSettings();
			settings.CachePath = "chache";

			settings.CefCommandLineArgs.Add("enable-npapi", "1");

			settings.RegisterScheme(new CefCustomScheme
			{
				SchemeName = "localfolder",
				DomainName = "cefsharp",
				SchemeHandlerFactory = new FolderSchemeHandlerFactory(
			rootFolder: "LocalFolder",
			hostName: "cefsharp",
			defaultPage: "index.html" // will default to index.html
		)
			});

			//settings.CefCommandLineArgs.Remove("enable-system-flash");
			//settings.CefCommandLineArgs.Add("enable-system-flash", "1");
			Cef.Initialize(settings);
			var f = new FormState();
			f.Maximize(this);
			this.WindowState = FormWindowState.Maximized;

			var br = new BrowserSettings();
			br.WebGl = CefState.Enabled;
			br.WindowlessFrameRate = 60;
			var browser = new CefSharp.WinForms.ChromiumWebBrowser("localfolder://cefsharp/");
			browser.BrowserSettings = br;

		
			browser.KeyDown += (ob, ev) =>
			{
				if (ev.KeyCode == Keys.Escape)
					browser.ShowDevTools();
			};
			this.Controls.Add(browser);
			browser.Dock = DockStyle.Fill;
			
			

		}
	}
}
