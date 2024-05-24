using System;
using System.Data;
using ceTe.DynamicPDF.ReportWriter;
using ceTe.DynamicPDF.ReportWriter.Data;

namespace zz93
{
	// Token: 0x02000351 RID: 849
	internal class wa
	{
		// Token: 0x0600242C RID: 9260 RVA: 0x00154BF0 File Offset: 0x00153BF0
		internal wa(wd A_0)
		{
			string text = null;
			while (A_0.y())
			{
				int num = A_0.u();
				if (num <= 611693197)
				{
					if (num <= 13541029)
					{
						if (num != 12196709)
						{
							if (num != 13541029)
							{
								goto IL_14E;
							}
							this.f = A_0.@as();
						}
						else
						{
							this.b = A_0.a8();
						}
					}
					else if (num != 13868069)
					{
						if (num != 611693197)
						{
							goto IL_14E;
						}
						this.a = A_0.ak();
					}
					else
					{
						this.g = A_0.aj();
					}
				}
				else if (num <= 805618439)
				{
					if (num != 785702916)
					{
						if (num != 805618439)
						{
							goto IL_14E;
						}
						this.d = A_0.at();
					}
					else
					{
						this.c = A_0.av();
					}
				}
				else if (num != 864951077)
				{
					if (num != 914804069)
					{
						goto IL_14E;
					}
					if (A_0.ay())
					{
						this.i = A_0.a3();
					}
					else
					{
						text = A_0.a8();
					}
				}
				else
				{
					this.e = A_0.at();
				}
				continue;
				IL_14E:
				throw new DplxParseException("A query element contains an invalid attribute.");
			}
			if (text != null)
			{
				this.a(text);
			}
			if (!A_0.z())
			{
				A_0.aa();
				A_0.aa();
			}
		}

		// Token: 0x0600242D RID: 9261 RVA: 0x00154D90 File Offset: 0x00153D90
		internal wa a()
		{
			return this.j;
		}

		// Token: 0x0600242E RID: 9262 RVA: 0x00154DA8 File Offset: 0x00153DA8
		internal void a(wa A_0)
		{
			this.j = A_0;
		}

		// Token: 0x0600242F RID: 9263 RVA: 0x00154DB4 File Offset: 0x00153DB4
		internal ParameterDirection b()
		{
			return this.a;
		}

		// Token: 0x06002430 RID: 9264 RVA: 0x00154DCC File Offset: 0x00153DCC
		internal string c()
		{
			return this.b;
		}

		// Token: 0x06002431 RID: 9265 RVA: 0x00154DE4 File Offset: 0x00153DE4
		internal bool d()
		{
			return this.c;
		}

		// Token: 0x06002432 RID: 9266 RVA: 0x00154DFC File Offset: 0x00153DFC
		internal byte e()
		{
			return this.d;
		}

		// Token: 0x06002433 RID: 9267 RVA: 0x00154E14 File Offset: 0x00153E14
		internal byte f()
		{
			return this.e;
		}

		// Token: 0x06002434 RID: 9268 RVA: 0x00154E2C File Offset: 0x00153E2C
		internal int g()
		{
			return this.f;
		}

		// Token: 0x06002435 RID: 9269 RVA: 0x00154E44 File Offset: 0x00153E44
		internal ParameterType h()
		{
			return this.g;
		}

		// Token: 0x06002436 RID: 9270 RVA: 0x00154E5C File Offset: 0x00153E5C
		internal object i()
		{
			return this.h;
		}

		// Token: 0x06002437 RID: 9271 RVA: 0x00154E74 File Offset: 0x00153E74
		internal vd j()
		{
			return this.i;
		}

