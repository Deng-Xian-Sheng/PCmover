using System;
using System.Collections;
using System.Text;

namespace zz93
{
	// Token: 0x020004BC RID: 1212
	internal class afp : IEnumerator
	{
		// Token: 0x060031D3 RID: 12755 RVA: 0x001BE36C File Offset: 0x001BD36C
		internal void a(string A_0)
		{
			char[] array = A_0.ToCharArray();
			StringBuilder stringBuilder = new StringBuilder();
			afq afq = afq.a;
			int i = 0;
			int num = -1;
			while (i < array.Length)
			{
				switch (afq)
				{
				case afq.a:
				{
					char c = array[i];
					if (c != '.')
					{
						if (c != '[')
						{
							stringBuilder.Append(array[i++]);
						}
						else
						{
							stringBuilder.Append(array[i++]);
							afq = afq.b;
							num = i;
						}
					}
					else if (i != array.Length - 1 && array[i + 1] == '#')
					{
						afq = afq.c;
						i += 3;
					}
					else
					{
						stringBuilder.Append(array[i]);
						i++;
					}
					break;
				}
				case afq.b:
					if (array[i] == ']' && num != -1)
					{
						char[] array2 = this.a(array, num, i);
						if (array2 != null)
						{
							stringBuilder.Append(array2);
						}
						stringBuilder.Append(array[i]);
						afq = afq.a;
						num = -1;
					}
					i++;
					break;
				case afq.c:
					if (array[i++] == ']')
					{
						afq = afq.a;
					}
					break;
				}
			}
			this.a = stringBuilder.ToString().Split(new char[]
			{
				'.'
			});
			this.Reset();
		}

		// Token: 0x060031D4 RID: 12756 RVA: 0x001BE4C4 File Offset: 0x001BD4C4
		private char[] a(char[] A_0, int A_1, int A_2)
		{
			if (A_2 > A_1)
			{
				int num;
				if (int.TryParse(new string(A_0, A_1, A_2 - A_1), out num))
				{
					num++;
					return num.ToString().ToCharArray();
				}
			}
			return null;
		}

		// Token: 0x060031D5 RID: 12757 RVA: 0x001BE510 File Offset: 0x001BD510
		public object get_Current()
		{
			return this.a[this.b];
		}

		// Token: 0x060031D6 RID: 12758 RVA: 0x001BE530 File Offset: 0x001BD530
		public bool MoveNext()
		{
			this.b++;
			return this.b <= this.a.Length - 1;
		}

		// Token: 0x060031D7 RID: 12759 RVA: 0x001BE56E File Offset: 0x001BD56E
		public void Reset()
		{
			this.b = -1;
		}

		// Token: 0x04001750 RID: 5968
		private string[] a;

		// Token: 0x04001751 RID: 5969
		private int b = -1;
	}
}
