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
using PCmover.ViewModels;

namespace PCmover.Views
{
	// Token: 0x02000006 RID: 6
	public partial class Authentication : UserControl, IHasPopupData
	{
		// Token: 0x17000044 RID: 68
		// (get) Token: 0x06000055 RID: 85 RVA: 0x00002A3E File Offset: 0x00000C3E
		public AuthenticationViewModel Vm { get; }

		// Token: 0x17000045 RID: 69
		// (get) Token: 0x06000056 RID: 86 RVA: 0x00002A46 File Offset: 0x00000C46
		public PopupData PopupData
		{
			get
			{
				return this.Vm.PopupData;
			}
		}

		// Token: 0x06000057 RID: 87 RVA: 0x00002A54 File Offset: 0x00000C54
		public Authentication(IUnityContainer container, AuthenticationData data)
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
