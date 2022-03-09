﻿using System;

namespace Appointment.Domain.Main
{
    public class CTRace
    {
        public Guid RaceId { get; set; }
        public string Code { get; set; }
        public string DisplayValue { get; set; }
        public string Description { get; set; }
        public bool IsUserMaintainable { get; set; }
        public DateTime EffectiveStartDate { get; set; }
        public DateTime EffectiveEndDate { get; set; }
        public DateTime CreateDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public string IRISCode { get; set; }
    }
}