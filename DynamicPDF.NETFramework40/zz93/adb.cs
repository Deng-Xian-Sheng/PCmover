using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x02000464 RID: 1124
	internal class adb : Font
	{
		// Token: 0x06002EBA RID: 11962 RVA: 0x001A8F58 File Offset: 0x001A7F58
		internal adb() : base(Encoder.Unicode)
		{
		}

		// Token: 0x06002EBB RID: 11963 RVA: 0x001A8F74 File Offset: 0x001A7F74
		public override void Draw(DocumentWriter writer)
		{
			writer.WriteBeginObject();
			writer.WriteDictionaryOpen();
			writer.WriteName(Resource.a);
			writer.WriteName(Resource.i);
			writer.WriteName(Resource.b);
			writer.WriteName(Font.b);
			writer.WriteName(Font.c);
			writer.WriteName(adb.b);
			writer.WriteName(Font.g);
			writer.WriteName(adb.c);
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
			writer.WriteName(adb.b);
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
			writer.WriteNumber(-160);
			writer.WriteNumber(-249);
			writer.WriteNumber(1015);
			writer.WriteNumber(888);
			writer.WriteArrayClose();
			writer.WriteDictionaryClose();
			writer.WriteEndObject();
		}

		// Token: 0x06002EBC RID: 11964 RVA: 0x001A91F0 File Offset: 0x001A81F0
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

		// Token: 0x06002EBD RID: 11965 RVA: 0x001A9230 File Offset: 0x001A8230
		public override short get_Descender()
		{
			return -120;
		}

		// Token: 0x06002EBE RID: 11966 RVA: 0x001A9244 File Offset: 0x001A8244
		public override short get_Ascender()
		{
			return 880;
		}

		// Token: 0x06002EBF RID: 11967 RVA: 0x001A925C File Offset: 0x001A825C
		public override int get_RequiredPdfObjects()
		{
			return 3;
		}

		// Token: 0x06002EC0 RID: 11968 RVA: 0x001A9270 File Offset: 0x001A8270
		internal override short be()
		{
			return -74;
		}

		// Token: 0x06002EC1 RID: 11969 RVA: 0x001A9284 File Offset: 0x001A8284
		internal override short bf()
		{
			return 50;
		}

		// Token: 0x06002EC2 RID: 11970 RVA: 0x001A9298 File Offset: 0x001A8298
		internal override short bc()
		{
			return 50;
		}

		// Token: 0x06002EC3 RID: 11971 RVA: 0x001A92AC File Offset: 0x001A82AC
		internal override short bd()
		{
			return 279;
		}

		// Token: 0x06002EC4 RID: 11972 RVA: 0x001A92C4 File Offset: 0x001A82C4
		public override string get_Name()
		{
			return this.a;
		}

		// Token: 0x06002EC5 RID: 11973 RVA: 0x001A92DC File Offset: 0x001A82DC
		public override LineBreaker get_LineBreaker()
		{
			return LineBreaker.Universal;
		}

		// Token: 0x06002EC6 RID: 11974 RVA: 0x001A92F4 File Offset: 0x001A82F4
		internal override short bh()
		{
			return this.Ascender;
		}

		// Token: 0x06002EC7 RID: 11975 RVA: 0x001A930C File Offset: 0x001A830C
		internal override short bi()
		{
			return this.Descender;
		}

		// Token: 0x04001627 RID: 5671
		private new string a = "MSung-Light";

		// Token: 0x04001628 RID: 5672
		private new static byte[] b = new byte[]
		{
			77,
			83,
			117,
			110,
			103,
			45,
			76,
			105,
			103,
			104,
			116
		};

		// Token: 0x04001629 RID: 5673
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
