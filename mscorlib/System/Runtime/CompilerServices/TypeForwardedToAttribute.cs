using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.CompilerServices
{
	// Token: 0x020008DF RID: 2271
	[AttributeUsage(AttributeTargets.Assembly, AllowMultiple = true, Inherited = false)]
	[__DynamicallyInvokable]
	public sealed class TypeForwardedToAttribute : Attribute
	{
		// Token: 0x06005DD2 RID: 24018 RVA: 0x001498AF File Offset: 0x00147AAF
		[__DynamicallyInvokable]
		public TypeForwardedToAttribute(Type destination)
		{
			this._destination = destination;
		}

		// Token: 0x1700101D RID: 4125
		// (get) Token: 0x06005DD3 RID: 24019 RVA: 0x001498BE File Offset: 0x00147ABE
		[__DynamicallyInvokable]
		public Type Destination
		{
			[__DynamicallyInvokable]
			get
			{
				return this._destination;
			}
		}

		// Token: 0x06005DD4 RID: 24020 RVA: 0x001498C8 File Offset: 0x00147AC8
		[SecurityCritical]
		internal static TypeForwardedToAttribute[] GetCustomAttribute(RuntimeAssembly assembly)
		{
			Type[] array = null;
			RuntimeAssembly.GetForwardedTypes(assembly.GetNativeHandle(), JitHelpers.GetObjectHandleOnStack<Type[]>(ref array));
			TypeForwardedToAttribute[] array2 = new TypeForwardedToAttribute[array.Length];
			for (int i = 0; i < array.Length; i++)
			{
				array2[i] = new TypeForwardedToAttribute(array[i]);
			}
			return array2;
		}

		// Token: 0x04002A32 RID: 10802
		private Type _destination;
	}
}
