using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleBookstore.DomainEntities
{
  public class JournalIssue: IBaseItem
  {
    public int Id { get; set; }
    public string Name { get; set; }
    public int Year { get; set; }
    public int Vol { get; set; }
    public int Nr { get; set; }

    //------------------------------------
    public JournalIssue() { } 

  }
}
