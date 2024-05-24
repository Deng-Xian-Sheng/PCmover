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
	// Token: 0x02000055 RID: 85
	public partial class OtherComputersFound : UserControl
	{
		// Token: 0x060004B9 RID: 1209 RVA: 0x0000AD0E File Offset: 0x00008F0E
		public OtherComputersFound(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
