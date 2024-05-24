using System;
using System.Collections.Generic;

namespace Laplink.Pcmover.Service
{
	// Token: 0x02000008 RID: 8
	public class DistinguishedName
	{
		// Token: 0x0600002D RID: 45 RVA: 0x00003004 File Offset: 0x00001204
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

		// Token: 0x020000E9 RID: 233
		public struct Part
		{
			// Token: 0x06000512 RID: 1298 RVA: 0x00012256 File Offset: 0x00010456
			public Part(string name, string value, int index = -1)
			{
				this = default(DistinguishedName.Part);
				this.Name = name;
				this.Value = value;
				this.Index = index;
			}

			// Token: 0x1700018B RID: 395
			// (get) Token: 0x06000513 RID: 1299 RVA: 0x00012274 File Offset: 0x00010474
			// (set) Token: 0x06000514 RID: 1300 RVA: 0x0001227C File Offset: 0x0001047C
			public string Name { get; private set; }

			// Token: 0x1700018C RID: 396
			// (get) Token: 0x06000515 RID: 1301 RVA: 0x00012285 File Offset: 0x00010485
			// (set) Token: 0x06000516 RID: 1302 RVA: 0x0001228D File Offset: 0x0001048D
			public string Value { get; private set; }

			// Token: 0x1700018D RID: 397
			// (get) Token: 0x06000517 RID: 1303 RVA: 0x00012296 File Offset: 0x00010496
			// (set) Token: 0x06000518 RID: 1304 RVA: 0x0001229E File Offset: 0x0001049E
			public int Index { get; private set; }

			// Token: 0x06000519 RID: 1305 RVA: 0x000122A7 File Offset: 0x000104A7
			public bool IsNamed(string name)
			{
				return string.Equals(name, this.Name, StringComparison.OrdinalIgnoreCase);
			}
		}
	}
}
