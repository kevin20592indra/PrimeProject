using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace PrimeProject.Business.Application.Utils
{
    public class ReflectionUtils
    {
        public static void CopyObject(object src, object dest)
        {
            CopyObject(src, dest, false, null);
        }

        public static void CopyObject(object src, object dest, bool copyContextObject)
        {
            CopyObject(src, dest, copyContextObject, null);
        }

        public static void CopyObject(object src, object dest, bool copyContextObject, string[] excludeProps)
        {
            if (!IsSrcDestObjectValid(src, dest))
            {
                return;
            }
            foreach (var sourceProperty in src.GetType().GetProperties())
            {
                if (sourceProperty.PropertyType.Assembly == typeof(ReflectionUtils).Assembly)
                {
                    continue;
                }
                if (sourceProperty.PropertyType.IsGenericType)
                {
                    if (sourceProperty.PropertyType.GetGenericTypeDefinition() == typeof(Collection<>))
                    {
                        continue;
                    }
                }
                if (excludeProps != null)
                {
                    if (excludeProps.Contains(sourceProperty.Name))
                    {
                        continue;
                    }
                }
                foreach (var destProperty in dest.GetType().GetProperties())
                {
                    if (destProperty.Name == sourceProperty.Name &&
                        destProperty.PropertyType.IsAssignableFrom(sourceProperty.PropertyType))
                    {
                        destProperty.SetValue(dest, sourceProperty.GetValue(
                            src, new object[] { }), new object[] { });
                        break;
                    }
                }
            }
        }

        private static bool IsSrcDestObjectValid(object src, object dest)
        {
            try
            {
                var srcType = GetEntityType(src);
                var destType = GetEntityType(dest);

                if (srcType != destType)
                {
                    return false;
                }

                return true;
            }
            catch
            {
                return false;
            }
        }

        private static Type GetEntityType(object obj)
        {
            var objType = obj.GetType();

            if (objType.BaseType != null && objType.Namespace == "System.Data.Entity.DynamicProxies")
            {
                objType = objType.BaseType;
            }

            return objType;
        }
    }
}
