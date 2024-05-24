using System;

namespace System.Runtime.Versioning
{
	// Token: 0x02000723 RID: 1827
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = false, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class TargetFrameworkAttribute : Attribute
	{
		// Token: 0x0600515C RID: 20828 RVA: 0x0011EF51 File Offset: 0x0011D151
		[__DynamicallyInvokable]
		public TargetFrameworkAttribute(string frameworkName)
		{
			if (frameworkName == null)
			{
				throw new ArgumentNullException("frameworkName");
			}
			this._frameworkName = frameworkName;
		}

		// Token: 0x17000D6D RID: 3437
		// (get) Token: 0x0600515D RID: 20829 RVA: 0x0011EF6E File Offset: 0x0011D16E
		[__DynamicallyInvokable]
		public string FrameworkName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._frameworkName;
			}
		}

		// Token: 0x17000D6E RID: 3438
		// (get) Token: 0x0600515E RID: 20830 RVA: 0x0011EF76 File Offset: 0x0011D176
		// (set) Token: 0x0600515F RID: 20831 RVA: 0x0011EF7E File Offset: 0x0011D17E
		[__DynamicallyInvokable]
		public string FrameworkDisplayName
		{
			[__DynamicallyInvokable]
			get
			{
				return this._frameworkDisplayName;
			}
			[__DynamicallyInvokable]
			set
			{
				this._frameworkDisplayName = value;
			}
		}

		// Token: 0x0400241C RID: 9244
		private string _frameworkName;

		// Token: 0x0400241D RID: 9245
		private string _frameworkDisplayName;
	}
}
