using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x02000782 RID: 1922
	internal sealed class BinaryAssembly : IStreamable
	{
		// Token: 0x060053C7 RID: 21447 RVA: 0x00126F31 File Offset: 0x00125131
		internal BinaryAssembly()
		{
		}

		// Token: 0x060053C8 RID: 21448 RVA: 0x00126F39 File Offset: 0x00125139
		internal void Set(int assemId, string assemblyString)
		{
			this.assemId = assemId;
			this.assemblyString = assemblyString;
		}

		// Token: 0x060053C9 RID: 21449 RVA: 0x00126F49 File Offset: 0x00125149
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(12);
			sout.WriteInt32(this.assemId);
			sout.WriteString(this.assemblyString);
		}

		// Token: 0x060053CA RID: 21450 RVA: 0x00126F6B File Offset: 0x0012516B
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.assemId = input.ReadInt32();
			this.assemblyString = input.ReadString();
		}

		// Token: 0x060053CB RID: 21451 RVA: 0x00126F85 File Offset: 0x00125185
		public void Dump()
		{
		}

		// Token: 0x060053CC RID: 21452 RVA: 0x00126F87 File Offset: 0x00125187
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025BA RID: 9658
		internal int assemId;

		// Token: 0x040025BB RID: 9659
		internal string assemblyString;
	}
}
