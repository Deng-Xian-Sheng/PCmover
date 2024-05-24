using System;
using System.Globalization;

namespace System.Reflection.Emit
{
	// Token: 0x02000668 RID: 1640
	internal sealed class ConstructorOnTypeBuilderInstantiation : ConstructorInfo
	{
		// Token: 0x06004ED5 RID: 20181 RVA: 0x0011BD58 File Offset: 0x00119F58
		internal static ConstructorInfo GetConstructor(ConstructorInfo Constructor, TypeBuilderInstantiation type)
		{
			return new ConstructorOnTypeBuilderInstantiation(Constructor, type);
		}

		// Token: 0x06004ED6 RID: 20182 RVA: 0x0011BD61 File Offset: 0x00119F61
		internal ConstructorOnTypeBuilderInstantiation(ConstructorInfo constructor, TypeBuilderInstantiation type)
		{
			this.m_ctor = constructor;
			this.m_type = type;
		}

		// Token: 0x06004ED7 RID: 20183 RVA: 0x0011BD77 File Offset: 0x00119F77
		internal override Type[] GetParameterTypes()
		{
			return this.m_ctor.GetParameterTypes();
		}

		// Token: 0x06004ED8 RID: 20184 RVA: 0x0011BD84 File Offset: 0x00119F84
		internal override Type GetReturnType()
		{
			return this.DeclaringType;
		}

		// Token: 0x17000C7C RID: 3196
		// (get) Token: 0x06004ED9 RID: 20185 RVA: 0x0011BD8C File Offset: 0x00119F8C
		public override MemberTypes MemberType
		{
			get
			{
				return this.m_ctor.MemberType;
			}
		}

		// Token: 0x17000C7D RID: 3197
		// (get) Token: 0x06004EDA RID: 20186 RVA: 0x0011BD99 File Offset: 0x00119F99
		public override string Name
		{
			get
			{
				return this.m_ctor.Name;
			}
		}

		// Token: 0x17000C7E RID: 3198
		// (get) Token: 0x06004EDB RID: 20187 RVA: 0x0011BDA6 File Offset: 0x00119FA6
		public override Type DeclaringType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000C7F RID: 3199
		// (get) Token: 0x06004EDC RID: 20188 RVA: 0x0011BDAE File Offset: 0x00119FAE
		public override Type ReflectedType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x06004EDD RID: 20189 RVA: 0x0011BDB6 File Offset: 0x00119FB6
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_ctor.GetCustomAttributes(inherit);
		}

		// Token: 0x06004EDE RID: 20190 RVA: 0x0011BDC4 File Offset: 0x00119FC4
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_ctor.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004EDF RID: 20191 RVA: 0x0011BDD3 File Offset: 0x00119FD3
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_ctor.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000C80 RID: 3200
		// (get) Token: 0x06004EE0 RID: 20192 RVA: 0x0011BDE4 File Offset: 0x00119FE4
		internal int MetadataTokenInternal
		{
			get
			{
				ConstructorBuilder constructorBuilder = this.m_ctor as ConstructorBuilder;
				if (constructorBuilder != null)
				{
					return constructorBuilder.MetadataTokenInternal;
				}
				return this.m_ctor.MetadataToken;
			}
		}

		// Token: 0x17000C81 RID: 3201
		// (get) Token: 0x06004EE1 RID: 20193 RVA: 0x0011BE18 File Offset: 0x0011A018
		public override Module Module
		{
			get
			{
				return this.m_ctor.Module;
			}
		}

		// Token: 0x06004EE2 RID: 20194 RVA: 0x0011BE25 File Offset: 0x0011A025
		public new Type GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004EE3 RID: 20195 RVA: 0x0011BE2D File Offset: 0x0011A02D
		public override ParameterInfo[] GetParameters()
		{
			return this.m_ctor.GetParameters();
		}

		// Token: 0x06004EE4 RID: 20196 RVA: 0x0011BE3A File Offset: 0x0011A03A
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_ctor.GetMethodImplementationFlags();
		}

		// Token: 0x17000C82 RID: 3202
		// (get) Token: 0x06004EE5 RID: 20197 RVA: 0x0011BE47 File Offset: 0x0011A047
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				return this.m_ctor.MethodHandle;
			}
		}

		// Token: 0x17000C83 RID: 3203
		// (get) Token: 0x06004EE6 RID: 20198 RVA: 0x0011BE54 File Offset: 0x0011A054
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_ctor.Attributes;
			}
		}

		// Token: 0x06004EE7 RID: 20199 RVA: 0x0011BE61 File Offset: 0x0011A061
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000C84 RID: 3204
		// (get) Token: 0x06004EE8 RID: 20200 RVA: 0x0011BE68 File Offset: 0x0011A068
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_ctor.CallingConvention;
			}
		}

		// Token: 0x06004EE9 RID: 20201 RVA: 0x0011BE75 File Offset: 0x0011A075
		public override Type[] GetGenericArguments()
		{
			return this.m_ctor.GetGenericArguments();
		}

		// Token: 0x17000C85 RID: 3205
		// (get) Token: 0x06004EEA RID: 20202 RVA: 0x0011BE82 File Offset: 0x0011A082
		public override bool IsGenericMethodDefinition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C86 RID: 3206
		// (get) Token: 0x06004EEB RID: 20203 RVA: 0x0011BE85 File Offset: 0x0011A085
		public override bool ContainsGenericParameters
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000C87 RID: 3207
		// (get) Token: 0x06004EEC RID: 20204 RVA: 0x0011BE88 File Offset: 0x0011A088
		public override bool IsGenericMethod
		{
			get
			{
				return false;
			}
		}

		// Token: 0x06004EED RID: 20205 RVA: 0x0011BE8B File Offset: 0x0011A08B
		public override object Invoke(BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new InvalidOperationException();
		}

		// Token: 0x040021D0 RID: 8656
		internal ConstructorInfo m_ctor;

		// Token: 0x040021D1 RID: 8657
		private TypeBuilderInstantiation m_type;
	}
}
