using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Poetas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            using(var context = new PoetasEntities())
            {
                //var poet = new Poet { PoetId = 1, FirstName = "John", MiddleName = "Cassidy", LastName = "Milton" };
                //var poem = new Poem { PoemId = 1, Title = "Paradise Lost" };
                //var meter = new Meter { MeterId = 1, MeterName = "Iambic Pentameter" };
                //poem.Meter = meter;
                //poem.Poet = poet;
                //context.Poems.Add(poem);
                //poem = new Poem { PoemId = 2, Title = "Paradise Regained" };
                //poem.Meter = meter;
                //poem.Poet = poet;
                //context.Poems.Add(poem);
                //poet = new Poet { PoetId = 2, FirstName = "Lewis", MiddleName = "C.", LastName = "Carroll" };
                //poem = new Poem { PoemId = 3, Title = "The Hunting of the Shark" };
                //meter = new Meter { MeterId = 2, MeterName = "Anapestic Tetrameter" };
                //poem.Meter = meter;
                //poem.Poet = poet;
                //context.Poems.Add(poem);
                //poet = new Poet { PoetId = 3, FirstName = "Lord", MiddleName = "J.", LastName = "Byron" };
                //poem = new Poem { PoemId = 4, Title = "Don Juan" };
                //poem.Meter = meter;
                //poem.Poet = poet;
                //context.Poems.Add(poem);
                //context.SaveChanges();

                var query = context.Poems
                    .Select(p=> new
                    {
                        Poet = p.Poet.FirstName,
                        Title = p.Title,
                        Meter = p.Meter.MeterName
                    }).ToList();

                GridView1.DataSource = query;
                GridView1.DataBind();
            }
        }
    }
}