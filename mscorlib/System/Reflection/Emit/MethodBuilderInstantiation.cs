using System;
using System.Globalization;

namespace System.Reflection.Emit
{
	// Token: 0x02000648 RID: 1608
	internal sealed class MethodBuilderInstantiation : MethodInfo
	{
		// Token: 0x06004B7C RID: 19324 RVA: 0x00111918 File Offset: 0x0010FB18
		internal static MethodInfo MakeGenericMethod(MethodInfo method, Type[] inst)
		{
			if (!method.IsGenericMethodDefinition)
			{
				throw new InvalidOperationException();
			}
			return new MethodBuilderInstantiation(method, inst);
		}

		// Token: 0x06004B7D RID: 19325 RVA: 0x0011192F File Offset: 0x0010FB2F
		internal MethodBuilderInstantiation(MethodInfo method, Type[] inst)
		{
			this.m_method = method;
			this.m_inst = inst;
		}

		// Token: 0x06004B7E RID: 19326 RVA: 0x00111945 File Offset: 0x0010FB45
		internal override Type[] GetParameterTypes()
		{
			return this.m_method.GetParameterTypes();
		}

		// Token: 0x17000BCB RID: 3019
		// (get) Token: 0x06004B7F RID: 19327 RVA: 0x00111952 File Offset: 0x0010FB52
		public override MemberTypes MemberType
		{
			get
			{
				return this.m_method.MemberType;
			}
		}

		// Token: 0x17000BCC RID: 3020
		// (get) Token: 0x06004B80 RID: 19328 RVA: 0x0011195F File Offset: 0x0010FB5F
		public override string Name
		{
			get
			{
				return this.m_method.Name;
			}
		}

		// Token: 0x17000BCD RID: 3021
		// (get) Token: 0x06004B81 RID: 19329 RVA: 0x0011196C File Offset: 0x0010FB6C
		public override Type DeclaringType
		{
			get
			{
				return this.m_method.DeclaringType;
			}
		}

		// Token: 0x17000BCE RID: 3022
		// (get) Token: 0x06004B82 RID: 19330 RVA: 0x00111979 File Offset: 0x0010FB79
		public override Type ReflectedType
		{
			get
			{
				return this.m_method.ReflectedType;
			}
		}

		// Token: 0x06004B83 RID: 19331 RVA: 0x00111986 File Offset: 0x0010FB86
		public override object[] GetCustomAttributes(bool inherit)
		{
			return this.m_method.GetCustomAttributes(inherit);
		}

		// Token: 0x06004B84 RID: 19332 RVA: 0x00111994 File Offset: 0x0010FB94
		public override object[] GetCustomAttributes(Type attributeType, bool inherit)
		{
			return this.m_method.GetCustomAttributes(attributeType, inherit);
		}

		// Token: 0x06004B85 RID: 19333 RVA: 0x001119A3 File Offset: 0x0010FBA3
		public override bool IsDefined(Type attributeType, bool inherit)
		{
			return this.m_method.IsDefined(attributeType, inherit);
		}

		// Token: 0x17000BCF RID: 3023
		// (get) Token: 0x06004B86 RID: 19334 RVA: 0x001119B2 File Offset: 0x0010FBB2
		public override Module Module
		{
			get
			{
				return this.m_method.Module;
			}
		}

		// Token: 0x06004B87 RID: 19335 RVA: 0x001119BF File Offset: 0x0010FBBF
		public new Type GetType()
		{
			return base.GetType();
		}

		// Token: 0x06004B88 RID: 19336 RVA: 0x001119C7 File Offset: 0x0010FBC7
		public override ParameterInfo[] GetParameters()
		{
			throw new NotSupportedException();
		}

		// Token: 0x06004B89 RID: 19337 RVA: 0x001119CE File Offset: 0x0010FBCE
		public override MethodImplAttributes GetMethodImplementationFlags()
		{
			return this.m_method.GetMethodImplementationFlags();
		}

