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
	// Token: 0x02000053 RID: 83
	public partial class NoComputersFound : UserControl
	{
		// Token: 0x060004B3 RID: 1203 RVA: 0x0000ABAA File Offset: 0x00008DAA
		public NoComputersFound(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
