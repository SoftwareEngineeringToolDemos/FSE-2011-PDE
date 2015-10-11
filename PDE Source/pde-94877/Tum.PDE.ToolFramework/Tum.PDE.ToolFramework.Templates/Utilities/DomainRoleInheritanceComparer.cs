using Tum.PDE.LanguageDSL;

namespace Tum.PDE.ToolFramework.Templates
{
    /// <summary>
    /// Sorts domain role by inheritance of the referenced domain classes.
    /// </summary>
    public class DomainRoleInheritanceComparer<T> : System.Collections.IComparer, System.Collections.Generic.IComparer<T>
        where T : DomainRole
    {

        public DomainRoleInheritanceComparer()
        {
        }

        public int Compare(T x, T y)
        {
            if (System.Object.Equals(x, y))
                return 0;
            if ((x == null) || (y == null))
                return 0;
            int i1 = -GetInheritanceDepth(x.RolePlayer);
            int i2 = -GetInheritanceDepth(y.RolePlayer);
            return i1.CompareTo(i2);
        }

        public int Compare(object x, object y)
        {
            T t1 = (T)(x as T);
            T t2 = (T)(y as T);
            if (t1 == null)
                throw new System.ArgumentOutOfRangeException("x", "DomainClassComparer can only compare DomainClasses.");
            if (t2 == null)
                throw new System.ArgumentOutOfRangeException("y", "DomainClassComparer can only compare DomainClasses.");
            return Compare(t1, t2);
        }

        private static int GetInheritanceDepth(AttributedDomainElement domainClass)
        {
            int i = 0;
            for (AttributedDomainElement domainClass1 = domainClass; domainClass1 != null; domainClass1 = domainClass1.GetBaseClassSafely(domainClass))
            {
                i++;
            }
            return i;
        }

    }
}
