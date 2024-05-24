using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000784 RID: 1924
	internal sealed class BinaryObject : IStreamable
	{
		// Token: 0x060053D2 RID: 21458 RVA: 0x00126FE7 File Offset: 0x001251E7
		internal BinaryObject()
		{
		}

		// Token: 0x060053D3 RID: 21459 RVA: 0x00126FEF File Offset: 0x001251EF
		internal void Set(int objectId, int mapId)
		{
			this.objectId = objectId;
			this.mapId = mapId;
		}

		// Token: 0x060053D4 RID: 21460 RVA: 0x00126FFF File Offset: 0x001251FF
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(1);
			sout.WriteInt32(this.objectId);
			sout.WriteInt32(this.mapId);
		}

		// Token: 0x060053D5 RID: 21461 RVA: 0x00127020 File Offset: 0x00125220
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.objectId = input.ReadInt32();
			this.mapId = input.ReadInt32();
		}

		// Token: 0x060053D6 RID: 21462 RVA: 0x0012703A File Offset: 0x0012523A
		public void Dump()
		{
		}

		// Token: 0x060053D7 RID: 21463 RVA: 0x0012703C File Offset: 0x0012523C
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025BE RID: 9662
		internal int objectId;

		// Token: 0x040025BF RID: 9663
		internal int mapId;
	}
}
