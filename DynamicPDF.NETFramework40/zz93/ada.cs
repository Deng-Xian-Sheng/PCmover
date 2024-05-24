using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000463 RID: 1123
	internal class ada : Font
	{
		// Token: 0x06002EAB RID: 11947 RVA: 0x001A8B5F File Offset: 0x001A7B5F
		internal ada() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002EAC RID: 11948 RVA: 0x001A8B7C File Offset: 0x001A7B7C
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(ada.b);
			writer.WriteName(Font.g);
			writer.WriteName(ada.c);
			writer.WriteName(Font.h);
			writer.WriteArrayOpen();
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.i);
			writer.WriteName(Font.c);
			writer.WriteName(ada.b);
			writer.WriteName(Font.k);
			writer.WriteDictionaryOpen();
			writer.WriteName(Font.l);
			writer.WriteText("Adobe");
			writer.WriteName(Font.o);
			writer.WriteText("CNS1");
			writer.WriteName(Font.m);
			writer.WriteNumber0();
			writer.WriteDictionaryClose();
			writer.WriteName(Font.n);
			writer.WriteReference(writer.GetObjectNumber(1));
			writer.WriteName(87);
			writer.WriteArrayOpen();
			writer.WriteNumber1();
			writer.WriteNumber(95);
			writer.WriteNumber(500);
			writer.WriteNumber(13648);
			writer.WriteNumber(13742);
			writer.WriteNumber(500);
			writer.WriteArrayClose();
			writer.WriteName(Font.q);
			writer.WriteNumber(1000);
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Font.n);
			writer.WriteName(Font.p);
			writer.WriteArrayOpen();
			writer.WriteNumber(-45);
			writer.WriteNumber(-250);
			writer.WriteNumber(1015);
			writer.WriteNumber(887);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002EAD RID: 11949 RVA: 0x001A8DF4 File Offset: 0x001A7DF4
		public override short GetGlyphWidth(char glyph)
		{
			short result;
			if (glyph > 'ÿ')
			{
				result = 1000;
			}
			else if (glyph >= ' ')
			{
				result = 500;
			}
			else
			{
				result = 1000;
			}
			return result;
		}

		// Token: 0x06002EAE RID: 11950 RVA: 0x001A8E34 File Offset: 0x001A7E34
		public override short get_Descender()
		{
			return -120;
		}

		// Token: 0x06002EAF RID: 11951 RVA: 0x001A8E48 File Offset: 0x001A7E48
		public override short get_Ascender()
		{
			return 880;
		}

		// Token: 0x06002EB0 RID: 11952 RVA: 0x001A8E60 File Offset: 0x001A7E60
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002EB1 RID: 11953 RVA: 0x001A8E74 File Offset: 0x001A7E74
		internal override short bd()
		{
			return 279;
		}

		// Token: 0x06002EB2 RID: 11954 RVA: 0x001A8E8C File Offset: 0x001A7E8C
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002EB3 RID: 11955 RVA: 0x001A8EA0 File Offset: 0x001A7EA0
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002EB4 RID: 11956 RVA: 0x001A8EB4 File Offset: 0x001A7EB4
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002EB5 RID: 11957 RVA: 0x001A8EC8 File Offset: 0x001A7EC8
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002EB6 RID: 11958 RVA: 0x001A8EE0 File Offset: 0x001A7EE0
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002EB7 RID: 11959 RVA: 0x001A8EF8 File Offset: 0x001A7EF8
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002EB8 RID: 11960 RVA: 0x001A8F10 File Offset: 0x001A7F10
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04001624 RID: 5668
		private new string a = "MHei-Medium";

		// Token: 0x04001625 RID: 5669
		private new static byte[] b = new byte[]
		{
			77,
			72,
			101,
			105,
			45,
			77,
			101,
			100,
			105,
			117,
			109
		};

		// Token: 0x04001626 RID: 5670
		private new static byte[] c = new byte[]
		{
			85,
			110,
			105,
			67,
			78,
			83,
			45,
			85,
			67,
			83,
			50,
			45,
			72
		};
	}
}
