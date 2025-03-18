using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    class ENProduct
    {

        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code { set { _code = value; } get { return _code; } }
        public string Name { set { _name = value; } get { return _name; } }



    }
}
