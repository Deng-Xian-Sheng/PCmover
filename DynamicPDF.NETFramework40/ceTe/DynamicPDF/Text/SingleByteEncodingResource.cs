using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000867 RID: 2151
	public class SingleByteEncodingResource : Resource
	{
		// Token: 0x06005741 RID: 22337 RVA: 0x002EC685 File Offset: 0x002EB685
		public SingleByteEncodingResource(long uid, byte[] data) : base(uid)
		{
			this.a = data;
		}

		// Token: 0x1700088F RID: 2191
		// (get) Token: 0x06005742 RID: 22338 RVA: 0x002EC698 File Offset: 0x002EB698
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x06005743 RID: 22339 RVA: 0x002EC6AB File Offset: 0x002EB6AB
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.Write(this.a);
			writer.WriteEndObject();
		}

		// Token: 0x17000890 RID: 2192
		// (get) Token: 0x06005744 RID: 22340 RVA: 0x002EC6CC File Offset: 0x002EB6CC
		public override ResourceType ResourceType
		{
			get
			{
				return ResourceType.Font;
			}
		}

		// Token: 0x04002E62 RID: 11874
		private new byte[] a;
	}
}
