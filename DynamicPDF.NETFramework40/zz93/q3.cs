using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x0200028A RID: 650
	internal class q3 : Resource
	{
		// Token: 0x06001D38 RID: 7480 RVA: 0x0012B34E File Offset: 0x0012A34E
		internal q3(r2 A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06001D39 RID: 7481 RVA: 0x0012B368 File Offset: 0x0012A368
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(q3.b);
			writer.WriteArrayOpen();
			q2 q = this.a.i();
			int i = 0;
			while (i < q.a())
			{
				if (q.a(i) != null)
				{
					int num = q.a(i).c().c();
					if (num != 0)
					{
						writer.WriteNumber(i);
						if (q.a(i).b())
						{
							if (this.a.b(i, 0) != null && this.a.f()[this.a.b(i, 0)] != null)
							{
								writer.WriteReferenceShallow((int)this.a.f()[this.a.b(i, 0)]);
							}
						}
						else
						{
							writer.WriteArrayOpen();
							for (int j = 0; j < num; j++)
							{
								if (this.a.b(i, j) != null && this.a.f()[this.a.b(i, j)] != null)
								{
									writer.WriteReferenceShallow((int)this.a.f()[this.a.b(i, j)]);
								}
							}
							writer.WriteArrayClose();
						}
					}
				}
				IL_17C:
				i++;
				continue;
				goto IL_17C;
			}
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x04000D2B RID: 3371
		private new r2 a = null;

		// Token: 0x04000D2C RID: 3372
		private new static byte[] b = new byte[]
		{
			78,
			117,
			109,
			115
		};
	}
}
