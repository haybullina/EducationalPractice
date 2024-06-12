using EducationalPractice.DBConnectionClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EducationalPractice.AdoModel
{
    public partial class Users_Services
    {

        public string nameClient 
        {
            get { return $"{DBConnection.Connection.Users.Where(x => x.id == this.user_id).FirstOrDefault().name}"; }
        }
        public string surnameClient
        {
            get { return $"{DBConnection.Connection.Users.Where(x => x.id == this.user_id).FirstOrDefault().surname}"; }
        }
        public string telephone_numberClient
        {
            get { return $"{DBConnection.Connection.Users.Where(x => x.id == this.user_id).FirstOrDefault().telephone_number}"; }
        }
        public string master
        {
            get {
                var master = DBConnection.Connection.Users.Where(x => x.id == this.master_id).FirstOrDefault();
                return $"{master.surname} {master.name}"; }
        }
        public string reсeption
        {
            get
            {
                var reсeption = DBConnection.Connection.Users.Where(x => x.id == this.reception_id).FirstOrDefault();
                return $"{reсeption.surname} {reсeption.name}";
            }
        }
        public string discount
        {
            get
            {
                var discount = DBConnection.Connection.Discounts.Where(x => x.id == this.dicount_id).FirstOrDefault();
                return $"{discount.title} {discount.size}";
            }
        }

        public string service
        {
            get
            {
                var service = DBConnection.Connection.Services.Where(x => x.id == this.service_id).FirstOrDefault();
                return $"{service.title}";
            }
        }
    }
}
