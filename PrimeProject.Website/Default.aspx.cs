using System;
using System.Linq;
using PrimeProject.Business.Application.Manager;
using PrimeProject.Business.Entity;

namespace PrimeProject.Website
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Btn1_OnClick(object sender, EventArgs e)
        {
            for (int i = 1; i < 5; i++)
            {
                string itemName = "", itemType = "";

                switch (i)
                {
                    case 1:
                        itemName = "Apel";
                        itemType = "Buah";
                        break;
                    case 2:
                        itemName = "Mobil";
                        itemType = "Kendaraan";
                        break;
                    case 3:
                        itemName = "Motor";
                        itemType = "Kendaraan";
                        break;
                    case 4:
                        itemName = "Pisang";
                        itemType = "Buah";
                        break;
                    case 5:
                        itemName = "Handphone";
                        itemType = "Elektronik";
                        break;
                }

                ItemManager.GetInstance().Insert(new Item
                {
                    ItemId = Guid.NewGuid(),
                    ItemName = itemName,
                    Type = itemType,
                    Parameters = ""
                });
            }
            _UpdateView();
        }

        protected void Btn2_OnClick(object sender, EventArgs e)
        {
            var item = ItemManager.GetInstance().GetAll().FirstOrDefault();
            if (item != null)
            {
                ItemManager.GetInstance().Delete(item.ItemId);
            }
            _UpdateView();
        }

        protected void Btn3_OnClick(object sender, EventArgs e)
        {
            _UpdateView();
        }

        private void _UpdateView()
        {/*
            Lbl1.Text = "";

            var items = ItemManager.GetInstance().GetAll();

            foreach (var item in items)
            {
                Lbl1.Text = Lbl1.Text + " " + item.ItemName + "</br>";
                Lbl1.Text = Lbl1.Text + " " + item.Type + "</br>";
                Lbl1.Text = Lbl1.Text + "</br>";
            }*/
        }
    }
}