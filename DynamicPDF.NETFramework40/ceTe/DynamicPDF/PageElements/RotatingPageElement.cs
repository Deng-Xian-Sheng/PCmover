using System;
using ceTe.DynamicPDF.IO;
using zz93;

namespace ceTe.DynamicPDF.PageElements
{
	// Token: 0x02000393 RID: 915
	public abstract class RotatingPageElement : TaggablePageElement, ICoordinate
	{
		// Token: 0x06002718 RID: 10008 RVA: 0x00169654 File Offset: 0x00168654
		protected RotatingPageElement(float x, float y, float height) : this(x, y, height, 0f)
		{
		}

		// Token: 0x06002719 RID: 10009 RVA: 0x00169667 File Offset: 0x00168667
		protected RotatingPageElement(float x, float y, float height, float angle)
		{
			this.b = x;
			this.c = x5.a(y);
			this.d = x5.a(height);
			this.e = angle;
		}

		// Token: 0x0600271A RID: 10010 RVA: 0x0016969B File Offset: 0x0016869B
		internal RotatingPageElement(float A_0, x5 A_1, x5 A_2, float A_3)
		{
			this.b = A_0;
			this.c = A_1;
			this.d = A_2;
			this.e = A_3;
		}

		// Token: 0x1700008B RID: 139
		// (get) Token: 0x0600271B RID: 10011 RVA: 0x001696C4 File Offset: 0x001686C4
		// (set) Token: 0x0600271C RID: 10012 RVA: 0x001696DC File Offset: 0x001686DC
		public virtual float Angle
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

		// Token: 0x1700008C RID: 140
		// (get) Token: 0x0600271D RID: 10013 RVA: 0x001696E8 File Offset: 0x001686E8
		// (set) Token: 0x0600271E RID: 10014 RVA: 0x00169700 File Offset: 0x00168700
		public virtual float X
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

		// Token: 0x1700008D RID: 141
		// (get) Token: 0x0600271F RID: 10015 RVA: 0x0016970C File Offset: 0x0016870C
		// (set) Token: 0x06002720 RID: 10016 RVA: 0x0016972A File Offset: 0x0016872A
		public virtual float Y
		{
			get
			{
				return x5.b(this.c);
			}
			set
			{
				this.c = x5.a(value);
			}
		}

		// Token: 0x1700008E RID: 142
		// (get) Token: 0x06002721 RID: 10017 RVA: 0x0016973C File Offset: 0x0016873C
		// (set) Token: 0x06002722 RID: 10018 RVA: 0x0016975A File Offset: 0x0016875A
		public virtual float Height
		{
			get
			{
				return x5.b(this.d);
			}
			set
			{
				this.d = x5.a(value);
			}
		}

		// Token: 0x06002723 RID: 10019
		protected abstract void DrawRotated(PageWriter writer);

		// Token: 0x06002724 RID: 10020 RVA: 0x0016976C File Offset: 0x0016876C
		public override void Draw(PageWriter writer)
		{
			if (writer.Document.Tag != null)
			{
				writer.Document.RequireLicense(3);
			}
			if (this.e != 0f)
			{
				writer.SetDimensionsSimpleRotate(this.X, this.Y, this.e);
				this.DrawRotated(writer);
				writer.ResetDimensions();
			}
			else
			{
				this.DrawRotated(writer);
			}
		}

		// Token: 0x06002725 RID: 10021 RVA: 0x001697E0 File Offset: 0x001687E0
		internal override void b5(dv A_0)
		{
			this.c = x5.f(this.c, A_0.a(this.c));
		}

		// Token: 0x06002726 RID: 10022 RVA: 0x00169800 File Offset: 0x00168800
		internal void a(dv A_0)
		{
			x5 a_ = A_0.a(this.c);
			x5 a_2 = A_0.a(x5.f(this.c, this.d));
			this.c = x5.f(this.c, a_);
			this.d = x5.f(this.d, x5.e(a_2, a_));
		}

		// Token: 0x06002727 RID: 10023 RVA: 0x0016985D File Offset: 0x0016885D
		internal override void b6(acw A_0)
		{
			A_0.c(this.c, x5.f(this.c, this.d));
		}

		// Token: 0x06002728 RID: 10024 RVA: 0x00169880 File Offset: 0x00168880
		internal override x5 b7()
		{
			return this.c;
		}

		// Token: 0x06002729 RID: 10025 RVA: 0x00169898 File Offset: 0x00168898
		internal override x5 b8()
		{
			return x5.f(this.c, this.d);
		}

		// Token: 0x0600272A RID: 10026 RVA: 0x001698BC File Offset: 0x001688BC
		internal x5 l()
		{
			return this.c;
		}

		// Token: 0x0600272B RID: 10027 RVA: 0x001698D4 File Offset: 0x001688D4
		internal void a(x5 A_0)
		{
			this.c = A_0;
		}

		// Token: 0x0600272C RID: 10028 RVA: 0x001698E0 File Offset: 0x001688E0
		internal x5 m()
		{
			return this.d;
		}

		// Token: 0x0600272D RID: 10029 RVA: 0x001698F8 File Offset: 0x001688F8
		internal override void b9(x5 A_0)
		{
			this.c = x5.e(this.c, A_0);
			this.d = x5.f(this.d, A_0);
		}

		// Token: 0x0600272E RID: 10030 RVA: 0x0016991F File Offset: 0x0016891F
		internal override void ca(x5 A_0)
		{
			this.c = x5.e(this.c, A_0);
		}

		// Token: 0x040010FC RID: 4348
		private new const float a = 0f;

		// Token: 0x040010FD RID: 4349
		private float b;

		// Token: 0x040010FE RID: 4350
		private x5 c;

		// Token: 0x040010FF RID: 4351
		private new x5 d;

		// Token: 0x04001100 RID: 4352
		private float e;
	}
}
