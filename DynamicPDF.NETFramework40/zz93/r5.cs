using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Security;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;
using ceTe.DynamicPDF.Text;

namespace zz93
{
	// Token: 0x020002B8 RID: 696
	internal class r5 : Encoder, IDisposable
	{
		// Token: 0x06001FF1 RID: 8177 RVA: 0x0013B0E2 File Offset: 0x0013A0E2
		internal r5() : base(false)
		{
		}

		// Token: 0x06001FF2 RID: 8178 RVA: 0x0013B111 File Offset: 0x0013A111
		public void Dispose()
		{
			this.a(true);
			GC.SuppressFinalize(this);
		}

		// Token: 0x06001FF3 RID: 8179 RVA: 0x0013B124 File Offset: 0x0013A124
		~r5()
		{
			this.a(false);
		}

		// Token: 0x06001FF4 RID: 8180 RVA: 0x0013B158 File Offset: 0x0013A158
		[SecuritySafeCritical]
		protected virtual void a(bool A_0)
		{
			if (!this.h)
			{
				if (this.d != IntPtr.Zero)
				{
					aeo.a(this.d);
				}
				if (this.e != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(this.e);
				}
				this.h = true;
			}
		}

		// Token: 0x06001FF5 RID: 8181 RVA: 0x0013B1C3 File Offset: 0x0013A1C3
		public override void DrawEncoding(DocumentWriter writer)
		{
			writer.WriteName(Encoder.i);
			writer.WriteName(r5.g);
		}

		// Token: 0x06001FF6 RID: 8182 RVA: 0x0013B1DE File Offset: 0x0013A1DE
		internal void a(ad1 A_0)
		{
			this.a = A_0.w().b();
			this.b = A_0.w().c();
			this.c = A_0.x();
		}

		// Token: 0x06001FF7 RID: 8183 RVA: 0x0013B20F File Offset: 0x0013A20F
		internal void b(bool A_0)
		{
			this.f = A_0;
		}

		// Token: 0x06001FF8 RID: 8184 RVA: 0x0013B21C File Offset: 0x0013A21C
		internal bool a()
		{
			return this.f;
		}

		// Token: 0x06001FF9 RID: 8185 RVA: 0x0013B234 File Offset: 0x0013A234
		[SecuritySafeCritical]
		internal void a(byte[] A_0)
		{
			try
			{
				this.e = IntPtr.Zero;
				this.e = Marshal.AllocHGlobal(A_0.Length);
				if (!(this.e != IntPtr.Zero))
				{
					throw new GeneratorException("Unable to create the required memory for character shapping.");
				}
				Marshal.Copy(A_0, 0, this.e, A_0.Length);
				this.d = aeo.a(this.e, (uint)A_0.Length);
				if (this.d == IntPtr.Zero)
				{
					throw new GeneratorException("Unable to load character shapping module. Please make sure DPDNative_XXX library is deployed");
				}
			}
			catch (Exception ex)
			{
				throw new GeneratorException(ex.Message);
			}
		}

		// Token: 0x06001FFA RID: 8186 RVA: 0x0013B2EC File Offset: 0x0013A2EC
		public override byte[] Encode(FontSubsetter subsetter, char[] text, int start, int length, bool rightToLeft)
		{
			byte[] array = new byte[length * 2];
			if (rightToLeft)
			{
				int num = start + length - 1;
				for (int i = 0; i < length; i++)
				{
					ushort num2 = (ushort)this.a[(int)text[num--]];
					subsetter.GlyphUsed((int)num2);
					array[i * 2] = (byte)(num2 >> 8);
					array[i * 2 + 1] = (byte)num2;
				}
			}
			else
			{
				int num = start;
				for (int i = 0; i < length; i++)
				{
					char c = this.a[(int)text[num++]];
					subsetter.GlyphUsed((int)c);
					array[i * 2] = (byte)(c >> 8);
					array[i * 2 + 1] = (byte)c;
				}
			}
			return array;
		}

