using System;

namespace Commerce.Common
{
    public class DiscountDisplayCollection : System.Collections.CollectionBase
    {
        public DiscountDisplay this[int index] { get { return (DiscountDisplay)List[index]; } }

        public void Add(DiscountDisplay item) { List.Add(item); }

        public void Remove(int index) { List.RemoveAt(index); }

        public string ToXML() { return Utility.ObjectToXML(typeof(DiscountDisplayCollection), this); }

        public override string ToString()
        {
            string items = "";
            foreach (DiscountDisplay item in this)
            {
                items += "<b>" + item.Name + "</b>: " + item.DiscountAmount + "<br>";
            }
            return items;
        }
    }

    public class DiscountDisplay
    {
        public static DiscountDisplay GetDiscount(int productID, int quantity, decimal price)
        {
            DiscountDisplay item = new DiscountDisplay();
            System.Data.IDataReader dr = SPsQtyDiscount.StoreProductQtyDiscountGet(productID, quantity).GetReader();
            if (dr.Read())
            {
                decimal discount = decimal.Parse(dr["discount"].ToString());
                if (bool.Parse(dr["isPercent"].ToString()))
                {
                    item.DiscountAmount = (price * (discount / 100)) * quantity;
                    item.Discount = discount;
                    item.IsPercent = true;
                    item.Qty = int.Parse(dr["quantity"].ToString());
                    return item;
                }
                else
                {
                    item.DiscountAmount = (discount * quantity);
                    item.Discount = discount;
                    item.IsPercent = false;
                    item.Qty = int.Parse(dr["quantity"].ToString());
                    return item;
                }
            }
            return null;
        }
        public DiscountDisplay(int qty, decimal discount, decimal discountAmount, string name, bool isPercent)
        {
            this.qty = qty;
            this.discount = discount;
            this.discountAmount = discountAmount;
            this.name = name;
            this.isPercent = isPercent;
        }
        public DiscountDisplay(int qty, decimal price, string name)
        {
            this.qty = qty;
            this.price = price;
            this.name = name;
        }
        public DiscountDisplay() { }

        #region Private

        private int qty;
        private decimal price;
        private decimal discount;
        private decimal discountAmount;
        private string name;
        private bool isPercent;

        #endregion

        #region Public

        public int Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        public decimal Price
        {
            get { return price; }
            set { price = value; }
        }
        public decimal Discount
        {
            get { return discount; }
            set { discount = value; }
        }
        public decimal DiscountAmount
        {
            get { return discountAmount; }
            set { discountAmount = value; }
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public bool IsPercent
        {
            get { return isPercent; }
            set { isPercent = value; }
        }

        #endregion
    }
}