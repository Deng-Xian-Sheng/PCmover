using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005D9 RID: 1497
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	internal struct CustomAttributeNamedParameter
	{
		// Token: 0x06004564 RID: 17764 RVA: 0x000FF45C File Offset: 0x000FD65C
		public CustomAttributeNamedParameter(string argumentName, CustomAttributeEncoding fieldOrProperty, CustomAttributeType type)
		{
			if (argumentName == null)
			{
				throw new ArgumentNullException("argumentName");
			}
			this.m_argumentName = argumentName;
			this.m_fieldOrProperty = fieldOrProperty;
			this.m_padding = fieldOrProperty;
			this.m_type = type;
			this.m_encodedArgument = default(CustomAttributeEncodedArgument);
		}

		// Token: 0x17000A57 RID: 2647
		// (get) Token: 0x06004565 RID: 17765 RVA: 0x000FF494 File Offset: 0x000FD694
		public CustomAttributeEncodedArgument EncodedArgument
		{
			get
			{
				return this.m_encodedArgument;
			}
		}

		// Token: 0x04001C78 RID: 7288
		private string m_argumentName;

		// Token: 0x04001C79 RID: 7289
		private CustomAttributeEncoding m_fieldOrProperty;

		// Token: 0x04001C7A RID: 7290
		private CustomAttributeEncoding m_padding;

		// Token: 0x04001C7B RID: 7291
		private CustomAttributeType m_type;

		// Token: 0x04001C7C RID: 7292
		private CustomAttributeEncodedArgument m_encodedArgument;
	}
}
