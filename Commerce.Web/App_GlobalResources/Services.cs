using System;
using System.Web;
using System.Collections;
using System.Web.Services;
using System.Web.Services.Protocols;
using Commerce.Common;
using System.Data;
/// <summary>
/// Summary description for Services
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
public class Services : System.Web.Services.WebService {

    public Services () {

        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    public ProductCollection GetProducts() {
        return ProductController.GetAll();
    }

    [WebMethod]
    public ProductCollection GetProducts(int categoryID) {
        IDataReader rdr=ProductController.GetByCategoryID(categoryID);
        ProductCollection coll=new ProductCollection();
        coll.Load(rdr);
        rdr.Close();
        return coll;
    }
    [WebMethod]
    public Product GetProduct(string sku) {
        return new Product(sku);
    }
    [WebMethod]
    public Product GetProduct(int productID) {
        return new Product(productID);
    }
    [WebMethod]
    public CategoryCollection GetCategories() {
        return CategoryController.CategoryList;
    }
    [WebMethod]
    public Category GetCategory(string categoryGUID) {
        return new Category("categoryGUID",categoryGUID);
    }
    [WebMethod]
    public Transaction TransactCreditCartOrder(Commerce.Common.Order order) {
        return OrderController.TransactOrder(order,TransactionType.CreditCardPayment);
    }
}

