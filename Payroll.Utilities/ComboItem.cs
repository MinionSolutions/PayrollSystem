using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Security;
using Payroll.BusinessObjects;


namespace Payroll.Utilities
{
    public class ComboItem
    {
        #region Properties
        public string Text { get; set; }
        public object Value { get; set; }
        #endregion

        #region Public Methods

        public override string ToString()
        {
            return Text;
        }
        #endregion

    }
}
