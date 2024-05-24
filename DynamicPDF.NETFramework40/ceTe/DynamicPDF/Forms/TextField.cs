using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x02000401 RID: 1025
	public abstract class TextField : FormField
	{
		// Token: 0x06002AF8 RID: 11000 RVA: 0x0018E272 File Offset: 0x0018D272
		internal TextField(string A_0, FormFieldAlign A_1, int A_2) : base(A_0, (FormFieldFlags)A_2, null)
		{
			this.a = A_1;
		}

		// Token: 0x06002AF9 RID: 11001 RVA: 0x0018E287 File Offset: 0x0018D287
		internal TextField(string A_0, FormFieldAlign A_1, int A_2, AnnotationReaderEvents A_3) : base(A_0, (FormFieldFlags)A_2, A_3)
		{
			this.a = A_1;
		}

		// Token: 0x170000BF RID: 191
		// (get) Token: 0x06002AFA RID: 11002 RVA: 0x0018E2A0 File Offset: 0x0018D2A0
		public override bool HasValue
		{
			get
			{
				return true;
			}
		}

		// Token: 0x170000C0 RID: 192
		// (get) Token: 0x06002AFB RID: 11003
		public abstract int MaximumLength { get; }

		// Token: 0x06002AFC RID: 11004 RVA: 0x0018E2B4 File Offset: 0x0018D2B4
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (base.Parent == null || !(base.Parent is TextField))
			{
				writer.WriteName(FormField.n);
				writer.WriteName(TextField.b);
			}
			if (base.e() != null)
			{
				base.d(writer);
			}
			base.DrawDictionary(writer);
			if (writer.Document.d().DefaultAlign != this.a)
			{
				writer.WriteName(81);
				writer.WriteNumber((int)this.a);
			}
		}

		// Token: 0x06002AFD RID: 11005
		internal abstract int hk();

		// Token: 0x06002AFE RID: 11006
		internal abstract string hl();

		// Token: 0x06002AFF RID: 11007 RVA: 0x0018E350 File Offset: 0x0018D350
		internal new FormFieldAlign c()
		{
			return this.a;
		}

		// Token: 0x06002B00 RID: 11008 RVA: 0x0018E368 File Offset: 0x0018D368
		internal override bj cc()
		{
			return bj.h;
		}

		// Token: 0x170000C1 RID: 193
		// (get) Token: 0x06002B01 RID: 11009 RVA: 0x0018E37C File Offset: 0x0018D37C
		public Align Align
		{
			get
			{
				Align result;
				switch (this.a)
				{
				case FormFieldAlign.Center:
					result = Align.Center;
					break;
				case FormFieldAlign.Right:
					result = Align.Right;
					break;
				default:
					result = Align.Left;
					break;
				}
				return result;
			}
		}

		// Token: 0x040013C3 RID: 5059
		private new FormFieldAlign a;

		// Token: 0x040013C4 RID: 5060
		private new static byte[] b = new byte[]
		{
			84,
			120
		};
	}
}
