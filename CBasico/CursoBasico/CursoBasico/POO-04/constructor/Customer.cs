﻿

namespace CursoBasico.POO_04.constructor
{
    public class Customer
    {
        public int Id;
        public string Name;
        public List<Order> Orders;

        public Customer() 
        {
            Orders = new List<Order>();
        }

        public Customer(int id)
            :this()
        {
            this.Id = id;
        }

        public Customer(int id, string name) 
            :this()
        {
            this.Id = id;
            this.Name = name;
        }
    }
}
