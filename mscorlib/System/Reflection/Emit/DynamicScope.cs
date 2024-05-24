using System;
using System.Collections.Generic;
using System.Globalization;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x02000633 RID: 1587
	internal class DynamicScope
	{
		// Token: 0x06004A1B RID: 18971 RVA: 0x0010C3B7 File Offset: 0x0010A5B7
		internal DynamicScope()
		{
			this.m_tokens = new List<object>();
			this.m_tokens.Add(null);
		}

		// Token: 0x17000B90 RID: 2960
		internal object this[int token]
		{
			get
			{
				token &= 16777215;
				if (token < 0 || token > this.m_tokens.Count)
				{
					return null;
				}
				return this.m_tokens[token];
			}
		}

		// Token: 0x06004A1D RID: 18973 RVA: 0x0010C401 File Offset: 0x0010A601
		internal int GetTokenFor(VarArgMethod varArgMethod)
		{
			this.m_tokens.Add(varArgMethod);
			return this.m_tokens.Count - 1 | 167772160;
		}

		// Token: 0x06004A1E RID: 18974 RVA: 0x0010C422 File Offset: 0x0010A622
		internal string GetString(int token)
		{
			return this[token] as string;
		}

		// Token: 0x06004A1F RID: 18975 RVA: 0x0010C430 File Offset: 0x0010A630
		internal byte[] ResolveSignature(int token, int fromMethod)
		{
			if (fromMethod == 0)
			{
				return (byte[])this[token];
			}
			VarArgMethod varArgMethod = this[token] as VarArgMethod;
			if (varArgMethod == null)
			{
				return null;
			}
			return varArgMethod.m_signature.GetSignature(true);
		}

		// Token: 0x06004A20 RID: 18976 RVA: 0x0010C46C File Offset: 0x0010A66C
		[SecuritySafeCritical]
		public int GetTokenFor(RuntimeMethodHandle method)
		{
			IRuntimeMethodInfo methodInfo = method.GetMethodInfo();
			RuntimeMethodHandleInternal value = methodInfo.Value;
			if (methodInfo != null && !RuntimeMethodHandle.IsDynamicMethod(value))
			{
				RuntimeType declaringType = RuntimeMethodHandle.GetDeclaringType(value);
				if (declaringType != null && RuntimeTypeHandle.HasInstantiation(declaringType))
				{
					MethodBase methodBase = RuntimeType.GetMethodBase(methodInfo);
					Type genericTypeDefinition = methodBase.DeclaringType.GetGenericTypeDefinition();
					throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, Environment.GetResourceString("Argument_MethodDeclaringTypeGenericLcg"), methodBase, genericTypeDefinition));
				}
			}
			this.m_tokens.Add(method);
			return this.m_tokens.Count - 1 | 100663296;
		}

		// Token: 0x06004A21 RID: 18977 RVA: 0x0010C500 File Offset: 0x0010A700
		public int GetTokenFor(RuntimeMethodHandle method, RuntimeTypeHandle typeContext)
		{
			this.m_tokens.Add(new GenericMethodInfo(method, typeContext));
			return this.m_tokens.Count - 1 | 100663296;
		}

		// Token: 0x06004A22 RID: 18978 RVA: 0x0010C527 File Offset: 0x0010A727
		public int GetTokenFor(DynamicMethod method)
		{
			this.m_tokens.Add(method);
			return this.m_tokens.Count - 1 | 100663296;
		}

		// Token: 0x06004A23 RID: 18979 RVA: 0x0010C548 File Offset: 0x0010A748
		public int GetTokenFor(RuntimeFieldHandle field)
		{
			this.m_tokens.Add(field);
			return this.m_tokens.Count - 1 | 67108864;
		}

		// Token: 0x06004A24 RID: 18980 RVA: 0x0010C56E File Offset: 0x0010A76E
		public int GetTokenFor(RuntimeFieldHandle field, RuntimeTypeHandle typeContext)
		{
			this.m_tokens.Add(new GenericFieldInfo(field, typeContext));
			return this.m_tokens.Count - 1 | 67108864;
		}

		// Token: 0x06004A25 RID: 18981 RVA: 0x0010C595 File Offset: 0x0010A795
		public int GetTokenFor(RuntimeTypeHandle type)
		{
			this.m_tokens.Add(type);
			return this.m_tokens.Count - 1 | 33554432;
		}

		// Token: 0x06004A26 RID: 18982 RVA: 0x0010C5BB File Offset: 0x0010A7BB
		public int GetTokenFor(string literal)
		{
			this.m_tokens.Add(literal);
			return this.m_tokens.Count - 1 | 1879048192;
		}

		// Token: 0x06004A27 RID: 18983 RVA: 0x0010C5DC File Offset: 0x0010A7DC
		public int GetTokenFor(byte[] signature)
		{
			this.m_tokens.Add(signature);
			return this.m_tokens.Count - 1 | 285212672;
		}

		// Token: 0x04001E8E RID: 7822
		internal List<object> m_tokens;
	}
}
