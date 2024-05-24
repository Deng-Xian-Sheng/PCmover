using System;

namespace System.Runtime.InteropServices.ComTypes
{
	// Token: 0x02000A27 RID: 2599
	[Guid("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
	internal interface IEnumerator
	{
		// Token: 0x06006616 RID: 26134
		bool MoveNext();

		// Token: 0x1700118A RID: 4490
		// (get) Token: 0x06006617 RID: 26135
		object Current { get; }

		// Token: 0x06006618 RID: 26136
		void Reset();
	}
}
