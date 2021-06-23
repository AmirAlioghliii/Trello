using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello_.Models;

namespace Infra.Models
{
    public class UserTask
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string UserId{ get; set; }
        public int CategoryId { get; set; }
        public string AdminId { get; set; }
        public string Status { get; set; }

        public ApplicationUser User { get; set; }
        public ApplicationUser Admin { get; set; }
        public Category Category{ get; set; }
    }
}
