using System;

namespace zz93
{
	// Token: 0x020000E4 RID: 228
	internal class fg : fd
	{
		// Token: 0x06000A1D RID: 2589 RVA: 0x000825AA File Offset: 0x000815AA
		internal fg()
		{
			this.a = new fb<fu>[20];
		}

		// Token: 0x06000A1E RID: 2590 RVA: 0x000825E8 File Offset: 0x000815E8
		internal fg(gi A_0)
		{
			this.a = new fb<fu>[20];
			this.cw(A_0);
		}

		// Token: 0x06000A1F RID: 2591 RVA: 0x00082638 File Offset: 0x00081638
		internal fb<fu>[] a()
		{
			return this.a;
		}

		// Token: 0x06000A20 RID: 2592 RVA: 0x00082650 File Offset: 0x00081650
		internal void a(fb<fu>[] A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06000A21 RID: 2593 RVA: 0x0008265C File Offset: 0x0008165C
		internal override int cv()
		{
			return 148235845;
		}

		// Token: 0x06000A22 RID: 2594 RVA: 0x00082674 File Offset: 0x00081674
		internal override bool ct()
		{
			return this.d;
		}

		// Token: 0x06000A23 RID: 2595 RVA: 0x0008268C File Offset: 0x0008168C
		internal override void cu(bool A_0)
		{
			this.d = A_0;
		}

		// Token: 0x06000A24 RID: 2596 RVA: 0x00082698 File Offset: 0x00081698
		internal bool b()
		{
			return this.e;
		}

		// Token: 0x06000A25 RID: 2597 RVA: 0x000826B0 File Offset: 0x000816B0
		internal void a(bool A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06000A26 RID: 2598 RVA: 0x000826BC File Offset: 0x000816BC
		private void a(gi A_0, string A_1)
		{
			string[] array = new string[]
			{
				A_1
			};
			if (A_1 == "inherit")
			{
				this.b(A_0, array, 1);
				this.a(A_0, array, 1);
				this.a(array, 1);
			}
			else if (char.IsNumber(array[0], 0) || A_1.StartsWith("-") || A_1.StartsWith("+"))
			{
				this.b(A_0, array, 1);
			}
			else if (A_0.c(array[0]))
			{
				this.b(A_0, array, 1);
			}
			else if (A_0.d(array[0]))
			{
				this.a(A_0, array, 1);
			}
			else
			{
				this.a(array, 1);
			}
		}

		// Token: 0x06000A27 RID: 2599 RVA: 0x00082790 File Offset: 0x00081790
		private void a(int A_0, gi A_1)
		{
			int[] a_ = null;
			if (A_0 <= 548864878)
			{
				if (A_0 <= 83960424)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 != 136794 && A_0 != 7021096)
						{
							goto IL_3E6;
						}
					}
					else
					{
						if (A_0 != 10890914 && A_0 != 83960424)
						{
							goto IL_3E6;
						}
						goto IL_200;
					}
				}
				else if (A_0 <= 426354259)
				{
					if (A_0 == 144877216)
					{
						this.a(A_1, A_0);
						return;
					}
					if (A_0 != 426354259)
					{
						goto IL_3E6;
					}
				}
				else if (A_0 != 448574430)
				{
					if (A_0 == 510035525)
					{
						this.a(A_1, A_0);
						return;
					}
					if (A_0 != 548864878)
					{
						goto IL_3E6;
					}
					goto IL_253;
				}
				string[] array = this.a(A_1);
				if (array != null)
				{
					if (A_0 <= 7021096)
					{
						if (A_0 != 136794)
						{
							if (A_0 == 7021096)
							{
								a_ = new int[]
								{
									1656587748,
									758017896,
									10890914
								};
							}
						}
						else
						{
							a_ = new int[]
							{
								663309508,
								548864878,
								83960424
							};
						}
					}
					else if (A_0 != 426354259)
					{
						if (A_0 == 448574430)
						{
							a_ = new int[]
							{
								789921929,
								1274012590,
								704614712
							};
						}
					}
					else
					{
						a_ = new int[]
						{
							1930785673,
							1304279675,
							1235296202
						};
					}
					this.a(A_1, a_, array);
				}
				return;
			}
			if (A_0 <= 795562982)
			{
				if (A_0 <= 704614712)
				{
					if (A_0 != 663309508)
					{
						if (A_0 != 704614712)
						{
							goto IL_3E6;
						}
						goto IL_200;
					}
				}
				else
				{
					if (A_0 == 758017896)
					{
						goto IL_253;
					}
					if (A_0 != 789921929)
					{
						if (A_0 != 795562982)
						{
							goto IL_3E6;
						}
						this.a(A_1, A_0);
						return;
					}
				}
			}
			else if (A_0 <= 1274012590)
			{
				if (A_0 == 1235296202)
				{
					goto IL_200;
				}
				if (A_0 != 1274012590)
				{
					goto IL_3E6;
				}
				goto IL_253;
			}
			else
			{
				if (A_0 == 1304279675)
				{
					goto IL_253;
				}
				if (A_0 != 1656587748 && A_0 != 1930785673)
				{
					goto IL_3E6;
				}
			}
			string text = A_1.ah();
			if (text.StartsWith("-"))
			{
				int num;
				if (int.TryParse(text.Substring(0, text.Length - 2), out num))
				{
					if (num != 0)
					{
						text = null;
						this.e = true;
					}
				}
			}
			if (text != null)
			{
				if (char.IsNumber(text[0]))
				{
					h2 a_2 = new h2(A_1.a(text));
					fw fw = new fw(m4.a(a_2));
					fw.a(a_2.a().b());
					this.a(A_0, fw);
				}
				else if (text == "inherit")
				{
					fw fw2 = new fw(x5.c());
					fw2.d(true);
					this.a(A_0, fw2);
				}
				else
				{
					h2 a_2 = A_1.e(text);
					fw fw = new fw(m4.a(a_2));
					fw.a(a_2.a().b());
					this.a(A_0, fw);
				}
			}
			return;
			IL_200:
			if (!A_1.a8())
			{
				text = A_1.ah();
			}
			else
			{
				text = A_1.a9();
			}
			fx fx = new fx(this.a(text));
			if (text == "inherit")
			{
				fx.d(true);
			}
			this.a(A_0, fx);
			return;
			IL_253:
			text = A_1.ah();
			fv fv = new fv(A_1.b(text));
			if (text == "inherit")
			{
				fv.d(true);
			}
			this.a(A_0, fv);
			return;
			IL_3E6:
			A_1.ap();
		}

