using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.model
{
    internal class StudentModel
    {
        private String _uuid;
        private String _name;
        private String _email;
        private String _phone;
        private String _address;
        private String _course;
        private int _age;

        public string Uuid { get => _uuid; set => _uuid = value`; }
        public string Name { get => _name; set => _name = value; }
        public string Email { get => _email; set => _email = value; }
        public string Phone { get => _phone; set => _phone = value; }
        public string Address { get => _address; set => _address = value; }
        public string Course { get => _course; set => _course = value; }
        public int Age
        {
            get => _age;
            set
            {
                if (value > 0)
                {
                    _age = value;
                }
            }
        }
        // Method construct (get and set in java)
        public StudentModel(string Uuid, string Name, string Email, string Phone, string Address, string Course, int Age)
        {
            this.Uuid = Uuid;
            this.Name = Name;
            this.Email = Email;
            this.Phone = Phone;
            this.Address = Address;
            this.Course = Course;
            this.Age = Age;
        }
        // Method construct null
        public StudentModel()
        {
            this.Uuid = "";
            this.Name = "";
            this.Email = "";
            this.Phone = "";
            this.Address = "";
            this.Course = "";
            this.Age = 0;
        }
    }
}
