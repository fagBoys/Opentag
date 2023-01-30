using Berlance.DataLayer.Entities.Product;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Berlance.Core.DTOs.Product
{
    public class VoteViewModel
    {
        public int manyVote { get; set; }
        public int Votecount { get; set; }
        public int averageVote { get; set; }
    }
}
