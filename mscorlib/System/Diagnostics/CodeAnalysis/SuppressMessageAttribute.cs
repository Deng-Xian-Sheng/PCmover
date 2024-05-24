using System;

namespace System.Diagnostics.CodeAnalysis
{
	// Token: 0x02000419 RID: 1049
	[AttributeUsage(AttributeTargets.All, Inherited = false, AllowMultiple = true)]
	[Conditional("CODE_ANALYSIS")]
	[__DynamicallyInvokable]
	public sealed class SuppressMessageAttribute : Attribute
	{
		// Token: 0x06003429 RID: 13353 RVA: 0x000C6C65 File Offset: 0x000C4E65
		[__DynamicallyInvokable]
		public SuppressMessageAttribute(string category, string checkId)
		{
			this.category = category;
			this.checkId = checkId;
		}

		// Token: 0x170007B3 RID: 1971
		// (get) Token: 0x0600342A RID: 13354 RVA: 0x000C6C7B File Offset: 0x000C4E7B
		[__DynamicallyInvokable]
		public string Category
		{
			[__DynamicallyInvokable]
			get
			{
				return this.category;
			}
		}

		// Token: 0x170007B4 RID: 1972
		// (get) Token: 0x0600342B RID: 13355 RVA: 0x000C6C83 File Offset: 0x000C4E83
		[__DynamicallyInvokable]
		public string CheckId
		{
			[__DynamicallyInvokable]
			get
			{
				return this.checkId;
			}
		}

		// Token: 0x170007B5 RID: 1973
		// (get) Token: 0x0600342C RID: 13356 RVA: 0x000C6C8B File Offset: 0x000C4E8B
		// (set) Token: 0x0600342D RID: 13357 RVA: 0x000C6C93 File Offset: 0x000C4E93
		[__DynamicallyInvokable]
		public string Scope
		{
			[__DynamicallyInvokable]
			get
			{
				return this.scope;
			}
			[__DynamicallyInvokable]
			set
			{
				this.scope = value;
			}
		}

		// Token: 0x170007B6 RID: 1974
		// (get) Token: 0x0600342E RID: 13358 RVA: 0x000C6C9C File Offset: 0x000C4E9C
		// (set) Token: 0x0600342F RID: 13359 RVA: 0x000C6CA4 File Offset: 0x000C4EA4
		[__DynamicallyInvokable]
		public string Target
		{
			[__DynamicallyInvokable]
			get
			{
				return this.target;
			}
			[__DynamicallyInvokable]
			set
			{
				this.target = value;
			}
		}

		// Token: 0x170007B7 RID: 1975
		// (get) Token: 0x06003430 RID: 13360 RVA: 0x000C6CAD File Offset: 0x000C4EAD
		// (set) Token: 0x06003431 RID: 13361 RVA: 0x000C6CB5 File Offset: 0x000C4EB5
		[__DynamicallyInvokable]
		public string MessageId
		{
			[__DynamicallyInvokable]
			get
			{
				return this.messageId;
			}
			[__DynamicallyInvokable]
			set
			{
				this.messageId = value;
			}
		}

		// Token: 0x170007B8 RID: 1976
		// (get) Token: 0x06003432 RID: 13362 RVA: 0x000C6CBE File Offset: 0x000C4EBE
		// (set) Token: 0x06003433 RID: 13363 RVA: 0x000C6CC6 File Offset: 0x000C4EC6
		[__DynamicallyInvokable]
		public string Justification
		{
			[__DynamicallyInvokable]
			get
			{
				return this.justification;
			}
			[__DynamicallyInvokable]
			set
			{
				this.justification = value;
			}
		}

		// Token: 0x0400171A RID: 5914
		private string category;

		// Token: 0x0400171B RID: 5915
		private string justification;

		// Token: 0x0400171C RID: 5916
		private string checkId;

		// Token: 0x0400171D RID: 5917
		private string scope;

		// Token: 0x0400171E RID: 5918
		private string target;

		// Token: 0x0400171F RID: 5919
		private string messageId;
	}
}