		// Token: 0x06001FFB RID: 8187 RVA: 0x0013B3A8 File Offset: 0x0013A3A8
		internal char a(int A_0)
		{
			char result;
			if (A_0 < this.b.Length)
			{
				result = this.b[A_0];
			}
			else
			{
				result = '\0';
			}
			return result;
		}

		// Token: 0x06001FFC RID: 8188 RVA: 0x0013B3D8 File Offset: 0x0013A3D8
		internal override int fl()
		{
			return 2;
		}

		// Token: 0x06001FFD RID: 8189 RVA: 0x0013B3EC File Offset: 0x0013A3EC
		internal override void fm(br A_0, FontSubsetter A_1, char[] A_2, int A_3, int A_4, bool A_5)
		{
			A_0.g();
			if (A_5)
			{
				for (int i = A_3 + A_4 - 1; i >= A_3; i--)
				{
					char c = this.a[(int)A_2[i]];
					A_1.GlyphUsed((int)c);
					A_0.b((byte)(c >> 8));
					A_0.b((byte)c);
				}
			}
			else
			{
				for (int i = A_3; i < A_3 + A_4; i++)
				{
					char c = this.a[(int)A_2[i]];
					A_1.GlyphUsed((int)c);
					A_0.b((byte)(c >> 8));
					A_0.b((byte)c);
				}
			}
			A_0.h();
		}

		// Token: 0x06001FFE RID: 8190 RVA: 0x0013B498 File Offset: 0x0013A498
		internal void a(br A_0, FontSubsetter A_1, agd A_2, int A_3, int A_4)
		{
			A_0.g();
			for (int i = A_3; i < A_3 + A_4; i++)
			{
				agc agc = A_2.a(i);
				A_1.GlyphUsed(agc.a());
				A_0.b((byte)(agc.a() >> 8));
				A_0.b((byte)agc.a());
			}
			A_0.h();
		}

		// Token: 0x06001FFF RID: 8191 RVA: 0x0013B500 File Offset: 0x0013A500
		internal agd a(char[] A_0, int A_1, int A_2, bool A_3)
		{
			bool flag = true;
			agd agd;
			if (this.d == IntPtr.Zero)
			{
				agd = new agd(A_2 - A_1, this.b);
				int a_ = 0;
				for (int i = A_1; i < A_2; i++)
				{
					agd.a(a_++, new agc((int)this.a[(int)A_0[i]], a_, 0, 0, 0, 0));
				}
			}
			else if (A_0 == null || A_0.Length == 0)
			{
				agd = new agd(0, this.b);
			}
			else
			{
				List<object[]> list = new List<object[]>();
				List<agf> a_2 = new List<agf>();
				int num = 0;
				KeyValuePair<uint, agf> a_3 = age.a(A_0[A_1]);
				bool flag2 = this.a(a_3.Key);
				int a_4 = A_1;
				int num2 = 1;
				for (int i = A_1 + 1; i < A_2; i++)
				{
					if (A_0[i] == '\r' || A_0[i] == '\n')
					{
						if (num2 > 0)
						{
							this.a(A_0, ref list, ref a_2, ref num, a_3, flag2, a_4, num2);
							List<object[]> list2 = list;
							object[] item = new object[1];
							list2.Add(item);
							num++;
						}
						else if (A_0[i] != '\n' || A_0[i - 1] != '\r')
						{
							List<object[]> list3 = list;
							object[] item = new object[1];
							list3.Add(item);
							num++;
						}
						if (flag2)
						{
							a_3 = age.a();
							flag2 = false;
						}
						a_4 = i + 1;
						num2 = 0;
					}
					else if ((int)A_0[i] >= a_3.Value.a() && (int)A_0[i] <= a_3.Value.b())
					{
						num2++;
					}
					else if ((!flag2 && r5.b(A_0[i])) || (flag2 && r5.a(A_0[i])))
					{
						num2++;
					}
					else
					{
						KeyValuePair<uint, agf> keyValuePair = age.a(A_0[i]);
						if (keyValuePair.Key != age.c || flag2)
						{
							this.a(A_0, ref list, ref a_2, ref num, a_3, flag2, a_4, num2);
							a_3 = keyValuePair;
							flag2 = this.a(a_3.Key);
							a_4 = i;
							num2 = 1;
						}
						else
						{
							num2++;
						}
					}
					if (flag2 && this.a(A_0, i))
					{
						this.a(ref A_0, A_2, ref flag, ref a_3, ref flag2, ref num2, ref i, false);
					}
				}
				this.a(A_0, ref list, ref a_2, ref num, a_3, flag2, a_4, num2);
				agd = this.a(A_3, list, num);
				agd.a(a_2);
			}
			return agd;
		}

