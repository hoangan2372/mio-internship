using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace mio1412.Models
{
    public class Report
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [DisplayName("Tasks")]
        public string Task_Name { get; set; }
        public string Progress { get; set; }
        public string Issues { get; set; }
        [DisplayName("Date Created")]
        public DateTime DateCreated { get; set; }

        [ForeignKey("Account")]
        public int? AccountId { get; set; }
        public virtual Account Account { get; set; }
    }
}
