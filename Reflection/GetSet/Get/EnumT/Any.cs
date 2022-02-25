using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class EnumT {
			/// <summary>
			/// Determines whether any item of the specified enum satisfies a condition.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>True if any enum item satisfies the <paramref name="predicate"/>; false otherwise.</returns>
			public static bool Any(Type enumType, Func<Enum, bool> predicate) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));

				var values = Enum.GetValues(enumType);

				foreach (Enum value in values) {
					if (predicate(value)) {
						return true;
					}
				}

				return false;
			}

			/// <summary>
			/// Determines whether any item of the specified enum satisfies a condition.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>True if any enum item satisfies the <paramref name="predicate"/>; false otherwise.</returns>
			public static bool Any(Type enumType, Func<int, bool> predicate) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));

				var values = Enum.GetValues(enumType);

				foreach (int value in values) {
					if (predicate(value)) {
						return true;
					}
				}

				return false;
			}

			/// <summary>
			/// Determines whether any item of the specified enum satisfies a condition.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>True if any enum item satisfies the <paramref name="predicate"/>; false otherwise.</returns>
			public static bool Any<TEnum>(Func<Enum, bool> predicate) where TEnum : Enum {
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));

				var values = Enum.GetValues(typeof(TEnum));

				foreach (TEnum value in values) {
					if (predicate(value)) {
						return true;
					}
				}

				return false;
			}

			/// <summary>
			/// Determines whether any item of the specified enum satisfies a condition.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>True if any enum item satisfies the <paramref name="predicate"/>; false otherwise.</returns>
			public static bool Any<TEnum>(Func<int, bool> predicate) where TEnum : Enum {
				return Any(typeof(TEnum), predicate);
			}
		}
	}
}
