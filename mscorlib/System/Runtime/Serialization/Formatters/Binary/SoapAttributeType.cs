using System;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000777 RID: 1911
	[Serializable]
	internal enum SoapAttributeType
	{
		// Token: 0x0400256E RID: 9582
		None,
		// Token: 0x0400256F RID: 9583
		SchemaType,
		// Token: 0x04002570 RID: 9584
		Embedded,
		// Token: 0x04002571 RID: 9585
		XmlElement = 4,
		// Token: 0x04002572 RID: 9586
		XmlAttribute = 8
	}
}
