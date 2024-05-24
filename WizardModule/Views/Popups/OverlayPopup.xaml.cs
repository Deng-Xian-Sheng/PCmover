using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Laplink.Tools.Popups;
using Microsoft.Practices.Unity;
using PCmover.Infrastructure;
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x02000049 RID: 73
	public partial class OverlayPopup : UserControl, IHasPopupData
	{
		// Token: 0x1700038A RID: 906
		// (get) Token: 0x06000489 RID: 1161 RVA: 0x0000A48D File Offset: 0x0000868D
		public OverlayPopupViewModel Vm { get; }

		// Token: 0x1700038B RID: 907
		// (get) Token: 0x0600048A RID: 1162 RVA: 0x0000A495 File Offset: 0x00008695
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600048B RID: 1163 RVA: 0x0000A4A4 File Offset: 0x000086A4
		public OverlayPopup(IUnityContainer container, Events.OverlayPopupResolveArgs overlayArgs)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("overlayArgs", overlayArgs)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
