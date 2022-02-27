using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Linq;

namespace Kontore.Reflection.GetSet {
	public static partial class Get {
		public static partial class EnumT {
			/// <summary>
			/// Checks if all the values of an enum are powers of 2.
			/// </summary>
			/// <param name="enumType">The type of the enum.</param>
			/// <returns>Whether all the values in the specified enum are powers of 2.</returns>
			public static bool AreValuesPowerOf2(Type enumType) {
				if (enumType == null) throw new ArgumentNullException(nameof(enumType));
				if (!enumType.IsEnum) throw new ArgumentException("Type must be an enum.", nameof(enumType));
				
				/*
				  0100 = 4
				& 0011 = 3
				----------
				  0000 = 0

				  0110 = 5
				& 0100 = 4
				----------
				  0100 = 4
				*/
				return All(enumType, e => (e & (e - 1)) == 0);
			}

			/// <summary>
			/// Checks if all the values of an enum are powers of 2.
			/// </summary>
			/// <typeparam name="TEnum">The type of the enum.</typeparam>
			/// <returns>Whether all the values in the specified enum are powers of 2.</returns>
			public static bool AreValuesPowerOf2<TEnum>() where TEnum : Enum {
				return AreValuesPowerOf2(typeof(TEnum));
			}
		}
	}
}
