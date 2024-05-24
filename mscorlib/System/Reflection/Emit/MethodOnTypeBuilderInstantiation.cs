using System;
using System.Globalization;

namespace System.Reflection.Emit
{
	// Token: 0x02000667 RID: 1639
	internal sealed class MethodOnTypeBuilderInstantiation : MethodInfo
	{
		// Token: 0x06004EB8 RID: 20152 RVA: 0x0011BBC6 File Offset: 0x00119DC6
		internal static MethodInfo GetMethod(MethodInfo method, TypeBuilderInstantiation type)
		{
			return new MethodOnTypeBuilderInstantiation(method, type);
		}

		// Token: 0x06004EB9 RID: 20153 RVA: 0x0011BBCF File Offset: 0x00119DCF
		internal MethodOnTypeBuilderInstantiation(MethodInfo method, TypeBuilderInstantiation type)
		{
			this.m_method = method;
			this.m_type = type;
		}

		// Token: 0x06004EBA RID: 20154 RVA: 0x0011BBE5 File Offset: 0x00119DE5
		internal override Type[] GetParameterTypes()
		{
			return this.m_method.GetParameterTypes();
		}

		// Token: 0x17000C6D RID: 3181
		// (get) Token: 0x06004EBB RID: 20155 RVA: 0x0011BBF2 File Offset: 0x00119DF2
		public override MemberTypes MemberType
		{
			get
			{
				return this.m_method.MemberType;
			}
		}

		// Token: 0x17000C6E RID: 3182
		// (get) Token: 0x06004EBC RID: 20156 RVA: 0x0011BBFF File Offset: 0x00119DFF
		public override string Name
		{
			get
			{
				return this.m_method.Name;
			}
		}

		// Token: 0x17000C6F RID: 3183
		// (get) Token: 0x06004EBD RID: 20157 RVA: 0x0011BC0C File Offset: 0x00119E0C
		public override Type DeclaringType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000C70 RID: 3184
		// (get) Token: 0x06004EBE RID: 20158 RVA: 0x0011BC14 File Offset: 0x00119E14
		public override Type ReflectedType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x06004EBF RID: 20159 RVA: 0x0011BC1C File Offset: 0x00119E1C
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_method.GetCustomAttributes(inherit);
		}

		// Token: 0x06004EC0 RID: 20160 RVA: 0x0011BC2A File Offset: 0x00119E2A
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_method.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004EC1 RID: 20161 RVA: 0x0011BC39 File Offset: 0x00119E39
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_method.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000C71 RID: 3185
		// (get) Token: 0x06004EC2 RID: 20162 RVA: 0x0011BC48 File Offset: 0x00119E48
		internal int MetadataTokenInternal
		{
			get
			{
				MethodBuilder methodBuilder = this.m_method as MethodBuilder;
				if (methodBuilder != null)
				{
					return methodBuilder.MetadataTokenInternal;
				}
				return this.m_method.MetadataToken;
			}
		}

		// Token: 0x17000C72 RID: 3186
		// (get) Token: 0x06004EC3 RID: 20163 RVA: 0x0011BC7C File Offset: 0x00119E7C
		public override Module Module
		{
			get
			{
				return this.m_method.Module;
			}
		}

		// Token: 0x06004EC4 RID: 20164 RVA: 0x0011BC89 File Offset: 0x00119E89
		public new Type GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004EC5 RID: 20165 RVA: 0x0011BC91 File Offset: 0x00119E91
		public override ParameterInfo[] GetParameters()
		{
			return this.m_method.GetParameters();
		}

		// Token: 0x06004EC6 RID: 20166 RVA: 0x0011BC9E File Offset: 0x00119E9E
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_method.GetMethodImplementationFlags();
		}

		// Token: 0x17000C73 RID: 3187
		// (get) Token: 0x06004EC7 RID: 20167 RVA: 0x0011BCAB File Offset: 0x00119EAB
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				return this.m_method.MethodHandle;
			}
		}

		// Token: 0x17000C74 RID: 3188
		// (get) Token: 0x06004EC8 RID: 20168 RVA: 0x0011BCB8 File Offset: 0x00119EB8
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_method.Attributes;
			}
		}

		// Token: 0x06004EC9 RID: 20169 RVA: 0x0011BCC5 File Offset: 0x00119EC5
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000C75 RID: 3189
		// (get) Token: 0x06004ECA RID: 20170 RVA: 0x0011BCCC File Offset: 0x00119ECC
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_method.CallingConvention;
			}
		}

		// Token: 0x06004ECB RID: 20171 RVA: 0x0011BCD9 File Offset: 0x00119ED9
		public override Type[] GetGenericArguments()
		{
			return this.m_method.GetGenericArguments();
		}

		// Token: 0x06004ECC RID: 20172 RVA: 0x0011BCE6 File Offset: 0x00119EE6
		public override MethodInfo GetGenericMethodDefinition()
		{
			return this.m_method;
		}

		// Token: 0x17000C76 RID: 3190
		// (get) Token: 0x06004ECD RID: 20173 RVA: 0x0011BCEE File Offset: 0x00119EEE
		public override bool IsGenericMethodDefinition
		{
			get
			{
				return this.m_method.IsGenericMethodDefinition;
			}
		}

		// Token: 0x17000C77 RID: 3191
		// (get) Token: 0x06004ECE RID: 20174 RVA: 0x0011BCFB File Offset: 0x00119EFB
		public override bool ContainsGenericParameters
		{
			get
			{
				return this.m_method.ContainsGenericParameters;
			}
		}

		// Token: 0x06004ECF RID: 20175 RVA: 0x0011BD08 File Offset: 0x00119F08
		public override MethodInfo MakeGenericMethod(params Type[] typeArgs)
		{
			if (!this.IsGenericMethodDefinition)
			{
				throw new InvalidOperationException(Environment.GetResourceString("Arg_NotGenericMethodDefinition"));
			}
			return MethodBuilderInstantiation.MakeGenericMethod(this, typeArgs);
		}

		// Token: 0x17000C78 RID: 3192
		// (get) Token: 0x06004ED0 RID: 20176 RVA: 0x0011BD29 File Offset: 0x00119F29
		public override bool IsGenericMethod
		{
			get
			{
				return this.m_method.IsGenericMethod;
			}
		}

		// Token: 0x17000C79 RID: 3193
		// (get) Token: 0x06004ED1 RID: 20177 RVA: 0x0011BD36 File Offset: 0x00119F36
		public override Type ReturnType
		{
			get
			{
				return this.m_method.ReturnType;
			}
		}

		// Token: 0x17000C7A RID: 3194
		// (get) Token: 0x06004ED2 RID: 20178 RVA: 0x0011BD43 File Offset: 0x00119F43
		public override ParameterInfo ReturnParameter
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000C7B RID: 3195
		// (get) Token: 0x06004ED3 RID: 20179 RVA: 0x0011BD4A File Offset: 0x00119F4A
		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06004ED4 RID: 20180 RVA: 0x0011BD51 File Offset: 0x00119F51
		public override MethodInfo GetBaseDefinition()
		{
			throw new NotSupportedException();
		}

		// Token: 0x040021CE RID: 8654
		internal MethodInfo m_method;

		// Token: 0x040021CF RID: 8655
		private TypeBuilderInstantiation m_type;
	}
}
