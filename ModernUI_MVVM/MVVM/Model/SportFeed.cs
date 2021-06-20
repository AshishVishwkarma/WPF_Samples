using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModernUI_MVVM.MVVM.Model
{
    class SportFeed : IFeed
    {
        public string getMessage()
        {
            string message = "Current Sport feed";
            return message;
        }
    }
}