		// Token: 0x06002000 RID: 8192 RVA: 0x0013B7DC File Offset: 0x0013A7DC
		internal agd a(char[] A_0, int A_1, int A_2, ref int A_3)
		{
			agd result;
			if (this.d == IntPtr.Zero)
			{
				agd agd = new agd(A_2, this.b);
				int a_ = 0;
				for (int i = A_1; i < A_1 + A_2; i++)
				{
					agd.a(a_++, new agc((int)this.a[(int)A_0[i]], a_, 0, 0, 0, 0));
				}
				A_3 = A_1 + A_2;
				result = agd;
			}
			else
			{
				bool flag = true;
				List<object[]> list = new List<object[]>();
				List<agf> a_2 = new List<agf>();
				int num = 0;
				KeyValuePair<uint, agf> a_3 = age.a(A_0[A_1]);
				bool flag2 = this.a(a_3.Key);
				int a_4 = A_1;
				int num2 = 1;
				List<int> list2 = new List<int>();
				for (int i = A_1 + 1; i < A_1 + A_2; i++)
				{
					if (A_0[i] == '\r' || A_0[i] == '\n')
					{
						if (num2 > 0)
						{
							this.a(A_0, ref list, ref a_2, ref num, a_3, flag2, a_4, num2);
							List<object[]> list3 = list;
							object[] item = new object[1];
							list3.Add(item);
							num++;
						}
						else if (A_0[i] != '\n' || A_0[i - 1] != '\r')
						{
							List<object[]> list4 = list;
							object[] item = new object[1];
							list4.Add(item);
							num++;
						}
						if (flag2)
						{
							a_3 = age.a();
							flag2 = false;
						}
						a_4 = i + 1;
						num2 = 0;
					}
					else if ((int)A_0[i] >= a_3.Value.a() && (int)A_0[i] <= a_3.Value.b())
					{
						num2++;
					}
					else if (A_0[i] <= '@')
					{
						if ((!flag2 && r5.b(A_0[i])) || (flag2 && r5.a(A_0[i])))
						{
							num2++;
						}
					}
					else
					{
						if (age.a(A_0[i]).Key != age.c && !flag2)
						{
							A_3 = i;
							break;
						}
						num2++;
					}
					if (flag2 && this.a(A_0, i))
					{
						this.a(ref A_0, A_2, ref flag, ref a_3, ref flag2, ref num2, ref i, true);
					}
				}
				this.a(A_0, ref list, ref a_2, ref num, a_3, flag2, a_4, num2);
				agd agd = this.a(true, list, num);
				agd.a(a_2);
				result = agd;
			}
			return result;
		}

		// Token: 0x06002001 RID: 8193 RVA: 0x0013BA84 File Offset: 0x0013AA84
		private agd a(bool A_0, List<object[]> A_1, int A_2)
		{
			agd agd;
			if (A_1.Count > 0)
			{
				agd = new agd(A_2, this.b);
				int num = 0;
				for (int i = 0; i < A_1.Count; i++)
				{
					object[] array = A_1[i];
					int num2 = 0;
					for (int j = 0; j < array.Length; j++)
					{
						if (array[j] != null)
						{
							int num3 = ((agc)array[j]).e();
							if (num3 != 0)
							{
								if (j > 0 && agd.a(num - 1).a() >= 0)
								{
									num3 = this.c.a(num3, agd.a(num - 1).a());
								}
								else
								{
									num3 = 0;
								}
							}
							agd.a(num, new agc(((agc)array[j]).a(), ((agc)array[j]).b(), 0, 0, num3 - num2, 0));
							num2 = num3;
						}
						else if (A_0)
						{
							agd.a(num, new agc(-1, 1, 0, 0, 0, 0));
						}
						else
						{
							agd.a(num, new agc(0, 1, 0, 0, 0, 0));
						}
						num++;
					}
				}
			}
			else
			{
				agd = null;
			}
			return agd;
		}