		// Token: 0x06000A28 RID: 2600 RVA: 0x00082B8C File Offset: 0x00081B8C
		private void a(gi A_0, int[] A_1, string[] A_2)
		{
			bool flag = false;
			bool flag2 = false;
			bool flag3 = false;
			if (A_2[0] == "inherit")
			{
				fw fw = new fw(x5.c());
				fw.d(true);
				fv fv = new fv(A_0.b(A_2[0]));
				fv.d(true);
				fx fx = new fx(this.a(A_2[0]));
				fx.d(true);
				this.a(A_1[0], fw);
				this.a(A_1[1], fv);
				this.a(A_1[2], fx);
			}
			else
			{
				for (int i = 0; i < A_2.Length; i++)
				{
					if (A_2[i] == null)
					{
						break;
					}
					if (char.IsNumber(A_2[i], 0))
					{
						foreach (string text in A_2)
						{
							if (text == "hidden")
							{
								this.f = true;
							}
						}
						flag = true;
						h2 a_ = new h2(A_0.a(A_2[i]));
						fw fw2 = new fw(x5.c());
						if (this.f)
						{
							fw2 = new fw(x5.c());
							this.f = false;
						}
						else
						{
							fw2 = new fw(m4.a(a_));
						}
						fw2.a(a_.a().b());
						this.a(A_1[0], fw2);
					}
					else if (!flag && A_0.c(A_2[i]))
					{
						flag = true;
						h2 a_ = A_0.e(A_2[i]);
						fw fw2 = new fw(m4.a(a_));
						fw2.a(a_.a().b());
						this.a(A_1[0], fw2);
					}
					else if (!flag2 && A_0.d(A_2[i]))
					{
						flag2 = true;
						this.a(A_1[1], new fv(A_0.b(A_2[i])));
					}
					else if (!flag3)
					{
						flag3 = true;
						this.a(A_1[2], new fx(this.a(A_2[i])));
					}
				}
				if (flag2)
				{
					if (!flag3)
					{
						this.a(A_1[2], new fx("none"));
					}
					if (!flag)
					{
						this.a(A_1[0], new fw(x5.a(1f)));
					}
				}
				else
				{
					this.a(A_1[1], new fv(ft.a));
					if (!flag3)
					{
						this.a(A_1[2], new fx("none"));
					}
					if (!flag)
					{
						this.a(A_1[0], new fw(x5.c()));
					}
				}
			}
		}

