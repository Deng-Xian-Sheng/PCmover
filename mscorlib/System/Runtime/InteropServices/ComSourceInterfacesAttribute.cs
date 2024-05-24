using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000920 RID: 2336
	[AttributeUsage(AttributeTargets.Class, Inherited = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class ComSourceInterfacesAttribute : Attribute
	{
		// Token: 0x06006008 RID: 24584 RVA: 0x0014B683 File Offset: 0x00149883
		[__DynamicallyInvokable]
		public ComSourceInterfacesAttribute(string sourceInterfaces)
		{
			this._val = sourceInterfaces;
		}

		// Token: 0x06006009 RID: 24585 RVA: 0x0014B692 File Offset: 0x00149892
		[__DynamicallyInvokable]
		public ComSourceInterfacesAttribute(Type sourceInterface)
		{
			this._val = sourceInterface.FullName;
		}

		// Token: 0x0600600A RID: 24586 RVA: 0x0014B6A6 File Offset: 0x001498A6
		[__DynamicallyInvokable]
		public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2)
		{
			this._val = sourceInterface1.FullName + "\0" + sourceInterface2.FullName;
		}

		// Token: 0x0600600B RID: 24587 RVA: 0x0014B6CC File Offset: 0x001498CC
		[__DynamicallyInvokable]
		public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3)
		{
			this._val = string.Concat(new string[]
			{
				sourceInterface1.FullName,
				"\0",
				sourceInterface2.FullName,
				"\0",
				sourceInterface3.FullName
			});
		}

		// Token: 0x0600600C RID: 24588 RVA: 0x0014B71C File Offset: 0x0014991C
		[__DynamicallyInvokable]
		public ComSourceInterfacesAttribute(Type sourceInterface1, Type sourceInterface2, Type sourceInterface3, Type sourceInterface4)
		{
			this._val = string.Concat(new string[]
			{
				sourceInterface1.FullName,
				"\0",
				sourceInterface2.FullName,
				"\0",
				sourceInterface3.FullName,
				"\0",
				sourceInterface4.FullName
			});
		}

		// Token: 0x170010DB RID: 4315
		// (get) Token: 0x0600600D RID: 24589 RVA: 0x0014B77D File Offset: 0x0014997D
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A74 RID: 10868
		internal string _val;
	}
}