		// Token: 0x17000BD0 RID: 3024
		// (get) Token: 0x06004B8A RID: 19338 RVA: 0x001119DB File Offset: 0x0010FBDB
		public override RuntimeMethodHandle MethodHandle
		{
			get
			{
				throw new NotSupportedException(Environment.GetResourceString("NotSupported_DynamicModule"));
			}
		}

		// Token: 0x17000BD1 RID: 3025
		// (get) Token: 0x06004B8B RID: 19339 RVA: 0x001119EC File Offset: 0x0010FBEC
		public override MethodAttributes Attributes
		{
			get
			{
				return this.m_method.Attributes;
			}
		}

		// Token: 0x06004B8C RID: 19340 RVA: 0x001119F9 File Offset: 0x0010FBF9
		public override object Invoke(object obj, BindingFlags invokeAttr, Binder binder, object[] parameters, CultureInfo culture)
		{
			throw new NotSupportedException();
		}

		// Token: 0x17000BD2 RID: 3026
		// (get) Token: 0x06004B8D RID: 19341 RVA: 0x00111A00 File Offset: 0x0010FC00
		public override CallingConventions CallingConvention
		{
			get
			{
				return this.m_method.CallingConvention;
			}
		}

		// Token: 0x06004B8E RID: 19342 RVA: 0x00111A0D File Offset: 0x0010FC0D
		public override Type[] GetGenericArguments()
		{
			return this.m_inst;
		}

		// Token: 0x06004B8F RID: 19343 RVA: 0x00111A15 File Offset: 0x0010FC15
		public override MethodInfo GetGenericMethodDefinition()
		{
			return this.m_method;
		}

		// Token: 0x17000BD3 RID: 3027
		// (get) Token: 0x06004B90 RID: 19344 RVA: 0x00111A1D File Offset: 0x0010FC1D
		public override bool IsGenericMethodDefinition
		{
			get
			{
				return false;
			}
		}

		// Token: 0x17000BD4 RID: 3028
		// (get) Token: 0x06004B91 RID: 19345 RVA: 0x00111A20 File Offset: 0x0010FC20
		public override bool ContainsGenericParameters
		{
			get
			{
				for (int i = 0; i < this.m_inst.Length; i++)
				{
					if (this.m_inst[i].ContainsGenericParameters)
					{
						return true;
					}
				}
				return this.DeclaringType != null && this.DeclaringType.ContainsGenericParameters;
			}
		}

		// Token: 0x06004B92 RID: 19346 RVA: 0x00111A6F File Offset: 0x0010FC6F
		public override MethodInfo MakeGenericMethod(params Type[] arguments)
		{
			throw new InvalidOperationException(Environment.GetResourceString("Arg_NotGenericMethodDefinition"));
		}

		// Token: 0x17000BD5 RID: 3029
		// (get) Token: 0x06004B93 RID: 19347 RVA: 0x00111A80 File Offset: 0x0010FC80
		public override bool IsGenericMethod
		{
			get
			{
				return true;
			}
		}

		// Token: 0x17000BD6 RID: 3030
		// (get) Token: 0x06004B94 RID: 19348 RVA: 0x00111A83 File Offset: 0x0010FC83
		public override Type ReturnType
		{
			get
			{
				return this.m_method.ReturnType;
			}
		}

		// Token: 0x17000BD7 RID: 3031
		// (get) Token: 0x06004B95 RID: 19349 RVA: 0x00111A90 File Offset: 0x0010FC90
		public override ParameterInfo ReturnParameter
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x17000BD8 RID: 3032
		// (get) Token: 0x06004B96 RID: 19350 RVA: 0x00111A97 File Offset: 0x0010FC97
		public override ICustomAttributeProvider ReturnTypeCustomAttributes
		{
			get
			{
				throw new NotSupportedException();
			}
		}

		// Token: 0x06004B97 RID: 19351 RVA: 0x00111A9E File Offset: 0x0010FC9E
		public override MethodInfo GetBaseDefinition()
		{
			throw new NotSupportedException();
		}

		// Token: 0x04001F32 RID: 7986
		internal MethodInfo m_method;

		// Token: 0x04001F33 RID: 7987
		private Type[] m_inst;
	}
}
