using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Threading
{
	// Token: 0x0200050D RID: 1293
	internal sealed class Gen2GcCallback : CriticalFinalizerObject
	{
		// Token: 0x06003CD0 RID: 15568 RVA: 0x000E5AAC File Offset: 0x000E3CAC
		[SecuritySafeCritical]
		public Gen2GcCallback()
		{
		}

		// Token: 0x06003CD1 RID: 15569 RVA: 0x000E5AB4 File Offset: 0x000E3CB4
		public static void Register(Func<object, bool> callback, object targetObj)
		{
			Gen2GcCallback gen2GcCallback = new Gen2GcCallback();
			gen2GcCallback.Setup(callback, targetObj);
		}

		// Token: 0x06003CD2 RID: 15570 RVA: 0x000E5ACF File Offset: 0x000E3CCF
		[SecuritySafeCritical]
		private void Setup(Func<object, bool> callback, object targetObj)
		{
			this.m_callback = callback;
			this.m_weakTargetObj = GCHandle.Alloc(targetObj, GCHandleType.Weak);
		}

		// Token: 0x06003CD3 RID: 15571 RVA: 0x000E5AE8 File Offset: 0x000E3CE8
		[SecuritySafeCritical]
		protected override void Finalize()
		{
			try
			{
				if (this.m_weakTargetObj.IsAllocated)
				{
					object target = this.m_weakTargetObj.Target;
					if (target == null)
					{
						this.m_weakTargetObj.Free();
					}
					else
					{
						try
						{
							if (!this.m_callback(target))
							{
								return;
							}
						}
						catch
						{
						}
						if (!Environment.HasShutdownStarted && !AppDomain.CurrentDomain.IsFinalizingForUnload())
						{
							GC.ReRegisterForFinalize(this);
						}
					}
				}
			}
			finally
			{
				base.Finalize();
			}
		}

		// Token: 0x040019D0 RID: 6608
		private Func<object, bool> m_callback;

		// Token: 0x040019D1 RID: 6609
		private GCHandle m_weakTargetObj;
	}
}
