using System;

namespace ceTe.DynamicPDF.Text
{
	// Token: 0x02000869 RID: 2153
	public class TextLine
	{
		// Token: 0x06005756 RID: 22358 RVA: 0x002EC8F0 File Offset: 0x002EB8F0
		public TextLine(int start, int length, int mWidth, float yOffset, int spaceCount, bool newParagraph, bool hardReturn, bool hyphenate)
		{
			this.a = start;
			this.b = length;
			this.g = mWidth;
			this.h = yOffset;
			this.f = spaceCount;
			this.d = newParagraph;
			this.c = hardReturn;
			this.e = hyphenate;
		}

		// Token: 0x17000898 RID: 2200
		// (get) Token: 0x06005757 RID: 22359 RVA: 0x002EC960 File Offset: 0x002EB960
		// (set) Token: 0x06005758 RID: 22360 RVA: 0x002EC978 File Offset: 0x002EB978
		public int Start
		{
			get
			{
				return this.a;
			}
			set
			{
				this.a = value;
			}
		}

		// Token: 0x17000899 RID: 2201
		// (get) Token: 0x06005759 RID: 22361 RVA: 0x002EC984 File Offset: 0x002EB984
		// (set) Token: 0x0600575A RID: 22362 RVA: 0x002EC99C File Offset: 0x002EB99C
		public int Length
		{
			get
			{
				return this.b;
			}
			set
			{
				this.b = value;
			}
		}

		// Token: 0x1700089A RID: 2202
		// (get) Token: 0x0600575B RID: 22363 RVA: 0x002EC9A8 File Offset: 0x002EB9A8
		// (set) Token: 0x0600575C RID: 22364 RVA: 0x002EC9C0 File Offset: 0x002EB9C0
		public bool HardReturn
		{
			get
			{
				return this.c;
			}
			set
			{
				this.c = value;
			}
		}

		// Token: 0x1700089B RID: 2203
		// (get) Token: 0x0600575D RID: 22365 RVA: 0x002EC9CC File Offset: 0x002EB9CC
		// (set) Token: 0x0600575E RID: 22366 RVA: 0x002EC9E4 File Offset: 0x002EB9E4
		public bool NewParagraph
		{
			get
			{
				return this.d;
			}
			set
			{
				this.d = value;
			}
		}

		// Token: 0x1700089C RID: 2204
		// (get) Token: 0x0600575F RID: 22367 RVA: 0x002EC9F0 File Offset: 0x002EB9F0
		// (set) Token: 0x06005760 RID: 22368 RVA: 0x002ECA08 File Offset: 0x002EBA08
		public bool Hyphenate
		{
			get
			{
				return this.e;
			}
			set
			{
				this.e = value;
			}
		}

		// Token: 0x1700089D RID: 2205
		// (get) Token: 0x06005761 RID: 22369 RVA: 0x002ECA14 File Offset: 0x002EBA14
		// (set) Token: 0x06005762 RID: 22370 RVA: 0x002ECA2C File Offset: 0x002EBA2C
		public int SpaceCount
		{
			get
			{
				return this.f;
			}
			set
			{
				this.f = value;
			}
		}

		// Token: 0x1700089E RID: 2206
		// (get) Token: 0x06005763 RID: 22371 RVA: 0x002ECA38 File Offset: 0x002EBA38
		// (set) Token: 0x06005764 RID: 22372 RVA: 0x002ECA50 File Offset: 0x002EBA50
		public int MWidth
		{
			get
			{
				return this.g;
			}
			set
			{
				this.g = value;
			}
		}

		// Token: 0x1700089F RID: 2207
		// (get) Token: 0x06005765 RID: 22373 RVA: 0x002ECA5C File Offset: 0x002EBA5C
		// (set) Token: 0x06005766 RID: 22374 RVA: 0x002ECA74 File Offset: 0x002EBA74
		public float YOffset
		{
			get
			{
				return this.h;
			}
			set
			{
				this.h = value;
			}
		}

		// Token: 0x06005767 RID: 22375 RVA: 0x002ECA80 File Offset: 0x002EBA80
		public float GetWidth(float fontSize)
		{
			return (float)this.g * fontSize / 1000f;
		}

		// Token: 0x04002E66 RID: 11878
		private int a;

		// Token: 0x04002E67 RID: 11879
		private int b;

		// Token: 0x04002E68 RID: 11880
		private bool c = false;

		// Token: 0x04002E69 RID: 11881
		private bool d = false;

		// Token: 0x04002E6A RID: 11882
		private bool e = false;

		// Token: 0x04002E6B RID: 11883
		private int f = 0;

		// Token: 0x04002E6C RID: 11884
		private int g;

		// Token: 0x04002E6D RID: 11885
		private float h;
	}
}
