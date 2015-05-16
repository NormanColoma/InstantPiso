using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PisoEstudiantes.Models.DTO
{
    public class Flat
    {
        private int id;
        private string province;
        private string city;
        private string address;
        private string postal_code;
        private int bedrooms;
        private int bathrooms;
        private int available_bedrooms;
        private int minimum;
        private string description;
        private string tittle;
        private string property_type;
        private DateTime availableDate;
        private Owner owner;
        private string profile_img;
        private double price;
        private List<Schedule> schedule;

        public Flat(int id, string province, string city, string postal_code, string address, string description,
        int bedrooms, Owner owner, string profile_img, double price)
        {
            this.id = id;
            this.province = province;
            this.city = city;
            this.postal_code = postal_code;
            this.address = address;
            this.description = description;
            this.bedrooms = bedrooms;
            this.owner = owner;
            this.profile_img = profile_img;
            this.price = price;
        }

        public Flat(string province, string city, string postal_code, string address, string description, string tittle,
        int bedrooms, Owner owner, string profile_img, double price, int bathrooms, int available_bedrooms, int minimum, string property_type,
        DateTime availableDate)
        {
            this.province = province;
            this.city = city;
            this.postal_code = postal_code;
            this.address = address;
            this.description = description;
            this.bedrooms = bedrooms;
            this.owner = owner;
            this.profile_img = profile_img;
            this.price = price;
            this.bathrooms = bathrooms;
            this.available_bedrooms = available_bedrooms;
            this.minimum = minimum;
            this.property_type = property_type;
            this.availableDate = availableDate;
            this.tittle = tittle;
        }
        public int ID
        {
            get { return id; }
            set { id = value; }
        }

        public String Province
        {
            get { return province; }
            set { province = value; }
        }
        public String City
        {
            get { return city; }
            set { city = value; }
        }

        public String Address
        {
            get { return address; }
            set { address = value; }
        }

        public String PC
        {
            get { return postal_code; }
            set { postal_code = value; }
        }

        public int Bedrooms
        {
            get { return bedrooms; }
            set { bedrooms = value; }
        }

        public int Bathrooms
        {
            get { return bathrooms; }
            set { bathrooms = value; }
        }

        public int Minimum
        {
            get { return minimum; }
            set { minimum = value; }
        }

        public int AvailableBedrooms
        {
            get { return available_bedrooms; }
            set { available_bedrooms = value; }
        }

        public DateTime AvailableDate
        {
            get { return availableDate; }
            set { availableDate = value; }
        }


        public String Description
        {
            get { return description; }
            set { description = value; }
        }

        public String Tittle
        {
            get { return tittle; }
            set { tittle = value; }
        }

        public String PropertyType
        {
            get { return property_type; }
            set { property_type = value; }
        }

        public Owner Owner
        {
            get { return owner; }
            set { owner = value; }
        }

        public String Profile
        {
            get { return profile_img; }
            set { profile_img = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }

        public List<Schedule> Schedule
        {
            get { return schedule; }
            set { schedule = value; }
        }
    }
}