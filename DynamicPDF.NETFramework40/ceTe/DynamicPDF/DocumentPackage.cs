using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006C3 RID: 1731
	public class DocumentPackage : Resource
	{
		// Token: 0x060042CA RID: 17098 RVA: 0x0022C7C4 File Offset: 0x0022B7C4
		public DocumentPackage()
		{
		}

		// Token: 0x060042CB RID: 17099 RVA: 0x0022C7DD File Offset: 0x0022B7DD
		public DocumentPackage(AttachmentLayout layout)
		{
			this.y = layout;
		}

		// Token: 0x17000353 RID: 851
		// (get) Token: 0x060042CD RID: 17101 RVA: 0x0022C808 File Offset: 0x0022B808
		// (set) Token: 0x060042CC RID: 17100 RVA: 0x0022C7FD File Offset: 0x0022B7FD
		public AttachmentLayout ViewList
		{
			get
			{
				return this.y;
			}
			set
			{
				this.y = value;
			}
		}

		// Token: 0x17000354 RID: 852
		// (get) Token: 0x060042CF RID: 17103 RVA: 0x0022C82C File Offset: 0x0022B82C
		// (set) Token: 0x060042CE RID: 17102 RVA: 0x0022C820 File Offset: 0x0022B820
		public AttachmentListingOrderBy OrderBy
		{
			get
			{
				return this.z;
			}
			set
			{
				this.z = value;
			}
		}

		// Token: 0x17000355 RID: 853
		// (get) Token: 0x060042D1 RID: 17105 RVA: 0x0022C850 File Offset: 0x0022B850
		// (set) Token: 0x060042D0 RID: 17104 RVA: 0x0022C844 File Offset: 0x0022B844
		public bool AscendingOrder
		{
			get
			{
				return this.aa;
			}
			set
			{
				this.aa = value;
			}
		}

		// Token: 0x17000356 RID: 854
		// (get) Token: 0x060042D2 RID: 17106 RVA: 0x0022C868 File Offset: 0x0022B868
		public override int RequiredPdfObjects
		{
			get
			{
				return 7;
			}
		}

		// Token: 0x060042D3 RID: 17107 RVA: 0x0022C87C File Offset: 0x0022B87C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(DocumentPackage.d);
			writer.WriteDictionaryOpen();
			writer.WriteName(DocumentPackage.e);
			switch (this.z)
			{
			case AttachmentListingOrderBy.Index:
				writer.WriteName(DocumentPackage.g);
				break;
			case AttachmentListingOrderBy.Name:
				writer.WriteName(DocumentPackage.a);
				break;
			case AttachmentListingOrderBy.Size:
				writer.WriteName(DocumentPackage.b);
				break;
			case AttachmentListingOrderBy.ModifiedDate:
				writer.WriteName(DocumentPackage.c);
				break;
			default:
				writer.WriteName(DocumentPackage.g);
				break;
			}
			if (!this.aa)
			{
				writer.WriteName(DocumentPackage.f);
				writer.WriteBoolean(false);
			}
			writer.WriteDictionaryClose();
			writer.WriteName(DocumentPackage.h);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(DocumentPackage.i);
			if (this.y == AttachmentLayout.Tile)
			{
				writer.WriteName(DocumentPackage.k);
			}
			else if (this.y == AttachmentLayout.Hidden)
			{
				writer.WriteName(DocumentPackage.l);
			}
			else
			{
				writer.WriteName(DocumentPackage.j);
			}
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			this.f(writer);
		}

		// Token: 0x060042D4 RID: 17108 RVA: 0x0022C9D0 File Offset: 0x0022B9D0
		private new void f(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(DocumentPackage.a);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteName(DocumentPackage.o);
			A_0.WriteReference(A_0.GetObjectNumber(2));
			A_0.WriteName(DocumentPackage.g);
			A_0.WriteReference(A_0.GetObjectNumber(3));
			A_0.WriteName(DocumentPackage.b);
			A_0.WriteReference(A_0.GetObjectNumber(4));
			A_0.WriteName(DocumentPackage.n);
			A_0.WriteReference(A_0.GetObjectNumber(5));
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			this.a(A_0);
			this.b(A_0);
			this.c(A_0);
			this.d(A_0);
			this.e(A_0);
		}

		// Token: 0x060042D5 RID: 17109 RVA: 0x0022CAA4 File Offset: 0x0022BAA4
		private new void e(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.b);
			A_0.WriteName(DocumentPackage.v);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteText(DocumentPackage.n);
			A_0.WriteName(DocumentPackage.q);
			A_0.WriteNumber(3);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x060042D6 RID: 17110 RVA: 0x0022CB14 File Offset: 0x0022BB14
		private new void d(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.b);
			A_0.WriteName(DocumentPackage.x);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteText(DocumentPackage.x);
			A_0.WriteName(DocumentPackage.q);
			A_0.WriteNumber(4);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x060042D7 RID: 17111 RVA: 0x0022CB84 File Offset: 0x0022BB84
		private new void c(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.b);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteName(DocumentPackage.s);
			A_0.WriteBoolean(true);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteText(DocumentPackage.g);
			A_0.WriteName(DocumentPackage.q);
			A_0.WriteNumber0();
			A_0.WriteName(DocumentPackage.w);
			A_0.WriteBoolean(false);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x060042D8 RID: 17112 RVA: 0x0022CC1C File Offset: 0x0022BC1C
		private new void b(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.b);
			A_0.WriteName(DocumentPackage.t);
			A_0.WriteName(DocumentPackage.s);
			A_0.WriteBoolean(true);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteText(DocumentPackage.u);
			A_0.WriteName(DocumentPackage.q);
			A_0.WriteNumber(2);
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x060042D9 RID: 17113 RVA: 0x0022CCA0 File Offset: 0x0022BCA0
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.b);
			A_0.WriteName(DocumentPackage.r);
			A_0.WriteName(DocumentPackage.s);
			A_0.WriteBoolean(true);
			A_0.WriteName(DocumentPackage.p);
			A_0.WriteText(DocumentPackage.a);
			A_0.WriteName(DocumentPackage.q);
			A_0.WriteNumber1();
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x04002529 RID: 9513
		private new static readonly byte[] a = new byte[]
		{
			78,
			97,
			109,
			101
		};

		// Token: 0x0400252A RID: 9514
		private new static readonly byte[] b = new byte[]
		{
			83,
			105,
			122,
			101
		};

		// Token: 0x0400252B RID: 9515
		private new static readonly byte[] c = new byte[]
		{
			77,
			111,
			100,
			105,
			102,
			105,
			101,
			100
		};

		// Token: 0x0400252C RID: 9516
		private new static readonly byte[] d = new byte[]
		{
			83,
			111,
			114,
			116
		};

		// Token: 0x0400252D RID: 9517
		private new static readonly byte[] e = new byte[]
		{
			83
		};

		// Token: 0x0400252E RID: 9518
		private new static readonly byte[] f = new byte[]
		{
			65
		};

		// Token: 0x0400252F RID: 9519
		private new static readonly byte[] g = new byte[]
		{
			73,
			110,
			100,
			101,
			120
		};

		// Token: 0x04002530 RID: 9520
		private new static readonly byte[] h = new byte[]
		{
			83,
			99,
			104,
			101,
			109,
			97
		};

		// Token: 0x04002531 RID: 9521
		private new static readonly byte[] i = new byte[]
		{
			86,
			105,
			101,
			119
		};

		// Token: 0x04002532 RID: 9522
		private static readonly byte[] j = new byte[]
		{
			68
		};

		// Token: 0x04002533 RID: 9523
		private static readonly byte[] k = new byte[]
		{
			84
		};

		// Token: 0x04002534 RID: 9524
		private static readonly byte[] l = new byte[]
		{
			72
		};

		// Token: 0x04002535 RID: 9525
		private static readonly byte[] m = new byte[]
		{
			68
		};

		// Token: 0x04002536 RID: 9526
		private static readonly byte[] n = new byte[]
		{
			77,
			111,
			100,
			105,
			102,
			105,
			101,
			100
		};

		// Token: 0x04002537 RID: 9527
		private static readonly byte[] o = new byte[]
		{
			68,
			101,
			115,
			99,
			114,
			105,
			112,
			116,
			105,
			111,
			110
		};

		// Token: 0x04002538 RID: 9528
		private static readonly byte[] p = new byte[]
		{
			78
		};

		// Token: 0x04002539 RID: 9529
		private static readonly byte[] q = new byte[]
		{
			79
		};

		// Token: 0x0400253A RID: 9530
		private static readonly byte[] r = new byte[]
		{
			70
		};

		// Token: 0x0400253B RID: 9531
		private static readonly byte[] s = new byte[]
		{
			69
		};

		// Token: 0x0400253C RID: 9532
		private static readonly byte[] t = new byte[]
		{
			68,
			101,
			115,
			99
		};

		// Token: 0x0400253D RID: 9533
		private static readonly byte[] u = new byte[]
		{
			68,
			101,
			115,
			99,
			114,
			105,
			112,
			116,
			105,
			111,
			110
		};

		// Token: 0x0400253E RID: 9534
		private static readonly byte[] v = new byte[]
		{
			77,
			111,
			100,
			68,
			97,
			116,
			101
		};

		// Token: 0x0400253F RID: 9535
		private static readonly byte[] w = new byte[]
		{
			86
		};

		// Token: 0x04002540 RID: 9536
		private static readonly byte[] x = new byte[]
		{
			83,
			105,
			122,
			101
		};

		// Token: 0x04002541 RID: 9537
		private AttachmentLayout y;

		// Token: 0x04002542 RID: 9538
		private AttachmentListingOrderBy z = AttachmentListingOrderBy.Index;

		// Token: 0x04002543 RID: 9539
		private bool aa = true;
	}
}
