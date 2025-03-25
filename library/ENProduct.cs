using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library
{
    public class ENProduct
    {

        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        public string Code { set { _code = value; } get { return _code; } }
        public string Name { set { _name = value; } get { return _name; } }
        public int Amount { set { _amount = value; } get { return _amount; } }

        public float Price { set { _price = value; } get { return _price; } }

        public int Category { set { _category = value; } get { return _category; } }

        public DateTime CreationDate { set { _creationDate = value; } get { return _creationDate; }}

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Category = category;
            this.CreationDate = creationDate;
        }
        public bool Create()
        {
            CADProduct bd = new CADProduct();
            return bd.Create(this);
        }

        public bool Update()
        {
            CADProduct bd = new CADProduct();
            return bd.Update(this);
        }

        public bool Delete()
        {
            CADProduct bd = new CADProduct();
            return bd.Delete(this);
        }

        public bool Read()
        {
            CADProduct bd = new CADProduct();
            return bd.Read(this);
        }

        public bool ReadFirst()
        {
            CADProduct bd = new CADProduct();
            return bd.ReadFirst(this);
        }

        public bool ReadNext()
        {
            CADProduct bd = new CADProduct();
            return bd.ReadNext(this);
        }

        public bool ReadPrev()
        {
            CADProduct bd = new CADProduct();
            return bd.ReadPrev(this);
        }
    }
}
