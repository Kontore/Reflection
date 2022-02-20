using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Kontore.Reflection.Invoke {
	public static partial class Invoke {
		/// <summary>
		/// Invokes a method with the specified parameters.
		/// </summary>
		/// <param name="sourceType">The type in which the method is declared.</param>
		/// <param name="source">The instance where the method is located. Use <see langword="null"/> to invoke a static method.</param>
		/// <param name="methodName">The name of the method.</param>
		/// <param name="parameters">The parameters to be passed onto the method.</param>
		public static void Method(Type sourceType, object source, string methodName, params object[] parameters) {
			if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
			if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentException("The name must not be null or whitespace.", nameof(methodName));
			
			var method = sourceType.GetMethod(methodName);

			Method(source, method, parameters);
		}

		/// <summary>
		/// Invokes a method with the specified parameters.
		/// </summary>
		/// <typeparam name="T">The type in which the method is declared.</param>
		/// <param name="source">The instance where the method is located. Use <see langword="null"/> to invoke a static method.</param>
		/// <param name="methodName">The name of the method.</param>
		/// <param name="parameters">The parameters to be passed onto the method.</param>
		public static void Method<T>(T source, string methodName, params object[] parameters) {
			Method(typeof(T), source, methodName, parameters);
		}

		/// <summary>
		/// Invokes a method with the specified parameters.
		/// </summary>
		/// <typeparam name="T">The type in which the method is declared.</param>
		/// <param name="source">The instance where the method is located. Use <see langword="null"/> to invoke a static method.</param>
		/// <param name="method">The method to invoke from the <paramref name="source"/>.</param>
		/// <param name="parameters">The parameters to be passed onto the method.</param>
		public static void Method(object source, MethodInfo method, params object[] parameters) {
			if (method == null) throw new ArgumentNullException($"The specified method '{method.Name}' does not exist in the type '{method.DeclaringType}'.", nameof(method));

			method.Invoke(source, parameters);
		}
	}
}
