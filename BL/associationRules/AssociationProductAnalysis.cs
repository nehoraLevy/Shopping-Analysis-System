using Accord.IO;
using Accord.MachineLearning.Rules;
using BE;
using DAL;
//using Syncfusion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using Syncfusion.Pdf.Graphics;
//using Syncfusion.Pdf;
//using Syncfusion.Pdf.Tables;
using System.Runtime.Serialization;
using PdfSharp.Pdf;
using PdfSharp.Drawing;

namespace BL.associationRules
{
    [Serializable()]
    internal class AssociationProductAnalysis: IAssociationProductAnalysis,  ISerializable
    {

        private IDb _db;

        public AssociationProductAnalysis()
        {
            _db = new DalFactory().GetDb();
        }

        public string[] CreateShopingListRecommendation(string path)
        {
            IEnumerable<IEnumerable<Product>> products = GetNewRecommendedProductList();
            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Recommended Shopping List";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 10, XFontStyle.Italic);
            DataTable table = new DataTable();

            table.Columns.Add("Product Name");
            table.Columns.Add("Bar Code");

            string strToPDF="";
            string[] result = new string[] {"hi," };

            if (products == null || products.Count() == 0)
            {
                table.Rows.Add(new string[] { "There is still no shopping list, Add Shopping Carts", "" });
                strToPDF += "There is still no shopping list, Add Shopping Carts";
            }
            else
            {
                int i = 0;
                int j = 0;
                foreach (var productGroup in products)
                {
                    foreach (var product in productGroup)
                    {
                        result[j] = product.Name.ToString() + "," + product.BarCode.ToString();
                        j++;
                        strToPDF = " Product Name: "+ product.Name.ToString() + " BarCode: " + product.BarCode.ToString();
                        graph.DrawString(strToPDF, font, XBrushes.Black, new XRect(0,i, 0, i), XStringFormats.TopLeft);
                        i += 20;
                        table.Rows.Add(new string[] { product.Name.ToString(), product.BarCode.ToString() });
                        
                    }
                }
            }
            string pdfFilename = "ShoppingList.pdf";
            pdf.Save(@"C:\Users\levy\Desktop\Shopping_project_final\" + pdfFilename);

            return result;

            //pdf.Save()
            //Process.Start(pdfFilename);

            /*
            IEnumerable<IEnumerable<Product>> products = GetNewRecommendedProductList();


            PdfDocument doc = new PdfDocument();

            PdfPage page = doc.Pages.Add();

            PdfLightTable pdfLightTable = new PdfLightTable();

            DataTable table = new DataTable();

            table.Columns.Add("Product Name");
            table.Columns.Add("Bar Code");

            if (products == null || products.Count() == 0)
                table.Rows.Add(new string[] { "There is still no shoping list", "" });
            else
                foreach (var productGroup in products)
                {
                    foreach (var product in productGroup)
                    {
                        table.Rows.Add(new string[] { product.Name.ToString(), product.BarCode.ToString() });
                    }
                }

            pdfLightTable.Style.CellPadding = 3;
            pdfLightTable.ApplyBuiltinStyle(PdfLightTableBuiltinStyle.GridTable3Accent3);

            pdfLightTable.DataSource = table;

            pdfLightTable.Style.ShowHeader = true;

            pdfLightTable.Draw(page,new Syncfusion.Drawing.PointF( 0, 0));
            //Save the document
            //doc.Save("ShopingList" + DateTime.Now.ToString() + ".pdf");
            doc.Save("PdfTable.pdf");

            doc.Close(true);

            Process.Start("PdfTable.pdf");*/

        }


        private IEnumerable<IEnumerable<Product>> GetNewRecommendedProductList()
        {
            IEnumerable<IMyAssociationRule> associationRules = GetAssosiatonRules();
            ShoppingCart shoppingCarts = _db.ShoppingCarts.OrderBy(t => t.BuyDate).ToList().Last();
            IEnumerable<Product> transactionProduct = from productTransaction in shoppingCarts.ProductTransactions
                                                      select productTransaction.Product;
            var p = from rule in associationRules
                    from pt in transactionProduct
                    where rule.Product.Count() >0 && rule.Product.First().Id == pt.Id
                    select rule.GoesWith;

            return p;
        }

        private IEnumerable<Product> GetProductListByAssosiatonRules(AssociationRule<int>[] rules)
        {
            IEnumerable<Product> productList = new List<Product>();
            foreach (var rule in rules)
            {
                productList.Concat(BarCodesToProducts(rule.Y));
            }
            return productList;
        }

        private SortedSet<int>[] GetBasicPoductList()
        {
            return GetLastTransactionByBarCode();
        }

        private SortedSet<int>[] GetLastTransactionByBarCode()
        {
            ShoppingCart shoppingCarts = _db.ShoppingCarts.OrderBy(t => t.BuyDate).ToList().Last();
            List<SortedSet<int>> dataset = new List<SortedSet<int>>();
            SortedSet<int> transactionBarCodes = new SortedSet<int>();
            foreach (var productTransaction in shoppingCarts.ProductTransactions)
            {
                transactionBarCodes.Add((int)productTransaction.Product.Id);
            }
            dataset.Add(transactionBarCodes);
            return dataset.ToArray();
        }

        public IEnumerable<IMyAssociationRule> GetAssosiatonRules()
        {
            SortedSet<int>[] dataset = GetAllTransactionByBarCodes();

            Apriori apriori = new Apriori(threshold: 2, confidence: 0);

            AssociationRuleMatcher<int> classifier = apriori.Learn(dataset);

            AssociationRule<int>[] rules = classifier.Rules;

            return GetAssosiatonRules(rules);
        }

        private IEnumerable<IMyAssociationRule> GetAssosiatonRules(AssociationRule<int>[] rules)
        {
            List<MyAssociatonRule> assosiatonRules = new List<MyAssociatonRule>();
            foreach (var rule in rules)
            {
                assosiatonRules.Add(new MyAssociatonRule(BarCodesToProducts(rule.X),
                                                                BarCodesToProducts(rule.Y),
                                                                rule.Confidence));
            }
            return assosiatonRules;
        }

        private IEnumerable<Product> BarCodesToProducts(SortedSet<int> barcodes)
        {
            IEnumerable<Product> allProducts = _db.Products;
            IEnumerable<Product> products = new List<Product>();
            foreach (var barCode in barcodes)
            {
                products = products.Concat(from product in allProducts
                                           where product.Id == barCode
                                           select product);
            }
            return products;
        }

        private SortedSet<int>[] GetAllTransactionByBarCodes()
        {
            IEnumerable<ShoppingCart> shoppingCarts = _db.ShoppingCarts;
            List<SortedSet<int>> dataset = new List<SortedSet<int>>();
            foreach (var shoppingCart in shoppingCarts)
            {
                SortedSet<int> transactionBarCodes = new SortedSet<int>();
                foreach (var productTransaction in shoppingCart.ProductTransactions)
                {
                    transactionBarCodes.Add((int)productTransaction.Product.Id);
                }
                dataset.Add(transactionBarCodes);
            }
            return dataset.ToArray();
        }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            throw new NotImplementedException();
        }
    }
}
