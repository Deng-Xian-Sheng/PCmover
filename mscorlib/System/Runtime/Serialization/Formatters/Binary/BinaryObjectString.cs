using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000787 RID: 1927
	internal sealed class BinaryObjectString : IStreamable
	{
		// Token: 0x060053E7 RID: 21479 RVA: 0x00127BEE File Offset: 0x00125DEE
		internal BinaryObjectString()
		{
		}

		// Token: 0x060053E8 RID: 21480 RVA: 0x00127BF6 File Offset: 0x00125DF6
		internal void Set(int objectId, string value)
		{
			this.objectId = objectId;
			this.value = value;
		}

		// Token: 0x060053E9 RID: 21481 RVA: 0x00127C06 File Offset: 0x00125E06
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(6);
			sout.WriteInt32(this.objectId);
			sout.WriteString(this.value);
		}

		// Token: 0x060053EA RID: 21482 RVA: 0x00127C27 File Offset: 0x00125E27
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.objectId = input.ReadInt32();
			this.value = input.ReadString();
		}

		// Token: 0x060053EB RID: 21483 RVA: 0x00127C41 File Offset: 0x00125E41
		public void Dump()
		{
		}

		// Token: 0x060053EC RID: 21484 RVA: 0x00127C43 File Offset: 0x00125E43
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025D9 RID: 9689
		internal int objectId;

		// Token: 0x040025DA RID: 9690
		internal string value;
	}
}
