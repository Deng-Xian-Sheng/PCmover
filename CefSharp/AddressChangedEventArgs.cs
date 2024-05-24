using System;

namespace CefSharp
{
	// Token: 0x02000044 RID: 68
	public class AddressChangedEventArgs : EventArgs
	{
		// Token: 0x17000054 RID: 84
		// (get) Token: 0x060000DD RID: 221 RVA: 0x00003249 File Offset: 0x00001449
		// (set) Token: 0x060000DE RID: 222 RVA: 0x00003251 File Offset: 0x00001451
		public IBrowser Browser { get; private set; }

		// Token: 0x17000055 RID: 85
		// (get) Token: 0x060000DF RID: 223 RVA: 0x0000325A File Offset: 0x0000145A
		// (set) Token: 0x060000E0 RID: 224 RVA: 0x00003262 File Offset: 0x00001462
		public string Address { get; private set; }

		// Token: 0x060000E1 RID: 225 RVA: 0x0000326B File Offset: 0x0000146B
		public AddressChangedEventArgs(IBrowser browser, string address)
		{
			this.Browser = browser;
			this.Address = address;
		}
	}
}
