using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009DF RID: 2527
	[__DynamicallyInvokable]
	public struct EventRegistrationToken
	{
		// Token: 0x0600646A RID: 25706 RVA: 0x0015656F File Offset: 0x0015476F
		internal EventRegistrationToken(ulong value)
		{
			this.m_value = value;
		}

		// Token: 0x17001151 RID: 4433
		// (get) Token: 0x0600646B RID: 25707 RVA: 0x00156578 File Offset: 0x00154778
		internal ulong Value
		{
			get
			{
				return this.m_value;
			}
		}

		// Token: 0x0600646C RID: 25708 RVA: 0x00156580 File Offset: 0x00154780
		[__DynamicallyInvokable]
		public static bool operator ==(EventRegistrationToken left, EventRegistrationToken right)
		{
			return left.Equals(right);
		}

		// Token: 0x0600646D RID: 25709 RVA: 0x00156595 File Offset: 0x00154795
		[__DynamicallyInvokable]
		public static bool operator !=(EventRegistrationToken left, EventRegistrationToken right)
		{
			return !left.Equals(right);
		}

		// Token: 0x0600646E RID: 25710 RVA: 0x001565B0 File Offset: 0x001547B0
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return obj is EventRegistrationToken && ((EventRegistrationToken)obj).Value == this.Value;
		}

		// Token: 0x0600646F RID: 25711 RVA: 0x001565DD File Offset: 0x001547DD
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return this.m_value.GetHashCode();
		}

		// Token: 0x04002CE8 RID: 11496
		internal ulong m_value;
	}
}
