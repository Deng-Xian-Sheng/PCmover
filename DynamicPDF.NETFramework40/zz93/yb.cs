using System;
using System.Collections;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003A1 RID: 929
	internal class yb : Resource
	{
		// Token: 0x0600278F RID: 10127 RVA: 0x0016B339 File Offset: 0x0016A339
		internal yb()
		{
		}

		// Token: 0x06002790 RID: 10128 RVA: 0x0016B350 File Offset: 0x0016A350
		internal new void a(Font A_0)
		{
			if (!this.a.Contains(A_0))
			{
				this.a.Add(A_0);
			}
		}

		// Token: 0x06002791 RID: 10129 RVA: 0x0016B37C File Offset: 0x0016A37C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.i);
			writer.WriteDictionaryOpen();
			for (int i = 0; i < this.a.Count; i++)
			{
				writer.WriteName(((Font)this.a[i]).bg());
				writer.WriteReference(writer.Resources.Add((Font)this.a[i]));
			}
			writer.WriteDictionaryClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002792 RID: 10130 RVA: 0x0016B41C File Offset: 0x0016A41C
		internal new Font b(Font A_0)
		{
			for (int i = 0; i < this.a.Count; i++)
			{
				if (((Font)this.a[i]).bg().Equals(A_0.bg()))
				{
					return (Font)this.a[i];
				}
			}
			return null;
		}

		// Token: 0x04001122 RID: 4386
		private new ArrayList a = new ArrayList(3);
	}
}
