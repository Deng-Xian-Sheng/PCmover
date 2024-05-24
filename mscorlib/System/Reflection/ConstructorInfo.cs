using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x020005D1 RID: 1489
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_ConstructorInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class ConstructorInfo : MethodBase, _ConstructorInfo
	{
		// Token: 0x060044E2 RID: 17634 RVA: 0x000FD238 File Offset: 0x000FB438
		[__DynamicallyInvokable]
		public static bool operator ==(ConstructorInfo left, ConstructorInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeConstructorInfo) && !(right is RuntimeConstructorInfo) && left.Equals(right));
		}

		// Token: 0x060044E3 RID: 17635 RVA: 0x000FD25F File Offset: 0x000FB45F
		[__DynamicallyInvokable]
		public static bool operator !=(ConstructorInfo left, ConstructorInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060044E4 RID: 17636 RVA: 0x000FD26B File Offset: 0x000FB46B
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060044E5 RID: 17637 RVA: 0x000FD274 File Offset: 0x000FB474
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060044E6 RID: 17638 RVA: 0x000FD27C File Offset: 0x000FB47C
		internal virtual Type GetReturnType()
		{
			throw new NotImplementedException();
		}

		// Token: 0x17000A32 RID: 2610
		// (get) Token: 0x060044E7 RID: 17639 RVA: 0x000FD283 File Offset: 0x000FB483
		[ComVisible(true)]
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Constructor;
			}
		}

		// Token: 0x060044E8 RID: 17640
		public abstract object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		// Token: 0x060044E9 RID: 17641 RVA: 0x000FD286 File Offset: 0x000FB486
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public object Invoke(object[] parameters)
		{
			return this.Invoke(BindingFlags.Default, null, parameters, null);
		}

		// Token: 0x060044EA RID: 17642 RVA: 0x000FD292 File Offset: 0x000FB492
		Type _ConstructorInfo.GetType()
		{
			return base.GetType();
		}

		// Token: 0x060044EB RID: 17643 RVA: 0x000FD29A File Offset: 0x000FB49A
		object _ConstructorInfo.Invoke_2(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			return this.Invoke(obj, invokeAttr, binder, parameters, culture);
		}

		// Token: 0x060044EC RID: 17644 RVA: 0x000FD2A9 File Offset: 0x000FB4A9
		object _ConstructorInfo.Invoke_3(object obj, object[] parameters)
		{
			return base.Invoke(obj, parameters);
		}

		// Token: 0x060044ED RID: 17645 RVA: 0x000FD2B3 File Offset: 0x000FB4B3
		object _ConstructorInfo.Invoke_4(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			return this.Invoke(invokeAttr, binder, parameters, culture);
		}

		// Token: 0x060044EE RID: 17646 RVA: 0x000FD2C0 File Offset: 0x000FB4C0
		object _ConstructorInfo.Invoke_5(object[] parameters)
		{
			return this.Invoke(parameters);
		}

		// Token: 0x060044EF RID: 17647 RVA: 0x000FD2C9 File Offset: 0x000FB4C9
		void _ConstructorInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060044F0 RID: 17648 RVA: 0x000FD2D0 File Offset: 0x000FB4D0
		void _ConstructorInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060044F1 RID: 17649 RVA: 0x000FD2D7 File Offset: 0x000FB4D7
		void _ConstructorInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x060044F2 RID: 17650 RVA: 0x000FD2DE File Offset: 0x000FB4DE
		void _ConstructorInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}

		// Token: 0x04001C43 RID: 7235
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public static readonly string ConstructorName = ".ctor";

		// Token: 0x04001C44 RID: 7236
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public static readonly string TypeConstructorName = ".cctor";
	}
}
