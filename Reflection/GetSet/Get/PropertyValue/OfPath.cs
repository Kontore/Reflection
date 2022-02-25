using System;
using System.Reflection;
using System.Linq;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class PropertyValue {
			/// <summary>
			/// Gets the value of an instance or static property from the specified path.
			/// </summary>
			/// <param name="sourceType">The type of the class to get the property from.</param>
			/// <param name="source">The instance to get the property from. Use <see langword="null"/> to get a static property.</param>
			/// <param name="path">The path to the property. Sub-properties are separated by '.'. Example: <c>"Salary.Mothly"</c> for an <c>Employee</c>.</param>
			/// <param name="ignoreAccessibility">Whether to ignore the accesibiity modifier of the property.</param>
			/// <param name="bindingFlags">The binding flags to use when getting the property.</param>
			/// <exception cref="ArgumentNullException"><param name="sourceType"/> is null.</exception>
			/// <exception cref="ArgumentException"><paramref name="path"/> is null or whitespace.</exception>
			/// <exception cref="AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
			/// <returns>The target property.</returns>
			private static object OfPath(Type sourceType, object source, string path, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) {
				if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("The path must not be null or whitespace.", nameof(path));

				var fragments = path.Split('.');
				object current = sourceType;

				if (source == null) {
					for (int i = 0; i < fragments.Length - 1; i++) {
						object temp;

						try {
							temp = Of((Type)current, current, fragments[i], ignoreAccessibility, bindingFlags);
						} catch {
							temp = null;
						}

						if (bindingFlags.HasFlag(BindingFlags.Instance) && temp != null) {
							current = temp;
						} else {
							current = ((Type)current).GetNestedType(fragments[i], bindingFlags);
						}
					}

					if (current as Type == null) {
						current = Of(current.GetType(), current, fragments.Last(), ignoreAccessibility, bindingFlags);
					} else {
						current = Of((Type)current, null, fragments.Last(), ignoreAccessibility, bindingFlags);
					}
				} else {
					current = source;

					foreach (var fragment in fragments) {
						current = Of(current.GetType(), current, fragment, ignoreAccessibility, bindingFlags);
					}
				}

				return current;
			}

			/// <summary>
			/// Gets the value of an instance or static property from the specified path.
			/// </summary>
			/// <typeparam name="T">The type of the class to get the property from.</typeparam>
			/// <param name="source">The instance to get the property from. Use <see langword="null"/> to get a static property.</param>
			/// <param name="path">The path to the property. Sub-properties are separated by '.'. Example: <c>"Salary.Mothly"</c> for an <c>Employee</c>.</param>
			/// <param name="ignoreAccessibility">Whether to ignore the accesibiity modifier of the property.</param>
			/// <param name="bindingFlags">The binding flags to use when getting the property.</param>
			/// <exception cref="ArgumentNullException"><typeparamref name="T"/> is null.</exception>
			/// <exception cref="ArgumentException"><paramref name="path"/> is null or whitespace.</exception>
			/// <exception cref="AmbiguousMatchException">More than one property is found with the specified name and matching the specified binding constraints.</exception>
			/// <returns>The target property.</returns>
			private static object OfPath<T>(T source, string path, bool ignoreAccessibility = false, BindingFlags bindingFlags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public | BindingFlags.NonPublic) {
				return OfPath(typeof(T), source, path, ignoreAccessibility, bindingFlags);
			}
		}
	}
}
