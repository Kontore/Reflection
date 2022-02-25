using System;
using System.Reflection;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class PropertyInfoT {
			/// <summary>
			/// Gets the <see cref="PropertyInfo"/> of the specified property.
			/// </summary>
			/// <param name="sourceType">The type of the class that the property is located in.</param>
			/// <param name="name">The name of the property.</param>
			/// <param name="ignoreAccessibility">Whether to ignore the accesibiity modifier of the property.</param>
			/// <param name="bindingFlags">The binding flags to use when getting the property.</param>
			/// <exception cref="ArgumentNullException"><paramref name="sourceType"/> is null.</exception>
			/// <exception cref="ArgumentException"><paramref name="name"/> is null or whitespace.</exception>
			/// <exception cref="AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
			/// <returns>The <see cref="PropertyInfo"/> of the target property.</returns>
			public static PropertyInfo Of(Type sourceType, string name, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public) {
				if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
				if (string.IsNullOrWhiteSpace(name)) throw new ArgumentException("The name must not be null or whitespace.", nameof(name));
				
				if (ignoreAccessibility) {
					bindingFlags |= BindingFlags.Public | BindingFlags.NonPublic;
				}

				return sourceType.GetProperty(name, bindingFlags);
			}

			/// <summary>
			/// Gets the <see cref="PropertyInfo"/> of the specified property.
			/// </summary>
			/// <typeparam name="T"></typeparam>
			/// <param name="name"></param>
			/// <param name="ignoreAccessibility"></param>
			/// <param name="bindingFlags"></param>
			/// <returns></returns>
			public static PropertyInfo Of<T>(string name, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public) {
				return Of(typeof(T), name, ignoreAccessibility, bindingFlags);
			}
		}
	}
}