using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeaShop.Entity.Models;

namespace TeaShop.DataAccess.Concrete
{
    public class TeaContext:DbContext
    {
        public TeaContext(DbContextOptions options):base(options) { }
        
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Faq> Faqs { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<About> Abouts { get; set; }
        public DbSet<Subscribe> Subscribes { get; set; }

    }
}
