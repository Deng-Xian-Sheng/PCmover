using System;
using System.Collections.Generic;
using System.Data;

namespace ceTe.DynamicPDF.LayoutEngine.Data
{
	// Token: 0x0200093F RID: 2367
	public class DataReaderReportData : ReportData
	{
		// Token: 0x0600601F RID: 24607 RVA: 0x0035FDEC File Offset: 0x0035EDEC
		public DataReaderReportData(IDbConnection connection, IDataReader reader)
		{
			this.a = connection;
			this.b = reader;
			this.c = reader;
			this.d = new List<string>();
			for (int i = 0; i < reader.FieldCount; i++)
			{
				this.d.Add(reader.GetName(i).ToLower());
			}
			this.g = reader.Read();
		}

		// Token: 0x06006020 RID: 24608 RVA: 0x0035FE69 File Offset: 0x0035EE69
		internal override void mn()
		{
			this.e++;
			this.f++;
		}

		// Token: 0x06006021 RID: 24609 RVA: 0x0035FE88 File Offset: 0x0035EE88
		internal override void mo()
		{
			this.e--;
		}

		// Token: 0x06006022 RID: 24610 RVA: 0x0035FE9C File Offset: 0x0035EE9C
		internal override bool mp(LayoutWriter A_0)
		{
			bool result;
			if (this.f > this.e)
			{
				this.f--;
				result = this.g;
			}
			else
			{
				if (base.a().a())
				{
					base.a().b().a(A_0);
				}
				if (this.b != null)
				{
					this.g = this.b.Read();
				}
				result = this.g;
			}
			return result;
		}

		// Token: 0x17000A3F RID: 2623
		public override object this[string fieldName]
		{
			get
			{
				object result;
				if (this.g)
				{
					result = this.c[fieldName.ToLower()];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06006024 RID: 24612 RVA: 0x0035FF5C File Offset: 0x0035EF5C
		internal override bool mq(string A_0)
		{
			return this.d.Contains(A_0.ToLower());
		}

		// Token: 0x06006025 RID: 24613 RVA: 0x0035FF80 File Offset: 0x0035EF80
		internal override void mr()
		{
			if (this.b != null)
			{
				this.b.Close();
			}
			this.a.Close();
		}

		// Token: 0x17000A40 RID: 2624
		// (get) Token: 0x06006026 RID: 24614 RVA: 0x0035FFB8 File Offset: 0x0035EFB8
		public override bool HasData
		{
			get
			{
				return this.g;
			}
		}

		// Token: 0x17000A41 RID: 2625
		// (get) Token: 0x06006027 RID: 24615 RVA: 0x0035FFD0 File Offset: 0x0035EFD0
		public IDbConnection Connection
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x17000A42 RID: 2626
		// (get) Token: 0x06006028 RID: 24616 RVA: 0x0035FFE8 File Offset: 0x0035EFE8
		public IDataReader DataReader
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x04003178 RID: 12664
		private new IDbConnection a;

		// Token: 0x04003179 RID: 12665
		private IDataReader b;

		// Token: 0x0400317A RID: 12666
		private IDataRecord c;

		// Token: 0x0400317B RID: 12667
		private List<string> d;

		// Token: 0x0400317C RID: 12668
		private int e = 0;

		// Token: 0x0400317D RID: 12669
		private int f = 0;

		// Token: 0x0400317E RID: 12670
		private bool g;
	}
}