		// Token: 0x06000A29 RID: 2601 RVA: 0x00082E80 File Offset: 0x00081E80
		private string[] a(gi A_0)
		{
			string[] array = new string[3];
			int num = 0;
			bool flag = false;
			if (A_0.aw())
			{
				if (!A_0.a8())
				{
					string text = A_0.ah();
					int num2 = text.IndexOf('#');
					if (num2 > 0)
					{
						array[num++] = text.Substring(0, num2);
						array[num] = text.Substring(num2, text.Length - num2);
					}
					else
					{
						array[num] = text;
					}
				}
				else
				{
					array[num] = A_0.a9();
				}
				while (A_0.a0() && A_0.aw())
				{
					num++;
					if (num > 2)
					{
						A_0.ah();
						flag = true;
					}
					else if (!A_0.a8())
					{
						string text = A_0.ah();
						int num2 = text.IndexOf('#');
						if (num2 > 0)
						{
							array[num++] = text.Substring(0, num2);
							array[num] = text.Substring(num2, text.Length - num2);
						}
						else
						{
							array[num] = text;
						}
					}
					else
					{
						array[num] = A_0.a9();
					}
				}
			}
			return (!flag) ? array : null;
		}

		// Token: 0x06000A2A RID: 2602 RVA: 0x00082FD0 File Offset: 0x00081FD0
		private void a(gi A_0, int A_1)
		{
			string[] array = new string[4];
			int num = 0;
			if (A_0.aw())
			{
				if (!A_0.a8())
				{
					array[num] = A_0.ah();
				}
				else
				{
					array[num] = A_0.a9();
				}
				num++;
				while (A_0.a0() && A_0.aw())
				{
					if (!A_0.a8())
					{
						array[num] = A_0.ah();
					}
					else
					{
						array[num] = A_0.a9();
					}
					num++;
				}
			}
			if (A_1 != 144877216)
			{
				if (A_1 != 510035525)
				{
					if (A_1 == 795562982)
					{
						this.b(A_0, array, num);
					}
				}
				else
				{
					this.a(array, num);
				}
			}
			else
			{
				this.a(A_0, array, num);
			}
		}

