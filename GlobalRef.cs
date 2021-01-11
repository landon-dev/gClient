using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gClient
{
    class GlobalRef
    {
        public static mainFm _clientFm = null;
        public GlobalRef(mainFm __clientFm)
        {
            _clientFm = __clientFm;
        }


        public class Client
        {
            public class Settings
            {
                public class UI
                {
                    public static int headerHeight = 40;
                    public static bool Overlay = false;
                    public class Header
                    {
                        public const int maxHeight = 400;
                        public const int minHeight = 25;
                    }
                }
            }
        }
    }
}
