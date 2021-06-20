using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUI_MVVM.MVVM.Model
{
    class BusinessFeed : IFeed
    {
        public string getMessage()
        {
            string message = "Current Business feed";
            return message;
        }
    }
}
