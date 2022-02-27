using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Kontore.Reflection.GetSet;
using System.Collections;

namespace Kontore.Reflection {
	public abstract class ReflectionQuery<T> {
		public List<T> Result { get; }
		private List<Func<T, bool>> Queries { get; }

		public ReflectionQuery() {
			Queries = new List<Func<T, bool>>();
		}

		public ReflectionQuery(IEnumerable<Func<T, bool>> queries) {
			Queries = queries.ToList();
		}

		public ReflectionQuery(params Func<T, bool>[] queries) {
			Queries = Queries.ToList();
		}

		public ReflectionQuery<T> Run(IEnumerable<T> data) {
			Result.AddRange(data.Where(value => Queries.Any(query => query(value))));

			return this;
		}

		public Func<T, bool> Get(int index) => Queries[index];
		public ReflectionQuery<T> Set(int index, Func<T, bool> query) {
			Queries[index] = query;

			return this;
		}

		public ReflectionQuery<T> Add(Func<T, bool> query) {
			Queries.Add(query);

			return this;
		}

		public ReflectionQuery<T> Remove(int index) {
			Queries.RemoveAt(index);

			return this;
		}

		public ReflectionQuery<T> Remove(Func<T, bool> query) {
			Queries.Remove(query);

			return this;
		}
	}

	public class EnumQuery<TEnum> : ReflectionQuery<TEnum> where TEnum : Enum {
		public EnumQuery() : base() { }
		public EnumQuery(IEnumerable<Func<TEnum, bool>> queries) : base(queries) { }
		public EnumQuery(params Func<TEnum, bool>[] queries) : base(queries) { }

		public static Func<TEnum, bool> Any(Func<TEnum, bool> query) {
			return new Func<TEnum, bool>(e => {
				if (query == null) throw new ArgumentNullException(nameof(query));

				var values = Enum.GetValues(typeof(TEnum));

				foreach (TEnum value in values) {
					if (query(value)) {
						return true;
					}
				}

				return false;
			});
		}
	}
}
