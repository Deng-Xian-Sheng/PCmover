using System;
using System.Collections;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E3 RID: 2019
	public class ChoiceItemList
	{
		// Token: 0x060051C0 RID: 20928 RVA: 0x0028B1C8 File Offset: 0x0028A1C8
		public ChoiceItem Add(string itemName)
		{
			return this.Add(itemName, null, false);
		}

		// Token: 0x060051C1 RID: 20929 RVA: 0x0028B1E4 File Offset: 0x0028A1E4
		public ChoiceItem Add(string itemName, string exportValue)
		{
			return this.Add(itemName, exportValue, false);
		}

		// Token: 0x060051C2 RID: 20930 RVA: 0x0028B200 File Offset: 0x0028A200
		public ChoiceItem Add(string itemName, bool selected)
		{
			return this.Add(itemName, null, selected);
		}

		// Token: 0x060051C3 RID: 20931 RVA: 0x0028B21C File Offset: 0x0028A21C
		public ChoiceItem Add(string itemName, string exportValue, bool selected)
		{
			ChoiceItem choiceItem = this[itemName];
			if (choiceItem == null)
			{
				choiceItem = new ChoiceItem(itemName, exportValue, selected);
				this.a.Add(choiceItem);
			}
			return choiceItem;
		}

		// Token: 0x1700070D RID: 1805
		// (get) Token: 0x060051C4 RID: 20932 RVA: 0x0028B25C File Offset: 0x0028A25C
		public int Count
		{
			get
			{
				int result;
				if (this.a != null)
				{
					result = this.a.Count;
				}
				else
				{
					result = 0;
				}
				return result;
			}
		}

		// Token: 0x1700070E RID: 1806
		public ChoiceItem this[int index]
		{
			get
			{
				return (ChoiceItem)this.a[index];
			}
		}

		// Token: 0x1700070F RID: 1807
		public ChoiceItem this[string itemName]
		{
			get
			{
				foreach (object obj in this.a)
				{
					ChoiceItem choiceItem = (ChoiceItem)obj;
					if (choiceItem.ItemName.Equals(itemName))
					{
						return choiceItem;
					}
				}
				return null;
			}
		}

		// Token: 0x060051C7 RID: 20935 RVA: 0x0028B330 File Offset: 0x0028A330
		public void Remove(int index)
		{
			this.a.RemoveAt(index);
		}

		// Token: 0x060051C8 RID: 20936 RVA: 0x0028B340 File Offset: 0x0028A340
		internal int a(ChoiceItem A_0)
		{
			return this.a.IndexOf(A_0);
		}

		// Token: 0x060051C9 RID: 20937 RVA: 0x0028B360 File Offset: 0x0028A360
		internal ChoiceItem[] a()
		{
			ChoiceItem[] array = new ChoiceItem[this.a.Count];
			int num = 0;
			foreach (object obj in this.a)
			{
				ChoiceItem choiceItem = (ChoiceItem)obj;
				if (choiceItem.Selected)
				{
					array[num++] = choiceItem;
				}
			}
			ChoiceItem[] array2 = new ChoiceItem[num];
			Array.Copy(array, array2, num);
			array = array2;
			return array;
		}

		// Token: 0x04002BC1 RID: 11201
		private ArrayList a = new ArrayList();
	}
}
