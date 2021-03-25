using System;

namespace ProductionWebAPI.Models
{
    /// <summary>
    /// A view model of Product DAL model 
    /// </summary>
    public class ProductViewModel
    {
        /// <summary>
        /// This is a key of the product
        /// </summary>
        public int ProductID { get; set; }
        
        /// <summary>
        /// This is a name of the product
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// This is a product number in catalog
        /// </summary>
        public string ProductNumber { get; set; }

        /// <summary>
        /// This is make flag
        /// </summary>
        public bool MakeFlag { get; set; }

        /// <summary>
        /// This is finished shipment flag
        /// </summary>
        public bool FinishedGoodsFlag { get; set; }

        /// <summary>
        /// This is color of the product
        /// </summary>
        public string Color { get; set; }

        /// <summary>
        /// This is safety stock level
        /// </summary>
        public short SafetyStockLevel { get; set; }

        /// <summary>
        /// This is reorder point
        /// </summary>
        public short ReorderPoint { get; set; }

        /// <summary>
        /// This is standard coast of the product
        /// </summary>
        public decimal StandardCost { get; set; }

        /// <summary>
        /// This is list price of the product
        /// </summary>
        public decimal ListPrice { get; set; }

        /// <summary>
        /// This is size of the product
        /// </summary>
        public string Size { get; set; }

        /// <summary>
        /// This is size unit measure code
        /// </summary>
        public string SizeUnitMeasureCode { get; set; }

        /// <summary>
        /// This is weight unit measure code
        /// </summary>
        public string WeightUnitMeasureCode { get; set; }

        /// <summary>
        /// This is weight of the product
        /// </summary>
        public decimal? Weight { get; set; }

        /// <summary>
        /// This is days which need to manufacture the product
        /// </summary>
        public int DaysToManufacture { get; set; }

        /// <summary>
        /// This is product line of the product
        /// </summary>
        public string ProductLine { get; set; }

        /// <summary>
        /// This is class of the product
        /// </summary>
        public string Class { get; set; }

        /// <summary>
        /// This is stile of the product 
        /// </summary>
        public string Style { get; set; }

        /// <summary>
        /// This is product subcategory ID
        /// </summary>
        public int? ProductSubcategoryID { get; set; }

        /// <summary>
        /// This is product model ID
        /// </summary>
        public int? ProductModelID { get; set; }

        /// <summary>
        /// This is sell start date
        /// </summary>
        public DateTime SellStartDate { get; set; }

        /// <summary>
        /// This is sell end date
        /// </summary>
        public DateTime? SellEndDate { get; set; }

        /// <summary>
        /// This is discontinue date
        /// </summary>
        public DateTime? DiscontinuedDate { get; set; }

        /// <summary>
        /// This is row guid
        /// </summary>
        public Guid rowguid { get; set; }

        /// <summary>
        /// This is modified date
        /// </summary>
        public DateTime ModifiedDate { get; set; }
    }
}