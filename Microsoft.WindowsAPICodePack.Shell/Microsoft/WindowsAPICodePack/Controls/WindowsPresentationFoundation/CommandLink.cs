using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using MS.WindowsAPICodePack.Internal;

namespace Microsoft.WindowsAPICodePack.Controls.WindowsPresentationFoundation
{
	// Token: 0x0200001D RID: 29
	public class CommandLink : UserControl, INotifyPropertyChanged, IComponentConnector
	{
		// Token: 0x06000103 RID: 259 RVA: 0x00005E3F File Offset: 0x0000403F
		public CommandLink()
		{
			CoreHelpers.ThrowIfNotVista();
			base.DataContext = this;
			this.InitializeComponent();
			this.button.Click += this.button_Click;
		}

		// Token: 0x06000104 RID: 260 RVA: 0x00005E78 File Offset: 0x00004078
		private void button_Click(object sender, RoutedEventArgs e)
		{
			e.Source = this;
			if (this.Click != null)
			{
				this.Click(sender, e);
			}
		}

		// Token: 0x17000043 RID: 67
		// (get) Token: 0x06000105 RID: 261 RVA: 0x00005EAC File Offset: 0x000040AC
		// (set) Token: 0x06000106 RID: 262 RVA: 0x00005EC3 File Offset: 0x000040C3
		public RoutedUICommand Command { get; set; }

		// Token: 0x14000001 RID: 1
		// (add) Token: 0x06000107 RID: 263 RVA: 0x00005ECC File Offset: 0x000040CC
		// (remove) Token: 0x06000108 RID: 264 RVA: 0x00005F08 File Offset: 0x00004108
		public event RoutedEventHandler Click;

		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000109 RID: 265 RVA: 0x00005F44 File Offset: 0x00004144
		// (set) Token: 0x0600010A RID: 266 RVA: 0x00005F5C File Offset: 0x0000415C
		public string Link
		{
			get
			{
				return this.link;
			}
			set
			{
				this.link = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Link"));
				}
			}
		}

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x0600010B RID: 267 RVA: 0x00005F98 File Offset: 0x00004198
		// (set) Token: 0x0600010C RID: 268 RVA: 0x00005FB0 File Offset: 0x000041B0
		public string Note
		{
			get
			{
				return this.note;
			}
			set
			{
				this.note = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Note"));
				}
			}
		}

		// Token: 0x17000046 RID: 70
		// (get) Token: 0x0600010D RID: 269 RVA: 0x00005FEC File Offset: 0x000041EC
		// (set) Token: 0x0600010E RID: 270 RVA: 0x00006004 File Offset: 0x00004204
		public ImageSource Icon
		{
			get
			{
				return this.icon;
			}
			set
			{
				this.icon = value;
				if (this.PropertyChanged != null)
				{
					this.PropertyChanged(this, new PropertyChangedEventArgs("Icon"));
				}
			}
		}

		// Token: 0x17000047 RID: 71
		// (get) Token: 0x0600010F RID: 271 RVA: 0x00006040 File Offset: 0x00004240
		// (set) Token: 0x06000110 RID: 272 RVA: 0x0000605D File Offset: 0x0000425D
		public bool? IsCheck
		{
			get
			{
				return this.button.IsChecked;
			}
			set
			{
				this.button.IsChecked = value;
			}
		}

		// Token: 0x14000002 RID: 2
		// (add) Token: 0x06000111 RID: 273 RVA: 0x00006070 File Offset: 0x00004270
		// (remove) Token: 0x06000112 RID: 274 RVA: 0x000060AC File Offset: 0x000042AC
		public event PropertyChangedEventHandler PropertyChanged;

		// Token: 0x17000048 RID: 72
		// (get) Token: 0x06000113 RID: 275 RVA: 0x000060E8 File Offset: 0x000042E8
		public static bool IsPlatformSupported
		{
			get
			{
				return CoreHelpers.RunningOnVista;
			}
		}

		// Token: 0x06000114 RID: 276 RVA: 0x00006100 File Offset: 0x00004300
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		public void InitializeComponent()
		{
			if (!this._contentLoaded)
			{
				this._contentLoaded = true;
				Uri resourceLocator = new Uri("/Microsoft.WindowsAPICodePack.Shell;component/controls/commandlinkwpf.xaml", UriKind.Relative);
				Application.LoadComponent(this, resourceLocator);
			}
		}

		// Token: 0x06000115 RID: 277 RVA: 0x0000613C File Offset: 0x0000433C
		[DebuggerNonUserCode]
		[GeneratedCode("PresentationBuildTasks", "4.0.0.0")]
		[EditorBrowsable(EditorBrowsableState.Never)]
		void IComponentConnector.Connect(int connectionId, object target)
		{
			if (connectionId != 1)
			{
				this._contentLoaded = true;
			}
			else
			{
				this.button = (RadioButton)target;
			}
		}

		// Token: 0x0400003F RID: 63
		private string link;

		// Token: 0x04000040 RID: 64
		private string note;

		// Token: 0x04000041 RID: 65
		private ImageSource icon;

		// Token: 0x04000043 RID: 67
		internal RadioButton button;

		// Token: 0x04000044 RID: 68
		private bool _contentLoaded;
	}
}
