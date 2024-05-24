using System;

namespace zz93
{
	// Token: 0x020003F1 RID: 1009
	internal class aag
	{
		// Token: 0x06002A21 RID: 10785 RVA: 0x0018884E File Offset: 0x0018784E
		private aag(uint[] A_0)
		{
			this.a = new h(A_0);
		}

		// Token: 0x06002A22 RID: 10786 RVA: 0x00188868 File Offset: 0x00187868
		internal bool a(byte[] A_0, byte[] A_1)
		{
			h a_ = this.a(A_0);
			h h = new h(A_1);
			h a_2 = h.o(aag.b, this.a);
			return h.k(a_, a_2);
		}

		// Token: 0x06002A23 RID: 10787 RVA: 0x001888A4 File Offset: 0x001878A4
		private h a(byte[] A_0)
		{
			byte[] array = new byte[64];
			aag.c.CopyTo(array, 0);
			cz.b(A_0).CopyTo(array, 48);
			return new h(array);
		}

		// Token: 0x06002A24 RID: 10788 RVA: 0x001888E0 File Offset: 0x001878E0
		internal static aag d()
		{
			if (aag.d == null)
			{
				uint[] a_ = new uint[]
				{
					2969310335U,
					1425626445U,
					3434309874U,
					2047340596U,
					187349008U,
					696091894U,
					3115903355U,
					2807259993U,
					2346414635U,
					3329225083U,
					826128509U,
					3558005711U,
					448315342U,
					1083732298U,
					701507513U,
					1570809485U
				};
				aag.d = new aag(a_);
			}
			return aag.d;
		}

		// Token: 0x06002A25 RID: 10789 RVA: 0x00188928 File Offset: 0x00187928
		internal static aag c()
		{
			if (aag.e == null)
			{
				uint[] a_ = new uint[]
				{
					3739292134U,
					3691016945U,
					888185209U,
					474852925U,
					4114165535U,
					285634386U,
					3026154579U,
					1863708031U,
					3475728798U,
					210241268U,
					270827261U,
					2937499202U,
					3507336750U,
					1978794624U,
					344452059U,
					939807095U
				};
				aag.e = new aag(a_);
			}
			return aag.e;
		}

		// Token: 0x06002A26 RID: 10790 RVA: 0x00188970 File Offset: 0x00187970
		internal static aag b()
		{
			if (aag.f == null)
			{
				uint[] a_ = new uint[]
				{
					3341750096U,
					480617691U,
					1283518144U,
					2304905301U,
					3801484592U,
					494570221U,
					2701727726U,
					878701564U,
					564108977U,
					68888700U,
					364354746U,
					1025936993U,
					1887092384U,
					1388007389U,
					2513161250U,
					2703470523U
				};
				aag.f = new aag(a_);
			}
			return aag.f;
		}

		// Token: 0x06002A27 RID: 10791 RVA: 0x001889B8 File Offset: 0x001879B8
		internal static aag a()
		{
			if (aag.g == null)
			{
				uint[] a_ = new uint[]
				{
					2695193705U,
					2281188357U,
					2681936949U,
					1551811575U,
					4099751659U,
					538559394U,
					1438487034U,
					3673051350U,
					3002885061U,
					2219758703U,
					415477617U,
					3018670943U,
					3688874029U,
					3389870945U,
					1530380843U,
					4257648733U
				};
				aag.g = new aag(a_);
			}
			return aag.g;
		}

		// Token: 0x0400135F RID: 4959
		private h a;

		// Token: 0x04001360 RID: 4960
		private static h b = new h(65537U);

		// Token: 0x04001361 RID: 4961
		private static byte[] c = new byte[]
		{
			0,
			1,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			byte.MaxValue,
			0,
			48,
			32,
			48,
			12,
			6,
			8,
			42,
			134,
			72,
			134,
			247,
			13,
			2,
			5,
			5,
			0,
			4,
			16
		};

		// Token: 0x04001362 RID: 4962
		private static aag d = null;

		// Token: 0x04001363 RID: 4963
		private static aag e = null;

		// Token: 0x04001364 RID: 4964
		private static aag f = null;

		// Token: 0x04001365 RID: 4965
		private static aag g = null;
	}
}
