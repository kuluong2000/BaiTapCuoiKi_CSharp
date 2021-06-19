namespace ModelEF.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Product")]
    public partial class Product
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "ID")]
        public int ID { get; set; }

        [StringLength(250)]
        [Display(Name = "Tên Sản Phẩm")]
        public string Name { get; set; }

        [Display(Name = "Giá Tiền")]
        public decimal? UnitCost { get; set; }

        [Display(Name = "Số Lượng")]
        public int? Quantity { get; set; }
        
        [StringLength(250)]
        [Display(Name = "Hình Ảnh")]
        public string Image { get; set; }


        [StringLength(250)]
        [Display(Name = "Mô tả")]
        public string Description { get; set; }

        [StringLength(50)]
        [Display(Name = "Status")]
        public string Status { get; set; }

        [StringLength(50)]

        [Display(Name = "Loại Sản Phẩm")]
        public string CategoryID { get; set; }
        [Display(Name = "Loại Sản Phẩm")]
        public virtual Category Category { get; set; }
    }
}
