using System;
using System.Collections.Specialized;
using ceTe.DynamicPDF.LayoutEngine;
using ceTe.DynamicPDF.LayoutEngine.LayoutElements;

namespace zz93
{
	// Token: 0x020005D7 RID: 1495
	internal class and : alo
	{
		// Token: 0x06003B3C RID: 15164 RVA: 0x001FB9DD File Offset: 0x001FA9DD
		internal and()
		{
		}

		// Token: 0x06003B3D RID: 15165 RVA: 0x001FB9F0 File Offset: 0x001FA9F0
		ahs alo.a()
		{
			return this.d();
		}

		// Token: 0x06003B3E RID: 15166 RVA: 0x001FBA08 File Offset: 0x001FAA08
		string alo.b()
		{
			return "Page";
		}

		// Token: 0x06003B3F RID: 15167 RVA: 0x001FBA20 File Offset: 0x001FAA20
		DocumentLayoutPart alo.c()
		{
			return this.c;
		}

		// Token: 0x06003B40 RID: 15168 RVA: 0x001FBA38 File Offset: 0x001FAA38
		internal ahs d()
		{
			if (this.a == null)
			{
				this.a = new ahs();
			}
			return this.a;
		}

		// Token: 0x06003B41 RID: 15169 RVA: 0x001FBA70 File Offset: 0x001FAA70
		internal bool e()
		{
			return this.a != null && this.a.b() != 0;
		}

		// Token: 0x06003B42 RID: 15170 RVA: 0x001FBAAC File Offset: 0x001FAAAC
		internal aig f()
		{
			if (this.b == null)
			{
				this.b = new aig();
			}
			return this.b;
		}

		// Token: 0x06003B43 RID: 15171 RVA: 0x001FBAE1 File Offset: 0x001FAAE1
		internal void a(aig A_0)
		{
			this.b = A_0;
		}

		// Token: 0x06003B44 RID: 15172 RVA: 0x001FBAEC File Offset: 0x001FAAEC
		internal HybridDictionary g()
		{
			HybridDictionary result;
			if (this.d == null)
			{
				this.d = new HybridDictionary();
				result = this.d;
			}
			else
			{
				result = this.d;
			}
			return result;
		}

		// Token: 0x06003B45 RID: 15173 RVA: 0x001FBB2C File Offset: 0x001FAB2C
		bool alo.h()
		{
			return false;
		}

		// Token: 0x06003B46 RID: 15174 RVA: 0x001FBB3F File Offset: 0x001FAB3F
		void alo.a(SubReport A_0)
		{
		}

		// Token: 0x04001BE6 RID: 7142
		private ahs a;

		// Token: 0x04001BE7 RID: 7143
		private aig b;

		// Token: 0x04001BE8 RID: 7144
		private DocumentLayoutPart c = null;

		// Token: 0x04001BE9 RID: 7145
		private HybridDictionary d;
	}
}
