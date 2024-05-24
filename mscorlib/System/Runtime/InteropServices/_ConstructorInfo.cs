﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000906 RID: 2310
	[Guid("E9A19478-9646-3679-9B10-8411AE1FD57D")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(ConstructorInfo))]
	[ComVisible(true)]
	public interface _ConstructorInfo
	{
		// Token: 0x06005F51 RID: 24401
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005F52 RID: 24402
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005F53 RID: 24403
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005F54 RID: 24404
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		// Token: 0x06005F55 RID: 24405
		string ToString();

		// Token: 0x06005F56 RID: 24406
		bool Equals(object other);

		// Token: 0x06005F57 RID: 24407
		int GetHashCode();

		// Token: 0x06005F58 RID: 24408
		Type GetType();

		// Token: 0x17001096 RID: 4246
		// (get) Token: 0x06005F59 RID: 24409
		MemberTypes MemberType { get; }

		// Token: 0x17001097 RID: 4247
		// (get) Token: 0x06005F5A RID: 24410
		string Name { get; }

		// Token: 0x17001098 RID: 4248
		// (get) Token: 0x06005F5B RID: 24411
		Type DeclaringType { get; }

		// Token: 0x17001099 RID: 4249
		// (get) Token: 0x06005F5C RID: 24412
		Type ReflectedType { get; }

		// Token: 0x06005F5D RID: 24413
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005F5E RID: 24414
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005F5F RID: 24415
		bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x06005F60 RID: 24416
		ParameterInfo[] GetParameters();

		// Token: 0x06005F61 RID: 24417
		MethodImplAttributes GetMethodImplementationFlags();

		// Token: 0x1700109A RID: 4250
		// (get) Token: 0x06005F62 RID: 24418
		RuntimeMethodHandle MethodHandle { get; }

		// Token: 0x1700109B RID: 4251
		// (get) Token: 0x06005F63 RID: 24419
		MethodAttributes Attributes { get; }

		// Token: 0x1700109C RID: 4252
		// (get) Token: 0x06005F64 RID: 24420
		CallingConventions CallingConvention { get; }

		// Token: 0x06005F65 RID: 24421
		object Invoke_2(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		// Token: 0x1700109D RID: 4253
		// (get) Token: 0x06005F66 RID: 24422
		bool IsPublic { get; }

		// Token: 0x1700109E RID: 4254
		// (get) Token: 0x06005F67 RID: 24423
		bool IsPrivate { get; }

		// Token: 0x1700109F RID: 4255
		// (get) Token: 0x06005F68 RID: 24424
		bool IsFamily { get; }

		// Token: 0x170010A0 RID: 4256
		// (get) Token: 0x06005F69 RID: 24425
		bool IsAssembly { get; }

		// Token: 0x170010A1 RID: 4257
		// (get) Token: 0x06005F6A RID: 24426
		bool IsFamilyAndAssembly { get; }

		// Token: 0x170010A2 RID: 4258
		// (get) Token: 0x06005F6B RID: 24427
		bool IsFamilyOrAssembly { get; }

		// Token: 0x170010A3 RID: 4259
		// (get) Token: 0x06005F6C RID: 24428
		bool IsStatic { get; }

		// Token: 0x170010A4 RID: 4260
		// (get) Token: 0x06005F6D RID: 24429
		bool IsFinal { get; }

		// Token: 0x170010A5 RID: 4261
		// (get) Token: 0x06005F6E RID: 24430
		bool IsVirtual { get; }

		// Token: 0x170010A6 RID: 4262
		// (get) Token: 0x06005F6F RID: 24431
		bool IsHideBySig { get; }

		// Token: 0x170010A7 RID: 4263
		// (get) Token: 0x06005F70 RID: 24432
		bool IsAbstract { get; }

		// Token: 0x170010A8 RID: 4264
		// (get) Token: 0x06005F71 RID: 24433
		bool IsSpecialName { get; }

		// Token: 0x170010A9 RID: 4265
		// (get) Token: 0x06005F72 RID: 24434
		bool IsConstructor { get; }

		// Token: 0x06005F73 RID: 24435
		object Invoke_3(object obj, object[] parameters);

		// Token: 0x06005F74 RID: 24436
		object Invoke_4(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		// Token: 0x06005F75 RID: 24437
		object Invoke_5(object[] parameters);
	}
}
