using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.ReportWriter;

namespace zz93
{
	// Token: 0x02000340 RID: 832
	internal abstract class vt
	{
		// Token: 0x060023A0 RID: 9120 RVA: 0x00151C68 File Offset: 0x00150C68
		internal vt m()
		{
			return this.a;
		}

		// Token: 0x060023A1 RID: 9121 RVA: 0x00151C80 File Offset: 0x00150C80
		internal void a(vt A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060023A2 RID: 9122
		internal abstract void f2(DocumentLayoutPartList A_0);

		// Token: 0x060023A3 RID: 9123 RVA: 0x00151C8C File Offset: 0x00150C8C
		internal PageSize a(int A_0)
		{
			if (A_0 <= 620630763)
			{
				if (A_0 <= 175715612)
				{
					if (A_0 <= 2229)
					{
						switch (A_0)
						{
						case 2163:
							return PageSize.A3;
						case 2164:
							return PageSize.A4;
						case 2165:
							return PageSize.A5;
						case 2166:
							return PageSize.A6;
						default:
							switch (A_0)
							{
							case 2227:
								return PageSize.B3;
							case 2228:
								return PageSize.B4;
							case 2229:
								return PageSize.B5;
							}
							break;
						}
					}
					else
					{
						if (A_0 == 24361212)
						{
							return PageSize.DoublePostcard;
						}
						if (A_0 == 175715612)
						{
							return PageSize.Envelope10;
						}
					}
				}
				else if (A_0 <= 175716761)
				{
					if (A_0 == 175716448)
					{
						return PageSize.EnvelopeDL;
					}
					if (A_0 == 175716761)
					{
						return PageSize.EnvelopeC5;
					}
				}
				else
				{
					if (A_0 == 175716825)
					{
						return PageSize.EnvelopeB5;
					}
					if (A_0 == 584362611)
					{
						return PageSize.B5JIS;
					}
					if (A_0 == 620630763)
					{
						return PageSize.EnvelopeMonarch;
					}
				}
			}
			else if (A_0 <= 817701255)
			{
				if (A_0 <= 650037871)
				{
					if (A_0 == 623953232)
					{
						return PageSize.Executive;
					}
					if (A_0 == 650037871)
					{
						return PageSize.Folio;
					}
				}
				else
				{
					if (A_0 == 748058732)
					{
						return PageSize.Legal;
					}
					if (A_0 == 748113175)
					{
						return PageSize.Letter;
					}
					if (A_0 == 817701255)
					{
						return PageSize.Postcard;
					}
				}
			}
			else if (A_0 <= 818560249)
			{
				if (A_0 == 818560125)
				{
					return PageSize.PRC16K;
				}
				if (A_0 == 818560249)
				{
					return PageSize.PRC32K;
				}
			}
			else
			{
				if (A_0 == 836115741)
				{
					return PageSize.Quatro;
				}
				if (A_0 == 862209681)
				{
					return PageSize.Statement;
				}
				if (A_0 == 881205579)
				{
					return PageSize.Tabloid;
				}
			}
			return PageSize.Letter;
		}

		// Token: 0x04000F59 RID: 3929
		private vt a = null;
	}
}
