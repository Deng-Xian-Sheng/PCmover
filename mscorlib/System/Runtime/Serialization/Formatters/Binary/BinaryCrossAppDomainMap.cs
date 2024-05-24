using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000789 RID: 1929
	internal sealed class BinaryCrossAppDomainMap : IStreamable
	{
		// Token: 0x060053F2 RID: 21490 RVA: 0x00127CA3 File Offset: 0x00125EA3
		internal BinaryCrossAppDomainMap()
		{
		}

		// Token: 0x060053F3 RID: 21491 RVA: 0x00127CAB File Offset: 0x00125EAB
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(18);
			sout.WriteInt32(this.crossAppDomainArrayIndex);
		}

		// Token: 0x060053F4 RID: 21492 RVA: 0x00127CC1 File Offset: 0x00125EC1
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.crossAppDomainArrayIndex = input.ReadInt32();
		}

		// Token: 0x060053F5 RID: 21493 RVA: 0x00127CCF File Offset: 0x00125ECF
		public void Dump()
		{
		}

		// Token: 0x060053F6 RID: 21494 RVA: 0x00127CD1 File Offset: 0x00125ED1
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025DD RID: 9693
		internal int crossAppDomainArrayIndex;
	}
}
