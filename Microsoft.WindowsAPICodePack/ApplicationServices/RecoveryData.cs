using System;

namespace Microsoft.WindowsAPICodePack.ApplicationServices
{
	// Token: 0x02000005 RID: 5
	public class RecoveryData
	{
		// Token: 0x06000010 RID: 16 RVA: 0x00002235 File Offset: 0x00000435
		public RecoveryData(RecoveryCallback callback, object state)
		{
			this.Callback = callback;
			this.State = state;
		}

		// Token: 0x17000001 RID: 1
		// (get) Token: 0x06000011 RID: 17 RVA: 0x00002250 File Offset: 0x00000450
		// (set) Token: 0x06000012 RID: 18 RVA: 0x00002267 File Offset: 0x00000467
		public RecoveryCallback Callback { get; set; }

		// Token: 0x17000002 RID: 2
		// (get) Token: 0x06000013 RID: 19 RVA: 0x00002270 File Offset: 0x00000470
		// (set) Token: 0x06000014 RID: 20 RVA: 0x00002287 File Offset: 0x00000487
		public object State { get; set; }

		// Token: 0x06000015 RID: 21 RVA: 0x00002290 File Offset: 0x00000490
		public void Invoke()
		{
			if (this.Callback != null)
			{
				this.Callback(this.State);
			}
		}
	}
}
