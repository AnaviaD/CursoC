using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StopWatch.Clases
{
    public class assigmentRecordClass
    {
        public string Id { get; set; }
        [ForeignKey("assigmentClass")]
        public string AssigmentId{ get; set; }
        public DateTime InitH { get; set; }
        public DateTime FinishH { get; set; }
        public string TotalTime { get; set; }
    }

    //  [Id]
    //  ,[AssigmentId]
    //  ,[InitH]
    //  ,[FinishH]
    //  ,[TotalTime]
}
