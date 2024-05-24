using System;
using System.Threading;

namespace System.Text
{
	// Token: 0x02000A6E RID: 2670
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class EncoderFallback
	{
		// Token: 0x170011BD RID: 4541
		// (get) Token: 0x060067FA RID: 26618 RVA: 0x0015F40C File Offset: 0x0015D60C
		private static object InternalSyncObject
		{
			get
			{
				if (EncoderFallback.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref EncoderFallback.s_InternalSyncObject, value, null);
				}
				return EncoderFallback.s_InternalSyncObject;
			}
		}

		// Token: 0x170011BE RID: 4542
		// (get) Token: 0x060067FB RID: 26619 RVA: 0x0015F438 File Offset: 0x0015D638
		[__DynamicallyInvokable]
		public static EncoderFallback ReplacementFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (EncoderFallback.replacementFallback == null)
				{
					object internalSyncObject = EncoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (EncoderFallback.replacementFallback == null)
						{
							EncoderFallback.replacementFallback = new EncoderReplacementFallback();
						}
					}
				}
				return EncoderFallback.replacementFallback;
			}
		}

		// Token: 0x170011BF RID: 4543
		// (get) Token: 0x060067FC RID: 26620 RVA: 0x0015F498 File Offset: 0x0015D698
		[__DynamicallyInvokable]
		public static EncoderFallback ExceptionFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (EncoderFallback.exceptionFallback == null)
				{
					object internalSyncObject = EncoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (EncoderFallback.exceptionFallback == null)
						{
							EncoderFallback.exceptionFallback = new EncoderExceptionFallback();
						}
					}
				}
				return EncoderFallback.exceptionFallback;
			}
		}

		// Token: 0x060067FD RID: 26621
		[__DynamicallyInvokable]
		public abstract EncoderFallbackBuffer CreateFallbackBuffer();

		// Token: 0x170011C0 RID: 4544
		// (get) Token: 0x060067FE RID: 26622
		[__DynamicallyInvokable]
		public abstract int MaxCharCount { [__DynamicallyInvokable] get; }

		// Token: 0x060067FF RID: 26623 RVA: 0x0015F4F8 File Offset: 0x0015D6F8
		[__DynamicallyInvokable]
		protected EncoderFallback()
		{
		}

		// Token: 0x04002E5F RID: 11871
		internal bool bIsMicrosoftBestFitFallback;

		// Token: 0x04002E60 RID: 11872
		private static volatile EncoderFallback replacementFallback;

		// Token: 0x04002E61 RID: 11873
		private static volatile EncoderFallback exceptionFallback;

		// Token: 0x04002E62 RID: 11874
		private static object s_InternalSyncObject;
	}
}
