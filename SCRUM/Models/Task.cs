using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace SCRUM.Models
{
    public class Task
    {
        public virtual int ID { get; set; } //usunac po wprowadzeniu bazy danych
        public virtual string WhoMadePost { get; set; } //string z imieniem autora
        public virtual string DateOfPost { get; set; } //DataTime z datą dodania postu
        
        [Required]
        [StringLength(5000,ErrorMessage = "Zla ilosc znakow", MinimumLength = 5)]
        public virtual string WhatIHaveDone { get; set; } //Co zrobilem

        [Required]
        [StringLength(5000, ErrorMessage = "Zla ilosc znakow", MinimumLength = 5)]
        public virtual string WhatIWillDo { get; set; } //Co zrobie

        [Required]
        [StringLength(5000, ErrorMessage = "Zla ilosc znakow", MinimumLength = 5)]
        public virtual string WhatProblemsIgot { get; set; } //Jakie mialem problemy
    }
}