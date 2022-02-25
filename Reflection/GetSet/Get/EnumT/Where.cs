using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Reflection.Emit;
using System.Linq;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class EnumT {
			/// <summary>
			/// Filters an enum based on a predicate.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>A list of all enum items which fit the <c><paramref name="predicate"/></c>.</returns>
			public static List<Enum> Where(Type enumType, Func<Enum, bool> predicate) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));

				var values = Enum.GetValues(enumType);
				var toReturn = new List<Enum>(values.Length);

				foreach (Enum value in values) {
					if (predicate(value)) {
						toReturn.Add(value);
					}
				}

				return toReturn;
			}

			/// <summary>
			/// Filters an enum based on a predicate.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>A list of all enum items which fit the <c><paramref name="predicate"/></c>.</returns>
			public static List<int> Where(Type enumType, Func<int, bool> predicate) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));

				var values = Enum.GetValues(enumType);
				var toReturn = new List<int>(values.Length);

				foreach (int value in values) {
					if (predicate(value)) {
						toReturn.Add(value);
					}
				}

				return toReturn;
			}

			/// <summary>
			/// Filters an enum based on a predicate.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>A list of all enum items which fit the <c><paramref name="predicate"/></c>.</returns>
			public static List<TEnum> Where<TEnum>(Func<TEnum, bool> predicate) where TEnum : Enum {
				if (predicate == null) throw new ArgumentNullException(nameof(predicate));

				var values = Enum.GetValues(typeof(TEnum));
				var toReturn = new List<TEnum>(values.Length);

				foreach (TEnum value in values) {
					if (predicate(value)) {
						toReturn.Add(value);
					}
				}

				return toReturn;
			}

			/// <summary>
			/// Filters an enum based on a predicate.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <param name="predicate">A function to test each enum item for a condition.</param>
			/// <returns>A list of all enum items which fit the <c><paramref name="predicate"/></c>.</returns>
			public static List<int> Where<TEnum>(Func<int, bool> predicate) where TEnum : Enum {
				return Where(typeof(TEnum), predicate);
			}
		}
	}
}
