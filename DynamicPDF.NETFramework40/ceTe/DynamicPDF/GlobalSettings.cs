using System;
using System.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006BE RID: 1726
	public sealed class GlobalSettings
	{
		// Token: 0x06004299 RID: 17049 RVA: 0x0022B865 File Offset: 0x0022A865
		private GlobalSettings()
		{
		}

		// Token: 0x0600429A RID: 17050 RVA: 0x0022B870 File Offset: 0x0022A870
		static GlobalSettings()
		{
			try
			{
				string environmentVariable = Environment.GetEnvironmentVariable("WINDIR");
				if (environmentVariable != null && environmentVariable.Length > 0)
				{
					GlobalSettings.d = Path.Combine(environmentVariable, "Fonts");
				}
			}
			catch (Exception)
			{
			}
		}

		// Token: 0x17000346 RID: 838
		// (get) Token: 0x0600429B RID: 17051 RVA: 0x0022B8F0 File Offset: 0x0022A8F0
		// (set) Token: 0x0600429C RID: 17052 RVA: 0x0022B907 File Offset: 0x0022A907
		public static bool UseLegacyTextHeightCalculations
		{
			get
			{
				return GlobalSettings.a;
			}
			set
			{
				GlobalSettings.a = value;
			}
		}

		// Token: 0x17000347 RID: 839
		// (get) Token: 0x0600429D RID: 17053 RVA: 0x0022B910 File Offset: 0x0022A910
		// (set) Token: 0x0600429E RID: 17054 RVA: 0x0022B927 File Offset: 0x0022A927
		public static PdfVersion DefaultOutputPdfVersion
		{
			get
			{
				return GlobalSettings.b;
			}
			set
			{
				GlobalSettings.b = value;
			}
		}

		// Token: 0x17000348 RID: 840
		// (get) Token: 0x0600429F RID: 17055 RVA: 0x0022B930 File Offset: 0x0022A930
		// (set) Token: 0x060042A0 RID: 17056 RVA: 0x0022B947 File Offset: 0x0022A947
		public static PdfFormat DefaultOutputPdfFormat
		{
			get
			{
				return GlobalSettings.c;
			}
			set
			{
				GlobalSettings.c = value;
			}
		}

		// Token: 0x17000349 RID: 841
		// (get) Token: 0x060042A1 RID: 17057 RVA: 0x0022B950 File Offset: 0x0022A950
		// (set) Token: 0x060042A2 RID: 17058 RVA: 0x0022B967 File Offset: 0x0022A967
		public static string PathToFontsResourceDirectory
		{
			get
			{
				return GlobalSettings.d;
			}
			set
			{
				GlobalSettings.d = value;
			}
		}

		// Token: 0x060042A3 RID: 17059 RVA: 0x0022B970 File Offset: 0x0022A970
		internal static bool a()
		{
			return GlobalSettings.e;
		}

		// Token: 0x0400250C RID: 9484
		private static bool a = false;

		// Token: 0x0400250D RID: 9485
		private static PdfVersion b = PdfVersion.v1_4;

		// Token: 0x0400250E RID: 9486
		private static PdfFormat c = PdfFormat.SinglePass;

		// Token: 0x0400250F RID: 9487
		private static string d = "";

		// Token: 0x04002510 RID: 9488
		private static bool e = true;
	}
}
