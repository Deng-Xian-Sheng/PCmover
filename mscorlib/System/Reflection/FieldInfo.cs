using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.InteropServices;
using System.Security.Permissions;

namespace System.Reflection
{
	// Token: 0x020005E4 RID: 1508
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_FieldInfo))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class FieldInfo : MemberInfo, _FieldInfo
	{
		// Token: 0x060045E2 RID: 17890 RVA: 0x001016C8 File Offset: 0x000FF8C8
		[__DynamicallyInvokable]
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			FieldInfo fieldInfo = RuntimeType.GetFieldInfo(handle.GetRuntimeFieldInfo());
			Type declaringType = fieldInfo.DeclaringType;
			if (declaringType != null && declaringType.IsGenericType)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_FieldDeclaringTypeGeneric"), fieldInfo.Name, declaringType.GetGenericTypeDefinition()));
			}
			return fieldInfo;
		}

		// Token: 0x060045E3 RID: 17891 RVA: 0x0010173A File Offset: 0x000FF93A
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static FieldInfo GetFieldFromHandle(RuntimeFieldHandle handle, RuntimeTypeHandle declaringType)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return RuntimeType.GetFieldInfo(declaringType.GetRuntimeType(), handle.GetRuntimeFieldInfo());
		}

		// Token: 0x060045E5 RID: 17893 RVA: 0x00101770 File Offset: 0x000FF970
		[__DynamicallyInvokable]
		public static bool operator ==(FieldInfo left, FieldInfo right)
		{
			return left == right || (left != null && right != null && !(left is RuntimeFieldInfo) && !(right is RuntimeFieldInfo) && left.Equals(right));
		}

		// Token: 0x060045E6 RID: 17894 RVA: 0x00101797 File Offset: 0x000FF997
		[__DynamicallyInvokable]
		public static bool operator !=(FieldInfo left, FieldInfo right)
		{
			return !(left == right);
		}

		// Token: 0x060045E7 RID: 17895 RVA: 0x001017A3 File Offset: 0x000FF9A3
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060045E8 RID: 17896 RVA: 0x001017AC File Offset: 0x000FF9AC
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x17000A6F RID: 2671
		// (get) Token: 0x060045E9 RID: 17897 RVA: 0x001017B4 File Offset: 0x000FF9B4
		public override MemberTypes MemberType
		{
			get
			{
				return MemberTypes.Field;
			}
		}

		// Token: 0x060045EA RID: 17898 RVA: 0x001017B7 File Offset: 0x000FF9B7
		public virtual Type[] GetRequiredCustomModifiers()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045EB RID: 17899 RVA: 0x001017BE File Offset: 0x000FF9BE
		public virtual Type[] GetOptionalCustomModifiers()
		{
			throw new NotImplementedException();
		}

		// Token: 0x060045EC RID: 17900 RVA: 0x001017C5 File Offset: 0x000FF9C5
		[CLSCompliant(false)]
		public virtual void SetValueDirect(TypedReference obj, object value)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		// Token: 0x060045ED RID: 17901 RVA: 0x001017D6 File Offset: 0x000FF9D6
		[CLSCompliant(false)]
		public virtual object GetValueDirect(TypedReference obj)
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		// Token: 0x17000A70 RID: 2672
		// (get) Token: 0x060045EE RID: 17902
		[__DynamicallyInvokable]
		public abstract RuntimeFieldHandle FieldHandle { [__DynamicallyInvokable] get; }

		// Token: 0x17000A71 RID: 2673
		// (get) Token: 0x060045EF RID: 17903
		[__DynamicallyInvokable]
		public abstract Type FieldType { [__DynamicallyInvokable] get; }

		// Token: 0x060045F0 RID: 17904
		[__DynamicallyInvokable]
		public abstract object GetValue(object obj);

		// Token: 0x060045F1 RID: 17905 RVA: 0x001017E7 File Offset: 0x000FF9E7
		public virtual object GetRawConstantValue()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_AbstractNonCLS"));
		}

		// Token: 0x060045F2 RID: 17906
		public abstract void SetValue(object obj, object value, BindingFlags invokeAttr, Binder binder, CultureInfo culture);

		// Token: 0x17000A72 RID: 2674
		// (get) Token: 0x060045F3 RID: 17907
		[__DynamicallyInvokable]
		public abstract FieldAttributes Attributes { [__DynamicallyInvokable] get; }

		// Token: 0x060045F4 RID: 17908 RVA: 0x001017F8 File Offset: 0x000FF9F8
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public void SetValue(object obj, object value)
		{
			this.SetValue(obj, value, BindingFlags.Default, Type.DefaultBinder, null);
		}

		// Token: 0x17000A73 RID: 2675
		// (get) Token: 0x060045F5 RID: 17909 RVA: 0x00101809 File Offset: 0x000FFA09
		[__DynamicallyInvokable]
		public bool IsPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Public;
			}
		}

		// Token: 0x17000A74 RID: 2676
		// (get) Token: 0x060045F6 RID: 17910 RVA: 0x00101816 File Offset: 0x000FFA16
		[__DynamicallyInvokable]
		public bool IsPrivate
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Private;
			}
		}

		// Token: 0x17000A75 RID: 2677
		// (get) Token: 0x060045F7 RID: 17911 RVA: 0x00101823 File Offset: 0x000FFA23
		[__DynamicallyInvokable]
		public bool IsFamily
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Family;
			}
		}

		// Token: 0x17000A76 RID: 2678
		// (get) Token: 0x060045F8 RID: 17912 RVA: 0x00101830 File Offset: 0x000FFA30
		[__DynamicallyInvokable]
		public bool IsAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.Assembly;
			}
		}

		// Token: 0x17000A77 RID: 2679
		// (get) Token: 0x060045F9 RID: 17913 RVA: 0x0010183D File Offset: 0x000FFA3D
		[__DynamicallyInvokable]
		public bool IsFamilyAndAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamANDAssem;
			}
		}

		// Token: 0x17000A78 RID: 2680
		// (get) Token: 0x060045FA RID: 17914 RVA: 0x0010184A File Offset: 0x000FFA4A
		[__DynamicallyInvokable]
		public bool IsFamilyOrAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.FieldAccessMask) == FieldAttributes.FamORAssem;
			}
		}

		// Token: 0x17000A79 RID: 2681
		// (get) Token: 0x060045FB RID: 17915 RVA: 0x00101857 File Offset: 0x000FFA57
		[__DynamicallyInvokable]
		public bool IsStatic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.Static) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7A RID: 2682
		// (get) Token: 0x060045FC RID: 17916 RVA: 0x00101865 File Offset: 0x000FFA65
		[__DynamicallyInvokable]
		public bool IsInitOnly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.InitOnly) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7B RID: 2683
		// (get) Token: 0x060045FD RID: 17917 RVA: 0x00101873 File Offset: 0x000FFA73
		[__DynamicallyInvokable]
		public bool IsLiteral
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.Literal) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7C RID: 2684
		// (get) Token: 0x060045FE RID: 17918 RVA: 0x00101881 File Offset: 0x000FFA81
		public bool IsNotSerialized
		{
			get
			{
				return (this.Attributes & FieldAttributes.NotSerialized) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7D RID: 2685
		// (get) Token: 0x060045FF RID: 17919 RVA: 0x00101892 File Offset: 0x000FFA92
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & FieldAttributes.SpecialName) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7E RID: 2686
		// (get) Token: 0x06004600 RID: 17920 RVA: 0x001018A3 File Offset: 0x000FFAA3
		public bool IsPinvokeImpl
		{
			get
			{
				return (this.Attributes & FieldAttributes.PinvokeImpl) > FieldAttributes.PrivateScope;
			}
		}

		// Token: 0x17000A7F RID: 2687
		// (get) Token: 0x06004601 RID: 17921 RVA: 0x001018B4 File Offset: 0x000FFAB4
		public virtual bool IsSecurityCritical
		{
			get
			{
				return this.FieldHandle.IsSecurityCritical();
			}
		}

		// Token: 0x17000A80 RID: 2688
		// (get) Token: 0x06004602 RID: 17922 RVA: 0x001018D0 File Offset: 0x000FFAD0
		public virtual bool IsSecuritySafeCritical
		{
			get
			{
				return this.FieldHandle.IsSecuritySafeCritical();
			}
		}

		// Token: 0x17000A81 RID: 2689
		// (get) Token: 0x06004603 RID: 17923 RVA: 0x001018EC File Offset: 0x000FFAEC
		public virtual bool IsSecurityTransparent
		{
			get
			{
				return this.FieldHandle.IsSecurityTransparent();
			}
		}

		// Token: 0x06004604 RID: 17924 RVA: 0x00101907 File Offset: 0x000FFB07
		Type _FieldInfo.GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004605 RID: 17925 RVA: 0x0010190F File Offset: 0x000FFB0F
		void _FieldInfo.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004606 RID: 17926 RVA: 0x00101916 File Offset: 0x000FFB16
		void _FieldInfo.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004607 RID: 17927 RVA: 0x0010191D File Offset: 0x000FFB1D
		void _FieldInfo.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004608 RID: 17928 RVA: 0x00101924 File Offset: 0x000FFB24
		void _FieldInfo.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
