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
	// Token: 0x02000069 RID: 105
	public partial class SectionApplications : UserControl
	{
		// Token: 0x06000527 RID: 1319 RVA: 0x0000BECD File Offset: 0x0000A0CD
		public SectionApplications(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
