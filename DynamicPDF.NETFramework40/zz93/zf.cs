using System;

namespace zz93
{
	// Token: 0x020003CC RID: 972
	internal class zf
	{
		// Token: 0x060028F2 RID: 10482 RVA: 0x0017B2AC File Offset: 0x0017A2AC
		internal zf(byte[] A_0, int A_1, int A_2, bool A_3, int A_4)
		{
			if (A_3)
			{
				if (A_4 == 1)
				{
					this.c(A_0, A_1, A_2);
				}
				else
				{
					this.d(A_0, A_1, A_2);
				}
			}
			else if (A_4 == 1)
			{
				this.b(A_0, A_1, A_2);
			}
			else
			{
				this.a(A_0, A_1, A_2);
			}
		}

		// Token: 0x060028F3 RID: 10483 RVA: 0x0017B315 File Offset: 0x0017A315
		internal zf()
		{
		}

		// Token: 0x060028F4 RID: 10484 RVA: 0x0017B320 File Offset: 0x0017A320
		private void d(byte[] A_0, int A_1, int A_2)
		{
			int num = A_1 * 2;
			int num2 = A_1 * 4 + 1;
			this.a = new byte[A_1 * A_2 * 2];
			this.b = new byte[A_1 * A_2 * 2];
			za za = new za();
			za.a(A_0, 0, A_0.Length);
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < A_2; i++)
			{
				byte[] array = new byte[num2];
				za.b(array, 0, num2);
				switch (array[0])
				{
				case 0:
				{
					int j = 1;
					while (j < num2)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
						this.b[num4++] = array[j++];
					}
					break;
				}
				case 1:
				{
					int j = 1;
					this.a[num3++] = array[j++];
					this.a[num3++] = array[j++];
					this.b[num4++] = array[j++];
					this.b[num4++] = array[j++];
					while (j < num2)
					{
						this.a[num3] = array[j++] + this.a[num3++ - 2];
						this.a[num3] = array[j++] + this.a[num3++ - 2];
						this.b[num4] = array[j++] + this.b[num4++ - 2];
						this.b[num4] = array[j++] + this.b[num4++ - 2];
					}
					break;
				}
				case 2:
				{
					int j = 1;
					if (i == 0)
					{
						while (j < num2)
						{
							this.a[num3++] = array[j++];
							this.a[num3++] = array[j++];
							this.b[num4++] = array[j++];
							this.b[num4++] = array[j++];
						}
					}
					else
					{
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a[num3++ - num];
							this.a[num3] = array[j++] + this.a[num3++ - num];
							this.b[num4] = array[j++] + this.b[num4++ - num];
							this.b[num4] = array[j++] + this.b[num4++ - num];
						}
					}
					break;
				}
				case 3:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
						this.b[num4++] = array[j++];
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a[num3++ - 2] / 2;
							this.a[num3] = array[j++] + this.a[num3++ - 2] / 2;
							this.b[num4] = array[j++] + this.b[num4++ - 2] / 2;
							this.b[num4] = array[j++] + this.b[num4++ - 2] / 2;
						}
					}
					else
					{
						this.a[num3] = array[j++] + this.a[num3++ - num] / 2;
						this.a[num3] = array[j++] + this.a[num3++ - num] / 2;
						this.b[num4] = array[j++] + this.b[num4++ - num] / 2;
						this.b[num4] = array[j++] + this.b[num4++ - num] / 2;
						while (j < num2)
						{
							this.a[num3] = array[j++] + (this.a[num3 - num] + this.a[num3++ - 2]) / 2;
							this.a[num3] = array[j++] + (this.a[num3 - num] + this.a[num3++ - 2]) / 2;
							this.b[num4] = array[j++] + (this.b[num4 - num] + this.b[num4++ - 2]) / 2;
							this.b[num4] = array[j++] + (this.b[num4 - num] + this.b[num4++ - 2]) / 2;
						}
					}
					break;
				}
				case 4:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
						this.b[num4++] = array[j++];
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a(this.a[num3++ - 2], 0, 0);
							this.a[num3] = array[j++] + this.a(this.a[num3++ - 2], 0, 0);
							this.b[num4] = array[j++] + this.a(this.b[num4++ - 2], 0, 0);
							this.b[num4] = array[j++] + this.a(this.b[num4++ - 2], 0, 0);
						}
					}
					else
					{
						this.a[num3] = array[j++] + this.a(0, this.a[num3++ - num], 0);
						this.a[num3] = array[j++] + this.a(0, this.a[num3++ - num], 0);
						this.b[num4] = array[j++] + this.a(0, this.b[num4++ - num], 0);
						this.b[num4] = array[j++] + this.a(0, this.b[num4++ - num], 0);
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a(this.a[num3 - 2], this.a[num3 - num], this.a[num3++ - num - 2]);
							this.a[num3] = array[j++] + this.a(this.a[num3 - 2], this.a[num3 - num], this.a[num3++ - num - 2]);
							this.b[num4] = array[j++] + this.a(this.b[num4 - 2], this.b[num4 - num], this.b[num4++ - num - 2]);
							this.b[num4] = array[j++] + this.a(this.b[num4 - 2], this.b[num4 - num], this.b[num4++ - num - 2]);
						}
					}
					break;
				}
				}
			}
			byte[] array2 = new byte[A_1 * A_2];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = this.b[k * 2];
			}
			this.b = array2;
		}

		// Token: 0x060028F5 RID: 10485 RVA: 0x0017BC5C File Offset: 0x0017AC5C
		private void c(byte[] A_0, int A_1, int A_2)
		{
			int num = A_1 * 2 + 1;
			this.a = new byte[A_1 * A_2];
			this.b = new byte[A_1 * A_2];
			za za = new za();
			za.a(A_0, 0, A_0.Length);
			int num2 = 0;
			int num3 = 0;
			for (int i = 0; i < A_2; i++)
			{
				byte[] array = new byte[num];
				za.b(array, 0, num);
				switch (array[0])
				{
				case 0:
				{
					int j = 1;
					while (j < num)
					{
						this.a[num2++] = array[j++];
						this.b[num3++] = array[j++];
					}
					break;
				}
				case 1:
				{
					int j = 1;
					this.a[num2++] = array[j++];
					this.b[num3++] = array[j++];
					while (j < num)
					{
						this.a[num2] = array[j++] + this.a[num2++ - 1];
						this.b[num3] = array[j++] + this.b[num3++ - 1];
					}
					break;
				}
				case 2:
				{
					int j = 1;
					if (i == 0)
					{
						while (j < num)
						{
							this.a[num2++] = array[j++];
							this.b[num3++] = array[j++];
						}
					}
					else
					{
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a[num2++ - A_1];
							this.b[num3] = array[j++] + this.b[num3++ - A_1];
						}
					}
					break;
				}
				case 3:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num2++] = array[j++];
						this.b[num3++] = array[j++];
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a[num2++ - 1] / 2;
							this.b[num3] = array[j++] + this.b[num3++ - 1] / 2;
						}
					}
					else
					{
						this.a[num2] = array[j++] + this.a[num2++ - A_1] / 2;
						this.b[num3] = array[j++] + this.b[num3++ - A_1] / 2;
						while (j < num)
						{
							this.a[num2] = array[j++] + (this.a[num2 - A_1] + this.a[num2++ - 1]) / 2;
							this.b[num3] = array[j++] + (this.b[num3 - A_1] + this.b[num3++ - 1]) / 2;
						}
					}
					break;
				}
				case 4:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num2++] = array[j++];
						this.b[num3++] = array[j++];
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a(this.a[num2++ - 1], 0, 0);
							this.b[num3] = array[j++] + this.a(this.b[num3++ - 1], 0, 0);
						}
					}
					else
					{
						this.a[num2] = array[j++] + this.a(0, this.a[num2++ - A_1], 0);
						this.b[num3] = array[j++] + this.a(0, this.b[num3++ - A_1], 0);
						while (j < num)
						{
							this.a[num2] = array[j++] + this.a(this.a[num2 - 1], this.a[num2 - A_1], this.a[num2++ - A_1 - 1]);
							this.b[num3] = array[j++] + this.a(this.b[num3 - 1], this.b[num3 - A_1], this.b[num3++ - A_1 - 1]);
						}
					}
					break;
				}
				}
			}
		}

		// Token: 0x060028F6 RID: 10486 RVA: 0x0017C14C File Offset: 0x0017B14C
		private void b(byte[] A_0, int A_1, int A_2)
		{
			int num = A_1 * 3;
			int num2 = A_1 * 4 + 1;
			this.a = new byte[A_1 * A_2 * 3];
			this.b = new byte[A_1 * A_2];
			za za = new za();
			za.a(A_0, 0, A_0.Length);
			int num3 = 0;
			int num4 = 0;
			for (int i = 0; i < A_2; i++)
			{
				byte[] array = new byte[num2];
				za.b(array, 0, num2);
				switch (array[0])
				{
				case 0:
				{
					int j = 1;
					while (j < num2)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
					}
					break;
				}
				case 1:
				{
					int j = 1;
					this.a[num3++] = array[j++];
					this.a[num3++] = array[j++];
					this.a[num3++] = array[j++];
					this.b[num4++] = array[j++];
					while (j < num2)
					{
						this.a[num3] = array[j++] + this.a[num3++ - 3];
						this.a[num3] = array[j++] + this.a[num3++ - 3];
						this.a[num3] = array[j++] + this.a[num3++ - 3];
						this.b[num4] = array[j++] + this.b[num4++ - 1];
					}
					break;
				}
				case 2:
				{
					int j = 1;
					if (i == 0)
					{
						while (j < num2)
						{
							this.a[num3++] = array[j++];
							this.a[num3++] = array[j++];
							this.a[num3++] = array[j++];
							this.b[num4++] = array[j++];
						}
					}
					else
					{
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a[num3++ - num];
							this.a[num3] = array[j++] + this.a[num3++ - num];
							this.a[num3] = array[j++] + this.a[num3++ - num];
							this.b[num4] = array[j++] + this.b[num4++ - A_1];
						}
					}
					break;
				}
				case 3:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a[num3++ - 3] / 2;
							this.a[num3] = array[j++] + this.a[num3++ - 3] / 2;
							this.a[num3] = array[j++] + this.a[num3++ - 3] / 2;
							this.b[num4] = array[j++] + this.b[num4++ - 1] / 2;
						}
					}
					else
					{
						this.a[num3] = array[j++] + this.a[num3++ - num] / 2;
						this.a[num3] = array[j++] + this.a[num3++ - num] / 2;
						this.a[num3] = array[j++] + this.a[num3++ - num] / 2;
						this.b[num4] = array[j++] + this.b[num4++ - A_1] / 2;
						while (j < num2)
						{
							this.a[num3] = array[j++] + (this.a[num3 - num] + this.a[num3++ - 3]) / 2;
							this.a[num3] = array[j++] + (this.a[num3 - num] + this.a[num3++ - 3]) / 2;
							this.a[num3] = array[j++] + (this.a[num3 - num] + this.a[num3++ - 3]) / 2;
							this.b[num4] = array[j++] + (this.b[num4 - A_1] + this.b[num4++ - 1]) / 2;
						}
					}
					break;
				}
				case 4:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.a[num3++] = array[j++];
						this.b[num4++] = array[j++];
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a(this.a[num3++ - 3], 0, 0);
							this.a[num3] = array[j++] + this.a(this.a[num3++ - 3], 0, 0);
							this.a[num3] = array[j++] + this.a(this.a[num3++ - 3], 0, 0);
							this.b[num4] = array[j++] + this.a(this.b[num4++ - 1], 0, 0);
						}
					}
					else
					{
						this.a[num3] = array[j++] + this.a(0, this.a[num3++ - num], 0);
						this.a[num3] = array[j++] + this.a(0, this.a[num3++ - num], 0);
						this.a[num3] = array[j++] + this.a(0, this.a[num3++ - num], 0);
						this.b[num4] = array[j++] + this.a(0, this.b[num4++ - A_1], 0);
						while (j < num2)
						{
							this.a[num3] = array[j++] + this.a(this.a[num3 - 3], this.a[num3 - num], this.a[num3++ - num - 3]);
							this.a[num3] = array[j++] + this.a(this.a[num3 - 3], this.a[num3 - num], this.a[num3++ - num - 3]);
							this.a[num3] = array[j++] + this.a(this.a[num3 - 3], this.a[num3 - num], this.a[num3++ - num - 3]);
							this.b[num4] = array[j++] + this.a(this.b[num4 - 1], this.b[num4 - A_1], this.b[num4++ - A_1 - 1]);
						}
					}
					break;
				}
				}
			}
		}

		// Token: 0x060028F7 RID: 10487 RVA: 0x0017CA4C File Offset: 0x0017BA4C
		private void a(byte[] A_0, int A_1, int A_2)
		{
			int num = A_1 * 6;
			int num2 = A_1 * 2;
			int num3 = A_1 * 8 + 1;
			this.a = new byte[A_1 * A_2 * 6];
			this.b = new byte[A_1 * A_2 * 2];
			za za = new za();
			za.a(A_0, 0, A_0.Length);
			int num4 = 0;
			int num5 = 0;
			for (int i = 0; i < A_2; i++)
			{
				byte[] array = new byte[num3];
				za.b(array, 0, num3);
				switch (array[0])
				{
				case 0:
				{
					int j = 1;
					while (j < num3)
					{
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.b[num5++] = array[j++];
						this.b[num5++] = array[j++];
					}
					break;
				}
				case 1:
				{
					int j = 1;
					this.a[num4++] = array[j++];
					this.a[num4++] = array[j++];
					this.a[num4++] = array[j++];
					this.a[num4++] = array[j++];
					this.a[num4++] = array[j++];
					this.a[num4++] = array[j++];
					this.b[num5++] = array[j++];
					this.b[num5++] = array[j++];
					while (j < num3)
					{
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.a[num4] = array[j++] + this.a[num4++ - 6];
						this.b[num5] = array[j++] + this.b[num5++ - 2];
						this.b[num5] = array[j++] + this.b[num5++ - 2];
					}
					break;
				}
				case 2:
				{
					int j = 1;
					if (i == 0)
					{
						while (j < num3)
						{
							this.a[num4++] = array[j++];
							this.a[num4++] = array[j++];
							this.a[num4++] = array[j++];
							this.a[num4++] = array[j++];
							this.a[num4++] = array[j++];
							this.a[num4++] = array[j++];
							this.b[num5++] = array[j++];
							this.b[num5++] = array[j++];
						}
					}
					else
					{
						while (j < num3)
						{
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.a[num4] = array[j++] + this.a[num4++ - num];
							this.b[num5] = array[j++] + this.b[num5++ - num2];
							this.b[num5] = array[j++] + this.b[num5++ - num2];
						}
					}
					break;
				}
				case 3:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.b[num5++] = array[j++];
						this.b[num5++] = array[j++];
						while (j < num3)
						{
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.a[num4] = array[j++] + this.a[num4++ - 6] / 2;
							this.b[num5] = array[j++] + this.b[num5++ - 2] / 2;
							this.b[num5] = array[j++] + this.b[num5++ - 2] / 2;
						}
					}
					else
					{
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.a[num4] = array[j++] + this.a[num4++ - num] / 2;
						this.b[num5] = array[j++] + this.b[num5++ - num2] / 2;
						this.b[num5] = array[j++] + this.b[num5++ - num2] / 2;
						while (j < num3)
						{
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.a[num4] = array[j++] + (this.a[num4 - num] + this.a[num4++ - 6]) / 2;
							this.b[num5] = array[j++] + (this.b[num5 - num2] + this.b[num5++ - 2]) / 2;
							this.b[num5] = array[j++] + (this.b[num5 - num2] + this.b[num5++ - 2]) / 2;
						}
					}
					break;
				}
				case 4:
				{
					int j = 1;
					if (i == 0)
					{
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.a[num4++] = array[j++];
						this.b[num5++] = array[j++];
						this.b[num5++] = array[j++];
						while (j < num3)
						{
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.a[num4] = array[j++] + this.a(this.a[num4++ - 6], 0, 0);
							this.b[num5] = array[j++] + this.a(this.b[num5++ - 2], 0, 0);
							this.b[num5] = array[j++] + this.a(this.b[num5++ - 2], 0, 0);
						}
					}
					else
					{
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.a[num4] = array[j++] + this.a(0, this.a[num4++ - num], 0);
						this.b[num5] = array[j++] + this.a(0, this.b[num5++ - num2], 0);
						this.b[num5] = array[j++] + this.a(0, this.b[num5++ - num2], 0);
						while (j < num3)
						{
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.a[num4] = array[j++] + this.a(this.a[num4 - 6], this.a[num4 - num], this.a[num4++ - num - 6]);
							this.b[num5] = array[j++] + this.a(this.b[num5 - 2], this.b[num5 - num2], this.b[num5++ - num2 - 2]);
							this.b[num5] = array[j++] + this.a(this.b[num5 - 2], this.b[num5 - num2], this.b[num5++ - num2 - 2]);
						}
					}
					break;
				}
				}
			}
			byte[] array2 = new byte[A_1 * A_2];
			for (int k = 0; k < array2.Length; k++)
			{
				array2[k] = this.b[k * 2];
			}
			this.b = array2;
		}

		// Token: 0x060028F8 RID: 10488 RVA: 0x0017DAEC File Offset: 0x0017CAEC
		internal byte[] e(byte[] A_0, int A_1, int A_2)
		{
			byte[] array = new byte[A_1 * A_2 * 6];
			long num = 0L;
			za za = new za();
			za.a(A_0);
			byte[] a_ = null;
			int num2 = 0;
			byte[] a_2 = new byte[A_2 * A_1 * 6 + A_2];
			za.b(a_2);
			for (int i = 0; i < A_2; i++)
			{
				byte[] array2 = this.a(a_2, 6, a_, A_1, ref num2);
				int j = 0;
				while (j < array2.Length)
				{
					int num3 = ((int)array2[j++] << 8) + (int)array2[j++];
					int num4 = ((int)array2[j++] << 8) + (int)array2[j++];
					int num5 = ((int)array2[j++] << 8) + (int)array2[j++];
					byte[] array3 = array;
					long num6 = num;
					num = num6 + 1L;
					array3[(int)(checked((IntPtr)num6))] = (byte)(num3 >> 8);
					byte[] array4 = array;
					long num7 = num;
					num = num7 + 1L;
					array4[(int)(checked((IntPtr)num7))] = (byte)num3;
					byte[] array5 = array;
					long num8 = num;
					num = num8 + 1L;
					array5[(int)(checked((IntPtr)num8))] = (byte)(num4 >> 8);
					byte[] array6 = array;
					long num9 = num;
					num = num9 + 1L;
					array6[(int)(checked((IntPtr)num9))] = (byte)num4;
					byte[] array7 = array;
					long num10 = num;
					num = num10 + 1L;
					array7[(int)(checked((IntPtr)num10))] = (byte)(num5 >> 8);
					byte[] array8 = array;
					long num11 = num;
					num = num11 + 1L;
					array8[(int)(checked((IntPtr)num11))] = (byte)num5;
				}
				a_ = array2;
			}
			this.a = array;
			return this.a;
		}

		// Token: 0x060028F9 RID: 10489 RVA: 0x0017DC34 File Offset: 0x0017CC34
		internal byte[] a(byte[] A_0, int A_1, byte[] A_2, int A_3, ref int A_4)
		{
			byte[] array = new byte[A_3 * A_1];
			switch (A_0[A_4++])
			{
			case 0:
				for (int i = 0; i < array.Length; i++)
				{
					array[i] = A_0[A_4++];
				}
				break;
			case 1:
				for (int i = 0; i < array.Length; i++)
				{
					if (i < A_1)
					{
						array[i] = A_0[A_4++];
					}
					else
					{
						array[i] = (byte)((int)(A_0[A_4++] + array[i - A_1]) % 256);
					}
				}
				break;
			case 2:
				for (int i = 0; i < array.Length; i++)
				{
					if (A_2 == null)
					{
						array[i] = A_0[A_4++];
					}
					else
					{
						array[i] = (byte)((int)(A_0[A_4++] + A_2[i]) % 256);
					}
				}
				break;
			case 3:
				for (int i = 0; i < array.Length; i++)
				{
					if (A_2 == null)
					{
						if (i >= A_1)
						{
							array[i] = (byte)((int)(A_0[A_4++] + array[i - A_1] / 2) % 256);
						}
						else
						{
							array[i] = A_0[A_4++];
						}
					}
					else if (i < A_1)
					{
						array[i] = (byte)((int)(A_0[A_4++] + A_2[i] / 2) % 256);
					}
					else
					{
						array[i] = (byte)((int)(A_0[A_4++] + (array[i - A_1] + A_2[i]) / 2) % 256);
					}
				}
				break;
			case 4:
				for (int i = 0; i < array.Length; i++)
				{
					if (A_2 == null)
					{
						if (i >= A_1)
						{
							array[i] = (byte)((int)(A_0[A_4++] + array[i - A_1]) % 256);
						}
						else
						{
							array[i] = A_0[A_4++];
						}
					}
					else if (i < A_1)
					{
						array[i] = (byte)((int)(A_0[A_4++] + A_2[i]) % 256);
					}
					else
					{
						array[i] = (byte)((int)(A_0[A_4++] + this.a(array[i - A_1], A_2[i], A_2[i - A_1])) % 256);
					}
				}
				break;
			}
			return array;
		}

		// Token: 0x060028FA RID: 10490 RVA: 0x0017DEDC File Offset: 0x0017CEDC
		internal byte[] a()
		{
			return this.a;
		}

		// Token: 0x060028FB RID: 10491 RVA: 0x0017DEF4 File Offset: 0x0017CEF4
		internal byte[] b()
		{
			return this.b;
		}

		// Token: 0x060028FC RID: 10492 RVA: 0x0017DF0C File Offset: 0x0017CF0C
		private byte a(byte A_0, byte A_1, byte A_2)
		{
			int num = (int)(A_0 + A_1 - A_2);
			int num2 = Math.Abs(num - (int)A_0);
			int num3 = Math.Abs(num - (int)A_1);
			int num4 = Math.Abs(num - (int)A_2);
			byte result;
			if (num2 <= num3 && num2 <= num4)
			{
				result = A_0;
			}
			else if (num3 <= num4)
			{
				result = A_1;
			}
			else
			{
				result = A_2;
			}
			return result;
		}

		// Token: 0x0400128D RID: 4749
		private byte[] a;

		// Token: 0x0400128E RID: 4750
		private byte[] b;
	}
}
