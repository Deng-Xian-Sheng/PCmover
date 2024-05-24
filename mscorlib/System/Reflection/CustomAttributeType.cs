using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005DC RID: 1500
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	internal struct CustomAttributeType
	{
		// Token: 0x0600456A RID: 17770 RVA: 0x000FF4B9 File Offset: 0x000FD6B9
		public CustomAttributeType(CustomAttributeEncoding encodedType, CustomAttributeEncoding encodedArrayType, CustomAttributeEncoding encodedEnumType, string enumName)
		{
			this.m_encodedType = encodedType;
			this.m_encodedArrayType = encodedArrayType;
			this.m_encodedEnumType = encodedEnumType;
			this.m_enumName = enumName;
			this.m_padding = this.m_encodedType;
		}

		// Token: 0x17000A59 RID: 2649
		// (get) Token: 0x0600456B RID: 17771 RVA: 0x000FF4E4 File Offset: 0x000FD6E4
		public CustomAttributeEncoding EncodedType
		{
			get
			{
				return this.m_encodedType;
			}
		}

		// Token: 0x17000A5A RID: 2650
		// (get) Token: 0x0600456C RID: 17772 RVA: 0x000FF4EC File Offset: 0x000FD6EC
		public CustomAttributeEncoding EncodedEnumType
		{
			get
			{
				return this.m_encodedEnumType;
			}
		}

		// Token: 0x17000A5B RID: 2651
		// (get) Token: 0x0600456D RID: 17773 RVA: 0x000FF4F4 File Offset: 0x000FD6F4
		public CustomAttributeEncoding EncodedArrayType
		{
			get
			{
				return this.m_encodedArrayType;
			}
		}

		// Token: 0x17000A5C RID: 2652
		// (get) Token: 0x0600456E RID: 17774 RVA: 0x000FF4FC File Offset: 0x000FD6FC
		[ComVisible(true)]
		public string EnumName
		{
			get
			{
				return this.m_enumName;
			}
		}

		// Token: 0x04001C83 RID: 7299
		private string m_enumName;

		// Token: 0x04001C84 RID: 7300
		private CustomAttributeEncoding m_encodedType;

		// Token: 0x04001C85 RID: 7301
		private CustomAttributeEncoding m_encodedEnumType;

		// Token: 0x04001C86 RID: 7302
		private CustomAttributeEncoding m_encodedArrayType;

		// Token: 0x04001C87 RID: 7303
		private CustomAttributeEncoding m_padding;
	}
}
