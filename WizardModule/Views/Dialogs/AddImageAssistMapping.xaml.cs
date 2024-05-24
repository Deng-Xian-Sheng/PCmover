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
	// Token: 0x0200004F RID: 79
	public partial class AddImageAssistMapping : UserControl
	{
		// Token: 0x060004A7 RID: 1191 RVA: 0x0000A96C File Offset: 0x00008B6C
		public AddImageAssistMapping(IUnityContainer container, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			base.DataContext = overlayArgs.GetResolveInfo(typeof(AddImageAssistMappingViewModel)).Resolve(container);
		}
	}
}
