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
	// Token: 0x02000037 RID: 55
	public partial class SectionUsers_Self : UserControl
	{
		// Token: 0x06000448 RID: 1096 RVA: 0x000099FE File Offset: 0x00007BFE
		public SectionUsers_Self(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
		}
	}
}
