using System;
using System.Reflection;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class PropertyValue {
			/// <summary>
			/// Gets the value of an instance or static property.
			/// </summary>
			/// <param name="sourceType">The type of the class to get the property from.</param>
			/// <param name="source">The instance to get the property from. Use <see langword="null"/> to get a static property.</param>
			/// <param name="name">The name of the property.</param>
			/// <param name="ignoreAccessibility">Whether to ignore the accesibiity modifier of the property.</param>
			/// <param name="bindingFlags">The binding flags to use when getting the property.</param>
			/// <exception cref="ArgumentNullException"><paramref name="sourceType"/> is null.</exception>
			/// <exception cref="ArgumentException"><paramref name="name"/> is null or whitespace.</exception>
			/// <exception cref="AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
			/// <returns>The target property.</returns>
			public static object Of(Type sourceType, object source, string name, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) {
				bindingFlags |= BindingFlags.Instance | BindingFlags.Static;

				return PropertyInfoT.Of(sourceType, name, ignoreAccessibility, bindingFlags).GetValue(source);
			}

			/// <summary>
			/// Gets the value of an instance or static property.
			/// </summary>
			/// <typeparam name="T">The type of the class to get the property from.</typeparam>
			/// <param name="source">The instance to get the property from. Use <see langword="null"/> to get a static property.</param>
			/// <param name="name">The name of the property.</param>
			/// <param name="ignoreAccessibility">Whether to ignore the accesibiity modifier of the property.</param>
			/// <param name="bindingFlags">The binding flags to use when getting the property.</param>
			/// <exception cref="ArgumentNullException"><typeparamref name="T"/> is null.</exception>
			/// <exception cref="ArgumentException"><paramref name="name"/> is null or whitespace.</exception>
			/// <exception cref="AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
			/// <returns>The target property.</returns>
			public static object Of<T>(object source, string name, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) {
				return Of(typeof(T), source, name, ignoreAccessibility, bindingFlags);
			}
		}
	}
}