		// Token: 0x06002002 RID: 8194 RVA: 0x0013BBFC File Offset: 0x0013ABFC
		private void a(ref char[] A_0, int A_1, ref bool A_2, ref KeyValuePair<uint, agf> A_3, ref bool A_4, ref int A_5, ref int A_6, bool A_7)
		{
			bool flag = A_5 == 1;
			int num = A_6;
			A_6++;
			A_5++;
			if (A_7)
			{
				A_1 = A_0.Length;
			}
			while (A_6 < A_1 && this.a(A_0, A_6))
			{
				A_6++;
				A_5++;
			}
			int num2 = A_6 - num;
			if (num2 > 1)
			{
				if (flag)
				{
					if (A_6 < A_1 && (int)A_0[A_6] >= A_3.Value.a() && (int)A_0[A_6] <= A_3.Value.b())
					{
						if (A_2)
						{
							A_0 = (char[])A_0.Clone();
							A_2 = false;
						}
						Array.Reverse(A_0, num, A_6 - num);
					}
					else
					{
						A_3 = age.a();
						A_4 = false;
					}
				}
				else
				{
					if (A_2)
					{
						A_0 = (char[])A_0.Clone();
						A_2 = false;
					}
					Array.Reverse(A_0, num, A_6 - num);
				}
			}
			A_6--;
			A_5--;
		}

		// Token: 0x06002003 RID: 8195 RVA: 0x0013BD48 File Offset: 0x0013AD48
		private void a(char[] A_0, ref List<object[]> A_1, ref List<agf> A_2, ref int A_3, KeyValuePair<uint, agf> A_4, bool A_5, int A_6, int A_7)
		{
			if (A_7 > 0)
			{
				string a_ = new string(A_0, A_6, A_7);
				object[] array = this.a(a_, A_4.Key);
				A_1.Add(array);
				A_3 += array.Length;
				if (A_5)
				{
					A_2.Add(new agf(A_3 - array.Length, A_3 - 1));
				}
			}
		}

		// Token: 0x06002004 RID: 8196 RVA: 0x0013BDB4 File Offset: 0x0013ADB4
		private bool c(char A_0)
		{
			return (A_0 >= '0' && A_0 <= '9') || (A_0 >= '٠' && A_0 <= '٩') || (A_0 >= '۰' && A_0 <= '۹');
		}

		// Token: 0x06002005 RID: 8197 RVA: 0x0013BE04 File Offset: 0x0013AE04
		private bool a(char[] A_0, int A_1)
		{
			bool result;
			if (this.c(A_0[A_1]))
			{
				result = true;
			}
			else
			{
				bool flag = false;
				char c = A_0[A_1];
				switch (c)
				{
				case '\'':
				case ',':
				case '-':
				case '.':
				case '/':
					break;
				case '(':
				case ')':
				case '*':
				case '+':
					goto IL_56;
				default:
					if (c != '\\')
					{
						goto IL_56;
					}
					break;
				}
				flag = true;
				IL_56:
				if (flag)
				{
					if ((A_1 > 0 && this.c(A_0[A_1 - 1])) || (A_1 + 1 < A_0.Length && this.c(A_0[A_1 + 1])))
					{
						return true;
					}
				}
				result = false;
			}
			return result;
		}

