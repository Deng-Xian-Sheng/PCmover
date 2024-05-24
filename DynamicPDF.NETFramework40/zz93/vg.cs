using System;
using System.Data;
using System.Data.Odbc;
using System.Data.OleDb;
using System.Data.OracleClient;
using System.Data.SqlClient;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace zz93
{
	// Token: 0x02000331 RID: 817
	internal class vg
	{
		// Token: 0x06002351 RID: 9041 RVA: 0x0014FB54 File Offset: 0x0014EB54
		internal vg(wa A_0)
		{
			this.a = A_0.b();
			this.b = A_0.c();
			this.c = A_0.d();
			this.d = A_0.e();
			this.e = A_0.f();
			this.f = A_0.g();
			this.g = A_0.h();
			this.h = A_0.i();
			this.i = A_0.j();
		}

		// Token: 0x06002352 RID: 9042 RVA: 0x0014FC08 File Offset: 0x0014EC08
		internal void a(LayoutWriter A_0, SqlCommand A_1)
		{
			SqlParameter sqlParameter = new SqlParameter(this.b, this.d(), this.f);
			if (this.i != null)
			{
				sqlParameter.Value = this.i.a().es(A_0);
			}
			else
			{
				sqlParameter.Value = this.h;
			}
			sqlParameter.Direction = this.a;
			sqlParameter.IsNullable = this.c;
			sqlParameter.Precision = this.d;
			sqlParameter.Scale = this.e;
			A_1.Parameters.Add(sqlParameter);
		}

		// Token: 0x06002353 RID: 9043 RVA: 0x0014FCA8 File Offset: 0x0014ECA8
		internal void a(LayoutWriter A_0, OracleCommand A_1)
		{
			OracleParameter oracleParameter = new OracleParameter(this.b, this.c(), this.f);
			if (this.i != null)
			{
				oracleParameter.Value = this.i.a().es(A_0);
			}
			else
			{
				oracleParameter.Value = this.h;
			}
			oracleParameter.Direction = this.a;
			oracleParameter.IsNullable = this.c;
			A_1.Parameters.Add(oracleParameter);
		}

		// Token: 0x06002354 RID: 9044 RVA: 0x0014FD30 File Offset: 0x0014ED30
		internal void a(LayoutWriter A_0, OleDbCommand A_1)
		{
			OleDbParameter oleDbParameter = new OleDbParameter(this.b, this.b(), this.f);
			if (this.i != null)
			{
				oleDbParameter.Value = this.i.a().es(A_0);
			}
			else
			{
				oleDbParameter.Value = this.h;
			}
			oleDbParameter.Direction = this.a;
			oleDbParameter.IsNullable = this.c;
			oleDbParameter.Precision = this.d;
			oleDbParameter.Scale = this.e;
			A_1.Parameters.Add(oleDbParameter);
		}

		// Token: 0x06002355 RID: 9045 RVA: 0x0014FDD0 File Offset: 0x0014EDD0
		internal void a(LayoutWriter A_0, OdbcCommand A_1)
		{
			OdbcParameter odbcParameter = new OdbcParameter(this.b, this.a(), this.f);
			if (this.i != null)
			{
				odbcParameter.Value = this.i.a().es(A_0);
			}
			else
			{
				odbcParameter.Value = this.h;
			}
			odbcParameter.Direction = this.a;
			odbcParameter.IsNullable = this.c;
			odbcParameter.Precision = this.d;
			odbcParameter.Scale = this.e;
			A_1.Parameters.Add(odbcParameter);
		}

		// Token: 0x06002356 RID: 9046 RVA: 0x0014FE70 File Offset: 0x0014EE70
		private SqlDbType d()
		{
			switch (this.g)
			{
			case ParameterType.BigInt:
				return SqlDbType.BigInt;
			case ParameterType.Bit:
				return SqlDbType.Bit;
			case ParameterType.Char:
				return SqlDbType.Char;
			case ParameterType.DateTime:
				return SqlDbType.DateTime;
			case ParameterType.Decimal:
				return SqlDbType.Decimal;
			case ParameterType.Float:
				return SqlDbType.Float;
			case ParameterType.Int:
				return SqlDbType.Int;
			case ParameterType.Money:
				return SqlDbType.Money;
			case ParameterType.NChar:
				return SqlDbType.NChar;
			case ParameterType.NText:
				return SqlDbType.NText;
			case ParameterType.NVarChar:
				return SqlDbType.NVarChar;
			case ParameterType.Real:
				return SqlDbType.Real;
			case ParameterType.SmallDateTime:
				return SqlDbType.SmallDateTime;
			case ParameterType.SmallInt:
				return SqlDbType.SmallInt;
			case ParameterType.SmallMoney:
				return SqlDbType.SmallMoney;
			case ParameterType.Text:
				return SqlDbType.Text;
			case ParameterType.TinyInt:
				return SqlDbType.TinyInt;
			case ParameterType.UniqueIdentifier:
				return SqlDbType.UniqueIdentifier;
			case ParameterType.VarChar:
				return SqlDbType.VarChar;
			}
			throw new ReportWriterException("Invalid parameterType for a MS SQL stored procedure parameter.");
		}

		// Token: 0x06002357 RID: 9047 RVA: 0x00150048 File Offset: 0x0014F048
		private OracleType c()
		{
			switch (this.g)
			{
			case ParameterType.Byte:
				return OracleType.Byte;
			case ParameterType.Char:
				return OracleType.Char;
			case ParameterType.DateTime:
				return OracleType.DateTime;
			case ParameterType.Double:
				return OracleType.Double;
			case ParameterType.Float:
				return OracleType.Float;
			case ParameterType.Int16:
				return OracleType.Int16;
			case ParameterType.Int32:
				return OracleType.Int32;
			case ParameterType.IntervalDayToSecond:
				return OracleType.IntervalDayToSecond;
			case ParameterType.IntervalYearToMonth:
				return OracleType.IntervalYearToMonth;
			case ParameterType.LongVarChar:
				return OracleType.LongVarChar;
			case ParameterType.NChar:
				return OracleType.NChar;
			case ParameterType.Number:
				return OracleType.Number;
			case ParameterType.NVarChar:
				return OracleType.NVarChar;
			case ParameterType.RowId:
				return OracleType.RowId;
			case ParameterType.SByte:
				return OracleType.SByte;
			case ParameterType.Timestamp:
				return OracleType.Timestamp;
			case ParameterType.TimestampLocal:
				return OracleType.TimestampLocal;
			case ParameterType.TimestampWithTZ:
				return OracleType.TimestampWithTZ;
			case ParameterType.UInt16:
				return OracleType.UInt16;
			case ParameterType.UInt32:
				return OracleType.UInt32;
			case ParameterType.VarChar:
				return OracleType.VarChar;
			case ParameterType.RefCursor:
				return OracleType.Cursor;
			}
			throw new ReportWriterException("Invalid parameterType for an Oracle stored procedure parameter.");
		}

		// Token: 0x06002358 RID: 9048 RVA: 0x00150238 File Offset: 0x0014F238
		private OleDbType b()
		{
			switch (this.g)
			{
			case ParameterType.BigInt:
				return OleDbType.BigInt;
			case ParameterType.Boolean:
				return OleDbType.Boolean;
			case ParameterType.Bstr:
				return OleDbType.BSTR;
			case ParameterType.Char:
				return OleDbType.Char;
			case ParameterType.Currency:
				return OleDbType.Currency;
			case ParameterType.Date:
				return OleDbType.Date;
			case ParameterType.DBDate:
				return OleDbType.DBDate;
			case ParameterType.DBTime:
				return OleDbType.DBTime;
			case ParameterType.DBTimestamp:
				return OleDbType.DBTimeStamp;
			case ParameterType.Decimal:
				return OleDbType.Decimal;
			case ParameterType.Double:
				return OleDbType.Double;
			case ParameterType.Filetime:
				return OleDbType.Filetime;
			case ParameterType.Guid:
				return OleDbType.Guid;
			case ParameterType.Integer:
				return OleDbType.Integer;
			case ParameterType.LongVarChar:
				return OleDbType.LongVarChar;
			case ParameterType.LongVarWChar:
				return OleDbType.LongVarWChar;
			case ParameterType.Numeric:
				return OleDbType.Numeric;
			case ParameterType.Single:
				return OleDbType.Single;
			case ParameterType.SmallInt:
				return OleDbType.SmallInt;
			case ParameterType.TinyInt:
				return OleDbType.TinyInt;
			case ParameterType.UnsignedBigInt:
				return OleDbType.UnsignedBigInt;
			case ParameterType.UnsignedInt:
				return OleDbType.UnsignedInt;
			case ParameterType.UnsignedSmallInt:
				return OleDbType.UnsignedSmallInt;
			case ParameterType.UnsignedTinyInt:
				return OleDbType.UnsignedTinyInt;
			case ParameterType.VarChar:
				return OleDbType.VarChar;
			case ParameterType.VarNumeric:
				return OleDbType.VarNumeric;
			case ParameterType.VarWChar:
				return OleDbType.VarWChar;
			case ParameterType.WChar:
				return OleDbType.WChar;
			}
			throw new ReportWriterException("Invalid parameterType for an OLE DB stored procedure parameter.");
		}

		// Token: 0x06002359 RID: 9049 RVA: 0x0015046C File Offset: 0x0014F46C
		private OdbcType a()
		{
			switch (this.g)
			{
			case ParameterType.BigInt:
				return OdbcType.BigInt;
			case ParameterType.Bit:
				return OdbcType.Bit;
			case ParameterType.Char:
				return OdbcType.Char;
			case ParameterType.Date:
				return OdbcType.Date;
			case ParameterType.DateTime:
				return OdbcType.DateTime;
			case ParameterType.Decimal:
				return OdbcType.Decimal;
			case ParameterType.Double:
				return OdbcType.Double;
			case ParameterType.Int:
				return OdbcType.Int;
			case ParameterType.NChar:
				return OdbcType.NChar;
			case ParameterType.NText:
				return OdbcType.NText;
			case ParameterType.Numeric:
				return OdbcType.Numeric;
			case ParameterType.NVarChar:
				return OdbcType.NVarChar;
			case ParameterType.Real:
				return OdbcType.Real;
			case ParameterType.SmallDateTime:
				return OdbcType.SmallDateTime;
			case ParameterType.SmallInt:
				return OdbcType.SmallInt;
			case ParameterType.Text:
				return OdbcType.Text;
			case ParameterType.Time:
				return OdbcType.Time;
			case ParameterType.TinyInt:
				return OdbcType.TinyInt;
			case ParameterType.UniqueIdentifier:
				return OdbcType.UniqueIdentifier;
			case ParameterType.VarChar:
				return OdbcType.VarChar;
			}
			throw new ReportWriterException("Invalid parameterType for an OLE DB stored procedure parameter.");
		}

		// Token: 0x04000F24 RID: 3876
		private ParameterDirection a = ParameterDirection.Input;

		// Token: 0x04000F25 RID: 3877
		private string b;

		// Token: 0x04000F26 RID: 3878
		private bool c = false;

		// Token: 0x04000F27 RID: 3879
		private byte d = 0;

		// Token: 0x04000F28 RID: 3880
		private byte e = 0;

		// Token: 0x04000F29 RID: 3881
		private int f = 0;

		// Token: 0x04000F2A RID: 3882
		private ParameterType g;

		// Token: 0x04000F2B RID: 3883
		private object h = null;

		// Token: 0x04000F2C RID: 3884
		private vd i = null;
	}
}
