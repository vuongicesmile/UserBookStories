﻿namespace UsedBookStore.DataAccess.Entities
{
    public class Coupon
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public int Discount { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public string? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
