using System;
using System.Collections;
using System.ComponentModel;
using System.Text;
using ceTe.DynamicPDF.Text;
using zz93;

namespace ceTe.DynamicPDF.IO
{
	// Token: 0x02000078 RID: 120
	public abstract class OperatorWriter : Resource
	{
		// Token: 0x06000505 RID: 1285 RVA: 0x00051168 File Offset: 0x00050168
		internal OperatorWriter(DocumentWriter A_0, zh A_1, AreaDimensions A_2)
		{
			this.g = A_0;
			this.d = new PageWriterState();
			this.e = A_2;
			this.f = A_0.Document;
			this.a = A_1;
		}

		// Token: 0x17000019 RID: 25
		// (get) Token: 0x06000506 RID: 1286 RVA: 0x000511CC File Offset: 0x000501CC
		public override int RequiredPdfObjects
		{
			get
			{
				return 1;
			}
		}

		// Token: 0x1700001A RID: 26
		// (get) Token: 0x06000507 RID: 1287 RVA: 0x000511E0 File Offset: 0x000501E0
		public AreaDimensions Dimensions
		{
			get
			{
				return this.e;
			}
		}

		// Token: 0x1700001B RID: 27
		// (get) Token: 0x06000508 RID: 1288 RVA: 0x000511F8 File Offset: 0x000501F8
		public Document Document
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x1700001C RID: 28
		// (get) Token: 0x06000509 RID: 1289 RVA: 0x00051210 File Offset: 0x00050210
		public DocumentWriter DocumentWriter
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x0600050A RID: 1290 RVA: 0x00051228 File Offset: 0x00050228
		internal PageWriterState q()
		{
			return this.d;
		}

		// Token: 0x0600050B RID: 1291
		public abstract void Write_Do(Resource xObject);

		// Token: 0x0600050C RID: 1292 RVA: 0x00051240 File Offset: 0x00050240
		public void SetDimensionsShift(float x, float y, float width, float height)
		{
			this.e = new cq(this.e, x, y, width, height);
		}

		// Token: 0x0600050D RID: 1293 RVA: 0x00051259 File Offset: 0x00050259
		public void SetDimensionsSimpleRotate(float x, float y, float angle)
		{
			this.e = new cs(this.e, x, y, angle);
			this.e.a1(this);
		}

		// Token: 0x0600050E RID: 1294 RVA: 0x0005127D File Offset: 0x0005027D
		public void SetDimensionsSimpleRotate(float x, float y, float xX, float xY, float yX, float yY)
		{
			this.e = new cs(this.e, x, y, xX, xY, yX, yY);
			this.e.a1(this);
		}

		// Token: 0x0600050F RID: 1295 RVA: 0x000512A7 File Offset: 0x000502A7
		public void SetDimensionsRotate(float x, float y, float width, float height, float angle)
		{
			this.e = new co(this.e, x, y, width, height, angle);
			this.e.a1(this);
		}

		// Token: 0x06000510 RID: 1296 RVA: 0x000512D0 File Offset: 0x000502D0
		public void SetDimensionsRotate(float x, float y, float width, float height, float xX, float xY, float yX, float yY)
		{
			this.e = new co(this.e, x, y, width, height, xX, xY, yX, yY);
			this.e.a1(this);
		}

		// Token: 0x06000511 RID: 1297 RVA: 0x00051309 File Offset: 0x00050309
		public void SetDimensionsScale(float x, float y, float width, float height, float scaleX, float scaleY)
		{
			this.e = new cp(this.e, x, y, width, height, scaleX, scaleY);
			this.e.a1(this);
		}

		// Token: 0x06000512 RID: 1298 RVA: 0x00051334 File Offset: 0x00050334
		public void SetDimensionsTransform(float x, float y, float width, float height, float angle, float scaleX, float scaleY)
		{
			this.e = new ct(this.e, x, y, width, height, angle, scaleX, scaleY);
			this.e.a1(this);
		}

		// Token: 0x06000513 RID: 1299 RVA: 0x0005136C File Offset: 0x0005036C
		public void SetDimensionsTransform(float x, float y, float width, float height, float xX, float xY, float yX, float yY, float scaleX, float scaleY)
		{
			this.e = new ct(this.e, x, y, width, height, xX, xY, yX, yY, scaleX, scaleY);
			this.e.a1(this);
		}

		// Token: 0x06000514 RID: 1300 RVA: 0x000513A9 File Offset: 0x000503A9
		public void ResetDimensions()
		{
			this.e.a2(this);
			this.e = this.e.ay();
		}

		// Token: 0x06000515 RID: 1301 RVA: 0x000513CC File Offset: 0x000503CC
		public void Write_BT()
		{
			this.h = true;
			br br = this.a.b(3);
			br.a(66);
			br.a(84);
			br.a(10);
		}

		// Token: 0x06000516 RID: 1302 RVA: 0x0005140C File Offset: 0x0005040C
		public void Write_ET()
		{
			this.h = false;
			br br = this.a.b(3);
			br.a(69);
			br.a(84);
			br.a(10);
		}

		// Token: 0x06000517 RID: 1303 RVA: 0x0005144C File Offset: 0x0005044C
		public void Write_W()
		{
			br br = this.a.b(2);
			br.a(87);
			br.a(10);
		}

		// Token: 0x06000518 RID: 1304 RVA: 0x0005147C File Offset: 0x0005047C
		public void Write_Wx()
		{
			br br = this.a.b(3);
			br.a(87);
			br.a(42);
			br.a(10);
		}

		// Token: 0x06000519 RID: 1305 RVA: 0x000514B2 File Offset: 0x000504B2
		public void Write_Tj_(char[] text, bool rightToLeft)
		{
			this.Write_Tj_(text, 0, text.Length, rightToLeft);
		}

		// Token: 0x0600051A RID: 1306 RVA: 0x000514C4 File Offset: 0x000504C4
		public void Write_Tj_(char[] textArray, int start, int length, bool rightToLeft)
		{
			br br = this.a.b(length * this.d.Font.Encoder.fl() * 2 + 5);
			this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, start, length, rightToLeft);
			br.a(84);
			br.a(106);
			br.a(10);
		}

