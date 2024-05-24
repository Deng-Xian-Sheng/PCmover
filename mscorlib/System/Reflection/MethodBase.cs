using System;
using System.Diagnostics;
using System.Globalization;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;
using System.Security.Permissions;
using System.Text;
using System.Threading;

namespace System.Reflection
{
	// Token: 0x02000605 RID: 1541
	[ClassInterface(ClassInterfaceType.None)]
	[ComDefaultInterface(typeof(_MethodBase))]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	[PermissionSet(SecurityAction.InheritanceDemand, Name = "FullTrust")]
	[Serializable]
	public abstract class MethodBase : MemberInfo, _MethodBase
	{
		// Token: 0x060046EC RID: 18156 RVA: 0x00103644 File Offset: 0x00101844
		[__DynamicallyInvokable]
		public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			MethodBase methodBase = RuntimeType.GetMethodBase(handle.GetMethodInfo());
			Type declaringType = methodBase.DeclaringType;
			if (declaringType != null && declaringType.IsGenericType)
			{
				throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_MethodDeclaringTypeGeneric"), methodBase, declaringType.GetGenericTypeDefinition()));
			}
			return methodBase;
		}

		// Token: 0x060046ED RID: 18157 RVA: 0x001036B1 File Offset: 0x001018B1
		[ComVisible(false)]
		[__DynamicallyInvokable]
		public static MethodBase GetMethodFromHandle(RuntimeMethodHandle handle, RuntimeTypeHandle declaringType)
		{
			if (handle.IsNullHandle())
			{
				throw new ArgumentException(Environment.GetResourceString("Argument_InvalidHandle"));
			}
			return RuntimeType.GetMethodBase(declaringType.GetRuntimeType(), handle.GetMethodInfo());
		}

		// Token: 0x060046EE RID: 18158 RVA: 0x001036E0 File Offset: 0x001018E0
		[MethodImpl(MethodImplOptions.NoInlining)]
		public static MethodBase GetCurrentMethod()
		{
			StackCrawlMark stackCrawlMark = StackCrawlMark.LookForMyCaller;
			return RuntimeMethodInfo.InternalGetCurrentMethod(ref stackCrawlMark);
		}

		// Token: 0x060046F0 RID: 18160 RVA: 0x00103700 File Offset: 0x00101900
		[__DynamicallyInvokable]
		public static bool operator ==(MethodBase left, MethodBase right)
		{
			if (left == right)
			{
				return true;
			}
			if (left == null || right == null)
			{
				return false;
			}
			MethodInfo left2;
			MethodInfo right2;
			if ((left2 = (left as MethodInfo)) != null && (right2 = (right as MethodInfo)) != null)
			{
				return left2 == right2;
			}
			ConstructorInfo left3;
			ConstructorInfo right3;
			return (left3 = (left as ConstructorInfo)) != null && (right3 = (right as ConstructorInfo)) != null && left3 == right3;
		}

		// Token: 0x060046F1 RID: 18161 RVA: 0x0010376C File Offset: 0x0010196C
		[__DynamicallyInvokable]
		public static bool operator !=(MethodBase left, MethodBase right)
		{
			return !(left == right);
		}

		// Token: 0x060046F2 RID: 18162 RVA: 0x00103778 File Offset: 0x00101978
		[__DynamicallyInvokable]
		public override bool Equals(object obj)
		{
			return base.Equals(obj);
		}

		// Token: 0x060046F3 RID: 18163 RVA: 0x00103781 File Offset: 0x00101981
		[__DynamicallyInvokable]
		public override int GetHashCode()
		{
			return base.GetHashCode();
		}

		// Token: 0x060046F4 RID: 18164 RVA: 0x0010378C File Offset: 0x0010198C
		[SecurityCritical]
		private IntPtr GetMethodDesc()
		{
			return this.MethodHandle.Value;
		}

		// Token: 0x17000ABA RID: 2746
		// (get) Token: 0x060046F5 RID: 18165 RVA: 0x001037A7 File Offset: 0x001019A7
		internal virtual bool IsDynamicallyInvokable
		{
			[__DynamicallyInvokable]
			get
			{
				return true;
			}
		}

