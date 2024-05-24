using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ThankYou.UIData
{
	// Token: 0x02000014 RID: 20
	public class Offer
	{
		// Token: 0x17000026 RID: 38
		// (get) Token: 0x0600009D RID: 157 RVA: 0x000032F4 File Offset: 0x000014F4
		// (set) Token: 0x0600009E RID: 158 RVA: 0x000032FC File Offset: 0x000014FC
		public Offer.ButtonData ButtonContent { get; set; }

		// Token: 0x17000027 RID: 39
		// (get) Token: 0x0600009F RID: 159 RVA: 0x00003305 File Offset: 0x00001505
		// (set) Token: 0x060000A0 RID: 160 RVA: 0x0000330D File Offset: 0x0000150D
		public Offer.PageData PageContent { get; set; }

		// Token: 0x17000028 RID: 40
		// (get) Token: 0x060000A1 RID: 161 RVA: 0x00003316 File Offset: 0x00001516
		// (set) Token: 0x060000A2 RID: 162 RVA: 0x0000331E File Offset: 0x0000151E
		public bool HideFooter { get; set; }

		// Token: 0x02000022 RID: 34
		public class ButtonData
		{
			// Token: 0x1700003C RID: 60
			// (get) Token: 0x060000DF RID: 223 RVA: 0x00004B46 File Offset: 0x00002D46
			// (set) Token: 0x060000E0 RID: 224 RVA: 0x00004B4E File Offset: 0x00002D4E
			public string Title { get; set; }

			// Token: 0x1700003D RID: 61
			// (get) Token: 0x060000E1 RID: 225 RVA: 0x00004B57 File Offset: 0x00002D57
			// (set) Token: 0x060000E2 RID: 226 RVA: 0x00004B5F File Offset: 0x00002D5F
			public string Description { get; set; }

			// Token: 0x1700003E RID: 62
			// (get) Token: 0x060000E3 RID: 227 RVA: 0x00004B68 File Offset: 0x00002D68
			// (set) Token: 0x060000E4 RID: 228 RVA: 0x00004B70 File Offset: 0x00002D70
			public BitmapImage Image { get; set; }
		}

		// Token: 0x02000023 RID: 35
		public class PageData
		{
			// Token: 0x1700003F RID: 63
			// (get) Token: 0x060000E6 RID: 230 RVA: 0x00004B79 File Offset: 0x00002D79
			// (set) Token: 0x060000E7 RID: 231 RVA: 0x00004B81 File Offset: 0x00002D81
			public string HeaderTitle { get; set; }

			// Token: 0x17000040 RID: 64
			// (get) Token: 0x060000E8 RID: 232 RVA: 0x00004B8A File Offset: 0x00002D8A
			// (set) Token: 0x060000E9 RID: 233 RVA: 0x00004B92 File Offset: 0x00002D92
			public string Title { get; set; }

			// Token: 0x17000041 RID: 65
			// (get) Token: 0x060000EA RID: 234 RVA: 0x00004B9B File Offset: 0x00002D9B
			// (set) Token: 0x060000EB RID: 235 RVA: 0x00004BA3 File Offset: 0x00002DA3
			public BitmapImage Image { get; set; }

			// Token: 0x17000042 RID: 66
			// (get) Token: 0x060000EC RID: 236 RVA: 0x00004BAC File Offset: 0x00002DAC
			// (set) Token: 0x060000ED RID: 237 RVA: 0x00004BB4 File Offset: 0x00002DB4
			public string Content1 { get; set; }

			// Token: 0x17000043 RID: 67
			// (get) Token: 0x060000EE RID: 238 RVA: 0x00004BBD File Offset: 0x00002DBD
			// (set) Token: 0x060000EF RID: 239 RVA: 0x00004BC5 File Offset: 0x00002DC5
			public TextAlignment Content1Alignment { get; set; }

			// Token: 0x17000044 RID: 68
			// (get) Token: 0x060000F0 RID: 240 RVA: 0x00004BCE File Offset: 0x00002DCE
			// (set) Token: 0x060000F1 RID: 241 RVA: 0x00004BD6 File Offset: 0x00002DD6
			public BitmapImage Content1Image { get; set; }

			// Token: 0x17000045 RID: 69
			// (get) Token: 0x060000F2 RID: 242 RVA: 0x00004BDF File Offset: 0x00002DDF
			// (set) Token: 0x060000F3 RID: 243 RVA: 0x00004BE7 File Offset: 0x00002DE7
			public string ContentButton1Text { get; set; }

			// Token: 0x17000046 RID: 70
			// (get) Token: 0x060000F4 RID: 244 RVA: 0x00004BF0 File Offset: 0x00002DF0
			// (set) Token: 0x060000F5 RID: 245 RVA: 0x00004BF8 File Offset: 0x00002DF8
			public string ContentButton1Url { get; set; }

			// Token: 0x17000047 RID: 71
			// (get) Token: 0x060000F6 RID: 246 RVA: 0x00004C01 File Offset: 0x00002E01
			// (set) Token: 0x060000F7 RID: 247 RVA: 0x00004C09 File Offset: 0x00002E09
			public string Content2 { get; set; }

			// Token: 0x17000048 RID: 72
			// (get) Token: 0x060000F8 RID: 248 RVA: 0x00004C12 File Offset: 0x00002E12
			// (set) Token: 0x060000F9 RID: 249 RVA: 0x00004C1A File Offset: 0x00002E1A
			public TextAlignment Content2Alignment { get; set; }

			// Token: 0x17000049 RID: 73
			// (get) Token: 0x060000FA RID: 250 RVA: 0x00004C23 File Offset: 0x00002E23
			// (set) Token: 0x060000FB RID: 251 RVA: 0x00004C2B File Offset: 0x00002E2B
			public BitmapImage Content2Image { get; set; }

			// Token: 0x1700004A RID: 74
			// (get) Token: 0x060000FC RID: 252 RVA: 0x00004C34 File Offset: 0x00002E34
			// (set) Token: 0x060000FD RID: 253 RVA: 0x00004C3C File Offset: 0x00002E3C
			public string ContentButton2Text { get; set; }

			// Token: 0x1700004B RID: 75
			// (get) Token: 0x060000FE RID: 254 RVA: 0x00004C45 File Offset: 0x00002E45
			// (set) Token: 0x060000FF RID: 255 RVA: 0x00004C4D File Offset: 0x00002E4D
			public string ContentButton2Url { get; set; }

			// Token: 0x1700004C RID: 76
			// (get) Token: 0x06000100 RID: 256 RVA: 0x00004C56 File Offset: 0x00002E56
			// (set) Token: 0x06000101 RID: 257 RVA: 0x00004C5E File Offset: 0x00002E5E
			public string Content3 { get; set; }

			// Token: 0x1700004D RID: 77
			// (get) Token: 0x06000102 RID: 258 RVA: 0x00004C67 File Offset: 0x00002E67
			// (set) Token: 0x06000103 RID: 259 RVA: 0x00004C6F File Offset: 0x00002E6F
			public TextAlignment Content3Alignment { get; set; }

			// Token: 0x1700004E RID: 78
			// (get) Token: 0x06000104 RID: 260 RVA: 0x00004C78 File Offset: 0x00002E78
			// (set) Token: 0x06000105 RID: 261 RVA: 0x00004C80 File Offset: 0x00002E80
			public BitmapImage Content3Image { get; set; }

			// Token: 0x1700004F RID: 79
			// (get) Token: 0x06000106 RID: 262 RVA: 0x00004C89 File Offset: 0x00002E89
			// (set) Token: 0x06000107 RID: 263 RVA: 0x00004C91 File Offset: 0x00002E91
			public string ContentButton3Text { get; set; }

			// Token: 0x17000050 RID: 80
			// (get) Token: 0x06000108 RID: 264 RVA: 0x00004C9A File Offset: 0x00002E9A
			// (set) Token: 0x06000109 RID: 265 RVA: 0x00004CA2 File Offset: 0x00002EA2
			public string ContentButton3Url { get; set; }

			// Token: 0x17000051 RID: 81
			// (get) Token: 0x0600010A RID: 266 RVA: 0x00004CAB File Offset: 0x00002EAB
			// (set) Token: 0x0600010B RID: 267 RVA: 0x00004CB3 File Offset: 0x00002EB3
			public string ContentURL { get; set; }

			// Token: 0x17000052 RID: 82
			// (get) Token: 0x0600010C RID: 268 RVA: 0x00004CBC File Offset: 0x00002EBC
			// (set) Token: 0x0600010D RID: 269 RVA: 0x00004CC4 File Offset: 0x00002EC4
			public BitmapImage BottomImage { get; set; }

			// Token: 0x17000053 RID: 83
			// (get) Token: 0x0600010E RID: 270 RVA: 0x00004CCD File Offset: 0x00002ECD
			// (set) Token: 0x0600010F RID: 271 RVA: 0x00004CD5 File Offset: 0x00002ED5
			public string InfoButtonText { get; set; }

			// Token: 0x17000054 RID: 84
			// (get) Token: 0x06000110 RID: 272 RVA: 0x00004CDE File Offset: 0x00002EDE
			// (set) Token: 0x06000111 RID: 273 RVA: 0x00004CE6 File Offset: 0x00002EE6
			public string BackButtonText { get; set; }
		}
	}
}
