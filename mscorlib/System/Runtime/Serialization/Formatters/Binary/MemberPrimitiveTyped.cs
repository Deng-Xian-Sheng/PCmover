using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200078A RID: 1930
	internal sealed class MemberPrimitiveTyped : IStreamable
	{
		// Token: 0x060053F7 RID: 21495 RVA: 0x00127CDE File Offset: 0x00125EDE
		internal MemberPrimitiveTyped()
		{
		}

		// Token: 0x060053F8 RID: 21496 RVA: 0x00127CE6 File Offset: 0x00125EE6
		internal void Set(InternalPrimitiveTypeE primitiveTypeEnum, object value)
		{
			this.primitiveTypeEnum = primitiveTypeEnum;
			this.value = value;
		}

		// Token: 0x060053F9 RID: 21497 RVA: 0x00127CF6 File Offset: 0x00125EF6
		public void Write(__BinaryWriter sout)
		{
			sout.WriteByte(8);
			sout.WriteByte((byte)this.primitiveTypeEnum);
			sout.WriteValue(this.primitiveTypeEnum, this.value);
		}

		// Token: 0x060053FA RID: 21498 RVA: 0x00127D1E File Offset: 0x00125F1E
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.primitiveTypeEnum = (InternalPrimitiveTypeE)input.ReadByte();
			this.value = input.ReadValue(this.primitiveTypeEnum);
		}

		// Token: 0x060053FB RID: 21499 RVA: 0x00127D3E File Offset: 0x00125F3E
		public void Dump()
		{
		}

		// Token: 0x060053FC RID: 21500 RVA: 0x00127D40 File Offset: 0x00125F40
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			BCLDebug.CheckEnabled("BINARY");
		}

		// Token: 0x040025DE RID: 9694
		internal InternalPrimitiveTypeE primitiveTypeEnum;

		// Token: 0x040025DF RID: 9695
		internal object value;
	}
}
