using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003ED RID: 1005
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerTypeProxyAttribute : Attribute
	{
		// Token: 0x0600330D RID: 13069 RVA: 0x000C4BF4 File Offset: 0x000C2DF4
		[__DynamicallyInvokable]
		public DebuggerTypeProxyAttribute(Type type)
		{
			if (type == null)
			{
				throw new ArgumentNullException("type");
			}
			this.typeName = type.AssemblyQualifiedName;
		}

		// Token: 0x0600330E RID: 13070 RVA: 0x000C4C1C File Offset: 0x000C2E1C
		[__DynamicallyInvokable]
		public DebuggerTypeProxyAttribute(string typeName)
		{
			this.typeName = typeName;
		}

		// Token: 0x17000776 RID: 1910
		// (get) Token: 0x0600330F RID: 13071 RVA: 0x000C4C2B File Offset: 0x000C2E2B
		[__DynamicallyInvokable]
		public string ProxyTypeName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.typeName;
			}
		}

		// Token: 0x17000777 RID: 1911
		// (get) Token: 0x06003311 RID: 13073 RVA: 0x000C4C5C File Offset: 0x000C2E5C
		// (set) Token: 0x06003310 RID: 13072 RVA: 0x000C4C33 File Offset: 0x000C2E33
		[__DynamicallyInvokable]
		public Type Target
		{
			[__DynamicallyInvokable]
			get
			{
				return this.target;
			}
			[__DynamicallyInvokable]
			set
			{
				if (value == null)
				{
					throw new ArgumentNullException("value");
				}
				this.targetName = value.AssemblyQualifiedName;
				this.target = value;
			}
		}

		// Token: 0x17000778 RID: 1912
		// (get) Token: 0x06003312 RID: 13074 RVA: 0x000C4C64 File Offset: 0x000C2E64
		// (set) Token: 0x06003313 RID: 13075 RVA: 0x000C4C6C File Offset: 0x000C2E6C
		[__DynamicallyInvokable]
		public string TargetTypeName
		{
			[__DynamicallyInvokable]
			get
			{
				return this.targetName;
			}
			[__DynamicallyInvokable]
			set
			{
				this.targetName = value;
			}
		}

		// Token: 0x040016A1 RID: 5793
		private string typeName;

		// Token: 0x040016A2 RID: 5794
		private string targetName;

		// Token: 0x040016A3 RID: 5795
		private Type target;
	}
}