		// Token: 0x0600051B RID: 1307 RVA: 0x0005153B File Offset: 0x0005053B
		internal new void a(char[] A_0, int A_1, int A_2, bool A_3)
		{
			this.a(A_0, A_1, ref A_2);
			this.Write_Tj_(A_0, A_1, A_2, A_3);
		}

		// Token: 0x0600051C RID: 1308 RVA: 0x00051558 File Offset: 0x00050558
		public void Write_TJ_Open()
		{
			br br = this.a.b(1);
			br.a(91);
		}

		// Token: 0x0600051D RID: 1309 RVA: 0x0005157C File Offset: 0x0005057C
		public void Write_TJ_Text(char[] text, int startIndex, int length, bool rightToLeft)
		{
			br a_ = this.a.b(length * this.d.Font.Encoder.fl() * 2 + 2);
			this.d.Font.Encoder.fm(a_, this.DocumentWriter.FontSubsetter, text, startIndex, length, rightToLeft);
		}

		// Token: 0x0600051E RID: 1310 RVA: 0x000515D8 File Offset: 0x000505D8
		public void Write_TJ_SpaceLength(int spaceLength)
		{
			br br = this.a.b(11);
			br.c(spaceLength);
		}

		// Token: 0x0600051F RID: 1311 RVA: 0x000515FC File Offset: 0x000505FC
		public void Write_TJ_Close()
		{
			br br = this.a.b(4);
			br.a(93);
			br.a(84);
			br.a(74);
			br.a(10);
		}

