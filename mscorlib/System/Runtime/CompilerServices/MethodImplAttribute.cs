using System;
using System.Reflection;
using System.Runtime.InteropServices;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008BE RID: 2238
	[AttributeUsage(AttributeTargets.Constructor | AttributeTargets.Method, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[Serializable]
	public sealed class MethodImplAttribute : Attribute
	{
		// Token: 0x06005DAE RID: 23982 RVA: 0x00149730 File Offset: 0x00147930
		internal MethodImplAttribute(MethodImplAttributes methodImplAttributes)
		{
			MethodImplOptions methodImplOptions = MethodImplOptions.Unmanaged | MethodImplOptions.ForwardRef | MethodImplOptions.PreserveSig | MethodImplOptions.InternalCall | MethodImplOptions.Synchronized | MethodImplOptions.NoInlining | MethodImplOptions.AggressiveInlining | MethodImplOptions.NoOptimization | MethodImplOptions.SecurityMitigations;
			this._val = (MethodImplOptions)(methodImplAttributes & (MethodImplAttributes)methodImplOptions);
		}

		// Token: 0x06005DAF RID: 23983 RVA: 0x00149752 File Offset: 0x00147952
		[__DynamicallyInvokable]
		public MethodImplAttribute(MethodImplOptions methodImplOptions)
		{
			this._val = methodImplOptions;
		}

		// Token: 0x06005DB0 RID: 23984 RVA: 0x00149761 File Offset: 0x00147961
		public MethodImplAttribute(short value)
		{
			this._val = (MethodImplOptions)value;
		}

		// Token: 0x06005DB1 RID: 23985 RVA: 0x00149770 File Offset: 0x00147970
		public MethodImplAttribute()
		{
		}

		// Token: 0x17001018 RID: 4120
		// (get) Token: 0x06005DB2 RID: 23986 RVA: 0x00149778 File Offset: 0x00147978
		[__DynamicallyInvokable]
		public MethodImplOptions Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002A22 RID: 10786
		internal MethodImplOptions _val;

		// Token: 0x04002A23 RID: 10787
		public MethodCodeType MethodCodeType;
	}
}
