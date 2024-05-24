using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels;

namespace WizardModule.Views.Compact
{
	// Token: 0x0200005E RID: 94
	public partial class AdvancedOptionUpgradeAssistant : UserControl
	{
		// Token: 0x06000505 RID: 1285 RVA: 0x0000B945 File Offset: 0x00009B45
		public AdvancedOptionUpgradeAssistant(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
