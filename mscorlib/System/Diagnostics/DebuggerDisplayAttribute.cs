using System;
using System.Runtime.InteropServices;

namespace System.Diagnostics
{
	// Token: 0x020003EE RID: 1006
	[AttributeUsage(AttributeTargets.Assembly | AttributeTargets.Class | AttributeTargets.Struct | AttributeTargets.Enum | AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Delegate, AllowMultiple = true)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class DebuggerDisplayAttribute : Attribute
	{
		// Token: 0x06003314 RID: 13076 RVA: 0x000C4C75 File Offset: 0x000C2E75
		[__DynamicallyInvokable]
		public DebuggerDisplayAttribute(string value)
		{
			if (value == null)
			{
				this.value = "";
			}
			else
			{
				this.value = value;
			}
			this.name = "";
			this.type = "";
		}

		// Token: 0x17000779 RID: 1913
		// (get) Token: 0x06003315 RID: 13077 RVA: 0x000C4CAA File Offset: 0x000C2EAA
		[__DynamicallyInvokable]
		public string Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this.value;
			}
		}

		// Token: 0x1700077A RID: 1914
		// (get) Token: 0x06003316 RID: 13078 RVA: 0x000C4CB2 File Offset: 0x000C2EB2
		// (set) Token: 0x06003317 RID: 13079 RVA: 0x000C4CBA File Offset: 0x000C2EBA
		[__DynamicallyInvokable]
		public string Name
		{
			[__DynamicallyInvokable]
			get
			{
				return this.name;
			}
			[__DynamicallyInvokable]
			set
			{
				this.name = value;
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06003318 RID: 13080 RVA: 0x000C4CC3 File Offset: 0x000C2EC3
		// (set) Token: 0x06003319 RID: 13081 RVA: 0x000C4CCB File Offset: 0x000C2ECB
		[__DynamicallyInvokable]
		public string Type
		{
			[__DynamicallyInvokable]
			get
			{
				return this.type;
			}
			[__DynamicallyInvokable]
			set
			{
				this.type = value;
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x0600331B RID: 13083 RVA: 0x000C4CFD File Offset: 0x000C2EFD
		// (set) Token: 0x0600331A RID: 13082 RVA: 0x000C4CD4 File Offset: 0x000C2ED4
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

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x0600331C RID: 13084 RVA: 0x000C4D05 File Offset: 0x000C2F05
		// (set) Token: 0x0600331D RID: 13085 RVA: 0x000C4D0D File Offset: 0x000C2F0D
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

		// Token: 0x040016A4 RID: 5796
		private string name;

		// Token: 0x040016A5 RID: 5797
		private string value;

		// Token: 0x040016A6 RID: 5798
		private string type;

		// Token: 0x040016A7 RID: 5799
		private string targetName;

		// Token: 0x040016A8 RID: 5800
		private Type target;
	}
}
