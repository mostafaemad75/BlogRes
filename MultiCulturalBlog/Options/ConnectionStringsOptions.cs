using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MultiCulturalBlog.Options
{
    public enum ConnectionStringMode
    {
        Azure,
        Emulator
    }

    public class ConnectionStringsOptions
    {
        public ConnectionStringMode Mode { get; set; }
        public ConnectionStringOptions Azure { get; set; }
        public ConnectionStringOptions Emulator { get; set; }

        public ConnectionStringOptions ActiveConnectionStringOptions =>
            Mode == ConnectionStringMode.Azure ? Azure : Emulator;
    }
}
