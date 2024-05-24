using System;
using System.Threading;

namespace System.Text
{
	// Token: 0x02000A63 RID: 2659
	[__DynamicallyInvokable]
	[Serializable]
	public abstract class DecoderFallback
	{
		// Token: 0x170011A5 RID: 4517
		// (get) Token: 0x0600679A RID: 26522 RVA: 0x0015E020 File Offset: 0x0015C220
		private static object InternalSyncObject
		{
			get
			{
				if (DecoderFallback.s_InternalSyncObject == null)
				{
					object value = new object();
					Interlocked.CompareExchange<object>(ref DecoderFallback.s_InternalSyncObject, value, null);
				}
				return DecoderFallback.s_InternalSyncObject;
			}
		}

		// Token: 0x170011A6 RID: 4518
		// (get) Token: 0x0600679B RID: 26523 RVA: 0x0015E04C File Offset: 0x0015C24C
		[__DynamicallyInvokable]
		public static DecoderFallback ReplacementFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (DecoderFallback.replacementFallback == null)
				{
					object internalSyncObject = DecoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (DecoderFallback.replacementFallback == null)
						{
							DecoderFallback.replacementFallback = new DecoderReplacementFallback();
						}
					}
				}
				return DecoderFallback.replacementFallback;
			}
		}

		// Token: 0x170011A7 RID: 4519
		// (get) Token: 0x0600679C RID: 26524 RVA: 0x0015E0AC File Offset: 0x0015C2AC
		[__DynamicallyInvokable]
		public static DecoderFallback ExceptionFallback
		{
			[__DynamicallyInvokable]
			get
			{
				if (DecoderFallback.exceptionFallback == null)
				{
					object internalSyncObject = DecoderFallback.InternalSyncObject;
					lock (internalSyncObject)
					{
						if (DecoderFallback.exceptionFallback == null)
						{
							DecoderFallback.exceptionFallback = new DecoderExceptionFallback();
						}
					}
				}
				return DecoderFallback.exceptionFallback;
			}
		}

		// Token: 0x0600679D RID: 26525
		[__DynamicallyInvokable]
		public abstract DecoderFallbackBuffer CreateFallbackBuffer();

		// Token: 0x170011A8 RID: 4520
		// (get) Token: 0x0600679E RID: 26526
		[__DynamicallyInvokable]
		public abstract int MaxCharCount { [__DynamicallyInvokable] get; }

		// Token: 0x170011A9 RID: 4521
		// (get) Token: 0x0600679F RID: 26527 RVA: 0x0015E10C File Offset: 0x0015C30C
		internal bool IsMicrosoftBestFitFallback
		{
			get
			{
				return this.bIsMicrosoftBestFitFallback;
			}
		}

		// Token: 0x060067A0 RID: 26528 RVA: 0x0015E114 File Offset: 0x0015C314
		[__DynamicallyInvokable]
		protected DecoderFallback()
		{
		}

		// Token: 0x04002E43 RID: 11843
		internal bool bIsMicrosoftBestFitFallback;

		// Token: 0x04002E44 RID: 11844
		private static volatile DecoderFallback replacementFallback;

		// Token: 0x04002E45 RID: 11845
		private static volatile DecoderFallback exceptionFallback;

		// Token: 0x04002E46 RID: 11846
		private static object s_InternalSyncObject;
	}
}
