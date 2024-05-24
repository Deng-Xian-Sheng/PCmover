using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003EE RID: 1006
	internal class aad : Resource
	{
		// Token: 0x06002A0B RID: 10763 RVA: 0x0018741E File Offset: 0x0018641E
		internal aad(OutlineList A_0, int A_1)
		{
			this.e = A_0;
			this.f = A_0.c() + A_0.Count;
			A_0.a(ref A_1);
		}

		// Token: 0x06002A0C RID: 10764 RVA: 0x0018744C File Offset: 0x0018644C
		public override int get_RequiredPdfObjects()
		{
			return this.f + 1;
		}

		// Token: 0x06002A0D RID: 10765 RVA: 0x00187468 File Offset: 0x00186468
		public override void Draw(DocumentWriter writer)
		{
			b3 b = null;
			if (writer is b3)
			{
				b = (b3)writer;
				if (writer.Document.InitialPageMode == PageMode.ShowOutlines || writer.Document.InitialPageMode == PageMode.Auto)
				{
					b.c(int.MaxValue);
				}
				b.b(17);
			}
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(aad.d);
			writer.WriteName(aad.a);
			writer.WriteReference(this.e[0].a());
			writer.WriteName(aad.b);
			writer.WriteReference(this.e[this.e.Count - 1].a());
			writer.WriteName(aad.c);
			writer.WriteNumber(this.f);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			this.e.a(writer);
			if (b != null)
			{
				zz zz = b.p().a(this.e.b());
				zz.a(zz.k() - 1);
				this.e.a(b);
				b.c(2147483645);
			}
		}

		// Token: 0x04001343 RID: 4931
		private new static byte[] a = new byte[]
		{
			70,
			105,
			114,
			115,
			116
		};

		// Token: 0x04001344 RID: 4932
		private new static byte[] b = new byte[]
		{
			76,
			97,
			115,
			116
		};

		// Token: 0x04001345 RID: 4933
		private new static byte[] c = new byte[]
		{
			67,
			111,
			117,
			110,
			116
		};

		// Token: 0x04001346 RID: 4934
		private new static byte[] d = new byte[]
		{
			79,
			117,
			116,
			108,
			105,
			110,
			101,
			115
		};

		// Token: 0x04001347 RID: 4935
		private new OutlineList e;

		// Token: 0x04001348 RID: 4936
		private new int f;
	}
}
