using System;

namespace ceTe.DynamicPDF.PageElements.Forms
{
	// Token: 0x020007E8 RID: 2024
	public class Behavior
	{
		// Token: 0x17000739 RID: 1849
		// (get) Token: 0x0600522F RID: 21039 RVA: 0x0028C6C4 File Offset: 0x0028B6C4
		public static Behavior None
		{
			get
			{
				return Behavior.f;
			}
		}

		// Token: 0x1700073A RID: 1850
		// (get) Token: 0x06005230 RID: 21040 RVA: 0x0028C6DC File Offset: 0x0028B6DC
		public static Behavior Invert
		{
			get
			{
				return Behavior.g;
			}
		}

		// Token: 0x1700073B RID: 1851
		// (get) Token: 0x06005231 RID: 21041 RVA: 0x0028C6F4 File Offset: 0x0028B6F4
		public static Behavior Outline
		{
			get
			{
				return Behavior.h;
			}
		}

		// Token: 0x1700073C RID: 1852
		// (get) Token: 0x06005232 RID: 21042 RVA: 0x0028C70C File Offset: 0x0028B70C
		public static PushBehavior Push
		{
			get
			{
				return Behavior.i;
			}
		}

		// Token: 0x06005233 RID: 21043 RVA: 0x0028C724 File Offset: 0x0028B724
		public static PushBehavior CreatePush(string downLabel)
		{
			return new PushBehavior(downLabel);
		}

		// Token: 0x06005234 RID: 21044 RVA: 0x0028C73C File Offset: 0x0028B73C
		public static PushBehavior CreatePush(string downLabel, string rolloverLabel)
		{
			return new PushBehavior(downLabel, rolloverLabel);
		}

		// Token: 0x06005235 RID: 21045 RVA: 0x0028C755 File Offset: 0x0028B755
		internal Behavior(int A_0)
		{
			this.e = A_0;
		}

		// Token: 0x06005236 RID: 21046 RVA: 0x0028C768 File Offset: 0x0028B768
		internal int a()
		{
			return this.e;
		}

		// Token: 0x04002BEE RID: 11246
		internal static int a = 78;

		// Token: 0x04002BEF RID: 11247
		internal static int b = 73;

		// Token: 0x04002BF0 RID: 11248
		internal static int c = 79;

		// Token: 0x04002BF1 RID: 11249
		internal static int d = 80;

		// Token: 0x04002BF2 RID: 11250
		private int e;

		// Token: 0x04002BF3 RID: 11251
		private static Behavior f = new Behavior(Behavior.a);

		// Token: 0x04002BF4 RID: 11252
		private static Behavior g = new Behavior(Behavior.b);

		// Token: 0x04002BF5 RID: 11253
		private static Behavior h = new Behavior(Behavior.c);

		// Token: 0x04002BF6 RID: 11254
		private static PushBehavior i = new PushBehavior(Behavior.d);
	}
}
