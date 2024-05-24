using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;

namespace WizardModule.Views.Controls
{
	// Token: 0x02000057 RID: 87
	public partial class DetailButton : UserControl
	{
		// Token: 0x060004C7 RID: 1223 RVA: 0x0000AF13 File Offset: 0x00009113
		public DetailButton()
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.IsUpgradeMode = false;
		}

		// Token: 0x17000397 RID: 919
		// (get) Token: 0x060004C8 RID: 1224 RVA: 0x0000AF43 File Offset: 0x00009143
		// (set) Token: 0x060004C9 RID: 1225 RVA: 0x0000AF55 File Offset: 0x00009155
		public ImageSource Source
		{
			get
			{
				return (ImageSource)base.GetValue(DetailButton.SourceProperty);
			}
			set
			{
				base.SetValue(DetailButton.SourceProperty, value);
			}
		}

		// Token: 0x17000398 RID: 920
		// (get) Token: 0x060004CA RID: 1226 RVA: 0x0000AF63 File Offset: 0x00009163
		// (set) Token: 0x060004CB RID: 1227 RVA: 0x0000AF75 File Offset: 0x00009175
		public string Title
		{
			get
			{
				return (string)base.GetValue(DetailButton.TitleProperty);
			}
			set
			{
				base.SetValue(DetailButton.TitleProperty, value);
			}
		}

		// Token: 0x17000399 RID: 921
		// (get) Token: 0x060004CC RID: 1228 RVA: 0x0000AF83 File Offset: 0x00009183
		// (set) Token: 0x060004CD RID: 1229 RVA: 0x0000AF95 File Offset: 0x00009195
		public string Size
		{
			get
			{
				return (string)base.GetValue(DetailButton.SizeProperty);
			}
			set
			{
				base.SetValue(DetailButton.SizeProperty, value);
			}
		}

		// Token: 0x1700039A RID: 922
		// (get) Token: 0x060004CE RID: 1230 RVA: 0x0000AFA3 File Offset: 0x000091A3
		// (set) Token: 0x060004CF RID: 1231 RVA: 0x0000AFB5 File Offset: 0x000091B5
		public string SecondaryText
		{
			get
			{
				return (string)base.GetValue(DetailButton.SecondaryTextProperty);
			}
			set
			{
				base.SetValue(DetailButton.SecondaryTextProperty, value);
			}
		}

		// Token: 0x1700039B RID: 923
		// (get) Token: 0x060004D0 RID: 1232 RVA: 0x0000AFC3 File Offset: 0x000091C3
		// (set) Token: 0x060004D1 RID: 1233 RVA: 0x0000AFD5 File Offset: 0x000091D5
		public bool IsApplicationMode
		{
			get
			{
				return (bool)base.GetValue(DetailButton.IsApplicationModeProperty);
			}
			set
			{
				base.SetValue(DetailButton.IsApplicationModeProperty, value);
			}
		}

		// Token: 0x1700039C RID: 924
		// (get) Token: 0x060004D2 RID: 1234 RVA: 0x0000AFE8 File Offset: 0x000091E8
		// (set) Token: 0x060004D3 RID: 1235 RVA: 0x0000AFFA File Offset: 0x000091FA
		public bool IsFileMode
		{
			get
			{
				return (bool)base.GetValue(DetailButton.IsFileModeProperty);
			}
			set
			{
				base.SetValue(DetailButton.IsFileModeProperty, value);
			}
		}

		// Token: 0x1700039D RID: 925
		// (get) Token: 0x060004D4 RID: 1236 RVA: 0x0000B00D File Offset: 0x0000920D
		// (set) Token: 0x060004D5 RID: 1237 RVA: 0x0000B01F File Offset: 0x0000921F
		public bool IsUsersMode
		{
			get
			{
				return (bool)base.GetValue(DetailButton.IsUsersModeProperty);
			}
			set
			{
				base.SetValue(DetailButton.IsUsersModeProperty, value);
			}
		}

		// Token: 0x1700039E RID: 926
		// (get) Token: 0x060004D6 RID: 1238 RVA: 0x0000B032 File Offset: 0x00009232
		// (set) Token: 0x060004D7 RID: 1239 RVA: 0x0000B044 File Offset: 0x00009244
		public bool IsUpgradeMode
		{
			get
			{
				return (bool)base.GetValue(DetailButton.IsUpgradeModeProperty);
			}
			set
			{
				base.SetValue(DetailButton.IsUpgradeModeProperty, value);
			}
		}

