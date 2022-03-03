using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Kontore.Reflection.GetSet {
	public static partial class Set {
		public static partial class PropertyValue {
			public static void PathTo(Type sourceType, object source, string path, object value, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Default) {
				if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
				if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("The path must not be null or whitespace.", nameof(path));

				Get.PropertyInfoT.OfPath(sourceType, path, ignoreAccessibility, bindingFlags).SetValue(source, value);
			}

			public static void PathTo<T, TValue>(T source, string path, TValue value, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Default) {
				PathTo(typeof(T), source, path, value, ignoreAccessibility, bindingFlags);
			}
		}
	}
}
