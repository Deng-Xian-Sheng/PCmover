using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels;

namespace WizardModule.Views
{
	// Token: 0x0200003A RID: 58
	public partial class SslConfiguration : UserControl
	{
		// Token: 0x06000451 RID: 1105 RVA: 0x00009B79 File Offset: 0x00007D79
		public SslConfiguration(IUnityContainer container)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
		}
	}
}
