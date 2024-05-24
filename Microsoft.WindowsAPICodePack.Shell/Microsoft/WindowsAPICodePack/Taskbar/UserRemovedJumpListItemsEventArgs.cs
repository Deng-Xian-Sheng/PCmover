using System;
using System.Collections;

namespace Microsoft.WindowsAPICodePack.Taskbar
{
	// Token: 0x0200018E RID: 398
	public class UserRemovedJumpListItemsEventArgs : EventArgs
	{
		// Token: 0x06000FA7 RID: 4007 RVA: 0x000379E7 File Offset: 0x00035BE7
		internal UserRemovedJumpListItemsEventArgs(IEnumerable RemovedItems)
		{
			this._removedItems = RemovedItems;
		}

		// Token: 0x17000897 RID: 2199
		// (get) Token: 0x06000FA8 RID: 4008 RVA: 0x000379FC File Offset: 0x00035BFC
		public IEnumerable RemovedItems
		{
			get
			{
				return this._removedItems;
			}
		}

		// Token: 0x04000698 RID: 1688
		private readonly IEnumerable _removedItems;
	}
}
