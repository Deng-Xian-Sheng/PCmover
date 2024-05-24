using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using MenuModule.ViewModels;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;

namespace MenuModule.Views
{
	// Token: 0x02000004 RID: 4
	public partial class LogMenu : UserControl
	{
		// Token: 0x06000007 RID: 7 RVA: 0x00002128 File Offset: 0x00000328
		public LogMenu(IUnityContainer container, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			base.DataContext = overlayArgs.GetResolveInfo(typeof(LogMenuViewModel)).Resolve(container);
		}
	}
}
