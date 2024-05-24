using System;
using System.Reflection;
using System.Security;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200092A RID: 2346
	[AttributeUsage(AttributeTargets.Field | AttributeTargets.Parameter | AttributeTargets.ReturnValue, Inherited = false)]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public sealed class MarshalAsAttribute : Attribute
	{
		// Token: 0x06006018 RID: 24600 RVA: 0x0014B7FF File Offset: 0x001499FF
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeParameterInfo parameter)
		{
			return MarshalAsAttribute.GetCustomAttribute(parameter.MetadataToken, parameter.GetRuntimeModule());
		}

		// Token: 0x06006019 RID: 24601 RVA: 0x0014B812 File Offset: 0x00149A12
		[SecurityCritical]
		internal static bool IsDefined(RuntimeParameterInfo parameter)
		{
			return MarshalAsAttribute.GetCustomAttribute(parameter) != null;
		}

		// Token: 0x0600601A RID: 24602 RVA: 0x0014B81D File Offset: 0x00149A1D
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(RuntimeFieldInfo field)
		{
			return MarshalAsAttribute.GetCustomAttribute(field.MetadataToken, field.GetRuntimeModule());
		}

		// Token: 0x0600601B RID: 24603 RVA: 0x0014B830 File Offset: 0x00149A30
		[SecurityCritical]
		internal static bool IsDefined(RuntimeFieldInfo field)
		{
			return MarshalAsAttribute.GetCustomAttribute(field) != null;
		}

		// Token: 0x0600601C RID: 24604 RVA: 0x0014B83C File Offset: 0x00149A3C
		[SecurityCritical]
		internal static Attribute GetCustomAttribute(int token, RuntimeModule scope)
		{
			int num = 0;
			int sizeConst = 0;
			string text = null;
			string marshalCookie = null;
			string text2 = null;
			int iidParamIndex = 0;
			ConstArray fieldMarshal = ModuleHandle.GetMetadataImport(scope.GetNativeHandle()).GetFieldMarshal(token);
			if (fieldMarshal.Length == 0)
			{
				return null;
			}
			UnmanagedType val;
			VarEnum safeArraySubType;
			UnmanagedType arraySubType;
			MetadataImport.GetMarshalAs(fieldMarshal, out val, out safeArraySubType, out text2, out arraySubType, out num, out sizeConst, out text, out marshalCookie, out iidParamIndex);
			RuntimeType safeArrayUserDefinedSubType = (text2 == null || text2.Length == 0) ? null : RuntimeTypeHandle.GetTypeByNameUsingCARules(text2, scope);
			RuntimeType marshalTypeRef = null;
			try
			{
				marshalTypeRef = ((text == null) ? null : RuntimeTypeHandle.GetTypeByNameUsingCARules(text, scope));
			}
			catch (TypeLoadException)
			{
			}
			return new MarshalAsAttribute(val, safeArraySubType, safeArrayUserDefinedSubType, arraySubType, (short)num, sizeConst, text, marshalTypeRef, marshalCookie, iidParamIndex);
		}

		// Token: 0x0600601D RID: 24605 RVA: 0x0014B8F0 File Offset: 0x00149AF0
		internal MarshalAsAttribute(UnmanagedType val, VarEnum safeArraySubType, RuntimeType safeArrayUserDefinedSubType, UnmanagedType arraySubType, short sizeParamIndex, int sizeConst, string marshalType, RuntimeType marshalTypeRef, string marshalCookie, int iidParamIndex)
		{
			this._val = val;
			this.SafeArraySubType = safeArraySubType;
			this.SafeArrayUserDefinedSubType = safeArrayUserDefinedSubType;
			this.IidParameterIndex = iidParamIndex;
			this.ArraySubType = arraySubType;
			this.SizeParamIndex = sizeParamIndex;
			this.SizeConst = sizeConst;
			this.MarshalType = marshalType;
			this.MarshalTypeRef = marshalTypeRef;
			this.MarshalCookie = marshalCookie;
		}

		// Token: 0x0600601E RID: 24606 RVA: 0x0014B950 File Offset: 0x00149B50
		[__DynamicallyInvokable]
		public MarshalAsAttribute(UnmanagedType unmanagedType)
		{
			this._val = unmanagedType;
		}

		// Token: 0x0600601F RID: 24607 RVA: 0x0014B95F File Offset: 0x00149B5F
		[__DynamicallyInvokable]
		public MarshalAsAttribute(short unmanagedType)
		{
			this._val = (UnmanagedType)unmanagedType;
		}

		// Token: 0x170010DF RID: 4319
		// (get) Token: 0x06006020 RID: 24608 RVA: 0x0014B96E File Offset: 0x00149B6E
		[__DynamicallyInvokable]
		public UnmanagedType Value
		{
			[__DynamicallyInvokable]
			get
			{
				return this._val;
			}
		}

		// Token: 0x04002AF7 RID: 10999
		internal UnmanagedType _val;

		// Token: 0x04002AF8 RID: 11000
		[__DynamicallyInvokable]
		public VarEnum SafeArraySubType;

		// Token: 0x04002AF9 RID: 11001
		[__DynamicallyInvokable]
		public Type SafeArrayUserDefinedSubType;

		// Token: 0x04002AFA RID: 11002
		[__DynamicallyInvokable]
		public int IidParameterIndex;

		// Token: 0x04002AFB RID: 11003
		[__DynamicallyInvokable]
		public UnmanagedType ArraySubType;

		// Token: 0x04002AFC RID: 11004
		[__DynamicallyInvokable]
		public short SizeParamIndex;

		// Token: 0x04002AFD RID: 11005
		[__DynamicallyInvokable]
		public int SizeConst;

		// Token: 0x04002AFE RID: 11006
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public string MarshalType;

		// Token: 0x04002AFF RID: 11007
		[ComVisible(true)]
		[__DynamicallyInvokable]
		public Type MarshalTypeRef;

		// Token: 0x04002B00 RID: 11008
		[__DynamicallyInvokable]
		public string MarshalCookie;
	}
}
