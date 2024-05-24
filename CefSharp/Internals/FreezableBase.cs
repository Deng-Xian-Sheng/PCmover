using System;
using System.Runtime.CompilerServices;

namespace CefSharp.Internals
{
	// Token: 0x020000CA RID: 202
	public class FreezableBase
	{
		// Token: 0x060005F8 RID: 1528 RVA: 0x00009B0E File Offset: 0x00007D0E
		public void Freeze()
		{
			this.frozen = true;
		}

		// Token: 0x060005F9 RID: 1529 RVA: 0x00009B17 File Offset: 0x00007D17
		protected void ThrowIfFrozen([CallerMemberName] string memberName = "")
		{
			if (this.frozen)
			{
				throw new Exception(base.GetType().Name + "." + memberName + " can no longer be modified, settings must be changed before the underlying browser has been created.");
			}
		}

		// Token: 0x04000343 RID: 835
		private bool frozen;
	}
}
