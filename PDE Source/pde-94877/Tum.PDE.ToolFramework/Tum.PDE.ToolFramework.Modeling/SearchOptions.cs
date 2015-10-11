using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tum.PDE.ToolFramework.Modeling
{
    /// <summary>
    /// This class defines possible search options.
    /// </summary>
    public class SearchOptions
    {
        /// <summary>
        /// Gets or sets whether to match case or not.
        /// </summary>
        public bool DoMatchCase { get; set; }

        /// <summary>
        /// Gets or sets whether to match whole word or not.
        /// </summary>
        public bool DoMatchWholeWord { get; set; }

        /// <summary>
        /// Constructor.
        /// </summary>
        public SearchOptions() : this(false, false)
        {
            
        }

        /// <summary>
        /// Constructor.
        /// </summary>
        /// <param name="doMatchCase"></param>
        /// <param name="doMatchWholeWord"></param>
        public SearchOptions(bool doMatchCase, bool doMatchWholeWord)
        {
            this.DoMatchCase = doMatchCase;
            this.DoMatchWholeWord = doMatchWholeWord;
        }
    }
}
