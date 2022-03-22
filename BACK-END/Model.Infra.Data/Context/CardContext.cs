using Microsoft.EntityFrameworkCore;
using Model.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Infra.Data.Context
{
    public class CardContext : DbContext
    {
        public CardContext(DbContextOptions<CardContext> options)
          : base(options)
        { 
        }


        public DbSet<Card> Cards { get; set; }
    }
}
