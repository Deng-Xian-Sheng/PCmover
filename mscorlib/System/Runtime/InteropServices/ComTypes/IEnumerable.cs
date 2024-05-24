using System;
using System.Collections;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A26 RID: 2598
	[Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
	internal interface IEnumerable
	{
		// Token: 0x06006615 RID: 26133
		[DispId(-4)]
		IEnumerator GetEnumerator();
	}
}