		// Token: 0x060046F6 RID: 18166 RVA: 0x001037AA File Offset: 0x001019AA
		internal virtual ParameterInfo[] GetParametersNoCopy()
		{
			return this.GetParameters();
		}

		// Token: 0x060046F7 RID: 18167
		[__DynamicallyInvokable]
		public abstract ParameterInfo[] GetParameters();

		// Token: 0x17000ABB RID: 2747
		// (get) Token: 0x060046F8 RID: 18168 RVA: 0x001037B2 File Offset: 0x001019B2
		[__DynamicallyInvokable]
		public virtual MethodImplAttributes MethodImplementationFlags
		{
			[__DynamicallyInvokable]
			get
			{
				return this.GetMethodImplementationFlags();
			}
		}

		// Token: 0x060046F9 RID: 18169
		public abstract MethodImplAttributes GetMethodImplementationFlags();

		// Token: 0x17000ABC RID: 2748
		// (get) Token: 0x060046FA RID: 18170
		[__DynamicallyInvokable]
		public abstract RuntimeMethodHandle MethodHandle { [__DynamicallyInvokable] get; }

		// Token: 0x17000ABD RID: 2749
		// (get) Token: 0x060046FB RID: 18171
		[__DynamicallyInvokable]
		public abstract MethodAttributes Attributes { [__DynamicallyInvokable] get; }

