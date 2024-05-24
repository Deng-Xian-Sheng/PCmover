using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000932 RID: 2354
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Method, AllowMultiple = false)]
	[ComVisible(false)]
	[__DynamicallyInvokable]
	public sealed class DefaultDllImportSearchPathsAttribute : Attribute
	{
		// Token: 0x06006032 RID: 24626 RVA: 0x0014BA50 File Offset: 0x00149C50
		[__DynamicallyInvokable]
		public DefaultDllImportSearchPathsAttribute(DllImportSearchPath paths)
		{
			this._paths = paths;
		}

		// Token: 0x170010E1 RID: 4321
		// (get) Token: 0x06006033 RID: 24627 RVA: 0x0014BA5F File Offset: 0x00149C5F
		[__DynamicallyInvokable]
		public DllImportSearchPath Paths
		{
			[__DynamicallyInvokable]
			get
			{
				return this._paths;
			}
		}

		// Token: 0x04002B0A RID: 11018
		internal DllImportSearchPath _paths;
	}
}
