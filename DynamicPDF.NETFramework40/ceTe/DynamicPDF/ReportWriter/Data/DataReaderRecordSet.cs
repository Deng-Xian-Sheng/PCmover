using System;
using System.Collections;
using System.Data;
using System.Data.OracleClient;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x020007FE RID: 2046
	public class DataReaderRecordSet : RecordSet
	{
		// Token: 0x0600530D RID: 21261 RVA: 0x002909B8 File Offset: 0x0028F9B8
		public DataReaderRecordSet(IDbConnection connection, IDataReader reader)
		{
			this.a = connection;
			this.b = reader;
			this.c = reader;
			this.f = reader.Read();
		}

		// Token: 0x0600530E RID: 21262 RVA: 0x00290A04 File Offset: 0x0028FA04
		internal DataReaderRecordSet(Query A_0, IDbConnection A_1, IDataReader A_2) : base(A_0)
		{
			this.a = A_1;
			this.b = A_2;
			this.c = A_2;
			this.f = A_2.Read();
		}

		// Token: 0x0600530F RID: 21263 RVA: 0x00290A54 File Offset: 0x0028FA54
		internal DataReaderRecordSet(Query A_0, IDbConnection A_1, OracleCommand A_2) : base(A_0)
		{
			OracleParameterCollection parameters = A_2.Parameters;
			string parameterName = ((StoredProcedureQuery)A_0).a();
			try
			{
				if (parameterName == "")
				{
					this.b = null;
				}
				else
				{
					this.b = (IDataReader)parameters[parameterName].Value;
					parameters.RemoveAt(parameterName);
				}
			}
			catch
			{
				throw new ReportWriterException("The entry given for Reference Parameter is incorrect; must be one of refcursor parameters name");
			}
			this.a = A_1;
			this.c = this.b;
			if (this.b != null)
			{
				this.f = this.b.Read();
			}
			this.g = parameters;
		}

		// Token: 0x06005310 RID: 21264 RVA: 0x00290B30 File Offset: 0x0028FB30
		internal override void d9()
		{
			this.d++;
			this.e++;
		}

		// Token: 0x06005311 RID: 21265 RVA: 0x00290B4F File Offset: 0x0028FB4F
		internal override void ea()
		{
			this.d--;
		}

		// Token: 0x06005312 RID: 21266 RVA: 0x00290B60 File Offset: 0x0028FB60
		internal override bool d8(LayoutWriter A_0)
		{
			bool result;
			if (this.e > this.d)
			{
				this.e--;
				result = this.f;
			}
			else
			{
				if (base.Query.d())
				{
					base.Query.e().a(A_0);
				}
				if (this.b != null)
				{
					this.f = this.b.Read();
				}
				result = this.f;
			}
			return result;
		}

		// Token: 0x17000779 RID: 1913
		public override object this[string fieldName]
		{
			get
			{
				object result;
				if (this.f)
				{
					result = this.c[fieldName];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x1700077A RID: 1914
		public override object this[int fieldIndex]
		{
			get
			{
				object result;
				if (this.f)
				{
					result = this.c[fieldIndex];
				}
				else
				{
					result = null;
				}
				return result;
			}
		}

		// Token: 0x06005315 RID: 21269 RVA: 0x00290C4C File Offset: 0x0028FC4C
		internal override void eb()
		{
			if (base.Query is ReferenceQuery)
			{
				this.b.Close();
			}
			else
			{
				if (this.b != null)
				{
					this.b.Close();
				}
				this.a.Close();
			}
		}

		// Token: 0x1700077B RID: 1915
		// (get) Token: 0x06005316 RID: 21270 RVA: 0x00290CA8 File Offset: 0x0028FCA8
		public override bool HasData
		{
			get
			{
				return this.f;
			}
		}

		// Token: 0x1700077C RID: 1916
		// (get) Token: 0x06005317 RID: 21271 RVA: 0x00290CC0 File Offset: 0x0028FCC0
		public IDbConnection Connection
		{
			get
			{
				return this.a;
			}
		}

		// Token: 0x1700077D RID: 1917
		// (get) Token: 0x06005318 RID: 21272 RVA: 0x00290CD8 File Offset: 0x0028FCD8
		public IDataReader DataReader
		{
			get
			{
				return this.b;
			}
		}

		// Token: 0x06005319 RID: 21273 RVA: 0x00290CF0 File Offset: 0x0028FCF0
		internal DataReaderRecordSet a(Query A_0, string A_1)
		{
			DataReaderRecordSet result;
			try
			{
				IDataReader a_ = (IDataReader)((OracleParameterCollection)this.g)[A_1].Value;
				((OracleParameterCollection)this.g).RemoveAt(A_1);
				result = new DataReaderRecordSet(A_0, this.a, a_);
			}
			catch
			{
				throw new ReportWriterException("The RefCursor used for ReferenceQuery '" + A_0.Id + "' is incorrect.");
			}
			return result;
		}

		// Token: 0x0600531A RID: 21274 RVA: 0x00290D6C File Offset: 0x0028FD6C
		internal object a(string A_0)
		{
			object result;
			if (this.a.State != ConnectionState.Closed)
			{
				object obj = null;
				switch (((StoredProcedureQuery)base.Query).ProviderType)
				{
				case ProviderType.MsSql:
					throw new ReportWriterException("The out parameters of stored procedures is not supported for MS Sql Server");
				case ProviderType.Odbc:
					throw new ReportWriterException("The out parameters of stored procedures is not supported for Odbc");
				case ProviderType.OleDb:
					throw new ReportWriterException("The out parameters of stored procedures is not supported for OledDb");
				case ProviderType.Oracle:
				{
					OracleParameter oracleParameter = ((OracleParameterCollection)this.g)[A_0];
					if (oracleParameter.OracleType != OracleType.Cursor)
					{
						obj = oracleParameter.Value;
					}
					break;
				}
				}
				result = obj;
			}
			else
			{
				result = null;
			}
			return result;
		}

		// Token: 0x04002C59 RID: 11353
		private new IDbConnection a;

		// Token: 0x04002C5A RID: 11354
		private IDataReader b;

		// Token: 0x04002C5B RID: 11355
		private IDataRecord c;

		// Token: 0x04002C5C RID: 11356
		private int d = 0;

		// Token: 0x04002C5D RID: 11357
		private int e = 0;

		// Token: 0x04002C5E RID: 11358
		private bool f;

		// Token: 0x04002C5F RID: 11359
		private ICollection g = null;
	}
}
