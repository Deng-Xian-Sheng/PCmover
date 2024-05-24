using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.Imaging;

namespace zz93
{
	// Token: 0x0200005A RID: 90
	internal class bx : bw
	{
		// Token: 0x060002FE RID: 766 RVA: 0x0003FADD File Offset: 0x0003EADD
		internal bx(int A_0) : base(A_0)
		{
			this.a = new List<bs>();
		}

		// Token: 0x060002FF RID: 767 RVA: 0x0003FAF4 File Offset: 0x0003EAF4
		internal bx(int A_0, int A_1) : base(A_0, A_1)
		{
			this.a = new List<bs>();
		}

		// Token: 0x06000300 RID: 768 RVA: 0x0003FB0C File Offset: 0x0003EB0C
		private new byte[] a(byte[] A_0)
		{
			SHA256CryptoServiceProvider sha256CryptoServiceProvider = new SHA256CryptoServiceProvider();
			return sha256CryptoServiceProvider.ComputeHash(A_0);
		}

		// Token: 0x06000301 RID: 769 RVA: 0x0003FB2C File Offset: 0x0003EB2C
		private new bool a(byte[] A_0, byte[] A_1)
		{
			bool result;
			if (A_0.Length != A_1.Length)
			{
				result = false;
			}
			else
			{
				for (int i = 0; i < A_0.Length; i++)
				{
					if (A_0[i] != A_1[i])
					{
						return false;
					}
				}
				result = true;
			}
			return result;
		}

		// Token: 0x06000302 RID: 770 RVA: 0x0003FB78 File Offset: 0x0003EB78
		private new int a(int A_0, byte[] A_1, int A_2, int A_3, afj A_4, byte[] A_5, afj A_6, byte[] A_7)
		{
			if (this.a != null)
			{
				for (int i = 0; i < this.a.Count; i++)
				{
					bs bs = this.a[i];
					if (bs.a() == A_2 && bs.b() == A_3)
					{
						if (bs.d() == A_0)
						{
							if (this.a(A_1, bs.c()))
							{
								if (bs.f() != null && A_4 != null)
								{
									if (bs.f() != null && bs.f().e() == A_4.e() && bs.f().f() == A_4.f())
									{
										if (bs.f().g() == A_4.g())
										{
											if (this.a(A_5, bs.g()))
											{
												if (bs.h() == null || bs.h().e() != A_6.e() || bs.h().f() != A_6.f())
												{
													return (int)base.e()[bs.e()];
												}
												if (this.a(A_7, bs.i()))
												{
													return (int)base.e()[bs.e()];
												}
											}
										}
									}
								}
								else
								{
									if (bs.h() == null || bs.h().e() != A_6.e() || bs.h().f() != A_6.f())
									{
										return (int)base.e()[bs.e()];
									}
									if (this.a(A_7, bs.i()))
									{
										return (int)base.e()[bs.e()];
									}
								}
							}
						}
					}
				}
			}
			return -1;
		}

		// Token: 0x06000303 RID: 771 RVA: 0x0003FDE4 File Offset: 0x0003EDE4
		public override int Add(Resource resource)
		{
			int result;
			if (base.e().ContainsKey(resource.Uid))
			{
				result = (int)base.e()[resource.Uid];
			}
			else
			{
				if (resource is abn)
				{
					abn abn = (abn)resource;
					long uid = abn.Uid;
					abd abd = abn.a();
					if (abd is afj && ((afj)abd).n() == ag0.c)
					{
						afj afj = (afj)abd;
						byte[] array = afj.j4();
						byte[] array2 = this.a(array);
						int num = afj.e();
						int num2 = afj.f();
						afj afj2 = null;
						byte[] array3 = null;
						if (afj.h() != null)
						{
							afj2 = afj.h();
							byte[] a_ = afj2.j4();
							array3 = this.a(a_);
						}
						afj afj3 = null;
						byte[] array4 = null;
						byte[] array5 = null;
						if (afj.i() != null)
						{
							abe abe = afj.i();
							for (int i = 0; i < abe.a(); i += 2)
							{
								if (abe.a(i).hy() == ag9.b)
								{
									abd abd2 = abe.a(i + 1).h6();
									if (abd2 is afj)
									{
										afj3 = (afj)abd2;
										array5 = afj3.j4();
									}
									else if (abd2 is afn)
									{
										array5 = ((afn)abd2).kh();
									}
									break;
								}
							}
							if (array5 != null)
							{
								array4 = this.a(array5);
							}
						}
						int num3 = this.a(array.Length, array2, num, num2, afj2, array3, afj3, array4);
						if (num3 > 0)
						{
							return num3;
						}
						bs item = new bs(num, num2, array2, array.Length, uid, afj2, array3, afj3, array4);
						if (this.a == null)
						{
							this.a = new List<bs>();
						}
						this.a.Add(item);
					}
				}
				else if (resource is ImageData)
				{
					ImageData imageData = (ImageData)resource;
					byte[] array = imageData.gs();
					byte[] array2 = this.a(array);
					int num = imageData.Width;
					int num2 = imageData.Height;
					long uid = resource.Uid;
					int num3 = this.a(array.Length, array2, num, num2, null, null, null, null);
					if (num3 > 0)
					{
						return num3;
					}
					bs item = new bs(num, num2, array2, array.Length, uid, null, null, null, null);
					if (this.a == null)
					{
						this.a = new List<bs>();
					}
					this.a.Add(item);
				}
				int currentObjectNumber = base.CurrentObjectNumber;
				base.d().Add(resource);
				base.e().Add(resource.Uid, currentObjectNumber);
				base.a(base.CurrentObjectNumber + resource.RequiredPdfObjects);
				result = currentObjectNumber;
			}
			return result;
		}

		// Token: 0x06000304 RID: 772 RVA: 0x00040154 File Offset: 0x0003F154
		internal override void t()
		{
			this.a = null;
		}

		// Token: 0x04000209 RID: 521
		private new List<bs> a;
	}
}
