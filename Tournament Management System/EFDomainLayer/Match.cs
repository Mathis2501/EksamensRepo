using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainLayer
{
    public class Match : IID
    {
        public int MatchId { get; set; }
        public int ID
        {
            get { return MatchId; }

            set { MatchId = value; }
        }
    }
}
