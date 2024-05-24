using System;
using System.Collections.Generic;

namespace PCmoverCertificate
{
	// Token: 0x02000005 RID: 5
	public class DistinguishedName
	{
		// Token: 0x06000013 RID: 19 RVA: 0x000033EC File Offset: 0x000015EC
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
			int num2;
			string text;
			string text2;
			while (i < dn.Length)
			{
				num2 = i;
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
					if (!inNamePart || num != 0 || !char.IsWhiteSpace(c))
					{
						if (inNamePart)
						{
							namePart[num++] = c;
						}
						else
						{
							valuePart[length++] = c;
						}
					}
				}
			}
			text = new string(namePart, 0, num);
			text2 = new string(valuePart, 0, length);
			string name2 = text;
			string value2 = text2;
			num2 = index + 1;
			index = num2;
			yield return new DistinguishedName.Part(name2, value2, num2);
			yield break;
		}

		// Token: 0x0200000E RID: 14
		public struct Part
		{
			// Token: 0x06000041 RID: 65 RVA: 0x00003481 File Offset: 0x00001681
			public Part(string name, string value, int index = -1)
			{
				this = default(DistinguishedName.Part);
				this.Name = name;
				this.Value = value;
				this.Index = index;
			}

			// Token: 0x17000011 RID: 17
			// (get) Token: 0x06000042 RID: 66 RVA: 0x0000349F File Offset: 0x0000169F
			// (set) Token: 0x06000043 RID: 67 RVA: 0x000034A7 File Offset: 0x000016A7
			public string Name { get; private set; }

			// Token: 0x17000012 RID: 18
			// (get) Token: 0x06000044 RID: 68 RVA: 0x000034B0 File Offset: 0x000016B0
			// (set) Token: 0x06000045 RID: 69 RVA: 0x000034B8 File Offset: 0x000016B8
			public string Value { get; private set; }

			// Token: 0x17000013 RID: 19
			// (get) Token: 0x06000046 RID: 70 RVA: 0x000034C1 File Offset: 0x000016C1
			// (set) Token: 0x06000047 RID: 71 RVA: 0x000034C9 File Offset: 0x000016C9
			public int Index { get; private set; }

			// Token: 0x06000048 RID: 72 RVA: 0x000034D2 File Offset: 0x000016D2
			public bool IsNamed(string name)
			{
				return string.Equals(name, this.Name, StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
