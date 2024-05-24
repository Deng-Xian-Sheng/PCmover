using System;

namespace CefSharp
{
	// Token: 0x0200008A RID: 138
	public sealed class PdfPrintSettings
	{
		// Token: 0x1700014E RID: 334
		// (get) Token: 0x060003CC RID: 972 RVA: 0x00003A74 File Offset: 0x00001C74
		// (set) Token: 0x060003CD RID: 973 RVA: 0x00003A7C File Offset: 0x00001C7C
		public string HeaderFooterTitle { get; set; }

		// Token: 0x1700014F RID: 335
		// (get) Token: 0x060003CE RID: 974 RVA: 0x00003A85 File Offset: 0x00001C85
		// (set) Token: 0x060003CF RID: 975 RVA: 0x00003A8D File Offset: 0x00001C8D
		public string HeaderFooterUrl { get; set; }

		// Token: 0x17000150 RID: 336
		// (get) Token: 0x060003D0 RID: 976 RVA: 0x00003A96 File Offset: 0x00001C96
		// (set) Token: 0x060003D1 RID: 977 RVA: 0x00003A9E File Offset: 0x00001C9E
		public int PageWidth { get; set; }

		// Token: 0x17000151 RID: 337
		// (get) Token: 0x060003D2 RID: 978 RVA: 0x00003AA7 File Offset: 0x00001CA7
		// (set) Token: 0x060003D3 RID: 979 RVA: 0x00003AAF File Offset: 0x00001CAF
		public int PageHeight { get; set; }

		// Token: 0x17000152 RID: 338
		// (get) Token: 0x060003D4 RID: 980 RVA: 0x00003AB8 File Offset: 0x00001CB8
		// (set) Token: 0x060003D5 RID: 981 RVA: 0x00003AC0 File Offset: 0x00001CC0
		public int MarginLeft { get; set; }

		// Token: 0x17000153 RID: 339
		// (get) Token: 0x060003D6 RID: 982 RVA: 0x00003AC9 File Offset: 0x00001CC9
		// (set) Token: 0x060003D7 RID: 983 RVA: 0x00003AD1 File Offset: 0x00001CD1
		public int MarginTop { get; set; }

		// Token: 0x17000154 RID: 340
		// (get) Token: 0x060003D8 RID: 984 RVA: 0x00003ADA File Offset: 0x00001CDA
		// (set) Token: 0x060003D9 RID: 985 RVA: 0x00003AE2 File Offset: 0x00001CE2
		public int MarginRight { get; set; }

		// Token: 0x17000155 RID: 341
		// (get) Token: 0x060003DA RID: 986 RVA: 0x00003AEB File Offset: 0x00001CEB
		// (set) Token: 0x060003DB RID: 987 RVA: 0x00003AF3 File Offset: 0x00001CF3
		public int MarginBottom { get; set; }

		// Token: 0x17000156 RID: 342
		// (get) Token: 0x060003DC RID: 988 RVA: 0x00003AFC File Offset: 0x00001CFC
		// (set) Token: 0x060003DD RID: 989 RVA: 0x00003B04 File Offset: 0x00001D04
		public CefPdfPrintMarginType MarginType { get; set; }

		// Token: 0x17000157 RID: 343
		// (get) Token: 0x060003DE RID: 990 RVA: 0x00003B0D File Offset: 0x00001D0D
		// (set) Token: 0x060003DF RID: 991 RVA: 0x00003B15 File Offset: 0x00001D15
		public int ScaleFactor { get; set; }

		// Token: 0x17000158 RID: 344
		// (get) Token: 0x060003E0 RID: 992 RVA: 0x00003B1E File Offset: 0x00001D1E
		// (set) Token: 0x060003E1 RID: 993 RVA: 0x00003B26 File Offset: 0x00001D26
		public bool HeaderFooterEnabled { get; set; }

		// Token: 0x17000159 RID: 345
		// (get) Token: 0x060003E2 RID: 994 RVA: 0x00003B2F File Offset: 0x00001D2F
		// (set) Token: 0x060003E3 RID: 995 RVA: 0x00003B37 File Offset: 0x00001D37
		public bool SelectionOnly { get; set; }

		// Token: 0x1700015A RID: 346
		// (get) Token: 0x060003E4 RID: 996 RVA: 0x00003B40 File Offset: 0x00001D40
		// (set) Token: 0x060003E5 RID: 997 RVA: 0x00003B48 File Offset: 0x00001D48
		public bool Landscape { get; set; }

		// Token: 0x1700015B RID: 347
		// (get) Token: 0x060003E6 RID: 998 RVA: 0x00003B51 File Offset: 0x00001D51
		// (set) Token: 0x060003E7 RID: 999 RVA: 0x00003B59 File Offset: 0x00001D59
		public bool BackgroundsEnabled { get; set; }
	}
}
