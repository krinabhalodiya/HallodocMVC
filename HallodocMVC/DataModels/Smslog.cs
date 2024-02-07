﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace HallodocMVC.DataModels;

[Table("SMSLog")]
public partial class Smslog
{
    [Key]
    [Column("SMSLogID")]
    [Precision(10, 0)]
    public decimal SmslogId { get; set; }

    [Column("SMSTemplate ", TypeName = "character varying")]
    public string Smstemplate { get; set; } = null!;

    [StringLength(56)]
    public string MobileNumber { get; set; } = null!;

    [StringLength(56)]
    public string? ConfirmationNumber { get; set; }

    public int? RoleId { get; set; }

    [Column("AdminId ")]
    public int? AdminId { get; set; }

    public int? RequestId { get; set; }

    public int? PhysicianId { get; set; }

    [Column("CreateDate ")]
    public DateTime CreateDate { get; set; }

    public DateTime? SentDate { get; set; }

    [Column("IsSMSSent", TypeName = "bit(1)")]
    public BitArray? IsSmssent { get; set; }

    public int SentTries { get; set; }

    public int? Action { get; set; }

    [ForeignKey("AdminId")]
    [InverseProperty("Smslogs")]
    public virtual Admin? Admin { get; set; }

    [ForeignKey("PhysicianId")]
    [InverseProperty("Smslogs")]
    public virtual Physician? Physician { get; set; }

    [ForeignKey("RequestId")]
    [InverseProperty("Smslogs")]
    public virtual Request? Request { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Smslogs")]
    public virtual Role? Role { get; set; }
}
