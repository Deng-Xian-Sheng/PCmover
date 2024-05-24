using System;
using System.IO;
using System.Resources;

namespace System.Reflection.Emit
{
	// Token: 0x0200062B RID: 1579
	internal class ResWriterData
	{
		// Token: 0x06004986 RID: 18822 RVA: 0x0010A7D9 File Offset: 0x001089D9
		internal ResWriterData(ResourceWriter resWriter, Stream memoryStream, string strName, string strFileName, string strFullFileName, ResourceAttributes attribute)
		{
			this.m_resWriter = resWriter;
			this.m_memoryStream = memoryStream;
			this.m_strName = strName;
			this.m_strFileName = strFileName;
			this.m_strFullFileName = strFullFileName;
			this.m_nextResWriter = null;
			this.m_attribute = attribute;
		}

		// Token: 0x04001E65 RID: 7781
		internal ResourceWriter m_resWriter;

		// Token: 0x04001E66 RID: 7782
		internal string m_strName;

		// Token: 0x04001E67 RID: 7783
		internal string m_strFileName;

		// Token: 0x04001E68 RID: 7784
		internal string m_strFullFileName;

		// Token: 0x04001E69 RID: 7785
		internal Stream m_memoryStream;

		// Token: 0x04001E6A RID: 7786
		internal ResWriterData m_nextResWriter;

		// Token: 0x04001E6B RID: 7787
		internal ResourceAttributes m_attribute;
	}
}
