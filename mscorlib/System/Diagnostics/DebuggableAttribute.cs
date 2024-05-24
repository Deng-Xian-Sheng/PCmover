using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003EA RID: 1002
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Module, AllowMultiple = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggableAttribute : Attribute
	{
		// Token: 0x06003306 RID: 13062 RVA: 0x000C4B60 File Offset: 0x000C2D60
		public DebuggableAttribute(bool isJITTrackingEnabled, bool isJITOptimizerDisabled)
		{
			this.m_debuggingModes = DebuggableAttribute.DebuggingModes.None;
			if (isJITTrackingEnabled)
			{
				this.m_debuggingModes |= DebuggableAttribute.DebuggingModes.Default;
			}
			if (isJITOptimizerDisabled)
			{
				this.m_debuggingModes |= DebuggableAttribute.DebuggingModes.DisableOptimizations;
			}
		}

		// Token: 0x06003307 RID: 13063 RVA: 0x000C4B95 File Offset: 0x000C2D95
		[__DynamicallyInvokable]
		public DebuggableAttribute(DebuggableAttribute.DebuggingModes modes)
		{
			this.m_debuggingModes = modes;
		}

		// Token: 0x17000772 RID: 1906
		// (get) Token: 0x06003308 RID: 13064 RVA: 0x000C4BA4 File Offset: 0x000C2DA4
		public bool IsJITTrackingEnabled
		{
			get
			{
				return (this.m_debuggingModes & DebuggableAttribute.DebuggingModes.Default) > DebuggableAttribute.DebuggingModes.None;
			}
		}

		// Token: 0x17000773 RID: 1907
		// (get) Token: 0x06003309 RID: 13065 RVA: 0x000C4BB1 File Offset: 0x000C2DB1
		public bool IsJITOptimizerDisabled
		{
			get
			{
				return (this.m_debuggingModes & DebuggableAttribute.DebuggingModes.DisableOptimizations) > DebuggableAttribute.DebuggingModes.None;
			}
		}

		// Token: 0x17000774 RID: 1908
		// (get) Token: 0x0600330A RID: 13066 RVA: 0x000C4BC2 File Offset: 0x000C2DC2
		public DebuggableAttribute.DebuggingModes DebuggingFlags
		{
			get
			{
				return this.m_debuggingModes;
			}
		}

		// Token: 0x0400169B RID: 5787
		private DebuggableAttribute.DebuggingModes m_debuggingModes;

		// Token: 0x02000B80 RID: 2944
		[Flags]
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public enum DebuggingModes
		{
			// Token: 0x040034D3 RID: 13523
			[__DynamicallyInvokable]
			None = 0,
			// Token: 0x040034D4 RID: 13524
			[__DynamicallyInvokable]
			Default = 1,
			// Token: 0x040034D5 RID: 13525
			[__DynamicallyInvokable]
			DisableOptimizations = 256,
			// Token: 0x040034D6 RID: 13526
			[__DynamicallyInvokable]
			IgnoreSymbolStoreSequencePoints = 2,
			// Token: 0x040034D7 RID: 13527
			[__DynamicallyInvokable]
			EnableEditAndContinue = 4
		}
	}
}
