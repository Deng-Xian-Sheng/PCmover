using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection.Emit
{
	// Token: 0x02000632 RID: 1586
	[ComVisible(true)]
	public class DynamicILInfo
	{
		// Token: 0x06004A05 RID: 18949 RVA: 0x0010C0E4 File Offset: 0x0010A2E4
		internal DynamicILInfo(DynamicScope scope, DynamicMethod method, byte[] methodSignature)
		{
			this.m_method = method;
			this.m_scope = scope;
			this.m_methodSignature = this.m_scope.GetTokenFor(methodSignature);
			this.m_exceptions = EmptyArray<byte>.Value;
			this.m_code = EmptyArray<byte>.Value;
			this.m_localSignature = EmptyArray<byte>.Value;
		}

		// Token: 0x06004A06 RID: 18950 RVA: 0x0010C138 File Offset: 0x0010A338
		[SecurityCritical]
		internal void GetCallableMethod(RuntimeModule module, DynamicMethod dm)
		{
			dm.m_methodHandle = ModuleHandle.GetDynamicMethod(dm, module, this.m_method.Name, (byte[])this.m_scope[this.m_methodSignature], new DynamicResolver(this));
		}

		// Token: 0x17000B8A RID: 2954
		// (get) Token: 0x06004A07 RID: 18951 RVA: 0x0010C16E File Offset: 0x0010A36E
		internal byte[] LocalSignature
		{
			get
			{
				if (this.m_localSignature == null)
				{
					this.m_localSignature = SignatureHelper.GetLocalVarSigHelper().InternalGetSignatureArray();
				}
				return this.m_localSignature;
			}
		}

		// Token: 0x17000B8B RID: 2955
		// (get) Token: 0x06004A08 RID: 18952 RVA: 0x0010C18E File Offset: 0x0010A38E
		internal byte[] Exceptions
		{
			get
			{
				return this.m_exceptions;
			}
		}

		// Token: 0x17000B8C RID: 2956
		// (get) Token: 0x06004A09 RID: 18953 RVA: 0x0010C196 File Offset: 0x0010A396
		internal byte[] Code
		{
			get
			{
				return this.m_code;
			}
		}

		// Token: 0x17000B8D RID: 2957
		// (get) Token: 0x06004A0A RID: 18954 RVA: 0x0010C19E File Offset: 0x0010A39E
		internal int MaxStackSize
		{
			get
			{
				return this.m_maxStackSize;
			}
		}

		// Token: 0x17000B8E RID: 2958
		// (get) Token: 0x06004A0B RID: 18955 RVA: 0x0010C1A6 File Offset: 0x0010A3A6
		public DynamicMethod DynamicMethod
		{
			get
			{
				return this.m_method;
			}
		}

		// Token: 0x17000B8F RID: 2959
		// (get) Token: 0x06004A0C RID: 18956 RVA: 0x0010C1AE File Offset: 0x0010A3AE
		internal DynamicScope DynamicScope
		{
			get
			{
				return this.m_scope;
			}
		}

		// Token: 0x06004A0D RID: 18957 RVA: 0x0010C1B6 File Offset: 0x0010A3B6
		public void SetCode(byte[] code, int maxStackSize)
		{
			this.m_code = ((code != null) ? ((byte[])code.Clone()) : EmptyArray<byte>.Value);
			this.m_maxStackSize = maxStackSize;
		}

		// Token: 0x06004A0E RID: 18958 RVA: 0x0010C1DC File Offset: 0x0010A3DC
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe void SetCode(byte* code, int codeSize, int maxStackSize)
		{
			if (codeSize < 0)
			{
				throw new ArgumentOutOfRangeException("codeSize", Environment.GetResourceString("ArgumentOutOfRange_GenericPositive"));
			}
			if (codeSize > 0 && code == null)
			{
				throw new ArgumentNullException("code");
			}
			this.m_code = new byte[codeSize];
			for (int i = 0; i < codeSize; i++)
			{
				this.m_code[i] = *code;
				code++;
			}
			this.m_maxStackSize = maxStackSize;
		}

		// Token: 0x06004A0F RID: 18959 RVA: 0x0010C244 File Offset: 0x0010A444
		public void SetExceptions(byte[] exceptions)
		{
			this.m_exceptions = ((exceptions != null) ? ((byte[])exceptions.Clone()) : EmptyArray<byte>.Value);
		}

		// Token: 0x06004A10 RID: 18960 RVA: 0x0010C264 File Offset: 0x0010A464
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe void SetExceptions(byte* exceptions, int exceptionsSize)
		{
			if (exceptionsSize < 0)
			{
				throw new ArgumentOutOfRangeException("exceptionsSize", Environment.GetResourceString("ArgumentOutOfRange_GenericPositive"));
			}
			if (exceptionsSize > 0 && exceptions == null)
			{
				throw new ArgumentNullException("exceptions");
			}
			this.m_exceptions = new byte[exceptionsSize];
			for (int i = 0; i < exceptionsSize; i++)
			{
				this.m_exceptions[i] = *exceptions;
				exceptions++;
			}
		}

		// Token: 0x06004A11 RID: 18961 RVA: 0x0010C2C5 File Offset: 0x0010A4C5
		public void SetLocalSignature(byte[] localSignature)
		{
			this.m_localSignature = ((localSignature != null) ? ((byte[])localSignature.Clone()) : EmptyArray<byte>.Value);
		}

		// Token: 0x06004A12 RID: 18962 RVA: 0x0010C2E4 File Offset: 0x0010A4E4
		[SecurityCritical]
		[CLSCompliant(false)]
		public unsafe void SetLocalSignature(byte* localSignature, int signatureSize)
		{
			if (signatureSize < 0)
			{
				throw new ArgumentOutOfRangeException("signatureSize", Environment.GetResourceString("ArgumentOutOfRange_GenericPositive"));
			}
			if (signatureSize > 0 && localSignature == null)
			{
				throw new ArgumentNullException("localSignature");
			}
			this.m_localSignature = new byte[signatureSize];
			for (int i = 0; i < signatureSize; i++)
			{
				this.m_localSignature[i] = *localSignature;
				localSignature++;
			}
		}

		// Token: 0x06004A13 RID: 18963 RVA: 0x0010C345 File Offset: 0x0010A545
		[SecuritySafeCritical]
		public int GetTokenFor(RuntimeMethodHandle method)
		{
			return this.DynamicScope.GetTokenFor(method);
		}

		// Token: 0x06004A14 RID: 18964 RVA: 0x0010C353 File Offset: 0x0010A553
		public int GetTokenFor(DynamicMethod method)
		{
			return this.DynamicScope.GetTokenFor(method);
		}

		// Token: 0x06004A15 RID: 18965 RVA: 0x0010C361 File Offset: 0x0010A561
		public int GetTokenFor(RuntimeMethodHandle method, RuntimeTypeHandle contextType)
		{
			return this.DynamicScope.GetTokenFor(method, contextType);
		}

		// Token: 0x06004A16 RID: 18966 RVA: 0x0010C370 File Offset: 0x0010A570
		public int GetTokenFor(RuntimeFieldHandle field)
		{
			return this.DynamicScope.GetTokenFor(field);
		}

		// Token: 0x06004A17 RID: 18967 RVA: 0x0010C37E File Offset: 0x0010A57E
		public int GetTokenFor(RuntimeFieldHandle field, RuntimeTypeHandle contextType)
		{
			return this.DynamicScope.GetTokenFor(field, contextType);
		}

		// Token: 0x06004A18 RID: 18968 RVA: 0x0010C38D File Offset: 0x0010A58D
		public int GetTokenFor(RuntimeTypeHandle type)
		{
			return this.DynamicScope.GetTokenFor(type);
		}

		// Token: 0x06004A19 RID: 18969 RVA: 0x0010C39B File Offset: 0x0010A59B
		public int GetTokenFor(string literal)
		{
			return this.DynamicScope.GetTokenFor(literal);
		}

		// Token: 0x06004A1A RID: 18970 RVA: 0x0010C3A9 File Offset: 0x0010A5A9
		public int GetTokenFor(byte[] signature)
		{
			return this.DynamicScope.GetTokenFor(signature);
		}

		// Token: 0x04001E87 RID: 7815
		private DynamicMethod m_method;

		// Token: 0x04001E88 RID: 7816
		private DynamicScope m_scope;

		// Token: 0x04001E89 RID: 7817
		private byte[] m_exceptions;

		// Token: 0x04001E8A RID: 7818
		private byte[] m_code;

		// Token: 0x04001E8B RID: 7819
		private byte[] m_localSignature;

		// Token: 0x04001E8C RID: 7820
		private int m_maxStackSize;

		// Token: 0x04001E8D RID: 7821
		private int m_methodSignature;
	}
}
