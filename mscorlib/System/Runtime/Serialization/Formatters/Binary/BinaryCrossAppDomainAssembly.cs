using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000783 RID: 1923
	internal sealed class BinaryCrossAppDomainAssembly : IStreamable
	{
		// Token: 0x060053CD RID: 21453 RVA: 0x00126F94 File Offset: 0x00125194
		internal BinaryCrossAppDomainAssembly()
		{
		}

		// Token: 0x060053CE RID: 21454 RVA: 0x00126F9C File Offset: 0x0012519C
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(20);
			sout.WriteInt32(this.assemId);
			sout.WriteInt32(this.assemblyIndex);
		}

		// Token: 0x060053CF RID: 21455 RVA: 0x00126FBE File Offset: 0x001251BE
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.assemId = input.ReadInt32();
			this.assemblyIndex = input.ReadInt32();
		}

		// Token: 0x060053D0 RID: 21456 RVA: 0x00126FD8 File Offset: 0x001251D8
		public void Dump()
		{
		}

		// Token: 0x060053D1 RID: 21457 RVA: 0x00126FDA File Offset: 0x001251DA
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025BC RID: 9660
		internal int assemId;

		// Token: 0x040025BD RID: 9661
		internal int assemblyIndex;
	}
}
