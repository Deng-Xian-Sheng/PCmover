using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200078F RID: 1935
	internal sealed class MemberReference : IStreamable
	{
		// Token: 0x06005415 RID: 21525 RVA: 0x0012859D File Offset: 0x0012679D
		internal MemberReference()
		{
		}

		// Token: 0x06005416 RID: 21526 RVA: 0x001285A5 File Offset: 0x001267A5
		internal void Set(int idRef)
		{
			this.idRef = idRef;
		}

		// Token: 0x06005417 RID: 21527 RVA: 0x001285AE File Offset: 0x001267AE
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(9);
			sout.WriteInt32(this.idRef);
		}

		// Token: 0x06005418 RID: 21528 RVA: 0x001285C4 File Offset: 0x001267C4
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.idRef = input.ReadInt32();
		}

		// Token: 0x06005419 RID: 21529 RVA: 0x001285D2 File Offset: 0x001267D2
		public void Dump()
		{
		}

		// Token: 0x0600541A RID: 21530 RVA: 0x001285D4 File Offset: 0x001267D4
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025FA RID: 9722
		internal int idRef;
	}
}
