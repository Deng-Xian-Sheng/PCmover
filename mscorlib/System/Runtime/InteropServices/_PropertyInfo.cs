﻿using System;
using System.Globalization;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000908 RID: 2312
	[Guid("F59ED4E4-E68F-3218-BD77-061AA82824BF")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(PropertyInfo))]
	[ComVisible(true)]
	public interface _PropertyInfo
	{
		// Token: 0x06005F99 RID: 24473
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005F9A RID: 24474
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005F9B RID: 24475
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005F9C RID: 24476
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		// Token: 0x06005F9D RID: 24477
		string ToString();

		// Token: 0x06005F9E RID: 24478
		bool Equals(object other);

		// Token: 0x06005F9F RID: 24479
		int GetHashCode();

		// Token: 0x06005FA0 RID: 24480
		Type GetType();

		// Token: 0x170010BD RID: 4285
		// (get) Token: 0x06005FA1 RID: 24481
		MemberTypes MemberType { get; }

		// Token: 0x170010BE RID: 4286
		// (get) Token: 0x06005FA2 RID: 24482
		string Name { get; }

		// Token: 0x170010BF RID: 4287
		// (get) Token: 0x06005FA3 RID: 24483
		Type DeclaringType { get; }

		// Token: 0x170010C0 RID: 4288
		// (get) Token: 0x06005FA4 RID: 24484
		Type ReflectedType { get; }

		// Token: 0x06005FA5 RID: 24485
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005FA6 RID: 24486
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005FA7 RID: 24487
		bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x170010C1 RID: 4289
		// (get) Token: 0x06005FA8 RID: 24488
		Type PropertyType { get; }

		// Token: 0x06005FA9 RID: 24489
		object GetValue(object obj, object[] index);

		// Token: 0x06005FAA RID: 24490
		object GetValue(object obj, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);

		// Token: 0x06005FAB RID: 24491
		void SetValue(object obj, object value, object[] index);

		// Token: 0x06005FAC RID: 24492
		void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, object[] index, CultureInfo culture);

		// Token: 0x06005FAD RID: 24493
		MethodInfo[] GetAccessors(bool nonPublic);

		// Token: 0x06005FAE RID: 24494
		MethodInfo GetGetMethod(bool nonPublic);

		// Token: 0x06005FAF RID: 24495
		MethodInfo GetSetMethod(bool nonPublic);

		// Token: 0x06005FB0 RID: 24496
		ParameterInfo[] GetIndexParameters();

		// Token: 0x170010C2 RID: 4290
		// (get) Token: 0x06005FB1 RID: 24497
		PropertyAttributes Attributes { get; }

		// Token: 0x170010C3 RID: 4291
		// (get) Token: 0x06005FB2 RID: 24498
		bool CanRead { get; }

		// Token: 0x170010C4 RID: 4292
		// (get) Token: 0x06005FB3 RID: 24499
		bool CanWrite { get; }

		// Token: 0x06005FB4 RID: 24500
		MethodInfo[] GetAccessors();

		// Token: 0x06005FB5 RID: 24501
		MethodInfo GetGetMethod();

		// Token: 0x06005FB6 RID: 24502
		MethodInfo GetSetMethod();

		// Token: 0x170010C5 RID: 4293
		// (get) Token: 0x06005FB7 RID: 24503
		bool IsSpecialName { get; }
	}
}
