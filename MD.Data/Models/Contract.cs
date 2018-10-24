namespace MD.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public partial class Contract
    {
        public Guid Id { get; set; }

        [Display(Name = "Номер")]
        public string Number { get; set; }

        [Display(Name = "Дата")]
        public DateTime Date { get; set; }

    }
}
