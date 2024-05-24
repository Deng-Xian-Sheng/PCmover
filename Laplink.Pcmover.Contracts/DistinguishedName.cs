using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Contracts
{
	// Token: 0x02000035 RID: 53
	public static class DistinguishedName
	{
		// Token: 0x06000127 RID: 295 RVA: 0x00002F03 File Offset: 0x00001103
		public static IEnumerable<DistinguishedName.Part> Parse(string dn)
		{
			int i = 0;
			int num = 0;
			int length = 0;
			int index = -1;
			bool inNamePart = true;
			bool flag = false;
			char[] namePart = new char[50];
			char[] valuePart = new char[200];
			string text;
			string text2;
			while (i < dn.Length)
			{
				int num2 = i;
				i = num2 + 1;
				char c = dn[num2];
				if (!inNamePart && c == '"')
				{
					flag = !flag;
				}
				else
				{
					if (!flag)
					{
						if (c == '\\')
						{
							valuePart[length++] = c;
							char[] array = valuePart;
							int num3 = length++;
							num2 = i;
							i = num2 + 1;
							array[num3] = dn[num2];
							continue;
						}
						if (c == '=')
						{
							inNamePart = false;
							flag = false;
							continue;
						}
						if (c == ',')
						{
							inNamePart = true;
							text = new string(namePart, 0, num);
							text2 = new string(valuePart, 0, length);
							string name = text;
							string value = text2;
							num2 = index + 1;
							index = num2;
							yield return new DistinguishedName.Part(name, value, num2);
							flag = false;
							length = (num = 0);
							continue;
						}
					}
					if (inNamePart)
					{
						if (num != 0 || !char.IsWhiteSpace(c))
						{
							namePart[num++] = c;
						}
					}
					else
					{
						valuePart[length++] = c;
					}
				}
			}
			text = new string(namePart, 0, num);
			text2 = new string(valuePart, 0, length);
			yield return new DistinguishedName.Part(text, text2, index + 1);
			yield break;
		}

		// Token: 0x0200009D RID: 157
		public struct Part
		{
			// Token: 0x06000424 RID: 1060 RVA: 0x00004BAA File Offset: 0x00002DAA
			public Part(string name, string value, int index = -1)
			{
				this = default(DistinguishedName.Part);
				this.Name = name;
				this.Value = value;
				this.Index = index;
			}

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x06000425 RID: 1061 RVA: 0x00004BC8 File Offset: 0x00002DC8
			// (set) Token: 0x06000426 RID: 1062 RVA: 0x00004BD0 File Offset: 0x00002DD0
			public string Name { get; private set; }

			// Token: 0x1700018E RID: 398
			// (get) Token: 0x06000427 RID: 1063 RVA: 0x00004BD9 File Offset: 0x00002DD9
			// (set) Token: 0x06000428 RID: 1064 RVA: 0x00004BE1 File Offset: 0x00002DE1
			public string Value { get; private set; }

			// Token: 0x1700018F RID: 399
			// (get) Token: 0x06000429 RID: 1065 RVA: 0x00004BEA File Offset: 0x00002DEA
			// (set) Token: 0x0600042A RID: 1066 RVA: 0x00004BF2 File Offset: 0x00002DF2
			public int Index { get; private set; }

			// Token: 0x0600042B RID: 1067 RVA: 0x00004BFB File Offset: 0x00002DFB
			public bool IsNamed(string name)
			{
				return string.Equals(name, this.Name, StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