		// Token: 0x06000A2B RID: 2603 RVA: 0x00083098 File Offset: 0x00082098
		private void b(gi A_0, string[] A_1, int A_2)
		{
			switch (A_2)
			{
			case 1:
				if (char.IsNumber(A_1[0], 0))
				{
					h2 a_ = new h2(A_0.a(A_1[0]));
					fw fw;
					if (this.f)
					{
						fw = new fw(x5.c());
					}
					else
					{
						fw = new fw(m4.a(a_));
					}
					fw.a(a_.a().b());
					this.a(663309508, fw);
					this.a(789921929, fw);
					this.a(1930785673, fw);
					this.a(1656587748, fw);
					this.g = true;
				}
				else if (A_1[0] == "inherit")
				{
					fw fw = new fw(x5.c());
					fw.d(true);
					this.a(663309508, fw);
					this.a(789921929, fw);
					this.a(1930785673, fw);
					this.a(1656587748, fw);
				}
				else
				{
					h2 a_ = A_0.e(A_1[0]);
					fw fw = new fw(m4.a(a_));
					fw.a(a_.a().b());
					this.a(663309508, fw);
					this.a(789921929, fw);
					this.a(1930785673, fw);
					this.a(1656587748, fw);
				}
				break;
			case 2:
				for (int i = 0; i < A_2; i++)
				{
					h2 a_;
					if (char.IsNumber(A_1[i], 0))
					{
						a_ = new h2(A_0.a(A_1[i]));
					}
					else
					{
						a_ = A_0.e(A_1[i]);
					}
					fw fw2 = new fw(m4.a(a_));
					fw2.a(a_.a().b());
					switch (i)
					{
					case 0:
						this.a(663309508, fw2);
						this.a(1930785673, fw2);
						break;
					case 1:
						this.a(789921929, fw2);
						this.a(1656587748, fw2);
						break;
					}
				}
				break;
			case 3:
				for (int i = 0; i < A_2; i++)
				{
					h2 a_;
					if (char.IsNumber(A_1[i], 0))
					{
						a_ = new h2(A_0.a(A_1[i]));
					}
					else
					{
						a_ = A_0.e(A_1[i]);
					}
					fw fw2 = new fw(m4.a(a_));
					fw2.a(a_.a().b());
					switch (i)
					{
					case 0:
						this.a(663309508, fw2);
						break;
					case 1:
						this.a(789921929, fw2);
						this.a(1656587748, fw2);
						break;
					case 2:
						this.a(1930785673, fw2);
						break;
					}
				}
				break;
			case 4:
				for (int i = 0; i < A_2; i++)
				{
					h2 a_;
					if (char.IsNumber(A_1[i], 0))
					{
						a_ = new h2(A_0.a(A_1[i]));
					}
					else
					{
						a_ = A_0.e(A_1[i]);
					}
					fw fw2 = new fw(m4.a(a_));
					fw2.a(a_.a().b());
					switch (i)
					{
					case 0:
						this.a(663309508, fw2);
						break;
					case 1:
						this.a(789921929, fw2);
						break;
					case 2:
						this.a(1930785673, fw2);
						break;
					case 3:
						this.a(1656587748, fw2);
						break;
					}
				}
				break;
			}
		}

		// Token: 0x06000A2C RID: 2604 RVA: 0x0008348C File Offset: 0x0008248C
		private void a(gi A_0, string[] A_1, int A_2)
		{
			switch (A_2)
			{
			case 1:
			{
				fv fv = new fv(A_0.b(A_1[0]));
				if (A_1[0] == "inherit")
				{
					fv.d(true);
				}
				if (A_1[0] == "hidden")
				{
					this.f = true;
				}
				this.a(548864878, fv);
				this.a(1274012590, fv);
				this.a(1304279675, fv);
				this.a(758017896, fv);
				break;
			}
			case 2:
			{
				fv a_ = new fv(A_0.b(A_1[0]));
				fv a_2 = new fv(A_0.b(A_1[1]));
				this.a(548864878, a_);
				this.a(1274012590, a_2);
				this.a(1304279675, a_);
				this.a(758017896, a_2);
				break;
			}
			case 3:
			{
				fv a_2 = new fv(A_0.b(A_1[1]));
				this.a(548864878, new fv(A_0.b(A_1[0])));
				this.a(1274012590, a_2);
				this.a(1304279675, new fv(A_0.b(A_1[2])));
				this.a(758017896, a_2);
				break;
			}
			case 4:
				this.a(548864878, new fv(A_0.b(A_1[0])));
				this.a(1274012590, new fv(A_0.b(A_1[1])));
				this.a(1304279675, new fv(A_0.b(A_1[2])));
				this.a(758017896, new fv(A_0.b(A_1[3])));
				break;
			}
		}

