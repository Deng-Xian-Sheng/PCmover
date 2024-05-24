using System;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x02000809 RID: 2057
	public class SqlQuery : Query
	{
		// Token: 0x0600534E RID: 21326 RVA: 0x00291675 File Offset: 0x00290675
		internal SqlQuery(wl A_0) : base(A_0.f())
		{
			this.a = A_0.b();
			this.b = A_0.c();
			this.c = A_0.a();
		}

		// Token: 0x17000789 RID: 1929
		// (get) Token: 0x0600534F RID: 21327 RVA: 0x002916AC File Offset: 0x002906AC
		// (set) Token: 0x06005350 RID: 21328 RVA: 0x002916C9 File Offset: 0x002906C9
		public string Sql
		{
			get
			{
				return this.c.f();
			}
			set
			{
				this.c = new tu(value);
			}
		}

		// Token: 0x06005351 RID: 21329 RVA: 0x002916D8 File Offset: 0x002906D8
		protected override RecordSet GetRecordSet(LayoutWriter writer)
		{
			RecordSet result;
			switch (this.b)
			{
			case ProviderType.MsSql:
				result = this.d(writer);
				break;
			case ProviderType.Odbc:
				result = this.a(writer);
				break;
			case ProviderType.OleDb:
				result = this.b(writer);
				break;
			case ProviderType.Oracle:
				result = this.c(writer);
				break;
			default:
				throw new ReportWriterException("Invalid providerType specified.");
			}
			return result;
		}

		// Token: 0x06005352 RID: 21330 RVA: 0x0029173C File Offset: 0x0029073C
		private RecordSet d(LayoutWriter A_0)
		{
			SqlConnection sqlConnection = new SqlConnection(this.a);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand(this.c.a(A_0), sqlConnection);
			return new DataReaderRecordSet(this, sqlConnection, sqlCommand.ExecuteReader());
		}

		// Token: 0x06005353 RID: 21331 RVA: 0x00291784 File Offset: 0x00290784
		private RecordSet c(LayoutWriter A_0)
		{
			OracleConnection oracleConnection = new OracleConnection(this.a);
			oracleConnection.Open();
			OracleCommand oracleCommand = new OracleCommand(this.c.a(A_0), oracleConnection);
			return new DataReaderRecordSet(this, oracleConnection, oracleCommand.ExecuteReader());
		}

		// Token: 0x06005354 RID: 21332 RVA: 0x002917CC File Offset: 0x002907CC
		private RecordSet b(LayoutWriter A_0)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(this.a);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(this.c.a(A_0), oleDbConnection);
			return new DataReaderRecordSet(this, oleDbConnection, oleDbCommand.ExecuteReader());
		}

		// Token: 0x06005355 RID: 21333 RVA: 0x00291814 File Offset: 0x00290814
		private RecordSet a(LayoutWriter A_0)
		{
			OdbcConnection odbcConnection = new OdbcConnection(this.a);
			odbcConnection.Open();
			OdbcCommand odbcCommand = new OdbcCommand(this.c.a(A_0), odbcConnection);
			return new DataReaderRecordSet(this, odbcConnection, odbcCommand.ExecuteReader());
		}

		// Token: 0x1700078A RID: 1930
		// (get) Token: 0x06005356 RID: 21334 RVA: 0x0029185C File Offset: 0x0029085C
		// (set) Token: 0x06005357 RID: 21335 RVA: 0x00291874 File Offset: 0x00290874
		public string ConnectionString
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

		// Token: 0x1700078B RID: 1931
		// (get) Token: 0x06005358 RID: 21336 RVA: 0x00291880 File Offset: 0x00290880
		// (set) Token: 0x06005359 RID: 21337 RVA: 0x00291898 File Offset: 0x00290898
		public ProviderType ProviderType
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

		// Token: 0x04002CB2 RID: 11442
		internal new string a;

		// Token: 0x04002CB3 RID: 11443
		private ProviderType b;

		// Token: 0x04002CB4 RID: 11444
		private tu c;
	}
}
