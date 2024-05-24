using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000788 RID: 1928
	internal sealed class BinaryCrossAppDomainString : IStreamable
	{
		// Token: 0x060053ED RID: 21485 RVA: 0x00127C50 File Offset: 0x00125E50
		internal BinaryCrossAppDomainString()
		{
		}

		// Token: 0x060053EE RID: 21486 RVA: 0x00127C58 File Offset: 0x00125E58
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(19);
			sout.WriteInt32(this.objectId);
			sout.WriteInt32(this.value);
		}

		// Token: 0x060053EF RID: 21487 RVA: 0x00127C7A File Offset: 0x00125E7A
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.objectId = input.ReadInt32();
			this.value = input.ReadInt32();
		}

		// Token: 0x060053F0 RID: 21488 RVA: 0x00127C94 File Offset: 0x00125E94
		public void Dump()
		{
		}

		// Token: 0x060053F1 RID: 21489 RVA: 0x00127C96 File Offset: 0x00125E96
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025DB RID: 9691
		internal int objectId;

		// Token: 0x040025DC RID: 9692
		internal int value;
	}
}
