using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x0200057D RID: 1405
	internal abstract class aky
	{
		// Token: 0x060037A0 RID: 14240 RVA: 0x001E07D0 File Offset: 0x001DF7D0
		internal aky m()
		{
			return this.a;
		}

		// Token: 0x060037A1 RID: 14241 RVA: 0x001E07E8 File Offset: 0x001DF7E8
		internal void a(aky A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060037A2 RID: 14242
		internal abstract void my(DocumentLayoutPartList A_0);

		// Token: 0x060037A3 RID: 14243 RVA: 0x001E07F4 File Offset: 0x001DF7F4
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

		// Token: 0x04001A5D RID: 6749
		private aky a = null;
	}
}
