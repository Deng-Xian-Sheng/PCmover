using System;
using System.Runtime.InteropServices;

// Token: 0x02000002 RID: 2
[AttributeUsage(AttributeTargets.Assembly)]
[ComVisible(false)]
public sealed class DotfuscatorAttribute : Attribute
{
	// Token: 0x06000001 RID: 1 RVA: 0x0001400C File Offset: 0x0001300C
	public DotfuscatorAttribute(string a, int c)
	{
		this.a = a;
		this.c = c;
	}

	// Token: 0x17000001 RID: 1
	// (get) Token: 0x06000002 RID: 2 RVA: 0x00014030 File Offset: 0x00013030
	public string A
	{
		get
		{
			return this.a;
		}
	}

	// Token: 0x17000002 RID: 2
	// (get) Token: 0x06000003 RID: 3 RVA: 0x00014044 File Offset: 0x00013044
	public int C
	{
		get
		{
			return this.c;
		}
	}

	// Token: 0x04000001 RID: 1
	private string a;

	// Token: 0x04000002 RID: 2
	private int c;
}
