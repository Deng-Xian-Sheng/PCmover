using System;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200077F RID: 1919
	internal interface IStreamable
	{
		// Token: 0x060053BB RID: 21435
		[SecurityCritical]
		void Read(__BinaryParser input);

		// Token: 0x060053BC RID: 21436
		void Write(__BinaryWriter sout);
	}
}
