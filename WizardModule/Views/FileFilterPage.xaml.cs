using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels;

namespace WizardModule.Views
{
	// Token: 0x02000027 RID: 39
	public partial class FileFilterPage : UserControl
	{
		// Token: 0x06000416 RID: 1046 RVA: 0x000090ED File Offset: 0x000072ED
		public FileFilterPage(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}

		// Token: 0x06000417 RID: 1047 RVA: 0x00009127 File Offset: 0x00007327
		private void Popup_Opened(object sender, EventArgs e)
		{
			this.FileSpec.Focus();
		}
	}
}
