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
	// Token: 0x02000050 RID: 80
	public partial class AttemptingWiFi : UserControl
	{
		// Token: 0x060004AA RID: 1194 RVA: 0x0000AA06 File Offset: 0x00008C06
		public AttemptingWiFi(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
