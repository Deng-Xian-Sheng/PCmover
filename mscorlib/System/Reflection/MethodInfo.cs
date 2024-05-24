using System;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x02000607 RID: 1543
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MethodInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MethodInfo : MethodBase, _MethodInfo
	{
		// Token: 0x0600472D RID: 18221 RVA: 0x00103B38 File Offset: 0x00101D38
		[__DynamicallyInvokable]
		public static bool operator ==(MethodInfo left, MethodInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeMethodInfo) && !(right is RuntimeMethodInfo) && left.Equals(right));
		}

		// Token: 0x0600472E RID: 18222 RVA: 0x00103B5F File Offset: 0x00101D5F
		[__DynamicallyInvokable]
		public static bool operator !=(MethodInfo left, MethodInfo right)
		{
			return !(left == right);
		}

		// Token: 0x0600472F RID: 18223 RVA: 0x00103B6B File Offset: 0x00101D6B
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x06004730 RID: 18224 RVA: 0x00103B74 File Offset: 0x00101D74
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000AE0 RID: 2784
		// (get) Token: 0x06004731 RID: 18225 RVA: 0x00103B7C File Offset: 0x00101D7C
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Method;
			}
		}

		// Token: 0x17000AE1 RID: 2785
		// (get) Token: 0x06004732 RID: 18226 RVA: 0x00103B7F File Offset: 0x00101D7F
		[__DynamicallyInvokable]
		public virtual Type ReturnType
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000AE2 RID: 2786
		// (get) Token: 0x06004733 RID: 18227 RVA: 0x00103B86 File Offset: 0x00101D86
		[__DynamicallyInvokable]
		public virtual ParameterInfo ReturnParameter
		{
			[__DynamicallyInvokable]
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000AE3 RID: 2787
		// (get) Token: 0x06004734 RID: 18228
		public abstract ICustomAttributeProvider ReturnTypeCustomAttributes { get; }

		// Token: 0x06004735 RID: 18229
		[__DynamicallyInvokable]
		public abstract MethodInfo GetBaseDefinition();

		// Token: 0x06004736 RID: 18230 RVA: 0x00103B8D File Offset: 0x00101D8D
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public override Type[] GetGenericArguments()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x06004737 RID: 18231 RVA: 0x00103B9E File Offset: 0x00101D9E
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual MethodInfo GetGenericMethodDefinition()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x06004738 RID: 18232 RVA: 0x00103BAF File Offset: 0x00101DAF
		[__DynamicallyInvokable]
		public virtual MethodInfo MakeGenericMethod(params Type[] typeArguments)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x06004739 RID: 18233 RVA: 0x00103BC0 File Offset: 0x00101DC0
		[__DynamicallyInvokable]
		public virtual Delegate CreateDelegate(Type delegateType)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x0600473A RID: 18234 RVA: 0x00103BD1 File Offset: 0x00101DD1
		[__DynamicallyInvokable]
		public virtual Delegate CreateDelegate(Type delegateType, object target)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x0600473B RID: 18235 RVA: 0x00103BE2 File Offset: 0x00101DE2
		Type _MethodInfo.GetType()
		{
			return base.GetType();
		}

		// Token: 0x0600473C RID: 18236 RVA: 0x00103BEA File Offset: 0x00101DEA
		void _MethodInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600473D RID: 18237 RVA: 0x00103BF1 File Offset: 0x00101DF1
		void _MethodInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600473E RID: 18238 RVA: 0x00103BF8 File Offset: 0x00101DF8
		void _MethodInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600473F RID: 18239 RVA: 0x00103BFF File Offset: 0x00101DFF
		void _MethodInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
