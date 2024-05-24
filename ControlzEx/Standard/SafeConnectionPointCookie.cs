using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices.ComTypes;
using Microsoft.Win32.SafeHandles;

namespace ControlzEx.Standard
{
	// Token: 0x0200005A RID: 90
	internal sealed class SafeConnectionPointCookie : SafeHandleZeroOrMinusOneIsInvalid
	{
		// Token: 0x0600017D RID: 381 RVA: 0x000086CC File Offset: 0x000068CC
		public SafeConnectionPointCookie(IConnectionPointContainer target, object sink, Guid eventId) : base(true)
		{
			Verify.IsNotNull<IConnectionPointContainer>(target, "target");
			Verify.IsNotNull<object>(sink, "sink");
			Verify.IsNotDefault<Guid>(eventId, "eventId");
			this.handle = IntPtr.Zero;
			IConnectionPoint connectionPoint = null;
			try
			{
				target.FindConnectionPoint(ref eventId, out connectionPoint);
				int num;
				connectionPoint.Advise(sink, out num);
				if (num == 0)
				{
					throw new InvalidOperationException("IConnectionPoint::Advise returned an invalid cookie.");
				}
				this.handle = new IntPtr(num);
				this._cp = connectionPoint;
				connectionPoint = null;
			}
			finally
			{
				Utility.SafeRelease<IConnectionPoint>(ref connectionPoint);
			}
		}

		// Token: 0x0600017E RID: 382 RVA: 0x00008760 File Offset: 0x00006960
		public void Disconnect()
		{
			this.ReleaseHandle();
		}

		// Token: 0x0600017F RID: 383 RVA: 0x0000876C File Offset: 0x0000696C
		[ReliabilityContract(Consistency.WillNotCorruptState, Cer.MayFail)]
		protected override bool ReleaseHandle()
		{
			bool result;
			try
			{
				if (!this.IsInvalid)
				{
					int dwCookie = this.handle.ToInt32();
					this.handle = IntPtr.Zero;
					try
					{
						this._cp.Unadvise(dwCookie);
					}
					finally
					{
						Utility.SafeRelease<IConnectionPoint>(ref this._cp);
					}
				}
				result = true;
			}
			catch
			{
				result = false;
			}
			return result;
		}

		// Token: 0x040004F7 RID: 1271
		private IConnectionPoint _cp;
	}
}
