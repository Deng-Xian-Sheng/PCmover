using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000093 RID: 147
	internal class da : Resource
	{
		// Token: 0x06000728 RID: 1832 RVA: 0x00062084 File Offset: 0x00061084
		internal da(abj A_0, abg A_1)
		{
			this.b = A_1;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				switch (num)
				{
				case 14:
					this.c = (ab6)abk.c();
					break;
				case 15:
				case 17:
				case 19:
				case 21:
					break;
				case 16:
					this.f = (ab6)abk.c();
					break;
				case 18:
					this.g = (abe)abk.c();
					break;
				case 20:
					this.d = (ab6)abk.c();
					break;
				case 22:
					this.e = (ab6)abk.c();
					break;
				default:
					if (num == 5479461)
					{
						this.h = true;
					}
					break;
				}
			}
		}

		// Token: 0x06000729 RID: 1833 RVA: 0x000621A0 File Offset: 0x000611A0
		internal new abg a()
		{
			return this.b;
		}

		// Token: 0x0600072A RID: 1834 RVA: 0x000621B8 File Offset: 0x000611B8
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			if (this.h)
			{
				writer.WriteName(Resource.a);
				writer.WriteName(da.a);
			}
			writer.WriteName(78);
			this.c.a(writer);
			writer.WriteName(80);
			this.f.a(writer);
			writer.WriteName(82);
			this.g.hz(writer);
			if (this.d != null)
			{
				writer.WriteName(84);
				this.d.a(writer);
			}
			writer.WriteName(86);
			this.e.a(writer);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x040003CB RID: 971
		private new static byte[] a = new byte[]
		{
			66,
			101,
			97,
			100
		};

		// Token: 0x040003CC RID: 972
		private new abg b = null;

		// Token: 0x040003CD RID: 973
		private new ab6 c = null;

		// Token: 0x040003CE RID: 974
		private new ab6 d = null;

		// Token: 0x040003CF RID: 975
		private new ab6 e = null;

		// Token: 0x040003D0 RID: 976
		private new ab6 f = null;

		// Token: 0x040003D1 RID: 977
		private new abe g = null;

		// Token: 0x040003D2 RID: 978
		private new bool h = false;
	}
}
