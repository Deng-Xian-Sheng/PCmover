using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using WizardModule.ViewModels.Dialogs;

namespace WizardModule.Views.Dialogs
{
	// Token: 0x02000051 RID: 81
	public partial class IABrowse : UserControl
	{
		// Token: 0x060004AD RID: 1197 RVA: 0x0000AA8C File Offset: 0x00008C8C
		public IABrowse(IUnityContainer container, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			base.DataContext = overlayArgs.GetResolveInfo(typeof(IABrowseViewModel)).Resolve(container);
		}
	}
}
