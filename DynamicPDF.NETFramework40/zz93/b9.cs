using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000068 RID: 104
	internal class b9 : Resource
	{
		// Token: 0x0600046A RID: 1130 RVA: 0x00049860 File Offset: 0x00048860
		internal b9(abj A_0, DocumentWriter A_1)
		{
			this.a = A_0;
			for (abk abk = this.a.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num != 111594775)
				{
					if (num != 211216860)
					{
						if (num == 567551866)
						{
							if (abk.c().hy() == ag9.e)
							{
								abe abe = (abe)abk.c();
								for (int i = 0; i < abe.a(); i++)
								{
									if (abe.a(i).hy() == ag9.g)
									{
										for (abk abk2 = ((abj)abe.a(i)).l(); abk2 != null; abk2 = abk2.d())
										{
											if (abk2.a().j9() == "Name")
											{
												abe.a(i).a(false);
											}
										}
									}
								}
							}
						}
					}
					else if (A_1.Document.Security != null && A_1.Document.Security.a() == b5.b)
					{
						if (A_1.Document.Security.d())
						{
							abk.a(false);
						}
					}
				}
				else if (abk.c().hy() == ag9.e)
				{
					abe abe2 = (abe)abk.c();
					for (int i = 0; i < abe2.a(); i++)
					{
						if (((abu)abe2.a(i)).j9() == "Crypt")
						{
							abe2.a(i).a(false);
						}
					}
				}
				else if (abk.c().hy() == ag9.d)
				{
					if (((abu)abk.c()).j9() == "Crypt")
					{
						abk.c().a(false);
					}
				}
			}
		}

		// Token: 0x0600046B RID: 1131 RVA: 0x00049AAC File Offset: 0x00048AAC
		public override int get_RequiredPdfObjects()
		{
			return 1;
		}

		// Token: 0x0600046C RID: 1132 RVA: 0x00049AC0 File Offset: 0x00048AC0
		public override void Draw(DocumentWriter writer)
		{
			if (writer.Document.Security != null && writer.Document.Security.a() == b5.b && writer.Document.Security.d())
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				for (abk abk = this.a.l(); abk != null; abk = abk.d())
				{
					abk.a(writer);
				}
				writer.WriteName(Resource.c);
				writer.WriteArrayOpen();
				writer.WriteName(b9.b);
				writer.WriteName(Resource.d);
				writer.WriteArrayClose();
				writer.WriteName(b9.c);
				writer.WriteArrayOpen();
				writer.WriteDictionaryOpen();
				writer.WriteName(b9.d);
				writer.WriteName(b9.e);
				writer.WriteDictionaryClose();
				writer.WriteNull();
				writer.WriteArrayClose();
				if (this.a.hy() == ag9.h)
				{
					afj afj = (afj)this.a;
					afj.j6(writer);
				}
				else
				{
					writer.WriteDictionaryClose();
				}
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteBeginObject();
				this.a.hz(writer);
				writer.WriteEndObject();
			}
		}

		// Token: 0x0400028F RID: 655
		private new abj a;

		// Token: 0x04000290 RID: 656
		private new static byte[] b = new byte[]
		{
			67,
			114,
			121,
			112,
			116
		};

		// Token: 0x04000291 RID: 657
		private new static byte[] c = new byte[]
		{
			68,
			101,
			99,
			111,
			100,
			101,
			80,
			97,
			114,
			109,
			115
		};

		// Token: 0x04000292 RID: 658
		private new static byte[] d = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x04000293 RID: 659
		private new static byte[] e = new byte[]
		{
			83,
			116,
			100,
			67,
			70
		};
	}
}