		// Token: 0x06002438 RID: 9272 RVA: 0x00154E8C File Offset: 0x00153E8C
		private void a(string A_0)
		{
			if (A_0.Length == 0)
			{
				ParameterType parameterType = this.g;
				if (parameterType <= ParameterType.RowId)
				{
					switch (parameterType)
					{
					case ParameterType.Bstr:
						this.h = A_0;
						goto IL_100;
					case ParameterType.Byte:
						break;
					case ParameterType.Char:
						this.h = A_0;
						goto IL_100;
					default:
						switch (parameterType)
						{
						case ParameterType.LongVarChar:
							this.h = A_0;
							goto IL_100;
						case ParameterType.LongVarWChar:
							this.h = A_0;
							goto IL_100;
						case ParameterType.NChar:
							this.h = A_0;
							goto IL_100;
						case ParameterType.NText:
							this.h = A_0;
							goto IL_100;
						case ParameterType.NVarChar:
							this.h = A_0;
							goto IL_100;
						case ParameterType.RowId:
							this.h = A_0;
							goto IL_100;
						}
						break;
					}
				}
				else
				{
					if (parameterType == ParameterType.Text)
					{
						this.h = A_0;
						goto IL_100;
					}
					switch (parameterType)
					{
					case ParameterType.VarChar:
						this.h = A_0;
						goto IL_100;
					case ParameterType.VarWChar:
						this.h = A_0;
						goto IL_100;
					case ParameterType.WChar:
						this.h = A_0;
						goto IL_100;
					}
				}
				this.h = null;
				IL_100:;
			}
			else
			{
				switch (this.g)
				{
				case ParameterType.BigInt:
					this.h = long.Parse(A_0);
					break;
				case ParameterType.Bit:
					this.h = bool.Parse(A_0);
					break;
				case ParameterType.Boolean:
					this.h = bool.Parse(A_0);
					break;
				case ParameterType.Bstr:
					this.h = A_0;
					break;
				case ParameterType.Byte:
					this.h = byte.Parse(A_0);
					break;
				case ParameterType.Char:
					this.h = A_0;
					break;
				case ParameterType.Currency:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.Date:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.DateTime:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.DBDate:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.DBTime:
					this.h = TimeSpan.Parse(A_0);
					break;
				case ParameterType.DBTimestamp:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.Decimal:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.Double:
					this.h = double.Parse(A_0);
					break;
				case ParameterType.Filetime:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.Float:
					this.h = double.Parse(A_0);
					break;
				case ParameterType.Guid:
					this.h = new Guid(A_0);
					break;
				case ParameterType.Int:
					this.h = int.Parse(A_0);
					break;
				case ParameterType.Int16:
					this.h = short.Parse(A_0);
					break;
				case ParameterType.Int32:
					this.h = int.Parse(A_0);
					break;
				case ParameterType.Integer:
					this.h = int.Parse(A_0);
					break;
				case ParameterType.IntervalDayToSecond:
					this.h = TimeSpan.Parse(A_0);
					break;
				case ParameterType.IntervalYearToMonth:
					this.h = int.Parse(A_0);
					break;
				case ParameterType.LongVarChar:
					this.h = A_0;
					break;
				case ParameterType.LongVarWChar:
					this.h = A_0;
					break;
				case ParameterType.Money:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.NChar:
					this.h = A_0;
					break;
				case ParameterType.NText:
					this.h = A_0;
					break;
				case ParameterType.Number:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.Numeric:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.NVarChar:
					this.h = A_0;
					break;
				case ParameterType.Real:
					this.h = float.Parse(A_0);
					break;
				case ParameterType.RowId:
					this.h = A_0;
					break;
				case ParameterType.SByte:
					this.h = sbyte.Parse(A_0);
					break;
				case ParameterType.Single:
					this.h = float.Parse(A_0);
					break;
				case ParameterType.SmallDateTime:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.SmallInt:
					this.h = short.Parse(A_0);
					break;
				case ParameterType.SmallMoney:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.Text:
					this.h = A_0;
					break;
				case ParameterType.Time:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.Timestamp:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.TimestampLocal:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.TimestampWithTZ:
					this.h = DateTime.Parse(A_0);
					break;
				case ParameterType.TinyInt:
					this.h = byte.Parse(A_0);
					break;
				case ParameterType.UInt16:
					this.h = ushort.Parse(A_0);
					break;
				case ParameterType.UInt32:
					this.h = uint.Parse(A_0);
					break;
				case ParameterType.UniqueIdentifier:
					this.h = new Guid(A_0);
					break;
				case ParameterType.UnsignedBigInt:
					this.h = ulong.Parse(A_0);
					break;
				case ParameterType.UnsignedInt:
					this.h = uint.Parse(A_0);
					break;
				case ParameterType.UnsignedSmallInt:
					this.h = ushort.Parse(A_0);
					break;
				case ParameterType.UnsignedTinyInt:
					this.h = byte.Parse(A_0);
					break;
				case ParameterType.VarChar:
					this.h = A_0;
					break;
				case ParameterType.VarNumeric:
					this.h = decimal.Parse(A_0);
					break;
				case ParameterType.VarWChar:
					this.h = A_0;
					break;
				case ParameterType.WChar:
					this.h = A_0;
					break;
				default:
					throw new DplxParseException("Cannot parse stored procedure parameter value.");
				}
			}
		}

		// Token: 0x04000FB4 RID: 4020
		private ParameterDirection a = ParameterDirection.Input;

		// Token: 0x04000FB5 RID: 4021
		private string b;

		// Token: 0x04000FB6 RID: 4022
		private bool c = false;

		// Token: 0x04000FB7 RID: 4023
		private byte d = 0;

		// Token: 0x04000FB8 RID: 4024
		private byte e = 0;

		// Token: 0x04000FB9 RID: 4025
		private int f = 0;

		// Token: 0x04000FBA RID: 4026
		private ParameterType g;

		// Token: 0x04000FBB RID: 4027
		private object h = null;

		// Token: 0x04000FBC RID: 4028
		private vd i = null;

		// Token: 0x04000FBD RID: 4029
		private wa j = null;
	}
}
