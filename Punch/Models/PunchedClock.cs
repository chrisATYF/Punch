using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Humanizer;

namespace Punch.Models
{
    public class PunchedClock
    {
        public int Id { get; set; }
        public string ApplicationUserId { get; set; }
        public ApplicationUser User { get; set; }
        public DateTime PunchIn { get; set; }
        public DateTime? PunchOut { get; set; }
        [NotMapped]
        public string PunchInHumanized => PunchIn.Humanize();
        [NotMapped]
        public string PunchOutHumanized => PunchOut.Humanize();
        [NotMapped]
        public string PunchSpanHumanized
        {
            get
            {
                if (!PunchOut.HasValue)
                {
                    return "";
                }
                else
                {
                    var difference = PunchIn - PunchOut.Value;
                    return difference.Humanize();
                }
            }
        }
    }
}