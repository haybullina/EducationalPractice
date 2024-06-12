using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPractice.AdoModel
{
    public partial class Roles
    {
        public override string ToString()
        {
            return $"{this.title}";
        }
    }
}
