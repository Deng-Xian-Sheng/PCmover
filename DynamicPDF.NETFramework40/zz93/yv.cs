using System;
using ceTe.DynamicPDF;
using ceTe.DynamicPDF.IO;

namespace zz93
{
	// Token: 0x020003B6 RID: 950
	internal class yv : OutputIntent
	{
		// Token: 0x0600282F RID: 10287 RVA: 0x001750BC File Offset: 0x001740BC
		internal yv(abj A_0)
		{
			this.f = A_0;
			for (abk abk = A_0.l(); abk != null; abk = abk.d())
			{
				int num = abk.a().j8();
				if (num <= 302722175)
				{
					if (num != 2550191)
					{
						if (num == 302722175)
						{
							this.a = (ab7)abk.c();
							abk.a(false);
						}
					}
					else
					{
						this.d = (ab7)abk.c();
						abk.a(false);
					}
				}
				else if (num != 563004151)
				{
					if (num != 643687095)
					{
						if (num == 839118521)
						{
							this.b = (ab7)abk.c();
							abk.a(false);
						}
					}
					else
					{
						this.c = (ab7)abk.c();
						abk.a(false);
					}
				}
				else
				{
					this.e = abk.c();
					abk.a(false);
				}
			}
		}

		// Token: 0x06002830 RID: 10288 RVA: 0x001751EC File Offset: 0x001741EC
		internal override void g0(DocumentWriter A_0)
		{
			A_0.WriteDictionaryOpen();
			this.f.b(A_0);
			if (this.d != null)
			{
				A_0.WriteName(OutputIntent.f);
				this.d.hz(A_0);
			}
			else if (base.Info != null && base.Info.Length > 0)
			{
				A_0.WriteName(OutputIntent.f);
				A_0.WriteText(base.Info);
			}
			if (this.a != null)
			{
				A_0.WriteName(OutputIntent.c);
				this.a.hz(A_0);
			}
			else if (base.OutputCondition != null && base.OutputCondition.Length > 0)
			{
				A_0.WriteName(OutputIntent.c);
				A_0.WriteText(base.OutputCondition);
			}
			if (this.b != null)
			{
				A_0.WriteName(OutputIntent.d);
				this.b.hz(A_0);
			}
			else if (base.OutputConditionIdentifier != null && base.OutputConditionIdentifier.Length > 0)
			{
				A_0.WriteName(OutputIntent.d);
				A_0.WriteText(base.OutputConditionIdentifier);
			}
			if (this.c != null)
			{
				A_0.WriteName(OutputIntent.e);
				this.c.hz(A_0);
			}
			else if (base.RegistryName != null && base.RegistryName.Length > 0)
			{
				A_0.WriteName(OutputIntent.e);
				A_0.WriteText(base.RegistryName);
			}
			if (this.e != null)
			{
				A_0.WriteName(OutputIntent.g);
				this.e.hz(A_0);
			}
			else
			{
				base.a(A_0);
			}
			A_0.WriteDictionaryClose();
		}

		// Token: 0x06002831 RID: 10289 RVA: 0x001753E0 File Offset: 0x001743E0
		public override string get_OutputCondition()
		{
			string result;
			if (this.a != null)
			{
				result = this.a.kf();
			}
			else
			{
				result = base.OutputCondition;
			}
			return result;
		}

		// Token: 0x06002832 RID: 10290 RVA: 0x00175413 File Offset: 0x00174413
		public override void set_OutputCondition(string value)
		{
			base.OutputCondition = value;
			this.a = null;
		}

		// Token: 0x06002833 RID: 10291 RVA: 0x00175428 File Offset: 0x00174428
		public override string get_OutputConditionIdentifier()
		{
			string result;
			if (this.b != null)
			{
				result = this.b.kf();
			}
			else
			{
				result = base.OutputConditionIdentifier;
			}
			return result;
		}

		// Token: 0x06002834 RID: 10292 RVA: 0x0017545B File Offset: 0x0017445B
		public override void set_OutputConditionIdentifier(string value)
		{
			base.OutputConditionIdentifier = value;
			this.b = null;
		}

		// Token: 0x06002835 RID: 10293 RVA: 0x00175470 File Offset: 0x00174470
		public override string get_RegistryName()
		{
			string result;
			if (this.c != null)
			{
				result = this.c.kf();
			}
			else
			{
				result = base.RegistryName;
			}
			return result;
		}

		// Token: 0x06002836 RID: 10294 RVA: 0x001754A3 File Offset: 0x001744A3
		public override void set_RegistryName(string value)
		{
			base.RegistryName = value;
			this.c = null;
		}

		// Token: 0x06002837 RID: 10295 RVA: 0x001754B8 File Offset: 0x001744B8
		public override string get_Info()
		{
			string result;
			if (this.d != null)
			{
				result = this.d.kf();
			}
			else
			{
				result = base.Info;
			}
			return result;
		}

		// Token: 0x06002838 RID: 10296 RVA: 0x001754EB File Offset: 0x001744EB
		public override void set_Info(string value)
		{
			base.Info = value;
			this.d = null;
		}

		// Token: 0x06002839 RID: 10297 RVA: 0x001754FD File Offset: 0x001744FD
		public override void SetDestOutputProfile(IccProfile iccProfile)
		{
			this.e = null;
			base.SetDestOutputProfile(iccProfile);
		}

		// Token: 0x040011A9 RID: 4521
		private new ab7 a = null;

		// Token: 0x040011AA RID: 4522
		private new ab7 b = null;

		// Token: 0x040011AB RID: 4523
		private new ab7 c = null;

		// Token: 0x040011AC RID: 4524
		private new ab7 d = null;

		// Token: 0x040011AD RID: 4525
		private new abd e = null;

		// Token: 0x040011AE RID: 4526
		private new abj f;
	}
}
