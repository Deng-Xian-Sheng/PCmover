using System;
using System.Collections;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x020007A2 RID: 1954
	internal sealed class SerObjectInfoInit
	{
		// Token: 0x040026FE RID: 9982
		internal Hashtable seenBeforeTable = new Hashtable();

		// Token: 0x040026FF RID: 9983
		internal int objectInfoIdCount = 1;

		// Token: 0x04002700 RID: 9984
		internal SerStack oiPool = new SerStack("SerObjectInfo Pool");
	}
}