		// Token: 0x06000A2D RID: 2605 RVA: 0x00083660 File Offset: 0x00082660
		private void a(string[] A_0, int A_1)
		{
			switch (A_1)
			{
			case 1:
			{
				fx fx = new fx(this.a(A_0[0]));
				if (A_0[0] == "inherit")
				{
					fx.d(true);
				}
				this.a(83960424, fx);
				this.a(704614712, fx);
				this.a(1235296202, fx);
				this.a(10890914, fx);
				break;
			}
			case 2:
			{
				fx a_ = new fx(this.a(A_0[0]));
				fx a_2 = new fx(this.a(A_0[1]));
				this.a(83960424, a_);
				this.a(704614712, a_2);
				this.a(1235296202, a_);
				this.a(10890914, a_2);
				break;
			}
			case 3:
			{
				fx a_2 = new fx(this.a(A_0[1]));
				this.a(83960424, new fx(this.a(A_0[0])));
				this.a(704614712, a_2);
				this.a(1235296202, new fx(this.a(A_0[2])));
				this.a(10890914, a_2);
				break;
			}
			case 4:
				this.a(83960424, new fx(this.a(A_0[0])));
				this.a(704614712, new fx(this.a(A_0[1])));
				this.a(1235296202, new fx(this.a(A_0[2])));
				this.a(10890914, new fx(this.a(A_0[3])));
				break;
			}
		}

		// Token: 0x06000A2E RID: 2606 RVA: 0x00083818 File Offset: 0x00082818
		private string a(string A_0)
		{
			if (A_0.Length != 7 && A_0[0] == '#')
			{
				char[] array = new char[7];
				int num = 0;
				array[0] = A_0[0];
				num++;
				if (A_0.Length == 4)
				{
					for (int i = 1; i < array.Length; i++)
					{
						if (i % 2 == 0)
						{
							array[i] = A_0[num];
							num++;
						}
						else
						{
							array[i] = A_0[num];
						}
					}
					A_0 = new string(array);
				}
				else
				{
					A_0 = "black";
				}
			}
			return A_0;
		}

		// Token: 0x06000A2F RID: 2607 RVA: 0x000838D0 File Offset: 0x000828D0
		private void a(int A_0, fu A_1)
		{
			if (A_0 != 0 && A_1 != null)
			{
				int num = this.a(A_0);
				if (num < 0)
				{
					this.a[this.c++] = new fb<fu>(A_0, A_1);
				}
				else
				{
					this.a[num].a(A_0);
					this.a[num].a(A_1);
				}
			}
		}

		// Token: 0x06000A30 RID: 2608 RVA: 0x00083958 File Offset: 0x00082958
		private int a(int A_0)
		{
			for (int i = 0; i < this.a.Length; i++)
			{
				if (this.a[i].a() == A_0)
				{
					return i;
				}
			}
			return -1;
		}

		// Token: 0x06000A31 RID: 2609 RVA: 0x000839A8 File Offset: 0x000829A8
		private void a(fb<fu> A_0, ref fg A_1, ref int A_2)
		{
			if (!this.a(A_0.a(), A_1.a(), ref A_2))
			{
				A_1.a()[A_2].a(A_0.a());
				A_1.a()[A_2].a(A_0.b());
				A_1.a()[A_2].b().d(A_0.b().g());
				A_2++;
			}
		}

		// Token: 0x06000A32 RID: 2610 RVA: 0x00083A34 File Offset: 0x00082A34
		private bool a(int A_0, fb<fu>[] A_1, ref int A_2)
		{
			while (A_2 < A_1.Length)
			{
				bool result;
				if (A_1[A_2].a() != 0 && A_1[A_2].a() == A_0)
				{
					result = true;
				}
				else
				{
					if (A_1[A_2].a() != 0)
					{
						A_2++;
						continue;
					}
					result = false;
				}
				return result;
			}
			return false;
		}

		// Token: 0x06000A33 RID: 2611 RVA: 0x00083AA5 File Offset: 0x00082AA5
		internal override fn cx()
		{
			throw new Exception("The method or operation is not implemented.");
		}

