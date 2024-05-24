using System;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Reflection
{
	// Token: 0x020005D8 RID: 1496
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	internal struct CustomAttributeEncodedArgument
	{
		// Token: 0x0600455E RID: 17758
		[SecurityCritical]
		[MethodImpl(MethodImplOptions.InternalCall)]
		private static extern void ParseAttributeArguments(IntPtr pCa, int cCa, ref CustomAttributeCtorParameter[] CustomAttributeCtorParameters, ref CustomAttributeNamedParameter[] CustomAttributeTypedArgument, RuntimeAssembly assembly);

		// Token: 0x0600455F RID: 17759 RVA: 0x000FF3FC File Offset: 0x000FD5FC
		[SecurityCritical]
		internal static void ParseAttributeArguments(ConstArray attributeBlob, ref CustomAttributeCtorParameter[] customAttributeCtorParameters, ref CustomAttributeNamedParameter[] customAttributeNamedParameters, RuntimeModule customAttributeModule)
		{
			if (customAttributeModule == null)
			{
				throw new ArgumentNullException("customAttributeModule");
			}
			if (customAttributeCtorParameters.Length != 0 || customAttributeNamedParameters.Length != 0)
			{
				CustomAttributeEncodedArgument.ParseAttributeArguments(attributeBlob.Signature, attributeBlob.Length, ref customAttributeCtorParameters, ref customAttributeNamedParameters, (RuntimeAssembly)customAttributeModule.Assembly);
			}
		}

		// Token: 0x17000A53 RID: 2643
		// (get) Token: 0x06004560 RID: 17760 RVA: 0x000FF43C File Offset: 0x000FD63C
		public CustomAttributeType CustomAttributeType
		{
			get
			{
				return this.m_type;
			}
		}

		// Token: 0x17000A54 RID: 2644
		// (get) Token: 0x06004561 RID: 17761 RVA: 0x000FF444 File Offset: 0x000FD644
		public long PrimitiveValue
		{
			get
			{
				return this.m_primitiveValue;
			}
		}

		// Token: 0x17000A55 RID: 2645
		// (get) Token: 0x06004562 RID: 17762 RVA: 0x000FF44C File Offset: 0x000FD64C
		public CustomAttributeEncodedArgument[] ArrayValue
		{
			get
			{
				return this.m_arrayValue;
			}
		}

		// Token: 0x17000A56 RID: 2646
		// (get) Token: 0x06004563 RID: 17763 RVA: 0x000FF454 File Offset: 0x000FD654
		public string StringValue
		{
			get
			{
				return this.m_stringValue;
			}
		}

		// Token: 0x04001C74 RID: 7284
		private long m_primitiveValue;

		// Token: 0x04001C75 RID: 7285
		private CustomAttributeEncodedArgument[] m_arrayValue;

		// Token: 0x04001C76 RID: 7286
		private string m_stringValue;

		// Token: 0x04001C77 RID: 7287
		private CustomAttributeType m_type;
	}
}
