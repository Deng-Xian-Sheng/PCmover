using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000748 RID: 1864
	public class UnorderedListItemList : ListItemList
	{
		// Token: 0x06004BBD RID: 19389 RVA: 0x002658A9 File Offset: 0x002648A9
		internal UnorderedListItemList(UnorderedSubList A_0) : base(A_0)
		{
			this.a = A_0;
		}

		// Token: 0x06004BBE RID: 19390 RVA: 0x002658BC File Offset: 0x002648BC
		internal override float i8(PageWriter A_0, float A_1, float A_2, ae7 A_3, float A_4)
		{
			int num = 0;
			int num2 = 0;
			ae7 a_ = A_3;
			if (A_3 != null)
			{
				object obj = A_3.e();
				if (obj != null)
				{
					num = (int)obj;
				}
				a_ = A_3.f();
				if (A_3.a() - 2 == A_3.b())
				{
					num2 = (int)A_3.c();
				}
			}
			int i = num;
			while (i <= base.Count - 1)
			{
				ListItem listItem = base[i];
				if (A_3 != null)
				{
					if (A_3.b() < A_3.a() - 2)
					{
						num2 = -1;
					}
					else if (A_3.a() - 1 == A_3.b())
					{
						num2 = 0;
					}
				}
				if (A_0.Document.Tag != null)
				{
					bool a_2 = listItem.aa() == 1 && listItem.Leading + listItem.u() + listItem.s() > A_4 && num2 == 0;
					base.a(A_0, listItem, A_1, A_2, a_2);
				}
				float num3 = listItem.a(a_);
				if (num3 < A_4 || (A_4 == base.b() && listItem.ad() == 1))
				{
					if (num2 == 0)
					{
						if (this.a.BulletStyle != UnorderedListStyle.None)
						{
							this.a.BulletStyle.a(A_0, A_1, A_2 + listItem.u(), listItem, this.a.BulletStyle);
						}
					}
					A_2 = listItem.a(A_0, A_1, A_2, A_4, A_3);
					A_4 -= num3;
					i++;
				}
				else
				{
					if (listItem.aa() > 1 && listItem.Leading + listItem.u() > A_4 && num2 == 0 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (listItem.aa() == 1 && listItem.Leading + listItem.u() + listItem.s() > A_4 && num2 == 0 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (num2 > 0 && listItem.Leading > A_4 && (A_4 != base.b() || base.b() < 0f))
					{
						break;
					}
					if (num2 == 0)
					{
						if (this.a.BulletStyle != UnorderedListStyle.None)
						{
							this.a.BulletStyle.a(A_0, A_1, A_2 + listItem.u(), listItem, this.a.BulletStyle);
						}
					}
					listItem.a(base.b());
					A_2 = listItem.a(A_0, A_1, A_2, A_4, A_3);
					break;
				}
			}
			return A_2;
		}

		// Token: 0x040028E2 RID: 10466
		private new UnorderedSubList a;
	}
}
