using System;
using System.Text;
using ceTe.DynamicPDF;

namespace zz93
{
	// Token: 0x020004A6 RID: 1190
	internal class ae5
	{
		// Token: 0x06003145 RID: 12613 RVA: 0x001B9F38 File Offset: 0x001B8F38
		internal static Encoding a(string A_0)
		{
			string text = A_0.ToLower();
			switch (text)
			{
			case "ibm437":
				return new ae3();
			case "windows-874":
				return new ae4();
			case "windows-1250":
				return new aep();
			case "windows-1251":
				return new aeq();
			case "windows-1252":
				return new aer();
			case "windows-1256":
				return new aes();
			case "iso-8859-2":
				return new aet();
			case "iso-8859-3":
				return new aeu();
			case "iso-8859-4":
				return new aev();
			case "iso-8859-5":
				return new aew();
			case "iso-8859-6":
				return new aex();
			case "iso-8859-7":
				return new aey();
			case "iso-8859-8":
				return new aez();
			case "iso-8859-9":
				return new ae0();
			case "iso-8859-13":
				return new ae1();
			case "iso-8859-15":
				return new ae2();
			}
			Encoding encoding;
			try
			{
				encoding = Encoding.GetEncoding(A_0);
			}
			catch (Exception ex)
			{
				throw new GeneratorException(ex.Message);
			}
			return encoding;
		}

		// Token: 0x06003146 RID: 12614 RVA: 0x001BA15C File Offset: 0x001B915C
		internal static Encoding a(int A_0)
		{
			if (A_0 <= 874)
			{
				if (A_0 == 437)
				{
					return new ae3();
				}
				if (A_0 == 874)
				{
					return new ae4();
				}
			}
			else
			{
				switch (A_0)
				{
				case 1250:
					return new aep();
				case 1251:
					return new aeq();
				case 1252:
					return new aer();
				case 1253:
				case 1254:
				case 1255:
					break;
				case 1256:
					return new aes();
				default:
					switch (A_0)
					{
					case 28592:
						return new aet();
					case 28593:
						return new aeu();
					case 28594:
						return new aev();
					case 28595:
						return new aew();
					case 28596:
						return new aex();
					case 28597:
						return new aey();
					case 28598:
						return new aez();
					case 28599:
						return new ae0();
					case 28603:
						return new ae1();
					case 28605:
						return new ae2();
					}
					break;
				}
			}
			Encoding encoding;
			try
			{
				encoding = Encoding.GetEncoding(A_0);
			}
			catch (Exception ex)
			{
				throw new GeneratorException(ex.Message);
			}
			return encoding;
		}
	}
}
