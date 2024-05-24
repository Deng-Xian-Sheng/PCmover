using System;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Markup;
using Microsoft.Practices.Unity;
using WizardModule.ViewModels;

namespace WizardModule.Views
{
	// Token: 0x02000043 RID: 67
	public partial class WelcomePage : UserControl
	{
		// Token: 0x0600046C RID: 1132 RVA: 0x00009FF5 File Offset: 0x000081F5
		public WelcomePage(IUnityContainer container)
		{
			this.InitializeComponent();
			base.DataContext = container.Resolve(Array.Empty<ResolverOverride>());
			base.FlowDirection = (CultureInfo.CurrentUICulture.TextInfo.IsRightToLeft ? FlowDirection.RightToLeft : FlowDirection.LeftToRight);
			this.Init();
		}

		// Token: 0x0600046D RID: 1133 RVA: 0x0000A038 File Offset: 0x00008238
		private void Init()
		{
			WelcomePage.<Init>d__1 <Init>d__;
			<Init>d__.<>t__builder = AsyncVoidMethodBuilder.Create();
			<Init>d__.<>4__this = this;
			<Init>d__.<>1__state = -1;
			<Init>d__.<>t__builder.Start<WelcomePage.<Init>d__1>(ref <Init>d__);
		}
	}
}
