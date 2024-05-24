using System;
using System.Reflection;

namespace System.Runtime.InteropServices
{
	// Token: 0x02000909 RID: 2313
	[Guid("9DE59C64-D889-35A1-B897-587D74469E5B")]
	[InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
	[CLSCompliant(false)]
	[TypeLibImportClass(typeof(EventInfo))]
	[ComVisible(true)]
	public interface _EventInfo
	{
		// Token: 0x06005FB8 RID: 24504
		void GetTypeInfoCount(out uint pcTInfo);

		// Token: 0x06005FB9 RID: 24505
		void GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo);

		// Token: 0x06005FBA RID: 24506
		void GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId);

		// Token: 0x06005FBB RID: 24507
		void Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr);

		// Token: 0x06005FBC RID: 24508
		string ToString();

		// Token: 0x06005FBD RID: 24509
		bool Equals(object other);

		// Token: 0x06005FBE RID: 24510
		int GetHashCode();

		// Token: 0x06005FBF RID: 24511
		Type GetType();

		// Token: 0x170010C6 RID: 4294
		// (get) Token: 0x06005FC0 RID: 24512
		MemberTypes MemberType { get; }

		// Token: 0x170010C7 RID: 4295
		// (get) Token: 0x06005FC1 RID: 24513
		string Name { get; }

		// Token: 0x170010C8 RID: 4296
		// (get) Token: 0x06005FC2 RID: 24514
		Type DeclaringType { get; }

		// Token: 0x170010C9 RID: 4297
		// (get) Token: 0x06005FC3 RID: 24515
		Type ReflectedType { get; }

		// Token: 0x06005FC4 RID: 24516
		object[] GetCustomAttributes(Type attributeType, bool inherit);

		// Token: 0x06005FC5 RID: 24517
		object[] GetCustomAttributes(bool inherit);

		// Token: 0x06005FC6 RID: 24518
		bool IsDefined(Type attributeType, bool inherit);

		// Token: 0x06005FC7 RID: 24519
		MethodInfo GetAddMethod(bool nonPublic);

		// Token: 0x06005FC8 RID: 24520
		MethodInfo GetRemoveMethod(bool nonPublic);

		// Token: 0x06005FC9 RID: 24521
		MethodInfo GetRaiseMethod(bool nonPublic);

		// Token: 0x170010CA RID: 4298
		// (get) Token: 0x06005FCA RID: 24522
		EventAttributes Attributes { get; }

		// Token: 0x06005FCB RID: 24523
		MethodInfo GetAddMethod();

		// Token: 0x06005FCC RID: 24524
		MethodInfo GetRemoveMethod();

		// Token: 0x06005FCD RID: 24525
		MethodInfo GetRaiseMethod();

		// Token: 0x06005FCE RID: 24526
		void AddEventHandler(object target, Delegate handler);

		// Token: 0x06005FCF RID: 24527
		void RemoveEventHandler(object target, Delegate handler);

		// Token: 0x170010CB RID: 4299
		// (get) Token: 0x06005FD0 RID: 24528
		Type EventHandlerType { get; }

		// Token: 0x170010CC RID: 4300
		// (get) Token: 0x06005FD1 RID: 24529
		bool IsSpecialName { get; }

		// Token: 0x170010CD RID: 4301
		// (get) Token: 0x06005FD2 RID: 24530
		bool IsMulticast { get; }
	}
}
