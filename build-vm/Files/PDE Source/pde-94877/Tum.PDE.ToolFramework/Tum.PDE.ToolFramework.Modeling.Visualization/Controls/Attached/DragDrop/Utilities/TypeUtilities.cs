﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using System.Reflection;

namespace Tum.PDE.ToolFramework.Modeling.Visualization.Controls.Attached.DragDrop.Utilities
{
    /// <summary>
    /// Type utilities.
    /// </summary>
    public class TypeUtilities
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <returns></returns>
        public static IEnumerable CreateDynamicallyTypedList(IEnumerable source)
        {
            Type type = GetCommonBaseClass(source);
            Type listType = typeof(List<>).MakeGenericType(type);
            MethodInfo addMethod = listType.GetMethod("Add");
            object list = listType.GetConstructor(Type.EmptyTypes).Invoke(null);

            foreach (object o in source)
            {
                addMethod.Invoke(list, new[] { o });
            }

            return (IEnumerable)list;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        public static Type GetCommonBaseClass(IEnumerable e)
        {
            Type[] types = e.Cast<object>().Select(o => o.GetType()).ToArray<Type>();
            return GetCommonBaseClass(types);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="types"></param>
        /// <returns></returns>
        public static Type GetCommonBaseClass(Type[] types)
        {
            if (types.Length == 0)
                return typeof(object);

            Type ret = types[0];

            for (int i = 1; i < types.Length; ++i)
            {
                if (types[i].IsAssignableFrom(ret))
                    ret = types[i];
                else
                {
                    // This will always terminate when ret == typeof(object)
                    while (!ret.IsAssignableFrom(types[i]))
                        ret = ret.BaseType;
                }
            }

            return ret;
        }
    }
}
