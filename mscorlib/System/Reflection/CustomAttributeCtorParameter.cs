using System;
using System.Runtime.InteropServices;

namespace System.Reflection
{
	// Token: 0x020005DA RID: 1498
	[Serializable]
	[StructLayout(LayoutKind.Auto)]
	internal struct CustomAttributeCtorParameter
	{
		// Token: 0x06004566 RID: 17766 RVA: 0x000FF49C File Offset: 0x000FD69C
		public CustomAttributeCtorParameter(CustomAttributeType type)
		{
			this.m_type = type;
			this.m_encodedArgument = default(CustomAttributeEncodedArgument);
		}

		// Token: 0x17000A58 RID: 2648
		// (get) Token: 0x06004567 RID: 17767 RVA: 0x000FF4B1 File Offset: 0x000FD6B1
		public CustomAttributeEncodedArgument CustomAttributeEncodedArgument
		{
			get
			{
				return this.m_encodedArgument;
			}
		}

		// Token: 0x04001C7D RID: 7293
		private CustomAttributeType m_type;

		// Token: 0x04001C7E RID: 7294
		private CustomAttributeEncodedArgument m_encodedArgument;
	}
}