		// Token: 0x06000A34 RID: 2612 RVA: 0x00083AB4 File Offset: 0x00082AB4
		internal bool c()
		{
			bool result = false;
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0 && this.a()[i].b().g())
				{
					result = true;
					i = this.a().Length;
					break;
				}
			}
			return result;
		}

		// Token: 0x06000A35 RID: 2613 RVA: 0x00083B24 File Offset: 0x00082B24
		internal fg a(fg A_0)
		{
			fb<fu>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					for (int j = 0; j < array.Length; j++)
					{
						if (this.a()[i].a() == array[j].a())
						{
							if (this.a()[i].b().g() && !array[j].b().g())
							{
								this.a()[i].a(array[j].b());
								this.a()[i].b().d(false);
							}
							break;
						}
					}
				}
			}
			return this;
		}

		// Token: 0x06000A36 RID: 2614 RVA: 0x00083C30 File Offset: 0x00082C30
		internal fg b(fg A_0)
		{
			fg fg = new fg();
			int num = 0;
			fb<fu>[] array = A_0.a();
			for (int i = 0; i < this.a().Length; i++)
			{
				if (this.a()[i].a() != 0)
				{
					fg.a()[num].a(this.a()[i].a());
					fg.a()[num].a(this.a()[i].b());
					num++;
				}
			}
			for (int i = 0; i < array.Length; i++)
			{
				bool flag = false;
				if (array[i].a() != 0)
				{
					for (int j = 0; j < this.a().Length; j++)
					{
						if (this.a()[j].a() == array[i].a())
						{
							flag = true;
							break;
						}
					}
					if (!flag)
					{
						this.a(array[i], ref fg, ref num);
					}
				}
			}
			return fg;
		}

		// Token: 0x06000A37 RID: 2615 RVA: 0x00083D7C File Offset: 0x00082D7C
		internal fg a(fg A_0, fg A_1)
		{
			fg fg = new fg();
			fb<fu>[] array = A_0.a();
			fb<fu>[] array2 = A_1.a();
			int num = 0;
			for (int i = 0; i < array2.Length; i++)
			{
				if (!this.a(array2[i].a(), array, ref num))
				{
					if (array2[i].a() != 0)
					{
						array[num].a(array2[i].a());
						array[num].a(array2[i].b());
					}
				}
				num = 0;
			}
			fg.a(array);
			return fg;
		}

		// Token: 0x06000A38 RID: 2616 RVA: 0x00083E38 File Offset: 0x00082E38
		internal override void cw(gi A_0)
		{
			if (A_0.x())
			{
				int num = A_0.y();
				if (num != 0)
				{
					this.a(num, A_0);
				}
			}
			else
			{
				this.b = this.a;
				this.a = new fb<fu>[20];
				this.c = 0;
				if (!A_0.a8())
				{
					string text = A_0.ah();
					if (text != null && text != "")
					{
						this.a(A_0, text);
					}
				}
				else
				{
					string text = A_0.a9();
					this.a(new string[]
					{
						text
					}, 1);
				}
				while (A_0.a0() && A_0.aw())
				{
					if (!A_0.a8())
					{
						string text = A_0.ah();
						if (text.StartsWith("-"))
						{
							text = null;
							this.e = true;
						}
						if (text != null && text != "")
						{
							this.a(A_0, text);
						}
					}
					else
					{
						string text = A_0.a9();
						this.a(new string[]
						{
							text
						}, 1);
					}
				}
				this.d = true;
				if (this.e)
				{
					this.a = this.b;
				}
			}
			if (this.f && this.g)
			{
				this.b(A_0, new string[]
				{
					"0"
				}, 1);
			}
		}

		// Token: 0x0400050A RID: 1290
		private new fb<fu>[] a;

		// Token: 0x0400050B RID: 1291
		private fb<fu>[] b;

		// Token: 0x0400050C RID: 1292
		private int c = 0;

		// Token: 0x0400050D RID: 1293
		private bool d = false;

		// Token: 0x0400050E RID: 1294
		private bool e = false;

		// Token: 0x0400050F RID: 1295
		private bool f = false;

		// Token: 0x04000510 RID: 1296
		private bool g = false;
	}
}
