using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000935 RID: 2357
	[AttributeUsage(AttributeTargets.Field, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class FieldOffsetAttribute : Attribute
	{
		// Token: 0x0600603F RID: 24639 RVA: 0x0014BD38 File Offset: 0x00149F38
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeFieldInfo field)
		{
			int offset;
			if (field.DeclaringType != null && field.GetRuntimeModule().MetadataImport.GetFieldOffset(field.DeclaringType.MetadataToken, field.MetadataToken, out offset))
			{
				return new FieldOffsetAttribute(offset);
			}
			return null;
		}

		// Token: 0x06006040 RID: 24640 RVA: 0x0014BD83 File Offset: 0x00149F83
		[SecurityCritical]
		internal static bool IsDefined(RuntimeFieldInfo field)
		{
			return FieldOffsetAttribute.GetCustomAttribute(field) != null;
		}

		// Token: 0x06006041 RID: 24641 RVA: 0x0014BD8E File Offset: 0x00149F8E
		[__DynamicallyInvokable]
		public FieldOffsetAttribute(int offset)
		{
			this._val = offset;
		}

		// Token: 0x170010E4 RID: 4324
		// (get) Token: 0x06006042 RID: 24642 RVA: 0x0014BD9D File Offset: 0x00149F9D
		[__DynamicallyInvokable]
		public int Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002B19 RID: 11033
		internal int _val;
	}
}
