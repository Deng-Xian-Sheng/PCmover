using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063C RID: 1596
	public abstract class Tag : Resource
	{
		// Token: 0x06003BB9 RID: 15289 RVA: 0x001FCFC0 File Offset: 0x001FBFC0
		internal new virtual void e(PageWriter A_0, TaggablePageElement A_1)
		{
		}

		// Token: 0x06003BBA RID: 15290 RVA: 0x001FCFC3 File Offset: 0x001FBFC3
		internal new virtual void f(PageWriter A_0, ListItem A_1, float A_2, float A_3)
		{
		}

		// Token: 0x06003BBB RID: 15291 RVA: 0x001FCFC6 File Offset: 0x001FBFC6
		internal new static void a(PageWriter A_0)
		{
			A_0.z();
		}

		// Token: 0x170000FF RID: 255
		// (get) Token: 0x06003BBC RID: 15292
		public abstract TagType TagType { get; }

		// Token: 0x06003BBD RID: 15293 RVA: 0x001FCFD0 File Offset: 0x001FBFD0
		internal new virtual bool g()
		{
			return true;
		}

		// Token: 0x06003BBE RID: 15294
		internal new abstract Tag h();

		// Token: 0x17000100 RID: 256
		// (get) Token: 0x06003BBF RID: 15295 RVA: 0x001FCFE4 File Offset: 0x001FBFE4
		public static StructureElement Annotation
		{
			get
			{
				return new StructureElement(TagType.Annotation);
			}
		}

		// Token: 0x17000101 RID: 257
		// (get) Token: 0x06003BC0 RID: 15296 RVA: 0x001FD000 File Offset: 0x001FC000
		public static StructureElement Article
		{
			get
			{
				return new StructureElement(TagType.Article);
			}
		}

		// Token: 0x17000102 RID: 258
		// (get) Token: 0x06003BC1 RID: 15297 RVA: 0x001FD01C File Offset: 0x001FC01C
		public static StructureElement BibliographyEntry
		{
			get
			{
				return new StructureElement(TagType.BibliographyEntry);
			}
		}

		// Token: 0x17000103 RID: 259
		// (get) Token: 0x06003BC2 RID: 15298 RVA: 0x001FD038 File Offset: 0x001FC038
		public static StructureElement BlockQuotation
		{
			get
			{
				return new StructureElement(TagType.BlockQuotation);
			}
		}

		// Token: 0x17000104 RID: 260
		// (get) Token: 0x06003BC3 RID: 15299 RVA: 0x001FD054 File Offset: 0x001FC054
		public static StructureElement Caption
		{
			get
			{
				return new StructureElement(TagType.Caption);
			}
		}

		// Token: 0x17000105 RID: 261
		// (get) Token: 0x06003BC4 RID: 15300 RVA: 0x001FD070 File Offset: 0x001FC070
		public static StructureElement Code
		{
			get
			{
				return new StructureElement(TagType.Code);
			}
		}

		// Token: 0x17000106 RID: 262
		// (get) Token: 0x06003BC5 RID: 15301 RVA: 0x001FD08C File Offset: 0x001FC08C
		public static StructureElement Division
		{
			get
			{
				return new StructureElement(TagType.Division);
			}
		}

		// Token: 0x17000107 RID: 263
		// (get) Token: 0x06003BC6 RID: 15302 RVA: 0x001FD0A8 File Offset: 0x001FC0A8
		public static StructureElement Document
		{
			get
			{
				return new StructureElement(TagType.Document);
			}
		}

		// Token: 0x17000108 RID: 264
		// (get) Token: 0x06003BC7 RID: 15303 RVA: 0x001FD0C4 File Offset: 0x001FC0C4
		public static StructureElement Figure
		{
			get
			{
				return new StructureElement(TagType.Figure);
			}
		}

		// Token: 0x17000109 RID: 265
		// (get) Token: 0x06003BC8 RID: 15304 RVA: 0x001FD0E0 File Offset: 0x001FC0E0
		public static StructureElement Form
		{
			get
			{
				return new StructureElement(TagType.Form);
			}
		}

		// Token: 0x1700010A RID: 266
		// (get) Token: 0x06003BC9 RID: 15305 RVA: 0x001FD0FC File Offset: 0x001FC0FC
		public static StructureElement Formula
		{
			get
			{
				return new StructureElement(TagType.Formula);
			}
		}

		// Token: 0x1700010B RID: 267
		// (get) Token: 0x06003BCA RID: 15306 RVA: 0x001FD118 File Offset: 0x001FC118
		public static StructureElement Heading
		{
			get
			{
				return new StructureElement(TagType.Heading);
			}
		}

		// Token: 0x1700010C RID: 268
		// (get) Token: 0x06003BCB RID: 15307 RVA: 0x001FD134 File Offset: 0x001FC134
		public static StructureElement HeadingLevel1
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel1);
			}
		}

		// Token: 0x1700010D RID: 269
		// (get) Token: 0x06003BCC RID: 15308 RVA: 0x001FD150 File Offset: 0x001FC150
		public static StructureElement HeadingLevel2
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel2);
			}
		}

		// Token: 0x1700010E RID: 270
		// (get) Token: 0x06003BCD RID: 15309 RVA: 0x001FD16C File Offset: 0x001FC16C
		public static StructureElement HeadingLevel3
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel3);
			}
		}

		// Token: 0x1700010F RID: 271
		// (get) Token: 0x06003BCE RID: 15310 RVA: 0x001FD188 File Offset: 0x001FC188
		public static StructureElement HeadingLevel4
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel4);
			}
		}

		// Token: 0x17000110 RID: 272
		// (get) Token: 0x06003BCF RID: 15311 RVA: 0x001FD1A4 File Offset: 0x001FC1A4
		public static StructureElement HeadingLevel5
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel5);
			}
		}

		// Token: 0x17000111 RID: 273
		// (get) Token: 0x06003BD0 RID: 15312 RVA: 0x001FD1C0 File Offset: 0x001FC1C0
		public static StructureElement HeadingLevel6
		{
			get
			{
				return new StructureElement(TagType.HeadingLevel6);
			}
		}

		// Token: 0x17000112 RID: 274
		// (get) Token: 0x06003BD1 RID: 15313 RVA: 0x001FD1DC File Offset: 0x001FC1DC
		public static StructureElement Index
		{
			get
			{
				return new StructureElement(TagType.Index);
			}
		}

		// Token: 0x17000113 RID: 275
		// (get) Token: 0x06003BD2 RID: 15314 RVA: 0x001FD1F8 File Offset: 0x001FC1F8
		public static StructureElement List
		{
			get
			{
				return new StructureElement(TagType.List);
			}
		}

		// Token: 0x17000114 RID: 276
		// (get) Token: 0x06003BD3 RID: 15315 RVA: 0x001FD214 File Offset: 0x001FC214
		public static StructureElement Label
		{
			get
			{
				return new StructureElement(TagType.Label);
			}
		}

		// Token: 0x17000115 RID: 277
		// (get) Token: 0x06003BD4 RID: 15316 RVA: 0x001FD230 File Offset: 0x001FC230
		public static StructureElement ListBody
		{
			get
			{
				return new StructureElement(TagType.ListBody);
			}
		}

		// Token: 0x17000116 RID: 278
		// (get) Token: 0x06003BD5 RID: 15317 RVA: 0x001FD24C File Offset: 0x001FC24C
		public static StructureElement ListItem
		{
			get
			{
				return new StructureElement(TagType.ListItem);
			}
		}

		// Token: 0x17000117 RID: 279
		// (get) Token: 0x06003BD6 RID: 15318 RVA: 0x001FD268 File Offset: 0x001FC268
		public static StructureElement Link
		{
			get
			{
				return new StructureElement(TagType.Link);
			}
		}

		// Token: 0x17000118 RID: 280
		// (get) Token: 0x06003BD7 RID: 15319 RVA: 0x001FD284 File Offset: 0x001FC284
		public static StructureElement NonStructuralElement
		{
			get
			{
				return new StructureElement(TagType.NonStructuralElement);
			}
		}

		// Token: 0x17000119 RID: 281
		// (get) Token: 0x06003BD8 RID: 15320 RVA: 0x001FD2A0 File Offset: 0x001FC2A0
		public static StructureElement Note
		{
			get
			{
				return new StructureElement(TagType.Note);
			}
		}

		// Token: 0x1700011A RID: 282
		// (get) Token: 0x06003BD9 RID: 15321 RVA: 0x001FD2BC File Offset: 0x001FC2BC
		public static StructureElement Paragraph
		{
			get
			{
				return new StructureElement(TagType.Paragraph);
			}
		}

		// Token: 0x1700011B RID: 283
		// (get) Token: 0x06003BDA RID: 15322 RVA: 0x001FD2D8 File Offset: 0x001FC2D8
		public static StructureElement Part
		{
			get
			{
				return new StructureElement(TagType.Part);
			}
		}

		// Token: 0x1700011C RID: 284
		// (get) Token: 0x06003BDB RID: 15323 RVA: 0x001FD2F4 File Offset: 0x001FC2F4
		public static StructureElement Private
		{
			get
			{
				return new StructureElement(TagType.Private);
			}
		}

		// Token: 0x1700011D RID: 285
		// (get) Token: 0x06003BDC RID: 15324 RVA: 0x001FD310 File Offset: 0x001FC310
		public static StructureElement Quotation
		{
			get
			{
				return new StructureElement(TagType.Quotation);
			}
		}

		// Token: 0x1700011E RID: 286
		// (get) Token: 0x06003BDD RID: 15325 RVA: 0x001FD32C File Offset: 0x001FC32C
		public static StructureElement Reference
		{
			get
			{
				return new StructureElement(TagType.Reference);
			}
		}

		// Token: 0x1700011F RID: 287
		// (get) Token: 0x06003BDE RID: 15326 RVA: 0x001FD348 File Offset: 0x001FC348
		public static StructureElement Ruby
		{
			get
			{
				return new StructureElement(TagType.Ruby);
			}
		}

		// Token: 0x17000120 RID: 288
		// (get) Token: 0x06003BDF RID: 15327 RVA: 0x001FD364 File Offset: 0x001FC364
		public static StructureElement Section
		{
			get
			{
				return new StructureElement(TagType.Section);
			}
		}

		// Token: 0x17000121 RID: 289
		// (get) Token: 0x06003BE0 RID: 15328 RVA: 0x001FD380 File Offset: 0x001FC380
		public static StructureElement Span
		{
			get
			{
				return new StructureElement(TagType.Span);
			}
		}

		// Token: 0x17000122 RID: 290
		// (get) Token: 0x06003BE1 RID: 15329 RVA: 0x001FD39C File Offset: 0x001FC39C
		public static StructureElement Table
		{
			get
			{
				return new StructureElement(TagType.Table);
			}
		}

		// Token: 0x17000123 RID: 291
		// (get) Token: 0x06003BE2 RID: 15330 RVA: 0x001FD3B8 File Offset: 0x001FC3B8
		public static StructureElement TableBodyRowGroup
		{
			get
			{
				return new StructureElement(TagType.TableBodyRowGroup);
			}
		}

		// Token: 0x17000124 RID: 292
		// (get) Token: 0x06003BE3 RID: 15331 RVA: 0x001FD3D4 File Offset: 0x001FC3D4
		public static StructureElement TableDataCell
		{
			get
			{
				return new StructureElement(TagType.TableDataCell);
			}
		}

		// Token: 0x17000125 RID: 293
		// (get) Token: 0x06003BE4 RID: 15332 RVA: 0x001FD3F0 File Offset: 0x001FC3F0
		public static StructureElement TableFooterRowGroup
		{
			get
			{
				return new StructureElement(TagType.TableFooterRowGroup);
			}
		}

		// Token: 0x17000126 RID: 294
		// (get) Token: 0x06003BE5 RID: 15333 RVA: 0x001FD40C File Offset: 0x001FC40C
		public static StructureElement TableHeader
		{
			get
			{
				return new StructureElement(TagType.TableHeader);
			}
		}

		// Token: 0x17000127 RID: 295
		// (get) Token: 0x06003BE6 RID: 15334 RVA: 0x001FD428 File Offset: 0x001FC428
		public static StructureElement TableHeaderRowGroup
		{
			get
			{
				return new StructureElement(TagType.TableHeaderRowGroup);
			}
		}

		// Token: 0x17000128 RID: 296
		// (get) Token: 0x06003BE7 RID: 15335 RVA: 0x001FD444 File Offset: 0x001FC444
		public static StructureElement TableOfContent
		{
			get
			{
				return new StructureElement(TagType.TableOfContent);
			}
		}

		// Token: 0x17000129 RID: 297
		// (get) Token: 0x06003BE8 RID: 15336 RVA: 0x001FD460 File Offset: 0x001FC460
		public static StructureElement TableOfContentItem
		{
			get
			{
				return new StructureElement(TagType.TableOfContentItem);
			}
		}

		// Token: 0x1700012A RID: 298
		// (get) Token: 0x06003BE9 RID: 15337 RVA: 0x001FD47C File Offset: 0x001FC47C
		public static StructureElement TableRow
		{
			get
			{
				return new StructureElement(TagType.TableRow);
			}
		}

		// Token: 0x1700012B RID: 299
		// (get) Token: 0x06003BEA RID: 15338 RVA: 0x001FD498 File Offset: 0x001FC498
		public static StructureElement Warichu
		{
			get
			{
				return new StructureElement(TagType.Warichu);
			}
		}

		// Token: 0x1700012C RID: 300
		// (get) Token: 0x06003BEB RID: 15339 RVA: 0x001FD4B4 File Offset: 0x001FC4B4
		public static Artifact Artifact
		{
			get
			{
				return new Artifact();
			}
		}
	}
}
