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
using WizardModule.ViewModels.Popups;

namespace WizardModule.Views.Popups
{
	// Token: 0x02000046 RID: 70
	public partial class InsufficientDriveSpace : UserControl, IHasPopupData
	{
		// Token: 0x17000384 RID: 900
		// (get) Token: 0x0600047A RID: 1146 RVA: 0x0000A252 File Offset: 0x00008452
		public InsufficientDriveSpaceViewModel Vm { get; }

		// Token: 0x17000385 RID: 901
		// (get) Token: 0x0600047B RID: 1147 RVA: 0x0000A25A File Offset: 0x0000845A
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x0600047C RID: 1148 RVA: 0x0000A268 File Offset: 0x00008468
		public InsufficientDriveSpace(IUnityContainer container, InsufficientDriveSpaceData data)
		{
			this.InitializeComponent();
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Vm = container.Resolve(new ResolverOverride[]
			{
				new ParameterOverride("data", data)
			});
			base.DataContext = this.Vm;
			this.Vm.PopupData.Content = this;
		}
	}
}
