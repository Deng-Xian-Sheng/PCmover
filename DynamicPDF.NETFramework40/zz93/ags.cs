using System;
using ceTe.DynamicPDF.Merger;

namespace zz93
{
	// Token: 0x020004E3 RID: 1251
	internal class ags
	{
		// Token: 0x060032E9 RID: 13033 RVA: 0x001C53A9 File Offset: 0x001C43A9
		internal ags(aba A_0)
		{
			this.a = A_0;
		}

		// Token: 0x060032EA RID: 13034 RVA: 0x001C53BC File Offset: 0x001C43BC
		internal PdfDocument b()
		{
			return this.a.af();
		}

		// Token: 0x060032EB RID: 13035 RVA: 0x001C53DC File Offset: 0x001C43DC
		internal static bool d(byte A_0)
		{
			return A_0 >= 48 && A_0 <= 57;
		}

		// Token: 0x060032EC RID: 13036 RVA: 0x001C5400 File Offset: 0x001C4400
		internal static bool c(byte A_0)
		{
			if (A_0 <= 47)
			{
				switch (A_0)
				{
				case 37:
					return true;
				case 38:
				case 39:
					break;
				case 40:
					return true;
				case 41:
					return true;
				default:
					if (A_0 == 47)
					{
						return true;
					}
					break;
				}
			}
			else
			{
				switch (A_0)
				{
				case 60:
					return true;
				case 61:
					break;
				case 62:
					return true;
				default:
					switch (A_0)
					{
					case 91:
						return true;
					case 92:
						break;
					case 93:
						return true;
					default:
						switch (A_0)
						{
						case 123:
							return true;
						case 125:
							return true;
						}
						break;
					}
					break;
				}
			}
			return false;
		}

		// Token: 0x060032ED RID: 13037 RVA: 0x001C54A8 File Offset: 0x001C44A8
		internal static bool b(byte A_0)
		{
			return A_0 <= 32;
		}

		// Token: 0x060032EE RID: 13038 RVA: 0x001C54C4 File Offset: 0x001C44C4
		internal static bool a(byte A_0)
		{
			return !ags.b(A_0) && !ags.c(A_0);
		}

		// Token: 0x04001866 RID: 6246
		private aba a;
	}
}
