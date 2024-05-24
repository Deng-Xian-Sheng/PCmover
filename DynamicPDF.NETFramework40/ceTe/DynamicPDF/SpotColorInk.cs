using System;
using ceTe.DynamicPDF.IO;

namespace ceTe.DynamicPDF
{
	// Token: 0x020006B2 RID: 1714
	public class SpotColorInk : ColorSpace
	{
		// Token: 0x060041FE RID: 16894 RVA: 0x00226790 File Offset: 0x00225790
		public SpotColorInk(string name, CmykColor alternateColor)
		{
			this.g = name;
			this.h = alternateColor;
		}

		// Token: 0x17000315 RID: 789
		// (get) Token: 0x060041FF RID: 16895 RVA: 0x002267AC File Offset: 0x002257AC
		public string Name
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000316 RID: 790
		// (get) Token: 0x06004200 RID: 16896 RVA: 0x002267C4 File Offset: 0x002257C4
		public CmykColor AlternateColor
		{
			get
			{
				return this.h;
			}
		}

		// Token: 0x06004201 RID: 16897 RVA: 0x002267DC File Offset: 0x002257DC
		public override void DrawName(PageWriter writer)
		{
			writer.Resources.ColorSpaces.Add(this, writer);
		}

		// Token: 0x06004202 RID: 16898 RVA: 0x002267F2 File Offset: 0x002257F2
		public override void DrawColorSpace(DocumentWriter writer)
		{
			writer.WriteName(SpotColorInk.a);
		}

		// Token: 0x06004203 RID: 16899 RVA: 0x00226804 File Offset: 0x00225804
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteArrayOpen();
			writer.WriteName(SpotColorInk.a);
			writer.WriteName(this.g.Replace(" ", "#20"));
			this.h.ColorSpace.DrawColorSpace(writer);
			writer.WriteDictionaryOpen();
			writer.WriteName(SpotColorInk.d);
			writer.WriteNumber(2);
			writer.WriteName(78);
			writer.WriteNumber1();
			writer.WriteName(SpotColorInk.c);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber1();
			writer.WriteArrayClose();
			writer.WriteName(SpotColorInk.b);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber1();
			writer.WriteNumber0();
			writer.WriteNumber1();
			writer.WriteNumber0();
			writer.WriteNumber1();
			writer.WriteNumber0();
			writer.WriteNumber1();
			writer.WriteArrayClose();
			writer.WriteName(SpotColorInk.e);
			writer.WriteArrayOpen();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteNumber0();
			writer.WriteArrayClose();
			writer.WriteName(SpotColorInk.f);
			this.h.gr(writer);
			writer.WriteDictionaryClose();
			writer.WriteArrayClose();
			writer.WriteEndObject();
		}

		// Token: 0x040024A5 RID: 9381
		private new static byte[] a = new byte[]
		{
			83,
			101,
			112,
			97,
			114,
			97,
			116,
			105,
			111,
			110
		};

		// Token: 0x040024A6 RID: 9382
		private new static byte[] b = new byte[]
		{
			82,
			97,
			110,
			103,
			101
		};

		// Token: 0x040024A7 RID: 9383
		private new static byte[] c = new byte[]
		{
			68,
			111,
			109,
			97,
			105,
			110
		};

		// Token: 0x040024A8 RID: 9384
		private new static byte[] d = new byte[]
		{
			70,
			117,
			110,
			99,
			116,
			105,
			111,
			110,
			84,
			121,
			112,
			101
		};

		// Token: 0x040024A9 RID: 9385
		private new static byte[] e = new byte[]
		{
			67,
			48
		};

		// Token: 0x040024AA RID: 9386
		private new static byte[] f = new byte[]
		{
			67,
			49
		};

		// Token: 0x040024AB RID: 9387
		private new string g;

		// Token: 0x040024AC RID: 9388
		private new CmykColor h;
	}
}
