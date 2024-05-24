using System;
using System.Diagnostics;
using System.Security;

namespace System.Runtime.Serialization.Formatters.Binary
{
	// Token: 0x0200078E RID: 1934
	internal sealed class MemberPrimitiveUnTyped : IStreamable
	{
		// Token: 0x0600540E RID: 21518 RVA: 0x0012852B File Offset: 0x0012672B
		internal MemberPrimitiveUnTyped()
		{
		}

		// Token: 0x0600540F RID: 21519 RVA: 0x00128533 File Offset: 0x00126733
		internal void Set(InternalPrimitiveTypeE typeInformation, object value)
		{
			this.typeInformation = typeInformation;
			this.value = value;
		}

		// Token: 0x06005410 RID: 21520 RVA: 0x00128543 File Offset: 0x00126743
		internal void Set(InternalPrimitiveTypeE typeInformation)
		{
			this.typeInformation = typeInformation;
		}

		// Token: 0x06005411 RID: 21521 RVA: 0x0012854C File Offset: 0x0012674C
		public void Write(__BinaryWriter sout)
		{
			sout.WriteValue(this.typeInformation, this.value);
		}

		// Token: 0x06005412 RID: 21522 RVA: 0x00128560 File Offset: 0x00126760
		[SecurityCritical]
		public void Read(__BinaryParser input)
		{
			this.value = input.ReadValue(this.typeInformation);
		}

		// Token: 0x06005413 RID: 21523 RVA: 0x00128574 File Offset: 0x00126774
		public void Dump()
		{
		}

		// Token: 0x06005414 RID: 21524 RVA: 0x00128578 File Offset: 0x00126778
		[Conditional("_LOGGING")]
		private void DumpInternal()
		{
			if (BCLDebug.CheckEnabled("BINARY"))
			{
				string text = Converter.ToComType(this.typeInformation);
			}
		}

		// Token: 0x040025F8 RID: 9720
		internal InternalPrimitiveTypeE typeInformation;

		// Token: 0x040025F9 RID: 9721
		internal object value;
	}
}
