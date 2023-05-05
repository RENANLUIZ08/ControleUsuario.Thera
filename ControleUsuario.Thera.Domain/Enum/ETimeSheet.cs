using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Thera.Enum
{
    public enum ETimeSheet
    {
        [Description("CHEGUEI")]
        Start = 0,
        [Description("FUI ALMOÇAR")]
        LuchStart = 1,
        [Description("VOLTEI")]
        EndStart = 2,
        [Description("FUI")]
        End = 3
    }
}
