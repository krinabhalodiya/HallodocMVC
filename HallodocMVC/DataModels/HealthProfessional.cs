﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HallodocMVC.DataModels;

public partial class HealthProfessional
{
    [Key]
    public int VendorId { get; set; }

    [StringLength(128)]
    public string VendorName { get; set; } = null!;

    public int? Profession { get; set; }

    [StringLength(56)]
    public string FaxNumber { get; set; } = null!;

    [StringLength(156)]
    public string? Address { get; set; }

    [StringLength(156)]
    public string? City { get; set; }

    [StringLength(56)]
    public string? State { get; set; }

    [StringLength(56)]
    public string? Zip { get; set; }

    public int? RegionId { get; set; }

    public DateTime CreatedDate { get; set; }

    public DateTime? ModifiedDate { get; set; }

    [StringLength(128)]
    public string? PhoneNumber { get; set; }

    [Column("IsDeleted ", TypeName = "bit(1)")]
    public BitArray? IsDeleted { get; set; }

    [Column("IP ")]
    [StringLength(20)]
    public string? Ip { get; set; }

    [StringLength(56)]
    public string? Email { get; set; }

    [StringLength(128)]
    public string? BusinessContact { get; set; }

    [InverseProperty("Vendor")]
    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    [ForeignKey("Profession")]
    [InverseProperty("HealthProfessionals")]
    public virtual HealthProfessionalType? ProfessionNavigation { get; set; }

    [ForeignKey("RegionId")]
    [InverseProperty("HealthProfessionals")]
    public virtual Region? Region { get; set; }
}
