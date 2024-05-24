using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000907 RID: 2311
	[Guid("8A7C1442-A9FB-366B-80D8-4939FFA6DBE0")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(FieldInfo))]
	[ComVisible(true)]
	public interface _FieldInfo
	{
		// Token: 0x06005F76 RID: 24438
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005F77 RID: 24439
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005F78 RID: 24440
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005F79 RID: 24441
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		// Token: 0x06005F7A RID: 24442
		string ToString();

		// Token: 0x06005F7B RID: 24443
		bool Equals(object other);

		// Token: 0x06005F7C RID: 24444
		int GetHashCode();

		// Token: 0x06005F7D RID: 24445
		Type GetType();

		// Token: 0x170010AA RID: 4266
		// (get) Token: 0x06005F7E RID: 24446
		MemberTypes MemberType { get; }

		// Token: 0x170010AB RID: 4267
		// (get) Token: 0x06005F7F RID: 24447
		string Name { get; }

		// Token: 0x170010AC RID: 4268
		// (get) Token: 0x06005F80 RID: 24448
		Type DeclaringType { get; }

		// Token: 0x170010AD RID: 4269
		// (get) Token: 0x06005F81 RID: 24449
		Type ReflectedType { get; }

		// Token: 0x06005F82 RID: 24450
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005F83 RID: 24451
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005F84 RID: 24452
		bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x170010AE RID: 4270
		// (get) Token: 0x06005F85 RID: 24453
		Type FieldType { get; }

		// Token: 0x06005F86 RID: 24454
		object GetValue(object obj);

		// Token: 0x06005F87 RID: 24455
		object GetValueDirect(TypedReference obj);

		// Token: 0x06005F88 RID: 24456
		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);

		// Token: 0x06005F89 RID: 24457
		void SetValueDirect(TypedReference obj, object value);

		// Token: 0x170010AF RID: 4271
		// (get) Token: 0x06005F8A RID: 24458
		RuntimeFieldHandle FieldHandle { get; }

		// Token: 0x170010B0 RID: 4272
		// (get) Token: 0x06005F8B RID: 24459
		FieldAttributes Attributes { get; }

		// Token: 0x06005F8C RID: 24460
		void SetValue(object obj, object value);

		// Token: 0x170010B1 RID: 4273
		// (get) Token: 0x06005F8D RID: 24461
		bool IsPublic { get; }

		// Token: 0x170010B2 RID: 4274
		// (get) Token: 0x06005F8E RID: 24462
		bool IsPrivate { get; }

		// Token: 0x170010B3 RID: 4275
		// (get) Token: 0x06005F8F RID: 24463
		bool IsFamily { get; }

		// Token: 0x170010B4 RID: 4276
		// (get) Token: 0x06005F90 RID: 24464
		bool IsAssembly { get; }

		// Token: 0x170010B5 RID: 4277
		// (get) Token: 0x06005F91 RID: 24465
		bool IsFamilyAndAssembly { get; }

		// Token: 0x170010B6 RID: 4278
		// (get) Token: 0x06005F92 RID: 24466
		bool IsFamilyOrAssembly { get; }

		// Token: 0x170010B7 RID: 4279
		// (get) Token: 0x06005F93 RID: 24467
		bool IsStatic { get; }

		// Token: 0x170010B8 RID: 4280
		// (get) Token: 0x06005F94 RID: 24468
		bool IsInitOnly { get; }

		// Token: 0x170010B9 RID: 4281
		// (get) Token: 0x06005F95 RID: 24469
		bool IsLiteral { get; }

		// Token: 0x170010BA RID: 4282
		// (get) Token: 0x06005F96 RID: 24470
		bool IsNotSerialized { get; }

		// Token: 0x170010BB RID: 4283
		// (get) Token: 0x06005F97 RID: 24471
		bool IsSpecialName { get; }

		// Token: 0x170010BC RID: 4284
		// (get) Token: 0x06005F98 RID: 24472
		bool IsPinvokeImpl { get; }
	}
}
