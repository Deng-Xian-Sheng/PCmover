using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using ceTe.DynamicPDF.ReportWriter.IO;

namespace ceTe.DynamicPDF.ReportWriter.Data
{
	// Token: 0x020007FA RID: 2042
	public class EnumerableRecordSet : RecordSet
	{
		// Token: 0x060052F8 RID: 21240 RVA: 0x002904A0 File Offset: 0x0028F4A0
		public EnumerableRecordSet(IEnumerable enumerable)
		{
			this.a = enumerable.GetEnumerator();
			this.d = this.a.MoveNext();
			if (this.d)
			{
				if (this.a.Current == null)
				{
					this.c = null;
				}
				else
				{
					this.c = new EnumerableRecordSet.a(this.a.Current.GetType());
					this.b.Add(this.c.a(), this.c);
				}
			}
			else
			{
				this.c = null;
			}
		}

		// Token: 0x17000773 RID: 1907
		public override object this[string fieldName]
		{
			get
			{
				object result;
				if (this.c == null)
				{
					result = null;
				}
				else
				{
					result = this.c.a(fieldName, this.a.Current);
				}
				return result;
			}
		}

		// Token: 0x17000774 RID: 1908
		public override object this[int fieldIndex]
		{
			get
			{
				object result;
				if (this.c == null)
				{
					result = null;
				}
				else
				{
					result = this.c.a(fieldIndex, this.a.Current);
				}
				return result;
			}
		}

		// Token: 0x17000775 RID: 1909
		// (get) Token: 0x060052FB RID: 21243 RVA: 0x002905E0 File Offset: 0x0028F5E0
		public override bool HasData
		{
			get
			{
				return this.d;
			}
		}

		// Token: 0x060052FC RID: 21244 RVA: 0x002905F8 File Offset: 0x0028F5F8
		internal override bool d8(LayoutWriter A_0)
		{
			bool result;
			if (this.f > this.e)
			{
				this.f--;
				result = this.d;
			}
			else
			{
				if (base.Query.d())
				{
					base.Query.e().a(A_0);
				}
				Type right;
				if (this.c == null)
				{
					right = null;
				}
				else
				{
					right = this.c.a();
				}
				this.d = this.a.MoveNext();
				if (this.d)
				{
					if (this.a.Current == null)
					{
						this.c = null;
					}
					else
					{
						Type type = this.a.Current.GetType();
						if (type != right)
						{
							if (!this.b.TryGetValue(type, out this.c))
							{
								this.c = new EnumerableRecordSet.a(type);
								this.b.Add(this.c.a(), this.c);
							}
						}
					}
					result = true;
				}
				else
				{
					this.c = null;
					result = false;
				}
			}
			return result;
		}

		// Token: 0x060052FD RID: 21245 RVA: 0x00290736 File Offset: 0x0028F736
		internal override void d9()
		{
			this.e++;
			this.f++;
		}

		// Token: 0x060052FE RID: 21246 RVA: 0x00290755 File Offset: 0x0028F755
		internal override void ea()
		{
			this.e--;
		}

		// Token: 0x060052FF RID: 21247 RVA: 0x00290766 File Offset: 0x0028F766
		internal override void eb()
		{
			this.a = null;
		}

		// Token: 0x04002C4C RID: 11340
		private new IEnumerator a;

		// Token: 0x04002C4D RID: 11341
		private Dictionary<Type, EnumerableRecordSet.a> b = new Dictionary<Type, EnumerableRecordSet.a>();

		// Token: 0x04002C4E RID: 11342
		private EnumerableRecordSet.a c;

		// Token: 0x04002C4F RID: 11343
		private bool d;

		// Token: 0x04002C50 RID: 11344
		private int e = 0;

		// Token: 0x04002C51 RID: 11345
		private int f = 0;

		// Token: 0x020007FB RID: 2043
		private new class a
		{
			// Token: 0x06005300 RID: 21248 RVA: 0x00290770 File Offset: 0x0028F770
			internal a(Type A_0)
			{
				this.c = A_0;
				this.d = A_0.GetProperties();
			}

			// Token: 0x06005301 RID: 21249 RVA: 0x002907A0 File Offset: 0x0028F7A0
			internal object a(string A_0, object A_1)
			{
				PropertyInfo property;
				if (!this.a.TryGetValue(A_0, out property))
				{
					property = this.c.GetProperty(A_0);
					if (property == null)
					{
						if (this.b == null)
						{
							if (this.d == null)
							{
								this.d = this.c.GetProperties();
							}
							this.b = new Dictionary<string, PropertyInfo>(StringComparer.CurrentCultureIgnoreCase);
							for (int i = 0; i < this.d.Length; i++)
							{
								if (!this.b.ContainsKey(this.d[i].Name))
								{
									this.b.Add(this.d[i].Name, this.d[i]);
								}
							}
						}
						this.b.TryGetValue(A_0, out property);
					}
					else
					{
						this.a.Add(A_0, property);
					}
				}
				object result;
				if (property == null)
				{
					result = null;
				}
				else
				{
					result = property.GetValue(A_1, null);
				}
				return result;
			}

			// Token: 0x06005302 RID: 21250 RVA: 0x002908C4 File Offset: 0x0028F8C4
			internal object a(int A_0, object A_1)
			{
				if (this.d == null)
				{
					this.d = this.c.GetProperties();
				}
				object result;
				if (A_0 >= this.d.Length || A_0 < 0)
				{
					result = null;
				}
				else
				{
					result = this.d[A_0].GetValue(A_1, null);
				}
				return result;
			}

			// Token: 0x06005303 RID: 21251 RVA: 0x00290924 File Offset: 0x0028F924
			internal Type a()
			{
				return this.c;
			}

			// Token: 0x04002C52 RID: 11346
			private Dictionary<string, PropertyInfo> a = new Dictionary<string, PropertyInfo>();

			// Token: 0x04002C53 RID: 11347
			private Dictionary<string, PropertyInfo> b = null;

			// Token: 0x04002C54 RID: 11348
			private Type c;

			// Token: 0x04002C55 RID: 11349
			private PropertyInfo[] d;
		}
	}
}
