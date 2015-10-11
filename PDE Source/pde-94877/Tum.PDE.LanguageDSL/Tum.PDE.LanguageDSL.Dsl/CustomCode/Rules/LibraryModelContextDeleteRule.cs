using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.VisualStudio.Modeling;
using Microsoft.VisualStudio.Modeling.Immutability;

namespace Tum.PDE.LanguageDSL
{
    [RuleOn(typeof(LibraryModelContext), FireTime = TimeToFire.TopLevelCommit)]
    public class LibraryModelContextDeleteRule : DeletingRule
    {
        public override void ElementDeleting(ElementDeletingEventArgs e)
        {
            if (e.ModelElement != null)
                if (e.ModelElement.Store.TransactionManager.CurrentTransaction != null)
                    if (e.ModelElement.Store.TransactionManager.CurrentTransaction.IsSerializing)
                        return;

            if (e.ModelElement == null)
                return;

            if (ImmutabilityExtensionMethods.GetLocks(e.ModelElement) != Locks.None)
                return;

            LibraryModelContext libraryModelContext = e.ModelElement as LibraryModelContext;
            if (libraryModelContext != null)
                if (libraryModelContext.ViewContext != null)
                    libraryModelContext.ViewContext.Delete();
        }
    }
}
