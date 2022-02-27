using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace Kontore.Reflection.GetSet {
	public static partial class Set {
		public static partial class PropertyValue {
			/// <summary>
			/// 
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <typeparam name="TValue"></typeparam>
			/// <param name="source"></param>
			/// <param name="name"></param>
			/// <param name="value"></param>
			/// <param name="ignoreAccessibility"></param>
			/// <param name="bindingFlags"></param>
			public static void To<T, TValue>(T source, string name, TValue value, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Default) {
				if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must not be null or whitespace.", nameof(name));

				Get.PropertyInfoT.Of<T>(name, ignoreAccessibility, bindingFlags).SetValue(source, value);
			}
		}
	}
}
