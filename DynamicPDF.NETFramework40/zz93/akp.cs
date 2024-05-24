using System;
using System.Reflection;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.LayoutEngine;

namespace zz93
{
	// Token: 0x02000573 RID: 1395
	internal class akp : ait
	{
		// Token: 0x06003768 RID: 14184 RVA: 0x001DF528 File Offset: 0x001DE528
		internal akp(string A_0, string A_1)
		{
			this.a = A_0;
			string[] array = A_1.Split(new char[]
			{
				'.'
			});
			this.b = new akp.a(array[0]);
			if (array.Length > 1)
			{
				akp.a a = this.b;
				for (int i = 1; i < array.Length; i++)
				{
					a.a(new akp.a(array[i]));
					a = a.a();
				}
			}
		}

		// Token: 0x06003769 RID: 14185 RVA: 0x001DF5AC File Offset: 0x001DE5AC
		internal override bool l4(LayoutWriter A_0)
		{
			object obj = A_0.Data.a(this.a);
			bool result;
			if (obj is DBNull || obj == null)
			{
				result = true;
			}
			else
			{
				object obj2 = this.b.b(obj);
				result = (obj2 == null);
			}
			return result;
		}

		// Token: 0x0600376A RID: 14186 RVA: 0x001DF5FC File Offset: 0x001DE5FC
		internal override bool lw(LayoutWriter A_0, akk A_1)
		{
			return A_1.b() == null;
		}

		// Token: 0x0600376B RID: 14187 RVA: 0x001DF618 File Offset: 0x001DE618
		internal override object ma(LayoutWriter A_0)
		{
			object a_ = A_0.Data.a(this.a);
			return this.b.b(a_);
		}

		// Token: 0x0600376C RID: 14188 RVA: 0x001DF648 File Offset: 0x001DE648
		internal override object l2(LayoutWriter A_0, akk A_1)
		{
			object result;
			if (A_0.f())
			{
				result = A_1.c();
			}
			else
			{
				result = A_1.b();
			}
			return result;
		}

		// Token: 0x0600376D RID: 14189 RVA: 0x001DF678 File Offset: 0x001DE678
		internal override void mc(LayoutWriter A_0, akk A_1, PageElement A_2)
		{
			object a_ = A_0.Data.a(this.a);
			A_1.a(this.b.b(a_));
		}

		// Token: 0x04001A3A RID: 6714
		private new string a;

		// Token: 0x04001A3B RID: 6715
		private new akp.a b;

		// Token: 0x02000574 RID: 1396
		internal new class a
		{
			// Token: 0x0600376E RID: 14190 RVA: 0x001DF6AB File Offset: 0x001DE6AB
			internal a(string A_0)
			{
				this.a = A_0;
			}

			// Token: 0x0600376F RID: 14191 RVA: 0x001DF6CC File Offset: 0x001DE6CC
			internal akp.a a()
			{
				return this.b;
			}

			// Token: 0x06003770 RID: 14192 RVA: 0x001DF6E4 File Offset: 0x001DE6E4
			internal void a(akp.a A_0)
			{
				this.b = A_0;
			}

			// Token: 0x06003771 RID: 14193 RVA: 0x001DF6F0 File Offset: 0x001DE6F0
			internal void a(object A_0)
			{
				Type type = A_0.GetType();
				this.c = type.GetProperty(this.a);
				if (!(this.c != null))
				{
					PropertyInfo[] properties = type.GetProperties();
					for (int i = 0; i < properties.Length; i++)
					{
						if (properties[i].Name.ToLower() == this.a.ToLower())
						{
							this.c = properties[i];
							break;
						}
					}
				}
			}

			// Token: 0x06003772 RID: 14194 RVA: 0x001DF778 File Offset: 0x001DE778
			internal object b(object A_0)
			{
				if (this.c == null)
				{
					this.a(A_0);
				}
				object result;
				if (this.c == null)
				{
					result = null;
				}
				else
				{
					object value = this.c.GetValue(A_0, null);
					if (this.b == null)
					{
						result = value;
					}
					else
					{
						result = this.b.b(value);
					}
				}
				return result;
			}

			// Token: 0x04001A3C RID: 6716
			private string a;

			// Token: 0x04001A3D RID: 6717
			private akp.a b = null;

			// Token: 0x04001A3E RID: 6718
			private PropertyInfo c = null;
		}
	}
}
