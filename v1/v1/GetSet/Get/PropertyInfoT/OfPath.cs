using System;
using System.Reflection;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class PropertyInfoT {
			public static PropertyInfo OfPath(Type sourceType, string path, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Default) {
				if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
				if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("The path must not be null or whitespace.", nameof(path));
				
				var fragments = path.Split('.');
				PropertyInfo current = Of(sourceType, fragments[0], ignoreAccessibility, bindingFlags);

				for (int i = 1; i < fragments.Length; i++) {
					current = Of(current.PropertyType, fragments[i], ignoreAccessibility, bindingFlags);
				}

				return current;
			}

			public static PropertyInfo OfPath<T>(string path, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Default) {
				return OfPath(typeof(T), path, ignoreAccessibility, bindingFlags);
			}
		}
	}
}