		// Token: 0x1700039F RID: 927
		// (get) Token: 0x060004D8 RID: 1240 RVA: 0x0000B057 File Offset: 0x00009257
		// (set) Token: 0x060004D9 RID: 1241 RVA: 0x0000B069 File Offset: 0x00009269
		public int FileCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.FileCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.FileCountProperty, value);
			}
		}

		// Token: 0x170003A0 RID: 928
		// (get) Token: 0x060004DA RID: 1242 RVA: 0x0000B07C File Offset: 0x0000927C
		// (set) Token: 0x060004DB RID: 1243 RVA: 0x0000B08E File Offset: 0x0000928E
		public int FolderCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.FolderCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.FolderCountProperty, value);
			}
		}

		// Token: 0x170003A1 RID: 929
		// (get) Token: 0x060004DC RID: 1244 RVA: 0x0000B0A1 File Offset: 0x000092A1
		// (set) Token: 0x060004DD RID: 1245 RVA: 0x0000B0B3 File Offset: 0x000092B3
		public string UsersCount
		{
			get
			{
				return (string)base.GetValue(DetailButton.UsersCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.UsersCountProperty, value);
			}
		}

		// Token: 0x170003A2 RID: 930
		// (get) Token: 0x060004DE RID: 1246 RVA: 0x0000B0C1 File Offset: 0x000092C1
		// (set) Token: 0x060004DF RID: 1247 RVA: 0x0000B0D3 File Offset: 0x000092D3
		public int GreenCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.GreenCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.GreenCountProperty, value);
			}
		}

		// Token: 0x170003A3 RID: 931
		// (get) Token: 0x060004E0 RID: 1248 RVA: 0x0000B0E6 File Offset: 0x000092E6
		// (set) Token: 0x060004E1 RID: 1249 RVA: 0x0000B0F8 File Offset: 0x000092F8
		public int YellowCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.YellowCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.YellowCountProperty, value);
			}
		}

		// Token: 0x170003A4 RID: 932
		// (get) Token: 0x060004E2 RID: 1250 RVA: 0x0000B10B File Offset: 0x0000930B
		// (set) Token: 0x060004E3 RID: 1251 RVA: 0x0000B11D File Offset: 0x0000931D
		public int RedCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.RedCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.RedCountProperty, value);
			}
		}

		// Token: 0x170003A5 RID: 933
		// (get) Token: 0x060004E4 RID: 1252 RVA: 0x0000B130 File Offset: 0x00009330
		// (set) Token: 0x060004E5 RID: 1253 RVA: 0x0000B142 File Offset: 0x00009342
		public int GreenSelectedCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.GreenSelectedCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.GreenSelectedCountProperty, value);
			}
		}

		// Token: 0x170003A6 RID: 934
		// (get) Token: 0x060004E6 RID: 1254 RVA: 0x0000B155 File Offset: 0x00009355
		// (set) Token: 0x060004E7 RID: 1255 RVA: 0x0000B167 File Offset: 0x00009367
		public int YellowSelectedCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.YellowSelectedCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.YellowSelectedCountProperty, value);
			}
		}

		// Token: 0x170003A7 RID: 935
		// (get) Token: 0x060004E8 RID: 1256 RVA: 0x0000B17A File Offset: 0x0000937A
		// (set) Token: 0x060004E9 RID: 1257 RVA: 0x0000B18C File Offset: 0x0000938C
		public int RedSelectedCount
		{
			get
			{
				return (int)base.GetValue(DetailButton.RedSelectedCountProperty);
			}
			set
			{
				base.SetValue(DetailButton.RedSelectedCountProperty, value);
			}
		}

		// Token: 0x170003A8 RID: 936
		// (get) Token: 0x060004EA RID: 1258 RVA: 0x0000B19F File Offset: 0x0000939F
		// (set) Token: 0x060004EB RID: 1259 RVA: 0x0000B1B1 File Offset: 0x000093B1
		public ICommand Command
		{
			get
			{
				return (ICommand)base.GetValue(DetailButton.CommandProperty);
			}
			set
			{
				base.SetValue(DetailButton.CommandProperty, value);
			}
		}

		// Token: 0x040000B8 RID: 184
		public static readonly DependencyProperty SourceProperty = DependencyProperty.Register("Source", typeof(ImageSource), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000B9 RID: 185
		public static readonly DependencyProperty TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BA RID: 186
		public static readonly DependencyProperty SizeProperty = DependencyProperty.Register("Size", typeof(string), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BB RID: 187
		public static readonly DependencyProperty SecondaryTextProperty = DependencyProperty.Register("SecondaryText", typeof(string), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BC RID: 188
		public static readonly DependencyProperty IsApplicationModeProperty = DependencyProperty.Register("IsApplicationMode", typeof(bool), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BD RID: 189
		public static readonly DependencyProperty IsFileModeProperty = DependencyProperty.Register("IsFileMode", typeof(bool), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BE RID: 190
		public static readonly DependencyProperty IsUsersModeProperty = DependencyProperty.Register("IsUsersMode", typeof(bool), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000BF RID: 191
		public static readonly DependencyProperty IsUpgradeModeProperty = DependencyProperty.Register("IsUpgradeMode", typeof(bool), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C0 RID: 192
		public static readonly DependencyProperty FileCountProperty = DependencyProperty.Register("FileCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C1 RID: 193
		public static readonly DependencyProperty FolderCountProperty = DependencyProperty.Register("FolderCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C2 RID: 194
		public static readonly DependencyProperty UsersCountProperty = DependencyProperty.Register("UsersCount", typeof(string), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C3 RID: 195
		public static readonly DependencyProperty GreenCountProperty = DependencyProperty.Register("GreenCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C4 RID: 196
		public static readonly DependencyProperty YellowCountProperty = DependencyProperty.Register("YellowCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C5 RID: 197
		public static readonly DependencyProperty RedCountProperty = DependencyProperty.Register("RedCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C6 RID: 198
		public static readonly DependencyProperty GreenSelectedCountProperty = DependencyProperty.Register("GreenSelectedCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C7 RID: 199
		public static readonly DependencyProperty YellowSelectedCountProperty = DependencyProperty.Register("YellowSelectedCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C8 RID: 200
		public static readonly DependencyProperty RedSelectedCountProperty = DependencyProperty.Register("RedSelectedCount", typeof(int), typeof(DetailButton), new PropertyMetadata(null));

		// Token: 0x040000C9 RID: 201
		public static readonly DependencyProperty CommandProperty = DependencyProperty.Register("Command", typeof(ICommand), typeof(DetailButton), new UIPropertyMetadata(null));
	}
}
