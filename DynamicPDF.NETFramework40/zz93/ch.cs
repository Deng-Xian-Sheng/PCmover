using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x02000071 RID: 113
	internal class ch : Resource
	{
		// Token: 0x060004AC RID: 1196 RVA: 0x0004E7A2 File Offset: 0x0004D7A2
		internal ch(abj A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060004AD RID: 1197 RVA: 0x0004E7B4 File Offset: 0x0004D7B4
		public override void Draw(DocumentWriter writer)
		{
			if (this.a.k().b().g() == null && (writer.Document.Security == null || writer.Document.Security.a() != b5.b || !writer.Document.Security.d()))
			{
				writer.WriteBeginObject();
				this.a.hz(writer);
				writer.WriteEndObject();
			}
			else if ((this.a.k().b().g() != null && this.a.k().b().g().at()) || (writer.Document.Security != null && writer.Document.Security.a() == b5.b && writer.Document.Security.d()))
			{
				writer.WriteBeginObject();
				writer.WriteDictionaryOpen();
				for (abk abk = this.a.l(); abk != null; abk = abk.d())
				{
					int num = abk.a().j8();
					if (num != 326)
					{
						abk.a(writer);
					}
					else if (abk.c().hy() == ag9.g)
					{
						abk.a().hz(writer);
						writer.WriteDictionaryOpen();
						for (abk abk2 = ((abj)abk.c()).l(); abk2 != null; abk2 = abk2.d())
						{
							if (abk2.a().j9() == "F")
							{
								abk2.a().hz(writer);
								if (abk2.c().hy() == ag9.j)
								{
									ab6 ab = (ab6)abk2.c();
									abg abg = ab.b().m().b((long)ab.c());
									if (abg != null)
									{
										abd abd = abg.i();
										if (abd.hy() == ag9.h)
										{
											writer.WriteReferenceUnique(new b9((abj)abd, writer));
										}
									}
								}
							}
							else
							{
								abk2.a(writer);
							}
						}
						writer.WriteDictionaryClose();
					}
				}
				writer.WriteDictionaryClose();
				writer.WriteEndObject();
			}
			else
			{
				writer.WriteBeginObject();
				this.a.hz(writer);
				writer.WriteEndObject();
			}
		}

		// Token: 0x040002C0 RID: 704
		private new abj a;
	}
}
