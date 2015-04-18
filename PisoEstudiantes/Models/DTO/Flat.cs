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
        private string capacity;
        private string description;
        private Owner owner;
        private string profile_img;
        private string img1;
        private string img2;
        private string img3;
        private string img4;
        private string img5;
        private string img6;
        private string img7;
        private double price;

        public Flat(int id, string province, string city, string postal_code, string address, string description,
        string capacity, Owner owner, string profile_img, string img1, string img2, string img3,
        string img4, string img5, string img6, string img7, double price)
        {
            this.id = id;
            this.province = province;
            this.city = city;
            this.postal_code = postal_code;
            this.address = address;
            this.description = description;
            this.capacity = capacity;
            this.owner = owner;
            this.profile_img = profile_img;
            this.img1 = img1;
            this.img2 = img2;
            this.img3 = img3;
            this.img4 = img4;
            this.img5 = img5;
            this.img6 = img6;
            this.img7 = img7;
            this.price = price;
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

        public String Capacity
        {
            get { return capacity; }
            set { capacity = value; }
        }

        public String Description
        {
            get { return description; }
            set { description = value; }
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

        public String IMG1
        {
            get { return img1; }
            set { img1 = value; }
        }

        public String IMG2
        {
            get { return img2; }
            set { img2 = value; }
        }

        public String IMG3
        {
            get { return img3; }
            set { img3 = value; }
        }
        public String IMG4
        {
            get { return img4; }
            set { img4 = value; }
        }
        public String IMG5
        {
            get { return img5; }
            set { img5 = value; }
        }
        public String IMG6
        {
            get { return img6; }
            set { img6 = value; }
        }
        public String IMG7
        {
            get { return img7; }
            set { img7 = value; }
        }

        public double Price
        {
            get { return price; }
            set { price = value; }
        }
    }
}