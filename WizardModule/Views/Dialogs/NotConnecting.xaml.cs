using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels.Dialogs;

namespace WizardModule.Views.Dialogs
{
	// Token: 0x02000054 RID: 84
	public partial class NotConnecting : UserControl
	{
		// Token: 0x060004B6 RID: 1206 RVA: 0x0000AC87 File Offset: 0x00008E87
		public NotConnecting(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
