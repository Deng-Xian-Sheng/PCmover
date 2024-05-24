using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF
{
	// Token: 0x0200069F RID: 1695
	public class JavaScriptResource : Resource
	{
		// Token: 0x06004065 RID: 16485 RVA: 0x00221885 File Offset: 0x00220885
		internal JavaScriptResource(JavaScriptAction A_0)
		{
			this.e = A_0.NextAction;
			this.d = A_0.a();
		}

		// Token: 0x06004066 RID: 16486 RVA: 0x002218A8 File Offset: 0x002208A8
		internal JavaScriptResource(string A_0)
		{
			this.d = A_0;
		}

		// Token: 0x17000269 RID: 617
		// (get) Token: 0x06004067 RID: 16487 RVA: 0x002218BC File Offset: 0x002208BC
		public override int RequiredPdfObjects
		{
			get
			{
				int result;
				if (this.d.Length > 210)
				{
					result = 2;
				}
				else
				{
					result = 1;
				}
				return result;
			}
		}

		// Token: 0x06004068 RID: 16488 RVA: 0x002218EC File Offset: 0x002208EC
		public override void Draw(DocumentWriter writer)
		{
			if (this.d.Length > 210)
			{
				this.b(writer);
			}
			else
			{
				this.c(writer);
			}
		}

		// Token: 0x06004069 RID: 16489 RVA: 0x0022192C File Offset: 0x0022092C
		private new void c(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(83);
			A_0.WriteName(JavaScriptResource.a);
			A_0.WriteName(JavaScriptResource.b);
			A_0.WriteText(this.d);
			if (this.e != null)
			{
				A_0.WriteName(JavaScriptResource.c);
				this.e.Draw(A_0);
			}
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
		}

		// Token: 0x0600406A RID: 16490 RVA: 0x002219AC File Offset: 0x002209AC
		private new void b(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(83);
			A_0.WriteName(JavaScriptResource.a);
			A_0.WriteName(JavaScriptResource.b);
			A_0.WriteReference(A_0.GetObjectNumber(1));
			A_0.WriteDictionaryClose();
			A_0.WriteEndObject();
			A_0.WriteBeginObject();
			this.a(A_0);
			A_0.WriteEndObject();
		}

		// Token: 0x0600406B RID: 16491 RVA: 0x00221A1C File Offset: 0x00220A1C
		private new void a(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			A_0.WriteName(Resource.e);
			bp bp = this.b(this.d, A_0);
			A_0.ai(bp.s());
			A_0.WriteName(Resource.c);
			A_0.WriteName(Resource.d);
			A_0.WriteDictionaryClose();
			A_0.ac(bp);
		}

		// Token: 0x0600406C RID: 16492 RVA: 0x00221A80 File Offset: 0x00220A80
		private new bp b(string A_0, DocumentWriter A_1)
		{
			zh zh = A_1.u();
			br br = zh.b(A_0.Length);
			for (int i = 0; i < A_0.Length; i++)
			{
				byte b = A_1.b(A_0[i]);
				if (b == 0)
				{
					return this.a(A_0, A_1);
				}
				br.a(b);
			}
			return zh.a(A_1.y());
		}

		// Token: 0x0600406D RID: 16493 RVA: 0x00221B04 File Offset: 0x00220B04
		private new bp a(string A_0, DocumentWriter A_1)
		{
			zh zh = A_1.u();
			zh.c();
			br br = zh.b(A_0.Length * 2 + 2);
			br.a(254);
			br.a(byte.MaxValue);
			for (int i = 0; i < A_0.Length; i++)
			{
				br.a((byte)(A_0[i] >> 8));
				br.a((byte)A_0[i]);
			}
			return zh.a(A_1.y());
		}

		// Token: 0x040023B4 RID: 9140
		internal new static byte[] a = new byte[]
		{
			74,
			97,
			118,
			97,
			83,
			99,
			114,
			105,
			112,
			116
		};

		// Token: 0x040023B5 RID: 9141
		internal new static byte[] b = new byte[]
		{
			74,
			83
		};

		// Token: 0x040023B6 RID: 9142
		private new static byte[] c = new byte[]
		{
			78,
			101,
			120,
			116
		};

		// Token: 0x040023B7 RID: 9143
		private new string d;

		// Token: 0x040023B8 RID: 9144
		private new Action e;
	}
}
