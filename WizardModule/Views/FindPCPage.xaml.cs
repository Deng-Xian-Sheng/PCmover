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
	// Token: 0x0200002E RID: 46
	public partial class FindPCPage : UserControl
	{
		// Token: 0x0600042C RID: 1068 RVA: 0x00009529 File Offset: 0x00007729
		public FindPCPage(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}

		// Token: 0x0600042D RID: 1069 RVA: 0x00009563 File Offset: 0x00007763
		private void RequestHostPopup_Opened(object sender, EventArgs e)
		{
			this.TBHost.SelectAll();
			this.TBHost.Focus();
		}
	}
}
