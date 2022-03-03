using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class EnumT {
			/// <summary>
			/// Sums up all enums in the specified enum.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <returns>The sum of all enum items of the <c><paramref name="enumType"/></c>.</returns>
			public static int Sum(Type enumType) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));

				var values = Enum.GetValues(enumType);
				int total = 0;

				foreach (int value in values) {
					total += value;
				}
				
				return total;
			}

			/// <summary>
			/// Sums up all enums in the specified enum.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <returns>The sum of all enum items of the <typeparamref name="TEnum"/>.</returns>
			public static int Sum<TEnum>() where TEnum : Enum {
				return Sum(typeof(TEnum));
			}
		}
	}
}