		// Token: 0x060046FC RID: 18172
		public abstract object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture);

		// Token: 0x17000ABE RID: 2750
		// (get) Token: 0x060046FD RID: 18173 RVA: 0x001037BA File Offset: 0x001019BA
		[__DynamicallyInvokable]
		public virtual CallingConventions CallingConvention
		{
			[__DynamicallyInvokable]
			get
			{
				return CallingConventions.Standard;
			}
		}

		// Token: 0x060046FE RID: 18174 RVA: 0x001037BD File Offset: 0x001019BD
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public virtual Type[] GetGenericArguments()
		{
			throw new NotSupportedException(Environment.GetResourceString("NotSupported_SubclassOverride"));
		}

		// Token: 0x17000ABF RID: 2751
		// (get) Token: 0x060046FF RID: 18175 RVA: 0x001037CE File Offset: 0x001019CE
		[__DynamicallyInvokable]
		public virtual bool IsGenericMethodDefinition
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x17000AC0 RID: 2752
		// (get) Token: 0x06004700 RID: 18176 RVA: 0x001037D1 File Offset: 0x001019D1
		[__DynamicallyInvokable]
		public virtual bool ContainsGenericParameters
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x17000AC1 RID: 2753
		// (get) Token: 0x06004701 RID: 18177 RVA: 0x001037D4 File Offset: 0x001019D4
		[__DynamicallyInvokable]
		public virtual bool IsGenericMethod
		{
			[__DynamicallyInvokable]
			get
			{
				return false;
			}
		}

		// Token: 0x17000AC2 RID: 2754
		// (get) Token: 0x06004702 RID: 18178 RVA: 0x001037D7 File Offset: 0x001019D7
		public virtual bool IsSecurityCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000AC3 RID: 2755
		// (get) Token: 0x06004703 RID: 18179 RVA: 0x001037DE File Offset: 0x001019DE
		public virtual bool IsSecuritySafeCritical
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x17000AC4 RID: 2756
		// (get) Token: 0x06004704 RID: 18180 RVA: 0x001037E5 File Offset: 0x001019E5
		public virtual bool IsSecurityTransparent
		{
			get
			{
				throw new NotImplementedException();
			}
		}

		// Token: 0x06004705 RID: 18181 RVA: 0x001037EC File Offset: 0x001019EC
		[DebuggerStepThrough]
		[DebuggerHidden]
		[__DynamicallyInvokable]
		public object Invoke(object obj, object[] parameters)
		{
			return this.Invoke(obj, BindingFlags.Default, null, parameters, null);
		}

		// Token: 0x17000AC5 RID: 2757
		// (get) Token: 0x06004706 RID: 18182 RVA: 0x001037F9 File Offset: 0x001019F9
		[__DynamicallyInvokable]
		public bool IsPublic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Public;
			}
		}

		// Token: 0x17000AC6 RID: 2758
		// (get) Token: 0x06004707 RID: 18183 RVA: 0x00103806 File Offset: 0x00101A06
		[__DynamicallyInvokable]
		public bool IsPrivate
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Private;
			}
		}

		// Token: 0x17000AC7 RID: 2759
		// (get) Token: 0x06004708 RID: 18184 RVA: 0x00103813 File Offset: 0x00101A13
		[__DynamicallyInvokable]
		public bool IsFamily
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Family;
			}
		}

		// Token: 0x17000AC8 RID: 2760
		// (get) Token: 0x06004709 RID: 18185 RVA: 0x00103820 File Offset: 0x00101A20
		[__DynamicallyInvokable]
		public bool IsAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.Assembly;
			}
		}

		// Token: 0x17000AC9 RID: 2761
		// (get) Token: 0x0600470A RID: 18186 RVA: 0x0010382D File Offset: 0x00101A2D
		[__DynamicallyInvokable]
		public bool IsFamilyAndAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamANDAssem;
			}
		}

		// Token: 0x17000ACA RID: 2762
		// (get) Token: 0x0600470B RID: 18187 RVA: 0x0010383A File Offset: 0x00101A3A
		[__DynamicallyInvokable]
		public bool IsFamilyOrAssembly
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.MemberAccessMask) == MethodAttributes.FamORAssem;
			}
		}

		// Token: 0x17000ACB RID: 2763
		// (get) Token: 0x0600470C RID: 18188 RVA: 0x00103847 File Offset: 0x00101A47
		[__DynamicallyInvokable]
		public bool IsStatic
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Static) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000ACC RID: 2764
		// (get) Token: 0x0600470D RID: 18189 RVA: 0x00103855 File Offset: 0x00101A55
		[__DynamicallyInvokable]
		public bool IsFinal
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Final) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000ACD RID: 2765
		// (get) Token: 0x0600470E RID: 18190 RVA: 0x00103863 File Offset: 0x00101A63
		[__DynamicallyInvokable]
		public bool IsVirtual
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Virtual) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000ACE RID: 2766
		// (get) Token: 0x0600470F RID: 18191 RVA: 0x00103871 File Offset: 0x00101A71
		[__DynamicallyInvokable]
		public bool IsHideBySig
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.HideBySig) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000ACF RID: 2767
		// (get) Token: 0x06004710 RID: 18192 RVA: 0x00103882 File Offset: 0x00101A82
		[__DynamicallyInvokable]
		public bool IsAbstract
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.Abstract) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000AD0 RID: 2768
		// (get) Token: 0x06004711 RID: 18193 RVA: 0x00103893 File Offset: 0x00101A93
		[__DynamicallyInvokable]
		public bool IsSpecialName
		{
			[__DynamicallyInvokable]
			get
			{
				return (this.Attributes & MethodAttributes.SpecialName) > MethodAttributes.PrivateScope;
			}
		}

		// Token: 0x17000AD1 RID: 2769
		// (get) Token: 0x06004712 RID: 18194 RVA: 0x001038A4 File Offset: 0x00101AA4
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public bool IsConstructor
		{
			[__DynamicallyInvokable]
			get
			{
				return this is ConstructorInfo && !this.IsStatic && (this.Attributes & MethodAttributes.RTSpecialName) == MethodAttributes.RTSpecialName;
			}
		}

		// Token: 0x06004713 RID: 18195 RVA: 0x001038CB File Offset: 0x00101ACB
		[SecuritySafeCritical]
		[ReflectionPermission(SecurityAction.Demand, Flags = ReflectionPermissionFlag.MemberAccess)]
		public virtual MethodBody GetMethodBody()
		{
			throw new InvalidOperationException();
		}

		// Token: 0x06004714 RID: 18196 RVA: 0x001038D4 File Offset: 0x00101AD4
		internal static string ConstructParameters(Type[] parameterTypes, CallingConventions callingConvention, bool serialization)
		{
			StringBuilder stringBuilder = new StringBuilder();
			string value = "";
			foreach (Type type in parameterTypes)
			{
				stringBuilder.Append(value);
				string text = type.FormatTypeName(serialization);
				if (type.IsByRef && !serialization)
				{
					stringBuilder.Append(text.TrimEnd(new char[]
					{
						'&'
					}));
					stringBuilder.Append(" ByRef");
				}
				else
				{
					stringBuilder.Append(text);
				}
				value = ", ";
			}
			if ((callingConvention & CallingConventions.VarArgs) == CallingConventions.VarArgs)
			{
				stringBuilder.Append(value);
				stringBuilder.Append("...");
			}
			return stringBuilder.ToString();
		}

		// Token: 0x17000AD2 RID: 2770
		// (get) Token: 0x06004715 RID: 18197 RVA: 0x00103971 File Offset: 0x00101B71
		internal string FullName
		{
			get
			{
				return string.Format("{0}.{1}", this.DeclaringType.FullName, this.FormatNameAndSig());
			}
		}

		// Token: 0x06004716 RID: 18198 RVA: 0x0010398E File Offset: 0x00101B8E
		internal string FormatNameAndSig()
		{
			return this.FormatNameAndSig(false);
		}

		// Token: 0x06004717 RID: 18199 RVA: 0x00103998 File Offset: 0x00101B98
		internal virtual string FormatNameAndSig(bool serialization)
		{
			StringBuilder stringBuilder = new StringBuilder(this.Name);
			stringBuilder.Append("(");
			stringBuilder.Append(MethodBase.ConstructParameters(this.GetParameterTypes(), this.CallingConvention, serialization));
			stringBuilder.Append(")");
			return stringBuilder.ToString();
		}

		// Token: 0x06004718 RID: 18200 RVA: 0x001039E8 File Offset: 0x00101BE8
		internal virtual Type[] GetParameterTypes()
		{
			ParameterInfo[] parametersNoCopy = this.GetParametersNoCopy();
			Type[] array = new Type[parametersNoCopy.Length];
			for (int i = 0; i < parametersNoCopy.Length; i++)
			{
				array[i] = parametersNoCopy[i].ParameterType;
			}
			return array;
		}

		// Token: 0x06004719 RID: 18201 RVA: 0x00103A20 File Offset: 0x00101C20
		[SecuritySafeCritical]
		internal object[] CheckArguments(object[] parameters, Binder binder, BindingFlags invokeAttr, CultureInfo culture, Signature sig)
		{
			object[] array = new object[parameters.Length];
			ParameterInfo[] array2 = null;
			for (int i = 0; i < parameters.Length; i++)
			{
				object obj = parameters[i];
				RuntimeType runtimeType = sig.Arguments[i];
				if (obj == Type.Missing)
				{
					if (array2 == null)
					{
						array2 = this.GetParametersNoCopy();
					}
					if (array2[i].DefaultValue == DBNull.Value)
					{
						throw new ArgumentException(Environment.GetResourceString("Arg_VarMissNull"), "parameters");
					}
					obj = array2[i].DefaultValue;
				}
				array[i] = runtimeType.CheckValue(obj, binder, culture, invokeAttr);
			}
			return array;
		}

		// Token: 0x0600471A RID: 18202 RVA: 0x00103AA4 File Offset: 0x00101CA4
		Type _MethodBase.GetType()
		{
			return base.GetType();
		}

		// Token: 0x17000AD3 RID: 2771
		// (get) Token: 0x0600471B RID: 18203 RVA: 0x00103AAC File Offset: 0x00101CAC
		bool _MethodBase.IsPublic
		{
			get
			{
				return this.IsPublic;
			}
		}

		// Token: 0x17000AD4 RID: 2772
		// (get) Token: 0x0600471C RID: 18204 RVA: 0x00103AB4 File Offset: 0x00101CB4
		bool _MethodBase.IsPrivate
		{
			get
			{
				return this.IsPrivate;
			}
		}

		// Token: 0x17000AD5 RID: 2773
		// (get) Token: 0x0600471D RID: 18205 RVA: 0x00103ABC File Offset: 0x00101CBC
		bool _MethodBase.IsFamily
		{
			get
			{
				return this.IsFamily;
			}
		}

		// Token: 0x17000AD6 RID: 2774
		// (get) Token: 0x0600471E RID: 18206 RVA: 0x00103AC4 File Offset: 0x00101CC4
		bool _MethodBase.IsAssembly
		{
			get
			{
				return this.IsAssembly;
			}
		}

		// Token: 0x17000AD7 RID: 2775
		// (get) Token: 0x0600471F RID: 18207 RVA: 0x00103ACC File Offset: 0x00101CCC
		bool _MethodBase.IsFamilyAndAssembly
		{
			get
			{
				return this.IsFamilyAndAssembly;
			}
		}

		// Token: 0x17000AD8 RID: 2776
		// (get) Token: 0x06004720 RID: 18208 RVA: 0x00103AD4 File Offset: 0x00101CD4
		bool _MethodBase.IsFamilyOrAssembly
		{
			get
			{
				return this.IsFamilyOrAssembly;
			}
		}

		// Token: 0x17000AD9 RID: 2777
		// (get) Token: 0x06004721 RID: 18209 RVA: 0x00103ADC File Offset: 0x00101CDC
		bool _MethodBase.IsStatic
		{
			get
			{
				return this.IsStatic;
			}
		}

		// Token: 0x17000ADA RID: 2778
		// (get) Token: 0x06004722 RID: 18210 RVA: 0x00103AE4 File Offset: 0x00101CE4
		bool _MethodBase.IsFinal
		{
			get
			{
				return this.IsFinal;
			}
		}

		// Token: 0x17000ADB RID: 2779
		// (get) Token: 0x06004723 RID: 18211 RVA: 0x00103AEC File Offset: 0x00101CEC
		bool _MethodBase.IsVirtual
		{
			get
			{
				return this.IsVirtual;
			}
		}

		// Token: 0x17000ADC RID: 2780
		// (get) Token: 0x06004724 RID: 18212 RVA: 0x00103AF4 File Offset: 0x00101CF4
		bool _MethodBase.IsHideBySig
		{
			get
			{
				return this.IsHideBySig;
			}
		}

		// Token: 0x17000ADD RID: 2781
		// (get) Token: 0x06004725 RID: 18213 RVA: 0x00103AFC File Offset: 0x00101CFC
		bool _MethodBase.IsAbstract
		{
			get
			{
				return this.IsAbstract;
			}
		}

		// Token: 0x17000ADE RID: 2782
		// (get) Token: 0x06004726 RID: 18214 RVA: 0x00103B04 File Offset: 0x00101D04
		bool _MethodBase.IsSpecialName
		{
			get
			{
				return this.IsSpecialName;
			}
		}

		// Token: 0x17000ADF RID: 2783
		// (get) Token: 0x06004727 RID: 18215 RVA: 0x00103B0C File Offset: 0x00101D0C
		bool _MethodBase.IsConstructor
		{
			get
			{
				return this.IsConstructor;
			}
		}

		// Token: 0x06004728 RID: 18216 RVA: 0x00103B14 File Offset: 0x00101D14
		void _MethodBase.GetTypeInfoCount(out uint pcTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x06004729 RID: 18217 RVA: 0x00103B1B File Offset: 0x00101D1B
		void _MethodBase.GetTypeInfo(uint iTInfo, uint lcid, IntPtr ppTInfo)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600472A RID: 18218 RVA: 0x00103B22 File Offset: 0x00101D22
		void _MethodBase.GetIDsOfNames([In] ref Guid riid, IntPtr rgszNames, uint cNames, uint lcid, IntPtr rgDispId)
		{
			throw new NotImplementedException();
		}

		// Token: 0x0600472B RID: 18219 RVA: 0x00103B29 File Offset: 0x00101D29
		void _MethodBase.Invoke(uint dispIdMember, [In] ref Guid riid, uint lcid, short wFlags, IntPtr pDispParams, IntPtr pVarResult, IntPtr pExcepInfo, IntPtr puArgErr)
		{
			throw new NotImplementedException();
		}
	}
}
