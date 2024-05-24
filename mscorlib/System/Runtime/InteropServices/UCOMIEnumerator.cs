using System;

namespace System.Runtime.InteropServices
{
	// Token: 0x0200097E RID: 2430
	[Obsolete("Use System.Runtime.InteropServices.ComTypes.IEnumerator instead. http://go.microsoft.com/fwlink/?linkid=14202", false)]
	[Guid("496B0ABF-CDEE-11d3-88E8-00902754C43A")]
	internal interface UCOMIEnumerator
	{
		// Token: 0x06006283 RID: 25219
		bool MoveNext();

		// Token: 0x17001116 RID: 4374
		// (get) Token: 0x06006284 RID: 25220
		object Current { get; }

		// Token: 0x06006285 RID: 25221
		void Reset();
	}
}
