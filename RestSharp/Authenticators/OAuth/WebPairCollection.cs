using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace RestSharp.Authenticators.OAuth
{
	// Token: 0x02000064 RID: 100
	[NullableContext(1)]
	[Nullable(0)]
	internal class WebPairCollection : IList<WebPair>, ICollection<WebPair>, IEnumerable<WebPair>, IEnumerable
	{
		// Token: 0x06000582 RID: 1410 RVA: 0x0000DA70 File Offset: 0x0000BC70
		public IEnumerator<WebPair> GetEnumerator()
		{
			return this._parameters.GetEnumerator();
		}

		// Token: 0x06000583 RID: 1411 RVA: 0x0000DA82 File Offset: 0x0000BC82
		IEnumerator IEnumerable.GetEnumerator()
		{
			return this.GetEnumerator();
		}

		// Token: 0x06000584 RID: 1412 RVA: 0x0000DA8A File Offset: 0x0000BC8A
		public void Add(WebPair parameter)
		{
			this._parameters.Add(parameter);
		}

		// Token: 0x06000585 RID: 1413 RVA: 0x0000DA98 File Offset: 0x0000BC98
		public void AddRange(IEnumerable<WebPair> collection)
		{
			this.AddCollection(collection);
		}

		// Token: 0x06000586 RID: 1414 RVA: 0x0000DAA1 File Offset: 0x0000BCA1
		public void Add(string name, string value)
		{
			this.Add(new WebPair(name, value, false));
		}

		// Token: 0x06000587 RID: 1415 RVA: 0x0000DAB1 File Offset: 0x0000BCB1
		public void Clear()
		{
			this._parameters.Clear();
		}

		// Token: 0x06000588 RID: 1416 RVA: 0x0000DABE File Offset: 0x0000BCBE
		public bool Contains(WebPair parameter)
		{
			return this._parameters.Contains(parameter);
		}

		// Token: 0x06000589 RID: 1417 RVA: 0x0000DACC File Offset: 0x0000BCCC
		public void CopyTo(WebPair[] parametersArray, int arrayIndex)
		{
			this._parameters.CopyTo(parametersArray, arrayIndex);
		}

		// Token: 0x0600058A RID: 1418 RVA: 0x0000DADB File Offset: 0x0000BCDB
		public bool Remove(WebPair parameter)
		{
			return this._parameters.Remove(parameter);
		}

		// Token: 0x17000189 RID: 393
		// (get) Token: 0x0600058B RID: 1419 RVA: 0x0000DAE9 File Offset: 0x0000BCE9
		public int Count
		{
			get
			{
				return this._parameters.Count;
			}
		}

		// Token: 0x1700018A RID: 394
		// (get) Token: 0x0600058C RID: 1420 RVA: 0x0000DAF6 File Offset: 0x0000BCF6
		public bool IsReadOnly
		{
			get
			{
				return false;
			}
		}

		// Token: 0x0600058D RID: 1421 RVA: 0x0000DAF9 File Offset: 0x0000BCF9
		public int IndexOf(WebPair parameter)
		{
			return this._parameters.IndexOf(parameter);
		}

		// Token: 0x0600058E RID: 1422 RVA: 0x0000DB07 File Offset: 0x0000BD07
		public void Insert(int index, WebPair parameter)
		{
			this._parameters.Insert(index, parameter);
		}

		// Token: 0x0600058F RID: 1423 RVA: 0x0000DB16 File Offset: 0x0000BD16
		public void RemoveAt(int index)
		{
			this._parameters.RemoveAt(index);
		}

		// Token: 0x1700018B RID: 395
		public WebPair this[int index]
		{
			get
			{
				return this._parameters[index];
			}
			set
			{
				this._parameters[index] = value;
			}
		}

		// Token: 0x06000592 RID: 1426 RVA: 0x0000DB41 File Offset: 0x0000BD41
		private void AddCollection(IEnumerable<WebPair> collection)
		{
			this._parameters.AddRange(from parameter in collection
			select new WebPair(parameter.Name, parameter.Value, false));
		}

		// Token: 0x0400017E RID: 382
		private readonly List<WebPair> _parameters = new List<WebPair>();
	}
}
