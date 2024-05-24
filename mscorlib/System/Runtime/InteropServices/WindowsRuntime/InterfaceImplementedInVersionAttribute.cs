using System;

namespace System.Runtime.InteropServices.WindowsRuntime
{
	// Token: 0x020009C7 RID: 2503
	[AttributeUsage(AttributeTargets.Class | AttributeTargets.Interface, Inherited = false, AllowMultiple = true)]
	[__DynamicallyInvokable]
	public sealed class InterfaceImplementedInVersionAttribute : Attribute
	{
		// Token: 0x060063BC RID: 25532 RVA: 0x001547E8 File Offset: 0x001529E8
		[__DynamicallyInvokable]
		public InterfaceImplementedInVersionAttribute(Type interfaceType, byte majorVersion, byte minorVersion, byte buildVersion, byte revisionVersion)
		{
			this.m_interfaceType = interfaceType;
			this.m_majorVersion = majorVersion;
			this.m_minorVersion = minorVersion;
			this.m_buildVersion = buildVersion;
			this.m_revisionVersion = revisionVersion;
		}

		// Token: 0x1700113A RID: 4410
		// (get) Token: 0x060063BD RID: 25533 RVA: 0x00154815 File Offset: 0x00152A15
		[__DynamicallyInvokable]
		public Type InterfaceType
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_interfaceType;
			}
		}

		// Token: 0x1700113B RID: 4411
		// (get) Token: 0x060063BE RID: 25534 RVA: 0x0015481D File Offset: 0x00152A1D
		[__DynamicallyInvokable]
		public byte MajorVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_majorVersion;
			}
		}

		// Token: 0x1700113C RID: 4412
		// (get) Token: 0x060063BF RID: 25535 RVA: 0x00154825 File Offset: 0x00152A25
		[__DynamicallyInvokable]
		public byte MinorVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_minorVersion;
			}
		}

		// Token: 0x1700113D RID: 4413
		// (get) Token: 0x060063C0 RID: 25536 RVA: 0x0015482D File Offset: 0x00152A2D
		[__DynamicallyInvokable]
		public byte BuildVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_buildVersion;
			}
		}

		// Token: 0x1700113E RID: 4414
		// (get) Token: 0x060063C1 RID: 25537 RVA: 0x00154835 File Offset: 0x00152A35
		[__DynamicallyInvokable]
		public byte RevisionVersion
		{
			[__DynamicallyInvokable]
			get
			{
				return this.m_revisionVersion;
			}
		}

		// Token: 0x04002CD4 RID: 11476
		private Type m_interfaceType;

		// Token: 0x04002CD5 RID: 11477
		private byte m_majorVersion;

		// Token: 0x04002CD6 RID: 11478
		private byte m_minorVersion;

		// Token: 0x04002CD7 RID: 11479
		private byte m_buildVersion;

		// Token: 0x04002CD8 RID: 11480
		private byte m_revisionVersion;
	}
}
