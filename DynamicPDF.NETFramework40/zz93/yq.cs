using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B0 RID: 944
	internal class yq : yg
	{
		// Token: 0x06002813 RID: 10259 RVA: 0x00172070 File Offset: 0x00171070
		internal yq(TiffImageData A_0, yj A_1)
		{
			this.e = A_0;
			if (A_0.f()[0] == 32U)
			{
				throw new ImageParsingException("32 bit TIFF image is not supported.");
			}
			uint num = A_0.f()[0];
			for (int i = 1; i < A_0.f().Length; i++)
			{
				if (A_0.f()[i] != num)
				{
					throw new ImageParsingException("Tiff image with different bits per sample is not supported.");
				}
			}
			bool flag = false;
			uint[] array = null;
			uint[] array2 = null;
			uint num2 = 1U;
			byte[][] array3 = null;
			uint num3 = 0U;
			byte[] array4 = null;
			if (A_0.j() == 3)
			{
				A_0.a(2);
			}
			if (A_1.b(266U))
			{
				flag = (A_1.e() == 2);
			}
			if (A_1.b(273U))
			{
				array = A_1.k();
			}
			if (A_1.b(278U))
			{
				this.f = A_1.f();
			}
			if (A_1.b(279U))
			{
				array2 = A_1.k();
			}
			if (A_1.b(284U))
			{
				num2 = (uint)A_1.e();
			}
			if (A_1.b(317U))
			{
				this.h = (A_1.e() == 2);
			}
			if (A_1.b(320U))
			{
				this.d = A_1.n();
			}
			if (A_1.b(34665U))
			{
				num3 = A_1.i();
			}
			if (A_1.b(34675U))
			{
				array4 = A_1.m();
			}
			A_1.c(320U);
			if (this.f == 0U && array.Length == 1)
			{
				this.f = (uint)A_0.Height;
			}
			if (num2 == 2U)
			{
				array3 = new byte[array.Length][];
			}
			switch (A_0.j())
			{
			case 0:
				this.g = 1;
				goto IL_2B0;
			case 1:
				this.g = 1;
				goto IL_2B0;
			case 2:
				this.g = 3;
				goto IL_2B0;
			case 3:
				this.g = 1;
				goto IL_2B0;
			case 4:
				throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
			case 5:
				this.g = 4;
				goto IL_2B0;
			case 6:
				throw new ImageParsingException("YCbCr TIFF format is not supported.");
			case 8:
				this.g = 3;
				goto IL_2B0;
			}
			throw new ImageParsingException("Invalid TIFF PhotometricInterpretation.");
			IL_2B0:
			byte[] array5 = null;
			int num4 = 0;
			if ((long)this.g < (long)((ulong)A_0.e()))
			{
				if (A_0.j() != 2 && A_0.j() != 5 && A_0.j() != 1)
				{
					throw new ImageParsingException("TIFF Transparency mask can not be drawn.");
				}
				int num5 = (int)(A_0.e() - (uint)this.g);
				int num6 = 0;
				if (num5 > 0)
				{
					if (num5 != 1)
					{
						throw new ImageParsingException("TIFF Transparency mask can not be drawn (extra bytes > 1).");
					}
					if (A_1.b(338U))
					{
						num6 = (int)A_1.e();
					}
				}
				if (A_1.e() == 1)
				{
					this.b = true;
				}
				byte[] array6 = null;
				int num7 = 0;
				if (A_0.j() == 2)
				{
					if (A_0.f()[0] == 16U)
					{
						array6 = new byte[A_0.Width * A_0.Height * 2];
						array5 = new byte[array6.Length * 3 * 2];
					}
					else if (A_0.f()[0] == 8U)
					{
						array6 = new byte[A_0.Width * A_0.Height];
						array5 = new byte[array6.Length * 3];
					}
				}
				else if (A_0.j() == 1)
				{
					if (A_0.f()[0] == 8U)
					{
						array6 = new byte[A_0.Width * A_0.Height];
						array5 = new byte[array6.Length * 2];
					}
				}
				else if (A_0.j() == 5)
				{
					if (A_0.f()[0] == 16U)
					{
						array6 = new byte[A_0.Width * A_0.Height * 2];
						array5 = new byte[array6.Length * 4 * 2];
					}
					else if (A_0.f()[0] == 8U)
					{
						array6 = new byte[A_0.Width * A_0.Height];
						array5 = new byte[array6.Length * 4];
					}
				}
				for (int i = 0; i < array.Length; i++)
				{
					int num8 = (int)A_0.e();
					byte[] array7;
					if (array2 == null)
					{
						array7 = new byte[A_1.p() - (int)array[i]];
					}
					else
					{
						array7 = new byte[array2[i]];
					}
					A_1.a(array[i], array7, 0, array7.Length);
					if (flag)
					{
						base.a(array7);
					}
					zd zd;
					if (i == array.Length - 1 && (long)A_0.Height % (long)((ulong)this.f) != 0L)
					{
						zd = new zd(array7, (int)((long)A_0.Width * ((long)A_0.Height % (long)((ulong)this.f)) * (long)num8));
					}
					else
					{
						zd = new zd(array7, (int)((long)A_0.Width * (long)((ulong)this.f) * (long)num8));
					}
					byte[] array8 = zd.d();
					int j = 0;
					if (A_0.j() == 2)
					{
						while (j < array8.Length && num7 < array6.Length)
						{
							array5[num4++] = array8[j++];
							array5[num4++] = array8[j++];
							array5[num4++] = array8[j++];
							array6[num7++] = array8[j++];
						}
					}
					else if (A_0.j() == 1)
					{
						while (j < array8.Length && num7 < array6.Length)
						{
							array5[num4++] = array8[j++];
							array6[num7++] = array8[j++];
						}
					}
					else if (A_0.j() == 5)
					{
						if (A_0.f()[0] == 8U)
						{
							if (num6 == 0)
							{
								while (j < array8.Length)
								{
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									j++;
								}
							}
							else
							{
								while (j < array8.Length)
								{
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array6[num7++] = array8[j++];
								}
							}
						}
						else if (A_0.f()[0] == 16U)
						{
							if (num6 == 0)
							{
								while (j < array8.Length)
								{
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									j += 2;
								}
							}
							else
							{
								while (j < array8.Length && num7 < array6.Length)
								{
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array5[num4++] = array8[j++];
									array6[num7++] = array8[j++];
									array6[num7++] = array8[j++];
								}
							}
						}
					}
				}
				if (num6 == 1)
				{
					this.a = y0.a(array6, 0, array6.Length);
				}
			}
			else
			{
				int num9 = 0;
				if (A_0.f()[0] == 8U)
				{
					array5 = new byte[A_0.Width * A_0.Height * this.g];
				}
				else if (A_0.f()[0] == 16U)
				{
					array5 = new byte[A_0.Width * A_0.Height * this.g * 2];
				}
				else if (A_0.f()[0] == 1U)
				{
					num9 = A_0.Width / 8;
					if (A_0.Width % 8 != 0)
					{
						num9++;
					}
					array5 = new byte[num9 * A_0.Height];
				}
				else if (A_0.f()[0] == 4U)
				{
					array5 = new byte[A_0.Width * A_0.Height * this.g];
				}
				for (int i = 0; i < array.Length; i++)
				{
					byte[] array7;
					if (array2 == null)
					{
						array7 = new byte[A_1.p() - (int)array[i]];
					}
					else
					{
						array7 = new byte[array2[i]];
					}
					A_1.a(array[i], array7, 0, array7.Length);
					if (flag)
					{
						base.a(array7);
					}
					zd zd = null;
					if (i == array.Length - 1 && (long)A_0.Height % (long)((ulong)this.f) != 0L)
					{
						if (A_0.f()[0] == 8U)
						{
							zd = new zd(array7, (int)((long)A_0.Width * ((long)A_0.Height % (long)((ulong)this.f)) * (long)this.g));
						}
						else if (A_0.f()[0] == 16U)
						{
							zd = new zd(array7, (int)((long)A_0.Width * ((long)A_0.Height % (long)((ulong)this.f)) * (long)this.g * 2L));
						}
						else if (A_0.f()[0] == 1U)
						{
							zd = new zd(array7, (int)((long)num9 * (long)((ulong)this.f)));
						}
						else if (A_0.f()[0] == 4U)
						{
							zd = new zd(array7, (int)((long)A_0.Width * ((long)A_0.Height % (long)((ulong)this.f)) * (long)this.g));
						}
					}
					else if (A_0.f()[0] == 8U)
					{
						zd = new zd(array7, (int)((long)A_0.Width * (long)((ulong)this.f) * (long)this.g));
					}
					else if (A_0.f()[0] == 16U)
					{
						zd = new zd(array7, (int)((long)A_0.Width * (long)((ulong)this.f) * (long)this.g * 2L));
					}
					else if (A_0.f()[0] == 1U)
					{
						zd = new zd(array7, (int)((long)num9 * (long)((ulong)this.f)));
					}
					else if (A_0.f()[0] == 4U)
					{
						zd = new zd(array7, (int)((long)A_0.Width * (long)((ulong)this.f) * (long)this.g));
					}
					if (num2 == 2U && A_0.j() == 2)
					{
						array3[i] = new byte[zd.e()];
						Array.Copy(zd.d(), 0, array3[i], num4, zd.e());
					}
					else
					{
						Array.Copy(zd.d(), 0, array5, num4, zd.e());
						num4 += zd.e();
					}
				}
				if (num2 == 2U && A_0.j() == 2)
				{
					for (int i = 0; i < array.Length / 3; i++)
					{
						int num10 = 0;
						for (int k = 0; k < array3[0].Length; k++)
						{
							array5[num4++] = array3[i][num10];
							array5[num4++] = array3[i + array.Length / 3][num10];
							array5[num4++] = array3[i + 2 * (array.Length / 3)][num10];
							num10++;
						}
					}
				}
			}
			if (A_0.i() && num == 16U)
			{
				byte[] array9 = new byte[array5.Length];
				for (int i = 0; i < array5.Length; i += 2)
				{
					array9[i] = array5[i + 1];
					array9[i + 1] = array5[i];
				}
				this.c = y0.a(array9, 0, num4);
			}
			else
			{
				this.c = y0.a(array5, 0, num4);
			}
			if (array4 != null)
			{
				this.n = new bn(array4);
			}
			if (num3 != 0U)
			{
				this.o = A_1.d(num3);
			}
			if (this.a != null && (this.n != null || this.o == 1))
			{
				A_0.a(2);
			}
		}

		// Token: 0x06002814 RID: 10260 RVA: 0x00172FA8 File Offset: 0x00171FA8
		internal override byte[] gx()
		{
			return this.c;
		}

		// Token: 0x06002815 RID: 10261 RVA: 0x00172FC0 File Offset: 0x00171FC0
		internal override void gy(DocumentWriter A_0)
		{
			A_0.WriteBeginObject();
			A_0.WriteDictionaryOpen();
			A_0.WriteName(yg.g);
			A_0.WriteName(yg.k);
			A_0.WriteName(yg.h);
			A_0.WriteName(yg.l);
			if (this.e.Interpolate)
			{
				A_0.WriteName(yg.a);
				A_0.WriteBoolean(true);
			}
			A_0.WriteName(yg.b);
			A_0.WriteNumber(this.e.Width);
			A_0.WriteName(yg.c);
			A_0.WriteNumber(this.e.Height);
			A_0.WriteName(yg.d);
			A_0.WriteNumber(this.e.f()[0]);
			switch (this.e.j())
			{
			case 0:
				A_0.WriteName(yg.t);
				A_0.WriteArrayOpen();
				A_0.WriteNumber1();
				A_0.WriteNumber0();
				A_0.WriteArrayClose();
				break;
			case 1:
				break;
			case 2:
				A_0.WriteName(yg.e);
				if (this.n != null && this.n.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.n.a());
					A_0.WriteArrayClose();
				}
				else if (this.o == 1)
				{
					byte[] iccProfile = (byte[])Document.a.GetObject("sRGBColorSpaceProfile");
					IccProfile resource = new IccProfile(iccProfile);
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(resource);
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				A_0.WriteName(yg.p);
				A_0.WriteArrayOpen();
				A_0.WriteDictionaryOpen();
				if (this.h)
				{
					A_0.WriteName(yq.l);
					A_0.WriteNumber(2);
				}
				A_0.WriteName(yg.v);
				A_0.WriteNumber(3);
				A_0.WriteName(yg.o);
				A_0.WriteNumber(this.e.Width);
				A_0.WriteDictionaryClose();
				A_0.WriteArrayClose();
				goto IL_5E5;
			case 3:
				A_0.WriteName(yg.e);
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.w);
				if (this.n != null && this.n.b() == 3)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.n.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.r);
				}
				A_0.WriteNumber(this.d.Length / 3 - 1);
				A_0.WriteReference(A_0.GetObjectNumber(1));
				A_0.WriteArrayClose();
				A_0.WriteName(yg.p);
				A_0.WriteArrayOpen();
				A_0.WriteDictionaryOpen();
				if (this.h)
				{
					A_0.WriteName(yq.l);
					A_0.WriteNumber(2);
				}
				A_0.WriteName(yg.o);
				A_0.WriteNumber(this.e.Width);
				A_0.WriteDictionaryClose();
				A_0.WriteArrayClose();
				goto IL_5E5;
			case 4:
			case 6:
			case 7:
				goto IL_5DA;
			case 5:
				A_0.WriteName(yg.e);
				if (this.n != null && this.n.b() == 4)
				{
					A_0.WriteArrayOpen();
					A_0.WriteName(yg.x);
					A_0.WriteReference(this.n.a());
					A_0.WriteArrayClose();
				}
				else
				{
					A_0.WriteName(yg.s);
				}
				A_0.WriteName(yg.p);
				A_0.WriteArrayOpen();
				A_0.WriteDictionaryOpen();
				if (this.h)
				{
					A_0.WriteName(yq.l);
					A_0.WriteNumber(2);
				}
				A_0.WriteName(yg.v);
				A_0.WriteNumber(4);
				A_0.WriteName(yg.o);
				A_0.WriteNumber(this.e.Width);
				A_0.WriteDictionaryClose();
				A_0.WriteArrayClose();
				goto IL_5E5;
			case 8:
				A_0.WriteName(yg.e);
				A_0.WriteName(yg.u);
				A_0.WriteName(yg.p);
				A_0.WriteArrayOpen();
				A_0.WriteDictionaryOpen();
				if (this.h)
				{
					A_0.WriteName(yq.l);
					A_0.WriteNumber(2);
				}
				A_0.WriteName(yg.v);
				A_0.WriteNumber(3);
				A_0.WriteName(yg.o);
				A_0.WriteNumber(this.e.Width);
				A_0.WriteDictionaryClose();
				A_0.WriteArrayClose();
				goto IL_5E5;
			default:
				goto IL_5DA;
			}
			A_0.WriteName(yg.e);
			if (this.n != null && this.n.b() == 1)
			{
				A_0.WriteArrayOpen();
				A_0.WriteName(yg.x);
				A_0.WriteReference(this.n.a());
				A_0.WriteArrayClose();
			}
			else
			{
				A_0.WriteName(yg.f);
			}
			A_0.WriteName(yg.p);
			A_0.WriteArrayOpen();
			A_0.WriteDictionaryOpen();
			if (this.h)
			{
				A_0.WriteName(yq.l);
				A_0.WriteNumber(2);
			}
			A_0.WriteName(yg.o);
			A_0.WriteNumber(this.e.Width);
			A_0.WriteDictionaryClose();
			A_0.WriteArrayClose();
			goto IL_5E5;
			IL_5DA:
			throw new ImageParsingException("Invalid TIFF PhotometricInterpretation.");
			IL_5E5:
			if (this.a != null)
			{
				A_0.WriteName(ImageData.l);
				A_0.WriteReference(A_0.GetObjectNumber(1));
			}
			A_0.WriteName(yg.i);
			A_0.WriteArrayOpen();
			A_0.WriteName(yq.m);
			A_0.WriteArrayClose();
			A_0.WriteName(yg.j);
			A_0.ai(this.c.Length);
			A_0.WriteDictionaryClose();
			A_0.WriteStream(this.c, this.c.Length);
			A_0.WriteEndObject();
			if (this.a != null)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(yg.g);
				A_0.WriteName(yg.k);
				A_0.WriteName(Resource.b);
				A_0.WriteName(yg.l);
				A_0.WriteName(yg.b);
				A_0.WriteNumber(this.e.Width);
				A_0.WriteName(yg.c);
				A_0.WriteNumber(this.e.Height);
				A_0.WriteName(yg.d);
				A_0.WriteNumber(8);
				A_0.WriteName(yg.e);
				A_0.WriteName(yg.f);
				if (this.e.j() == 1)
				{
					A_0.WriteName(yg.t);
					A_0.WriteArrayOpen();
					A_0.WriteNumber1();
					A_0.WriteNumber0();
					A_0.WriteArrayClose();
				}
				if (this.h)
				{
					A_0.WriteName(yg.p);
					A_0.WriteArrayOpen();
					A_0.WriteDictionaryOpen();
					A_0.WriteName(yq.l);
					A_0.WriteNumber(2);
					A_0.WriteName(yg.v);
					A_0.WriteNumber(1);
					A_0.WriteName(yg.o);
					A_0.WriteNumber(this.e.Width);
					A_0.WriteDictionaryClose();
					A_0.WriteArrayClose();
				}
				if (this.b)
				{
					switch (this.e.j())
					{
					case 0:
						A_0.WriteName(yq.i);
						break;
					case 1:
						A_0.WriteName(yq.i);
						break;
					case 2:
						A_0.WriteName(yq.j);
						break;
					case 3:
						A_0.WriteName(yq.j);
						break;
					case 5:
						A_0.WriteName(yq.k);
						break;
					case 8:
						A_0.WriteName(yq.j);
						break;
					}
				}
				A_0.WriteName(yg.i);
				A_0.WriteArrayOpen();
				A_0.WriteName(yq.m);
				A_0.WriteArrayClose();
				A_0.WriteName(yg.j);
				A_0.ai(this.a.Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.a, this.a.Length);
				A_0.WriteEndObject();
			}
			if (this.d != null)
			{
				A_0.WriteBeginObject();
				A_0.WriteDictionaryOpen();
				A_0.WriteName(yg.j);
				A_0.ai(this.d.Length);
				A_0.WriteDictionaryClose();
				A_0.WriteStream(this.d, this.d.Length);
				A_0.WriteEndObject();
			}
		}

		// Token: 0x04001185 RID: 4485
		private new byte[] a = null;

		// Token: 0x04001186 RID: 4486
		private new bool b = false;

		// Token: 0x04001187 RID: 4487
		private new byte[] c = null;

		// Token: 0x04001188 RID: 4488
		private new byte[] d = null;

		// Token: 0x04001189 RID: 4489
		private new TiffImageData e;

		// Token: 0x0400118A RID: 4490
		private new uint f = 0U;

		// Token: 0x0400118B RID: 4491
		private new int g;

		// Token: 0x0400118C RID: 4492
		private new bool h;

		// Token: 0x0400118D RID: 4493
		private new static byte[] i = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			93
		};

		// Token: 0x0400118E RID: 4494
		private new static byte[] j = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			32,
			48,
			32,
			48,
			93
		};

		// Token: 0x0400118F RID: 4495
		private new static byte[] k = new byte[]
		{
			77,
			97,
			116,
			116,
			101,
			91,
			48,
			32,
			48,
			32,
			48,
			32,
			48,
			93
		};

		// Token: 0x04001190 RID: 4496
		private new static byte[] l = new byte[]
		{
			80,
			114,
			101,
			100,
			105,
			99,
			116,
			111,
			114
		};

		// Token: 0x04001191 RID: 4497
		private new static byte[] m = new byte[]
		{
			70,
			108,
			97,
			116,
			101,
			68,
			101,
			99,
			111,
			100,
			101
		};

		// Token: 0x04001192 RID: 4498
		private new bn n = null;

		// Token: 0x04001193 RID: 4499
		private new int o = 0;
	}
}
