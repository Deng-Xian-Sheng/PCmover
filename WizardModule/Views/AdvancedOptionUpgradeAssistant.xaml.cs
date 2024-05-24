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

namespace WizardModule.Views
{
	// Token: 0x0200000E RID: 14
	public partial class AdvancedOptionUpgradeAssistant : UserControl
	{
		// Token: 0x060003C7 RID: 967 RVA: 0x00008501 File Offset: 0x00006701
		public AdvancedOptionUpgradeAssistant(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
