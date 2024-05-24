using System;
using System.Diagnostics;
using System.IO;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000791 RID: 1937
	internal sealed class MessageEnd : IStreamable
	{
		// Token: 0x06005422 RID: 21538 RVA: 0x001286CA File Offset: 0x001268CA
		internal MessageEnd()
		{
		}

		// Token: 0x06005423 RID: 21539 RVA: 0x001286D2 File Offset: 0x001268D2
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(11);
		}

		// Token: 0x06005424 RID: 21540 RVA: 0x001286DC File Offset: 0x001268DC
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
		}

		// Token: 0x06005425 RID: 21541 RVA: 0x001286DE File Offset: 0x001268DE
		public void Dump()
		{
		}

		// Token: 0x06005426 RID: 21542 RVA: 0x001286E0 File Offset: 0x001268E0
		public void Dump(Stream sout)
		{
		}

		// Token: 0x06005427 RID: 21543 RVA: 0x001286E4 File Offset: 0x001268E4
		[Conditional("_LOGGING")]
		private void DumpInternal(Stream sout)
		{
			if (BCLDebug.CheckEnabled("BINARY") && sout != null && sout.CanSeek)
			{
				long length = sout.Length;
			}
		}
	}
}
