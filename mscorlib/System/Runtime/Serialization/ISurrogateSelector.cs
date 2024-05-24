using System;
using System.Runtime.InteropServices;
using System.Security;

namespace System.Runtime.Serialization
{
	// Token: 0x02000736 RID: 1846
	[ComVisible(true)]
	public interface ISurrogateSelector
	{
		// Token: 0x060051BE RID: 20926
		[SecurityCritical]
		void ChainSelector(ISurrogateSelector selector);

		// Token: 0x060051BF RID: 20927
		[SecurityCritical]
		ISerializationSurrogate GetSurrogate(Type type, StreamingContext context, out ISurrogateSelector selector);

		// Token: 0x060051C0 RID: 20928
		[SecurityCritical]
		ISurrogateSelector GetNextSelector();
	}
}
