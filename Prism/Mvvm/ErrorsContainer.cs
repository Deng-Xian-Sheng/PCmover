using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Prism.Mvvm
{
	// Token: 0x02000005 RID: 5
	public class ErrorsContainer<T>
	{
		// Token: 0x0600001D RID: 29 RVA: 0x0000229F File Offset: 0x0000049F
		public ErrorsContainer(Action<string> raiseErrorsChanged)
		{
			if (raiseErrorsChanged == null)
			{
				throw new ArgumentNullException("raiseErrorsChanged");
			}
			this.raiseErrorsChanged = raiseErrorsChanged;
			this.validationResults = new Dictionary<string, List<T>>();
		}

		// Token: 0x1700000F RID: 15
		// (get) Token: 0x0600001E RID: 30 RVA: 0x000022C7 File Offset: 0x000004C7
		public bool HasErrors
		{
			get
			{
				return this.validationResults.Count != 0;
			}
		}

		// Token: 0x0600001F RID: 31 RVA: 0x000022D8 File Offset: 0x000004D8
		public IEnumerable<T> GetErrors(string propertyName)
		{
			string key = propertyName ?? string.Empty;
			List<T> result = null;
			if (this.validationResults.TryGetValue(key, out result))
			{
				return result;
			}
			return ErrorsContainer<T>.noErrors;
		}

		// Token: 0x06000020 RID: 32 RVA: 0x0000230C File Offset: 0x0000050C
		public void ClearErrors<TProperty>(Expression<Func<TProperty>> propertyExpression)
		{
			string propertyName = PropertySupport.ExtractPropertyName<TProperty>(propertyExpression);
			this.ClearErrors(propertyName);
		}

		// Token: 0x06000021 RID: 33 RVA: 0x00002327 File Offset: 0x00000527
		public void ClearErrors(string propertyName)
		{
			this.SetErrors(propertyName, new List<T>());
		}

		// Token: 0x06000022 RID: 34 RVA: 0x00002338 File Offset: 0x00000538
		public void SetErrors<TProperty>(Expression<Func<TProperty>> propertyExpression, IEnumerable<T> propertyErrors)
		{
			string propertyName = PropertySupport.ExtractPropertyName<TProperty>(propertyExpression);
			this.SetErrors(propertyName, propertyErrors);
		}

		// Token: 0x06000023 RID: 35 RVA: 0x00002354 File Offset: 0x00000554
		public void SetErrors(string propertyName, IEnumerable<T> newValidationResults)
		{
			string text = propertyName ?? string.Empty;
			bool flag = this.validationResults.ContainsKey(text);
			bool flag2 = newValidationResults != null && newValidationResults.Count<T>() > 0;
			if (flag || flag2)
			{
				if (flag2)
				{
					this.validationResults[text] = new List<T>(newValidationResults);
					this.raiseErrorsChanged(text);
					return;
				}
				this.validationResults.Remove(text);
				this.raiseErrorsChanged(text);
			}
		}

		// Token: 0x04000004 RID: 4
		private static readonly T[] noErrors = new T[0];

		// Token: 0x04000005 RID: 5
		protected readonly Action<string> raiseErrorsChanged;

		// Token: 0x04000006 RID: 6
		protected readonly Dictionary<string, List<T>> validationResults;
	}
}
