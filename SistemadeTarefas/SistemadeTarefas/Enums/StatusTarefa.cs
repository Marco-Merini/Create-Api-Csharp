using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace SistemadeTarefas.Enums
{
    public enum StatusTarefa
    {
        [Description("TO DO")]
        Todo = 1,
        [Description("IN PROGRESS")]
        InProgress = 2,
        [Description("DONE")]
        Done = 3
    }
}
