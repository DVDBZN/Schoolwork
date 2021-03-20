using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace C968_Software1CSharp_DBozin9
{
    public class Program
    {
        public static void Start()
        {
            Application.SetCompatibleTextRenderingDefault(false);
        }

        //Instantiate inventory and mainform in a way that makes them accessible
        public static Inventory inventory = new Inventory();
        public static MainForm title = new MainForm();

        public static void Main()
        {
            //Auto-generated code
            Application.EnableVisualStyles();
            Application.Run(title);
        }
    }

    public class Inventory
    {
        //Arrays
        public List<Product> Products = new List<Product>();
        public List<Part> allParts = new List<Part>();

        //Functions

        //Add product to product array
        public void addProduct(Product product)
        {
            Products.Add(product);
        }

        //Remove product from product array
        public bool removeProduct(int i)
        {
            //Removes product if in range of array
            if (Products.Count - 1 < i || i < 0)
            {
                return false;
            }

            Products.RemoveAt(i);

            //Set all higher products' IDs down by one
            for (int j = i; j < Products.Count; j++)
            {
                Products[j].ProductID = j;
            }
            return true;
        }

        //Return product at index
        public Product lookupProduct(int i)
        {
            if (i > Products.Count)
                return Products[i];
            else
                return null;
        }

        //Update product to new product
        public void updateProduct(int i, Product product)
        {
            if (i <= Products.Count)
                Products[i] = product;
        }

        //Add part to part array
        public void addPart(Part part)
        {
            allParts.Add(part);
        }

        //Delete part
        public bool deletePart(Part part)
        {
            //Removes part if in range of array
            for (int i = 0; i < allParts.Count; i++)
            {
                //If part matches given part
                if (allParts[i] == part)
                {
                    allParts.RemoveAt(i);

                    //Adjust part IDs
                    for (int j = i; j < allParts.Count; j++)
                    {
                        allParts[j].PartID = j;
                    }
                    return true;
                }
            }
            return false;
        }

        //Return part by index
        public Part lookupPart(int i)
        {
            if (i > allParts.Count)
                return allParts[i];
            else
                return null;
        }

        //Part is new part
        public void updatePart(int i, Part part)
        {
            if (i <= allParts.Count)
                allParts[i] = part;
        }
    }

    public class Product
    {
        //Arrays
        public List<Part> associatedParts = new List<Part>();

        //Variables with gets/sets
        public int ProductID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int InStock { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }

        public Product(int productID, string name, double price, int inStock, int min, int max)
        {
            //Assign variable to variable
            ProductID = productID;
            Name = name;
            Price = price;

            //TODO: These exceptions will not be used since constructor requires correct types.
            //Use this when saving part/product
            if (inStock.GetType() != typeof(int))
            {
                throw new ArgumentException("Variable inStock must be of type \"int\".", "inStock");
            }
            else
            {
                InStock = inStock;
            }

            if (min.GetType() != typeof(int))
            {
                throw new ArgumentException("Variable min must be of type \"int\".", "min");
            }
            else
            {
                Min = min;
            }

            if (max.GetType() != typeof(int))
            {
                throw new ArgumentException("Variable max must be of type \"int\".", "max");
            }
            else
            {
                Max = max;
            }
        }

        //Add an assocated part to the product
        public void addAssociatedPart(Part part)
        {
            associatedParts.Add(part);
        }

        //Remove an assocated part from the product
        public bool removeAssociatedPart(int i)
        {
            //Removes part if in range of array
            if (associatedParts.Count - 1 < i || i < 0)
            {
                return false;
            }
            associatedParts.RemoveAt(i);
            return true;
        }

        //Self-explanatory
        public Part lookupAssociatedPart(int i)
        {
            return associatedParts[i];
        }
    }
}

public abstract class Part
{
    //Variables with gets/sets
    public int PartID { get; set; }
    public string Name { get; set; }
    public double Price { get; set; }
    public int InStock { get; set; }
    public int Min { get; set; }
    public int Max { get; set; }

    //Assigns variables to variables
    public Part(int partID, string name, double price, int inStock, int min, int max)
    {
        PartID = partID;
        Name = name;
        Price = price;

        //Same TODO as above
        if (inStock.GetType() != typeof(int))
        {
            throw new ArgumentException("Variable inStock must be of type \"int\".", "inStock");
        }
        else
        {
            InStock = inStock;
        }

        if (min.GetType() != typeof(int))
        {
            throw new ArgumentException("Variable min must be of type \"int\".", "min");
        }
        else
        {
            Min = min;
        }

        if (max.GetType() != typeof(int))
        {
            throw new ArgumentException("Variable max must be of type \"int\".", "max");
        }
        else
        {
            Max = max;
        }
    }
}

//Using inheritance for different parts
public class Inhouse : Part
{
    //Additional variables
    public int MachineID { get; set; }

    public Inhouse(int partID, string name, double price, int inStock, int min, int max, int machineID)
        : base(partID, name, price, inStock, min, max)
    {
        MachineID = machineID;
    }
}

public class Outsourced : Part
{
    //Additional variables
    public string CompanyName { get; set; }

    public Outsourced(int partID, string name, double price, int inStock, int min, int max, string companyName)
        : base(partID, name, price, inStock, min, max)
    {
        CompanyName = companyName;
    }
}