using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using ceTe.DynamicPDF.ReportWriter.IO;
using zz93;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x0200080A RID: 2058
	public class StoredProcedureQuery : Query
	{
		// Token: 0x0600535A RID: 21338 RVA: 0x002918A4 File Offset: 0x002908A4
		internal StoredProcedureQuery(wm A_0) : base(A_0.f())
		{
			this.a = A_0.c();
			this.b = A_0.d();
			this.c = A_0.a();
			if (A_0.b() != null)
			{
				this.d = new vh(A_0.b());
			}
			this.e = A_0.e();
		}

		// Token: 0x0600535B RID: 21339 RVA: 0x00291918 File Offset: 0x00290918
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

		// Token: 0x0600535C RID: 21340 RVA: 0x0029197C File Offset: 0x0029097C
		private RecordSet d(LayoutWriter A_0)
		{
			SqlConnection sqlConnection = new SqlConnection(this.a);
			sqlConnection.Open();
			SqlCommand sqlCommand = new SqlCommand(this.c, sqlConnection);
			sqlCommand.CommandType = CommandType.StoredProcedure;
			if (this.d != null)
			{
				this.d.a(A_0, sqlCommand);
			}
			return new DataReaderRecordSet(this, sqlConnection, sqlCommand.ExecuteReader());
		}

		// Token: 0x0600535D RID: 21341 RVA: 0x002919E0 File Offset: 0x002909E0
		private RecordSet c(LayoutWriter A_0)
		{
			OracleConnection oracleConnection = new OracleConnection(this.a);
			oracleConnection.Open();
			OracleCommand oracleCommand = new OracleCommand(this.c, oracleConnection);
			oracleCommand.CommandType = CommandType.StoredProcedure;
			if (this.d != null)
			{
				this.d.a(A_0, oracleCommand);
			}
			oracleCommand.ExecuteNonQuery();
			return new DataReaderRecordSet(this, oracleConnection, oracleCommand);
		}

		// Token: 0x0600535E RID: 21342 RVA: 0x00291A44 File Offset: 0x00290A44
		private RecordSet b(LayoutWriter A_0)
		{
			OleDbConnection oleDbConnection = new OleDbConnection(this.a);
			oleDbConnection.Open();
			OleDbCommand oleDbCommand = new OleDbCommand(this.c, oleDbConnection);
			oleDbCommand.CommandType = CommandType.StoredProcedure;
			if (this.d != null)
			{
				this.d.a(A_0, oleDbCommand);
			}
			return new DataReaderRecordSet(this, oleDbConnection, oleDbCommand.ExecuteReader());
		}

		// Token: 0x0600535F RID: 21343 RVA: 0x00291AA8 File Offset: 0x00290AA8
		private RecordSet a(LayoutWriter A_0)
		{
			OdbcConnection odbcConnection = new OdbcConnection(this.a);
			odbcConnection.Open();
			OdbcCommand odbcCommand = new OdbcCommand(this.c, odbcConnection);
			odbcCommand.CommandType = CommandType.StoredProcedure;
			if (this.d != null)
			{
				this.d.a(A_0, odbcCommand);
			}
			return new DataReaderRecordSet(this, odbcConnection, odbcCommand.ExecuteReader());
		}

		// Token: 0x1700078C RID: 1932
		// (get) Token: 0x06005360 RID: 21344 RVA: 0x00291B0C File Offset: 0x00290B0C
		// (set) Token: 0x06005361 RID: 21345 RVA: 0x00291B24 File Offset: 0x00290B24
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

		// Token: 0x1700078D RID: 1933
		// (get) Token: 0x06005362 RID: 21346 RVA: 0x00291B30 File Offset: 0x00290B30
		// (set) Token: 0x06005363 RID: 21347 RVA: 0x00291B48 File Offset: 0x00290B48
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

		// Token: 0x06005364 RID: 21348 RVA: 0x00291B54 File Offset: 0x00290B54
		internal string a()
		{
			return this.e;
		}

		// Token: 0x04002CB5 RID: 11445
		internal new string a;

		// Token: 0x04002CB6 RID: 11446
		private ProviderType b;

		// Token: 0x04002CB7 RID: 11447
		private string c;

		// Token: 0x04002CB8 RID: 11448
		private vh d = null;

		// Token: 0x04002CB9 RID: 11449
		private new string e;
	}
}
