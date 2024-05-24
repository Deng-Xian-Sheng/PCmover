using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200063D RID: 1597
	public class Artifact : Tag
	{
		// Token: 0x06003BED RID: 15341 RVA: 0x001FD4D3 File Offset: 0x001FC4D3
		public Artifact()
		{
		}

		// Token: 0x06003BEE RID: 15342 RVA: 0x001FD4FF File Offset: 0x001FC4FF
		public Artifact(BoundingBox bBox)
		{
			this.k = bBox;
		}

		// Token: 0x06003BEF RID: 15343 RVA: 0x001FD532 File Offset: 0x001FC532
		public Artifact(ArtifactType type, Attached attached)
		{
			this.j = type;
			this.l = attached;
		}

		// Token: 0x06003BF0 RID: 15344 RVA: 0x001FD56C File Offset: 0x001FC56C
		public Artifact(ArtifactType type, SubType subType)
		{
			this.j = type;
			this.m = subType;
		}

		// Token: 0x06003BF1 RID: 15345 RVA: 0x001FD5A8 File Offset: 0x001FC5A8
		public Artifact(ArtifactType type, Attached attached, SubType subType)
		{
			this.j = type;
			this.l = attached;
			this.m = subType;
		}

		// Token: 0x06003BF2 RID: 15346 RVA: 0x001FD5F4 File Offset: 0x001FC5F4
		public Artifact(ArtifactType type, BoundingBox bBox, Attached attached, SubType subType)
		{
			this.j = type;
			this.k = bBox;
			this.l = attached;
			this.m = subType;
		}

		// Token: 0x06003BF3 RID: 15347 RVA: 0x001FD648 File Offset: 0x001FC648
		public void SetType(ArtifactType type)
		{
			this.j = type;
		}

		// Token: 0x06003BF4 RID: 15348 RVA: 0x001FD652 File Offset: 0x001FC652
		public void SetBoundingBox(BoundingBox boundingBox)
		{
			this.k = boundingBox;
		}

		// Token: 0x06003BF5 RID: 15349 RVA: 0x001FD65C File Offset: 0x001FC65C
		public void SetBoundingBox()
		{
			this.k = new BoundingBox();
		}

		// Token: 0x06003BF6 RID: 15350 RVA: 0x001FD66A File Offset: 0x001FC66A
		public void SetAttached(Attached attached)
		{
			this.l = attached;
		}

		// Token: 0x06003BF7 RID: 15351 RVA: 0x001FD674 File Offset: 0x001FC674
		public void SetSubType(SubType subType)
		{
			this.m = subType;
		}

		// Token: 0x1700012D RID: 301
		// (get) Token: 0x06003BF8 RID: 15352 RVA: 0x001FD680 File Offset: 0x001FC680
		public override TagType TagType
		{
			get
			{
				return TagType.a();
			}
		}

		// Token: 0x06003BF9 RID: 15353 RVA: 0x001FD697 File Offset: 0x001FC697
		internal override void e(PageWriter A_0, TaggablePageElement A_1)
		{
			this.a(A_0, A_1, null, null);
		}

		// Token: 0x06003BFA RID: 15354 RVA: 0x001FD6A8 File Offset: 0x001FC6A8
		internal new void a(PageWriter A_0, TaggablePageElement A_1, Row A_2, acx A_3)
		{
			if (this.k != null || this.j != ArtifactType.None || this.m != SubType.None || (this.l.a() || this.l.d() || this.l.c()) || this.l.b())
			{
				A_0.WriteName(Artifact.a);
				A_0.ac();
				if (this.j != ArtifactType.None)
				{
					A_0.WriteName(Resource.a);
					switch (this.j)
					{
					case ArtifactType.Pagination:
						A_0.WriteName(Artifact.c);
						break;
					case ArtifactType.Layout:
						A_0.WriteName(Artifact.d);
						break;
					case ArtifactType.Page:
						A_0.WriteName(Artifact.e);
						break;
					case ArtifactType.Background:
						A_0.WriteName(Artifact.f);
						break;
					}
				}
				if (this.k != null)
				{
					this.k.a(A_0, A_1, A_2, A_3);
				}
				this.l.a(A_0);
				if (this.m != SubType.None)
				{
					A_0.WriteName(Artifact.b);
					switch (this.m)
					{
					case SubType.Header:
						A_0.WriteName(Artifact.g);
						break;
					case SubType.Footer:
						A_0.WriteName(Artifact.h);
						break;
					case SubType.Watermark:
						A_0.WriteName(Artifact.i);
						break;
					}
				}
				A_0.af();
				A_0.aa();
			}
			else
			{
				Artifact.a(A_0);
			}
		}

		// Token: 0x06003BFB RID: 15355 RVA: 0x001FD840 File Offset: 0x001FC840
		internal new void a(PageWriter A_0, TaggablePageElement A_1, Row2 A_2, q0 A_3, bool A_4)
		{
			if (this.k != null || this.j != ArtifactType.None || this.m != SubType.None || (this.l.a() || this.l.d() || this.l.c()) || this.l.b())
			{
				A_0.WriteName(Artifact.a);
				A_0.ac();
				if (this.j != ArtifactType.None)
				{
					A_0.WriteName(Resource.a);
					switch (this.j)
					{
					case ArtifactType.Pagination:
						A_0.WriteName(Artifact.c);
						break;
					case ArtifactType.Layout:
						A_0.WriteName(Artifact.d);
						break;
					case ArtifactType.Page:
						A_0.WriteName(Artifact.e);
						break;
					case ArtifactType.Background:
						A_0.WriteName(Artifact.f);
						break;
					}
				}
				if (this.k != null)
				{
					this.k.a(A_0, A_1, A_2, A_3);
				}
				this.l.a(A_0);
				if (this.m != SubType.None)
				{
					A_0.WriteName(Artifact.b);
					switch (this.m)
					{
					case SubType.Header:
						A_0.WriteName(Artifact.g);
						break;
					case SubType.Footer:
						A_0.WriteName(Artifact.h);
						break;
					case SubType.Watermark:
						A_0.WriteName(Artifact.i);
						break;
					}
				}
				A_0.af();
				A_0.aa();
			}
			else
			{
				Artifact.a(A_0);
			}
		}

		// Token: 0x06003BFC RID: 15356 RVA: 0x001FD9D7 File Offset: 0x001FC9D7
		internal new static void a(PageWriter A_0)
		{
			A_0.WriteName(Artifact.a);
			A_0.WriteSpace();
			A_0.ab();
		}

		// Token: 0x06003BFD RID: 15357 RVA: 0x001FD9F4 File Offset: 0x001FC9F4
		internal override void f(PageWriter A_0, ListItem A_1, float A_2, float A_3)
		{
			Artifact.a(A_0);
		}

		// Token: 0x06003BFE RID: 15358 RVA: 0x001FDA00 File Offset: 0x001FCA00
		internal override bool g()
		{
			return false;
		}

		// Token: 0x06003BFF RID: 15359 RVA: 0x001FDA14 File Offset: 0x001FCA14
		internal override Tag h()
		{
			Artifact artifact = new Artifact();
			artifact.l = this.l;
			artifact.m = this.m;
			artifact.j = this.j;
			BoundingBox boundingBox = new BoundingBox();
			if (this.k != null)
			{
				boundingBox.a(this.k.a());
			}
			else
			{
				boundingBox = null;
			}
			artifact.k = boundingBox;
			return artifact;
		}

		// Token: 0x06003C00 RID: 15360 RVA: 0x001FDA83 File Offset: 0x001FCA83
		public override void Draw(DocumentWriter writer)
		{
		}

		// Token: 0x040020A7 RID: 8359
		private new static byte[] a = new byte[]
		{
			65,
			114,
			116,
			105,
			102,
			97,
			99,
			116
		};

		// Token: 0x040020A8 RID: 8360
		private new static byte[] b = new byte[]
		{
			83,
			117,
			98,
			116,
			121,
			112,
			101
		};

		// Token: 0x040020A9 RID: 8361
		private new static byte[] c = new byte[]
		{
			80,
			97,
			103,
			105,
			110,
			97,
			116,
			105,
			111,
			110
		};

		// Token: 0x040020AA RID: 8362
		private new static byte[] d = new byte[]
		{
			76,
			97,
			121,
			111,
			117,
			116
		};

		// Token: 0x040020AB RID: 8363
		private new static byte[] e = new byte[]
		{
			80,
			97,
			103,
			101
		};

		// Token: 0x040020AC RID: 8364
		private new static byte[] f = new byte[]
		{
			66,
			97,
			99,
			107,
			103,
			114,
			111,
			117,
			110,
			100
		};

		// Token: 0x040020AD RID: 8365
		private new static byte[] g = new byte[]
		{
			72,
			101,
			97,
			100,
			101,
			114
		};

		// Token: 0x040020AE RID: 8366
		private new static byte[] h = new byte[]
		{
			70,
			111,
			111,
			116,
			101,
			114
		};

		// Token: 0x040020AF RID: 8367
		private new static byte[] i = new byte[]
		{
			87,
			97,
			116,
			101,
			114,
			109,
			97,
			114,
			107
		};

		// Token: 0x040020B0 RID: 8368
		private ArtifactType j = ArtifactType.None;

		// Token: 0x040020B1 RID: 8369
		private BoundingBox k = null;

		// Token: 0x040020B2 RID: 8370
		private Attached l = default(Attached);

		// Token: 0x040020B3 RID: 8371
		private SubType m = SubType.None;
	}
}
