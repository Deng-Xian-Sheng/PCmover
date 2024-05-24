using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000903 RID: 2307
	[Guid("f7102fa9-cabb-3a74-a6da-b4567ef1b079")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[TypeLibImportClass(typeof(MemberInfo))]
	[CLSCompliant(false)]
	[ComVisible(true)]
	public interface _MemberInfo
	{
		// Token: 0x06005EF9 RID: 24313
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005EFA RID: 24314
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005EFB RID: 24315
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005EFC RID: 24316
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		// Token: 0x06005EFD RID: 24317
		string ToString();

		// Token: 0x06005EFE RID: 24318
		bool Equals(object other);

		// Token: 0x06005EFF RID: 24319
		int GetHashCode();

		// Token: 0x06005F00 RID: 24320
		Type GetType();

		// Token: 0x17001068 RID: 4200
		// (get) Token: 0x06005F01 RID: 24321
		MemberTypes MemberType { get; }

		// Token: 0x17001069 RID: 4201
		// (get) Token: 0x06005F02 RID: 24322
		string Name { get; }

		// Token: 0x1700106A RID: 4202
		// (get) Token: 0x06005F03 RID: 24323
		Type DeclaringType { get; }

		// Token: 0x1700106B RID: 4203
		// (get) Token: 0x06005F04 RID: 24324
		Type ReflectedType { get; }

		// Token: 0x06005F05 RID: 24325
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005F06 RID: 24326
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005F07 RID: 24327
		bool IsDefined(Type attributeType, bool inherit);
	}
}