		// Token: 0x06002006 RID: 8198 RVA: 0x0013BEB0 File Offset: 0x0013AEB0
		private bool a(uint A_0)
		{
			return A_0 == age.d || A_0 == age.o || A_0 == age.a7;
		}

		// Token: 0x06002007 RID: 8199 RVA: 0x0013BEEC File Offset: 0x0013AEEC
		[SecuritySafeCritical]
		private agc[] a(string A_0, uint A_1)
		{
			agc[] array = null;
			IntPtr intPtr = IntPtr.Zero;
			try
			{
				intPtr = Marshal.StringToHGlobalUni(A_0);
				if (!(intPtr != IntPtr.Zero))
				{
					throw new GeneratorException("Unable to create the required memory for process string.");
				}
				IntPtr intPtr2 = IntPtr.Zero;
				try
				{
					intPtr2 = aeo.a(intPtr, A_1, this.d, (uint)A_0.Length);
					int num = aeo.c(intPtr2);
					aeg[] array2 = new aeg[num];
					aeh[] array3 = new aeh[num];
					aeo.a(array2, intPtr2);
					aeo.a(array3, intPtr2);
					array = new agc[num];
					for (int i = 0; i < num; i++)
					{
						array[i] = new agc((int)array2[i].a, (int)array2[i].c, (int)array3[i].a, (int)array3[i].b, (int)array3[i].c, (int)array3[i].d);
					}
				}
				finally
				{
					if (intPtr2 != IntPtr.Zero)
					{
						aeo.b(intPtr2);
					}
				}
			}
			finally
			{
				if (intPtr != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(intPtr);
				}
			}
			return array;
		}

		// Token: 0x06002008 RID: 8200 RVA: 0x0013C074 File Offset: 0x0013B074
		private static bool b(char A_0)
		{
			return A_0 < '\u007f' || (A_0 >= '\u2000' && A_0 <= '‟');
		}

		// Token: 0x06002009 RID: 8201 RVA: 0x0013C0B4 File Offset: 0x0013B0B4
		private static bool a(char A_0)
		{
			switch (A_0)
			{
			case '\t':
			case ' ':
			case '!':
			case '"':
			case '#':
			case '$':
			case '%':
			case '\'':
			case '*':
			case '+':
			case ',':
			case '-':
			case '.':
			case '/':
			case '0':
			case '1':
			case '2':
			case '3':
			case '4':
			case '5':
			case '6':
			case '7':
			case '8':
			case '9':
			case ':':
			case ';':
			case '<':
			case '>':
			case '@':
				break;
			case '\n':
			case '\v':
			case '\f':
			case '\r':
			case '\u000e':
			case '\u000f':
			case '\u0010':
			case '\u0011':
			case '\u0012':
			case '\u0013':
			case '\u0014':
			case '\u0015':
			case '\u0016':
			case '\u0017':
			case '\u0018':
			case '\u0019':
			case '\u001a':
			case '\u001b':
			case '\u001c':
			case '\u001d':
			case '\u001e':
			case '\u001f':
			case '&':
			case '(':
			case ')':
			case '=':
			case '?':
				goto IL_FC;
			default:
				if (A_0 != '\\' && A_0 != '~')
				{
					goto IL_FC;
				}
				break;
			}
			return true;
			IL_FC:
			return A_0 >= '\u2000' && A_0 <= '‟';
		}

		// Token: 0x04000DD4 RID: 3540
		private char[] a = null;

		// Token: 0x04000DD5 RID: 3541
		private char[] b = null;

		// Token: 0x04000DD6 RID: 3542
		private adr c = null;

		// Token: 0x04000DD7 RID: 3543
		private IntPtr d;

		// Token: 0x04000DD8 RID: 3544
		private IntPtr e;

		// Token: 0x04000DD9 RID: 3545
		private bool f = false;

		// Token: 0x04000DDA RID: 3546
		private static byte[] g = new byte[]
		{
			73,
			100,
			101,
			110,
			116,
			105,
			116,
			121,
			45,
			72
		};

		// Token: 0x04000DDB RID: 3547
		private bool h = false;
	}
}
