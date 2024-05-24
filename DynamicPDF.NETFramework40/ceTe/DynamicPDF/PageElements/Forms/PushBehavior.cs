using System;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007F0 RID: 2032
	public class PushBehavior : Behavior
	{
		// Token: 0x06005280 RID: 21120 RVA: 0x0028DF29 File Offset: 0x0028CF29
		public PushBehavior(string downLabel) : base(Behavior.d)
		{
			this.a = downLabel;
		}

		// Token: 0x06005281 RID: 21121 RVA: 0x0028DF40 File Offset: 0x0028CF40
		public PushBehavior(string downLabel, string rolloverLabel) : base(Behavior.d)
		{
			this.a = downLabel;
			this.b = rolloverLabel;
		}

		// Token: 0x06005282 RID: 21122 RVA: 0x0028DF5E File Offset: 0x0028CF5E
		internal PushBehavior(int A_0) : base(A_0)
		{
		}

		// Token: 0x17000754 RID: 1876
		// (get) Token: 0x06005283 RID: 21123 RVA: 0x0028DF6C File Offset: 0x0028CF6C
		// (set) Token: 0x06005284 RID: 21124 RVA: 0x0028DF84 File Offset: 0x0028CF84
		public string DownLabel
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000755 RID: 1877
		// (get) Token: 0x06005285 RID: 21125 RVA: 0x0028DF90 File Offset: 0x0028CF90
		// (set) Token: 0x06005286 RID: 21126 RVA: 0x0028DFA8 File Offset: 0x0028CFA8
		public string RolloverLabel
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x04002C1A RID: 11290
		private new string a;

		// Token: 0x04002C1B RID: 11291
		private new string b;
	}
}
