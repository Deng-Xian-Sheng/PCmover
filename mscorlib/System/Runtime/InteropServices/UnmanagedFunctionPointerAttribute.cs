using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200090E RID: 2318
	[AttributeUsage(AttributeTargets.Delegate, AllowMultiple = false, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class UnmanagedFunctionPointerAttribute : Attribute
	{
		// Token: 0x06005FE8 RID: 24552 RVA: 0x0014B50E File Offset: 0x0014970E
		[__DynamicallyInvokable]
		public UnmanagedFunctionPointerAttribute(CallingConvention callingConvention)
		{
			this.m_callingConvention = callingConvention;
		}

		// Token: 0x170010CE RID: 4302
		// (get) Token: 0x06005FE9 RID: 24553 RVA: 0x0014B51D File Offset: 0x0014971D
		[__DynamicallyInvokable]
		public CallingConvention CallingConvention
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_callingConvention;
			}
		}

		// Token: 0x04002A56 RID: 10838
		private CallingConvention m_callingConvention;

		// Token: 0x04002A57 RID: 10839
		[__DynamicallyInvokable]
		public CharSet CharSet;

		// Token: 0x04002A58 RID: 10840
		[__DynamicallyInvokable]
		public bool BestFitMapping;

		// Token: 0x04002A59 RID: 10841
		[__DynamicallyInvokable]
		public bool ThrowOnUnmappableChar;

		// Token: 0x04002A5A RID: 10842
		[__DynamicallyInvokable]
		public bool SetLastError;
	}
}