		// Token: 0x06000520 RID: 1312 RVA: 0x0005163C File Offset: 0x0005063C
		public void Write_TJ(char[] textArray, int start, int length, float wordSpacing, bool rightToLeft)
		{
			br br = this.a.b(1);
			br.a(91);
			int a_ = (int)(-wordSpacing * 1000f / this.d.FontSize);
			if (rightToLeft)
			{
				int num = start + length - 1;
				int i = num;
				int num2 = 0;
				while (i > start)
				{
					if (textArray[i] == ' ')
					{
						br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 13);
						this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, i + 1, num2, rightToLeft);
						br.c(a_);
						num2 = 0;
					}
					num2++;
					i--;
				}
				br = this.a.b((num2 + 1) * this.d.Font.Encoder.fl() * 2 + 6);
				this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, i, num2 + 1, rightToLeft);
			}
			else
			{
				int num = start;
				int i = start;
				int num2 = 0;
				while (i < start + length)
				{
					num2++;
					if (textArray[i] == ' ')
					{
						br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 13);
						this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, num, num2, rightToLeft);
						br.c(a_);
						num = i + 1;
						num2 = 0;
					}
					i++;
				}
				br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 6);
				this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, num, num2, rightToLeft);
			}
			br.a(93);
			br.a(84);
			br.a(74);
			br.a(10);
		}

		// Token: 0x06000521 RID: 1313 RVA: 0x00051884 File Offset: 0x00050884
		internal new void a(char[] A_0, int A_1, int A_2, float A_3, bool A_4)
		{
			br br = this.a.b(1);
			br.a(91);
			int a_ = (int)(-A_3 * 1000f / this.d.FontSize);
			if (A_4)
			{
				int num = A_1 + A_2 - 1;
				int i = num;
				int num2 = 0;
				while (i > A_1)
				{
					if (A_0[i] == ' ')
					{
						br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 13);
						this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, A_0, i + 1, num2, A_4);
						br.c(a_);
						num2 = 0;
					}
					num2++;
					i--;
				}
				br = this.a.b((num2 + 1) * this.d.Font.Encoder.fl() * 2 + 6);
				this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, A_0, i, num2 + 1, A_4);
			}
			else
			{
				int num = A_1;
				int i = A_1;
				int num2 = 0;
				while (i < A_1 + A_2)
				{
					num2++;
					if (A_0[i] == ' ')
					{
						br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 13);
						this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, A_0, num, num2, A_4);
						br.c(a_);
						num = i + 1;
						num2 = 0;
					}
					i++;
				}
				this.a(A_0, num, ref num2);
				br = this.a.b(num2 * this.d.Font.Encoder.fl() * 2 + 6);
				this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, A_0, num, num2, A_4);
			}
			br.a(93);
			br.a(84);
			br.a(74);
			br.a(10);
		}

		// Token: 0x06000522 RID: 1314 RVA: 0x00051AD8 File Offset: 0x00050AD8
		private new void a(char[] A_0, int A_1, ref int A_2)
		{
			if (A_0.Length > A_1 + A_2)
			{
				if (A_0[A_1 + A_2] == ' ')
				{
					A_2++;
				}
			}
		}

		// Token: 0x06000523 RID: 1315 RVA: 0x00051B10 File Offset: 0x00050B10
		public void Write_Tc(float characterSpacing)
		{
			br br = this.a.b(14);
			br.c(characterSpacing);
			br.a(32);
			br.a(84);
			br.a(99);
			br.a(10);
			this.d.CharacterSpacing = characterSpacing;
		}

		// Token: 0x06000524 RID: 1316 RVA: 0x00051B68 File Offset: 0x00050B68
		public void Write_Tw(float wordSpacing)
		{
			br br = this.a.b(14);
			br.c(wordSpacing);
			br.a(32);
			br.a(84);
			br.a(119);
			br.a(10);
			this.d.WordSpacing = wordSpacing;
		}

		// Token: 0x06000525 RID: 1317 RVA: 0x00051BC0 File Offset: 0x00050BC0
		public void Write_Tz(float horizontalScaling)
		{
			br br = this.a.b(14);
			br.c(horizontalScaling);
			br.a(32);
			br.a(84);
			br.a(122);
			br.a(10);
			this.d.HorizontalScaling = horizontalScaling;
		}

		// Token: 0x06000526 RID: 1318 RVA: 0x00051C18 File Offset: 0x00050C18
		public void Write_TL(float leading)
		{
			br br = this.a.b(14);
			br.c(leading);
			br.a(32);
			br.a(84);
			br.a(76);
			br.a(10);
			this.d.Leading = leading;
		}

		// Token: 0x06000527 RID: 1319 RVA: 0x00051C70 File Offset: 0x00050C70
		public void Write_Tr(TextRenderingMode renderingMode)
		{
			br br = this.a.b(7);
			br.c((int)renderingMode);
			br.a(32);
			br.a(84);
			br.a(114);
			br.a(10);
			this.d.TextRenderingMode = renderingMode;
		}

		// Token: 0x06000528 RID: 1320 RVA: 0x00051CC4 File Offset: 0x00050CC4
		public void Write_Ts(float textRise)
		{
			br br = this.a.b(14);
			br.c(textRise);
			br.a(32);
			br.a(84);
			br.a(115);
			br.a(10);
			this.d.TextRise = textRise;
		}

		// Token: 0x06000529 RID: 1321
		public abstract void Write_Tf(Font font, float fontSize);

		// Token: 0x0600052A RID: 1322 RVA: 0x00051D19 File Offset: 0x00050D19
		public void Write_d(LineStyle lineStyle)
		{
			lineStyle.a(this);
			this.d.LineStyle = lineStyle;
		}

		// Token: 0x0600052B RID: 1323 RVA: 0x00051D34 File Offset: 0x00050D34
		public void Write_Tm(float angle, float x, float y)
		{
			double num = (double)(-(double)angle) * 0.017453292519943295;
			float num2 = (float)Math.Cos(num);
			float num3 = (float)Math.Sin(num);
			float num4 = -num3;
			float num5 = num2;
			this.Write_Tm(num2, num3, num4, num5, x, y);
		}

		// Token: 0x0600052C RID: 1324 RVA: 0x00051D74 File Offset: 0x00050D74
		public void Write_Tm(float x, float y)
		{
			br br = this.a.b(33);
			br.a(49);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(49);
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y));
			br.a(32);
			br.a(84);
			br.a(109);
			br.a(10);
		}

		// Token: 0x0600052D RID: 1325 RVA: 0x00051E2C File Offset: 0x00050E2C
		public void Write_Tm(float a, float b, float c, float d, float x, float y)
		{
			br br = this.a.b(73);
			br.a(a);
			br.a(32);
			br.a(b);
			br.a(32);
			br.a(c);
			br.a(32);
			br.a(d);
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y));
			br.a(32);
			br.a(84);
			br.a(109);
			br.a(10);
		}

		// Token: 0x0600052E RID: 1326 RVA: 0x00051EE4 File Offset: 0x00050EE4
		public void Write_Tm(float xX, float xY, float yX, float yY)
		{
			br br = this.a.b(55);
			br.a(xX);
			br.a(32);
			br.a(xY);
			br.a(32);
			br.a(yX);
			br.a(32);
			br.a(yY);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(84);
			br.a(109);
			br.a(10);
		}

		// Token: 0x0600052F RID: 1327 RVA: 0x00051F84 File Offset: 0x00050F84
		public void Write_DQuote(float wordSpacing, float characterSpacing, char[] textArray, int start, int length, bool rightToLeft)
		{
			br br = this.a.b(length * this.d.Font.Encoder.fl() * 2 + 28);
			br.a(wordSpacing);
			br.a(32);
			br.a(characterSpacing);
			br.a(32);
			this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, start, length, rightToLeft);
			br.a(34);
			br.a(10);
			this.d.WordSpacing = wordSpacing;
			this.d.CharacterSpacing = characterSpacing;
		}

		// Token: 0x06000530 RID: 1328 RVA: 0x00052034 File Offset: 0x00051034
		public virtual void Write_m_(float x, float y)
		{
			br br = this.a.b(26);
			br.c(this.Dimensions.GetPdfX(x));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y));
			br.a(32);
			br.a(109);
			br.a(10);
		}

		// Token: 0x06000531 RID: 1329 RVA: 0x0005209C File Offset: 0x0005109C
		public virtual void Write_l_(float x, float y)
		{
			br br = this.a.b(26);
			br.c(this.Dimensions.GetPdfX(x));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y));
			br.a(32);
			br.a(108);
			br.a(10);
		}

		// Token: 0x06000532 RID: 1330 RVA: 0x00052104 File Offset: 0x00051104
		public virtual void Write_c(float x1, float y1, float x2, float y2, float x3, float y3)
		{
			br br = this.a.b(68);
			br.c(this.Dimensions.GetPdfX(x1));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y1));
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x2));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y2));
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x3));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y3));
			br.a(32);
			br.a(99);
			br.a(10);
		}

		// Token: 0x06000533 RID: 1331 RVA: 0x000521E0 File Offset: 0x000511E0
		public virtual void Write_v(float x2, float y2, float x3, float y3)
		{
			br br = this.a.b(46);
			br.c(this.Dimensions.GetPdfX(x2));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y2));
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x3));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y3));
			br.a(32);
			br.a(118);
			br.a(10);
		}

		// Token: 0x06000534 RID: 1332 RVA: 0x00052280 File Offset: 0x00051280
		public virtual void Write_y(float x1, float y1, float x3, float y3)
		{
			br br = this.a.b(46);
			br.c(this.Dimensions.GetPdfX(x1));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y1));
			br.a(32);
			br.c(this.Dimensions.GetPdfX(x3));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y3));
			br.a(32);
			br.a(121);
			br.a(10);
		}

		// Token: 0x06000535 RID: 1333 RVA: 0x00052320 File Offset: 0x00051320
		public virtual void Write_re(float x, float y, float width, float height)
		{
			br br = this.a.b(47);
			br.c(this.Dimensions.GetPdfX(x));
			br.a(32);
			br.c(this.Dimensions.GetPdfY(y + height));
			br.a(32);
			br.c(width);
			br.a(32);
			br.c(height);
			br.a(32);
			br.a(114);
			br.a(101);
			br.a(10);
		}

		// Token: 0x06000536 RID: 1334 RVA: 0x000523B8 File Offset: 0x000513B8
		public void SetLineStyle(LineStyle lineStyle)
		{
			if (this.d.LineStyle != lineStyle)
			{
				this.Write_d(lineStyle);
			}
		}

		// Token: 0x06000537 RID: 1335 RVA: 0x000523E4 File Offset: 0x000513E4
		public void WritePoint(float pointX, float pointY)
		{
			br br = this.a.b(21);
			br.c(this.Dimensions.GetPdfX(pointX));
			br.e();
			br.c(this.Dimensions.GetPdfY(pointY));
		}

		// Token: 0x06000538 RID: 1336 RVA: 0x00052430 File Offset: 0x00051430
		public void WritePointX(float pointX)
		{
			br br = this.a.b(10);
			br.c(this.Dimensions.GetPdfX(pointX));
		}

		// Token: 0x06000539 RID: 1337 RVA: 0x00052460 File Offset: 0x00051460
		public void WritePointY(float pointY)
		{
			br br = this.a.b(10);
			br.c(this.Dimensions.GetPdfY(pointY));
		}

		// Token: 0x0600053A RID: 1338 RVA: 0x00052490 File Offset: 0x00051490
		public void Write_w_(float lineWidth)
		{
			br br = this.a.b(13);
			br.c(lineWidth);
			br.a(32);
			br.a(119);
			br.a(10);
			this.d.LineWidth = lineWidth;
		}

		// Token: 0x0600053B RID: 1339 RVA: 0x000524DC File Offset: 0x000514DC
		public void Write_J(LineCap lineCap)
		{
			br br = this.a.b(6);
			br.c((int)lineCap);
			br.a(32);
			br.a(74);
			br.a(10);
			this.d.LineCap = lineCap;
		}

		// Token: 0x0600053C RID: 1340 RVA: 0x00052528 File Offset: 0x00051528
		public void Write_j_(LineJoin lineJoin)
		{
			br br = this.a.b(6);
			br.c((int)lineJoin);
			br.a(32);
			br.a(106);
			br.a(10);
			this.d.LineJoin = lineJoin;
		}

		// Token: 0x0600053D RID: 1341 RVA: 0x00052574 File Offset: 0x00051574
		public void Write_M(float miterLimit)
		{
			br br = this.a.b(13);
			br.c(miterLimit);
			br.a(32);
			br.a(77);
			br.a(10);
			this.d.MiterLimit = miterLimit;
		}

		// Token: 0x0600053E RID: 1342 RVA: 0x000525C0 File Offset: 0x000515C0
		public void Write_Td_(float x, float y)
		{
			br br = this.a.b(25);
			br.c(x);
			br.a(32);
			br.c(y);
			br.a(32);
			br.a(84);
			br.a(100);
			br.a(10);
		}

		// Token: 0x0600053F RID: 1343 RVA: 0x0005261C File Offset: 0x0005161C
		public void Write_TD(float x, float y)
		{
			br br = this.a.b(25);
			br.c(x);
			br.a(32);
			br.c(-y);
			br.a(32);
			br.a(84);
			br.a(68);
			br.a(10);
			this.d.Leading = y;
		}

		// Token: 0x06000540 RID: 1344 RVA: 0x00052684 File Offset: 0x00051684
		public void Write_Tx()
		{
			br br = this.a.b(3);
			br.a(84);
			br.a(42);
			br.a(10);
		}

		// Token: 0x06000541 RID: 1345 RVA: 0x000526BC File Offset: 0x000516BC
		public virtual void Write_G(Grayscale color)
		{
			br br = this.a.b(8);
			br.b(color.GrayLevel);
			br.a(32);
			br.a(71);
			br.a(10);
			this.d.StrokeColor = color;
			this.d.StrokeColorSpace = ColorSpace.DeviceGray;
		}

		// Token: 0x06000542 RID: 1346 RVA: 0x00052720 File Offset: 0x00051720
		public virtual void Write_g_(Grayscale color)
		{
			br br = this.a.b(8);
			br.b(color.GrayLevel);
			br.a(32);
			br.a(103);
			br.a(10);
			this.d.FillColor = color;
			this.d.FillColorSpace = ColorSpace.DeviceGray;
		}

		// Token: 0x06000543 RID: 1347 RVA: 0x00052784 File Offset: 0x00051784
		public virtual void Write_RG(RgbColor color)
		{
			br br = this.a.b(21);
			br.b(color.R);
			br.a(32);
			br.b(color.G);
			br.a(32);
			br.b(color.B);
			br.a(32);
			br.a(82);
			br.a(71);
			br.a(10);
			this.d.StrokeColor = color;
			this.d.StrokeColorSpace = ColorSpace.DeviceRgb;
		}

		// Token: 0x06000544 RID: 1348 RVA: 0x0005281C File Offset: 0x0005181C
		public virtual void Write_rg_(RgbColor color)
		{
			br br = this.a.b(21);
			br.b(color.R);
			br.a(32);
			br.b(color.G);
			br.a(32);
			br.b(color.B);
			br.a(32);
			br.a(114);
			br.a(103);
			br.a(10);
			this.d.FillColor = color;
			this.d.FillColorSpace = ColorSpace.DeviceRgb;
		}

		// Token: 0x06000545 RID: 1349 RVA: 0x000528B4 File Offset: 0x000518B4
		internal new void e(float A_0, float A_1, float A_2)
		{
			br br = this.a.b(21);
			br.b(A_0);
			br.a(32);
			br.b(A_1);
			br.a(32);
			br.b(A_2);
			br.a(32);
			br.a(114);
			br.a(103);
			br.a(10);
			this.d.FillColorSpace = ColorSpace.DeviceRgb;
		}

		// Token: 0x06000546 RID: 1350 RVA: 0x00052930 File Offset: 0x00051930
		internal new void f(float A_0, float A_1, float A_2)
		{
			br br = this.a.b(21);
			br.b(A_0);
			br.a(32);
			br.b(A_1);
			br.a(32);
			br.b(A_2);
			br.a(32);
			br.a(82);
			br.a(71);
			br.a(10);
			this.d.FillColorSpace = ColorSpace.DeviceRgb;
		}

		// Token: 0x06000547 RID: 1351 RVA: 0x000529AC File Offset: 0x000519AC
		public virtual void Write_K(CmykColor color)
		{
			br br = this.a.b(26);
			br.b(color.C);
			br.a(32);
			br.b(color.M);
			br.a(32);
			br.b(color.Y);
			br.a(32);
			br.b(color.K);
			br.a(32);
			br.a(75);
			br.a(10);
			this.d.StrokeColor = color;
			this.d.StrokeColorSpace = ColorSpace.DeviceCmyk;
		}

		// Token: 0x06000548 RID: 1352 RVA: 0x00052A50 File Offset: 0x00051A50
		public virtual void Write_k_(CmykColor color)
		{
			br br = this.a.b(26);
			br.b(color.C);
			br.a(32);
			br.b(color.M);
			br.a(32);
			br.b(color.Y);
			br.a(32);
			br.b(color.K);
			br.a(32);
			br.a(107);
			br.a(10);
			this.d.FillColor = color;
			this.d.FillColorSpace = ColorSpace.DeviceCmyk;
		}

		// Token: 0x06000549 RID: 1353 RVA: 0x00052AF4 File Offset: 0x00051AF4
		public void Write_q_(bool storeState)
		{
			if (storeState)
			{
				this.c.Push(this.d);
				this.d = new PageWriterState(this.d);
			}
			this.Write_q_();
		}

		// Token: 0x0600054A RID: 1354 RVA: 0x00052B38 File Offset: 0x00051B38
		public void Write_Q(bool restoreState)
		{
			if (restoreState)
			{
				this.d = (PageWriterState)this.c.Pop();
				if (this.d.Font is IFontSubsettable)
				{
					this.DocumentWriter.SetFontSubsetter((IFontSubsettable)this.d.Font);
				}
			}
			this.Write_Q();
		}

		// Token: 0x0600054B RID: 1355 RVA: 0x00052BA4 File Offset: 0x00051BA4
		public void Write_q_()
		{
			this.SetGraphicsMode();
			br br = this.a.b(2);
			br.a(113);
			br.a(10);
		}

		// Token: 0x0600054C RID: 1356 RVA: 0x00052BD8 File Offset: 0x00051BD8
		public void Write_Q()
		{
			this.SetGraphicsMode();
			br br = this.a.b(2);
			br.a(81);
			br.a(10);
		}

		// Token: 0x0600054D RID: 1357 RVA: 0x00052C0C File Offset: 0x00051C0C
		public void Write_cm(float xOffset, float yOffset)
		{
			if (xOffset != 0f || yOffset != 0f)
			{
				br br = this.a.b(33);
				br.a(49);
				br.a(32);
				br.a(48);
				br.a(32);
				br.a(48);
				br.a(32);
				br.a(49);
				br.a(32);
				br.c(xOffset);
				br.a(32);
				br.c(yOffset);
				br.a(32);
				br.a(99);
				br.a(109);
				br.a(10);
			}
		}

		// Token: 0x0600054E RID: 1358 RVA: 0x00052CD0 File Offset: 0x00051CD0
		public void Write_cm(float angle, float xOffset, float yOffset)
		{
			double num = (double)(-(double)angle) * 0.017453292519943295;
			float num2 = (float)Math.Cos(num);
			float num3 = (float)Math.Sin(num);
			float num4 = -num3;
			float num5 = num2;
			this.Write_cm(num2, num3, num4, num5, xOffset, yOffset);
		}

		// Token: 0x0600054F RID: 1359 RVA: 0x00052D10 File Offset: 0x00051D10
		public void Write_cm(float angle)
		{
			double num = (double)(-(double)angle) * 0.017453292519943295;
			float num2 = (float)Math.Cos(num);
			float num3 = (float)Math.Sin(num);
			float num4 = -num3;
			float num5 = num2;
			this.Write_cm(num2, num3, num4, num5, 0f, 0f);
		}

		// Token: 0x06000550 RID: 1360 RVA: 0x00052D58 File Offset: 0x00051D58
		public void Write_cm(float xX, float xY, float yX, float yY)
		{
			if (xX != 1f || xY != 0f || yX != 0f || yY != 1f)
			{
				br br = this.a.b(55);
				br.a(xX);
				br.a(32);
				br.a(xY);
				br.a(32);
				br.a(yX);
				br.a(32);
				br.a(yY);
				br.a(32);
				br.a(48);
				br.a(32);
				br.a(48);
				br.a(32);
				br.a(99);
				br.a(109);
				br.a(10);
			}
		}

		// Token: 0x06000551 RID: 1361 RVA: 0x00052E2C File Offset: 0x00051E2C
		public void Write_cm(float a, float b, float c, float d, float e, float f)
		{
			br br = this.a.b(73);
			br.a(a);
			br.a(32);
			br.a(b);
			br.a(32);
			br.a(c);
			br.a(32);
			br.a(d);
			br.a(32);
			br.c(e);
			br.a(32);
			br.c(f);
			br.a(32);
			br.a(99);
			br.a(109);
			br.a(10);
		}

		// Token: 0x06000552 RID: 1362 RVA: 0x00052ECC File Offset: 0x00051ECC
		internal new void b(char[] A_0)
		{
			this.b(A_0, 0, A_0.Length, false);
		}

		// Token: 0x06000553 RID: 1363 RVA: 0x00052EDC File Offset: 0x00051EDC
		internal new void b(char[] A_0, int A_1, int A_2, bool A_3)
		{
			if (this.d.Font.Encoder is r5 && ((r5)this.d.Font.Encoder).a())
			{
				r5 r = (r5)this.d.Font.Encoder;
				agd agd = r.a(A_0, A_1, A_2, false);
				if (agd.b() != null && agd.b().Count > 0)
				{
					foreach (agf agf in agd.b())
					{
						agd.a(agf.a(), agf.b() - agf.a() + 1);
					}
				}
				this.a(agd, 0, agd.a(), A_3, 0f);
			}
			else
			{
				this.Write_Tj_(A_0, A_1, A_2, A_3);
			}
		}

		// Token: 0x06000554 RID: 1364 RVA: 0x00052FF8 File Offset: 0x00051FF8
		internal new void a(agd A_0, int A_1, int A_2, bool A_3, float A_4)
		{
			r5 r = (r5)this.d.Font.Encoder;
			int num = A_1 + A_2;
			if (A_0.a() > 1)
			{
				OperatorWriter.a(A_0, A_1, A_2);
				this.Write_TJ_Open();
				int num2 = A_1;
				if (A_4 == 0f)
				{
					for (int i = A_1 + 1; i < num; i++)
					{
						if (A_0.a(i).e() != 0)
						{
							int num3 = i - num2;
							br a_ = this.a.b(num3 * this.d.Font.Encoder.fl() * 2 + 4);
							r.a(a_, this.DocumentWriter.FontSubsetter, A_0, num2, num3);
							this.Write_TJ_SpaceLength(-A_0.a(i).e());
							num2 = i;
						}
					}
				}
				else
				{
					int num4 = (int)(A_4 * 1000f / this.d.FontSize);
					for (int i = A_1 + 1; i < num; i++)
					{
						int num5;
						if (A_0.b(A_0.a(i).a()) == ' ')
						{
							num5 = num4;
						}
						else
						{
							num5 = 0;
						}
						if (A_0.a(i).e() + num5 != 0)
						{
							int num3 = i - num2;
							br a_ = this.a.b(num3 * this.d.Font.Encoder.fl() * 2 + 4);
							r.a(a_, this.DocumentWriter.FontSubsetter, A_0, num2, num3);
							this.Write_TJ_SpaceLength(-(A_0.a(i).e() + num5));
							num2 = i;
						}
					}
				}
				int num6 = num - num2;
				br a_2 = this.a.b(num6 * this.d.Font.Encoder.fl() * 2 + 4);
				r.a(a_2, this.DocumentWriter.FontSubsetter, A_0, num2, num6);
				this.Write_TJ_Close();
			}
			else
			{
				this.Write_TJ_Open();
				br a_ = this.a.b(A_2 * this.d.Font.Encoder.fl() * 2 + 4);
				r.a(a_, this.DocumentWriter.FontSubsetter, A_0, 0, A_0.a());
				this.Write_TJ_Close();
			}
		}

		// Token: 0x06000555 RID: 1365 RVA: 0x00053274 File Offset: 0x00052274
		private new static void a(agd A_0, int A_1, int A_2)
		{
			if (A_0.b() != null && A_0.b().Count > 0)
			{
				agf agf = A_0.b()[0];
				if (A_1 + A_2 >= agf.a())
				{
					if (agf.a() < A_1)
					{
						agf.a(A_1);
					}
					int a_ = agf.a();
					int a_2;
					if (A_1 + A_2 - 1 >= agf.b())
					{
						a_2 = agf.b() - agf.a() + 1;
						A_0.b().Remove(agf);
						if (A_0.b().Count > 0)
						{
							if (A_1 + A_2 >= A_0.b()[0].a())
							{
								OperatorWriter.a(A_0, A_1, A_2);
							}
						}
					}
					else
					{
						a_2 = A_1 + A_2 - agf.a();
						agf.a(A_1 + A_2);
					}
					A_0.a(a_, a_2);
				}
			}
		}

		// Token: 0x06000556 RID: 1366 RVA: 0x00053378 File Offset: 0x00052378
		public void Write_SQuote(char[] textArray, int start, int length, bool rightToLeft)
		{
			br br = this.a.b(length * this.d.Font.Encoder.fl() * 2 + 4);
			this.d.Font.Encoder.fm(br, this.DocumentWriter.FontSubsetter, textArray, start, length, rightToLeft);
			br.a(39);
			br.a(10);
		}

		// Token: 0x06000557 RID: 1367 RVA: 0x000533E6 File Offset: 0x000523E6
		internal new void c(char[] A_0, int A_1, int A_2, bool A_3)
		{
			this.a(A_0, A_1, ref A_2);
			this.Write_SQuote(A_0, A_1, A_2, A_3);
		}

		// Token: 0x06000558 RID: 1368 RVA: 0x00053400 File Offset: 0x00052400
		public void Write_h()
		{
			br br = this.a.b(2);
			br.a(104);
			br.a(10);
		}

		// Token: 0x06000559 RID: 1369 RVA: 0x00053430 File Offset: 0x00052430
		public virtual void Write_S()
		{
			br br = this.a.b(2);
			br.a(83);
			br.a(10);
		}

		// Token: 0x0600055A RID: 1370 RVA: 0x00053460 File Offset: 0x00052460
		public virtual void Write_s_()
		{
			br br = this.a.b(2);
			br.a(115);
			br.a(10);
		}

		// Token: 0x0600055B RID: 1371 RVA: 0x00053490 File Offset: 0x00052490
		public virtual void Write_fx()
		{
			br br = this.a.b(3);
			br.a(102);
			br.a(42);
			br.a(10);
		}

		// Token: 0x0600055C RID: 1372 RVA: 0x000534C8 File Offset: 0x000524C8
		public virtual void Write_f()
		{
			br br = this.a.b(2);
			br.a(102);
			br.a(10);
		}

		// Token: 0x0600055D RID: 1373 RVA: 0x000534F8 File Offset: 0x000524F8
		public virtual void Write_B()
		{
			br br = this.a.b(2);
			br.a(66);
			br.a(10);
		}

		// Token: 0x0600055E RID: 1374 RVA: 0x00053528 File Offset: 0x00052528
		public virtual void Write_b_()
		{
			br br = this.a.b(2);
			br.a(98);
			br.a(10);
		}

		// Token: 0x0600055F RID: 1375 RVA: 0x00053558 File Offset: 0x00052558
		public virtual void Write_Bx()
		{
			br br = this.a.b(3);
			br.a(66);
			br.a(42);
			br.a(10);
		}

		// Token: 0x06000560 RID: 1376 RVA: 0x00053590 File Offset: 0x00052590
		public virtual void Write_bx_()
		{
			br br = this.a.b(3);
			br.a(98);
			br.a(42);
			br.a(10);
		}

		// Token: 0x06000561 RID: 1377 RVA: 0x000535C8 File Offset: 0x000525C8
		public void Write_n()
		{
			br br = this.a.b(2);
			br.a(110);
			br.a(10);
		}

		// Token: 0x06000562 RID: 1378 RVA: 0x000535F8 File Offset: 0x000525F8
		public void Write_d(int on, int off)
		{
			br br = this.a.b(28);
			br.a(91);
			br.c(on);
			br.a(32);
			if (off != 0)
			{
				br.c(off);
			}
			br.a(93);
			br.a(32);
			br.a(48);
			br.a(32);
			br.a(100);
			br.a(10);
		}

		// Token: 0x06000563 RID: 1379 RVA: 0x00053674 File Offset: 0x00052674
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RequireLicense(int level)
		{
			this.i |= level;
		}

		// Token: 0x06000564 RID: 1380 RVA: 0x00053685 File Offset: 0x00052685
		[EditorBrowsable(EditorBrowsableState.Never)]
		public void RequireLicense()
		{
			this.RequireLicense(1);
		}

		// Token: 0x06000565 RID: 1381 RVA: 0x00053690 File Offset: 0x00052690
		internal int r()
		{
			return this.i;
		}

		// Token: 0x06000566 RID: 1382 RVA: 0x000536A8 File Offset: 0x000526A8
		public void SetLineWidth(float lineWidth)
		{
			if (this.d.LineWidth != lineWidth)
			{
				this.Write_w_(lineWidth);
			}
		}

		// Token: 0x06000567 RID: 1383 RVA: 0x000536D4 File Offset: 0x000526D4
		public void SetCharacterSpacing(float characterSpacing)
		{
			if (this.d.CharacterSpacing != characterSpacing)
			{
				this.Write_Tc(characterSpacing);
			}
		}

		// Token: 0x06000568 RID: 1384 RVA: 0x00053700 File Offset: 0x00052700
		public void SetHorizontalScaling(float horizontalScaling)
		{
			if (this.d.HorizontalScaling != horizontalScaling)
			{
				this.Write_Tz(horizontalScaling);
			}
		}

		// Token: 0x06000569 RID: 1385 RVA: 0x0005372C File Offset: 0x0005272C
		public void SetTextRenderingMode(TextRenderingMode textRenderingMode)
		{
			if (this.d.TextRenderingMode != textRenderingMode)
			{
				this.Write_Tr(textRenderingMode);
			}
		}

		// Token: 0x0600056A RID: 1386 RVA: 0x00053758 File Offset: 0x00052758
		public void SetTextRise(float textRise)
		{
			if (this.d.TextRise != textRise)
			{
				this.Write_Ts(textRise);
			}
		}

		// Token: 0x0600056B RID: 1387 RVA: 0x00053784 File Offset: 0x00052784
		public void SetWordSpacing(float wordSpacing)
		{
			if (this.d.WordSpacing != wordSpacing)
			{
				this.Write_Tw(wordSpacing);
			}
		}

		// Token: 0x0600056C RID: 1388 RVA: 0x000537B0 File Offset: 0x000527B0
		public void SetGraphicsMode()
		{
			if (this.h)
			{
				this.Write_ET();
			}
		}

		// Token: 0x0600056D RID: 1389 RVA: 0x000537D4 File Offset: 0x000527D4
		public void SetTextMode()
		{
			if (!this.h)
			{
				this.Write_BT();
			}
		}

		// Token: 0x0600056E RID: 1390 RVA: 0x000537F5 File Offset: 0x000527F5
		public void SetTextDefaults()
		{
			this.SetTextRenderingMode(TextRenderingMode.Fill);
			this.SetCharacterSpacing(0f);
			this.SetWordSpacing(0f);
			this.SetHorizontalScaling(100f);
			this.SetTextRise(0f);
		}

		// Token: 0x0600056F RID: 1391 RVA: 0x00053830 File Offset: 0x00052830
		public void SetLeading(float leading)
		{
			if (this.d.Leading != leading)
			{
				this.Write_TL(leading);
			}
		}

		// Token: 0x06000570 RID: 1392 RVA: 0x0005385C File Offset: 0x0005285C
		public void SetLineJoin(LineJoin lineJoin)
		{
			if (this.d.LineJoin != lineJoin)
			{
				this.Write_j_(lineJoin);
			}
		}

		// Token: 0x06000571 RID: 1393 RVA: 0x00053888 File Offset: 0x00052888
		public void SetLineCap(LineCap lineCap)
		{
			if (this.d.LineCap != lineCap)
			{
				this.Write_J(lineCap);
			}
		}

		// Token: 0x06000572 RID: 1394 RVA: 0x000538B4 File Offset: 0x000528B4
		public void SetMiterLimit(float miterLimit)
		{
			if (this.d.MiterLimit != miterLimit)
			{
				this.Write_M(miterLimit);
			}
		}

		// Token: 0x06000573 RID: 1395 RVA: 0x000538E0 File Offset: 0x000528E0
		public void SetFont(Font font, float fontSize)
		{
			if (this.d.Font != font || this.d.FontSize != fontSize)
			{
				this.Write_Tf(font, fontSize);
			}
		}

		// Token: 0x06000574 RID: 1396 RVA: 0x00053920 File Offset: 0x00052920
		public void SetStrokeColor(Color color)
		{
			if (!this.d.StrokeColor.Equals(color))
			{
				color.DrawStroke(this);
			}
		}

		// Token: 0x06000575 RID: 1397 RVA: 0x00053950 File Offset: 0x00052950
		public void SetFillColor(Color color)
		{
			if (!this.d.FillColor.Equals(color))
			{
				color.DrawFill(this);
			}
		}

		// Token: 0x06000576 RID: 1398 RVA: 0x0005397D File Offset: 0x0005297D
		public void Write(byte[] data)
		{
			this.Write(data, 0, data.Length);
		}

		// Token: 0x06000577 RID: 1399 RVA: 0x0005398C File Offset: 0x0005298C
		public void Write(byte[] data, int length)
		{
			this.Write(data, 0, length);
		}

		// Token: 0x06000578 RID: 1400 RVA: 0x0005399C File Offset: 0x0005299C
		public void Write(byte[] data, int start, int length)
		{
			br br = this.a.b(length);
			br.a(data, start, length);
		}

		// Token: 0x06000579 RID: 1401 RVA: 0x000539C4 File Offset: 0x000529C4
		public void WriteSpace()
		{
			br br = this.a.b(1);
			br.e();
		}

		// Token: 0x0600057A RID: 1402 RVA: 0x000539E8 File Offset: 0x000529E8
		public void WritePair(float value1, float value2)
		{
			br br = this.a.b(21);
			br.c(value1);
			br.e();
			br.c(value2);
		}

		// Token: 0x0600057B RID: 1403 RVA: 0x00053A1C File Offset: 0x00052A1C
		public void WriteColorValue(byte value)
		{
			br br = this.a.b(5);
			br.b((float)value / 25.5f + 0.005f);
		}

		// Token: 0x0600057C RID: 1404 RVA: 0x00053A4C File Offset: 0x00052A4C
		public void Write(float value)
		{
			br br = this.a.b(10);
			br.c(value);
		}

		// Token: 0x0600057D RID: 1405 RVA: 0x00053A70 File Offset: 0x00052A70
		public void Write(int value)
		{
			br br = this.a.b(11);
			br.c(value);
		}

		// Token: 0x0600057E RID: 1406 RVA: 0x00053A94 File Offset: 0x00052A94
		public virtual void Write_BI()
		{
			br br = this.a.b(3);
			br.a(66);
			br.a(73);
			br.f();
		}

		// Token: 0x0600057F RID: 1407 RVA: 0x00053AC8 File Offset: 0x00052AC8
		public void Write_ID()
		{
			br br = this.a.b(3);
			br.a(73);
			br.a(68);
			br.f();
		}

		// Token: 0x06000580 RID: 1408 RVA: 0x00053AFC File Offset: 0x00052AFC
		public virtual void Write_EI()
		{
			br br = this.a.b(3);
			br.a(69);
			br.a(73);
			br.f();
		}

		// Token: 0x06000581 RID: 1409 RVA: 0x00053B30 File Offset: 0x00052B30
		public void WriteName(byte[] name)
		{
			br br = this.a.b(name.Length + 1);
			br.a(47);
			br.a(name);
		}

		// Token: 0x06000582 RID: 1410 RVA: 0x00053B60 File Offset: 0x00052B60
		public void WriteName(byte name)
		{
			br br = this.a.b(2);
			br.a(47);
			br.a(name);
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x00053B8C File Offset: 0x00052B8C
		public void WriteNewLine()
		{
			br br = this.a.b(1);
			br.f();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x00053BB0 File Offset: 0x00052BB0
		internal zh s()
		{
			return this.a;
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x00053BC8 File Offset: 0x00052BC8
		internal new void a(zh A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x00053BD4 File Offset: 0x00052BD4
		internal bp t()
		{
			return this.b;
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x00053BEC File Offset: 0x00052BEC
		internal void u()
		{
			this.a = this.g.w();
			this.a.c();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x00053C0C File Offset: 0x00052C0C
		internal void v()
		{
			this.a = this.g.u();
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x00053C20 File Offset: 0x00052C20
		internal virtual void w()
		{
			this.SetGraphicsMode();
			if (this.f.CompressionLevel < 1 || this.f.CompressionLevel > 9)
			{
				this.b = this.a.b();
			}
			else
			{
				this.b = this.a.a(this.g.y());
			}
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x00053C90 File Offset: 0x00052C90
		internal bp x()
		{
			this.SetGraphicsMode();
			return this.a.b();
		}

		// Token: 0x0600058B RID: 1419 RVA: 0x00053CB4 File Offset: 0x00052CB4
		internal void y()
		{
			if (this.f.CompressionLevel < 1 || this.f.CompressionLevel > 9)
			{
				this.b = this.a.a(this.g.u().b());
			}
			else
			{
				this.b = this.a.a(this.g.u(), this.g.y());
			}
		}

		// Token: 0x0600058C RID: 1420 RVA: 0x00053D38 File Offset: 0x00052D38
		internal void z()
		{
			if (this.j)
			{
				br br = this.a.b(4);
				br.a(69);
				br.a(77);
				br.a(67);
				br.a(10);
				this.j = false;
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x00053D90 File Offset: 0x00052D90
		internal new void a(object A_0)
		{
			br br = this.a.b(A_0.ToString().Length + 1);
			br.a(47);
			br.a(new ASCIIEncoding().GetBytes(A_0.ToString()));
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x00053DD8 File Offset: 0x00052DD8
		internal new void h(float A_0)
		{
			br br = this.a.b(10);
			br.c(A_0);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x00053DFC File Offset: 0x00052DFC
		internal new void b(int A_0)
		{
			br br = this.a.b(21);
			br.a(60);
			br.a(60);
			br.a(47);
			br.a(77);
			br.a(67);
			br.a(73);
			br.a(68);
			br.a(32);
			br.c(A_0);
			br.a(62);
			br.a(62);
		}

		// Token: 0x06000590 RID: 1424 RVA: 0x00053E7C File Offset: 0x00052E7C
		internal void aa()
		{
			if (!this.j)
			{
				br br = this.a.b(4);
				br.a(66);
				br.a(68);
				br.a(67);
				br.a(10);
				this.j = true;
			}
		}

		// Token: 0x06000591 RID: 1425 RVA: 0x00053ED4 File Offset: 0x00052ED4
		internal void ab()
		{
			if (!this.j)
			{
				br br = this.a.b(4);
				br.a(66);
				br.a(77);
				br.a(67);
				br.a(10);
				this.j = true;
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x00053F2C File Offset: 0x00052F2C
		internal void ac()
		{
			br br = this.a.b(2);
			br.a(60);
			br.a(60);
		}

		// Token: 0x06000593 RID: 1427 RVA: 0x00053F5C File Offset: 0x00052F5C
		internal void ad()
		{
			br br = this.a.b(1);
			br.a(93);
		}

		// Token: 0x06000594 RID: 1428 RVA: 0x00053F80 File Offset: 0x00052F80
		internal void ae()
		{
			br br = this.a.b(1);
			br.a(91);
		}

		// Token: 0x06000595 RID: 1429 RVA: 0x00053FA4 File Offset: 0x00052FA4
		internal void af()
		{
			br br = this.a.b(2);
			br.a(62);
			br.a(62);
		}

		// Token: 0x06000596 RID: 1430 RVA: 0x00053FD4 File Offset: 0x00052FD4
		internal new void a(float A_0, float A_1, float A_2, float A_3)
		{
			br br = this.a.b(51);
			br.c(A_0);
			br.a(32);
			br.c(A_1);
			br.a(32);
			br.c(A_2);
			br.a(32);
			br.c(A_3);
			br.a(32);
			br.a(114);
			br.a(101);
			br.a(10);
			br.a(87);
			br.a(10);
			br.a(110);
			br.a(10);
		}

		// Token: 0x040002FA RID: 762
		private new zh a;

		// Token: 0x040002FB RID: 763
		private new bp b;

		// Token: 0x040002FC RID: 764
		private new Stack c = new Stack();

		// Token: 0x040002FD RID: 765
		private new PageWriterState d;

		// Token: 0x040002FE RID: 766
		private new AreaDimensions e;

		// Token: 0x040002FF RID: 767
		private new Document f;

		// Token: 0x04000300 RID: 768
		private new DocumentWriter g;

		// Token: 0x04000301 RID: 769
		private new bool h = false;

		// Token: 0x04000302 RID: 770
		private new int i = 0;

		// Token: 0x04000303 RID: 771
		private bool j = false;
	}
}
