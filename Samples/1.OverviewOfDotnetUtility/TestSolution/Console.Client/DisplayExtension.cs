using System;
using System.Collections;
using System.Linq.Expressions;
using System.Reflection;
/// <summary>
/// Display Extension Class
/// </summary>
public static class DisplayExtension
{

    /// <summary>
    /// Displays the value of an object, including its properties if it is a reference type.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to display.</param>
    /// <param name="name">name of the object</param>
    public static void Display<T>(this T obj,string name="")
    {
        // Handle null values
        if (obj == null)
        {
            Console.WriteLine("null");
            return;
        }

        var type = obj.GetType();

        // Handle primitive types and strings
        if (type.IsPrimitive || type == typeof(string))
        {
            if (!string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine($"{name}: {obj}");
            }
            else 
            {
                Console.WriteLine($"value: {obj}");
            }
            return;
        }

        // Handle nullable types
        if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>))
        {
            var underlyingType = Nullable.GetUnderlyingType(type);
            if (underlyingType == null)
            {
                Console.WriteLine("null");
                return;
            }

            if (underlyingType.IsPrimitive || underlyingType == typeof(string))
            {
                Console.WriteLine($"value: {obj}");
                return;
            }
        }

        // Handle collections and arrays
        if (typeof(IEnumerable).IsAssignableFrom(type))
        {
            foreach (var item in (IEnumerable)obj)
            {
                Display(item);
            }

            return;
        }

        // Handle reference types
        Console.WriteLine($"{type.Name}:");
        var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);

        foreach (var property in properties)
        {
            try
            {
                var value = property.GetValue(obj, null);
                Console.WriteLine($"{property.Name}: {value}");
            }
            catch {
                  Console.WriteLine($"{property.Name}: <error>");
             }
        }
    }
    
    /// <summary>
    /// Displays the value of an object, including its properties if it is a reference type.
    /// </summary>
    /// <typeparam name="T">The type of the object.</typeparam>
    /// <param name="obj">The object to display.</param>
    /// <param name="expr"></param> expression <summary>
    
    public static void Display<T>(this T obj,Expression<Func<T>> expr) => 
      Display(obj,  ((MemberExpression)expr.Body).Member.Name);

}