using EducationalPractice.DBConnectionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPractice.AdoModel
{
    public partial class Services
    {
        public string category 
        {
            get 
            {
                return $"{DBConnection.Connection.Categories.Where(x => x.id == this.category_id).FirstOrDefault().title}";
            }
        }

        public override string ToString()
        {
            return $"{this.title} {this.price}";
        }

    }
}
