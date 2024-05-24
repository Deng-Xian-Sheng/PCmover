using System;
using Prism.Mvvm;

namespace Laplink.Tools.Popups
{
	// Token: 0x0200000C RID: 12
	public class PopupViewModelBase : BindableBase
	{
		// Token: 0x17000032 RID: 50
		// (get) Token: 0x0600006F RID: 111 RVA: 0x00002C1A File Offset: 0x00000E1A
		public PopupData PopupData { get; } = new PopupData();
	}
}
