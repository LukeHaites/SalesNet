using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace SalesNet.Models
{
    public class Persons
    {
        [XmlElement("Person")]
        public List<Person> person;

        public Persons()
        {
            person = new List<Person>();
        }
    }

    public class Person
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string Title { get; set; }
        public string Initials { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public string Sex { get; set; }
        public string DateOfBirth { get; set; }
        public string StartDate { get; set; }
        public string JobTitle { get; set; }
        private DateTime UpdateTimeStamp { get; set; }
        public bool IsAgent { get; set; }
        public Addresses Addresses { get; set; }
        [XmlElement("Contacts")]
        public List<Contacts> Contacts { get; set; }
        public Currency Currency { get; set; }

        public Person()
        {
            Contacts = new List<Contacts>();
        }

        [XmlElement("UpdateTimeStamp")]
        public string UpdateTimeStampString
        {
            get { return this.UpdateTimeStamp.ToString(); }
            set { this.UpdateTimeStamp = DateTime.Parse(value); }
        }
    }

    public class Addresses
    {
        [XmlElement("Billing")]
        public Address BillingAddress { get; set; }
        [XmlElement("Delivery")]
        public Address deliveryAddress { get; set; }
    }

    public class Address
    {
        public int Id { get; set; }
        public string AddressType { get; set; }
        public string ContactName { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
    }

    public class Contacts
    {
        public string Email { get; set; }
        public Phones Phones { get; set; }
    }

    public class Phones
    {
        public string Home { get; set; }
        public string Mobile { get; set; }
        public string Work { get; set; }
    }

    public class Currency
    {
        public string Code { get; set; }
        public string Format { get; set; }
    }
}