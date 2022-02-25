using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Reflection;

namespace Kontore.Reflection.Invoke {
	public static partial class Invoke {
		public static void GenericMethod(Type sourceType, object source, string methodName, Type[] typeParameters, params object[] parameters) {
			if (sourceType == null) throw new ArgumentNullException(nameof(sourceType));
			if (string.IsNullOrWhiteSpace(methodName)) throw new ArgumentException("The name must not be null or whitespace.", nameof(methodName));
			
			var method = sourceType.GetMethod(methodName);

			GenericMethod(source, method, typeParameters, parameters);
		}

		public static void GenericMethod<T>(T source, string methodName, Type[] typeParameters, params object[] parameters) {
			GenericMethod(typeof(T), source, methodName, typeParameters, parameters);
		}

		public static void GenericMethod(object source, MethodInfo method, Type[] typeParameters, params object[] parameters) {
			if (method == null) throw new ArgumentNullException($"The specified method '{method.Name}' does not exist in the type '{method.DeclaringType}'.", nameof(method));

			int nullTypeIndex = Array.IndexOf(typeParameters, null);

			if (nullTypeIndex != -1) throw new ArgumentNullException($"The type number '{nullTypeIndex}' is null.", nameof(typeParameters));

			method.MakeGenericMethod(typeParameters).Invoke(source, parameters);
		}
	}
}
