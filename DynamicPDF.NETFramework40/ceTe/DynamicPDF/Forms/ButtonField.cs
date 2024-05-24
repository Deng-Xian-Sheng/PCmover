using System;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.PageElements.Forms;
using zz93;

namespace ceTe.DynamicPDF.Forms
{
	// Token: 0x020003F4 RID: 1012
	public abstract class ButtonField : FormField
	{
		// Token: 0x06002A38 RID: 10808 RVA: 0x001890E5 File Offset: 0x001880E5
		internal ButtonField(string A_0, int A_1, AnnotationReaderEvents A_2) : base(A_0, (FormFieldFlags)A_1, A_2)
		{
		}

		// Token: 0x06002A39 RID: 10809 RVA: 0x001890FC File Offset: 0x001880FC
		protected override void DrawDictionary(DocumentWriter writer)
		{
			if (base.Parent == null || !(base.Parent is ButtonField))
			{
				writer.WriteName(FormField.n);
				writer.WriteName(ButtonField.a);
			}
			base.d(writer);
			base.DrawDictionary(writer);
		}

		// Token: 0x06002A3A RID: 10810 RVA: 0x00189154 File Offset: 0x00188154
		internal virtual string i6()
		{
			return this.e;
		}

		// Token: 0x06002A3B RID: 10811 RVA: 0x0018916C File Offset: 0x0018816C
		internal new virtual void b(string A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06002A3C RID: 10812 RVA: 0x00189178 File Offset: 0x00188178
		internal virtual Behavior i5()
		{
			return this.f;
		}

		// Token: 0x06002A3D RID: 10813 RVA: 0x00189190 File Offset: 0x00188190
		internal new virtual void a(Behavior A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06002A3E RID: 10814 RVA: 0x0018919C File Offset: 0x0018819C
		internal override bj cc()
		{
			return bj.a;
		}

		// Token: 0x0400136B RID: 4971
		private new static byte[] a = new byte[]
		{
			66,
			116,
			110
		};

		// Token: 0x0400136C RID: 4972
		internal new static byte[] b = new byte[]
		{
			67,
			65
		};

		// Token: 0x0400136D RID: 4973
		internal new static byte[] c = new byte[]
		{
			65,
			67
		};

		// Token: 0x0400136E RID: 4974
		internal new static byte[] d = new byte[]
		{
			82,
			67
		};

		// Token: 0x0400136F RID: 4975
		private new string e;

		// Token: 0x04001370 RID: 4976
		private new Behavior f = null;
	}
}
