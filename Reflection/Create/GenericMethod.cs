using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;
using Kontore.Reflection.Invoke;

namespace Kontore.Reflection.Create {
	public static partial class Create {
		/// <summary>
		/// Creates a generic method with the specified parameters.
		/// You can then use this in <see cref="Invoke"/>
		/// </summary>
		/// <param name="sourceType"></param>
		/// <param name="methodName"></param>
		/// <param name="typeParameters"></param>
		/// <returns></returns>
		public static MethodInfo GenericMethod(Type sourceType, string methodName, params Type[] typeParameters) {
			if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
			if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentException("The name must not be null or whitespace.", nameof(methodName));
			
			var method = sourceType.GetMethod(methodName);

			return GenericMethod(method, typeParameters);
		}

		public static MethodInfo GenericMethod<T>(T source, string methodName, params Type[] typeParameters) {
			return GenericMethod(typeof(T), methodName, typeParameters);
		}

		public static MethodInfo GenericMethod(MethodInfo method, params Type[] typeParameters) {
			if (method == null) throw new ArgumentNullException($"The specified method '{method.Name}' does not exist in the type '{method.DeclaringType}'.", nameof(method));

			int nullTypeIndex = Array.IndexOf(typeParameters, null);

			if (nullTypeIndex != -1) throw new ArgumentNullException($"The type number '{nullTypeIndex}' is null.", nameof(typeParameters));

			return method.MakeGenericMethod(typeParameters);
		}
	}
}
