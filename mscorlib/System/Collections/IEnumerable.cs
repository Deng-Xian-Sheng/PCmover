using System;
using System.Runtime.InteropServices;

namespace System.Collections
{
	// Token: 0x0200049D RID: 1181
	[Guid("496B0ABE-CDEE-11d3-88E8-00902754C43A")]
	[ComVisible(true)]
	[__DynamicallyInvokable]
	public interface IEnumerable
	{
		// Token: 0x060038B5 RID: 14517
		[DispId(-4)]
		[__DynamicallyInvokable]
		IEnumerator GetEnumerator();
	}
}
