using EducationalPractice.DBConnectionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPractice.AdoModel
{
    public partial class Users
    {

        public override string ToString()
        {
            return $"{this.name} {this.telephone_number}";
        }

        public string role 
        {
            get 
            {
                return $"{DBConnection.Connection.Roles.Where(x => x.id == this.role_id).FirstOrDefault().title}";
            }
        }
    }
}
